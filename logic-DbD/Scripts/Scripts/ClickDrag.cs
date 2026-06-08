using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ClickDrag : MonoBehaviour, IDragHandler, IEventSystemHandler, IBeginDragHandler, IEndDragHandler
{
	[SerializeField]
	private GameObject dragBox;

	private Canvas canvas;

	private Vector2 originalPos;

	private GameObject currentDragBox;

	private Dictionary<Icon, Vector3> iconPositions;

	private HashSet<Icon> selectedIcons;

	private void Awake()
	{
		canvas = UIUtils.FindCanvasFromChild(base.transform);
		selectedIcons = new HashSet<Icon>();
	}

	public void PopulateIconPositions()
	{
		iconPositions = new Dictionary<Icon, Vector3>();
		foreach (Transform item in base.transform)
		{
			Icon componentInChildren = item.GetComponentInChildren<Icon>();
			if (componentInChildren != null && !iconPositions.ContainsKey(componentInChildren) && !Icon.IsGameOverSkipIcon(item))
			{
				iconPositions[componentInChildren] = componentInChildren.transform.position;
				Debug.Log($"ClickDrag: {componentInChildren.transform.parent} {componentInChildren.transform.position}");
			}
		}
		Debug.Log($"ClickDrag: There are {iconPositions.Count} icons");
	}

	public void AddIcon(GameObject icon)
	{
		iconPositions[icon.GetComponentInChildren<Icon>()] = icon.transform.position;
		Debug.Log($"ClickDrag: There are {iconPositions.Count} icons");
	}

	public void RemoveIcon(Icon icon)
	{
		iconPositions.Remove(icon);
		Debug.Log($"ClickDrag: There are {iconPositions.Count} icons");
	}

	public void UpdatePosition(Icon icon)
	{
		iconPositions[icon] = icon.transform.position;
	}

	public void OnDrag(PointerEventData eventData)
	{
		Vector2 vector = new Vector2(originalPos.x - eventData.position.x, eventData.position.y - originalPos.y);
		bool flag = vector.x < 0f;
		bool flag2 = vector.y < 0f;
		currentDragBox.GetComponent<RectTransform>().sizeDelta = new Vector2(Math.Abs(vector.x), Math.Abs(vector.y)) * UIUtils.GetScreenFixedRatio();
		currentDragBox.GetComponent<RectTransform>().localScale = new Vector3((!flag) ? 1 : (-1), (!flag2) ? 1 : (-1), 1f);
		Vector2 vector2 = Camera.main.ScreenToWorldPoint(originalPos);
		Vector2 vector3 = Camera.main.ScreenToWorldPoint(eventData.position);
		Vector2 dragTopLeft = new Vector2(Math.Min(vector2.x, vector3.x), Math.Max(vector2.y, vector3.y));
		Vector2 dragBottomRight = new Vector2(Math.Max(vector2.x, vector3.x), Math.Min(vector2.y, vector3.y));
		foreach (Icon key in iconPositions.Keys)
		{
			Vector2 iconPosition = key.transform.position;
			if (IsSelected(iconPosition, dragTopLeft, dragBottomRight, 20))
			{
				key.SelectIcon();
				AddSelectedIcon(key);
			}
			else
			{
				key.UnselectIcon();
				RemoveSelectedIcon(key);
			}
		}
	}

	public bool IsSelected(Vector2 iconPosition, Vector2 dragTopLeft, Vector2 dragBottomRight, int width)
	{
		return IsSelectedOffset(width, width);
		bool IsSelectedOffset(float x, float y)
		{
			if (iconPosition.x + x > dragTopLeft.x && iconPosition.x - x < dragBottomRight.x && iconPosition.y - y < dragTopLeft.y)
			{
				return iconPosition.y + y > dragBottomRight.y;
			}
			return false;
		}
	}

	public void AddSelectedIcon(Icon icon)
	{
		selectedIcons.Add(icon);
	}

	public void RemoveSelectedIcon(Icon icon)
	{
		selectedIcons.Remove(icon);
	}

	public void ClearSelectedIcons()
	{
		selectedIcons = new HashSet<Icon>();
	}

	public ICollection<Icon> GetSelectedIcons()
	{
		return selectedIcons;
	}

	public void OnEndDrag(PointerEventData eventData)
	{
		MonoBehaviour.print($"end pos: {Camera.main.ScreenToWorldPoint(eventData.position)}");
		UnityEngine.Object.Destroy(currentDragBox);
	}

	public void OnBeginDrag(PointerEventData eventData)
	{
		originalPos = eventData.position;
		currentDragBox = UnityEngine.Object.Instantiate(dragBox, Camera.main.ScreenToWorldPoint(originalPos), Quaternion.identity, base.transform);
		Vector3 localPosition = currentDragBox.GetComponent<Transform>().localPosition;
		currentDragBox.GetComponent<Transform>().localPosition = new Vector2(localPosition.x, localPosition.y);
		MonoBehaviour.print($"original pos: {Camera.main.ScreenToWorldPoint(originalPos)}");
	}
}
