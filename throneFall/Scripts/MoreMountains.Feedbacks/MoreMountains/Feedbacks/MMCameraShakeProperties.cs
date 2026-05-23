using System;

namespace MoreMountains.Feedbacks
{
	[Serializable]
	public struct MMCameraShakeProperties
	{
		public float Duration;

		public float Amplitude;

		public float Frequency;

		public float AmplitudeX;

		public float AmplitudeY;

		public float AmplitudeZ;

		public MMCameraShakeProperties(float duration, float amplitude, float frequency, float amplitudeX = 0f, float amplitudeY = 0f, float amplitudeZ = 0f)
		{
			Duration = duration;
			Amplitude = amplitude;
			Frequency = frequency;
			AmplitudeX = amplitudeX;
			AmplitudeY = amplitudeY;
			AmplitudeZ = amplitudeZ;
		}
	}
}
