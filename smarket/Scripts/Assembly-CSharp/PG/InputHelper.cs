using UnityEngine;

namespace PG
{
	public static class InputHelper
	{
		private static Touch Touch;

		public static bool InputSupportSplitScreen => false;

		public static bool EscapeWasPresed => false;

		public static int GetGamepadNames(out string[] names)
		{
			names = null;
			return 0;
		}

		public static void EnableAccelerometer()
		{
		}

		public static void DisableAccelerometer()
		{
		}

		public static Vector3 GetAccelerometerData()
		{
			return default(Vector3);
		}

		public static Vector2 GetNearestTouchPosition(Vector2 pos)
		{
			return default(Vector2);
		}
	}
}
