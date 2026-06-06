using InventorySystem;
using UnityEngine;

namespace Brewery.Items
{
	[CreateAssetMenu(fileName = "New Crate", menuName = "Brewery/Items/Crate")]
	public class CrateItem : BreweryItem
	{
		[Header("Crate Configuration")]
		[Tooltip("Number of rows in the crate grid")]
		[SerializeField]
		private int rows;

		[Tooltip("Number of columns in the crate grid")]
		[SerializeField]
		private int columns;

		[Tooltip("Items that can be stored in this crate")]
		[SerializeField]
		private ItemCategory[] allowedCategories;

		[Tooltip("Specific items that can be stored (leave empty to use categories only)")]
		[SerializeField]
		private Item[] allowedItems;

		public int Rows => 0;

		public int Columns => 0;

		public int TotalSlots => 0;

		public override bool IsSellable => false;

		public bool CanStoreItem(Item item)
		{
			return false;
		}

		public override bool RequiresMetadata()
		{
			return false;
		}

		private void OnEnable()
		{
		}

		public override void Use()
		{
		}
	}
}
