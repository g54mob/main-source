using System.Collections.Generic;
using System.Runtime.InteropServices;
using Pathfinding.Util;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Jobs;
using Unity.Jobs.LowLevel.Unsafe;
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

		internal List<NativeArraySlot> slots = ListPool<NativeArraySlot>.Claim();

		private DisposeArena arena;

		internal NativeArray<JobHandle> dependenciesScratchBuffer;

		private LinearDependencies linearDependencies;

		internal TimeSlice timeSlice = TimeSlice.Infinite;

		public bool forceLinearDependencies
		{
			get
			{
				if (linearDependencies == LinearDependencies.Check)
				{
					SetLinearDependencies(linearDependencies: false);
				}
				return linearDependencies == LinearDependencies.Enabled;
			}
		}

		public JobHandle AllWritesDependency
		{
			get
			{
				NativeArray<JobHandle> jobs = new NativeArray<JobHandle>(slots.Count, Allocator.Temp);
				for (int i = 0; i < slots.Count; i++)
				{
					jobs[i] = slots[i].lastWrite.handle;
				}
				JobHandle result = JobHandle.CombineDependencies(jobs);
				jobs.Dispose();
				return result;
			}
		}

		private bool supportsMultithreading => JobsUtility.JobWorkerCount > 0;

		public void SetLinearDependencies(bool linearDependencies)
		{
			if (!supportsMultithreading)
			{
				linearDependencies = true;
			}
			if (linearDependencies)
			{
				AllWritesDependency.Complete();
			}
			this.linearDependencies = (linearDependencies ? LinearDependencies.Enabled : LinearDependencies.Disabled);
		}

		public NativeArray<T> NewNativeArray<T>(int length, Allocator allocator, NativeArrayOptions options = NativeArrayOptions.ClearMemory) where T : unmanaged
		{
			NativeArray<T> nativeArray = new NativeArray<T>(length, allocator, options);
			Track(nativeArray, options == NativeArrayOptions.ClearMemory);
			return nativeArray;
		}

		public unsafe void Track<T>(NativeArray<T> array, bool initialized = true) where T : unmanaged
		{
			slots.Add(new NativeArraySlot
			{
				hash = (long)NativeArrayUnsafeUtility.GetUnsafeBufferPointerWithoutChecks(array),
				lastWrite = default(JobInstance),
				lastReads = ListPool<JobInstance>.Claim(),
				initialized = initialized
			});
			if (arena == null)
			{
				arena = new DisposeArena();
			}
			arena.Add(array);
		}

		public void Persist<T>(NativeArray<T> array) where T : unmanaged
		{
			if (arena != null)
			{
				arena.Remove(array);
			}
		}

		public JobHandle ScheduleBatch(NativeArray<RaycastCommand> commands, NativeArray<RaycastHit> results, int minCommandsPerJob)
		{
			if (forceLinearDependencies)
			{
				RaycastCommand.ScheduleBatch(commands, results, minCommandsPerJob).Complete();
				return default(JobHandle);
			}
			JobRaycastCommandDummy data = new JobRaycastCommandDummy
			{
				commands = commands,
				results = results
			};
			JobHandle dependencies = JobDependencyAnalyzer<JobRaycastCommandDummy>.GetDependencies(ref data, this);
			JobHandle jobHandle = RaycastCommand.ScheduleBatch(commands, results, minCommandsPerJob, dependencies);
			JobDependencyAnalyzer<JobRaycastCommandDummy>.Scheduled(ref data, this, jobHandle);
			return jobHandle;
		}

		public JobHandle ScheduleBatch(NativeArray<OverlapCapsuleCommand> commands, NativeArray<ColliderHit> results, int minCommandsPerJob)
		{
			if (forceLinearDependencies)
			{
				OverlapCapsuleCommand.ScheduleBatch(commands, results, minCommandsPerJob, 1).Complete();
				return default(JobHandle);
			}
			JobOverlapCapsuleCommandDummy data = new JobOverlapCapsuleCommandDummy
			{
				commands = commands,
				results = results
			};
			JobHandle dependencies = JobDependencyAnalyzer<JobOverlapCapsuleCommandDummy>.GetDependencies(ref data, this);
			JobHandle jobHandle = OverlapCapsuleCommand.ScheduleBatch(commands, results, minCommandsPerJob, 1, dependencies);
			JobDependencyAnalyzer<JobOverlapCapsuleCommandDummy>.Scheduled(ref data, this, jobHandle);
			return jobHandle;
		}

		public JobHandle ScheduleBatch(NativeArray<OverlapSphereCommand> commands, NativeArray<ColliderHit> results, int minCommandsPerJob)
		{
			if (forceLinearDependencies)
			{
				OverlapSphereCommand.ScheduleBatch(commands, results, minCommandsPerJob, 1).Complete();
				return default(JobHandle);
			}
			JobOverlapSphereCommandDummy data = new JobOverlapSphereCommandDummy
			{
				commands = commands,
				results = results
			};
			JobHandle dependencies = JobDependencyAnalyzer<JobOverlapSphereCommandDummy>.GetDependencies(ref data, this);
			JobHandle jobHandle = OverlapSphereCommand.ScheduleBatch(commands, results, minCommandsPerJob, 1, dependencies);
			JobDependencyAnalyzer<JobOverlapSphereCommandDummy>.Scheduled(ref data, this, jobHandle);
			return jobHandle;
		}

		public void DeferFree(GCHandle handle, JobHandle dependsOn)
		{
			if (arena == null)
			{
				arena = new DisposeArena();
			}
			arena.Add(handle);
		}

		internal void JobReadsFrom(JobHandle job, long nativeArrayHash, int jobHash)
		{
			for (int i = 0; i < slots.Count; i++)
			{
				NativeArraySlot nativeArraySlot = slots[i];
				if (nativeArraySlot.hash == nativeArrayHash)
				{
					nativeArraySlot.lastReads.Add(new JobInstance
					{
						handle = job,
						hash = jobHash
					});
					break;
				}
			}
		}

		internal void JobWritesTo(JobHandle job, long nativeArrayHash, int jobHash)
		{
			for (int i = 0; i < slots.Count; i++)
			{
				NativeArraySlot value = slots[i];
				if (value.hash == nativeArrayHash)
				{
					value.lastWrite = new JobInstance
					{
						handle = job,
						hash = jobHash
					};
					value.lastReads.Clear();
					value.initialized = true;
					value.hasWrite = true;
					slots[i] = value;
					break;
				}
			}
		}

		private void Dispose()
		{
			for (int i = 0; i < slots.Count; i++)
			{
				ListPool<JobInstance>.Release(slots[i].lastReads);
			}
			slots.Clear();
			if (arena != null)
			{
				arena.DisposeAll();
			}
			linearDependencies = LinearDependencies.Check;
			if (dependenciesScratchBuffer.IsCreated)
			{
				dependenciesScratchBuffer.Dispose();
			}
		}

		public void ClearMemory()
		{
			AllWritesDependency.Complete();
			Dispose();
		}

		void IAstarPooledObject.OnEnterPool()
		{
			Dispose();
		}
	}
}
