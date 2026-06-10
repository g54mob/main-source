using System.Collections.Generic;
using UnityEngine;

public class InventorySquareController : ButtonController
{
	public List<CanvasRenderer> renderers;

	public FirstPersonItemController.InventorySlot slot;

	public RectTransform stolenIcon;

	public RectTransform equipmentIcon;

	public RectTransform selected;

	public void Setup(FirstPersonItemController.InventorySlot newSlot)
	{
	}

	public void OnUpdateContent()
	{
	}

	public void UpdateHotkeyDisplay()
	{
	}

	public override void OnHoverStart()
	{
	}

	public override void OnHoverEnd()
	{
	}

	public override void OnLeftClick()
	{
	}

	public override void OnRightClick()
	{
	}
}
