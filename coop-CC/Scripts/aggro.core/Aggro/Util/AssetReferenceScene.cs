using System;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.ResourceManagement.ResourceProviders;

namespace Aggro.Util
{
	[Serializable]
	public class AssetReferenceScene : AssetReference
	{
		public AssetReferenceScene(string guid)
			: base(guid)
		{
		}

		public AssetReferenceScene()
		{
		}

		public override bool ValidateAsset(UnityEngine.Object obj)
		{
			return false;
		}

		public override bool ValidateAsset(string path)
		{
			return false;
		}

		public void ReloadScene()
		{
			if (IsValid())
			{
				AsyncOperationHandle<SceneInstance> asyncOperationHandle = UnLoadScene();
				asyncOperationHandle.Completed += OnReloadCompleted;
			}
			else
			{
				LoadSceneAsync();
			}
		}

		private void OnReloadCompleted(AsyncOperationHandle<SceneInstance> op)
		{
			LoadSceneAsync();
		}
	}
}
