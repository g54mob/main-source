using System;
using RSG;
using Restory.Data.Locations;
using Restory.Infrastructure.StateMachine.States.InitializationStates;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.ResourceManagement.ResourceProviders;
using UnityEngine.SceneManagement;
using Zenject;

namespace Restory.Infrastructure.ProjectServices
{
	public class LoadingScreenLoaderService
	{
		private readonly AssetReference defaultLoadingSceneRef;

		private readonly AssetReference blackLoadingSceneRef;

		private readonly AssetReference bicycleLoadingSceneRef;

		private AssetReference currentLoadingSceneRef;

		private AsyncOperationHandle<SceneInstance> loadingScreenHandle;

		public LoadingScreenLoaderService([Inject(Id = "LoadingSceneId")] AssetReference defaultLoadingSceneRef, [Inject(Id = "BlackLoadingSceneId")] AssetReference blackLoadingSceneRef, [Inject(Id = "BicycleLoadingSceneId")] AssetReference bicycleLoadingSceneRef)
		{
			this.bicycleLoadingSceneRef = bicycleLoadingSceneRef;
			this.defaultLoadingSceneRef = defaultLoadingSceneRef;
			this.blackLoadingSceneRef = blackLoadingSceneRef;
		}

		public IPromise OpenLoadingScreen()
		{
			Debug.Log("LoadingScreenLoaderService OpenLoadingScenePromise");
			Promise promise = new Promise();
			loadingScreenHandle = Addressables.LoadSceneAsync(defaultLoadingSceneRef);
			loadingScreenHandle.Completed += delegate
			{
				promise.Resolve();
			};
			return promise;
		}

		public IPromise OpenLoadingScreen(ScenesTransitionArguments nextScenesPresetTransition)
		{
			Debug.Log("LoadingScreenLoaderService OpenLoadingScenePromise");
			Promise promise = new Promise();
			loadingScreenHandle = Addressables.LoadSceneAsync(nextScenesPresetTransition.LoadingScreen switch
			{
				LoadingScreenTypes.DefaultLoadingScreen => defaultLoadingSceneRef, 
				LoadingScreenTypes.BlackScreen => blackLoadingSceneRef, 
				LoadingScreenTypes.BicycleScreen => bicycleLoadingSceneRef, 
				_ => throw new NotImplementedException(), 
			});
			loadingScreenHandle.Completed += delegate
			{
				promise.Resolve();
			};
			return promise;
		}

		public IPromise CloseLoadingScreen()
		{
			Debug.Log("LoadingScreenLoaderService unload loading screen");
			Promise promise = new Promise();
			AsyncOperationHandle<SceneInstance> asyncOperationHandle = Addressables.UnloadSceneAsync(loadingScreenHandle, UnloadSceneOptions.UnloadAllEmbeddedSceneObjects);
			asyncOperationHandle.Completed += delegate
			{
				promise.Resolve();
			};
			loadingScreenHandle = default(AsyncOperationHandle<SceneInstance>);
			return promise;
		}
	}
}
