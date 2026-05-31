using UnityEngine;

namespace ShellanderGames.WeaponWheel
{
	public static class SgMiscUtil
	{
		public static void AnchorTo(RectTransform rectTransform, Transform transform)
		{
		}

		public static float Angle(float x, float y)
		{
			return 0f;
		}

		public static float Angle(Vector2 point)
		{
			return 0f;
		}

		public static void CleanupComponentObjects<T>(GameObject container, bool calledFromEditor) where T : Component
		{
		}

		public static GameObject CreateUiObject(string name, Transform defaultParent)
		{
			return null;
		}

		public static long CurrentTimeMs()
		{
			return 0L;
		}

		public static Vector2 GetPointInCircle(Vector2 center, float radius, float ratio)
		{
			return default(Vector2);
		}

		public static T LazyComponent<T>(Component component, ref T localReference) where T : Component
		{
			return null;
		}

		public static T[] LazyComponents<T>(Component component, ref T[] localReference) where T : Component
		{
			return null;
		}

		public static T LazyParentComponent<T>(Component component, ref T localReference) where T : Component
		{
			return null;
		}
	}
}
