using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Localization;

[CreateAssetMenu(menuName = "TrainSurvival/Collectable Item Data")]
public class CollectableItemData : ScriptableObject
{
	public string itemName;

	public string itemDisplayName;

	public string itemFPSTemplateKey;

	public string itemDescription;

	[Tooltip("Scan folder yapılırken bu item dahil edilsin mi?")]
	public bool isIncludeToTranslate = true;

	[Tooltip("Localization table'dan display name key'i seç")]
	public LocalizedString displayNameLocalized;

	[Tooltip("Localization table'dan description key'i seç")]
	public LocalizedString descriptionLocalized;

	public ItemType itemType;

	public Sprite itemImage;

	[Tooltip("Bu item aynı zamanda saksıya ekilebilir mi? (Food itemlar için)")]
	public bool isPlantable;

	public float IncreaseBoost = 10f;

	[Range(0f, 1f)]
	public float fullRatio;

	public float growingTime;

	public List<GameObject> plantLevelPrefabs = new List<GameObject>();

	public List<Material> cookableLevelMaterials = new List<Material>();

	public CollectableItemData mainItem;

	public GameObject itemPrefab;

	public bool hasDurability;

	public float startDurability = 100f;

	public float maxDurabilityCapacity = 100f;

	public float durabilityDecreasePerUse = 1f;

	[Tooltip("Durability azaldıkça renk değişecek mi? (Yeşil -> Sarı -> Kırmızı)")]
	public bool changeColorForDurability = true;

	[Tooltip("Durability bitince item yok olacak mı?")]
	public bool clearItemOnDurabilityFinished = true;

	[Tooltip("True ise durability elde tutarken sürekli azalır (meşale gibi). False ise sadece kullanınca azalır (balta, kazma gibi).")]
	public bool continuousDurabilityDecrease;

	public bool isOpenedInStart;

	public bool isResearched;

	public bool isLearned;

	public ItemSizeType itemSizeType = ItemSizeType.Single;

	public int pawnShopPrice;

	public int shopPrice;

	public float itemWeight;

	public float itemExp;

	public float useDuration = 1f;

	public float productionDuration = 1f;

	public int productionCount = 1;

	public float burningTime = 30f;

	[Tooltip("Grill'de pişince envantere verilecek item ve miktar")]
	public CostData cookedReward;

	public PlayerPowerUpType powerUpType;

	[Tooltip("True ise PowerUp UI panelinde gösterilmez, efekt direkt uygulanır")]
	public bool isInstantUse;

	[Tooltip("Powerup'ın süre bazlı efektler için ne kadar süre aktif kalacağı (saniye)")]
	public float powerUpDuration = 30f;

	public float IncreaseHungerPerUse = 10f;

	public float IncreaseWaterPerUse;

	[Tooltip("Pozitif değer can arttırır, negatif değer can azaltır (zehirli yemekler için)")]
	public float IncreaseHealthPerUse;

	public List<CostData> costData = new List<CostData>();

	public List<CollectableItemData> neededCraftingTable = new List<CollectableItemData>();

	public List<CollectableItemData> neededResearchItems = new List<CollectableItemData>();

	public int craftingCount = 1;

	[HideInInspector]
	public List<EASTUP_InventorySlotItem> Slots = new List<EASTUP_InventorySlotItem>();

	public Info Info;

	public List<CostData> rewardData = new List<CostData>();

	public bool isNetworkObject;

	public bool useUnarmedAnimations;

	public int GetItemSizeMultiplier()
	{
		if (itemSizeType == ItemSizeType.MaxSize)
		{
			if (!(Singleton<GameSettings>.Instance != null))
			{
				return 16;
			}
			return Singleton<GameSettings>.Instance.inventorySlotSize;
		}
		return (int)itemSizeType;
	}

	public bool CanBePlanted()
	{
		if (itemType != ItemType.Plant && itemType != ItemType.Tree)
		{
			return isPlantable;
		}
		return true;
	}

	public string GetLocalizedDisplayName()
	{
		if (displayNameLocalized != null && !displayNameLocalized.IsEmpty)
		{
			string localizedString = displayNameLocalized.GetLocalizedString();
			if (!string.IsNullOrEmpty(localizedString) && !IsMissingTranslation(localizedString))
			{
				return localizedString;
			}
		}
		if (!string.IsNullOrEmpty(itemDisplayName))
		{
			return itemDisplayName;
		}
		return itemName;
	}

	public string GetLocalizedDescription()
	{
		if (descriptionLocalized != null && !descriptionLocalized.IsEmpty)
		{
			string localizedString = descriptionLocalized.GetLocalizedString();
			if (!string.IsNullOrEmpty(localizedString) && !IsMissingTranslation(localizedString))
			{
				return localizedString;
			}
		}
		if (!string.IsNullOrEmpty(itemDescription))
		{
			return itemDescription;
		}
		return "";
	}

	private bool IsMissingTranslation(string text)
	{
		if (!text.Contains("No translation") && !text.Contains("No localization") && !text.Contains("Missing Translation"))
		{
			return text.Contains("MISSING");
		}
		return true;
	}
}
