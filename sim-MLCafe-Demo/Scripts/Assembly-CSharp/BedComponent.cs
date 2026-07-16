using UnityEngine;

public class BedComponent : MonoBehaviour
{
	[SerializeField]
	private string localizationKeyInvalidCafeOpen;

	[SerializeField]
	private string localizationKeyInvalidHoldingItem;

	[SerializeField]
	private string hintTag;

	public void OnInteract(CharacterControllerComponent character)
	{
		HintBox hintBoxByTag = PopupMessageManager.GetPopHint().GetHintBoxByTag(hintTag);
		if (!PopupMessageManager.GetPopHint().TryShow(hintBoxByTag))
		{
			if (CafeShopManager.IsCafeOpen())
			{
				PopupMessageManager.GetInValidOrMissingPopUp().ShowMessageForSeconds(localizationKeyInvalidCafeOpen, 2f);
			}
			else if (character.socket.IsHoldingItem())
			{
				PopupMessageManager.GetInValidOrMissingPopUp().ShowMessageForSeconds(localizationKeyInvalidHoldingItem, 2f);
			}
			else
			{
				PopupMessageManager.GetConfirmationPopUp().ShowConfirmationPopup("ui_popup_confirmation_msg_gotosleep", GoToSleep, null, "ui_popup_confirmation_confirm_sleep");
			}
		}
	}

	private void GoToSleep()
	{
		TransitionManager.TriggerState("LevelSummary");
	}
}
