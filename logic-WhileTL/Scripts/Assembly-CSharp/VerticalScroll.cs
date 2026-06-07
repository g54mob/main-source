using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class VerticalScroll : DragController
{
	private static Vector2? screenCenter;

	private void Start()
	{
		if (!screenCenter.HasValue)
		{
			screenCenter = new Vector2(Screen.width, Screen.height) / 2f;
		}
	}

	public override void OnDrag(PointerEventData pointerEventData)
	{
		Camera main = Camera.main;
		Vector2 delta = pointerEventData.delta;
		Vector2? vector = screenCenter;
		Vector3 vector2 = main.ScreenToWorldPoint((delta + vector).Value);
		vector2.z = 0f;
		vector2.x = 0f;
		base.transform.position += vector2;
		RectTransform component = base.gameObject.GetComponent<RectTransform>();
		Vector2 anchoredPosition = component.anchoredPosition;
		anchoredPosition.y = Mathf.Min(anchoredPosition.y, component.sizeDelta.y);
		anchoredPosition.y = Math.Max(0f, anchoredPosition.y);
		component.anchoredPosition = anchoredPosition;
	}
}
