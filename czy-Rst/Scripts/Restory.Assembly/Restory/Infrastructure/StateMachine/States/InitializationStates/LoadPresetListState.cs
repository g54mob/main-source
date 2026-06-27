using System;
using System.Collections;
using RSG;
using Restory.AssetManagement;
using Restory.Data.Locations;
using Restory.Infrastructure.ProjectServices;
using Restory.Infrastructure.StateMachine.States.Base;
using Restory.Infrastructure.StateMachine.States.Interfaces;
using UnityEngine;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.ResourceManagement.ResourceProviders;
using UnityEngine.SceneManagement;
using Zenject;

namespace Restory.Infrastructure.StateMachine.States.InitializationStates
{
	public class LoadPresetListState : InitializationStateBase, IPayloadedState<GameScenesPreset>, IExitableState, IDisposable
	{
		public class Factory : PlaceholderFactory<LoadPresetListState>
		{
		}

		private readonly IAssetProvider assetProvider;

		private readonly ICoroutineRunner coroutineRunner;

		private readonly LoadPresetListHistory loadPresetListHistory;

		public LoadPresetListState(IAssetProvider assetProvider, ICoroutineRunner coroutineRunner, LoadPresetListHistory loadPresetListHistory)
		{
			this.assetProvider = assetProvider;
			this.coroutineRunner = coroutineRunner;
			this.loadPresetListHistory = loadPresetListHistory;
		}

		public void Enter(GameScenesPreset preset)
		{
			LogDebug("Enter state");
			Promise.Resolved().Then(() => LoadPresetPromise(preset)).Then((Func<IPromise>)WaitForEndOfFrame)
				.Then(delegate
				{
					EnterNextState(preset);
				})
				.Done();
		}

		private void EnterNextState(GameScenesPreset preset)
		{
			base.Progress = 1f;
			loadPresetListHistory.Enqueue(preset);
			LogDebug("Loading completed");
			GameStateMachine.Enter<InstallServicesState, GameScenesPreset>(preset);
		}

		public override void Exit()
		{
			LogDebug("Exit state");
		}

		private IPromise LoadPresetPromise(GameScenesPreset gameScenesPreset)
		{
			LogDebug("starts loading preset: " + gameScenesPreset.name);
			if (gameScenesPreset == null)
			{
				return Promise.Resolved();
			}
			Promise promise = new Promise();
			coroutineRunner.Run(LoadPresetAsync(gameScenesPreset, promise.Resolve));
			return promise;
		}

		private IEnumerator LoadPresetAsync(GameScenesPreset gameScenesPreset, Action onComplete = null)
		{
			LogDebug($"Start load scene with GUID: {gameScenesPreset.MainScene}");
			float progressStep = GetProgressStep(gameScenesPreset);
			float startLoadingTime = Time.realtimeSinceStartup;
			AsyncOperationHandle<SceneInstance> mainSceneLoadHandle = assetProvider.LoadScene(gameScenesPreset.MainScene, LoadSceneMode.Additive, activateOnLoad: true);
			yield return mainSceneLoadHandle;
			base.Progress += progressStep;
			float num = Time.realtimeSinceStartup - startLoadingTime;
			LogDebug("load scene " + mainSceneLoadHandle.Result.Scene.name + " is done. " + $"Total time: {num} sec");
			foreach (AdditiveLocationInfo additiveScene in gameScenesPreset.AdditiveScenes)
			{
				if (additiveScene.AssetProductionType == AssetProductionType.Release || (Application.isEditor && additiveScene.AssetProductionType == AssetProductionType.Blackwork))
				{
					LogDebug($"Start load scene with GUID: {additiveScene.Scene}");
					startLoadingTime = Time.realtimeSinceStartup;
					AsyncOperationHandle<SceneInstance> childSceneLoadHandle = assetProvider.LoadScene(additiveScene.Scene, LoadSceneMode.Additive, activateOnLoad: true);
					yield return childSceneLoadHandle;
					num = Time.realtimeSinceStartup - startLoadingTime;
					LogDebug("load scene " + childSceneLoadHandle.Result.Scene.name + " is done. " + $"Total time: {num} sec");
				}
				base.Progress += progressStep;
			}
			SceneManager.SetActiveScene(mainSceneLoadHandle.Result.Scene);
			onComplete?.Invoke();
		}

		private float GetProgressStep(GameScenesPreset gameScenesPreset)
		{
			int num = 1;
			int count = gameScenesPreset.AdditiveScenes.Count;
			return 1f / (float)(num + count);
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
	}
}
