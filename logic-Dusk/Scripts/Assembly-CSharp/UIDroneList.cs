using System;
using System.Collections.Generic;
using UnityEngine;

public class UIDroneList : MonoBehaviour, IUIList
{
	public GameObject itemPrefab;

	private UIDroneItem[] itemList;

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
		if (itemList != null)
		{
			int num = itemList.Length;
			for (int i = 0; i < num; i++)
			{
				itemList[i] = null;
			}
			itemList = null;
		}
		itemPrefab = null;
	}

	public void Refresh()
	{
		CurrentHighlightedIndex = -1;
		if (itemList != null && itemList.Length > 0)
		{
			int num = itemList.Length;
			for (int i = 0; i < num; i++)
			{
				UIDroneItem uIDroneItem = itemList[i];
				if (uIDroneItem != null)
				{
					GameObjectPool.Instance.PushObject(uIDroneItem.gameObject);
				}
			}
		}
		itemList = new UIDroneItem[GlobalSettings.GameState.ThePlayer.Drones.Count];
		List<IModification> modificationsForType = ModificationsHelper.GetModificationsForType(typeof(NonVisualDrone));
		IModification[] array = new IModification[modificationsForType.Count];
		modificationsForType.CopyTo(array);
		int num2 = 0;
		for (int j = 1; j < 8; j++)
		{
			int count = GlobalSettings.GameState.ThePlayer.Drones.Count;
			for (int k = 0; k < count; k++)
			{
				IDrone drone = GlobalSettings.GameState.ThePlayer.Drones[k];
				if (drone.DroneNumber == j)
				{
					GameObject gameObject = GameObjectPool.Instance.PopObject("DroneItem");
					itemList[num2] = gameObject.GetComponent<UIDroneItem>();
					itemList[num2].Init();
					itemList[num2].FillSlot(drone);
					itemList[num2].gameObject.SetActive(true);
					itemList[num2].SetActive();
					gameObject.transform.SetParent(ModificationUI.Instance.DroneList.transform);
					gameObject.transform.localScale = Vector3.one;
					int num3 = array.Length;
					for (int l = 0; l < num3; l++)
					{
						itemList[num2].AddModification(array[l].CopyModification());
					}
					itemList[num2].modsLabel.text = ModificationsHelper.GetUpgradeIndicators(drone.AppliedModifications);
					num2++;
				}
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
		UIDroneItem[] array = itemList;
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
		if (CurrentHighlightedIndex >= 0 && itemList[CurrentHighlightedIndex].Drone != null)
		{
			itemList[CurrentHighlightedIndex].Select();
			return itemList[CurrentHighlightedIndex];
		}
		return null;
	}

	public IUIItem GetHighlightedItem()
	{
		UIDroneItem[] array = itemList;
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
		UIDroneItem[] array = itemList;
		foreach (IUIItem iUIItem in array)
		{
			if (iUIItem.IsSelected)
			{
				return iUIItem;
			}
		}
		return null;
	}
}
