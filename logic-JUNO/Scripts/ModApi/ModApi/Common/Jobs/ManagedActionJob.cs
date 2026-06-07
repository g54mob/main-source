using System;
using System.Runtime.InteropServices;
using Unity.Jobs;

namespace ModApi.Common.Jobs
{
	public struct ManagedActionJob : IJob, IDisposable
	{
		private GCHandle _actionGCHandle;

		public Action Action
		{
			get
			{
				return (Action)_actionGCHandle.Target;
			}
			set
			{
				_actionGCHandle = GCHandle.Alloc(value);
			}
		}

		public ManagedActionJob(Action action)
		{
			_actionGCHandle = GCHandle.Alloc(action);
		}

		public void Dispose()
		{
			_actionGCHandle.Free();
		}

		public void Execute()
		{
			Action();
		}
	}
}
