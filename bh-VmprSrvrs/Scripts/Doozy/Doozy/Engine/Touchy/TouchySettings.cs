using System;
using UnityEngine;

namespace Doozy.Engine.Touchy
{
	[Serializable]
	public class TouchySettings : ScriptableObject
	{
		public const string FILE_NAME = "TouchySettings";

		private static TouchySettings s_instance;

		public const float LONG_TAP_DURATION_DEFAULT_VALUE = 0.4f;

		public const float LONG_TAP_DURATION_MAX = 1f;

		public const float LONG_TAP_DURATION_MIN = 0.2f;

		public const float SWIPE_LENGTH_DEFAULT_VALUE = 2f;

		public const float SWIPE_LENGTH_MAX = 200f;

		public const float SWIPE_LENGTH_MIN = 0.1f;

		public float LongTapDuration;

		[Range(0.1f, 200f)]
		public float SwipeLength;

		private static string ResourcesPath => null;

		public static TouchySettings Instance => null;

		private void Reset()
		{
		}

		public void Reset(bool saveAssets)
		{
		}

		public void SetDirty(bool saveAssets)
		{
		}

		public void UndoRecord(string undoMessage)
		{
		}
	}
}
