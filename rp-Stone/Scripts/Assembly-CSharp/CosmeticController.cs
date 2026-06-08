using System;
using System.Collections.Generic;
using UnityEngine;

public class CosmeticController : MonoBehaviour
{
	public class Collection
	{
		public string collectionId;

		public DateTime releaseDate;

		public string finalItemId;

		public string prefabPath;

		public Cosmetic cosmeticPrefab;

		public Set[] sets;

		public List<ItemEntry> commons = new List<ItemEntry>();

		public List<ItemEntry> rares = new List<ItemEntry>();

		public List<ItemEntry> collectedItems = new List<ItemEntry>();

		public Dictionary<string, ItemEntry> collectedItemsDict = new Dictionary<string, ItemEntry>();

		public Dictionary<string, ItemEntry> remainingCommons = new Dictionary<string, ItemEntry>();

		public Dictionary<string, ItemEntry> remainingRares = new Dictionary<string, ItemEntry>();

		public int totalCollectionSize { get; private set; }

		public int remainingDropCount => remainingCommons.Count + remainingRares.Count;

		public bool IsReleased()
		{
			return DateTime.Now >= releaseDate;
		}

		public Collection(string sjson)
		{
			collectionId = SlimJson.Parse(sjson, "id");
			releaseDate = SlimJson.ParseDateTime(sjson, "releaseDate", new DateTime(2019, 8, 8));
			finalItemId = SlimJson.Parse(sjson, "final_item");
			prefabPath = SlimJson.Parse(sjson, "prefab");
			GameObject gameObject = Resources.Load(prefabPath) as GameObject;
			cosmeticPrefab = gameObject.GetComponent<Cosmetic>();
			cosmeticPrefab.cosmeticCollection = this;
			string[] array = SlimJson.ParseArray(sjson, "sets");
			sets = new Set[array.Length];
			for (int i = 0; i < array.Length; i++)
			{
				string text = array[i];
				sets[i] = new Set(text, SlimJson.ParseArray(sjson, text));
			}
			ParseItemList(sjson, "commons", commons);
			ParseItemList(sjson, "rares", rares);
			SetupRemainingItems();
		}

		private void ParseItemList(string sjson, string collectionKey, List<ItemEntry> itemEntryList)
		{
			string[] array = SlimJson.ParseArray(sjson, collectionKey);
			foreach (string text in array)
			{
				int num = text.IndexOf(':');
				if (num < 0)
				{
					itemEntryList.Add(new ItemEntry(text, ItemData.Element.Stone));
					continue;
				}
				string id = text.Substring(0, num);
				string text2 = text.Substring(num + 1);
				if (text2 == "All")
				{
					itemEntryList.Add(new ItemEntry(id, ItemData.Element.AEther));
					itemEntryList.Add(new ItemEntry(id, ItemData.Element.Fire));
					itemEntryList.Add(new ItemEntry(id, ItemData.Element.Ice));
					itemEntryList.Add(new ItemEntry(id, ItemData.Element.Poison));
					itemEntryList.Add(new ItemEntry(id, ItemData.Element.Vigor));
				}
				else
				{
					ItemData.Element e = Enum.Parse<ItemData.Element>(text2);
					itemEntryList.Add(new ItemEntry(id, e));
				}
			}
		}

		private void SetupRemainingItems()
		{
			SetupDictionary(commons, remainingCommons);
			SetupDictionary(rares, remainingRares);
			totalCollectionSize = commons.Count + rares.Count + sets.Length + 1;
		}

		private void SetupDictionary(List<ItemEntry> itemEntryList, Dictionary<string, ItemEntry> remainingItemsDict)
		{
			remainingItemsDict.Clear();
			for (int i = 0; i < itemEntryList.Count; i++)
			{
				ItemEntry itemEntry = itemEntryList[i];
				remainingItemsDict.Add(itemEntry.GetDictionaryKey(), itemEntry);
			}
		}

		public bool HasDroppedFinalItem()
		{
			string dictionaryKey = ItemEntry.GetDictionaryKey(finalItemId, ItemData.Element.Stone);
			return collectedItemsDict.ContainsKey(dictionaryKey);
		}

		public void RemoveFromRemaining(ItemEntry entry)
		{
			string dictionaryKey = entry.GetDictionaryKey();
			if (remainingCommons.ContainsKey(dictionaryKey))
			{
				remainingCommons.Remove(dictionaryKey);
			}
			else if (remainingRares.ContainsKey(dictionaryKey))
			{
				remainingRares.Remove(dictionaryKey);
			}
		}

		public ItemEntry GetOwnedCosmeticItemEntry(string itemId, ItemData.Element element = ItemData.Element.Stone)
		{
			string dictionaryKey = ItemEntry.GetDictionaryKey(itemId, element);
			if (collectedItemsDict.ContainsKey(dictionaryKey))
			{
				return collectedItemsDict[dictionaryKey];
			}
			return null;
		}

		public void ClearProgress()
		{
			collectedItems.Clear();
			collectedItemsDict.Clear();
			SetupRemainingItems();
		}
	}

	public class Set
	{
		public string rewardId;

		public ItemEntry[] requirements;

		private HashSet<string> containsHash;

		public Set(string id, string[] reqs)
		{
			rewardId = id;
			requirements = new ItemEntry[reqs.Length];
			containsHash = new HashSet<string>(reqs.Length);
			for (int i = 0; i < reqs.Length; i++)
			{
				ItemEntry itemEntry = ItemEntry.FromString(reqs[i]);
				requirements[i] = itemEntry;
				containsHash.Add(itemEntry.GetDictionaryKey());
			}
		}

		public bool ContainsRequirement(ItemEntry item)
		{
			return ContainsRequirement(item.GetDictionaryKey());
		}

		public bool ContainsRequirement(string itemDictionaryKey)
		{
			return containsHash.Contains(itemDictionaryKey);
		}
	}

	public class SetUnlock
	{
		public string collectionId;

		public string rewardId;

		public ItemEntry[] requirements;

		public bool[] ownership;

		public bool[] unlockPending;

		public List<int> unlockIndexes;

		public bool unlockReward;

		public string rewardName;

		public SetUnlock(Collection c, Set setData)
		{
			collectionId = c.collectionId;
			rewardId = setData.rewardId;
			requirements = setData.requirements;
			ownership = new bool[requirements.Length + 1];
			unlockPending = new bool[requirements.Length + 1];
			unlockIndexes = new List<int>(1);
			unlockReward = false;
			for (int i = 0; i < requirements.Length; i++)
			{
				string dictionaryKey = requirements[i].GetDictionaryKey();
				if (c.collectedItemsDict.ContainsKey(dictionaryKey))
				{
					ownership[i] = true;
				}
			}
		}

		public bool HasItemRequirement(ItemEntry item)
		{
			string dictionaryKey = item.GetDictionaryKey();
			for (int i = 0; i < requirements.Length; i++)
			{
				if (requirements[i].GetDictionaryKey() == dictionaryKey)
				{
					return true;
				}
			}
			return false;
		}

		public void AddUnlock(ItemEntry item)
		{
			string dictionaryKey = item.GetDictionaryKey();
			for (int i = 0; i < requirements.Length; i++)
			{
				if (requirements[i].GetDictionaryKey() == dictionaryKey && !ownership[i])
				{
					unlockIndexes.Add(i);
					unlockPending[i] = true;
					break;
				}
			}
			int num = 0;
			for (int j = 0; j < ownership.Length; j++)
			{
				if (ownership[j])
				{
					num++;
				}
			}
			if (num + unlockIndexes.Count >= requirements.Length)
			{
				unlockReward = true;
				unlockPending[unlockPending.Length - 1] = true;
			}
		}
	}

	public class ItemEntry
	{
		public string itemId;

		public ItemData.Element element;

		public bool isNew;

		public string appliedGroupId;

		public ItemEntry()
		{
		}

		public ItemEntry(string id, ItemData.Element e)
		{
			itemId = id;
			element = e;
			isNew = true;
		}

		public string GetDictionaryKey()
		{
			return GetDictionaryKey(itemId, element);
		}

		public static string GetDictionaryKey(string _itemId, ItemData.Element _element)
		{
			if (_element == ItemData.Element.Stone)
			{
				return _itemId + "z";
			}
			return _itemId + _element;
		}

		public static ItemEntry FromString(string str)
		{
			ItemEntry itemEntry = new ItemEntry();
			string[] array = str.Split(';');
			string obj = array[0];
			itemEntry.isNew = false;
			if (array.Length > 1)
			{
				itemEntry.isNew = true;
			}
			array = obj.Split(':');
			itemEntry.itemId = array[0];
			if (array.Length > 1)
			{
				string value = array[1];
				itemEntry.element = Enum.Parse<ItemData.Element>(value);
			}
			return itemEntry;
		}

		public override string ToString()
		{
			string text = itemId;
			if (element != ItemData.Element.Stone)
			{
				text = text + ":" + element;
			}
			if (isNew)
			{
				text += ";new";
			}
			return text;
		}
	}

	public TextAsset[] collectionDefinitions;

	private Dictionary<string, Cosmetic> cosmeticPrefabs = new Dictionary<string, Cosmetic>();

	private Dictionary<string, SetUnlock> activeUnlockDict = new Dictionary<string, SetUnlock>(1);

	private List<SetUnlock> activeUnlocks = new List<SetUnlock>(1);

	public Collection[] collections { get; private set; }

	public static CosmeticController singleton { get; private set; }

	public bool HasActiveSetUnlocks()
	{
		return activeUnlocks.Count > 0;
	}

	public SetUnlock PopActiveSetUnlocks()
	{
		SetUnlock setUnlock = activeUnlocks[0];
		activeUnlockDict.Remove(setUnlock.rewardId);
		activeUnlocks.RemoveAt(0);
		return setUnlock;
	}

	public Cosmetic GetCosmeticPrefab(string id)
	{
		if (cosmeticPrefabs.ContainsKey(id))
		{
			return cosmeticPrefabs[id];
		}
		Utils.LogErrorIfEditor("Couldn't find cosmetic with id: " + id);
		return null;
	}

	public Cosmetic FindInventoryCosmetic(string collectionId, ItemEntry itemEntry)
	{
		return FindInventoryCosmetic(collectionId, itemEntry.itemId, itemEntry.element);
	}

	public Cosmetic FindInventoryCosmetic(Item item)
	{
		if (item.cosmeticId == null)
		{
			return null;
		}
		return FindInventoryCosmetic(item.cosmeticId, item.id, item.element);
	}

	public Cosmetic FindInventoryCosmetic(string collectionId, string itemId, ItemData.Element element)
	{
		List<Cosmetic> cosmetics = Inventory.Singleton.GetCosmetics();
		for (int num = cosmetics.Count - 1; num >= 0; num--)
		{
			Cosmetic cosmetic = cosmetics[num];
			if (!(cosmetic == null) && cosmetic.cosmeticCollection != null && cosmetic.cosmeticCollection.collectionId == collectionId && cosmetic.targetItem.itemId == itemId && cosmetic.targetItem.element == element)
			{
				return cosmetic;
			}
		}
		return null;
	}

	public ItemEntry GetOwnedCosmeticItemEntry(string collectionId, string itemId, ItemData.Element element = ItemData.Element.Stone)
	{
		Collection collection = GetCollection(collectionId);
		if (collection != null)
		{
			return collection.GetOwnedCosmeticItemEntry(itemId, element);
		}
		Utils.LogErrorIfEditor("GetOwnedCosmeticItemEntry() could not find collection with id: " + collectionId);
		return null;
	}

	public Collection GetCollection(string id)
	{
		for (int i = 0; i < collections.Length; i++)
		{
			if (collections[i].collectionId == id)
			{
				return collections[i];
			}
		}
		return null;
	}

	public bool HasCosmeticsToDrop(bool countFinalCollectionItems, string collectionId = null)
	{
		for (int i = 0; i < collections.Length; i++)
		{
			Collection collection = collections[i];
			if ((collectionId == null || !(collection.collectionId != collectionId)) && (collection.IsReleased() || !(collection.collectionId != collectionId)))
			{
				if (countFinalCollectionItems && !collection.HasDroppedFinalItem())
				{
					return true;
				}
				if (collection.remainingDropCount > 0)
				{
					return true;
				}
			}
		}
		return false;
	}

	public Cosmetic DropFinalItemForCollection(Collection c)
	{
		ItemEntry itemEntry = new ItemEntry(c.finalItemId, ItemData.Element.Stone);
		string dictionaryKey = itemEntry.GetDictionaryKey();
		Cosmetic cosmetic = InstantiateCosmeticItem(itemEntry, c);
		AddToInventory(cosmetic);
		c.collectedItems.Add(itemEntry);
		c.collectedItemsDict.Add(dictionaryKey, itemEntry);
		return cosmetic;
	}

	public Cosmetic AddRandomCosmeticToInventory(System.Random random, string collectionId = null)
	{
		for (int i = 0; i < collections.Length; i++)
		{
			Collection collection = collections[i];
			if ((collectionId == null || !(collection.collectionId != collectionId)) && (collection.IsReleased() || !(collection.collectionId != collectionId)) && collection.collectedItems.Count == collection.totalCollectionSize - 1 && !collection.HasDroppedFinalItem())
			{
				return DropFinalItemForCollection(collection);
			}
		}
		Collection collection2 = collections[0];
		int num = 0;
		for (int j = 0; j < collections.Length; j++)
		{
			Collection collection3 = collections[j];
			if ((collectionId == null || !(collection3.collectionId != collectionId)) && (collection3.IsReleased() || !(collection3.collectionId != collectionId)))
			{
				num += collection3.remainingDropCount;
			}
		}
		int num2 = random.Next(num);
		for (int k = 0; k < collections.Length; k++)
		{
			Collection collection4 = collections[k];
			if ((collectionId == null || !(collection4.collectionId != collectionId)) && (collection4.IsReleased() || !(collection4.collectionId != collectionId)))
			{
				int remainingDropCount = collection4.remainingDropCount;
				if (num2 < remainingDropCount)
				{
					collection2 = collection4;
					break;
				}
				num2 -= remainingDropCount;
			}
		}
		Dictionary<string, ItemEntry> dictionary = collection2.remainingCommons;
		int count = collection2.remainingCommons.Count;
		int count2 = collection2.remainingRares.Count;
		num = count * 4 + count2;
		num2 = random.Next(num);
		if (num2 < count2)
		{
			dictionary = collection2.remainingRares;
		}
		ItemEntry itemEntry = null;
		num2 = random.Next(dictionary.Count);
		foreach (ItemEntry value in dictionary.Values)
		{
			if (num2-- <= 0)
			{
				itemEntry = value;
				break;
			}
		}
		if (itemEntry == null)
		{
			Debug.LogError("Couldn't find a valid cosmetic entry for collection " + collection2.collectionId);
			return null;
		}
		return MakeCosmeticAndAddToInventory(itemEntry, collection2);
	}

	public Cosmetic MakeCosmeticAndAddToInventory(ItemEntry chosenItemEntry, Collection chosenCollection)
	{
		Cosmetic cosmetic = InstantiateCosmeticItem(chosenItemEntry, chosenCollection);
		AddToInventory(cosmetic);
		string dictionaryKey = chosenItemEntry.GetDictionaryKey();
		for (int i = 0; i < chosenCollection.sets.Length; i++)
		{
			Set set = chosenCollection.sets[i];
			if (!set.ContainsRequirement(dictionaryKey))
			{
				continue;
			}
			SetUnlock setUnlock;
			if (activeUnlockDict.ContainsKey(set.rewardId))
			{
				setUnlock = activeUnlockDict[set.rewardId];
			}
			else
			{
				setUnlock = new SetUnlock(chosenCollection, set);
				activeUnlockDict.Add(set.rewardId, setUnlock);
				activeUnlocks.Add(setUnlock);
			}
			setUnlock.AddUnlock(chosenItemEntry);
			if (setUnlock.unlockReward)
			{
				Item prefabForId = ItemFactory.singleton.GetPrefabForId(setUnlock.rewardId);
				ItemEntry itemEntry = new ItemEntry(setUnlock.rewardId, prefabForId.element);
				string dictionaryKey2 = itemEntry.GetDictionaryKey();
				if (!chosenCollection.collectedItemsDict.ContainsKey(dictionaryKey2))
				{
					Cosmetic cosmetic2 = InstantiateCosmeticItem(itemEntry, chosenCollection);
					AddToInventory(cosmetic2);
					chosenCollection.collectedItems.Add(itemEntry);
					chosenCollection.collectedItemsDict.Add(dictionaryKey2, itemEntry);
					setUnlock.rewardName = cosmetic2.GetName();
				}
			}
			SequentialPopupManager.singleton.Enqueue(SequentialPopupManager.Mode.CosmeticSet);
		}
		MarkAsCollected(chosenItemEntry, chosenCollection);
		return cosmetic;
	}

	public void MarkAsCollected(ItemEntry chosenItemEntry, Collection chosenCollection)
	{
		string dictionaryKey = chosenItemEntry.GetDictionaryKey();
		if (!chosenCollection.collectedItemsDict.ContainsKey(dictionaryKey))
		{
			chosenCollection.collectedItems.Add(chosenItemEntry);
			chosenCollection.collectedItemsDict.Add(dictionaryKey, chosenItemEntry);
			chosenCollection.RemoveFromRemaining(chosenItemEntry);
		}
	}

	public void ClearProgress()
	{
		for (int i = 0; i < collections.Length; i++)
		{
			collections[i].ClearProgress();
		}
	}

	public void Parse(string sjson)
	{
		ClearProgress();
		if (sjson == null)
		{
			return;
		}
		List<string> list = null;
		string[] array = SlimJson.ParseArray(sjson, "extra");
		if (array != null)
		{
			list = new List<string>(array);
		}
		for (int i = 0; i < collections.Length; i++)
		{
			Collection collection = collections[i];
			ItemEntry[] array2 = SlimJson.ParseArray(sjson, collection.collectionId, ItemEntry.FromString);
			if (array2 != null)
			{
				collection.collectedItems.AddRange(array2);
			}
			for (int j = 0; j < collection.collectedItems.Count; j++)
			{
				ItemEntry itemEntry = collection.collectedItems[j];
				if (itemEntry.element == ItemData.Element.AEther && itemEntry.itemId == "skeleton_arm")
				{
					itemEntry.element = ItemData.Element.Stone;
				}
				collection.collectedItemsDict.Add(itemEntry.GetDictionaryKey(), itemEntry);
				Cosmetic cosmetic = InstantiateCosmeticItem(itemEntry, collection);
				collection.RemoveFromRemaining(itemEntry);
				AddToInventory(cosmetic);
				if (cosmetic.HasSerializationData() && list != null && list.Count > 0)
				{
					cosmetic.ParseMore(list[0]);
					list.RemoveAt(0);
				}
			}
		}
		List<Weapon> allWeapons = Inventory.Singleton.GetAllWeapons();
		for (int k = 0; k < allWeapons.Count; k++)
		{
			Weapon weapon = allWeapons[k];
			if (weapon != null && weapon.cosmeticId != null)
			{
				ItemEntry ownedCosmeticItemEntry = GetOwnedCosmeticItemEntry(weapon.cosmeticId, weapon.id, weapon.element);
				if (ownedCosmeticItemEntry != null)
				{
					ownedCosmeticItemEntry.appliedGroupId = weapon.GetGroupId();
					continue;
				}
				weapon.cosmeticId = null;
				weapon.cosmetic = null;
			}
		}
	}

	public Cosmetic InstantiateCosmeticItem(ItemEntry entry, Collection collection)
	{
		Cosmetic component = Utils.InstantiatePrefab(collection.prefabPath).GetComponent<Cosmetic>();
		component.cosmeticCollection = collection;
		component.targetItem = entry;
		component.hasInteracted = !component.targetItem.isNew;
		return component;
	}

	private void AddToInventory(Cosmetic cosmetic)
	{
		Inventory.Singleton.GetAllItems().Add(cosmetic);
		Inventory.Singleton.GetCosmetics().Add(cosmetic);
	}

	public string Serialize()
	{
		bool identationEnabled = SlimJson.identationEnabled;
		SlimJson.identationEnabled = false;
		SlimJson.BeginSerialization();
		for (int i = 0; i < collections.Length; i++)
		{
			Collection collection = collections[i];
			if (collection.collectedItems.Count > 0)
			{
				SlimJson.AddProperty(collection.collectionId, collection.collectedItems.ToArray());
			}
		}
		List<string> list = new List<string>();
		List<Cosmetic> cosmetics = Inventory.Singleton.GetCosmetics();
		for (int j = 0; j < cosmetics.Count; j++)
		{
			Cosmetic cosmetic = cosmetics[j];
			if (cosmetic.HasSerializationData())
			{
				SlimJson.BeginSerialization();
				cosmetic.SerializeMore();
				string item = SlimJson.EndSerialization();
				list.Add(item);
			}
		}
		if (list.Count > 0)
		{
			SlimJson.AddProperty("extra", list.ToArray());
		}
		string result = SlimJson.EndSerialization();
		SlimJson.identationEnabled = identationEnabled;
		return result;
	}

	private void Load()
	{
		collections = new Collection[collectionDefinitions.Length];
		for (int i = 0; i < collectionDefinitions.Length; i++)
		{
			Collection collection = new Collection(collectionDefinitions[i].text);
			collections[i] = collection;
			cosmeticPrefabs.Add(collection.collectionId, collection.cosmeticPrefab);
			ItemFactory.singleton.AddPrefab(collection.cosmeticPrefab, collection.prefabPath);
		}
	}

	private void Awake()
	{
		singleton = this;
		Load();
	}
}
