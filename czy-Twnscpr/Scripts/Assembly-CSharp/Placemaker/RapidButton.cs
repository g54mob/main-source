using System;

namespace Placemaker
{
	[Serializable]
	public struct RapidButton
	{
		public int lastFrame;

		public int count;

		public float t;

		public int countThreshold;

		public float slowSpeed;

		public float fastSpeed;

		public static RapidButton undoRedo;

		public static RapidButton palette;

		public static RapidButton uiNavigation;

		public RapidButton(float slowSpeed, float fastSpeed, int countThreshold)
		{
			lastFrame = 0;
			count = 0;
			t = 0f;
			this.countThreshold = 0;
			this.slowSpeed = 0f;
			this.fastSpeed = 0f;
		}

		public bool Press(float intensity = 1f)
		{
			return false;
		}
	}
}
