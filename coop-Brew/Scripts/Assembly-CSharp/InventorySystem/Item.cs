using Brewery.Core;
using Brewery.Systems;
using PlacementSystem;
using UnityEngine;

namespace InventorySystem
{
	[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]
	public class Item : ScriptableObject
	{
		[Header("Item Identity")]
		[Tooltip("Unique identifier for this item (used by quests, saves, etc). Leave empty to use asset name.")]
		[SerializeField]
		private string itemId;

		[Header("Item Information")]
		public string itemName;

		[TextArea(3, 5)]
		public string description;

		[Header("Localization")]
		[SerializeField]
		private string itemNameKey;

		[SerializeField]
		private string descriptionKey;

		public Sprite icon;

		[Header("Item Properties")]
		public bool isStackable;

		[Tooltip("Max stack size in player inventory")]
		public int maxStackSize;

		[Tooltip("Max stack size in storage inventories (shelves, vehicles, crates, bar)")]
		public int storageMaxStackSize;

		[Header("Item Category")]
		public ItemCategory category;

		[Header("Crafting Properties")]
		[Min(0f)]
		public int tier;

		public bool isBaseMaterial;

		public bool isCraftable;

		public ItemCraftingCategory craftingCategory;

		[Header("Physical Properties")]
		public GameObject worldPrefab;

		[Tooltip("When set, items dropped/displayed on shelves/vehicles show this prefab instead of worldPrefab. Placement system still uses worldPrefab.")]
		public GameObject boxPrefab;

		[Header("Vehicle Storage")]
		[Tooltip("Defines how this item fits in a vehicle bed grid")]
		public VehicleFootprint vehicleFootprint;

		[Header("World Placement")]
		[Tooltip("Defines how this item can be placed in the world")]
		public PlacementFootprint placementFootprint;

		[Header("Shelf Display")]
		[Tooltip("Custom display settings when this item is placed on a shelf")]
		public ShelfDisplaySettings shelfDisplaySettings;

		[Header("Van Shelf Display")]
		[Tooltip("Per-property overrides for the van shelf. Only overridden properties differ from the Shelf Display settings.")]
		public VanShelfDisplayOverrides vanShelfDisplayOverrides;

		[Header("Hand Display")]
		[Tooltip("Custom display settings when this item is held in the player's hand")]
		public HandDisplaySettings handDisplaySettings;

		[Header("Audio")]
		[Tooltip("Sound played when this item is placed/dropped. If null, uses default placement sound.")]
		[SerializeField]
		private AudioClip placementSound;

		[Tooltip("Sound played when this item is picked up/withdrawn. If null, uses default pickup sound.")]
		[SerializeField]
		private AudioClip pickupSound;

		[Tooltip("Sound played when interacting with this item (opening station/shelf UI). If null, uses default interaction sound.")]
		[SerializeField]
		private AudioClip interactionSound;

		[Header("Carrying Configuration")]
		[Tooltip("How this item is carried when selected in inventory. None = cannot be held in hand.")]
		[SerializeField]
		protected ItemCarryType carryType;

		public AudioClip PlacementSound => null;

		public AudioClip PickupSound => null;

		public AudioClip InteractionSound => null;

		public string ItemId => null;

		public GameObject GetDisplayPrefab()
		{
			return null;
		}

		public virtual void Use()
		{
		}

		public virtual string GetDisplayName()
		{
			return null;
		}

		public virtual string GetLocalizedDescription()
		{
			return null;
		}

		public virtual string GetCatalystInfo()
		{
			return null;
		}

		public InventoryItemBrewingData GetBrewingData()
		{
			return null;
		}

		public string GetTooltip()
		{
			return null;
		}

		public virtual bool RequiresMetadata()
		{
			return false;
		}

		public virtual ItemCarryType GetCarryType()
		{
			return default(ItemCarryType);
		}

		public virtual int GetMaxStackSize(InventoryType inventoryType)
		{
			return 0;
		}

		private void OnEnable()
		{
		}
	}
}
