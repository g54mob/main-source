using FoxyVoxel.Logging;
using NSMedieval.UI;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.ResourceManagement.ResourceProviders;

namespace NSMedieval.Controllers
{
	public class HomeLoadingManager : MonoBehaviour
	{
		private static readonly FVLogger logger = FVLogger.New("HomeLoadingManager");

		private void Start()
		{
			logger.Debug("Loading home scene");
			AsyncOperationHandle<SceneInstance> asyncOperationHandle = Addressables.LoadSceneAsync("HomeScene");
			asyncOperationHandle.Completed += delegate(AsyncOperationHandle<SceneInstance> obj)
			{
				if (obj.Status != AsyncOperationStatus.Succeeded)
				{
					logger.Error("Failed to load HomeScene");
				}
				else
				{
					obj.Result.ActivateAsync().completed += delegate(AsyncOperation res)
					{
						if (!res.isDone)
						{
							logger.Error("Failed to activate HomeScene");
						}
						else
						{
							HomeSplashView.Instance.HomeSceneLoaded();
						}
					};
				}
			};
		}
	}
}
