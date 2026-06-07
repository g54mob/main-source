using Pathfinding.Util;
using Unity.Burst;
using Unity.Collections;
using Unity.Jobs;
using Unity.Mathematics;
using UnityEngine;

namespace Pathfinding.Graphs.Grid.Rules
{
	[Preserve]
	public class RuleAnglePenalty : GridGraphRule
	{
		[BurstCompile(FloatMode = FloatMode.Fast)]
		public struct JobPenaltyAngle : IJob
		{
			public Vector3 up;

			[ReadOnly]
			public NativeArray<float> angleToPenalty;

			[ReadOnly]
			public NativeArray<float4> nodeNormals;

			public NativeArray<uint> penalty;

			public void Execute()
			{
			}
		}

		public float penaltyScale;

		public AnimationCurve curve;

		private NativeArray<float> angleToPenalty;

		public override void Register(GridGraphRules rules)
		{
		}

		public override void DisposeUnmanagedData()
		{
		}
	}
}
