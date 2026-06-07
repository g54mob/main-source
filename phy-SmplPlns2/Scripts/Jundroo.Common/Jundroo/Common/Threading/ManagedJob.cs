using System;
using System.Runtime.InteropServices;
using Unity.Jobs;

namespace Jundroo.Common.Threading
{
	public struct ManagedJob : IJob, IDisposable
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

		public ManagedJob(Action action)
		{
			_actionGCHandle = default(GCHandle);
			Action = action;
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
