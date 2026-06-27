using System;
using System.Collections;
using Restory.Data.DaySwitching;
using Restory.Data.Locations;
using Restory.Infrastructure.ProjectServices;
using Restory.Infrastructure.StateMachine;
using Restory.Infrastructure.StateMachine.States.InitializationStates;
using Restory.UI.Presenters.DayEndWindow;
using Restory.Utils;
using UnityEngine;
using Zenject;

namespace Restory.Gameplay.TimeSystems
{
	public class EndOfDayMain : IInitializable, IDisposable
	{
		private readonly GlobalStateMachine globalStateMachine;

		private readonly GameScenesPreset mainGameModeScenesPreset;

		private readonly ICoroutineRunner coroutineRunner;

		private readonly DaySwitchingSettings settings;

		private GUI_DayEndWindow dayEndWindow;

		private Coroutine doCallbackAfterDelayCoroutine;

		public EndOfDayMain(GlobalStateMachine globalStateMachine, ICoroutineRunner coroutineRunner, GUI_DayEndWindow dayEndWindow, DaySwitchingSettings settings)
		{
			this.settings = settings;
			this.coroutineRunner = coroutineRunner;
			this.globalStateMachine = globalStateMachine;
			this.dayEndWindow = dayEndWindow;
		}

		public void Initialize()
		{
			if (globalStateMachine.IsInGameResults)
			{
				ShowMenuAfterDelay();
			}
			else
			{
				globalStateMachine.OnStateEntered += ResolveGlobalStateChanged;
			}
			dayEndWindow.OnSwitchToNextDayRequested += ResolveSwitchToNextDayRequested;
		}

		private void ShowMenuAfterDelay()
		{
			if (doCallbackAfterDelayCoroutine != null)
			{
				coroutineRunner.Stop(doCallbackAfterDelayCoroutine);
			}
			doCallbackAfterDelayCoroutine = coroutineRunner.Run(DoCallbackAfterDelayCoroutine(settings.DelayBeforeShowingResultsWindow, delegate
			{
				dayEndWindow.Show();
			}));
		}

		private IEnumerator DoCallbackAfterDelayCoroutine(float delay, Action callback)
		{
			yield return new WaitForSeconds(delay);
			doCallbackAfterDelayCoroutine = null;
			callback?.Invoke();
		}

		public void Dispose()
		{
			if (dayEndWindow.MonoShellExists())
			{
				dayEndWindow.OnSwitchToNextDayRequested -= ResolveSwitchToNextDayRequested;
				dayEndWindow = null;
			}
			if (globalStateMachine != null)
			{
				globalStateMachine.OnStateEntered -= ResolveGlobalStateChanged;
			}
		}

		private void ResolveGlobalStateChanged()
		{
			if (globalStateMachine.IsInGameResults || globalStateMachine.ActiveState is MainMenuState)
			{
				globalStateMachine.OnStateEntered -= ResolveGlobalStateChanged;
				ShowMenuAfterDelay();
			}
		}

		private void ResolveSwitchToNextDayRequested()
		{
			dayEndWindow.OnSwitchToNextDayRequested -= ResolveSwitchToNextDayRequested;
			globalStateMachine.Enter<StartLoadingPresetListState, GameScenesPresetTransition>(settings.TransitionToNextDayScenes);
		}
	}
}
