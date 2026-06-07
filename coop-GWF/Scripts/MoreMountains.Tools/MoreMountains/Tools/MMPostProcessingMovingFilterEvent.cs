using System.Runtime.InteropServices;
using UnityEngine;

namespace MoreMountains.Tools
{
	[StructLayout(LayoutKind.Sequential, Size = 1)]
	public struct MMPostProcessingMovingFilterEvent
	{
		public delegate void Delegate(MMTweenType curve, bool active, bool toggle, float duration, int channel = 0, bool stop = false, bool restore = false);

		private static event Delegate OnEvent;

		[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
		private static void RuntimeInitialization()
		{
			MMPostProcessingMovingFilterEvent.OnEvent = null;
		}

		public static void Register(Delegate callback)
		{
			OnEvent += callback;
		}

		public static void Unregister(Delegate callback)
		{
			OnEvent -= callback;
		}

		public static void Trigger(MMTweenType curve, bool active, bool toggle, float duration, int channel = 0, bool stop = false, bool restore = false)
		{
			MMPostProcessingMovingFilterEvent.OnEvent?.Invoke(curve, active, toggle, duration, channel, stop, restore);
		}
	}
}
