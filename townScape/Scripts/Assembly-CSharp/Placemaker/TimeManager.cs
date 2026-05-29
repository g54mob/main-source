using System;

namespace Placemaker
{
	[Serializable]
	public static class TimeManager
	{
		private static float _dimScale;

		private static bool _slowmo;

		public static float slowmoScale => 0f;

		public static float dimScale
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public static bool slowmo
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public static void SetDimScale(float scale)
		{
		}

		public static void SetRecordingScale(float scale)
		{
		}

		private static void UpdateTime()
		{
		}
	}
}
