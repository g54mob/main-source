using System;
using System.Collections.Generic;
using UnityEngine;

public class UIShipList : MonoBehaviour, IUIList
{
	public GameObject itemPrefab;

	private UIShipItem[] itemList;

	public GameObject UnderlyingGameObject
	{
		get
		{
			return base.gameObject;
		}
	}

	public int ItemCount
	{
		get
		{
			if (itemList != null)
			{
				return itemList.Length;
			}
			return 0;
		}
	}

	public int CurrentPageIndex
	{
		get
		{
			return 0;
		}
	}

	public int CurrentHighlightedIndex { get; private set; }

	private void OnDestroy()
	{
		itemPrefab = null;
		if (itemList != null)
		{
			int num = itemList.Length;
			for (int i = 0; i < num; i++)
			{
				itemList[i] = null;
			}
			itemList = null;
		}
	}

	public void Refresh()
	{
		CurrentHighlightedIndex = -1;
		if (itemList != null && itemList.Length > 0)
		{
			int num = itemList.Length;
			for (int i = 0; i < num; i++)
			{
				UIShipItem uIShipItem = itemList[i];
				if (uIShipItem != null)
				{
					UnityEngine.Object.Destroy(uIShipItem.gameObject);
				}
			}
		}
		if (GlobalSettings.GameState.ThePlayer.MyShip.slotList != null && GlobalSettings.GameState.ThePlayer.MyShip.slotList.Count > 0)
		{
			itemList = new UIShipItem[2];
			GameObject gameObject = UnityEngine.Object.Instantiate(itemPrefab);
			itemList[0] = gameObject.GetComponent<UIShipItem>();
			itemList[0].descriptionLabel.text = "Repair ship upgrade slot";
			itemList[0] = gameObject.GetComponent<UIShipItem>();
			itemList[0].gameObject.SetActive(true);
			itemList[0].SetActive();
			gameObject.transform.SetParent(ModificationUI.Instance.ShipList.transform);
			gameObject.transform.localScale = Vector3.one;
			gameObject = UnityEngine.Object.Instantiate(itemPrefab);
			itemList[1] = gameObject.GetComponent<UIShipItem>();
			itemList[1].descriptionLabel.text = "Repair ship schematic view";
			itemList[1] = gameObject.GetComponent<UIShipItem>();
			itemList[1].gameObject.SetActive(true);
			itemList[1].SetActive();
			gameObject.transform.SetParent(ModificationUI.Instance.ShipList.transform);
			gameObject.transform.localScale = Vector3.one;
			List<IModification> modificationsForType = ModificationsHelper.GetModificationsForType(typeof(SlotInfo));
			IModification[] array = new IModification[modificationsForType.Count];
			modificationsForType.CopyTo(array);
			int num2 = array.Length;
			for (int j = 0; j < num2; j++)
			{
				itemList[0].AddModification(array[j].CopyModification());
			}
			modificationsForType = ModificationsHelper.GetModificationsForType(typeof(DungeonInfo));
			array = new IModification[modificationsForType.Count];
			modificationsForType.CopyTo(array);
			num2 = array.Length;
			for (int k = 0; k < num2; k++)
			{
				itemList[1].AddModification(array[k].CopyModification());
			}
		}
		else
		{
			itemList = new UIShipItem[1];
			GameObject gameObject2 = UnityEngine.Object.Instantiate(itemPrefab);
			itemList[0] = gameObject2.GetComponent<UIShipItem>();
			itemList[0].descriptionLabel.text = "Repair ship schematic view";
			itemList[0] = gameObject2.GetComponent<UIShipItem>();
			itemList[0].gameObject.SetActive(true);
			itemList[0].SetActive();
			gameObject2.transform.SetParent(ModificationUI.Instance.ShipList.transform);
			gameObject2.transform.localScale = Vector3.one;
			List<IModification> modificationsForType2 = ModificationsHelper.GetModificationsForType(typeof(DungeonInfo));
			IModification[] array2 = new IModification[modificationsForType2.Count];
			modificationsForType2.CopyTo(array2);
			int num3 = array2.Length;
			for (int l = 0; l < num3; l++)
			{
				itemList[0].AddModification(array2[l].CopyModification());
			}
		}
	}

	public bool PageForward()
	{
		return true;
	}

	public bool PageBack()
	{
		return true;
	}

	public void Show(int pageIdx)
	{
	}

	public void GotFocus()
	{
		if (CurrentHighlightedIndex == -1 && itemList.Length > 0)
		{
			CurrentHighlightedIndex = 0;
		}
		if (CurrentHighlightedIndex != -1)
		{
			itemList[CurrentHighlightedIndex].Highlight();
		}
	}

	public void LoseFocus()
	{
		if (itemList != null && itemList.Length > 0 && CurrentHighlightedIndex != -1)
		{
			itemList[CurrentHighlightedIndex].ClearHighlight();
		}
	}

	public bool MoveDown()
	{
		if (itemList != null && itemList.Length > 0)
		{
			itemList[CurrentHighlightedIndex].ClearHighlight();
			CurrentHighlightedIndex += 1;
			if (CurrentHighlightedIndex >= itemList.Length)
			{
				return true;
			}
			itemList[CurrentHighlightedIndex].Highlight();
			return false;
		}
		return true;
	}

	public bool MoveUp()
	{
		if (itemList != null && itemList.Length > 0)
		{
			itemList[CurrentHighlightedIndex].ClearHighlight();
			CurrentHighlightedIndex -= 1;
			if (CurrentHighlightedIndex < 0)
			{
				return true;
			}
			itemList[CurrentHighlightedIndex].Highlight();
			return false;
		}
		return true;
	}

	public bool MoveToBottom()
	{
		if (itemList != null && itemList.Length > 0)
		{
			CurrentHighlightedIndex = itemList.Length - 1;
			itemList[CurrentHighlightedIndex].Highlight();
			return false;
		}
		return true;
	}

	public bool MoveToTop()
	{
		if (itemList != null && itemList.Length > 0)
		{
			CurrentHighlightedIndex = 0;
			itemList[CurrentHighlightedIndex].Highlight();
			return false;
		}
		return true;
	}

	public void MoveToTopOrSelected()
	{
		IUIItem selectedItem = GetSelectedItem();
		if (selectedItem == null)
		{
			MoveToTop();
			return;
		}
		CurrentHighlightedIndex = 0;
		UIShipItem[] array = itemList;
		foreach (IUIItem iUIItem in array)
		{
			if (iUIItem.IsSelected)
			{
				break;
			}
			CurrentHighlightedIndex += 1;
		}
		selectedItem.Highlight();
	}

	public bool DeleteHighlightedItem()
	{
		throw new NotImplementedException();
	}

	public void DeleteAllItems()
	{
		if (itemList != null)
		{
			int num = itemList.Length;
			for (int num2 = num - 1; num2 >= 0; num2--)
			{
				UnityEngine.Object.Destroy(itemList[num2].UnderlyingGameObject);
			}
			itemList = null;
		}
	}

	public bool RemoveBackendSelectedItem()
	{
		return false;
	}

	public void AddBackendItem(IUIItem item)
	{
	}

	public IUIItem SelectHighlightedItem()
	{
		if (CurrentHighlightedIndex >= 0)
		{
			itemList[CurrentHighlightedIndex].Select();
			return itemList[CurrentHighlightedIndex];
		}
		return null;
	}

	public IUIItem GetHighlightedItem()
	{
		UIShipItem[] array = itemList;
		foreach (IUIItem iUIItem in array)
		{
			if (iUIItem.IsHighlighted)
			{
				return iUIItem;
			}
		}
		return null;
	}

	public IUIItem GetSelectedItem()
	{
		if (itemList != null)
		{
			UIShipItem[] array = itemList;
			foreach (IUIItem iUIItem in array)
			{
				if (iUIItem.IsSelected)
				{
					return iUIItem;
				}
			}
		}
		return null;
	}
}
