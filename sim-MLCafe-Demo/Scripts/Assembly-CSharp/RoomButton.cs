using System;
using MLCN_Localization;
using UnityEngine;
using UnityEngine.UI;

public class RoomButton : MonoBehaviour
{
	[SerializeField]
	private Button button;

	[SerializeField]
	private Image image;

	[SerializeField]
	private Color colorRoomUnlocked;

	[SerializeField]
	private Color colorRoomLocked;

	[SerializeField]
	private Color colorRoomDisabled;

	[SerializeField]
	private Vector2Int position;

	public bool unlocked;

	private Vector2Int[] neighbours;

	public Vector2Int GetPosition()
	{
		return position;
	}

	public Vector2Int[] GetNeighbourPositions()
	{
		return neighbours;
	}

	public void Init(Vector2Int position)
	{
		this.position = position;
		CalculateNeighbours();
	}

	public void AddRoom()
	{
		Action onConfirm = delegate
		{
			ShopBuilder.AddRoom(position);
			Unlock();
			WalletSystem.GetPlayerWallet().ForceRemoveAmount(CafeShopManager.GetRoomBuildCost());
			SoundManager.PlaySoundOnce("management_buy_roomextension");
		};
		if (ShopBuilder.GetAvailableExtensionsCount() > 0)
		{
			string additionalInfoPreLocalized = LocalizationManager.GetLocalizedString("com_cafeeditor_label_purchase_info_price", LocalizationDataTable.Tables.ComputerElements) + ": " + PopupMessageManager.GetHighlightBegin() + CafeShopManager.GetRoomBuildCost() + "<sprite=0>" + PopupMessageManager.GetHighlightEnd() + "\n \n" + LocalizationManager.GetLocalizedString("com_cafeeditor_label_purchase_info_upkeep", LocalizationDataTable.Tables.ComputerElements) + ": <color=red>" + CafeShopManager.GetRentUpkeep() + "<sprite=0> </color> -> <color=red>" + (CafeShopManager.GetRentUpkeep() + CafeShopManager.GetSingleRoomRent()) + "<sprite=0> </color>";
			PopupMessageManager.GetConfirmationPopUp().ShowComputerConfirmationPopUp("ui_popup_confirmation_msg_buyroomextension", onConfirm, null, "ui_popup_confirmation_confirm_confirm", "ui_popup_confirmation_cancle_cancle", additionalInfoPreLocalized);
		}
		else
		{
			Color defaultColor = image.color;
			image.color = Color.red;
			TweenerManager.TweenTimeAction("CantAddRoom", 0.2f, delegate
			{
				image.color = defaultColor;
			});
		}
	}

	public void UpdateLockState(bool isUnlocked, bool isNeighbour)
	{
		if (isUnlocked)
		{
			Unlock();
		}
		else if (isNeighbour)
		{
			Locked();
		}
		else
		{
			Disabled();
		}
	}

	private void Unlock()
	{
		image.color = colorRoomUnlocked;
		button.gameObject.SetActive(value: false);
		unlocked = true;
	}

	private void Locked()
	{
		image.color = colorRoomLocked;
		button.gameObject.SetActive(value: true);
	}

	private void Disabled()
	{
		image.color = colorRoomDisabled;
		button.gameObject.SetActive(value: false);
	}

	private void CalculateNeighbours()
	{
		neighbours = ShopBuilder.GetNeighbourPositions(position);
	}
}
