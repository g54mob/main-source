using System;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class TwoMouseButtonButton : Button
{
	public Action OnButtonClick_LeftMouseButton;

	public Action OnButtonClick_RightMouseButton;

	public Action OnSelected;

	public Action OnDeselected;

	public override void OnPointerClick(PointerEventData eventData)
	{
	}

	public override void OnSelect(BaseEventData eventData)
	{
	}

	public override void OnDeselect(BaseEventData eventData)
	{
	}
}
