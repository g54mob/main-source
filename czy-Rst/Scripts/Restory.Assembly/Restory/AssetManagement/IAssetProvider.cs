using System;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.ResourceManagement.ResourceProviders;
using UnityEngine.SceneManagement;

namespace Restory.AssetManagement
{
	public interface IAssetProvider
	{
		Task<GameObject> Instantiate(string address, Vector3 at);

		Task<GameObject> Instantiate(string address);

		Task<T> Load<T>(AssetReference assetReference, bool preserved);

		AsyncOperationHandle<SceneInstance> LoadScene(AssetReference assetReference, LoadSceneMode loadSceneMode, bool activateOnLoad, Action onCompleted = null);

		AsyncOperationHandle<SceneInstance> UnloadScene(AssetReference assetReference, Action onCompleted = null);

		void CleanUp(bool disposeAll = false);

		T GetAsset<T>(string guid);

		void LoadWithLabel(AssetLabelReference assetLabelReference, Action onCompleted = null);

		void UnloadWithLabel(AssetLabelReference assetLabelReference);
	}
}
