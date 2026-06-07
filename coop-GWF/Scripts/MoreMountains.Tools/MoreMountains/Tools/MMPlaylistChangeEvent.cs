using System.Runtime.InteropServices;
using UnityEngine;

namespace MoreMountains.Tools
{
	[StructLayout(LayoutKind.Sequential, Size = 1)]
	public struct MMPlaylistChangeEvent
	{
		public delegate void Delegate(int channel, MMSMPlaylist newPlaylist, bool andPlay);

		private static event Delegate OnEvent;

		[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
		private static void RuntimeInitialization()
		{
			MMPlaylistChangeEvent.OnEvent = null;
		}

		public static void Register(Delegate callback)
		{
			OnEvent += callback;
		}

		public static void Unregister(Delegate callback)
		{
			OnEvent -= callback;
		}

		public static void Trigger(int channel, MMSMPlaylist newPlaylist, bool andPlay)
		{
			MMPlaylistChangeEvent.OnEvent?.Invoke(channel, newPlaylist, andPlay);
		}
	}
}
