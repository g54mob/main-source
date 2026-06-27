using System;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace Restory.AssetManagement.References
{
	[Serializable]
	public class SceneAssetReference : AssetReference
	{
		public SceneAssetReference(string guid)
			: base(guid)
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
	}
}
