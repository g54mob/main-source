using System.Runtime.InteropServices;
using UnityEngine;

namespace MoreMountains.Feedbacks
{
	[StructLayout(LayoutKind.Sequential, Size = 1)]
	public struct MMFreezeFrameEvent
	{
		public delegate void Delegate(float duration);

		private static event Delegate OnEvent;

		[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
		private static void RuntimeInitialization()
		{
			MMFreezeFrameEvent.OnEvent = null;
		}

		public static void Register(Delegate callback)
		{
			OnEvent += callback;
		}

		public static void Unregister(Delegate callback)
		{
			OnEvent -= callback;
		}

		public static void Trigger(float duration)
		{
			MMFreezeFrameEvent.OnEvent?.Invoke(duration);
		}
	}
}
