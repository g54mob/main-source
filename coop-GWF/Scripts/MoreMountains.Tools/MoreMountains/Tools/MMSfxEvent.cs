using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.Audio;

namespace MoreMountains.Tools
{
	[StructLayout(LayoutKind.Sequential, Size = 1)]
	public struct MMSfxEvent
	{
		public delegate void Delegate(AudioClip clipToPlay, AudioMixerGroup audioGroup = null, float volume = 1f, float pitch = 1f, int priority = 128);

		private static event Delegate OnEvent;

		[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
		private static void RuntimeInitialization()
		{
			MMSfxEvent.OnEvent = null;
		}

		public static void Register(Delegate callback)
		{
			OnEvent += callback;
		}

		public static void Unregister(Delegate callback)
		{
			OnEvent -= callback;
		}

		public static void Trigger(AudioClip clipToPlay, AudioMixerGroup audioGroup = null, float volume = 1f, float pitch = 1f, int priority = 128)
		{
			MMSfxEvent.OnEvent?.Invoke(clipToPlay, audioGroup, volume, pitch, priority);
		}
	}
}
