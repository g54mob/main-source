using System.Collections;
using UnityEngine;

public class PopupMessageManager : MonoBehaviour
{
	[SerializeField]
	private PopupMessageComponent popupInValidOrMissing;

	[SerializeField]
	private PopupMessageComponent popupInfo;

	[SerializeField]
	private PopupDialogComponent popupDialog;

	[SerializeField]
	private PopHintComponent popHint;

	[SerializeField]
	private PopupConfirmationComponent popupConfirmation;

	[SerializeField]
	private PopupTaskCheckListComponent popupCheckListOption;

	public string popupLocalizationMsgProceedTutorial = "ui_popup_confirmation_msg_proceedTutorial";

	public string popupLocalizationConfirmConfirm = "ui_popup_confirmation_confirm_confirm";

	public string popupLocalizationConfirmNext = "ui_popup_confirmation_confirm_next";

	public string popupLocalizationConfirmSleep = "ui_popup_confirmation_confirm_sleep";

	public string popupLocalizationCancleCancle = "ui_popup_confirmation_cancle_cancle";

	public string popupLocalizationCancleRepeat = "ui_popup_confirmation_cancle_repeat";

	public string popupLocalizationOkayOkay = "ui_popup_confirmation_okay_okay";

	public string popupLocalizationOkayGotIt = "ui_popup_confirmation_okay_gotit";

	public string popupLocalizationInvalidCafeNeedsToBeClosed = "ui_popup_invalid_msg_pricingboard_cafeopen";

	public string popupLocalizationInvalidCustomersNeedToLeave = "ui_popup_invalid_msg_pricingboard_customers";

	public string popupLocalizationInvalidItem = "ui_popup_invalid_msg_common_invaliditem";

	private static PopupMessageManager instance;

	private const string hexColor = "#ffc880";

	public static PopupMessageManager GetInstance()
	{
		return instance;
	}

	public static string GetHighlightBegin(string color)
	{
		return "  <color=" + color + "> ";
	}

	public static string GetHighlightBegin()
	{
		return "  <color=" + GetDefaultHighlightColorHex() + "> ";
	}

	public static string GetHighlightEnd()
	{
		return "</color>   ";
	}

	public static string GetDefaultHighlightColorHex()
	{
		return "#ffc880";
	}

	public static Color GetDefaultHighlightColor()
	{
		ColorUtility.TryParseHtmlString("#ffc880", out var color);
		return color;
	}

	public static bool IsValidated()
	{
		return instance != null;
	}

	public void Awake()
	{
		if (instance == null)
		{
			instance = this;
		}
		else if (instance != this)
		{
			Object.Destroy(this);
		}
		Object.DontDestroyOnLoad(instance);
	}

	private void Start()
	{
		StartCoroutine(WaitForFrame());
	}

	private IEnumerator WaitForFrame()
	{
		yield return new WaitForEndOfFrame();
		HideAll();
		StopAllCoroutines();
	}

	public static void HideAll()
	{
		GetInValidOrMissingPopUp().HideForce();
		GetInfoPopUp().HideForce();
		GetDialogPopUp().HideForce();
		GetConfirmationPopUp().Hide();
		GetCheckListPopUp().Hide();
	}

	public static void HideInfoPopups()
	{
		GetInValidOrMissingPopUp().HideForce();
		GetInfoPopUp().HideForce();
	}

	public static PopupMessageComponent GetInValidOrMissingPopUp()
	{
		return instance.popupInValidOrMissing;
	}

	public static PopupMessageComponent GetInfoPopUp()
	{
		return instance.popupInfo;
	}

	public static PopupDialogComponent GetDialogPopUp()
	{
		return instance.popupDialog;
	}

	public static PopHintComponent GetPopHint()
	{
		return instance.popHint;
	}

	public static PopupConfirmationComponent GetConfirmationPopUp()
	{
		return instance.popupConfirmation;
	}

	public static PopupTaskCheckListComponent GetCheckListPopUp()
	{
		return instance.popupCheckListOption;
	}
}
