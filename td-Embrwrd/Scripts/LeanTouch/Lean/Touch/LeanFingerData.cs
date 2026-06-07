using System.Collections.Generic;

namespace Lean.Touch
{
	public abstract class LeanFingerData
	{
		public LeanFinger Finger;

		public static int Count<T>(List<T> fingerDatas) where T : LeanFingerData
		{
			return 0;
		}

		public static bool Exists<T>(List<T> fingerDatas, LeanFinger finger) where T : LeanFingerData
		{
			return false;
		}

		public static void Remove<T>(List<T> fingerDatas, LeanFinger finger, Stack<T> pool = null) where T : LeanFingerData
		{
		}

		public static void RemoveAll<T>(List<T> fingerDatas, Stack<T> pool = null) where T : LeanFingerData
		{
		}

		public static T Find<T>(List<T> fingerDatas, LeanFinger finger) where T : LeanFingerData
		{
			return null;
		}

		public static T FindOrCreate<T>(ref List<T> fingerDatas, LeanFinger finger) where T : LeanFingerData, new()
		{
			return null;
		}
	}
}
