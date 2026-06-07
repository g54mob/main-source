using System.Runtime.InteropServices;
using UnityEngine;

namespace MoreMountains.Tools
{
	[StructLayout(LayoutKind.Sequential, Size = 1)]
	public struct MMPlaylistVolumeMultiplierEvent
	{
		public delegate void Delegate(int channel, float newVolumeMultiplier, bool applyVolumeMultiplierInstantly = false);

		private static event Delegate OnEvent;

		[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
		private static void RuntimeInitialization()
		{
			MMPlaylistVolumeMultiplierEvent.OnEvent = null;
		}

		public static void Register(Delegate callback)
		{
			OnEvent += callback;
		}

		public static void Unregister(Delegate callback)
		{
			OnEvent -= callback;
		}

		public static void Trigger(int channel, float newVolumeMultiplier, bool applyVolumeMultiplierInstantly = false)
		{
			MMPlaylistVolumeMultiplierEvent.OnEvent?.Invoke(channel, newVolumeMultiplier, applyVolumeMultiplierInstantly);
		}
	}
}
