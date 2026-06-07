using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnityEngine;

namespace MoreMountains.Feedbacks
{
	[StructLayout((LayoutKind)0, Size = 1)]
	public struct MMF_PlayerEvent
	{
		public enum EventTypes
		{
			Play = 0,
			Pause = 1,
			Resume = 2,
			Revert = 3,
			Complete = 4
		}

		public delegate void Delegate(MMF_Player source, EventTypes type);

		private static event Delegate OnEvent
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
		private static void RuntimeInitialization()
		{
		}

		public static void Register(Delegate callback)
		{
		}

		public static void Unregister(Delegate callback)
		{
		}

		public static void Trigger(MMF_Player source, EventTypes type)
		{
		}
	}
}
