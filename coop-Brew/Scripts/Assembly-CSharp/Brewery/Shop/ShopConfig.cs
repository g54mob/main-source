using System.Collections.Generic;
using Brewery.Items;
using UnityEngine;

namespace Brewery.Shop
{
	[CreateAssetMenu(fileName = "NewShopConfig", menuName = "Brewery/Shop/Shop Config", order = 1)]
	public class ShopConfig : ScriptableObject
	{
		[Header("Shop Identity")]
		[Tooltip("Display name shown in UI")]
		public string shopName;

		[Tooltip("Shop type determines item legality and theme")]
		public ShopType shopType;

		[TextArea(3, 5)]
		[Tooltip("Description shown when player opens shop")]
		public string shopDescription;

		[Header("Inventory")]
		[Tooltip("All items available for purchase in this shop")]
		public List<BreweryItem> availableItems;

		[Tooltip("If true, only show items where IsPurchasable = true")]
		public bool filterNonPurchasableItems;

		[Header("Daily Limited Items")]
		[Tooltip("Items with a daily purchase limit that resets when the shop opens")]
		public List<DailyLimitedItem> dailyLimitedItems;

		[Header("Output Grid Configuration")]
		[Tooltip("Number of rows in the spawn grid")]
		[Range(2f, 10f)]
		public int gridRows;

		[Tooltip("Number of columns in the spawn grid")]
		[Range(2f, 10f)]
		public int gridColumns;

		[Tooltip("Local position offset from shop transform to grid origin")]
		public Vector3 gridStartOffset;

		[Tooltip("Spacing between items in the grid (X, Y, Z)")]
		public Vector3 itemSpacing;

		[Tooltip("Scale multiplier for spawned item visuals")]
		[Range(0.1f, 2f)]
		public float itemScale;

		[Header("Visual Settings")]
		[Tooltip("Shopkeeper icon displayed in the shop UI header")]
		public Sprite shopkeeperIcon;

		[Tooltip("Show spawn grid gizmos in editor")]
		public bool showGizmos;

		[Tooltip("Color of grid gizmos in editor")]
		public Color gizmoColor;

		[Header("UI Theme (Future)")]
		[Tooltip("Custom UI color scheme (not yet implemented)")]
		public Color themeColor;

		public int GridCapacity => 0;

		public List<BreweryItem> GetPurchasableItems()
		{
			return null;
		}

		public bool HasDailyLimit(string itemId)
		{
			return false;
		}

		public int GetDailyLimit(string itemId)
		{
			return 0;
		}

		public DailyLimitedItem GetDailyLimitedItem(string itemId)
		{
			return null;
		}

		public bool Validate(out string error)
		{
			error = null;
			return false;
		}
	}
}
