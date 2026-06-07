using System.Runtime.InteropServices;
using UnityEngine;

namespace MoreMountains.Tools
{
	[StructLayout(LayoutKind.Sequential, Size = 1)]
	public struct MMDebugMenuCheckboxEvent
	{
		public enum EventModes
		{
			FromCheckbox = 0,
			SetCheckbox = 1
		}

		public delegate void Delegate(string checkboxEventName, bool value, EventModes eventMode = EventModes.FromCheckbox);

		private static event Delegate OnEvent;

		[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
		private static void RuntimeInitialization()
		{
			MMDebugMenuCheckboxEvent.OnEvent = null;
		}

		public static void Register(Delegate callback)
		{
			OnEvent += callback;
		}

		public static void Unregister(Delegate callback)
		{
			OnEvent -= callback;
		}

		public static void Trigger(string checkboxEventName, bool value, EventModes eventMode = EventModes.FromCheckbox)
		{
			MMDebugMenuCheckboxEvent.OnEvent?.Invoke(checkboxEventName, value, eventMode);
		}
	}
}
