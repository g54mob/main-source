using System;
using Restory.Gameplay.GameView;
using Restory.Gameplay.Work.StateMachine;
using Restory.Infrastructure.StateMachine;
using Restory.Infrastructure.StateMachine.States;
using UnityEngine;
using Zenject;

namespace Restory.Gameplay.Work
{
	public class WorkGameMode : MonoBehaviour, IInitializable, IDisposable
	{
		private GlobalStateObserver globalStateObserver;

		private WorkStateMachine workStateMachine;

		private GameViewController gameViewController;

		[Inject]
		private void Construct(GlobalStateObserver globalStateObserver, WorkStateMachine workStateMachine, GameViewController gameViewController)
		{
			this.globalStateObserver = globalStateObserver;
			this.workStateMachine = workStateMachine;
			this.gameViewController = gameViewController;
		}

		public void Initialize()
		{
			globalStateObserver.AddSubscriber(this, ResolveGlobalStateChanged);
			gameViewController.OnViewPresetSwitchingProcessStarted += ResolveGameViewTransitionStarted;
			gameViewController.OnViewPresetSwitchingProcessComplete += ResolveGameViewTransitionComplete;
		}

		public void Dispose()
		{
			globalStateObserver.RemoveSubscriber(this);
			gameViewController.OnViewPresetSwitchingProcessComplete -= ResolveGameViewTransitionStarted;
			gameViewController.OnViewPresetSwitchingProcessComplete -= ResolveGameViewTransitionComplete;
		}

		private void ResolveGlobalStateChanged()
		{
			if (globalStateObserver.ActiveState is GameLoopState)
			{
				workStateMachine.Enter<DetectionWorkState>();
			}
			else if (!(workStateMachine.ActiveState is DisabledWorkState))
			{
				workStateMachine.Enter<DisabledWorkState>();
			}
		}

		private void ResolveGameViewTransitionStarted()
		{
			if (!(workStateMachine.ActiveState is DisabledWorkState) && gameViewController.IsCurrentViewPresetDisassemblePreset)
			{
				workStateMachine.Enter<DisabledWorkState>();
			}
		}

		private void ResolveGameViewTransitionComplete()
		{
			if (workStateMachine.ActiveState is DisabledWorkState && !gameViewController.IsCurrentViewPresetDisassemblePreset)
			{
				workStateMachine.Enter<DetectionWorkState>();
			}
		}
	}
}
