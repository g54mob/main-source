using System.Collections.Generic;
using System.Runtime.InteropServices;
using Pathfinding.Pooling;
using Unity.Collections;
using Unity.Jobs;
using UnityEngine;

namespace Pathfinding.Jobs
{
	public class JobDependencyTracker : IAstarPooledObject
	{
		internal struct JobInstance
		{
			public JobHandle handle;

			public int hash;
		}

		internal struct NativeArraySlot
		{
			public long hash;

			public JobInstance lastWrite;

			public List<JobInstance> lastReads;

			public bool initialized;

			public bool hasWrite;
		}

		private struct JobRaycastCommandDummy : IJob
		{
			[ReadOnly]
			public NativeArray<RaycastCommand> commands;

			[WriteOnly]
			public NativeArray<RaycastHit> results;

			public void Execute()
			{
			}
		}

		private struct JobSpherecastCommandDummy : IJob
		{
			[ReadOnly]
			public NativeArray<SpherecastCommand> commands;

			[WriteOnly]
			public NativeArray<RaycastHit> results;

			public void Execute()
			{
			}
		}

		private struct JobOverlapCapsuleCommandDummy : IJob
		{
			[ReadOnly]
			public NativeArray<OverlapCapsuleCommand> commands;

			[WriteOnly]
			public NativeArray<ColliderHit> results;

			public void Execute()
			{
			}
		}

		private struct JobOverlapSphereCommandDummy : IJob
		{
			[ReadOnly]
			public NativeArray<OverlapSphereCommand> commands;

			[WriteOnly]
			public NativeArray<ColliderHit> results;

			public void Execute()
			{
			}
		}

		internal List<NativeArraySlot> slots;

		private DisposeArena arena;

		internal NativeArray<JobHandle> dependenciesScratchBuffer;

		private LinearDependencies linearDependencies;

		internal TimeSlice timeSlice;

		public bool forceLinearDependencies => false;

		public JobHandle AllWritesDependency => default(JobHandle);

		private bool supportsMultithreading => false;

		public void SetLinearDependencies(bool linearDependencies)
		{
		}

		public NativeArray<T> NewNativeArray<T>(int length, Allocator allocator, NativeArrayOptions options = NativeArrayOptions.ClearMemory) where T : struct
		{
			return default(NativeArray<T>);
		}

		public void Track<T>(NativeArray<T> array, bool initialized = true) where T : struct
		{
		}

		public void Persist<T>(NativeArray<T> array) where T : struct
		{
		}

		public JobHandle ScheduleBatch(NativeArray<RaycastCommand> commands, NativeArray<RaycastHit> results, int minCommandsPerJob)
		{
			return default(JobHandle);
		}

		public JobHandle ScheduleBatch(NativeArray<SpherecastCommand> commands, NativeArray<RaycastHit> results, int minCommandsPerJob)
		{
			return default(JobHandle);
		}

		public JobHandle ScheduleBatch(NativeArray<OverlapCapsuleCommand> commands, NativeArray<ColliderHit> results, int minCommandsPerJob)
		{
			return default(JobHandle);
		}

		public JobHandle ScheduleBatch(NativeArray<OverlapSphereCommand> commands, NativeArray<ColliderHit> results, int minCommandsPerJob)
		{
			return default(JobHandle);
		}

		public void DeferFree(GCHandle handle, JobHandle dependsOn)
		{
		}

		internal void JobReadsFrom(JobHandle job, long nativeArrayHash, int jobHash)
		{
		}

		internal void JobWritesTo(JobHandle job, long nativeArrayHash, int jobHash)
		{
		}

		private void Dispose()
		{
		}

		public void ClearMemory()
		{
		}

		void IAstarPooledObject.OnEnterPool()
		{
		}
	}
}
