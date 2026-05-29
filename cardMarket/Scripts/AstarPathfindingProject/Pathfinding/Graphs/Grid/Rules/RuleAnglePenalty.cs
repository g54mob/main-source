using System;
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
				float4 y = new float4(up.x, up.y, up.z, 0f);
				for (int i = 0; i < penalty.Length; i++)
				{
					float4 x = nodeNormals[i];
					if (math.any(x))
					{
						float num = math.acos(math.dot(x, y)) * (float)(angleToPenalty.Length - 1) / MathF.PI;
						int num2 = (int)num;
						float x2 = angleToPenalty[math.max(num2, 0)];
						float y2 = angleToPenalty[math.min(num2 + 1, angleToPenalty.Length - 1)];
						penalty[i] += (uint)math.lerp(x2, y2, num - (float)num2);
					}
				}
			}
		}

		public float penaltyScale = 10000f;

		public AnimationCurve curve = AnimationCurve.Linear(0f, 0f, 90f, 1f);

		private NativeArray<float> angleToPenalty;

		public override void Register(GridGraphRules rules)
		{
			if (!angleToPenalty.IsCreated)
			{
				angleToPenalty = new NativeArray<float>(32, Allocator.Persistent, NativeArrayOptions.UninitializedMemory);
			}
			for (int i = 0; i < angleToPenalty.Length; i++)
			{
				angleToPenalty[i] = Mathf.Max(0f, curve.Evaluate(90f * (float)i / (float)(angleToPenalty.Length - 1)) * penaltyScale);
			}
			rules.AddJobSystemPass(Pass.BeforeConnections, delegate(GridGraphRules.Context context)
			{
				new JobPenaltyAngle
				{
					angleToPenalty = angleToPenalty,
					up = context.data.up,
					nodeNormals = context.data.nodes.normals,
					penalty = context.data.nodes.penalties
				}.Schedule(context.tracker);
			});
		}

		public override void DisposeUnmanagedData()
		{
			if (angleToPenalty.IsCreated)
			{
				angleToPenalty.Dispose();
			}
		}
	}
}
