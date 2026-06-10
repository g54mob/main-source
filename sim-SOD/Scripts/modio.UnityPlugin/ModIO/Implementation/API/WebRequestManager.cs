using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace ModIO.Implementation.API
{
	internal static class WebRequestManager
	{
		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		private struct _003CShutdown_003Ed__5 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder _003C_003Et__builder;

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
		private struct _003CRemoveTaskFromListWhenComplete_003Ed__7 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncVoidMethodBuilder _003C_003Et__builder;

			public Task task;

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
		private struct _003CRequest_003Ed__8<TOutput> : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder<ResultAnd<TOutput>> _003C_003Et__builder;

			public WebRequestConfig config;

			public ProgressHandle progressHandle;

			private Task<ResultAnd<TOutput>> _003Ctask_003E5__2;

			private TaskAwaiter<ResultAnd<TOutput>> _003C_003Eu__1;

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
		private struct _003CRequest_003Ed__9 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder<Result> _003C_003Et__builder;

			public WebRequestConfig config;

			private TaskAwaiter<ResultAnd<int?>> _003C_003Eu__1;

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

		private static Dictionary<string, object> liveTasks;

		private static HashSet<Task> onGoingRequests;

		internal static event Action ShutdownEvent
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		[AsyncStateMachine(typeof(_003CShutdown_003Ed__5))]
		public static Task Shutdown()
		{
			return null;
		}

		public static RequestHandle<Result> Download(string url, Stream downloadTo, ProgressHandle progressHandle)
		{
			return null;
		}

		[AsyncStateMachine(typeof(_003CRemoveTaskFromListWhenComplete_003Ed__7))]
		private static void RemoveTaskFromListWhenComplete(Task task)
		{
		}

		[AsyncStateMachine(typeof(_003CRequest_003Ed__8<>))]
		public static Task<ResultAnd<TOutput>> Request<TOutput>(WebRequestConfig config, ProgressHandle progressHandle = null)
		{
			return null;
		}

		[AsyncStateMachine(typeof(_003CRequest_003Ed__9))]
		public static Task<Result> Request(WebRequestConfig config)
		{
			return null;
		}

		private static Task<ResultAnd<TOutput>> NewRequest<TOutput>(WebRequestConfig config, ProgressHandle progressHandle = null)
		{
			return null;
		}

		private static bool PreexistingGetRequest<TOutput>(WebRequestConfig config, out Task<ResultAnd<TOutput>> task)
		{
			task = null;
			return false;
		}
	}
}
