using System;
using Restory.Data.Locations;
using UnityEngine.AddressableAssets;

namespace Restory.AssetManagement.References
{
	[Serializable]
	public class GameScenesAssetRef : AssetReferenceT<GameScenesPreset>
	{
		public GameScenesAssetRef(string guid)
			: base(guid)
		{
		}
	}
}
