using UnityEngine;

namespace HighlightPlus
{
	public static class InputProxy
	{
		public static Vector3 mousePosition => default(Vector3);

		public static int touchCount => 0;

		public static void Init()
		{
		}

		public static bool GetMouseButtonDown(int buttonIndex)
		{
			return false;
		}

		public static int GetFingerIdFromTouch(int touchIndex)
		{
			return 0;
		}

		public static bool GetKeyDown(string name)
		{
			return false;
		}
	}
}
