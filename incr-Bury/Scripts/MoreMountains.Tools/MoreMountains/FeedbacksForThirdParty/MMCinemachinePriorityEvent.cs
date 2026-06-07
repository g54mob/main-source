using System.Runtime.InteropServices;
using MoreMountains.Feedbacks;
using Unity.Cinemachine;
using UnityEngine;

namespace MoreMountains.FeedbacksForThirdParty
{
	[StructLayout(LayoutKind.Sequential, Size = 1)]
	public struct MMCinemachinePriorityEvent
	{
		public delegate void Delegate(MMChannelData channelData, bool forceMaxPriority, int newPriority, bool forceTransition, CinemachineBlendDefinition blendDefinition, bool resetValuesAfterTransition, TimescaleModes timescaleMode, bool restore = false);

		private static event Delegate OnEvent;

		[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
		private static void RuntimeInitialization()
		{
			MMCinemachinePriorityEvent.OnEvent = null;
		}

		public static void Register(Delegate callback)
		{
			OnEvent += callback;
		}

		public static void Unregister(Delegate callback)
		{
			OnEvent -= callback;
		}

		public static void Trigger(MMChannelData channelData, bool forceMaxPriority, int newPriority, bool forceTransition, CinemachineBlendDefinition blendDefinition, bool resetValuesAfterTransition, TimescaleModes timescaleMode, bool restore = false)
		{
			MMCinemachinePriorityEvent.OnEvent?.Invoke(channelData, forceMaxPriority, newPriority, forceTransition, blendDefinition, resetValuesAfterTransition, timescaleMode, restore);
		}
	}
}
