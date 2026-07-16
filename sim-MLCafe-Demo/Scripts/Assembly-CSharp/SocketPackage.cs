using System;
using System.Linq;
using UnityEngine;

public class SocketPackage : MonoBehaviour
{
	[SerializeField]
	private ItemSocket[] sockets;

	[SerializeField]
	private bool reverseList;

	[SerializeField]
	private string localizationKeyInvalidItem;

	[SerializeField]
	private string localizationKeyPackageIsFull;

	private string hintTag = "Item_Packages";

	private void Start()
	{
		if (reverseList)
		{
			Array.Reverse(sockets);
		}
	}

	public void OnInteraction(CharacterControllerComponent character)
	{
		HintBox hintBoxByTag = PopupMessageManager.GetPopHint().GetHintBoxByTag(hintTag);
		if (PopupMessageManager.GetPopHint().TryShow(hintBoxByTag))
		{
			return;
		}
		if (character.socket.IsHoldingItem() && sockets[0].IsUsingItemFilter() && character.socket.GetItemComponent().item.id != sockets[0].onlyItem.id)
		{
			PopupMessageManager.GetInValidOrMissingPopUp().ShowMessageForSeconds(localizationKeyInvalidItem);
		}
		else if (character.socket.IsHoldingItem() && sockets[0].IsUsingTypeFilter() && character.socket.GetItemComponent().GetInfo().itemType != sockets[0].filterItemType)
		{
			PopupMessageManager.GetInValidOrMissingPopUp().ShowMessageForSeconds(localizationKeyInvalidItem);
		}
		else if (!TryPushToPackage(character, character.socket.GetItemComponent()))
		{
			ItemSocket nextItem = GetNextItem();
			if (!(nextItem == null))
			{
				character.socket.PushItem(nextItem.GetItemComponent());
			}
		}
	}

	public bool IsEmpty()
	{
		return !sockets.Any((ItemSocket socket) => socket.IsHoldingItem());
	}

	public bool IsFull()
	{
		bool result = true;
		for (int i = 0; i < sockets.Length; i++)
		{
			if (!sockets[i].IsHoldingItem())
			{
				result = false;
				break;
			}
		}
		return result;
	}

	public ItemSocket GetFreeSocket()
	{
		return sockets.FirstOrDefault((ItemSocket x) => !x.IsHoldingItem());
	}

	public ItemSocket GetNextItem()
	{
		return sockets.FirstOrDefault((ItemSocket x) => x.IsHoldingItem());
	}

	public int GetSocketCount()
	{
		return sockets.Length;
	}

	public ItemSocket GetSocket(int index)
	{
		return sockets[index];
	}

	public bool TryPushToPackage(CharacterControllerComponent character, ItemComponent targetItem = null)
	{
		if (character.socket.IsHoldingItem())
		{
			if (sockets.First().IsUsingItemFilter() && targetItem != null && targetItem.item.id != sockets.FirstOrDefault().onlyItem.id)
			{
				PopupMessageManager.GetInValidOrMissingPopUp().ShowMessageForSeconds(localizationKeyInvalidItem);
				return false;
			}
			if (sockets.First().IsUsingTypeFilter() && targetItem != null && targetItem.GetInfo().itemType != sockets.FirstOrDefault().filterItemType)
			{
				PopupMessageManager.GetInValidOrMissingPopUp().ShowMessageForSeconds(localizationKeyInvalidItem);
				return false;
			}
			ItemSocket freeSocket = GetFreeSocket();
			if (freeSocket == null)
			{
				PopupMessageManager.GetInValidOrMissingPopUp().ShowMessageForSeconds(localizationKeyPackageIsFull);
				return false;
			}
			freeSocket.PushItem(targetItem);
			return true;
		}
		return false;
	}

	public int ItemsInBox()
	{
		return sockets.ToList().FindAll((ItemSocket x) => x.IsHoldingItem()).Count;
	}

	public int GetIndexOfChild(SaveableInstance child)
	{
		return sockets.ToList().FindIndex((ItemSocket x) => (x.GetItemComponent() != null && x.GetItemComponent().GetComponent<SaveableInstance>() != null && x.GetItemComponent().GetComponent<SaveableInstance>().GetSaveData()
			.id == child.GetSaveData().id) || (x.transform.childCount > 0 && x.transform.GetComponentInChildren<SaveableInstance>() != null && x.transform.GetComponentInChildren<SaveableInstance>().GetSaveData().id == child.GetSaveData().id));
	}

	public void LoadClear()
	{
		ItemSocket[] array = sockets;
		foreach (ItemSocket itemSocket in array)
		{
			if (itemSocket.transform.childCount > 0)
			{
				for (int j = 0; j < itemSocket.transform.childCount; j++)
				{
					UnityEngine.Object.Destroy(itemSocket.transform.GetChild(j).gameObject);
				}
			}
			itemSocket.Clear();
		}
	}

	public void LoadPushItem(ItemComponent item, int preferedSocket = -1)
	{
		if (preferedSocket == -1)
		{
			ItemSocket itemSocket = sockets.First((ItemSocket x) => !x.IsHoldingItem());
			itemSocket.isLoadingObjects = true;
			itemSocket.SetItemToSocket(item);
		}
		else
		{
			sockets[preferedSocket].isLoadingObjects = true;
			sockets[preferedSocket].SetItemToSocket(item);
		}
	}
}
