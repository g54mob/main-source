using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace CTS.BBT
{
	public static class ManagersAutoSpawner
	{
		[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
		private static void Initialization()
		{
			AsyncOperationHandle<Object> asyncOperationHandle = Addressables.LoadAssetAsync<Object>("Assets/Prefabs/Managers/GameManager.prefab");
			asyncOperationHandle.WaitForCompletion();
			Object obj = Object.Instantiate(asyncOperationHandle.Result);
			obj.name = "Managers (Auto-Spawned)";
			Object.DontDestroyOnLoad(obj);
		}
	}
}
