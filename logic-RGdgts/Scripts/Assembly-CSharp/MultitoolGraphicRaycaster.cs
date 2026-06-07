using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MultitoolGraphicRaycaster : GraphicRaycaster
{
	public Camera overrideEventCamera;

	public override Camera eventCamera => null;

	public override void Raycast(PointerEventData eventData, List<RaycastResult> resultAppendList)
	{
	}
}
