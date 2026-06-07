using System.Runtime.InteropServices;
using UnityEngine;

namespace MoreMountains.Feedbacks
{
	[StructLayout(LayoutKind.Sequential, Size = 1)]
	public struct MMAudioSourcePitchShakeEvent
	{
		public delegate void Delegate(AnimationCurve pitchCurve, float duration, float remapMin, float remapMax, bool relativePitch = false, float feedbacksIntensity = 1f, MMChannelData channelData = null, bool resetShakerValuesAfterShake = true, bool resetTargetValuesAfterShake = true, bool forwardDirection = true, TimescaleModes timescaleMode = TimescaleModes.Scaled, bool stop = false, bool restore = false);

		private static event Delegate OnEvent;

		[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
		private static void RuntimeInitialization()
		{
			MMAudioSourcePitchShakeEvent.OnEvent = null;
		}

		public static void Register(Delegate callback)
		{
			OnEvent += callback;
		}

		public static void Unregister(Delegate callback)
		{
			OnEvent -= callback;
		}

		public static void Trigger(AnimationCurve pitchCurve, float duration, float remapMin, float remapMax, bool relativePitch = false, float feedbacksIntensity = 1f, MMChannelData channelData = null, bool resetShakerValuesAfterShake = true, bool resetTargetValuesAfterShake = true, bool forwardDirection = true, TimescaleModes timescaleMode = TimescaleModes.Scaled, bool stop = false, bool restore = false)
		{
			MMAudioSourcePitchShakeEvent.OnEvent?.Invoke(pitchCurve, duration, remapMin, remapMax, relativePitch, feedbacksIntensity, channelData, resetShakerValuesAfterShake, resetTargetValuesAfterShake, forwardDirection, timescaleMode, stop, restore);
		}
	}
}
