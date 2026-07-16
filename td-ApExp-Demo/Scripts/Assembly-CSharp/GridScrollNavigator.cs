using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class GridScrollNavigator : MonoBehaviour
{
	public ScrollRect scrollRect;

	public RectTransform viewport;

	public RectTransform content;

	public GridLayoutGroup gridLayout;

	private int columns;

	private void OnEnable()
	{
		NoticeBoardContent.OnNBCNavigate = (Action)Delegate.Combine(NoticeBoardContent.OnNBCNavigate, new Action(HandleNBCNavigate));
	}

	private void OnDisable()
	{
		NoticeBoardContent.OnNBCNavigate = (Action)Delegate.Remove(NoticeBoardContent.OnNBCNavigate, new Action(HandleNBCNavigate));
	}

	private void Start()
	{
		if (gridLayout.constraint != GridLayoutGroup.Constraint.FixedColumnCount)
		{
			Debug.LogError("GridScrollNavigator only works with Fixed Column Count.");
		}
		else
		{
			columns = gridLayout.constraintCount;
		}
	}

	private void HandleNBCNavigate()
	{
		GameObject currentSelectedGameObject = EventSystem.current.currentSelectedGameObject;
		if (!(currentSelectedGameObject == null) && !(currentSelectedGameObject.transform.parent != content))
		{
			RectTransform component = currentSelectedGameObject.GetComponent<RectTransform>();
			if (!IsFullyVisible(component))
			{
				ScrollToElement(component);
			}
		}
	}

	private bool IsFullyVisible(RectTransform item)
	{
		Vector3[] array = new Vector3[4];
		item.GetWorldCorners(array);
		Vector3[] array2 = new Vector3[4];
		viewport.GetWorldCorners(array2);
		if (array[1].y <= array2[1].y)
		{
			return array[0].y >= array2[0].y;
		}
		return false;
	}

	private void ScrollToElement(RectTransform item)
	{
		int num = item.GetSiblingIndex() / columns;
		float num2 = gridLayout.cellSize.y + gridLayout.spacing.y;
		float height = content.rect.height;
		float height2 = viewport.rect.height;
		float num3 = (float)num * num2;
		float num4 = height - height2;
		float num5 = Mathf.Clamp01(num3 / num4);
		scrollRect.verticalNormalizedPosition = 1f - num5;
	}
}
