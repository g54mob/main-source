using System.Collections.Generic;
using UnityEngine;

public class ItemSOManager : MonoBehaviour
{
	private Dictionary<string, T_ItemSO> itemSODictionary = new Dictionary<string, T_ItemSO>();

	private bool isInitialized;

	public static ItemSOManager Instance { get; private set; }

	private IReadOnlyList<T_ItemSO> AllItemSOs => ScriptableListManager.Instance.AllItemSOs;

	private void Awake()
	{
		if (Instance == null)
		{
			Instance = this;
			InitializeDictionary();
		}
		else
		{
			Debug.LogWarning("[ItemSOManager] Birden fazla ItemSOManager bulundu! Yeni instance destroy ediliyor.");
			Object.Destroy(base.gameObject);
		}
	}

	private void InitializeDictionary()
	{
		if (isInitialized)
		{
			return;
		}
		itemSODictionary.Clear();
		IReadOnlyList<T_ItemSO> allItemSOs = AllItemSOs;
		Debug.Log($"[ItemSOManager] Dictionary başlatılıyor - ItemSO count: {allItemSOs.Count}");
		int num = 0;
		int num2 = 0;
		foreach (T_ItemSO item in allItemSOs)
		{
			if (item == null)
			{
				num2++;
				continue;
			}
			string itemID = item.GetItemID();
			if (string.IsNullOrEmpty(itemID))
			{
				Debug.LogWarning("[ItemSOManager] ItemSO'nun ItemID'si boş! Name: " + item.name);
				num2++;
			}
			else if (itemSODictionary.ContainsKey(itemID))
			{
				Debug.LogWarning("[ItemSOManager] Duplicate ItemID bulundu! ID: " + itemID + ", Existing: " + itemSODictionary[itemID].name + ", New: " + item.name);
				num2++;
			}
			else
			{
				itemSODictionary[itemID] = item;
				num++;
			}
		}
		Debug.Log($"[ItemSOManager] Dictionary başlatıldı - Valid: {num}, Invalid: {num2}, Total: {itemSODictionary.Count}");
		isInitialized = true;
	}

	public T_ItemSO GetItemSOById(string itemId)
	{
		if (!isInitialized)
		{
			InitializeDictionary();
		}
		if (string.IsNullOrEmpty(itemId))
		{
			Debug.LogWarning("[ItemSOManager] GetItemSOById - ItemID null/boş!");
			return null;
		}
		if (itemSODictionary.TryGetValue(itemId, out var value))
		{
			return value;
		}
		Debug.LogWarning("[ItemSOManager] ItemSO bulunamadı! ItemID: " + itemId);
		return null;
	}

	public List<T_ItemSO> GetAllItemSOs()
	{
		return new List<T_ItemSO>(AllItemSOs);
	}

	public void RefreshDictionary()
	{
		isInitialized = false;
		InitializeDictionary();
	}

	public void AddItemSOToCache(T_ItemSO itemSO)
	{
		if (itemSO == null)
		{
			Debug.LogWarning("[ItemSOManager] AddItemSOToCache - ItemSO null!");
			return;
		}
		string itemID = itemSO.GetItemID();
		if (!string.IsNullOrEmpty(itemID) && !itemSODictionary.ContainsKey(itemID))
		{
			itemSODictionary[itemID] = itemSO;
			Debug.Log("[ItemSOManager] ItemSO cache'e eklendi - Name: " + itemSO.name + ", ID: " + itemID);
		}
		else
		{
			Debug.LogWarning("[ItemSOManager] ItemSO cache'e eklenemedi! ID: " + itemID);
		}
	}

	public void RemoveItemSOFromCache(T_ItemSO itemSO)
	{
		if (!(itemSO == null))
		{
			string itemID = itemSO.GetItemID();
			if (!string.IsNullOrEmpty(itemID) && itemSODictionary.ContainsKey(itemID))
			{
				itemSODictionary.Remove(itemID);
				Debug.Log("[ItemSOManager] ItemSO cache'den kaldırıldı - Name: " + itemSO.name + ", ID: " + itemID);
			}
		}
	}

	[ContextMenu("Test - Give All Items (1 each)")]
	public void GiveAllItemsToPlayer()
	{
		if (!Application.isPlaying)
		{
			Debug.LogWarning("[ItemSOManager] Bu özellik sadece Play modunda çalışır!");
			return;
		}
		if (GameManager.Instance == null || GameManager.Instance.localBag == null)
		{
			Debug.LogWarning("[ItemSOManager] GameManager veya localBag bulunamadı!");
			return;
		}
		T_Bag localBag = GameManager.Instance.localBag;
		IReadOnlyList<T_ItemSO> allItemSOs = AllItemSOs;
		int num = 0;
		int num2 = 0;
		foreach (T_ItemSO item in allItemSOs)
		{
			if (!(item == null))
			{
				if (localBag.AddItem(item))
				{
					num++;
				}
				else
				{
					num2++;
				}
			}
		}
		Debug.Log($"[ItemSOManager] Test - {num} item eklendi, {num2} item eklenemedi (toplam {allItemSOs.Count} item)");
	}
}
