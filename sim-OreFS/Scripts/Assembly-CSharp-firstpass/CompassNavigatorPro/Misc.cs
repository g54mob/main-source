using System;
using UnityEngine;

namespace CompassNavigatorPro
{
	public static class Misc
	{
		public static Vector4 Vector4back = new Vector4(0f, 0f, -1f, 0f);

		public static Vector3 Vector3one = Vector3.one;

		public static Vector3 Vector3zero = Vector3.zero;

		public static Vector3 Vector3back = Vector3.back;

		public static Vector3 Vector3left = Vector3.left;

		public static Vector3 Vector3right = Vector3.right;

		public static Vector3 Vector3up = Vector3.up;

		public static Vector3 Vector3down = Vector3.down;

		public static Vector3 Vector3half = new Vector3(0.5f, 0.5f, 0.5f);

		public static Vector2 Vector2left = Vector2.left;

		public static Vector2 Vector2right = Vector2.right;

		public static Vector2 Vector2one = Vector2.one;

		public static Vector2 Vector2zero = Vector2.zero;

		public static Vector2 Vector2down = Vector2.down;

		public static Vector2 Vector2up = Vector2.up;

		public static Vector2 Vector2max = new Vector2(100000f, 100000f);

		public static Vector2 Vector2half = new Vector2(0.5f, 0.5f);

		public static Vector3 ViewportCenter = new Vector3(0.5f, 0.5f, 0f);

		public static Color ColorTransparent = new Color(0f, 0f, 0f, 0f);

		public static Color ColorWhite = Color.white;

		public static Quaternion QuaternionZero = Quaternion.Euler(0f, 0f, 0f);

		private static readonly Vector3[] wc = new Vector3[4];

		public static WaitForSeconds WaitForOneSecond = new WaitForSeconds(1f);

		public static Rect GetScreenRect(this RectTransform o)
		{
			Vector2 vector = Vector2.Scale(o.rect.size, o.lossyScale);
			Rect result = new Rect(o.position.x, o.position.y, vector.x, vector.y);
			result.x -= o.pivot.x * vector.x;
			result.y -= o.pivot.y * vector.y;
			return result;
		}

		public static Rect GetScreenRect(this RectTransform o, Camera camera)
		{
			o.GetWorldCorners(wc);
			return new Rect(wc[0].x, wc[0].y, wc[2].x - wc[0].x, wc[2].y - wc[0].y);
		}

		public static Rect GetViewportRect(this RectTransform o, Camera camera)
		{
			Rect screenRect = o.GetScreenRect(camera);
			screenRect.x /= camera.pixelWidth;
			screenRect.y /= camera.pixelHeight;
			screenRect.width /= camera.pixelWidth;
			screenRect.height /= camera.pixelHeight;
			return screenRect;
		}

		public static T FindObjectOfType<T>(bool includeInactive = false) where T : UnityEngine.Object
		{
			return UnityEngine.Object.FindAnyObjectByType<T>(includeInactive ? FindObjectsInactive.Include : FindObjectsInactive.Exclude);
		}

		public static UnityEngine.Object[] FindObjectsOfType(Type type, bool includeInactive = false)
		{
			return UnityEngine.Object.FindObjectsByType(type, includeInactive ? FindObjectsInactive.Include : FindObjectsInactive.Exclude, FindObjectsSortMode.None);
		}

		public static T[] FindObjectsOfType<T>(bool includeInactive = false) where T : UnityEngine.Object
		{
			return UnityEngine.Object.FindObjectsByType<T>(includeInactive ? FindObjectsInactive.Include : FindObjectsInactive.Exclude, FindObjectsSortMode.None);
		}

		public static void DestroySafe(UnityEngine.Object obj)
		{
			UnityEngine.Object.Destroy(obj);
		}
	}
}
