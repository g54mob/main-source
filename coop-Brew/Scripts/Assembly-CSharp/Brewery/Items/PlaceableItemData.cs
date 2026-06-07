using InventorySystem;
using UnityEngine;

namespace Brewery.Items
{
	public abstract class PlaceableItemData : BreweryItem
	{
		[Header("Placement Configuration")]
		[Tooltip("Material to use when placement preview is valid (green)")]
		[SerializeField]
		protected Material validPlacementMaterial;

		[Tooltip("Material to use when placement preview is invalid (red)")]
		[SerializeField]
		protected Material invalidPlacementMaterial;

		[Tooltip("Prefab to spawn when this item is placed in the world")]
		[SerializeField]
		protected GameObject placedObjectPrefab;

		public Material ValidPlacementMaterial => null;

		public Material InvalidPlacementMaterial => null;

		public GameObject PlacedObjectPrefab => null;

		public override ItemCarryType GetCarryType()
		{
			return default(ItemCarryType);
		}
	}
}
