using UnityEngine;

public class MouseInteractionComponent : MonoBehaviour
{
	public bool showDurationWhenAvailable;

	public bool overrideInteractionInfo;

	public InteractionDisplayInfo displayInfo;

	public InteractionDisplayInfo[] interactionDisplayInfoToOthers;

	private Outline outline;

	private float startDuration;

	private float duration;

	private void Start()
	{
		outline = GetComponent<Outline>();
		HideOutline();
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
		this.startDuration = startDuration;
	}

	public void Show()
	{
		ItemComponent itemComponent = null;
		switch (displayInfo.infoType)
		{
		case InteractionDisplayInfo.InfoType.Interaction:
			itemComponent = GetComponent<ItemComponent>();
			PopupMessageManager.GetInfoPopUp().ShowMessage(itemComponent.GetInfo().GetLocalizedName());
			break;
		case InteractionDisplayInfo.InfoType.Product:
			itemComponent = GetComponent<ItemComponent>();
			PopupMessageManager.GetInfoPopUp().ShowProductInfo(itemComponent.GetInfo().GetLocalizedName(), itemComponent.item.tag.GetFormattedLocalizedTags(), itemComponent.useLimitedAmount ? (itemComponent.item.amount + "/" + itemComponent.item.maxAmount) : "", showDurationWhenAvailable ? duration.ToString() : "");
			break;
		}
	}

	public void Hide()
	{
	}

	public void ShowOutline()
	{
		if (!(outline == null))
		{
			outline.enabled = true;
		}
	}

	public void HideOutline()
	{
		if (!(outline == null))
		{
			outline.enabled = false;
		}
	}
}
