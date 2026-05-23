using System;
using Unity.Burst;
using Unity.Collections;
using Unity.Jobs;
using Unity.Mathematics;
using UnityEngine;

namespace Pathfinding.Jobs
{
	public struct JobRaycastAll
	{
		[BurstCompile]
		private struct JobCreateCommands : IJobParallelFor
		{
			public NativeArray<RaycastCommand> commands;

			[ReadOnly]
			public NativeArray<RaycastHit> raycastHits;

			public float minStep;

			public PhysicsScene physicsScene;

			public void Execute(int index)
			{
				RaycastHit raycastHit = raycastHits[index];
				if (raycastHit.normal != default(Vector3))
				{
					RaycastCommand raycastCommand = commands[index];
					Vector3 vector = raycastHit.point + raycastCommand.direction.normalized * minStep;
					float distance = raycastCommand.distance - (vector - raycastCommand.from).magnitude;
					QueryParameters queryParameters = new QueryParameters(raycastCommand.queryParameters.layerMask, hitMultipleFaces: false, QueryTriggerInteraction.Ignore);
					commands[index] = new RaycastCommand(physicsScene, vector, raycastCommand.direction, queryParameters, distance);
				}
				else
				{
					commands[index] = new RaycastCommand(physicsScene, Vector3.zero, Vector3.up, new QueryParameters(0, hitMultipleFaces: false, QueryTriggerInteraction.Ignore), 1f);
				}
			}
		}

		[BurstCompile]
		private struct JobCombineResults : IJob
		{
			public int maxHits;

			[ReadOnly]
			public NativeArray<RaycastHit> semiResults;

			public NativeArray<RaycastHit> results;

			public void Execute()
			{
				int num = semiResults.Length / maxHits;
				for (int i = 0; i < num; i++)
				{
					int num2 = 0;
					for (int num3 = maxHits - 1; num3 >= 0; num3--)
					{
						if (math.any(semiResults[i + num3 * num].normal))
						{
							results[i + num2] = semiResults[i + num3 * num];
							num2 += num;
						}
					}
				}
			}
		}

		private int maxHits;

		public readonly float minStep;

		private NativeArray<RaycastHit> results;

		private NativeArray<RaycastHit> semiResults;

		private NativeArray<RaycastCommand> commands;

		public PhysicsScene physicsScene;

		public JobRaycastAll(NativeArray<RaycastCommand> commands, NativeArray<RaycastHit> results, PhysicsScene physicsScene, int maxHits, Allocator allocator, JobDependencyTracker dependencyTracker, float minStep = 0.0001f)
		{
			if (maxHits <= 0)
			{
				throw new ArgumentException("maxHits should be greater than zero");
			}
			if (results.Length < commands.Length * maxHits)
			{
				throw new ArgumentException("Results array length does not match maxHits count");
			}
			if (minStep < 0f)
			{
				throw new ArgumentException("minStep should be more or equal to zero");
			}
			this.results = results;
			this.maxHits = maxHits;
			this.minStep = minStep;
			this.commands = commands;
			this.physicsScene = physicsScene;
			semiResults = dependencyTracker.NewNativeArray<RaycastHit>(maxHits * commands.Length, allocator);
		}

		public JobHandle Schedule(JobHandle dependency)
		{
			for (int i = 0; i < maxHits; i++)
			{
				NativeArray<RaycastHit> subArray = semiResults.GetSubArray(i * commands.Length, commands.Length);
				dependency = RaycastCommand.ScheduleBatch(commands, subArray, 128, dependency);
				if (i < maxHits - 1)
				{
					dependency = IJobParallelForExtensions.Schedule(new JobCreateCommands
					{
						commands = commands,
						raycastHits = subArray,
						minStep = minStep,
						physicsScene = physicsScene
					}, commands.Length, 256, dependency);
				}
			}
			return new JobCombineResults
			{
				semiResults = semiResults,
				maxHits = maxHits,
				results = results
			}.Schedule(dependency);
		}
	}
}
