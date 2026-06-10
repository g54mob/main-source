using System;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using NSEipix.Base;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace NSMedieval.Controllers
{
	public class AddressableLoadingManager : MonoSingleton<AddressableLoadingManager>
	{
		internal class ReleaseOnDestroy : MonoBehaviour
		{
			private void OnDestroy()
			{
				Addressables.ReleaseInstance(base.gameObject);
			}
		}

		public AsyncOperationHandle<T> LoadAddressableAsync<T>(string address) where T : UnityEngine.Object
		{
			return Addressables.LoadAssetAsync<T>(address);
		}

		public void Load<T>(AssetReference reference, Action<AssetReference> releaseCallback)
		{
			AsyncOperationHandle<T> asyncOperationHandle = reference.LoadAssetAsync<T>();
			asyncOperationHandle.Completed += delegate(AsyncOperationHandle<T> aoh)
			{
				if (aoh.Status != AsyncOperationStatus.Succeeded)
				{
					bool isEnabled;
					FVLogErrorInterpolationHandler messageBuilder = new FVLogErrorInterpolationHandler(16, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Controller\\AddressableLoadingManager.cs");
					if (isEnabled)
					{
						messageBuilder.AppendLiteral("Loading ");
						messageBuilder.AppendFormatted(typeof(T));
						messageBuilder.AppendLiteral(" failed!");
					}
					Log.Error(messageBuilder);
				}
				else
				{
					releaseCallback(reference);
				}
			};
		}

		public void LoadAsync<T>(AssetReference reference, Action<AssetReference> releaseCallback)
		{
			AsyncOperationHandle<T> asyncOperationHandle = reference.LoadAssetAsync<T>();
			asyncOperationHandle.Completed += delegate(AsyncOperationHandle<T> aoh)
			{
				if (aoh.Status != AsyncOperationStatus.Succeeded)
				{
					bool isEnabled;
					FVLogErrorInterpolationHandler messageBuilder = new FVLogErrorInterpolationHandler(16, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Controller\\AddressableLoadingManager.cs");
					if (isEnabled)
					{
						messageBuilder.AppendLiteral("Loading ");
						messageBuilder.AppendFormatted(typeof(T));
						messageBuilder.AppendLiteral(" failed!");
					}
					Log.Error(messageBuilder);
				}
				else
				{
					releaseCallback(reference);
				}
			};
		}

		public AsyncOperationHandle<GameObject> InstantiateAsync(AssetReference reference, Transform parent = null)
		{
			AsyncOperationHandle<GameObject> result = reference.InstantiateAsync(parent);
			result.Completed += delegate(AsyncOperationHandle<GameObject> aoh)
			{
				if (aoh.Status != AsyncOperationStatus.Succeeded)
				{
					bool isEnabled;
					FVLogErrorInterpolationHandler messageBuilder = new FVLogErrorInterpolationHandler(16, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Controller\\AddressableLoadingManager.cs");
					if (isEnabled)
					{
						messageBuilder.AppendLiteral("Loading ");
						messageBuilder.AppendFormatted(reference.RuntimeKey);
						messageBuilder.AppendLiteral(" failed!");
					}
					Log.Error(messageBuilder);
				}
				else
				{
					aoh.Result.AddComponent(typeof(ReleaseOnDestroy));
				}
			};
			return result;
		}
	}
}
