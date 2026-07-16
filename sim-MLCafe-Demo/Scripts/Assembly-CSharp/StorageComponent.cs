using System.Linq;
using UnityEngine;

public class StorageComponent : MonoBehaviour
{
	[SerializeField]
	private ItemSocket[] sockets;

	[SerializeField]
	private bool useOnlyItemsOfType;

	[SerializeField]
	private ItemInfo.ItemType[] itemTypes;

	[SerializeField]
	private Item deliveryBoxItem;

	[SerializeField]
	private string soundPush;

	[SerializeField]
	private string soundPull;

	[SerializeField]
	private string localizationKeyInvalidStorageSpace;

	[SerializeField]
	private string localizationKeyInvalidItemType;

	private string hintTag = "Item_Packages";

	public void CheckSurfaceInteraction(CharacterControllerComponent character)
	{
		if (character.socket.IsHoldingItem() && character.socket.GetItemComponent().item.id == deliveryBoxItem.id)
		{
			OnInteraction(character);
		}
	}

	public void OnInteraction(CharacterControllerComponent character)
	{
		HintBox hintBoxByTag = PopupMessageManager.GetPopHint().GetHintBoxByTag(hintTag);
		if (PopupMessageManager.GetPopHint().TryShow(hintBoxByTag))
		{
			return;
		}
		if (character.socket.IsHoldingItem())
		{
			if (character.socket.GetItemComponent().item.id == deliveryBoxItem.id)
			{
				PushAndPullDeliveryBoxItems(character.socket);
			}
			else if (character.socket.GetItemComponent().GetComponent<SocketPackage>() != null)
			{
				PushAndPullSocketPackage(character, character.socket);
			}
			else
			{
				TryPushItem(character.socket);
			}
		}
		else if (sockets.Any((ItemSocket x) => x.IsHoldingItem()))
		{
			ItemSocket itemSocket = sockets.FirstOrDefault((ItemSocket x) => x.IsHoldingItem());
			character.socket.PushItem(itemSocket.GetItemComponent());
			itemSocket.DeactivateInteractionSocketCollider();
			itemSocket.Clear();
			SoundManager.PlaySoundOnce(soundPull);
		}
	}

	public bool HasItem(ItemComponent item)
	{
		return sockets.Any((ItemSocket x) => x.GetItemComponent() == item);
	}

	private bool IsFull()
	{
		return !sockets.Any((ItemSocket x) => !x.IsHoldingItem());
	}

	private bool IsEmpty()
	{
		return !sockets.Any((ItemSocket x) => x.IsHoldingItem());
	}

	private bool TryPushItem(ItemSocket socket, bool dontTriggerPopup = false)
	{
		if (!socket.IsHoldingItem())
		{
			return false;
		}
		if (!IsFull())
		{
			if (useOnlyItemsOfType)
			{
				if (!itemTypes.Any((ItemInfo.ItemType x) => x == socket.GetItemComponent().GetInfo().itemType))
				{
					if (!dontTriggerPopup && !PopupMessageManager.GetInValidOrMissingPopUp().IsVisible())
					{
						PopupMessageManager.GetInValidOrMissingPopUp().ShowMessageForSeconds(localizationKeyInvalidItemType);
					}
					return false;
				}
				if (socket.GetItemComponent().GetComponent<SocketPackage>() != null)
				{
					if (!dontTriggerPopup && !PopupMessageManager.GetInValidOrMissingPopUp().IsVisible())
					{
						PopupMessageManager.GetInValidOrMissingPopUp().ShowMessageForSeconds(localizationKeyInvalidItemType);
					}
					return false;
				}
			}
			ItemSocket itemSocket = sockets.ToList().First((ItemSocket x) => !x.IsHoldingItem());
			itemSocket.PushItem(socket.GetItemComponent());
			itemSocket.ActivateInteractionSocketCollider();
			return true;
		}
		if (!dontTriggerPopup)
		{
			PopupMessageManager.GetInValidOrMissingPopUp().ShowMessageForSeconds(localizationKeyInvalidStorageSpace);
		}
		return false;
	}

	private void PushAndPullDeliveryBoxItems(ItemSocket socket)
	{
		DeliveryPackage component = socket.GetItemComponent().GetComponent<DeliveryPackage>();
		if (component == null)
		{
			return;
		}
		if (component.IsEmpty())
		{
			SoundManager.PlaySoundOnce(soundPull);
			for (int i = 0; i < sockets.Length; i++)
			{
				if (IsEmpty())
				{
					break;
				}
				if (component.IsFull())
				{
					break;
				}
				component.GetEmptySocket().PushItem(sockets.First((ItemSocket x) => x.IsHoldingItem()).GetItemComponent());
			}
			return;
		}
		SoundManager.PlaySoundOnce(soundPush);
		for (int num = 0; num < component.GetPackageCapacity(); num++)
		{
			if (IsFull())
			{
				break;
			}
			if (component.IsEmpty())
			{
				break;
			}
			TryPushItem(component.GetSockets()[num], dontTriggerPopup: true);
		}
	}

	private void PushAndPullSocketPackage(CharacterControllerComponent character, ItemSocket socket)
	{
		SocketPackage component = socket.GetItemComponent().GetComponent<SocketPackage>();
		if (component == null)
		{
			return;
		}
		if (component.IsEmpty())
		{
			for (int i = 0; i < sockets.Length; i++)
			{
				if (IsEmpty() || component.IsFull())
				{
					return;
				}
				component.TryPushToPackage(character, sockets.First((ItemSocket x) => x.IsHoldingItem()).GetItemComponent());
			}
			SoundManager.PlaySoundOnce(soundPull);
			return;
		}
		for (int num = 0; num < component.GetSocketCount(); num++)
		{
			if (IsFull() || component.IsEmpty())
			{
				return;
			}
			TryPushItem(component.GetNextItem());
		}
		SoundManager.PlaySoundOnce(soundPush);
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
					Object.Destroy(itemSocket.transform.GetChild(j).gameObject);
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
