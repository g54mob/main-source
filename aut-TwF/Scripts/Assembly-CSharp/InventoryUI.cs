using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
	[SerializeField]
	private InventoryElementUI inventoryElementUIPrefab;

	[SerializeField]
	private Transform container;

	[SerializeField]
	private Image inventoryBackground;

	[SerializeField]
	private int maxRows;

	private GridLayoutGroup gridLayout;

	private Dictionary<string, InventoryElementUI> inventoryElementUIs;

	private void Awake()
	{
		gridLayout = GetComponent<GridLayoutGroup>();
		inventoryElementUIs = new Dictionary<string, InventoryElementUI>();
		inventoryBackground.enabled = false;
	}

	private void OnEnable()
	{
		LTFunctionLibrary.GetPlayerInventory().onStoreObject += OnStoreObject;
		LTFunctionLibrary.GetPlayerInventory().onRemoveObject += OnRemoveObject;
		LTFunctionLibrary.GetPlayerInventory().StoredObjects.ForEach(delegate(Storage<ResourceData>.StoredObjectData o)
		{
			if (!o.obj.HideInInventory && !inventoryElementUIs.ContainsKey(o.id))
			{
				AddElement(o.obj);
			}
		});
		List<string> keys = new List<string>(inventoryElementUIs.Keys);
		int i;
		for (i = keys.Count - 1; i >= 0; i--)
		{
			if (!LTFunctionLibrary.GetPlayerInventory().StoredObjects.Any((Storage<ResourceData>.StoredObjectData item) => !item.obj.HideInInventory && item.id == keys[i]))
			{
				RemoveElement(keys[i]);
			}
			else
			{
				inventoryElementUIs[keys[i]].UpdateCostText();
			}
		}
		List<Storage<ResourceData>.StoredObjectData> list = new List<Storage<ResourceData>.StoredObjectData>();
		list = LTFunctionLibrary.GetPlayerInventory().StoredObjects.FindAll((Storage<ResourceData>.StoredObjectData storedObjectData) => !storedObjectData.obj.HideInInventory);
		foreach (InventoryElementUI element in inventoryElementUIs.Values)
		{
			element.transform.SetSiblingIndex(list.FindIndex((Storage<ResourceData>.StoredObjectData storedObject) => storedObject.id == (element.Data as ResourceData).Id) + 1);
		}
	}

	private void OnDisable()
	{
		LTFunctionLibrary.GetPlayerInventory().onStoreObject -= OnStoreObject;
		LTFunctionLibrary.GetPlayerInventory().onRemoveObject -= OnRemoveObject;
	}

	private void OnRemoveObject(Storage<ResourceData>.StoredObjectData removingObject, int removedAmount)
	{
		if (!removingObject.obj.HideInInventory)
		{
			if (removingObject.amount <= 0)
			{
				RemoveElement(removingObject.obj.Id);
			}
			else
			{
				inventoryElementUIs[removingObject.obj.Id].UpdateCostText();
			}
		}
	}

	private void OnStoreObject(Storage<ResourceData>.StoredObjectData storingObject, int storedAmount, string storeSourceID)
	{
		if (inventoryElementUIs.ContainsKey(storingObject.obj.Id))
		{
			inventoryElementUIs[storingObject.obj.Id].UpdateCostText();
		}
		else if (!storingObject.obj.HideInInventory)
		{
			AddElement(storingObject.obj);
		}
	}

	private void AddElement(ResourceData resourceData)
	{
		InventoryElementUI inventoryElementUI = Object.Instantiate(inventoryElementUIPrefab, container);
		inventoryElementUI.Data = resourceData;
		inventoryElementUIs.Add(resourceData.Id, inventoryElementUI);
		inventoryBackground.enabled = true;
		ResizeInventoryGrid();
	}

	private void RemoveElement(string key)
	{
		Object.Destroy(inventoryElementUIs[key].gameObject);
		inventoryElementUIs.Remove(key);
		if (inventoryElementUIs.Count == 0)
		{
			inventoryBackground.enabled = false;
		}
		ResizeInventoryGrid();
	}

	private void ResizeInventoryGrid()
	{
		gridLayout.constraintCount = Mathf.Min(inventoryElementUIs.Count, maxRows);
	}
}
