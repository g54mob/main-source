using UnityEngine;

namespace GameCreator.Runtime.Common
{
	public static class UIUtils
	{
		public const int LAYER_UI = 5;

		public static GameObject Instantiate(GameObject prefab, RectTransform parent)
		{
			if (prefab == null)
			{
				return null;
			}
			if (parent == null)
			{
				return null;
			}
			GameObject gameObject = Object.Instantiate(prefab, parent);
			RectTransform component = prefab.GetComponent<RectTransform>();
			RectTransform component2 = gameObject.GetComponent<RectTransform>();
			component2.anchorMin = component.anchorMin;
			component2.anchorMax = component.anchorMax;
			component2.pivot = component.pivot;
			component2.offsetMin = component.offsetMin;
			component2.offsetMax = component.offsetMax;
			component2.anchoredPosition = component.anchoredPosition;
			return gameObject;
		}
	}
}
