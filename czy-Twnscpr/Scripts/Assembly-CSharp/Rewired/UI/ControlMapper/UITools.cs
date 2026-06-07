using UnityEngine;
using UnityEngine.UI;

namespace Rewired.UI.ControlMapper
{
	public static class UITools
	{
		public static GameObject InstantiateGUIObject<T>(GameObject prefab, Transform parent, string name) where T : Component
		{
			return null;
		}

		public static GameObject InstantiateGUIObject<T>(GameObject prefab, Transform parent, string name, Vector2 pivot, Vector2 anchorMin, Vector2 anchorMax, Vector2 anchoredPosition) where T : Component
		{
			return null;
		}

		private static GameObject InstantiateGUIObject_Pre<T>(GameObject prefab, Transform parent, string name) where T : Component
		{
			return null;
		}

		public static Vector3 GetPointOnRectEdge(RectTransform rectTransform, Vector2 dir)
		{
			return default(Vector3);
		}

		public static Rect GetWorldSpaceRect(RectTransform rt)
		{
			return default(Rect);
		}

		public static Rect TransformRectTo(Transform from, Transform to, Rect rect)
		{
			return default(Rect);
		}

		public static Rect InvertY(Rect rect)
		{
			return default(Rect);
		}

		public static void SetInteractable(Selectable selectable, bool state, bool playTransition)
		{
		}
	}
}
