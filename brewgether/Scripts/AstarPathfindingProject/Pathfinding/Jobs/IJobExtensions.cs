using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Unity.Jobs;

namespace Pathfinding.Jobs
{
	public static class IJobExtensions
	{
		private struct ManagedJob : IJob
		{
			public GCHandle handle;

			public void Execute()
			{
			}
		}

		private struct ManagedActionJob : IJob
		{
			public GCHandle handle;

			public void Execute()
			{
			}
		}

		[CompilerGenerated]
		private sealed class _003CExecuteMainThreadJob_003Ed__7<T> : IEnumerator<JobHandle>, IEnumerator, IDisposable where T : struct, IJobTimeSliced
		{
			private int _003C_003E1__state;

			private JobHandle _003C_003E2__current;

			public JobDependencyTracker tracker;

			public T data;

			JobHandle IEnumerator<JobHandle>.Current
			{
				[DebuggerHidden]
				get
				{
					return default(JobHandle);
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			[DebuggerHidden]
			public _003CExecuteMainThreadJob_003Ed__7(int _003C_003E1__state)
			{
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				return false;
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			[DebuggerHidden]
			void IEnumerator.Reset()
			{
			}
		}

		public static JobHandle Schedule<T>(this T data, JobDependencyTracker tracker) where T : struct, IJob
		{
			return default(JobHandle);
		}

		public static JobHandle ScheduleBatch<T>(this T data, int arrayLength, int minIndicesPerJobCount, JobDependencyTracker tracker, JobHandle additionalDependency = default(JobHandle)) where T : struct, IJobParallelForBatched
		{
			return default(JobHandle);
		}

		public static JobHandle ScheduleManaged<T>(this T data, JobHandle dependsOn) where T : struct, IJob
		{
			return default(JobHandle);
		}

		public static JobHandle ScheduleManaged(this Action data, JobHandle dependsOn)
		{
			return default(JobHandle);
		}

		public static JobHandle GetDependencies<T>(this T data, JobDependencyTracker tracker) where T : struct, IJob
		{
			return default(JobHandle);
		}

		[IteratorStateMachine(typeof(_003CExecuteMainThreadJob_003Ed__7<>))]
		public static IEnumerator<JobHandle> ExecuteMainThreadJob<T>(this T data, JobDependencyTracker tracker) where T : struct, IJobTimeSliced
		{
			return null;
		}
	}
}
