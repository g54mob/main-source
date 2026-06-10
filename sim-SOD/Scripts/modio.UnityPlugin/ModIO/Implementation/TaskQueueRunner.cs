using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace ModIO.Implementation
{
	internal class TaskQueueRunner
	{
		private class TaskQueueItem
		{
			public Task task;

			public int taskSize;

			public TaskPriority priority;

			public bool useSeparateThread;
		}

		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		private struct _003CAutoRun_003Ed__7 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncVoidMethodBuilder _003C_003Et__builder;

			public TaskQueueRunner _003C_003E4__this;

			private TaskAwaiter _003C_003Eu__1;

			private void MoveNext()
			{
			}

			void IAsyncStateMachine.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				this.MoveNext();
			}

			[DebuggerHidden]
			private void SetStateMachine(IAsyncStateMachine stateMachine)
			{
			}

			void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
			{
				//ILSpy generated this explicit interface implementation from .override directive in SetStateMachine
				this.SetStateMachine(stateMachine);
			}
		}

		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		private struct _003CPerformTasks_003Ed__8 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder _003C_003Et__builder;

			public TaskQueueRunner _003C_003E4__this;

			private TaskAwaiter _003C_003Eu__1;

			private void MoveNext()
			{
			}

			void IAsyncStateMachine.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				this.MoveNext();
			}

			[DebuggerHidden]
			private void SetStateMachine(IAsyncStateMachine stateMachine)
			{
			}

			void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
			{
				//ILSpy generated this explicit interface implementation from .override directive in SetStateMachine
				this.SetStateMachine(stateMachine);
			}
		}

		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		private struct _003CRunTasksAsync_003Ed__12 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder _003C_003Et__builder;

			public bool synchronizedJobs;

			public List<TaskQueueItem> items;

			private List<TaskQueueItem>.Enumerator _003C_003E7__wrap1;

			private TaskAwaiter _003C_003Eu__1;

			private void MoveNext()
			{
			}

			void IAsyncStateMachine.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				this.MoveNext();
			}

			[DebuggerHidden]
			private void SetStateMachine(IAsyncStateMachine stateMachine)
			{
			}

			void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
			{
				//ILSpy generated this explicit interface implementation from .override directive in SetStateMachine
				this.SetStateMachine(stateMachine);
			}
		}

		private List<TaskQueueItem> tasks;

		private int upperTasksBoundary;

		private bool runsAutomatically;

		private bool isAutoRunning;

		private bool synchronizedJobs;

		public TaskQueueRunner(int upperTasksBoundary, bool runsAutomatically = false, bool synchronizedJobs = false)
		{
		}

		[AsyncStateMachine(typeof(_003CAutoRun_003Ed__7))]
		private void AutoRun()
		{
		}

		[AsyncStateMachine(typeof(_003CPerformTasks_003Ed__8))]
		public Task PerformTasks()
		{
			return null;
		}

		public bool HasTasks()
		{
			return false;
		}

		public Task<T> AddTask<T>(TaskPriority prio, int taskSize, Func<Task<T>> taskFunc, bool useSeparateThread = false)
		{
			return null;
		}

		private static List<TaskQueueItem> GetTasks(TaskPriority p, int upperTasksBoundary, ref int taskAmount, List<TaskQueueItem> operations)
		{
			return null;
		}

		[AsyncStateMachine(typeof(_003CRunTasksAsync_003Ed__12))]
		private static Task RunTasksAsync(List<TaskQueueItem> items, bool synchronizedJobs)
		{
			return null;
		}
	}
}
