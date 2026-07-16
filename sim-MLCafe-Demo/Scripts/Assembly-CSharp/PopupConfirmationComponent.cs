using System;
using MLCN_Localization;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class PopupConfirmationComponent : MonoBehaviour
{
	[SerializeField]
	private GameObject content;

	[SerializeField]
	private TMP_Text labelMessage;

	[SerializeField]
	private ButtonField buttonConfirm;

	[SerializeField]
	private ButtonField buttonCancel;

	[SerializeField]
	private ButtonField buttonOk;

	[SerializeField]
	private TMP_Text labelAdditionalInfo;

	[SerializeField]
	private GraphicRaycaster graphicRaycaster;

	[SerializeField]
	private UIContentAnimator animator;

	private bool isVisible;

	private void Start()
	{
		animator.BeginWithTargetState();
		ResetLabels();
		InputManager.OnCancelMenuWindow.AddListener(delegate
		{
			Hide();
		});
		animator.OnFinishedPlay.AddListener(delegate
		{
			content.SetActive(value: false);
		});
		content.SetActive(value: false);
	}

	public bool IsVisible()
	{
		return isVisible;
	}

	public void ShowComputerConfirmationPopUp(string msgKey, Action onConfirm, Action onCancel, string labelConfirmKey = "ui_popup_confirmation_confirm_confirm", string labelCancelKey = "ui_popup_confirmation_cancle_cancle", string additionalInfoPreLocalized = "")
	{
		string localizedString = LocalizationManager.GetLocalizedString(msgKey, LocalizationDataTable.Tables.UI);
		string localizedString2 = LocalizationManager.GetLocalizedString(labelConfirmKey, LocalizationDataTable.Tables.UI);
		string localizedString3 = LocalizationManager.GetLocalizedString(labelCancelKey, LocalizationDataTable.Tables.UI);
		ShowMessage(localizedString, onConfirm, onCancel, localizedString2, localizedString3, stayInGameState: true, additionalInfoPreLocalized);
	}

	public void ShowConfirmationPopup(string msgKey, Action onConfirm, Action onCancel, string labelConfirmKey = "ui_popup_confirmation_confirm_confirm", string labelCancelKey = "ui_popup_confirmation_cancle_cancle")
	{
		string localizedString = LocalizationManager.GetLocalizedString(msgKey, LocalizationDataTable.Tables.UI);
		string localizedString2 = LocalizationManager.GetLocalizedString(labelConfirmKey, LocalizationDataTable.Tables.UI);
		string localizedString3 = LocalizationManager.GetLocalizedString(labelCancelKey, LocalizationDataTable.Tables.UI);
		ShowPreLocalizedMessageForSeconds(localizedString, onConfirm, onCancel, localizedString2, localizedString3);
	}

	public void ShowPreLocalizedMessageForSeconds(string localizedMessage, Action onConfirm, Action onCancel, string localizedLabelConfirm = "Yes", string localizedLabelCancel = "No")
	{
		ShowMessage(localizedMessage, onConfirm, onCancel, localizedLabelConfirm, localizedLabelCancel);
	}

	private void ShowMessage(string msg, Action onConfirm, Action onCancel, string labelConfirmKey, string labelCancelKey, bool stayInGameState = false, string additionalInfoPreLocalized = "")
	{
		content.SetActive(value: true);
		ResetLabels();
		labelMessage.text = msg;
		labelAdditionalInfo.text = additionalInfoPreLocalized;
		buttonConfirm.label = labelConfirmKey;
		buttonCancel.label = labelCancelKey;
		graphicRaycaster.enabled = true;
		UnityAction action = delegate
		{
			Hide(stayInGameState);
			if (onConfirm != null)
			{
				onConfirm();
			}
		};
		UnityAction action2 = delegate
		{
			Hide(stayInGameState);
			if (onCancel != null)
			{
				onCancel();
			}
		};
		buttonConfirm.gameObject.SetActive(value: true);
		buttonCancel.gameObject.SetActive(value: true);
		buttonOk.gameObject.SetActive(value: false);
		buttonConfirm.SubscribeToOnClick(action);
		buttonCancel.SubscribeToOnClick(action2);
		if (!TransitionManager.IsTransitioning())
		{
			GameStateManager.ChangeCharacterState(GameStateManager.CharacterState.MenuOpen);
		}
		animator.OnReverse();
		isVisible = true;
	}

	public void ShowConfirmationPopup(string msgKey, Action onOk)
	{
		string localizedString = LocalizationManager.GetLocalizedString(msgKey, LocalizationDataTable.Tables.UI);
		ShowPreLocalizedMessageForSeconds(localizedString, onOk);
	}

	public void ShowPreLocalizedMessageForSeconds(string localizedMessage, Action onOk)
	{
		ShowMessage(localizedMessage, onOk);
	}

	private void ShowMessage(string msg, Action onOk)
	{
		content.SetActive(value: true);
		ResetLabels();
		labelMessage.text = msg;
		graphicRaycaster.enabled = true;
		UnityAction action = delegate
		{
			Hide();
			if (onOk != null)
			{
				onOk();
			}
		};
		buttonConfirm.gameObject.SetActive(value: false);
		buttonCancel.gameObject.SetActive(value: false);
		buttonOk.gameObject.SetActive(value: true);
		buttonOk.SubscribeToOnClick(action);
		GameStateManager.ChangeCharacterState(GameStateManager.CharacterState.MenuOpen);
		animator.OnReverse();
		isVisible = true;
	}

	public void Hide(bool stayInGameState = false)
	{
		if (isVisible)
		{
			animator.OnPlay();
			isVisible = false;
			buttonConfirm.UnsubscribeAllClickEvents();
			buttonCancel.UnsubscribeAllClickEvents();
			buttonOk.UnsubscribeAllClickEvents();
			if (stayInGameState)
			{
				graphicRaycaster.enabled = false;
			}
			else if (!TransitionManager.IsTransitioning())
			{
				GameStateManager.ChangeCharacterState(GameStateManager.CharacterState.CharacterMode);
				graphicRaycaster.enabled = false;
			}
		}
	}

	private void ResetLabels()
	{
		if (labelMessage != null)
		{
			labelMessage.text = "";
		}
		if (labelAdditionalInfo != null)
		{
			labelAdditionalInfo.text = "";
		}
	}
}
