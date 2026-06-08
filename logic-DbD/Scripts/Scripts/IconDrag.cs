using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class IconDrag : MonoBehaviour, IDragHandler, IEventSystemHandler, IBeginDragHandler, IEndDragHandler
{
	private Canvas canvas;

	private ClickDrag clickDrag;

	private Dictionary<Transform, Vector2> originalIconPos;

	private void Awake()
	{
		canvas = UIUtils.FindCanvasFromChild(base.transform);
		clickDrag = GetComponentInParent<ClickDrag>();
	}

	public void OnDrag(PointerEventData eventData)
	{
		foreach (Transform key in originalIconPos.Keys)
		{
			key.GetComponent<RectTransform>().anchoredPosition += eventData.delta / canvas.scaleFactor;
		}
	}

	public void OnEndDrag(PointerEventData eventData)
	{
		if (ThomasGridLayoutGroup.CanMoveIcons(originalIconPos))
		{
			ThomasGridLayoutGroup.ClampIconPositions(originalIconPos);
			{
				foreach (Transform key in originalIconPos.Keys)
				{
					Icon componentInChildren = key.GetComponentInChildren<Icon>();
					clickDrag.UpdatePosition(componentInChildren);
				}
				return;
			}
		}
		foreach (Transform key2 in originalIconPos.Keys)
		{
			key2.localPosition = originalIconPos[key2];
		}
	}

	public void OnBeginDrag(PointerEventData eventData)
	{
		originalIconPos = new Dictionary<Transform, Vector2>();
		foreach (Transform item in base.transform.parent)
		{
			Icon componentInChildren = item.GetComponentInChildren<Icon>();
			if (clickDrag.GetSelectedIcons().Contains(componentInChildren))
			{
				originalIconPos[item] = item.localPosition;
			}
		}
		foreach (Transform key in originalIconPos.Keys)
		{
			key.SetAsLastSibling();
		}
	}
}
