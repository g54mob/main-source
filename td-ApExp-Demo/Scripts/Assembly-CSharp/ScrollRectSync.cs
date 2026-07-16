using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(ScrollRect))]
public class ScrollRectSync : MonoBehaviour
{
	[Header("Settings")]
	[SerializeField]
	private Scrollbar scrollbar;

	[SerializeField]
	private bool isVertical = true;

	private ScrollRect scrollRect;

	private bool isDraggingScrollRect;

	private bool isDraggingScrollbar;

	private void Awake()
	{
		scrollRect = GetComponent<ScrollRect>();
		scrollbar.onValueChanged.AddListener(HandleScrollbarChanged);
		scrollRect.onValueChanged.AddListener(HandleScrollRectChanged);
	}

	private void HandleScrollbarChanged(float value)
	{
		if (!isDraggingScrollRect)
		{
			isDraggingScrollbar = true;
			if (isVertical)
			{
				scrollRect.verticalNormalizedPosition = 1f - value;
			}
			else
			{
				scrollRect.horizontalNormalizedPosition = value;
			}
			isDraggingScrollbar = false;
		}
	}

	private void HandleScrollRectChanged(Vector2 position)
	{
		if (!isDraggingScrollbar)
		{
			isDraggingScrollRect = true;
			if (isVertical)
			{
				scrollbar.value = 1f - position.y;
			}
			else
			{
				scrollbar.value = position.x;
			}
			isDraggingScrollRect = false;
		}
	}

	private void OnDestroy()
	{
		scrollbar.onValueChanged.RemoveListener(HandleScrollbarChanged);
		scrollRect.onValueChanged.RemoveListener(HandleScrollRectChanged);
	}
}
