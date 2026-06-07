using System.Runtime.InteropServices;
using UnityEngine;

namespace MoreMountains.Tools
{
	[StructLayout(LayoutKind.Sequential, Size = 1)]
	public struct MMPlaylistStopEvent
	{
		public delegate void Delegate(int channel);

		private static event Delegate OnEvent;

		[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
		private static void RuntimeInitialization()
		{
			MMPlaylistStopEvent.OnEvent = null;
		}

		public static void Register(Delegate callback)
		{
			OnEvent += callback;
		}

		public static void Unregister(Delegate callback)
		{
			OnEvent -= callback;
		}

		public static void Trigger(int channel)
		{
			MMPlaylistStopEvent.OnEvent?.Invoke(channel);
		}
	}
}
