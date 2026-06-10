using System;
using System.Collections.Generic;
using Lofelt.NiceVibrations;

namespace MoreMountains.FeedbacksForThirdParty
{
	[Serializable]
	public class NVHapticData
	{
		public int SampleCount;

		public HapticClip Clip;

		public List<NVAmplitudePoint> AmplitudePoints;

		public List<NVFrequencyPoint> FrequencyPoints;

		public GamepadRumble RumbleData;
	}
}
