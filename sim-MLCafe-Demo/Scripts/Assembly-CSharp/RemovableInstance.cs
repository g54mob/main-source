using UnityEngine;
using UnityEngine.Events;

public class RemovableInstance : MonoBehaviour, IInteraction
{
	[SerializeField]
	private string ItemName;

	[SerializeField]
	private UnityEvent OnRemove = new UnityEvent();

	[SerializeField]
	private float scaledDown = 0.5f;

	[SerializeField]
	public bool onlyRemovableWhenCafeIsClosed;

	[SerializeField]
	private string hintTag = "Item_Interaction";

	private int itemId = -1;

	[SerializeField]
	private bool canRemove = true;

	private void Start()
	{
		if (InventorySystem.IsValidated())
		{
			if (GetComponent<ItemComponent>() == null)
			{
				Debug.Log(base.transform.name + " Has no ItemComponent!");
				return;
			}
			itemId = GetComponent<ItemComponent>().item.id;
			ItemName = InventorySystem.GetItemLibrary().itemInfos[itemId].GetLocalizedName();
			Activate();
		}
	}

	public int GetItemId()
	{
		return itemId;
	}

	public void OnPlayerAction(CharacterControllerComponent character)
	{
		if (!canRemove)
		{
			return;
		}
		HintBox hintBoxByTag = PopupMessageManager.GetPopHint().GetHintBoxByTag(hintTag);
		if (PopupMessageManager.GetPopHint().TryShow(hintBoxByTag))
		{
			return;
		}
		if (onlyRemovableWhenCafeIsClosed)
		{
			if (CafeShopManager.IsCafeOpen())
			{
				PopupMessageManager.GetInValidOrMissingPopUp().ShowMessageForSeconds(PopupMessageManager.GetInstance().popupLocalizationInvalidCafeNeedsToBeClosed);
				return;
			}
			if (CafeShopManager.CustomersInCafe())
			{
				PopupMessageManager.GetInValidOrMissingPopUp().ShowMessageForSeconds(PopupMessageManager.GetInstance().popupLocalizationInvalidCustomersNeedToLeave);
				return;
			}
		}
		if (!character.socket.IsHoldingItem() && !(GetComponent<ItemComponent>() == null))
		{
			OnRemove.Invoke();
			GetComponent<ItemComponent>().DeactivateCollision();
			if (GetComponent<ItemComponent>().soundOnPlacement != "")
			{
				SoundManager.PlaySoundOnce(GetComponent<ItemComponent>().soundOnTake);
			}
			else
			{
				SoundManager.PlaySoundOnce(PlacingSystem.GetDefaultSoundTake());
			}
			character.socket.PushItemWithScale(GetComponent<ItemComponent>(), scaledDown);
		}
	}

	public void Activate()
	{
		canRemove = true;
	}

	public void Deactivate()
	{
		canRemove = false;
	}
}
