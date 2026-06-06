using UnityEngine;

namespace MagicaCloth2
{
	public class SimpleInput
	{
		public static int touchCount => 0;

		public static Vector3 mousePosition => default(Vector3);

		public static void Init()
		{
		}

		public static Touch GetTouch(int index)
		{
			return default(Touch);
		}

		public static bool GetKey(KeyCode key)
		{
			return false;
		}

		public static bool GetKeyDown(KeyCode key)
		{
			return false;
		}

		public static bool GetMouseButtonDown(int button)
		{
			return false;
		}

		public static bool GetMouseButtonUp(int button)
		{
			return false;
		}

		public static float GetMouseScrollWheel()
		{
			return 0f;
		}
	}
}
