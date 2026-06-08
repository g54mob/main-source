using System;
using KitchenData;
using UnityEngine;

namespace Kitchen.Modules
{
	[Serializable]
	public struct GridItemDish : IGridItem
	{
		public Dish Dish;

		public int SnapshotKey => Dish.ID;

		public Texture2D GetSnapshot()
		{
			return PrefabSnapshot.GetSnapshot(Dish.IconPrefab);
		}
	}
}
