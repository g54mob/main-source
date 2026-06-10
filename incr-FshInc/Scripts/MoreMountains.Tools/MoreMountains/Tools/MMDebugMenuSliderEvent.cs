using System.Runtime.InteropServices;
using UnityEngine;

namespace MoreMountains.Tools
{
	[StructLayout(LayoutKind.Sequential, Size = 1)]
	public struct MMDebugMenuSliderEvent
	{
		public enum EventModes
		{
			FromSlider = 0,
			SetSlider = 1
		}

		public delegate void Delegate(string sliderEventName, float value, EventModes eventMode = EventModes.FromSlider);

		private static event Delegate OnEvent;

		[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
		private static void RuntimeInitialization()
		{
			MMDebugMenuSliderEvent.OnEvent = null;
		}

		public static void Register(Delegate callback)
		{
			OnEvent += callback;
		}

		public static void Unregister(Delegate callback)
		{
			OnEvent -= callback;
		}

		public static void Trigger(string sliderEventName, float value, EventModes eventMode = EventModes.FromSlider)
		{
			MMDebugMenuSliderEvent.OnEvent?.Invoke(sliderEventName, value, eventMode);
		}
	}
}
