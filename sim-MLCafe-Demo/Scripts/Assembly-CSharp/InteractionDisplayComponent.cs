using MLCN_Localization;
using UnityEngine;
using UnityEngine.Events;

public class InteractionDisplayComponent : MonoBehaviour
{
	public InteractionDisplayConfig displayInfo;

	private Outline outline;

	private bool showDurationWhenAvailable;

	private float duration;

	public bool isVisible;

	public UnityEvent OnShow = new UnityEvent();

	public UnityEvent OnHide = new UnityEvent();

	private void Start()
	{
		outline = GetComponent<Outline>();
		if (outline != null)
		{
			outline.enabled = false;
		}
	}

	public string GetFormattedDuration()
	{
		if (duration <= 0f)
		{
			return "";
		}
		return $"{Mathf.FloorToInt(duration) / 60}:{Mathf.Abs(duration) % 60f:00}";
	}

	public void UpdateDuration(float newDuration, float startDuration)
	{
		duration = newDuration;
		if (duration > 0f)
		{
			showDurationWhenAvailable = true;
		}
		else
		{
			showDurationWhenAvailable = false;
		}
		PopupMessageManager.GetInfoPopUp().ShowRemainingTimeDuration(GetFormattedDuration());
	}

	public void HideInfo()
	{
		PopupMessageManager.GetInfoPopUp().Hide();
		MouseCursorInteraction.HideInteractionControl();
		if (GetComponent<RemovableInstance>() != null || displayInfo.controlType == InteractionDisplayConfig.ControlType.RightMouseClick || displayInfo.controlType == InteractionDisplayConfig.ControlType.LeftAndRight)
		{
			MouseCursorInteraction.HideRemoveObjectControl();
		}
		OnHide.Invoke();
	}

	public void HideOutline()
	{
		if (outline != null)
		{
			outline.enabled = false;
		}
	}

	public void ShowInfo()
	{
		if (outline != null)
		{
			outline.enabled = true;
		}
		ItemComponent component = GetComponent<ItemComponent>();
		PopupMessageComponent infoPopUp = PopupMessageManager.GetInfoPopUp();
		if (displayInfo.overrideMsgKey != string.Empty)
		{
			infoPopUp.ShowMessage(LocalizationManager.GetLocalizedString(displayInfo.overrideMsgKey, displayInfo.overrideKeyTable));
			return;
		}
		switch (displayInfo.infoType)
		{
		case InteractionDisplayConfig.InfoType.BasicInteraction:
			if (component != null)
			{
				infoPopUp.ShowMessage(component.GetInfo().GetLocalizedName());
			}
			break;
		case InteractionDisplayConfig.InfoType.Ingredient:
			PopupMessageManager.GetInfoPopUp().ShowProductInfo(component.GetInfo().GetLocalizedName(), component.item.tag.GetFormattedLocalizedTags(), component.useLimitedAmount ? (component.item.amount + "/" + component.item.maxAmount) : "", showDurationWhenAvailable ? GetFormattedDuration() : "");
			break;
		case InteractionDisplayConfig.InfoType.Product:
		{
			CupComponent component2 = GetComponent<CupComponent>();
			if (component2 != null && !component2.IsUseable())
			{
				string msg = "<color=red>" + LocalizationManager.GetLocalizedString("ui_popup_status_dirty", LocalizationDataTable.Tables.UI) + "</color> " + component.GetInfo().GetLocalizedName();
				infoPopUp.ShowMessage(msg);
				return;
			}
			ProductComponent component3 = GetComponent<ProductComponent>();
			if (component3 == null || !component3.IsHoldingProduct())
			{
				infoPopUp.ShowMessage(component.GetInfo().GetLocalizedName());
			}
			else if (component3.IsHoldingProduct())
			{
				Item item = component3.GetComponent<ItemComponent>().item;
				string productName = component3.GetProductName(byFlavour: true);
				string amount = ((item.maxAmount > 1) ? (item.amount + "/" + item.maxAmount) : "");
				PopupMessageManager.GetInfoPopUp().ShowProductInfo(productName, component3.GetProductTagsFormatted(), amount);
			}
			break;
		}
		}
		OnShow.Invoke();
	}

	public void ShowControls()
	{
		GetComponent<ItemComponent>();
		PopupMessageManager.GetInfoPopUp();
		if (GetComponent<RemovableInstance>() != null)
		{
			MouseCursorInteraction.ShowRemoveObjectControl();
		}
		else
		{
			MouseCursorInteraction.HideRemoveObjectControl();
		}
		string control = "";
		LocalizationDataTable.Tables tableKey = (displayInfo.useCustomControlTable ? displayInfo.customControlKeyTable : displayInfo.overrideKeyTable);
		switch (displayInfo.controlType)
		{
		case InteractionDisplayConfig.ControlType.LeftMouseClick:
			if (displayInfo.overrideLeftClickMsgKey != "")
			{
				control = LocalizationManager.GetLocalizedString(displayInfo.overrideLeftClickMsgKey, tableKey);
			}
			MouseCursorInteraction.ShowInteractionControl(control);
			break;
		case InteractionDisplayConfig.ControlType.RightMouseClick:
			if (displayInfo.overrideRightClickMsgKey != "")
			{
				control = LocalizationManager.GetLocalizedString(displayInfo.overrideRightClickMsgKey, tableKey);
			}
			MouseCursorInteraction.ShowRightClickInteractionControl(control);
			break;
		case InteractionDisplayConfig.ControlType.LeftAndRight:
			control = ((!(displayInfo.overrideLeftClickMsgKey != "")) ? "" : LocalizationManager.GetLocalizedString(displayInfo.overrideLeftClickMsgKey, tableKey));
			MouseCursorInteraction.ShowInteractionControl(control);
			control = ((!(displayInfo.overrideRightClickMsgKey != "")) ? "" : LocalizationManager.GetLocalizedString(displayInfo.overrideRightClickMsgKey, tableKey));
			MouseCursorInteraction.ShowRightClickInteractionControl(control);
			break;
		case InteractionDisplayConfig.ControlType.None:
		case InteractionDisplayConfig.ControlType.MouseScroll:
			break;
		}
	}
}
