using System.Runtime.InteropServices;
using UnityEngine;

namespace MoreMountains.Tools
{
	[StructLayout(LayoutKind.Sequential, Size = 1)]
	public struct MMDebugMenuButtonEvent
	{
		public enum EventModes
		{
			FromButton = 0,
			SetButton = 1
		}

		public delegate void Delegate(string buttonEventName, bool active = true, EventModes eventMode = EventModes.FromButton);

		private static event Delegate OnEvent;

		[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
		private static void RuntimeInitialization()
		{
			MMDebugMenuButtonEvent.OnEvent = null;
		}

		public static void Register(Delegate callback)
		{
			OnEvent += callback;
		}

		public static void Unregister(Delegate callback)
		{
			OnEvent -= callback;
		}

		public static void Trigger(string buttonEventName, bool active = true, EventModes eventMode = EventModes.FromButton)
		{
			MMDebugMenuButtonEvent.OnEvent?.Invoke(buttonEventName, active, eventMode);
		}
	}
}
