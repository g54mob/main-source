using System.Collections.Generic;
using NSEipix;
using NSEipix.Base;
using UnityEngine;
using UnityEngine.UI;

namespace NSMedieval.UI
{
	[RequireComponent(typeof(ScrollRect))]
	public class OptimizedScrollView : MonoBehaviour
	{
		public delegate void UpdateScrollDelegate(RectTransform rectTransform, int index);

		public UpdateScrollDelegate UpdateScrollItemAction;

		private static Vector3[] tempCorners = new Vector3[4];

		[SerializeField]
		private RectTransform contentRectTransform;

		[SerializeField]
		private float spacing = 4f;

		private RectTransform rectTransform;

		private ScrollRect scrollRect;

		private readonly List<RectTransform> children = new List<RectTransform>();

		private float groupElementHeight;

		private float topMargin;

		private float bottomMargin;

		private int elementCount;

		private int indexOfFirst;

		private int indexOfLast;

		private float previousScrollY;

		private int elementsToShow;

		private GameObject prefab;

		private bool elementsUpdating;

		private bool initialized;

		public float SpacedElementHeight => groupElementHeight + spacing;

		public RectTransform ContentRectTransform => contentRectTransform;

		[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
		public static void OnDomainReload()
		{
			tempCorners = new Vector3[4];
		}

		public void Initialize()
		{
			scrollRect = GetComponent<ScrollRect>();
			rectTransform = GetComponent<RectTransform>();
			prefab = contentRectTransform.GetComponent<LayoutGroupView>().Prefab.gameObject;
			groupElementHeight = prefab.GetComponent<RectTransform>().rect.height;
		}

		public void RefreshVisibleEntries(int elementCount)
		{
			if (!initialized)
			{
				Initialize();
			}
			this.elementCount = elementCount;
			UpdateElements();
		}

		private void NotifyUpdateScrollItems()
		{
			int num = indexOfFirst;
			foreach (RectTransform child in children)
			{
				UpdateScrollItemAction?.Invoke(child, num);
				num++;
			}
		}

		private void UpdateElements()
		{
			elementsUpdating = true;
			scrollRect.enabled = false;
			previousScrollY = 1f;
			topMargin = GetTopPosition(rectTransform);
			bottomMargin = GetBottomPosition(rectTransform);
			contentRectTransform.sizeDelta = new Vector2(contentRectTransform.sizeDelta.x, SpacedElementHeight * (float)elementCount - spacing);
			contentRectTransform.anchoredPosition = new Vector2(contentRectTransform.anchoredPosition.x, 0f);
			int b = (int)(rectTransform.rect.height / groupElementHeight) + 2;
			elementsToShow = Mathf.Min(elementCount, b);
			indexOfFirst = 0;
			indexOfLast = elementsToShow - 1;
			for (int i = 0; i < elementsToShow; i++)
			{
				RectTransform childAt = GetChildAt(i);
				childAt.anchoredPosition = new Vector2(y: 0f - (float)i * SpacedElementHeight, x: childAt.anchoredPosition.x);
			}
			for (int num = children.Count - 1; num > indexOfLast; num--)
			{
				GameObject obj = children[num].gameObject;
				children.RemoveAt(num);
				Object.Destroy(obj);
			}
			MonoSingleton<TaskController>.Instance.WaitForNextFrameUnscaled().Then(delegate
			{
				scrollRect.verticalScrollbar.value = 1f;
				NotifyUpdateScrollItems();
				scrollRect.enabled = true;
				elementsUpdating = false;
			});
		}

		private RectTransform GetChildAt(int index)
		{
			if (children.Count >= index + 1)
			{
				return children[index];
			}
			return children.GetNext(prefab, contentRectTransform).GetComponent<RectTransform>();
		}

		private void OnScrollValueChanged(Vector2 scrollPosition)
		{
			if (children != null && children.Count != 0 && !elementsUpdating && !Mathf.Approximately(scrollPosition.y, previousScrollY))
			{
				if (scrollPosition.y < previousScrollY)
				{
					RepositionDown();
				}
				if (scrollPosition.y > previousScrollY)
				{
					RepositionUp();
				}
				previousScrollY = scrollPosition.y;
			}
		}

		private void RepositionDown()
		{
			if (ShouldRepositionDown())
			{
				List<RectTransform> list = children;
				Vector2 anchoredPosition = list[list.Count - 1].anchoredPosition;
				anchoredPosition[1] -= SpacedElementHeight;
				RectTransform rectTransform = children[0];
				rectTransform.anchoredPosition = anchoredPosition;
				children.RemoveAt(0);
				children.Add(rectTransform);
				indexOfFirst++;
				indexOfLast++;
				UpdateScrollItemAction(rectTransform, indexOfLast);
				RepositionDown();
			}
		}

		private void RepositionUp()
		{
			if (ShouldRepositionUp())
			{
				Vector2 anchoredPosition = children[0].anchoredPosition;
				anchoredPosition[1] += SpacedElementHeight;
				List<RectTransform> list = children;
				RectTransform rectTransform = list[list.Count - 1];
				rectTransform.anchoredPosition = anchoredPosition;
				children.Remove(rectTransform);
				children.Insert(0, rectTransform);
				indexOfFirst--;
				indexOfLast--;
				UpdateScrollItemAction(rectTransform, indexOfFirst);
				RepositionUp();
			}
		}

		private void OnEnable()
		{
			if (!initialized)
			{
				Initialize();
			}
			scrollRect.onValueChanged.AddListener(OnScrollValueChanged);
		}

		private void OnDisable()
		{
			scrollRect.onValueChanged.RemoveListener(OnScrollValueChanged);
		}

		private bool ShouldRepositionDown()
		{
			bool num = indexOfFirst >= elementCount - elementsToShow;
			bool flag = GetBottomPosition(children[0]) > topMargin;
			return !num && flag;
		}

		private bool ShouldRepositionUp()
		{
			bool num = indexOfFirst == 0;
			List<RectTransform> list = children;
			bool flag = GetTopPosition(list[list.Count - 1]) < bottomMargin;
			return !num && flag;
		}

		private static float GetTopPosition(RectTransform rectTransform)
		{
			rectTransform.GetWorldCorners(tempCorners);
			return tempCorners[1].y;
		}

		private static float GetBottomPosition(RectTransform rectTransform)
		{
			rectTransform.GetWorldCorners(tempCorners);
			return tempCorners[0].y;
		}
	}
}
