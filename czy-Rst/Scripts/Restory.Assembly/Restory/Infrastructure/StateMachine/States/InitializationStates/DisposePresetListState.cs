using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using DG.Tweening;
using RSG;
using Restory.AssetManagement;
using Restory.Data.Locations;
using Restory.Infrastructure.ProjectServices;
using Restory.Infrastructure.StateMachine.States.Base;
using Restory.Infrastructure.StateMachine.States.Interfaces;
using UnityEngine;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.ResourceManagement.ResourceProviders;
using Zenject;

namespace Restory.Infrastructure.StateMachine.States.InitializationStates
{
	public class DisposePresetListState : InitializationStateBase, IPayloadedState<GameScenesPreset>, IExitableState, IDisposable, IPayloadedState<ScenesTransitionArguments>
	{
		public class Factory : PlaceholderFactory<DisposePresetListState>
		{
		}

		private readonly IAssetProvider assetProvider;

		private readonly ICoroutineRunner coroutineRunner;

		private readonly LoadPresetListHistory loadPresetListHistory;

		private readonly LoadingScreenLoaderService loadingScreenLoaderService;

		private readonly CleanupBeforeSceneUnloadService cleanupBeforeSceneUnloadService;

		public DisposePresetListState(IAssetProvider assetProvider, ICoroutineRunner coroutineRunner, CleanupBeforeSceneUnloadService cleanupBeforeSceneUnloadService, LoadPresetListHistory loadPresetListHistory, LoadingScreenLoaderService loadingScreenLoaderService)
		{
			this.cleanupBeforeSceneUnloadService = cleanupBeforeSceneUnloadService;
			this.assetProvider = assetProvider;
			this.coroutineRunner = coroutineRunner;
			this.loadPresetListHistory = loadPresetListHistory;
			this.loadingScreenLoaderService = loadingScreenLoaderService;
		}

		public void Enter(GameScenesPreset nextPreset)
		{
			LogDebug("Enter state");
			GameScenesPreset prevPreset = loadPresetListHistory.Records.LastOrDefault()?.Preset;
			PerformSceneCleanupPromise().Then((Action)UnInstallContainers).Then((Func<IPromise>)WaitForEndOfFrame).Then((Func<IPromise>)KillTweensPromise)
				.Then(delegate
				{
					SetProgress(0.45f);
				})
				.Then((Func<IPromise>)OpenLoadingScenePromise)
				.Then((Func<IPromise>)WaitForEndOfFrame)
				.Then((Action)CleanUpAssetProvider)
				.Then((Func<IPromise>)WaitForEndOfFrame)
				.Then(() => DisposePresetPromise(prevPreset))
				.Then(delegate
				{
					SetProgress(0.85f);
				})
				.Then((Func<IPromise>)WaitForEndOfFrame)
				.Then(delegate
				{
					EnterNextState(nextPreset);
				})
				.Done();
		}

		public void Enter(ScenesTransitionArguments nextPresetTransitionArguments)
		{
			LogDebug("Enter state");
			GameScenesPreset prevPreset = loadPresetListHistory.Records.LastOrDefault()?.Preset;
			PerformSceneCleanupPromise().Then((Action)UnInstallContainers).Then((Func<IPromise>)WaitForEndOfFrame).Then((Func<IPromise>)KillTweensPromise)
				.Then(delegate
				{
					SetProgress(0.45f);
				})
				.Then(() => OpenLoadingScenePromise(nextPresetTransitionArguments))
				.Then((Func<IPromise>)WaitForEndOfFrame)
				.Then((Action)CleanUpAssetProvider)
				.Then((Func<IPromise>)WaitForEndOfFrame)
				.Then(() => DisposePresetPromise(prevPreset))
				.Then(delegate
				{
					SetProgress(0.85f);
				})
				.Then((Func<IPromise>)WaitForEndOfFrame)
				.Then(delegate
				{
					EnterNextState(nextPresetTransitionArguments.ScenesPreset);
				})
				.Done();
		}

		private void EnterNextState(GameScenesPreset nextPreset)
		{
			base.Progress = 1f;
			LogDebug("Disposing completed");
			GameStateMachine.Enter<LoadPresetListState, GameScenesPreset>(nextPreset);
		}

		private IPromise OpenLoadingScenePromise()
		{
			return loadingScreenLoaderService.OpenLoadingScreen();
		}

		private IPromise OpenLoadingScenePromise(ScenesTransitionArguments nextPresetTransition)
		{
			return loadingScreenLoaderService.OpenLoadingScreen(nextPresetTransition);
		}

		private void CleanUpAssetProvider()
		{
			assetProvider.CleanUp();
		}

		public override void Exit()
		{
			LogDebug("Exit state");
		}

		private IPromise PerformSceneCleanupPromise()
		{
			return cleanupBeforeSceneUnloadService.PerformCleanup();
		}

		private void UnInstallContainers()
		{
			List<SceneContext> list = UnityEngine.Object.FindObjectsByType<SceneContext>(FindObjectsSortMode.None).ToList();
			SceneContext sceneContext = list.FirstOrDefault((SceneContext x) => x.ContractNames.Contains("MainScene"));
			if (sceneContext != null)
			{
				sceneContext.UnInstall();
				list.Remove(sceneContext);
			}
			SceneContext sceneContext2 = list.FirstOrDefault((SceneContext x) => x.ContractNames.Contains("StoryMode"));
			if (sceneContext2 != null)
			{
				sceneContext2.UnInstall();
				list.Remove(sceneContext2);
			}
			foreach (SceneContext item in list.OrderBy((SceneContext x) => x.ParentContractNames.Count()))
			{
				item.UnInstall();
			}
		}

		private IPromise KillTweensPromise()
		{
			LogDebug("Killing all tweens");
			DOTween.KillAll();
			return Promise.Resolved();
		}

		private IPromise DisposePresetPromise(GameScenesPreset presetList)
		{
			LogDebug("ispose scenes preset");
			if (presetList == null)
			{
				return Promise.Resolved();
			}
			Promise promise = new Promise();
			coroutineRunner.Run(DisposePresetRoutine(presetList, delegate
			{
				promise.Resolve();
			}));
			return promise;
		}

		private IEnumerator DisposePresetRoutine(GameScenesPreset gameScenesPreset, Action onComplete = null)
		{
			LogDebug("UnloadSceneAsset with GUID " + gameScenesPreset.MainScene.AssetGUID);
			AsyncOperationHandle<SceneInstance> disposeMainSceneHandle = assetProvider.UnloadScene(gameScenesPreset.MainScene);
			yield return new WaitUntil(() => disposeMainSceneHandle.IsDone);
			foreach (AdditiveLocationInfo additiveScene in gameScenesPreset.AdditiveScenes)
			{
				LogDebug("UnloadSceneAsset with GUID " + additiveScene.Scene.AssetGUID);
				AsyncOperationHandle<SceneInstance> disposeChildSceneHandle = assetProvider.UnloadScene(additiveScene.Scene);
				yield return new WaitUntil(() => disposeChildSceneHandle.IsDone);
			}
			onComplete?.Invoke();
		}

		private void SetProgress(float newValue)
		{
			base.Progress = newValue;
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
