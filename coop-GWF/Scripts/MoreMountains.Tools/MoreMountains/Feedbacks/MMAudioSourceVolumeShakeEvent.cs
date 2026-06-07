using System.Runtime.InteropServices;
using UnityEngine;

namespace MoreMountains.Feedbacks
{
	[StructLayout(LayoutKind.Sequential, Size = 1)]
	public struct MMAudioSourceVolumeShakeEvent
	{
		public delegate void Delegate(AnimationCurve volumeCurve, float duration, float remapMin, float remapMax, bool relativeVolume = false, float feedbacksIntensity = 1f, MMChannelData channelData = null, bool resetShakerValuesAfterShake = true, bool resetTargetValuesAfterShake = true, bool forwardDirection = true, TimescaleModes timescaleMode = TimescaleModes.Scaled, bool stop = false, bool restore = false);

		private static event Delegate OnEvent;

		[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
		private static void RuntimeInitialization()
		{
			MMAudioSourceVolumeShakeEvent.OnEvent = null;
		}

		public static void Register(Delegate callback)
		{
			OnEvent += callback;
		}

		public static void Unregister(Delegate callback)
		{
			OnEvent -= callback;
		}

		public static void Trigger(AnimationCurve volumeCurve, float duration, float remapMin, float remapMax, bool relativeVolume = false, float feedbacksIntensity = 1f, MMChannelData channelData = null, bool resetShakerValuesAfterShake = true, bool resetTargetValuesAfterShake = true, bool forwardDirection = true, TimescaleModes timescaleMode = TimescaleModes.Scaled, bool stop = false, bool restore = false)
		{
			MMAudioSourceVolumeShakeEvent.OnEvent?.Invoke(volumeCurve, duration, remapMin, remapMax, relativeVolume, feedbacksIntensity, channelData, resetShakerValuesAfterShake, resetTargetValuesAfterShake, forwardDirection, timescaleMode, stop, restore);
		}
	}
}
