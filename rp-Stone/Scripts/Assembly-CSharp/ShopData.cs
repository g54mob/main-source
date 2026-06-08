using System;
using System.Collections.Generic;
using SafeTypes;

[Serializable]
public class ShopData
{
	[Serializable]
	public class ShopState
	{
		public string shopId;

		public SpecialOffer specialOffer;

		public Entry[] fullEntries;

		public DateTime dateFirstOpened;

		public DateTime dateGenerated;

		public int totalDaysOpen;

		public static ShopState FromString(string sjson)
		{
			ShopState shopState = new ShopState();
			shopState.shopId = SlimJson.Parse(sjson, "shopId");
			shopState.specialOffer = SlimJson.Parse(sjson, "specialOffer", SpecialOffer.FromString);
			shopState.fullEntries = SlimJson.ParseArray(sjson, "fullEntries", Entry.FromString);
			shopState.dateFirstOpened = SlimJson.ParseDateTime(sjson, "dateFirstOpened");
			shopState.dateGenerated = SlimJson.ParseDateTime(sjson, "dateGenerated");
			if (SlimJson.HasKey(sjson, "totalDaysOpen"))
			{
				shopState.totalDaysOpen = SlimJson.ParseInt(sjson, "totalDaysOpen");
			}
			else
			{
				shopState.totalDaysOpen = (DateTime.Now - shopState.dateFirstOpened).Days;
			}
			return shopState;
		}

		public override string ToString()
		{
			SlimJson.BeginSerialization();
			SlimJson.AddProperty("shopId", shopId);
			if (specialOffer != null)
			{
				SlimJson.AddProperty("specialOffer", specialOffer.ToString());
			}
			SlimJson.AddProperty("fullEntries", fullEntries);
			SlimJson.AddProperty("dateFirstOpened", dateFirstOpened);
			SlimJson.AddProperty("dateGenerated", dateGenerated);
			SlimJson.AddProperty("totalDaysOpen", totalDaysOpen);
			return SlimJson.EndSerialization();
		}

		public bool HasExpired()
		{
			DateTime now = DateTime.Now;
			if (now > dateGenerated)
			{
				if (dateGenerated.Day == now.Day)
				{
					return dateGenerated.Month != now.Month;
				}
				return true;
			}
			return false;
		}

		public double RestockSecondsRemaining()
		{
			if (HasExpired())
			{
				return 0.0;
			}
			return Utils.GetSecondsUtilMidnight();
		}
	}

	[Serializable]
	public class Layout : BaseEntry
	{
		public string specialOffer;

		public string[][] entries;

		public static Layout FromString(string sjson)
		{
			return new Layout
			{
				id = SlimJson.Parse(sjson, "id"),
				specialOffer = SlimJson.Parse(sjson, "specialOffer"),
				entries = SlimJson.ParseArray2D(sjson, "entries")
			};
		}

		public override string ToString()
		{
			SlimJson.BeginSerialization();
			SlimJson.AddProperty("id", id);
			if (specialOffer != null)
			{
				SlimJson.AddProperty("specialOffer", specialOffer);
			}
			if (entries != null)
			{
				SlimJson.AddProperty("entries", entries);
			}
			return SlimJson.EndSerialization();
		}
	}

	[Serializable]
	public class PermutableEntry : BaseEntry
	{
		public bool randomElement;

		public string[] entries;

		public int bonusBaseCost;

		public int bonusCostPerBuy;

		public int overrideCopies;

		public static PermutableEntry FromString(string sjson)
		{
			return new PermutableEntry
			{
				id = SlimJson.Parse(sjson, "id"),
				randomElement = SlimJson.ParseBool(sjson, "randomElement"),
				entries = SlimJson.ParseArray(sjson, "entries"),
				bonusBaseCost = SlimJson.ParseInt(sjson, "bonusBaseCost"),
				bonusCostPerBuy = SlimJson.ParseInt(sjson, "bonusCostPerBuy"),
				overrideCopies = SlimJson.ParseInt(sjson, "overrideCopies")
			};
		}

		public override string ToString()
		{
			SlimJson.BeginSerialization();
			SlimJson.AddProperty("id", id);
			SlimJson.AddProperty("randomElement", randomElement);
			if (entries != null)
			{
				SlimJson.AddProperty("entries", entries);
			}
			SlimJson.AddProperty("bonusBaseCost", bonusBaseCost);
			SlimJson.AddProperty("bonusCostPerBuy", bonusCostPerBuy);
			SlimJson.AddProperty("overrideCopies", overrideCopies);
			return SlimJson.EndSerialization();
		}
	}

	[Serializable]
	public class Entry : BaseEntry
	{
		public string itemId;

		public SafeInt copies;

		public SafeInt baseCost;

		public SafeInt costPerBuy;

		public string requiresFlag;

		public string requiresItem;

		public string replaceWith;

		public Entry replacementEntry;

		public string title;

		public SafeInt kiReward;

		public SafeInt kiPerLevel;

		public string[] treasures;

		public float cashCost;

		public int specialMin;

		public int specialMax;

		public string iconId;

		public ItemData.Element element;

		public int rarityBonus;

		public int rngSeed;

		public bool isSmallSlot;

		public SafeInt amountPurchased;

		public int percentOff { get; set; }

		public Entry Copy()
		{
			Entry obj = new Entry
			{
				id = id,
				itemId = itemId,
				copies = new SafeInt(copies.GetValue()),
				baseCost = new SafeInt(baseCost.GetValue()),
				costPerBuy = new SafeInt(costPerBuy.GetValue()),
				requiresFlag = requiresFlag,
				requiresItem = requiresItem,
				replaceWith = replaceWith,
				replacementEntry = replacementEntry,
				title = title,
				kiReward = new SafeInt(kiReward.GetValue()),
				kiPerLevel = new SafeInt(kiPerLevel.GetValue()),
				treasures = treasures,
				cashCost = cashCost,
				specialMin = specialMin,
				specialMax = specialMax,
				iconId = iconId,
				element = element,
				rarityBonus = rarityBonus,
				rngSeed = rngSeed,
				isSmallSlot = isSmallSlot,
				amountPurchased = new SafeInt(amountPurchased.GetValue())
			};
			PreventFreeIAPExploit(obj);
			return obj;
		}

		private static void PreventFreeIAPExploit(Entry entry)
		{
			if (entry.cashCost < 0.09f && entry.id.StartsWith("iap_"))
			{
				entry.cashCost = 0.99f;
			}
		}

		public static Entry FromString(string sjson)
		{
			Entry entry = ((!LimitedTimeBundleFactory.IsLimitedTimeBundleEntryData(sjson)) ? new Entry() : LimitedTimeBundleFactory.InstantiateEntryData(sjson));
			entry.ParseEntry(sjson);
			PreventFreeIAPExploit(entry);
			return entry;
		}

		public virtual void ParseEntry(string sjson)
		{
			if (SlimJson.HasKey(sjson, "abb"))
			{
				id = SlimJson.Parse(sjson, "id");
				itemId = SlimJson.Parse(sjson, "it");
				copies = new SafeInt(SlimJson.ParseInt(sjson, "co"));
				baseCost = new SafeInt(SlimJson.ParseInt(sjson, "bC"));
				costPerBuy = new SafeInt(SlimJson.ParseInt(sjson, "cpb"));
				requiresFlag = SlimJson.Parse(sjson, "rF");
				requiresItem = SlimJson.Parse(sjson, "rI");
				replaceWith = SlimJson.Parse(sjson, "rW");
				replacementEntry = SlimJson.Parse(sjson, "rE", FromString);
				title = SlimJson.Parse(sjson, "ti");
				kiReward = new SafeInt(SlimJson.ParseInt(sjson, "kR"));
				kiPerLevel = new SafeInt(SlimJson.ParseInt(sjson, "kPL"));
				treasures = SlimJson.ParseArray(sjson, "tr");
				cashCost = SlimJson.ParseFloat(sjson, "cC");
				specialMin = SlimJson.ParseInt(sjson, "sMin");
				specialMax = SlimJson.ParseInt(sjson, "sMax");
				iconId = SlimJson.Parse(sjson, "ic");
				element = SlimJson.ParseEnum<ItemData.Element>(sjson, "el");
				rarityBonus = SlimJson.ParseInt(sjson, "rB");
				rngSeed = SlimJson.ParseInt(sjson, "rng");
				isSmallSlot = SlimJson.ParseBool(sjson, "iSS");
				amountPurchased = new SafeInt(SlimJson.ParseInt(sjson, "amP"));
			}
			else
			{
				id = SlimJson.Parse(sjson, "id");
				itemId = SlimJson.Parse(sjson, "itemId");
				copies = new SafeInt(SlimJson.ParseInt(sjson, "copies"));
				baseCost = new SafeInt(SlimJson.ParseInt(sjson, "baseCost"));
				costPerBuy = new SafeInt(SlimJson.ParseInt(sjson, "costPerBuy"));
				requiresFlag = SlimJson.Parse(sjson, "requiresFlag");
				requiresItem = SlimJson.Parse(sjson, "requiresItem");
				replaceWith = SlimJson.Parse(sjson, "replaceWith");
				title = SlimJson.Parse(sjson, "title");
				kiReward = new SafeInt(SlimJson.ParseInt(sjson, "kiReward"));
				kiPerLevel = new SafeInt(SlimJson.ParseInt(sjson, "kiPerLevel"));
				treasures = SlimJson.ParseArray(sjson, "treasures");
				cashCost = SlimJson.ParseFloat(sjson, "cashCost");
				specialMin = SlimJson.ParseInt(sjson, "specialMin");
				specialMax = SlimJson.ParseInt(sjson, "specialMax");
				iconId = SlimJson.Parse(sjson, "iconId");
				element = SlimJson.ParseEnum<ItemData.Element>(sjson, "element");
				rarityBonus = SlimJson.ParseInt(sjson, "rarityBonus");
				rngSeed = SlimJson.ParseInt(sjson, "rngSeed");
				isSmallSlot = SlimJson.ParseBool(sjson, "isSmallSlot");
				amountPurchased = new SafeInt(SlimJson.ParseInt(sjson, "amountPurchased"));
			}
		}

		public override string ToString()
		{
			SlimJson.BeginSerialization();
			SerializeEntry();
			return SlimJson.EndSerialization();
		}

		public virtual void SerializeEntry()
		{
			SlimJson.AddProperty("abb", property: true);
			SlimJson.AddProperty("id", id);
			if (itemId != null)
			{
				SlimJson.AddProperty("it", itemId);
			}
			if (copies.GetValue() != 0)
			{
				SlimJson.AddProperty("co", copies.GetValue());
			}
			if (baseCost.GetValue() != 0)
			{
				SlimJson.AddProperty("bC", baseCost.GetValue());
			}
			if (costPerBuy.GetValue() != 0)
			{
				SlimJson.AddProperty("cpb", costPerBuy.GetValue());
			}
			if (!string.IsNullOrEmpty(requiresFlag))
			{
				SlimJson.AddProperty("rF", requiresFlag);
			}
			if (!string.IsNullOrEmpty(requiresItem))
			{
				SlimJson.AddProperty("rI", requiresItem);
			}
			if (!string.IsNullOrEmpty(replaceWith))
			{
				SlimJson.AddProperty("rW", replaceWith);
			}
			if (replacementEntry != null)
			{
				SlimJson.AddProperty("rE", replacementEntry.ToString());
			}
			if (!string.IsNullOrEmpty(title))
			{
				SlimJson.AddProperty("ti", title);
			}
			if (kiReward.GetValue() != 0)
			{
				SlimJson.AddProperty("kR", kiReward.GetValue());
			}
			if (kiPerLevel.GetValue() != 0)
			{
				SlimJson.AddProperty("kPL", kiPerLevel.GetValue());
			}
			if (treasures != null && treasures.Length != 0)
			{
				SlimJson.AddProperty("tr", treasures);
			}
			if (cashCost > 0f)
			{
				SlimJson.AddProperty("cC", cashCost);
			}
			if (specialMin != 0)
			{
				SlimJson.AddProperty("sMin", specialMin);
			}
			if (specialMax != 0)
			{
				SlimJson.AddProperty("sMax", specialMax);
			}
			if (iconId != null)
			{
				SlimJson.AddProperty("ic", iconId);
			}
			if (element != ItemData.Element.Stone)
			{
				SlimJson.AddProperty("el", element.ToString());
			}
			if (rarityBonus != 0)
			{
				SlimJson.AddProperty("rB", rarityBonus);
			}
			if (rngSeed != 0)
			{
				SlimJson.AddProperty("rng", rngSeed);
			}
			if (isSmallSlot)
			{
				SlimJson.AddProperty("iSS", isSmallSlot);
			}
			if (amountPurchased.GetValue() != 0)
			{
				SlimJson.AddProperty("amP", amountPurchased.GetValue());
			}
		}

		public bool EvaluateRequirements()
		{
			if (!string.IsNullOrEmpty(requiresFlag))
			{
				return ProgressFlags.GetFlag(requiresFlag);
			}
			if (!string.IsNullOrEmpty(requiresItem))
			{
				return Inventory.Singleton.HasItemById(requiresItem);
			}
			return true;
		}

		public virtual string GetPurchaseId()
		{
			return id;
		}
	}

	[Serializable]
	public class SpecialOffer : Entry
	{
		public SafeInt saleCost;

		public SpecialOffer()
		{
		}

		public SpecialOffer(Entry entry)
		{
			ParseEntry(entry.ToString());
			CalculateSaleCost();
			copies = new SafeInt(1);
		}

		private void CalculateSaleCost()
		{
			int dateBasedRandomRange = GetDateBasedRandomRange(specialMin, specialMax + 1);
			saleCost = new SafeInt(dateBasedRandomRange);
		}

		public new static SpecialOffer FromString(string sjson)
		{
			SpecialOffer specialOffer = new SpecialOffer();
			specialOffer.ParseEntry(sjson);
			return specialOffer;
		}

		public override void ParseEntry(string sjson)
		{
			base.ParseEntry(sjson);
			saleCost = new SafeInt(SlimJson.ParseInt(sjson, "saleCost"));
		}

		public override string ToString()
		{
			SlimJson.BeginSerialization();
			SerializeEntry();
			SlimJson.AddProperty("saleCost", saleCost.GetValue());
			return SlimJson.EndSerialization();
		}
	}

	[Serializable]
	public class LimitedTimeBundle : Entry
	{
		public int limitedDays;

		public bool isBeginnerBundle;

		public bool hasStarted;

		public DateTime startDate;

		public void StartClock()
		{
			hasStarted = true;
			startDate = DateTime.Now;
		}

		public long GetRemainingSeconds()
		{
			if (hasStarted)
			{
				return (long)(startDate + new TimeSpan(limitedDays, 0, 0, 0) - DateTime.Now).TotalSeconds;
			}
			return -1L;
		}

		public bool HasExpired()
		{
			if (hasStarted)
			{
				return GetRemainingSeconds() <= 0;
			}
			return false;
		}

		public virtual bool CheckStartConditions()
		{
			return true;
		}

		public virtual Item MakeInventoryItem()
		{
			return null;
		}

		public virtual List<Item> GetItems()
		{
			return null;
		}

		public override void ParseEntry(string sjson)
		{
			base.ParseEntry(sjson);
			limitedDays = SlimJson.ParseInt(sjson, "limitedDays");
			isBeginnerBundle = SlimJson.ParseBool(sjson, "isBeginner");
			hasStarted = SlimJson.HasKey(sjson, "startDate");
			if (hasStarted)
			{
				startDate = SlimJson.ParseDateTime(sjson, "startDate");
			}
		}

		public override string ToString()
		{
			SlimJson.BeginSerialization();
			SerializeEntry();
			SlimJson.AddProperty("limitedDays", limitedDays);
			if (isBeginnerBundle)
			{
				SlimJson.AddProperty("isBeginner", property: true);
			}
			if (hasStarted)
			{
				SlimJson.AddProperty("startDate", startDate);
			}
			return SlimJson.EndSerialization();
		}
	}

	public class BaseEntry
	{
		public string id;
	}

	public string name;

	public string id;

	public string iconId;

	public Layout[] layouts;

	public PermutableEntry[] permutableEntries;

	public Entry[] entries;

	public Dictionary<string, Layout> layoutsDict = new Dictionary<string, Layout>();

	public Dictionary<string, PermutableEntry> permutableEntriesDict = new Dictionary<string, PermutableEntry>();

	public Dictionary<string, Entry> entriesDict = new Dictionary<string, Entry>();

	private static Random rng;

	public static ShopData FromString(string sjson)
	{
		ShopData shopData = new ShopData();
		shopData.name = SlimJson.Parse(sjson, "name");
		shopData.id = SlimJson.Parse(sjson, "id");
		shopData.iconId = SlimJson.Parse(sjson, "iconId");
		shopData.layouts = SlimJson.ParseArray(sjson, "layouts", Layout.FromString);
		shopData.permutableEntries = SlimJson.ParseArray(sjson, "permutableEntries", PermutableEntry.FromString);
		shopData.entries = SlimJson.ParseArray(sjson, "entries", Entry.FromString);
		PopulateDictionary(shopData.layoutsDict, shopData.layouts);
		PopulateDictionary(shopData.permutableEntriesDict, shopData.permutableEntries);
		PopulateDictionary(shopData.entriesDict, shopData.entries);
		return shopData;
	}

	private static void PopulateDictionary<T>(Dictionary<string, T> dict, T[] arr) where T : BaseEntry
	{
		dict.Clear();
		for (int i = 0; i < arr.Length; i++)
		{
			string text = arr[i].id;
			if (dict.ContainsKey(text))
			{
				Utils.LogError("Duplicate key '" + text + "' found when parsing shop data. Ignoring entry " + arr[i]);
			}
			else
			{
				dict.Add(text, arr[i]);
			}
		}
	}

	public override string ToString()
	{
		SlimJson.BeginSerialization();
		SlimJson.AddProperty("name", name);
		SlimJson.AddProperty("id", id);
		SlimJson.AddProperty("iconId", iconId);
		if (layouts != null)
		{
			SlimJson.AddProperty("layouts", layouts);
		}
		if (permutableEntries != null)
		{
			SlimJson.AddProperty("permutableEntries", permutableEntries);
		}
		if (entries != null)
		{
			SlimJson.AddProperty("entries", entries);
		}
		return SlimJson.EndSerialization();
	}

	public Layout GetLayout(string layoutId)
	{
		if (layoutsDict.ContainsKey(layoutId))
		{
			return layoutsDict[layoutId];
		}
		Utils.LogError("Could not find layout with id " + layoutId);
		if (layouts.Length != 0)
		{
			return layouts[0];
		}
		Utils.LogError("No layouts found");
		return null;
	}

	public static int GetDateSeed()
	{
		DateTime now = DateTime.Now;
		return now.Year + now.Month * 40 + now.Day;
	}

	public static int GetDateBasedRandomRange(int minInclusive, int maxExclusive, bool reusePreviousRngObject = false)
	{
		if (rng == null || !reusePreviousRngObject)
		{
			InitDateBasedRng();
		}
		return rng.Next(minInclusive, maxExclusive);
	}

	public static void InitDateBasedRng()
	{
		rng = new Random(GetDateSeed());
	}
}
