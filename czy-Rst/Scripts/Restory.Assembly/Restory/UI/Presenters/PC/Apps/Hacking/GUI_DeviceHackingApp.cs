using System;
using Restory.Data.PC;
using Restory.Gameplay.PlayerInput;
using Restory.UI.Presenters.PC.Apps.Hacking.Popups;
using Restory.UI.Presenters.PC.Apps.Hacking.Screens;
using Rewired;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Restory.UI.Presenters.PC.Apps.Hacking
{
	public class GUI_DeviceHackingApp : GUI_PcAppBase
	{
		private enum State
		{
			None = 0,
			Hacking = 1,
			Delay = 2,
			Decision = 3,
			Complete = 4
		}

		[SerializeField]
		private GUI_DeviceConnectionController connectionController;

		[SerializeField]
		private GUI_TypingController typingController;

		[SerializeField]
		private GUI_HackingBackgroundScreen backgroundScreen;

		[SerializeField]
		private GUI_HackingDelayPopup breakPopup;

		[SerializeField]
		private GUI_HackingDelayPopup alertPopup;

		[SerializeField]
		private GUI_HackingCompleteScreen completeScreen;

		[SerializeField]
		private Button completeButton;

		[SerializeField]
		private GUI_HackingDecisionPopup decisionPopup;

		[SerializeField]
		private GUI_DeviceHackingTimeline timeline;

		[SerializeField]
		private GUI_HackingEffectsScreen effectsScreen;

		[SerializeField]
		private GUI_DeviceHackingProgress progress;

		[SerializeField]
		private DeviceHackingAppSettings settings;

		private readonly float baseAutoTypingCooldown = 0.004f;

		private IPlayerInput playerInput;

		private IGameplayInputContextSwitcher inputContextSwitcher;

		private GUI_PcWindowsXpScreen pcScreen;

		private State state;

		private float regressCooldown;

		private float autoTypingCooldown;

		private bool effectsActivated;

		[Inject]
		private void Construct(IPlayerInput playerInput, IGameplayInputContextSwitcher inputContextSwitcher, GUI_PcWindowsXpScreen pcScreen)
		{
			this.playerInput = playerInput;
			this.inputContextSwitcher = inputContextSwitcher;
			this.pcScreen = pcScreen;
		}

		private void Update()
		{
			if (state != State.Hacking)
			{
				return;
			}
			DeviceHackingEvent reachedEvent;
			if (progress.IsComplete)
			{
				Complete();
			}
			else if (settings.AutoHacking)
			{
				if (autoTypingCooldown > 0f)
				{
					autoTypingCooldown -= Time.deltaTime;
				}
				else
				{
					typingController.PerformTyping();
					autoTypingCooldown = baseAutoTypingCooldown / settings.AutoHackingSpeed;
					EnsureHackingEffectsActivated();
				}
				progress.UpdateProgress(settings.AutoHackingSpeed * Time.deltaTime);
			}
			else if (timeline.CheckEvent(progress.Progress, out reachedEvent))
			{
				HandleHackingEvent(reachedEvent);
			}
			else if (regressCooldown > 0f)
			{
				regressCooldown -= Time.deltaTime;
			}
			else
			{
				progress.UpdateProgress((0f - settings.RegressSpeed) * Time.deltaTime);
			}
		}

		protected override void LaunchProcess(PcAppInfo appInfo)
		{
			base.LaunchProcess(appInfo);
			progress.Hide();
			inputContextSwitcher.SwitchInputContext("Typing");
			Subscribe();
			connectionController.Init(settings.ConnectionSettings, out var hackingContent);
			typingController.Init(hackingContent, settings.TypingSettings);
			timeline.Init(settings.TimelineSettings);
			effectsScreen.Init(settings.HackingEffectsSettings);
		}

		protected override void StopProcess()
		{
			effectsActivated = false;
			state = State.None;
			Unsubscribe();
			inputContextSwitcher.RestoreInputContext();
			typingController.Clear();
			if (pcScreen.IsVisible)
			{
				pcScreen.Toolbar.Activate();
			}
		}

		private void Subscribe()
		{
			connectionController.OnConnectionStatusChanged += ResolveConnectionStatusChanged;
			completeButton.onClick.AddListener(ResolveCompleteButtonClick);
			playerInput.AddInputEventDelegate(ResolveButtonPressed, InputActionEventType.ButtonJustPressed);
		}

		private void Unsubscribe()
		{
			connectionController.OnConnectionStatusChanged -= ResolveConnectionStatusChanged;
			completeButton.onClick.RemoveListener(ResolveCompleteButtonClick);
			playerInput.RemoveInputEventDelegate(ResolveButtonPressed, InputActionEventType.ButtonJustPressed);
		}

		private void ResolveConnectionStatusChanged(DeviceConnectionStatus status)
		{
			if (status == DeviceConnectionStatus.Ready)
			{
				state = State.Hacking;
				typingController.ActivateTypingCaret();
				progress.Show();
			}
		}

		private void ResolveCompleteButtonClick()
		{
			base.ExitButton.onClick.Invoke();
			pcScreen.Hide();
		}

		private void ResolveButtonPressed(InputActionEventData eventData)
		{
			if (!settings.AutoHacking && eventData.actionId >= 100 && eventData.actionId <= 139)
			{
				switch (state)
				{
				case State.Hacking:
					ResolveHackingInput(eventData);
					break;
				case State.Complete:
					ResolveCompleteInput(eventData);
					break;
				}
			}
		}

		private void ResolveHackingInput(InputActionEventData eventData)
		{
			if (eventData.actionId > 136)
			{
				return;
			}
			if (!effectsActivated)
			{
				EnsureHackingEffectsActivated();
				if (settings.InitialHackingProgress > 0f)
				{
					progress.UpdateProgress(settings.InitialHackingProgress);
					typingController.PerformTyping();
					return;
				}
			}
			progress.UpdateProgress(settings.HackingSpeed);
			typingController.PerformTyping();
			regressCooldown = 0f;
		}

		private void ResolveCompleteInput(InputActionEventData eventData)
		{
			if (eventData.actionId == 137)
			{
				ResolveCompleteButtonClick();
			}
		}

		private void ResolveDelayInput(InputActionEventData eventData)
		{
			if (eventData.actionId > 136)
			{
				return;
			}
			if (breakPopup.gameObject.activeSelf)
			{
				if (breakPopup.HackingShouldBeRegressedDueUnwarilyTyping())
				{
					progress.UpdateProgress(0f - breakPopup.Penalty);
					typingController.PerformTyping();
				}
			}
			else if (alertPopup.gameObject.activeSelf && alertPopup.HackingShouldBeRegressedDueUnwarilyTyping())
			{
				progress.UpdateProgress(0f - alertPopup.Penalty);
				typingController.PerformTyping();
			}
		}

		private void ResolveDecisionInput(InputActionEventData eventData)
		{
			switch (eventData.actionId)
			{
			case 137:
				decisionPopup.MakeDecision();
				break;
			case 138:
			case 139:
				decisionPopup.SwitchButton();
				break;
			}
		}

		private void ResolveDelayComplete(GUI_HackingDelayPopup delayPopup)
		{
			if (state != State.Delay)
			{
				Debug.LogError("State is " + state.ToString() + " instead of Delay");
				return;
			}
			if (!delayPopup.IsFailed)
			{
				progress.UpdateProgress(delayPopup.Bonus);
			}
			regressCooldown = settings.RegressCooldown;
			state = State.Hacking;
		}

		private void ResolveDecisionMade(bool isRightDecision)
		{
			if (state != State.Decision)
			{
				Debug.LogError("State is " + state.ToString() + " instead of Decision");
				return;
			}
			progress.UpdateProgress(isRightDecision ? decisionPopup.Bonus : (0f - decisionPopup.Penalty));
			regressCooldown = settings.RegressCooldown;
			state = State.Hacking;
		}

		private void HandleHackingEvent(DeviceHackingEvent hackingEvent)
		{
			if (!(hackingEvent is HackingDelayEvent delayEvent))
			{
				if (!(hackingEvent is HackingDecisionEvent decisionEvent))
				{
					throw new ArgumentOutOfRangeException();
				}
				HandleDecisionEvent(decisionEvent);
			}
			else
			{
				HandleDelayEvent(delayEvent);
			}
		}

		private void HandleDelayEvent(HackingDelayEvent delayEvent)
		{
			if (!settings.SkipDelay && delayEvent.EventType != HackingEventType.Break)
			{
				if (delayEvent.EventType == HackingEventType.Break)
				{
					breakPopup.Activate(delayEvent);
				}
				else
				{
					alertPopup.Activate(delayEvent);
				}
				state = State.Delay;
			}
		}

		private void HandleDecisionEvent(HackingDecisionEvent decisionEvent)
		{
			if (!settings.SkipDecision)
			{
				decisionPopup.Activate(decisionEvent);
				state = State.Decision;
			}
		}

		private void EnsureHackingEffectsActivated()
		{
			if (!effectsActivated)
			{
				effectsActivated = true;
				backgroundScreen.Activate();
				effectsScreen.Activate();
			}
		}

		private void Complete()
		{
			pcScreen.Toolbar.Deactivate();
			state = State.Complete;
			completeScreen.gameObject.SetActive(value: true);
			connectionController.MarkConnectedDeviceAsHacked();
		}
	}
}
