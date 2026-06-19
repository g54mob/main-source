using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlacementBox : MonoBehaviour
{
	public Image iconHolder;

	public Image rendererRef;

	public GameObject counterObject;

	public TextMeshProUGUI counterText;

	private Tooltip tooltipRef;

	private RoomCustomizationObject containedItem;

	private InventoryItem containedInventoryItem;

	private CursorUpdateArea updateAreaRef;

	private PlacementModeGUI controllerRef;

	public void SetContainedItem(InventoryItem itemRef, int number, Tooltip tooltip)
	{
		containedInventoryItem = itemRef;
		iconHolder.sprite = itemRef.icon;
		if (number == 1)
		{
			counterObject.SetActive(value: false);
		}
		else
		{
			counterObject.SetActive(value: true);
			counterText.text = number.ToString();
		}
		tooltipRef = tooltip;
	}

	public void SetContainedItem(RoomCustomizationObject itemRef, int number, Tooltip tooltip)
	{
		containedItem = itemRef;
		iconHolder.sprite = itemRef.icon;
		if (number == 1)
		{
			counterObject.SetActive(value: false);
		}
		else
		{
			counterObject.SetActive(value: true);
			counterText.text = number.ToString();
		}
		tooltipRef = tooltip;
	}

	public void SetControllerRef(PlacementModeGUI newRef, CursorUpdateArea areaRef)
	{
		controllerRef = newRef;
		updateAreaRef = areaRef;
	}

	public RoomCustomizationObject GetContainedItem()
	{
		return containedItem;
	}

	public InventoryItem GetContainedInventoryItem()
	{
		return containedInventoryItem;
	}

	public void OnClick()
	{
		controllerRef.SelectBox(this);
	}

	public void OnHoverStart()
	{
		if (containedInventoryItem != null)
		{
			tooltipRef.SetItem(containedInventoryItem);
		}
		else
		{
			tooltipRef.SetItem(containedItem);
		}
		if (!ShouldInputInhibitTooltip())
		{
			tooltipRef.gameObject.SetActive(value: true);
		}
		updateAreaRef.ReportCursorOverContent();
	}

	public void OnHover()
	{
		if (!ShouldInputInhibitTooltip())
		{
			tooltipRef.HoverBehavior();
			if (!tooltipRef.gameObject.activeSelf)
			{
				tooltipRef.gameObject.SetActive(value: true);
			}
		}
		else if (tooltipRef.gameObject.activeSelf)
		{
			tooltipRef.gameObject.SetActive(value: false);
		}
		updateAreaRef.ReportCursorOverContent();
	}

	public void OnHoverStop()
	{
		tooltipRef.gameObject.SetActive(value: false);
	}

	private bool ShouldInputInhibitTooltip()
	{
		if (GameControls.actions.Interact.IsPressed || GameControls.actions.Cancel.IsPressed || GameControls.actions.CloseMenu.IsPressed)
		{
			return true;
		}
		if (GameControls.actions.GamepadCameraX.IsPressed || GameControls.actions.GamepadCameraY.IsPressed)
		{
			return true;
		}
		return false;
	}
}
