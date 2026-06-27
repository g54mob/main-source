using System;
using UnityEngine;
using UnityEngine.UI;

namespace Mandragora.Utils
{
	public class ScrollViewOptimizer : MonoBehaviour
	{
		[SerializeField]
		private ScrollRect scrollRect;

		[SerializeField]
		[Tooltip("Root where items placed")]
		private RectTransform itemsContent;

		[SerializeField]
		[Tooltip("Mask root")]
		private RectTransform viewPort;

		[SerializeField]
		private HorizontalOrVerticalLayoutGroup layoutGroup;

		[SerializeField]
		[Tooltip("Count of items which fits in to viewport + 1")]
		private int maxVisibleItemsCount = 6;

		private int totalItemsCount;

		private float lastScrollPosition;

		private bool scrollDown;

		private float spaceBetweenItems;

		private RectTransform firstItem;

		private RectTransform lastItem;

		private int firstItemIndex;

		private int lastItemIndex;

		private Func<int, RectTransform> spawnView;

		private Func<int, RectTransform, RectTransform> reinitView;

		private bool inited;

		private readonly Vector3[] corners = new Vector3[4];

		private void Start()
		{
			lastScrollPosition = scrollRect.verticalNormalizedPosition;
			layoutGroup.enabled = false;
			scrollRect.onValueChanged.AddListener(OnScroll);
		}

		public void Init(Func<int, RectTransform> spawnView, Func<int, RectTransform, RectTransform> reinitView)
		{
			layoutGroup.enabled = false;
			this.spawnView = spawnView;
			this.reinitView = reinitView;
			inited = true;
		}

		public void Show(int totalItemsCount)
		{
			if (!inited)
			{
				return;
			}
			this.totalItemsCount = totalItemsCount;
			Vector2 anchoredPosition = new Vector2(layoutGroup.padding.left, -layoutGroup.padding.top);
			int num = Mathf.Min(maxVisibleItemsCount, totalItemsCount);
			for (int i = 0; i < num; i++)
			{
				RectTransform rectTransform = spawnView(i);
				rectTransform.pivot = new Vector2(0f, 1f);
				if (i == 0)
				{
					firstItem = rectTransform;
					spaceBetweenItems = rectTransform.sizeDelta.y + layoutGroup.spacing;
				}
				if (i == num - 1)
				{
					lastItem = rectTransform;
				}
				rectTransform.anchoredPosition = anchoredPosition;
				anchoredPosition.y -= spaceBetweenItems;
			}
			firstItemIndex = 0;
			lastItemIndex = num - 1;
			CalculateItemsContentSize(firstItem);
		}

		private void OnScroll(Vector2 value)
		{
			scrollDown = lastScrollPosition > scrollRect.verticalNormalizedPosition;
			lastScrollPosition = scrollRect.verticalNormalizedPosition;
			UpdateScrollItems();
		}

		private void UpdateScrollItems()
		{
			if (scrollDown && !IsRectVisible(firstItem))
			{
				MoveToEdge(firstItem, lastItem);
			}
			else if (!scrollDown && !IsRectVisible(lastItem))
			{
				MoveToEdge(lastItem, firstItem);
			}
		}

		private void MoveToEdge(RectTransform moveItem, RectTransform prevItem)
		{
			if (totalItemsCount < 2)
			{
				return;
			}
			int num = ((prevItem == firstItem) ? firstItemIndex : lastItemIndex);
			int num2 = (scrollDown ? 1 : (-1));
			int num3 = num + num2;
			if (num3 >= 0 && num3 < totalItemsCount)
			{
				firstItemIndex += num2;
				lastItemIndex += num2;
				moveItem = reinitView(num3, moveItem);
				if (scrollDown)
				{
					moveItem.SetAsLastSibling();
					lastItem = moveItem;
					firstItem = itemsContent.GetChild(0) as RectTransform;
				}
				else
				{
					moveItem.SetAsFirstSibling();
					firstItem = moveItem;
					lastItem = itemsContent.GetChild(itemsContent.childCount - 1) as RectTransform;
				}
				Vector2 anchoredPosition = prevItem.anchoredPosition;
				anchoredPosition.y += (scrollDown ? (0f - spaceBetweenItems) : spaceBetweenItems);
				moveItem.anchoredPosition = anchoredPosition;
			}
		}

		private void CalculateItemsContentSize(RectTransform view)
		{
			Vector2 sizeDelta = view.sizeDelta;
			float num = sizeDelta.y * (float)totalItemsCount;
			num += layoutGroup.spacing * (float)(totalItemsCount - 1);
			num += (float)(layoutGroup.padding.top + layoutGroup.padding.bottom);
			float x = sizeDelta.x;
			itemsContent.pivot = new Vector2(0f, 1f);
			itemsContent.sizeDelta = new Vector2(x, num);
			Vector2 anchoredPosition = itemsContent.anchoredPosition;
			anchoredPosition.x = layoutGroup.padding.left - layoutGroup.padding.right;
			itemsContent.anchoredPosition = anchoredPosition;
		}

		private bool IsRectVisible(RectTransform rectTransform)
		{
			rectTransform.GetWorldCorners(corners);
			for (int i = 0; i < 4; i++)
			{
				if (RectTransformUtility.RectangleContainsScreenPoint(viewPort, RectTransformUtility.WorldToScreenPoint(null, corners[i]), null))
				{
					return true;
				}
			}
			return false;
		}
	}
}
