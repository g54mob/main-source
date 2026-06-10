using System;

namespace MoreMountains.FeedbacksForThirdParty
{
	[Serializable]
	public class NVAmplitudePoint
	{
		public float time;

		public float amplitude;

		public NVEmphasis emphasis;
	}
}
