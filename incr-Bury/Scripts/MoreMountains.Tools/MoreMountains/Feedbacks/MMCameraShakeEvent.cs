using System.Runtime.InteropServices;
using UnityEngine;

namespace MoreMountains.Feedbacks
{
	[StructLayout(LayoutKind.Sequential, Size = 1)]
	public struct MMCameraShakeEvent
	{
		public delegate void Delegate(float duration, float amplitude, float frequency, float amplitudeX, float amplitudeY, float amplitudeZ, bool infinite = false, MMChannelData channelData = null, bool useUnscaledTime = false);

		private static event Delegate OnEvent;

		[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
		private static void RuntimeInitialization()
		{
			MMCameraShakeEvent.OnEvent = null;
		}

		public static void Register(Delegate callback)
		{
			OnEvent += callback;
		}

		public static void Unregister(Delegate callback)
		{
			OnEvent -= callback;
		}

		public static void Trigger(float duration, float amplitude, float frequency, float amplitudeX, float amplitudeY, float amplitudeZ, bool infinite = false, MMChannelData channelData = null, bool useUnscaledTime = false)
		{
			MMCameraShakeEvent.OnEvent?.Invoke(duration, amplitude, frequency, amplitudeX, amplitudeY, amplitudeZ, infinite, channelData, useUnscaledTime);
		}
	}
}
