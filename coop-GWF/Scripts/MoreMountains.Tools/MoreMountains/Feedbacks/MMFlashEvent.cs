using System.Runtime.InteropServices;
using UnityEngine;

namespace MoreMountains.Feedbacks
{
	[StructLayout(LayoutKind.Sequential, Size = 1)]
	public struct MMFlashEvent
	{
		public delegate void Delegate(Color flashColor, float duration, float alpha, int flashID, MMChannelData channelData, TimescaleModes timescaleMode, bool stop = false);

		private static event Delegate OnEvent;

		[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
		private static void RuntimeInitialization()
		{
			MMFlashEvent.OnEvent = null;
		}

		public static void Register(Delegate callback)
		{
			OnEvent += callback;
		}

		public static void Unregister(Delegate callback)
		{
			OnEvent -= callback;
		}

		public static void Trigger(Color flashColor, float duration, float alpha, int flashID, MMChannelData channelData, TimescaleModes timescaleMode, bool stop = false)
		{
			MMFlashEvent.OnEvent?.Invoke(flashColor, duration, alpha, flashID, channelData, timescaleMode, stop);
		}
	}
}
