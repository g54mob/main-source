using System;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

public class ItemSocket : MonoBehaviour, IInteraction
{
	[SerializeField]
	private bool onlySpecificItem;

	[SerializeField]
	public Item onlyItem;

	[SerializeField]
	public Item[] excludeItems;

	[SerializeField]
	private bool onlySpecificItemType;

	[SerializeField]
	public ItemInfo.ItemType filterItemType;

	[SerializeField]
	private bool useOnlyItemsOfType;

	[SerializeField]
	public ItemInfo.ItemType[] itemsOfType;

	[SerializeField]
	public bool useItemPreview;

	private ItemComponent holdingItem;

	[Header("Stock Existing Object")]
	[SerializeField]
	public bool useExistingObject;

	[SerializeField]
	private bool startWithItemInChilden;

	[SerializeField]
	private bool alwaysActive;

	[SerializeField]
	public GameObject itemObject;

	[SerializeField]
	private bool usePreferedSocketRotation;

	[SerializeField]
	private Vector3 socketRotation;

	[Header("Animate On Socket")]
	[SerializeField]
	private bool useBlendShape;

	[SerializeField]
	private SocketBlendShape socketBlendShape;

	[Header("Collision Handle")]
	[SerializeField]
	public bool useSocketInteraction;

	[SerializeField]
	public bool colliderStayEnabled;

	[SerializeField]
	public bool redirectInteractionCallOnPackageType;

	[SerializeField]
	private UnityEvent<CharacterControllerComponent> OnRedirectedInteractionCall = new UnityEvent<CharacterControllerComponent>();

	public bool isLoadingObjects;

	private void Start()
	{
		if (startWithItemInChilden && !isLoadingObjects)
		{
			ItemComponent componentInChildren = GetComponentInChildren<ItemComponent>();
			componentInChildren.socket = this;
			holdingItem = componentInChildren;
		}
		if (useExistingObject && !isLoadingObjects)
		{
			holdingItem = itemObject.GetComponent<ItemComponent>();
			if (!alwaysActive)
			{
				itemObject.SetActive(value: false);
			}
		}
		if (useSocketInteraction)
		{
			if (holdingItem != null)
			{
				ActivateInteractionSocketCollider();
			}
			else
			{
				DeactivateInteractionSocketCollider();
			}
		}
	}

	private void OnDrawGizmos()
	{
		Gizmos.DrawWireSphere(base.transform.position, 0.1f);
	}

	void IInteraction.OnPlayerInteraction(CharacterControllerComponent character)
	{
		if (!useSocketInteraction)
		{
			return;
		}
		if (redirectInteractionCallOnPackageType && character.socket.IsHoldingItem() && character.socket.GetItemComponent() != null && (bool)character.socket.GetItemComponent().GetComponent<SocketPackage>())
		{
			OnRedirectedInteractionCall.Invoke(character);
		}
		else if (character.socket.IsHoldingItem())
		{
			if (IsHoldingItem())
			{
				return;
			}
			if (!CheckReceivingItem(character.socket.holdingItem))
			{
				PopupMessageManager.GetInValidOrMissingPopUp().ShowMessageForSeconds(PopupMessageManager.GetInstance().popupLocalizationInvalidItem, 2f);
				return;
			}
			if (character.socket.GetItemComponent() != null)
			{
				SoundManager.PlaySoundOnce(character.socket.GetItemComponent().soundOnPlacement);
			}
			PushItem(character.socket.GetItemComponent());
			ActivateInteractionSocketCollider();
		}
		else if (holdingItem != null)
		{
			SoundManager.PlaySoundOnce(holdingItem.soundOnTake);
			character.socket.PushItem(holdingItem);
			DeactivateInteractionSocketCollider();
		}
	}

	public void OnInteraction(CharacterControllerComponent character)
	{
		if (GetComponent<InteractableComponent>().InRange(character.transform.position))
		{
			SwapItems(character.socket);
		}
	}

	public ItemComponent GetItemComponent()
	{
		return holdingItem;
	}

	public bool IsHoldingItem()
	{
		if (holdingItem == null)
		{
			ItemComponent componentInChildren = GetComponentInChildren<ItemComponent>();
			if (componentInChildren == null)
			{
				return false;
			}
			holdingItem = componentInChildren;
		}
		return holdingItem != null;
	}

	public ItemInfo GetRequiredItemInfo()
	{
		return InventorySystem.GetItemLibrary().itemInfos[onlyItem.id];
	}

	public Vector3 GetPreferedRotation()
	{
		return socketRotation;
	}

	public bool IsUsingTypeFilter()
	{
		return onlySpecificItemType;
	}

	public bool IsUsingItemFilter()
	{
		return onlySpecificItem;
	}

	public bool IsItemInExclusionList(int id)
	{
		return excludeItems.Any((Item x) => x.id == id);
	}

	public bool IsTool(Item tool)
	{
		if (IsHoldingItem())
		{
			return tool.id == holdingItem.item.id;
		}
		return false;
	}

	public void Clear()
	{
		if (!(holdingItem == null))
		{
			if (holdingItem.socket != null)
			{
				holdingItem.socket = null;
			}
			holdingItem = null;
		}
	}

	public void PushItem(ItemComponent item, Vector3 preferedEuler = default(Vector3), bool reactivateCollision = false, float customPushDuration = 0f)
	{
		holdingItem = item;
		if (holdingItem.socket != null)
		{
			holdingItem.socket.Clear();
		}
		holdingItem.socket = this;
		if (reactivateCollision)
		{
			holdingItem.DelayedAtivateCollision(0.1f);
		}
		TweenerManager.TweenWithScale("PushItemForce", holdingItem.transform, holdingItem.transform, base.transform, 1f, (customPushDuration == 0f) ? TweenerManager.GetDefaultDuration() : customPushDuration, TweenerManager.GetDefaultEaseCurve(), usePreferedSocketRotation ? socketRotation : preferedEuler);
		holdingItem.transform.parent = base.transform;
	}

	public void SetItemToSocket(ItemComponent item, Vector3 preferedEuler = default(Vector3), bool reactivateCollision = false)
	{
		Clear();
		if (itemObject != null)
		{
			UnityEngine.Object.Destroy(itemObject);
		}
		if (item == null)
		{
			Debug.LogError("Set ItemComponent to Socket is Null!");
			return;
		}
		holdingItem = item;
		holdingItem.socket = this;
		if (reactivateCollision)
		{
			holdingItem.DelayedAtivateCollision(0.1f);
		}
		holdingItem.transform.position = base.transform.position;
		holdingItem.transform.localScale = base.transform.localScale;
		Vector3 euler = (usePreferedSocketRotation ? socketRotation : preferedEuler);
		base.transform.localRotation = Quaternion.Euler(euler);
		holdingItem.transform.rotation = base.transform.rotation;
		holdingItem.transform.parent = base.transform;
	}

	public bool FillSkinnedItem(ItemComponent item, Vector3 preferedEuler = default(Vector3), bool reactivateCollision = false)
	{
		if (item.useLimitedAmount)
		{
			if (item.IsEmpty())
			{
				return false;
			}
			item.Consume();
		}
		else
		{
			holdingItem = item;
			holdingItem.socket = this;
			holdingItem.transform.parent = base.transform;
			item.DestoryItem();
		}
		if (!alwaysActive)
		{
			itemObject.SetActive(value: true);
		}
		if (!useBlendShape)
		{
			return true;
		}
		TweenerManager.TweenBlendShape("AnimateSocketItem", itemObject.GetComponent<SkinnedMeshRenderer>(), socketBlendShape.blendShape, socketBlendShape.blendShapeWeightStart, socketBlendShape.blendShapeWeightEnd, 0.5f, TweenerManager.GetDefaultEaseCurve(), null);
		return true;
	}

	public void UnfillSkinnedItem()
	{
		TweenerManager.TweenBlendShape("AnimateSocketItem", itemObject.GetComponent<SkinnedMeshRenderer>(), socketBlendShape.blendShape, socketBlendShape.blendShapeWeightEnd, socketBlendShape.blendShapeWeightStart, 0.1f, TweenerManager.GetDefaultEaseCurve(), null);
	}

	public void PushSkinnedItem(ItemComponent item, SkinnedMeshRenderer skinnedMesh, Vector3 preferedEuler = default(Vector3), bool reactivateCollision = false)
	{
		holdingItem = item;
		if (holdingItem.socket != null)
		{
			holdingItem.socket.Clear();
		}
		holdingItem.socket = this;
		holdingItem.transform.parent = base.transform;
		if (reactivateCollision)
		{
			holdingItem.DelayedAtivateCollision(0.1f);
		}
		Action action = delegate
		{
			if (useBlendShape)
			{
				TweenerManager.TweenBlendShape("AnimateSocketItem", skinnedMesh, socketBlendShape.blendShape, socketBlendShape.blendShapeWeightStart, socketBlendShape.blendShapeWeightEnd, 0.5f, TweenerManager.GetDefaultEaseCurve(), null);
			}
		};
		TweenerManager.TweenTimeAction("WaitForPush", 0.3f, action);
		TweenerManager.TweenWithScale("PushItemForce", holdingItem.transform, holdingItem.transform, base.transform, 1f, TweenerManager.GetDefaultDuration(), TweenerManager.GetDefaultEaseCurve(), usePreferedSocketRotation ? socketRotation : preferedEuler);
	}

	public void PushItemWithScale(ItemComponent item, float scale, Vector3 preferedEuler = default(Vector3), bool reactivateCollision = false)
	{
		holdingItem = item;
		if (holdingItem.socket != null)
		{
			holdingItem.socket.Clear();
		}
		holdingItem.socket = this;
		holdingItem.transform.parent = base.transform;
		item.DeactivateCollision();
		if (reactivateCollision)
		{
			holdingItem.DelayedAtivateCollision(0.1f);
		}
		TweenerManager.TweenWithScale("PushItemForce", holdingItem.transform, holdingItem.transform, base.transform, scale, TweenerManager.GetDefaultDuration(), TweenerManager.GetDefaultEaseCurve(), usePreferedSocketRotation ? socketRotation : preferedEuler);
	}

	public void PlaceItem(Transform parent, Transform target, Action onFinishedPush = null)
	{
		if (!(holdingItem == null))
		{
			holdingItem.transform.parent = parent;
			holdingItem.DelayedAtivateCollision(0.1f);
			TweenerManager.TweenWithScale("PlaceItemForce", holdingItem.transform, holdingItem.transform, target, 1f, TweenerManager.GetDefaultDuration(), TweenerManager.GetDefaultEaseCurve());
			if (onFinishedPush != null)
			{
				TweenerManager.TweenTimeAction("WaitForPush", 1f, onFinishedPush);
			}
			if (holdingItem.socket == null)
			{
				Clear();
			}
			else
			{
				holdingItem.socket.Clear();
			}
		}
	}

	public void SwapItems(ItemComponent item, Transform parent, Transform target, float scale = 1f, Vector3 prefferedRotation = default(Vector3), Action onFinishedSwap = null)
	{
		GameObject temp = new GameObject("TempTransform");
		temp.transform.parent = parent;
		temp.transform.position = target.position;
		temp.transform.rotation = target.rotation;
		Action action = delegate
		{
			PlaceItem(parent, temp.transform);
		};
		Action action2 = delegate
		{
			PushItemWithScale(item, scale, prefferedRotation);
		};
		Action action3 = delegate
		{
			UnityEngine.Object.Destroy(temp);
			if (onFinishedSwap != null)
			{
				onFinishedSwap();
			}
		};
		action();
		action2();
		TweenerManager.TweenTimeAction("CleanupSwap", TweenerManager.GetDefaultDuration() * 2f, action3);
	}

	public void SwapItems(ItemSocket socket, Action onFinishedSwap = null)
	{
		if (holdingItem == null && socket.holdingItem != null)
		{
			if (CheckReceivingItem(socket.holdingItem))
			{
				holdingItem = socket.holdingItem;
				socket.holdingItem = null;
				holdingItem.socket = this;
				holdingItem.transform.parent = base.transform;
				TweenerManager.Tween("TakeItemFrom", holdingItem.transform, socket.transform, base.transform, TweenerManager.GetDefaultDuration(), TweenerManager.GetDefaultEaseCurve(), onFinishedSwap);
			}
		}
		else if (holdingItem != null && socket.holdingItem == null)
		{
			socket.holdingItem = holdingItem;
			holdingItem = null;
			socket.holdingItem.socket = socket;
			socket.holdingItem.transform.parent = socket.transform;
			TweenerManager.Tween("PushItemTo", socket.holdingItem.transform, base.transform, socket.transform, TweenerManager.GetDefaultDuration(), TweenerManager.GetDefaultEaseCurve(), onFinishedSwap);
		}
		else if (holdingItem != null && socket.holdingItem != null && CheckReceivingItem(socket.holdingItem))
		{
			ItemComponent itemComponent = holdingItem;
			holdingItem = socket.holdingItem;
			socket.holdingItem = itemComponent;
			holdingItem.socket = this;
			socket.holdingItem.socket = socket;
			holdingItem.transform.parent = base.transform;
			socket.holdingItem.transform.parent = socket.transform;
			TweenerManager.Tween("ItemOne", holdingItem.transform, socket.transform, base.transform, TweenerManager.GetDefaultDuration(), TweenerManager.GetDefaultEaseCurve(), onFinishedSwap);
			TweenerManager.Tween("ItemTwo", socket.holdingItem.transform, base.transform, socket.transform, TweenerManager.GetDefaultDuration(), TweenerManager.GetDefaultEaseCurve(), onFinishedSwap);
		}
	}

	public bool CheckReceivingItem(ItemComponent itemInstance)
	{
		if (onlySpecificItem)
		{
			return itemInstance.item.id == onlyItem.id;
		}
		if (onlySpecificItemType)
		{
			return filterItemType == itemInstance.GetInfo().itemType;
		}
		if (useOnlyItemsOfType)
		{
			return itemsOfType.Any((ItemInfo.ItemType x) => x == itemInstance.GetInfo().itemType);
		}
		return true;
	}

	public bool CheckReceivingItemId(int itemId)
	{
		if (onlySpecificItem)
		{
			return itemId == onlyItem.id;
		}
		if (onlySpecificItemType)
		{
			return filterItemType == InventorySystem.GetItemLibrary().itemInfos[itemId].itemType;
		}
		if (useOnlyItemsOfType)
		{
			return itemsOfType.Any((ItemInfo.ItemType x) => x == InventorySystem.GetItemLibrary().itemInfos[itemId].itemType);
		}
		return true;
	}

	public void ActivateInteractionSocketCollider()
	{
		if (!(GetComponent<Collider>() == null))
		{
			GetComponent<Collider>().enabled = true;
		}
	}

	public void DeactivateInteractionSocketCollider()
	{
		if (!(GetComponent<Collider>() == null) && !colliderStayEnabled)
		{
			GetComponent<Collider>().enabled = false;
		}
	}
}
