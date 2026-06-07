using Pathfinding.Util;
using Unity.Burst;
using Unity.Collections;
using Unity.Jobs;
using UnityEngine;

namespace Pathfinding.Graphs.Grid.Rules
{
	[Preserve]
	public class RuleElevationPenalty : GridGraphRule
	{
		[BurstCompile(FloatMode = FloatMode.Fast)]
		public struct JobElevationPenalty : IJob
		{
			[ReadOnly]
			public NativeArray<float> elevationToPenalty;

			[ReadOnly]
			public NativeArray<Vector3> nodePositions;

			public Matrix4x4 worldToGraph;

			public NativeArray<uint> penalty;

			public void Execute()
			{
			}
		}

		public float penaltyScale;

		public Vector2 elevationRange;

		public AnimationCurve curve;

		private NativeArray<float> elevationToPenalty;

		public override void Register(GridGraphRules rules)
		{
		}

		public override void DisposeUnmanagedData()
		{
		}
	}
}
