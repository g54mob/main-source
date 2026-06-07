using System;
using UnityEngine.AddressableAssets;
using VampireSurvivors.App.Attributes;

namespace VampireSurvivors.Framework.DLC
{
	[Serializable]
	public class MobileDlcData
	{
		[PurchasableProduct]
		public string _Product;

		public AssetReference _InGameStoreIconRef;
	}
}
