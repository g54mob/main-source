using System;
using KitchenData;
using UnityEngine;

namespace Kitchen.Modules
{
	[Serializable]
	public struct GridItemCosmetic : IGridItem
	{
		public PlayerCosmetic Cosmetic;

		public int SnapshotKey => Cosmetic.ID;

		public Texture2D GetSnapshot()
		{
			return PrefabSnapshot.GetCosmeticSnapshot(Cosmetic);
		}
	}
}
