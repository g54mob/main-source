using System;
using System.Threading;
using UnityEngine;

namespace RoslynCSharp
{
	public abstract class AsyncOperation : CustomYieldInstruction
	{
		private bool hasStarted;

		private bool threadExit;

		private bool isDone;

		protected bool isSuccessful;

		public bool IsDone => isDone;

		public bool IsSuccessful => isSuccessful;

		public override bool keepWaiting
		{
			get
			{
				if (!hasStarted)
				{
					ThreadPool.QueueUserWorkItem(delegate
					{
						try
						{
							hasStarted = true;
							RunAsyncOperation();
						}
						catch (Exception exception2)
						{
							Debug.LogException(exception2);
							isSuccessful = false;
						}
						threadExit = true;
					});
				}
				if (!threadExit)
				{
					return true;
				}
				try
				{
					RunSyncFinalize();
				}
				catch (Exception exception)
				{
					Debug.LogException(exception);
					isSuccessful = false;
				}
				isDone = true;
				return false;
			}
		}

		protected abstract void RunAsyncOperation();

		protected virtual void RunSyncFinalize()
		{
		}
	}
}
