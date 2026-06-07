using UnityEngine;

namespace GameCreator.Runtime.Common
{
	public static class RectTransformUtils
	{
		public static void RebuildChildren(RectTransform parent, GameObject prefab, int count)
		{
			int childCount = parent.childCount;
			if (childCount == count)
			{
				return;
			}
			if (childCount > count)
			{
				int num = childCount - count;
				for (int i = 0; i < num; i++)
				{
					Transform child = parent.GetChild(childCount - i - 1);
					child.SetParent(null);
					Object.Destroy(child.gameObject);
				}
			}
			else
			{
				int num2 = count - childCount;
				for (int j = 0; j < num2; j++)
				{
					Object.Instantiate(prefab, parent);
				}
			}
		}

		public static void SetAndCenterToParent(RectTransform element, RectTransform parent)
		{
			element.SetParent(parent);
			element.localPosition = new Vector3(element.localPosition.x, element.localPosition.y, 0f);
			element.localScale = Vector3.one;
			element.localRotation = Quaternion.identity;
			element.anchorMin = new Vector2(0.5f, 0.5f);
			element.anchorMax = new Vector2(0.5f, 0.5f);
			element.pivot = new Vector2(0.5f, 0.5f);
			element.sizeDelta = Vector2.zero;
			element.offsetMin = Vector2.zero;
			element.offsetMax = Vector2.zero;
		}

		public static void SetAndStretchToParentSize(RectTransform element, RectTransform parent)
		{
			element.SetParent(parent);
			element.localPosition = new Vector3(element.localPosition.x, element.localPosition.y, 0f);
			element.localScale = Vector3.one;
			element.localRotation = Quaternion.identity;
			element.anchorMin = new Vector2(0f, 0f);
			element.anchorMax = new Vector2(1f, 1f);
			element.pivot = new Vector2(0.5f, 0.5f);
			element.sizeDelta = Vector2.zero;
			element.offsetMin = Vector2.zero;
			element.offsetMax = Vector2.zero;
		}
	}
}
