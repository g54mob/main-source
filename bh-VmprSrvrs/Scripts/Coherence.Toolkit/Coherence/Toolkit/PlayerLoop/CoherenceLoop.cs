using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.LowLevel;

namespace Coherence.Toolkit.PlayerLoop
{
	internal static class CoherenceLoop
	{
		internal class BridgeList<T> where T : ICoherenceBridge
		{
			private readonly List<T> bridges;

			private readonly List<T> toAdd;

			private readonly List<T> toRemove;

			public void QueueAdd(T bridge)
			{
			}

			public void QueueRemove(T bridge)
			{
			}

			public void Clear()
			{
			}

			public IReadOnlyList<T> Resolve()
			{
				return null;
			}
		}

		private static class UpdateFunctions
		{
			public static readonly PlayerLoopSystem.UpdateFunction ReceiveFromNetwork;

			public static readonly PlayerLoopSystem.UpdateFunction InterpolateUpdate;

			public static readonly PlayerLoopSystem.UpdateFunction InterpolateFixedUpdate;

			public static readonly PlayerLoopSystem.UpdateFunction InterpolateLateUpdate;

			public static readonly PlayerLoopSystem.UpdateFunction SampleUpdate;

			public static readonly PlayerLoopSystem.UpdateFunction SampleFixedUpdate;

			public static readonly PlayerLoopSystem.UpdateFunction SampleLateUpdate;

			public static readonly PlayerLoopSystem.UpdateFunction SyncAndSend;
		}

		internal static class CoherenceSender
		{
			internal static void SyncAndSend()
			{
			}
		}

		internal static class CoherenceInterpolation
		{
			internal static void InterpolateUpdate()
			{
			}

			internal static void InterpolateFixedUpdate()
			{
			}

			internal static void InterpolateLateUpdate()
			{
			}

			private static void Interpolate(CoherenceSync.InterpolationLoop interpolationLoop)
			{
			}
		}

		internal static class CoherenceSampler
		{
			internal static void SampleUpdate()
			{
			}

			internal static void SampleFixedUpdate()
			{
			}

			internal static void SampleLateUpdate()
			{
			}

			private static void Sample(CoherenceSync.InterpolationLoop loop)
			{
			}
		}

		internal static class CoherenceReceiver
		{
			internal static void ReceiveFromNetwork()
			{
			}
		}

		private static readonly BridgeList<CoherenceBridge> Bridges;

		[RuntimeInitializeOnLoadMethod]
		public static void Inject()
		{
		}

		private static void InsertBeforeCallback(PlayerLoopSystem[] systems, Type loopType, Type stepType, Type callbackType, PlayerLoopSystem.UpdateFunction callback)
		{
		}

		private static void InsertAfterCallback(PlayerLoopSystem[] systems, Type loopType, Type stepType, Type callbackType, PlayerLoopSystem.UpdateFunction callback)
		{
		}

		public static void AddBridge(CoherenceBridge bridge)
		{
		}

		public static void RemoveBridge(CoherenceBridge bridge)
		{
		}
	}
}
