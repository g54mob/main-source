using System.Runtime.InteropServices;
using UnityEngine;

namespace MoreMountains.Feedbacks
{
	[StructLayout(LayoutKind.Sequential, Size = 1)]
	public struct MMFeedbacksEvent
	{
		public enum EventTypes
		{
			Play = 0,
			Pause = 1,
			Resume = 2,
			ChangeDirection = 3,
			Complete = 4,
			SkipToTheEnd = 5,
			RestoreInitialValues = 6,
			Loop = 7,
			Enable = 8,
			Disable = 9,
			InitializationComplete = 10,
			Stop = 11
		}

		public delegate void Delegate(MMFeedbacks source, EventTypes type);

		private static event Delegate OnEvent;

		[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
		private static void RuntimeInitialization()
		{
			MMFeedbacksEvent.OnEvent = null;
		}

		public static void Register(Delegate callback)
		{
			OnEvent += callback;
		}

		public static void Unregister(Delegate callback)
		{
			OnEvent -= callback;
		}

		public static void Trigger(MMFeedbacks source, EventTypes type)
		{
			MMFeedbacksEvent.OnEvent?.Invoke(source, type);
		}
	}
}
