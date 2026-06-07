using System;
using System.Runtime.InteropServices;
using Unity.Jobs;

namespace Assets.Scripts.Jobs
{
	public struct ManagedJobParallelFor : IJobParallelFor, IDisposable
	{
		private GCHandle _managedObjectHandle;

		public ManagedJobParallelFor(IJobParallelFor job)
		{
			_managedObjectHandle = GCHandle.Alloc(job);
		}

		public static void RunToCompletion(IJobParallelFor job, int arrayLength, int innerloopBatchCount)
		{
			using ManagedJobParallelFor jobData = new ManagedJobParallelFor(job);
			IJobParallelForExtensions.Schedule(jobData, arrayLength, innerloopBatchCount).Complete();
		}

		public void Dispose()
		{
			_managedObjectHandle.Free();
		}

		public void Execute(int index)
		{
			((IJobParallelFor)_managedObjectHandle.Target).Execute(index);
		}
	}
}
