using Aura2API;
using NSEipix.Base;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace NSMedieval.Controllers
{
	public class HomeSceneManager : MonoSingleton<HomeSceneManager>
	{
		[SerializeField]
		private string key;

		protected override void Awake()
		{
			base.Awake();
			AsyncOperationHandle<GameObject> asyncOperationHandle = Addressables.InstantiateAsync(key);
			asyncOperationHandle.Completed += delegate(AsyncOperationHandle<GameObject> globalHandle)
			{
				if (globalHandle.Status == AsyncOperationStatus.Succeeded)
				{
					globalHandle.Result.AddComponent(typeof(ReleaseOnDestroy));
					this.Destroy();
				}
			};
		}
	}
}
