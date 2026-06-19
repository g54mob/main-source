using System;
using TH20.UI;
using UnityEngine;
using UnityEngine.UI;

namespace TH20
{
	[DisallowMultipleComponent]
	public class ButtonSFX : MonoBehaviour
	{
		public enum ButtonAudioEvent
		{
			Default = 0,
			GameStart = 1,
			SubMenuItem = 2,
			Custom = 3
		}

		private static readonly string Click_AudioEvent = "Click";

		private static readonly string Click_GameStart_AudioEvent = "Click:GameStart";

		private static readonly string Click_SelectSubMenuItem_AudioEvent = "Click:SelectSubMenuItem";

		public ButtonAudioEvent AudioEvent = ButtonAudioEvent.Custom;

		[SerializeField]
		private string _customAudioEvent;

		[SerializeField]
		private string _selectedAudioEvent;

		[SerializeField]
		private string _unselectableAudioEvent;

		private void OnEnable()
		{
			AddListeners();
		}

		private void OnDisable()
		{
			RemoveListeners();
		}

		public void UpdateListeners()
		{
			RemoveListeners();
			AddListeners();
		}

		public void SetCustomAudioEvent(string customAudioEvent)
		{
			_customAudioEvent = customAudioEvent;
		}

		public void SetSelectedAudioEvent(string selectedAudioEvent)
		{
			_selectedAudioEvent = selectedAudioEvent;
		}

		public void UnselectableAudioEvent(string unselectableAudioEvent)
		{
			_unselectableAudioEvent = unselectableAudioEvent;
		}

		public void AddListeners()
		{
			DynamicButton component = GetComponent<DynamicButton>();
			if (component != null)
			{
				component.onPrimaryDown.AddListener(OnButton);
				component.onPrimaryDownFailed.AddListener(OnButton);
				return;
			}
			Button component2 = GetComponent<Button>();
			InstantButton instantButton = component2 as InstantButton;
			if (instantButton != null)
			{
				instantButton.OnDown = (Action)Delegate.Combine(instantButton.OnDown, new Action(OnButton));
				return;
			}
			if (component2 != null)
			{
				component2.onClick.AddListener(OnButton);
				return;
			}
			Toggle component3 = GetComponent<Toggle>();
			if (component3 != null)
			{
				component3.onValueChanged.AddListener(OnToggle);
			}
		}

		private void RemoveListeners()
		{
			DynamicButton component = GetComponent<DynamicButton>();
			if (component != null)
			{
				component.onPrimaryDown.RemoveListener(OnButton);
				component.onPrimaryDownFailed.RemoveListener(OnButton);
				return;
			}
			Button component2 = GetComponent<Button>();
			InstantButton instantButton = component2 as InstantButton;
			if (instantButton != null)
			{
				instantButton.OnDown = (Action)Delegate.Remove(instantButton.OnDown, new Action(OnButton));
				return;
			}
			if (component2 != null)
			{
				component2.onClick.RemoveListener(OnButton);
				return;
			}
			Toggle component3 = GetComponent<Toggle>();
			if (component3 != null)
			{
				component3.onValueChanged.RemoveListener(OnToggle);
			}
		}

		private void OnToggle(bool newValue)
		{
			if (newValue)
			{
				if (!_customAudioEvent.IsNullOrEmpty())
				{
					AudioManager.Instance.Play(_customAudioEvent);
				}
			}
			else if (!_unselectableAudioEvent.IsNullOrEmpty())
			{
				AudioManager.Instance.Play(_unselectableAudioEvent);
			}
		}

		private void OnButton()
		{
			if (AudioManager.Instance == null)
			{
				return;
			}
			switch (AudioEvent)
			{
			case ButtonAudioEvent.Custom:
			{
				ButtonAnimator component = GetComponent<ButtonAnimator>();
				if (component != null)
				{
					switch (component.CurrentState)
					{
					case ButtonAnimator.State.Selectable:
						if (!_customAudioEvent.IsNullOrEmpty())
						{
							AudioManager.Instance.Play(_customAudioEvent);
						}
						break;
					case ButtonAnimator.State.Selected:
						if (!_selectedAudioEvent.IsNullOrEmpty())
						{
							AudioManager.Instance.Play(_selectedAudioEvent);
						}
						break;
					case ButtonAnimator.State.Unselectable:
						if (!_unselectableAudioEvent.IsNullOrEmpty())
						{
							AudioManager.Instance.Play(_unselectableAudioEvent);
						}
						break;
					}
				}
				else
				{
					AudioManager.Instance.Play(_customAudioEvent);
				}
				break;
			}
			case ButtonAudioEvent.Default:
				AudioManager.Instance.Play(Click_AudioEvent);
				break;
			case ButtonAudioEvent.GameStart:
				AudioManager.Instance.Play(Click_GameStart_AudioEvent);
				break;
			case ButtonAudioEvent.SubMenuItem:
				AudioManager.Instance.Play(Click_SelectSubMenuItem_AudioEvent);
				break;
			}
		}
	}
}
