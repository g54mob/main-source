using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class InventoryContextMenu : MonoBehaviour, IPointerClickHandler, IEventSystemHandler
{
	public DialogProperties DestroyConfirmation;

	private InventoryIcon _inventoryItem;

	public void OnPointerClick(PointerEventData eventData)
	{
		_inventoryItem = GetComponent<InventoryIcon>();
		if (!(_inventoryItem == null))
		{
			switch (eventData.button)
			{
			case PointerEventData.InputButton.Right:
				RemoveItemConfirmation();
				break;
			case PointerEventData.InputButton.Left:
			case PointerEventData.InputButton.Middle:
				break;
			}
		}
	}

	private void RemoveItemConfirmation()
	{
		if (PopUpDialog.Instance.CanPopup)
		{
			PopUpDialog.Instance.DialogFeedbackEvent.AddListener(RemoveItem);
			PopUpDialog.Instance.TryOpenPopUpDialog(DestroyConfirmation);
		}
	}

	private void RemoveItem(bool confirmed)
	{
		PopUpDialog.Instance.DialogFeedbackEvent.RemoveListener(RemoveItem);
		if (!confirmed)
		{
			return;
		}
		throw new NotImplementedException();
	}
}
