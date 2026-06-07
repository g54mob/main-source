using Unity.Burst;
using Unity.Collections;
using Unity.Jobs;
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
			this.maxHits = 0;
			this.minStep = 0f;
			this.results = default(NativeArray<RaycastHit>);
			semiResults = default(NativeArray<RaycastHit>);
			this.commands = default(NativeArray<RaycastCommand>);
			this.physicsScene = default(PhysicsScene);
		}

		public JobHandle Schedule(JobHandle dependency)
		{
			return default(JobHandle);
		}
	}
}
