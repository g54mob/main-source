using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StorageBox : MonoBehaviour
{
	public Color defaultColor;

	public Color selectedColor;

	public Image rendererRef;

	public Image iconHolder;

	public GameObject counterObject;

	public TextMeshProUGUI counterText;

	private string containedName;

	private GameObject containedObject;

	private InventoryItem containedItem;

	private bool objectInQueue;

	private int numberOfContainedItems;

	private List<GameObject> allContainedItems = new List<GameObject>();

	private SaveableTaggedObjectNoDepth containedSavedObject;

	private int boxIndex;

	private bool storageBox = true;

	private CursorUpdateArea updateAreaRef;

	private StorageChestGUIController controllerRef;

	public void SetContainedItem(ObjectID objRef, int number, int index, bool inQueue)
	{
		boxIndex = index;
		containedObject = objRef.gameObject;
		containedSavedObject = null;
		containedItem = null;
		objectInQueue = inQueue;
		iconHolder.sprite = objRef.item.icon;
		containedName = objRef.item.itemNameLocalized;
		if (number == 1)
		{
			counterObject.SetActive(value: false);
		}
		else
		{
			counterObject.SetActive(value: true);
			counterText.text = number.ToString();
		}
		numberOfContainedItems = number;
	}

	public void SetContainedItem(SaveableTaggedObjectNoDepth itemRef, int number, int index, Sprite icon, string objName, bool inQueue)
	{
		boxIndex = index;
		containedItem = null;
		containedObject = null;
		containedSavedObject = itemRef;
		objectInQueue = inQueue;
		iconHolder.sprite = icon;
		containedName = objName;
		if (number == 1)
		{
			counterObject.SetActive(value: false);
		}
		else
		{
			counterObject.SetActive(value: true);
			counterText.text = number.ToString();
		}
		numberOfContainedItems = number;
	}

	public void SetContainedItem(InventoryItem itemRef, List<GameObject> allItems, int index, bool inQueue)
	{
		boxIndex = index;
		containedObject = null;
		containedSavedObject = null;
		containedItem = itemRef;
		objectInQueue = inQueue;
		allContainedItems.Clear();
		allContainedItems.AddRange(allItems);
		iconHolder.sprite = itemRef.icon;
		containedName = itemRef.itemNameLocalized;
		if (allContainedItems.Count == 1)
		{
			counterObject.SetActive(value: false);
		}
		else
		{
			counterObject.SetActive(value: true);
			counterText.text = allContainedItems.Count.ToString();
		}
		numberOfContainedItems = allContainedItems.Count;
	}

	public void SetContainedItem(InventoryItem itemRef, int count, int index, bool inQueue)
	{
		boxIndex = index;
		containedObject = null;
		containedSavedObject = null;
		containedItem = itemRef;
		objectInQueue = inQueue;
		iconHolder.sprite = itemRef.icon;
		containedName = itemRef.itemNameLocalized;
		if (count == 1)
		{
			counterObject.SetActive(value: false);
		}
		else
		{
			counterObject.SetActive(value: true);
			counterText.text = count.ToString();
		}
		numberOfContainedItems = count;
	}

	public void SetControllerRef(StorageChestGUIController newRef, CursorUpdateArea areaRef, bool isStorageBox)
	{
		controllerRef = newRef;
		updateAreaRef = areaRef;
		storageBox = isStorageBox;
	}

	public bool GetIsInQueue()
	{
		return objectInQueue;
	}

	public bool GetIsStorageBox()
	{
		return storageBox;
	}

	public int GetIndex()
	{
		return boxIndex;
	}

	public int GetNumberOfContainedItems()
	{
		return numberOfContainedItems;
	}

	public List<GameObject> GetAllContainedItems()
	{
		return allContainedItems;
	}

	public GameObject GetContainedObject()
	{
		return containedObject;
	}

	public Sprite GetContainedIcon()
	{
		return iconHolder.sprite;
	}

	public string GetContainedName()
	{
		return containedName;
	}

	public SaveableTaggedObjectNoDepth GetContainedSavedObject()
	{
		return containedSavedObject;
	}

	public InventoryItem GetContainedInventoryItem()
	{
		return containedItem;
	}

	public void OnClick()
	{
		controllerRef.SelectBox(this);
	}

	public void OnSelected()
	{
		rendererRef.color = selectedColor;
	}

	public void OnDeselected()
	{
		rendererRef.color = defaultColor;
	}

	public void OnCursorStay()
	{
		updateAreaRef.ReportCursorOverContent();
	}
}
