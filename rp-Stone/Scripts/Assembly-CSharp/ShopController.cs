using System;
using System.Collections.Generic;
using SafeTypes;
using UnityEngine;

public class ShopController : MonoBehaviour
{
	private readonly bool DEBUG_FORCE_RESTOCK;

	private readonly int DEBUG_FORCE_LAYOUT_NUMBER = 2;

	public TextAsset[] shopFiles;

	public List<string> treasuresToOpen = new List<string>();

	public List<Item> itemsToGrant = new List<Item>();

	private Dictionary<string, ShopData> shopDict = new Dictionary<string, ShopData>();

	private Dictionary<string, ShopData.ShopState> shopStatesDict = new Dictionary<string, ShopData.ShopState>(2);

	private List<string> shopStateIds = new List<string>(2);

	private float _nextUpdateRemaining;

	public bool hasSeenShopkeeper { get; set; }

	public int totalPurchases { get; set; }

	public static ShopController singleton { get; private set; }

	public static event Action<Item> OnItemPurchased;

	private void Update()
	{
		if (GameStates.Singleton.CurrentState >= GameStates.State.Playing)
		{
			return;
		}
		_nextUpdateRemaining -= Utils.deltaTime;
		if (!(_nextUpdateRemaining <= 0f))
		{
			return;
		}
		_nextUpdateRemaining = 1f;
		for (int i = 0; i < shopStateIds.Count; i++)
		{
			string text = shopStateIds[i];
			if (shopStatesDict[text].HasExpired() && QuestController.singleton.HasPlayed(text))
			{
				QuestController.singleton.MarkAsUnplayed(text);
				QuestController.singleton.MarkAsUnseen(text);
				LimitedTimeBundlesController.singleton.canUnlockNextSuperBundle = true;
			}
		}
	}

	public ShopData GetShopById(string shopId)
	{
		if (shopDict.ContainsKey(shopId))
		{
			return shopDict[shopId];
		}
		Utils.LogWarning("Couldn't find shop with id " + shopId);
		return null;
	}

	public ShopData.ShopState GetShopState(string shopId)
	{
		ShopData.ShopState shopState = null;
		if (shopStatesDict.ContainsKey(shopId))
		{
			shopState = shopStatesDict[shopId];
		}
		if (shopState == null || shopState.HasExpired() || DEBUG_FORCE_RESTOCK)
		{
			shopState = MakeShopState(shopId);
		}
		return shopState;
	}

	private ShopData.ShopState MakeShopState(string shopId)
	{
		ShopData.ShopState shopState = new ShopData.ShopState();
		shopState.shopId = shopId;
		ShopData.ShopState shopState2 = null;
		if (shopStatesDict.ContainsKey(shopId))
		{
			shopState2 = shopStatesDict[shopId];
			shopStatesDict[shopId] = shopState;
			shopState.dateFirstOpened = shopState2.dateFirstOpened;
			shopState.dateGenerated = DateTime.Now;
			shopState.totalDaysOpen = shopState2.totalDaysOpen + 1;
		}
		else
		{
			shopStatesDict.Add(shopId, shopState);
			shopStateIds.Add(shopId);
			shopState.dateFirstOpened = DateTime.Now;
			shopState.dateGenerated = shopState.dateFirstOpened;
			shopState.totalDaysOpen = 0;
		}
		if (DEBUG_FORCE_RESTOCK)
		{
			shopState.totalDaysOpen = DEBUG_FORCE_LAYOUT_NUMBER;
		}
		ShopData shopById = GetShopById(shopId);
		ShopData.Layout layoutForShop = GetLayoutForShop(shopById, shopState);
		List<ShopData.Entry> list = new List<ShopData.Entry>();
		List<ItemData.Element> possibleElements = TreasureFactory.singleton.MakeListOfPossibleElements();
		ShopData.InitDateBasedRng();
		for (int i = 0; i < layoutForShop.entries.Length; i++)
		{
			string[] array = layoutForShop.entries[i];
			foreach (string entryId in array)
			{
				ShopData.Entry entryCopyById = GetEntryCopyById(shopById, entryId, list, possibleElements);
				if (entryCopyById != null)
				{
					entryCopyById.isSmallSlot = array.Length >= 3;
					list.Add(entryCopyById);
					if (entryCopyById.replaceWith != null)
					{
						entryCopyById.replacementEntry = GetEntryCopyById(shopById, entryCopyById.replaceWith, list, possibleElements);
						entryCopyById.replacementEntry.isSmallSlot = entryCopyById.isSmallSlot;
					}
				}
			}
		}
		shopState.fullEntries = list.ToArray();
		if (!string.IsNullOrEmpty(layoutForShop.specialOffer))
		{
			ShopData.Entry entryCopyById2 = GetEntryCopyById(shopById, layoutForShop.specialOffer, list, possibleElements);
			shopState.specialOffer = new ShopData.SpecialOffer(entryCopyById2);
		}
		return shopState;
	}

	private static ShopData.Entry GetEntryCopyById(ShopData shopData, string entryId, List<ShopData.Entry> entriesToAvoid, List<ItemData.Element> possibleElements)
	{
		ShopData.PermutableEntry permutableEntry = null;
		int num = entryId.IndexOf("-");
		if (num > 0)
		{
			possibleElements = new List<ItemData.Element>();
			if (entryId.EndsWith("Poison"))
			{
				possibleElements.Add(ItemData.Element.Poison);
			}
			else if (entryId.EndsWith("Vigor"))
			{
				possibleElements.Add(ItemData.Element.Vigor);
			}
			entryId = entryId.Substring(0, num);
		}
		if (shopData.permutableEntriesDict.ContainsKey(entryId))
		{
			permutableEntry = shopData.permutableEntriesDict[entryId];
			List<string> list = new List<string>();
			for (int i = 0; i < permutableEntry.entries.Length; i++)
			{
				list.Add(permutableEntry.entries[i]);
			}
			for (int j = 0; j < entriesToAvoid.Count; j++)
			{
				list.Remove(entriesToAvoid[j].id);
			}
			for (int num2 = list.Count - 1; num2 >= 0; num2--)
			{
				string key = list[num2];
				if (!shopData.entriesDict.ContainsKey(key))
				{
					list.RemoveAt(num2);
				}
				else if (!shopData.entriesDict[key].EvaluateRequirements())
				{
					list.RemoveAt(num2);
				}
			}
			if (list.Count > 0)
			{
				int dateBasedRandomRange = ShopData.GetDateBasedRandomRange(0, list.Count, reusePreviousRngObject: true);
				entryId = list[dateBasedRandomRange];
			}
			else
			{
				int dateBasedRandomRange2 = ShopData.GetDateBasedRandomRange(0, permutableEntry.entries.Length, reusePreviousRngObject: true);
				entryId = permutableEntry.entries[dateBasedRandomRange2];
			}
		}
		if (shopData.entriesDict.ContainsKey(entryId))
		{
			ShopData.Entry entry = shopData.entriesDict[entryId];
			entry = entry.Copy();
			if (permutableEntry != null)
			{
				if (permutableEntry.randomElement && possibleElements.Count > 0)
				{
					int dateBasedRandomRange3 = ShopData.GetDateBasedRandomRange(0, possibleElements.Count, reusePreviousRngObject: true);
					entry.element = possibleElements[dateBasedRandomRange3];
				}
				entry.rngSeed = ShopData.GetDateBasedRandomRange(0, 999999, reusePreviousRngObject: true);
				entry.baseCost += permutableEntry.bonusBaseCost;
				entry.costPerBuy += permutableEntry.bonusCostPerBuy;
				if (permutableEntry.overrideCopies > 0)
				{
					entry.copies = new SafeInt(permutableEntry.overrideCopies);
				}
			}
			return entry;
		}
		if (permutableEntry != null)
		{
			Utils.LogError("Couldn't find shop entry with id " + entryId + " from permutable entry " + permutableEntry.id);
		}
		else
		{
			Utils.LogError("Couldn't find shop entry with id " + entryId);
		}
		return null;
	}

	private ShopData.Layout GetLayoutForShop(ShopData shopData, ShopData.ShopState knownState)
	{
		int totalDaysOpen = knownState.totalDaysOpen;
		if (shopData.id == "uulaa_shop")
		{
			return GetLayoutForUUlaaShop(shopData, knownState);
		}
		return totalDaysOpen switch
		{
			0 => shopData.GetLayout("pc_day0"), 
			1 => shopData.GetLayout("pc_day1"), 
			_ => shopData.GetLayout("pc_day2"), 
		};
	}

	private ShopData.Layout GetLayoutForUUlaaShop(ShopData shopData, ShopData.ShopState knownState)
	{
		int totalDaysOpen = knownState.totalDaysOpen;
		string text = "pc_day";
		if (totalDaysOpen >= 0 && totalDaysOpen <= 3)
		{
			return shopData.GetLayout(text + totalDaysOpen);
		}
		int num = 4;
		int num2 = 10;
		int dateSeed = ShopData.GetDateSeed();
		int num3 = ((dateSeed % 2 != 0) ? (num + dateSeed / 2 % (num2 - num)) : ShopData.GetDateBasedRandomRange(num, num2));
		if (DEBUG_FORCE_RESTOCK)
		{
			num3 = DEBUG_FORCE_LAYOUT_NUMBER;
		}
		return shopData.GetLayout(text + num3);
	}

	public static int ComputeKiCost(ShopData.Entry entry)
	{
		if (entry is ShopData.SpecialOffer)
		{
			return ((ShopData.SpecialOffer)entry).saleCost.GetValue();
		}
		return entry.baseCost.GetValue() + entry.costPerBuy.GetValue() * entry.amountPurchased.GetValue();
	}

	public static int ComputeKiCostAllRemainingCopies(ShopData.Entry entry)
	{
		int num = ComputeKiCost(entry);
		int num2 = num;
		for (int i = entry.amountPurchased.GetValue() + 1; i < entry.copies.GetValue(); i++)
		{
			num += entry.costPerBuy.GetValue();
			num2 += num;
		}
		return num2;
	}

	public void ResetClock()
	{
		for (int i = 0; i < shopStateIds.Count; i++)
		{
			string key = shopStateIds[i];
			shopStatesDict[key].dateGenerated = DateTime.Now - new TimeSpan(24, 0, 0);
		}
	}

	public static void FireItemPurchased(Item item)
	{
		if (ShopController.OnItemPurchased != null)
		{
			ShopController.OnItemPurchased(item);
		}
	}

	public void ParseShopStates(string sjson)
	{
		ClearProgress();
		if (string.IsNullOrEmpty(sjson))
		{
			return;
		}
		string[] array = SlimJson.ParseArray(sjson, "ids");
		foreach (string text in array)
		{
			if (!shopStatesDict.ContainsKey(text))
			{
				ShopData.ShopState value = SlimJson.Parse(sjson, text, ShopData.ShopState.FromString);
				shopStatesDict.Add(text, value);
				shopStateIds.Add(text);
			}
			else
			{
				Utils.LogError("Duplicate shop state key " + text + " parsing will skip.");
			}
		}
		string[] array2 = SlimJson.ParseArray(sjson, "treasuresToOpen");
		if (array2 != null)
		{
			treasuresToOpen = new List<string>(array2);
		}
		else
		{
			treasuresToOpen.Clear();
		}
		Item[] array3 = SlimJson.ParseArray(sjson, "itemsToGrant", Item.FromString);
		if (array3 != null)
		{
			itemsToGrant = new List<Item>(array3);
		}
		else
		{
			itemsToGrant.Clear();
		}
		hasSeenShopkeeper = SlimJson.ParseBool(sjson, "hasSeenShopkeeper");
		totalPurchases = SlimJson.ParseInt(sjson, "totalPurchases");
		LimitedTimeBundlesController.singleton.Parse(SlimJson.Parse(sjson, "bundles"));
	}

	public string SerializeShopStates()
	{
		SlimJson.BeginSerialization();
		SlimJson.AddProperty("ids", shopStateIds.ToArray());
		for (int i = 0; i < shopStateIds.Count; i++)
		{
			string key = shopStateIds[i];
			ShopData.ShopState shopState = shopStatesDict[key];
			SlimJson.AddProperty(key, shopState.ToString());
		}
		if (treasuresToOpen.Count > 0)
		{
			SlimJson.AddProperty("treasuresToOpen", treasuresToOpen.ToArray());
		}
		if (itemsToGrant.Count > 0)
		{
			SlimJson.AddProperty("itemsToGrant", itemsToGrant.ToArray());
		}
		SlimJson.AddProperty("hasSeenShopkeeper", hasSeenShopkeeper);
		SlimJson.AddProperty("totalPurchases", totalPurchases);
		string text = LimitedTimeBundlesController.singleton.Serialize();
		if (text != null)
		{
			SlimJson.AddProperty("bundles", text);
		}
		return SlimJson.EndSerialization();
	}

	public void ClearProgress()
	{
		treasuresToOpen.Clear();
		itemsToGrant.Clear();
		hasSeenShopkeeper = false;
		totalPurchases = 0;
		shopStatesDict.Clear();
		shopStateIds.Clear();
		LimitedTimeBundlesController.singleton.ClearProgress();
	}

	private void Start()
	{
		LoadShops();
	}

	private void LoadShops()
	{
		for (int i = 0; i < shopFiles.Length; i++)
		{
			if (shopFiles[i] != null)
			{
				LoadShopFile(shopFiles[i].text);
			}
		}
	}

	private void LoadShopFile(string shopJson)
	{
		ShopData shopData = ShopData.FromString(shopJson);
		shopDict.Add(shopData.id, shopData);
		for (int i = 0; i < shopData.entries.Length; i++)
		{
			if (shopData.entries[i] is ShopData.LimitedTimeBundle bundleData)
			{
				LimitedTimeBundlesController.singleton.RegisterShopBundle(shopData.id, bundleData);
			}
		}
	}

	private void Awake()
	{
		singleton = this;
	}
}
