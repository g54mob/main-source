using System;
using System.Collections;
using RSG;
using Restory.Data.Locations;
using Restory.Infrastructure.ProjectServices;
using Restory.Infrastructure.StateMachine.States.Base;
using Restory.Infrastructure.StateMachine.States.Interfaces;
using UnityEngine;
using Zenject;

namespace Restory.Infrastructure.StateMachine.States.InitializationStates
{
	public class FinalSelectionState : InitializationStateBase, IPayloadedState<GameScenesPreset>, IExitableState, IDisposable
	{
		public class Factory : PlaceholderFactory<FinalSelectionState>
		{
		}

		private readonly float awaitProgressBarDelayInSeconds = 0.5f;

		private readonly LoadingScreenLoaderService loadingScreenLoaderService;

		private readonly ICoroutineRunner coroutineRunner;

		public FinalSelectionState(ICoroutineRunner coroutineRunner, LoadingScreenLoaderService loadingScreenLoaderService)
		{
			this.loadingScreenLoaderService = loadingScreenLoaderService;
			this.coroutineRunner = coroutineRunner;
		}

		public void Enter(GameScenesPreset preset)
		{
			LogDebug("Enter state");
			Promise.Resolved().Then(() => WaitForSeconds(awaitProgressBarDelayInSeconds)).Then((Func<IPromise>)DisposeLoadingScenePromise)
				.Then((Func<IPromise>)WaitForEndOfFrame)
				.Then(delegate
				{
					EnterTargetState(preset);
				})
				.Done();
		}

		private IPromise DisposeLoadingScenePromise()
		{
			return loadingScreenLoaderService.CloseLoadingScreen();
		}

		private void EnterTargetState(GameScenesPreset preset)
		{
			base.Progress = 1f;
			switch (preset.PresetType)
			{
			case ScenePresetType.GameResults:
				GameStateMachine.Enter<GameResultsState>();
				break;
			case ScenePresetType.Gameplay:
			case ScenePresetType.GameplayCore:
				GameStateMachine.Enter<GameLauncherState, GameScenesPreset>(preset);
				break;
			case ScenePresetType.Menu:
				GameStateMachine.Enter<MainMenuState>();
				break;
			case ScenePresetType.GameIntro:
				GameStateMachine.Enter<GameIntroState>();
				break;
			case ScenePresetType.GameLogosIntro:
				GameStateMachine.Enter<GameIntroLogosState>();
				break;
			default:
				throw new ArgumentOutOfRangeException("PresetType", preset.PresetType, null);
			case ScenePresetType.None:
				break;
			}
		}

		public override void Exit()
		{
			LogDebug("Exit state");
		}

		private IPromise WaitForEndOfFrame()
		{
			Promise promise = new Promise();
			coroutineRunner.Run(DelayRoutine());
			return promise;
			IEnumerator DelayRoutine()
			{
				for (int i = 0; i < 2; i++)
				{
					yield return new WaitForEndOfFrame();
				}
				promise.Resolve();
			}
		}

		private IPromise WaitForSeconds(float delayInSeconds)
		{
			Promise promise = new Promise();
			coroutineRunner.Run(DelayRoutine());
			return promise;
			IEnumerator DelayRoutine()
			{
				yield return new WaitForSeconds(delayInSeconds);
				promise.Resolve();
			}
		}

		public override void ResetProgress()
		{
			progress = 1f;
		}
	}
}
