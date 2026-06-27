using System;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace Restory.Data.Locations
{
	[Serializable]
	public struct AdditiveLocationInfo
	{
		private const string ODIN_GROUP_SETTINGS = "Settings";

		[SerializeField]
		private AssetReference scene;

		[SerializeField]
		private AssetProductionType productionType;

		public AssetReference Scene => scene;

		public AssetProductionType AssetProductionType => productionType;
	}
}
