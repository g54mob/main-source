using System.Collections.Generic;
using UnityEngine;

public class ItemSpawnManager : CSingleton<ItemSpawnManager>
{
	public static ItemSpawnManager m_Instance;

	public Item m_ItemPrefab;

	public Transform m_ItemParentGrp;

	private int m_SpawnedItemCount;

	private List<Item> m_ItemList = new List<Item>();

	private void Start()
	{
		for (int i = 0; i < m_ItemParentGrp.childCount; i++)
		{
			m_ItemList.Add(m_ItemParentGrp.GetChild(i).gameObject.GetComponent<Item>());
		}
	}

	public static Item GetItem(Transform parent)
	{
		Item item = null;
		for (int i = 0; i < CSingleton<ItemSpawnManager>.Instance.m_ItemList.Count; i++)
		{
			if ((bool)CSingleton<ItemSpawnManager>.Instance.m_ItemList[i] && !CSingleton<ItemSpawnManager>.Instance.m_ItemList[i].gameObject.activeSelf && CSingleton<ItemSpawnManager>.Instance.m_ItemList[i].transform.parent == CSingleton<ItemSpawnManager>.Instance.m_ItemParentGrp)
			{
				item = CSingleton<ItemSpawnManager>.Instance.m_ItemList[i];
				break;
			}
		}
		if (!item)
		{
			item = CSingleton<ItemSpawnManager>.Instance.AddItemPrefab();
		}
		item.transform.parent = parent;
		return item;
	}

	public static void DisableItem(Item item)
	{
		item.transform.parent = CSingleton<ItemSpawnManager>.Instance.m_ItemParentGrp;
		item.transform.localPosition = Vector3.zero;
		item.transform.localRotation = Quaternion.identity;
		item.transform.localScale = Vector3.one;
		item.gameObject.SetActive(value: false);
		item.m_Mesh.enabled = true;
	}

	private Item AddItemPrefab()
	{
		Item item = Object.Instantiate(m_ItemPrefab, new Vector3(0f, 0f, 0f), Quaternion.identity, m_ItemParentGrp);
		item.name = "ItemGrp" + m_SpawnedItemCount;
		item.gameObject.SetActive(value: false);
		m_ItemList.Add(item);
		m_SpawnedItemCount++;
		return item;
	}
}
