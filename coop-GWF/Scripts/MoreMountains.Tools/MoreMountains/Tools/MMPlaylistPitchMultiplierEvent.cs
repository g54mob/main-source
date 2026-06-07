using System.Runtime.InteropServices;
using UnityEngine;

namespace MoreMountains.Tools
{
	[StructLayout(LayoutKind.Sequential, Size = 1)]
	public struct MMPlaylistPitchMultiplierEvent
	{
		public delegate void Delegate(int channel, float newPitchMultiplier, bool applyPitchMultiplierInstantly = false);

		private static event Delegate OnEvent;

		[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
		private static void RuntimeInitialization()
		{
			MMPlaylistPitchMultiplierEvent.OnEvent = null;
		}

		public static void Register(Delegate callback)
		{
			OnEvent += callback;
		}

		public static void Unregister(Delegate callback)
		{
			OnEvent -= callback;
		}

		public static void Trigger(int channel, float newPitchMultiplier, bool applyPitchMultiplierInstantly = false)
		{
			MMPlaylistPitchMultiplierEvent.OnEvent?.Invoke(channel, newPitchMultiplier, applyPitchMultiplierInstantly);
		}
	}
}
