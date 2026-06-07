using Pathfinding.Jobs;
using Pathfinding.Util;
using Unity.Burst;
using Unity.Collections;
using Unity.Jobs;
using Unity.Mathematics;
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
				for (int i = 0; i < penalty.Length; i++)
				{
					float num = math.clamp(worldToGraph.MultiplyPoint3x4(nodePositions[i]).y, 0f, 1f) * (float)(elevationToPenalty.Length - 1);
					int num2 = (int)num;
					float x = elevationToPenalty[num2];
					float y = elevationToPenalty[math.min(num2 + 1, elevationToPenalty.Length - 1)];
					penalty[i] += (uint)math.lerp(x, y, num - (float)num2);
				}
			}
		}

		public float penaltyScale = 10000f;

		public Vector2 elevationRange = new Vector2(0f, 100f);

		public AnimationCurve curve = AnimationCurve.Linear(0f, 0f, 1f, 1f);

		private NativeArray<float> elevationToPenalty;

		public override void Register(GridGraphRules rules)
		{
			if (!elevationToPenalty.IsCreated)
			{
				elevationToPenalty = new NativeArray<float>(64, Allocator.Persistent, NativeArrayOptions.UninitializedMemory);
			}
			for (int i = 0; i < elevationToPenalty.Length; i++)
			{
				elevationToPenalty[i] = Mathf.Max(0f, penaltyScale * curve.Evaluate((float)i * 1f / (float)(elevationToPenalty.Length - 1)));
			}
			Vector2 clampedElevationRange = new Vector2(math.max(0f, elevationRange.x), math.max(1f, elevationRange.y));
			rules.AddJobSystemPass(Pass.BeforeConnections, delegate(GridGraphRules.Context context)
			{
				Matrix4x4 matrix4x = Matrix4x4.Scale(new Vector3(1f, 1f / (clampedElevationRange.y - clampedElevationRange.x), 1f)) * Matrix4x4.Translate(new Vector3(0f, 0f - clampedElevationRange.x, 0f));
				new JobElevationPenalty
				{
					elevationToPenalty = elevationToPenalty,
					nodePositions = context.data.nodes.positions,
					worldToGraph = matrix4x * context.data.transform.matrix.inverse,
					penalty = context.data.nodes.penalties
				}.Schedule(context.tracker);
			});
		}

		public override void DisposeUnmanagedData()
		{
			if (elevationToPenalty.IsCreated)
			{
				elevationToPenalty.Dispose();
			}
		}
	}
}
