using System;
using System.Collections.Generic;

namespace MoreMountains.FeedbacksForThirdParty
{
	[Serializable]
	public class NVEnvelopes
	{
		public List<NVAmplitudePoint> amplitude;

		public List<NVFrequencyPoint> frequency;
	}
}
