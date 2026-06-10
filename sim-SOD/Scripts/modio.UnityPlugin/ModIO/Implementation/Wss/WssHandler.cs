using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using ModIO.Implementation.Wss.Messages;

namespace ModIO.Implementation.Wss
{
	internal static class WssHandler
	{
		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		private struct _003CWaitForMessage_003Ed__6 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder<ResultAnd<WssMessage>> _003C_003Et__builder;

			public bool checkPreviousUnhandledMessages;

			public string messageOperation;

			private TaskCompletionSource<WssMessage> _003Ctcs_003E5__2;

			private TaskAwaiter<WssMessage> _003C_003Eu__1;

			private TaskAwaiter<Task> _003C_003Eu__2;

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
		private struct _003CDoMessageHandshake_003Ed__7<T> : IAsyncStateMachine where T : struct
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder<ResultAnd<T>> _003C_003Et__builder;

			public WssMessage message;

			private Task<ResultAnd<WssMessage>> _003Ctask_003E5__2;

			private TaskAwaiter<Result> _003C_003Eu__1;

			private TaskAwaiter<ResultAnd<WssMessage>> _003C_003Eu__2;

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
		private struct _003CShutdown_003Ed__10 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder _003C_003Et__builder;

			private TaskAwaiter _003C_003Eu__1;

			private YieldAwaitable.YieldAwaiter _003C_003Eu__2;

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
		private struct _003CEnsureConnection_003Ed__11 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder<Result> _003C_003Et__builder;

			private TaskAwaiter<Result> _003C_003Eu__1;

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
		private struct _003CSend_003Ed__12 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder<Result> _003C_003Et__builder;

			public WssMessage message;

			private WssMessages _003Cmessages_003E5__2;

			private TaskAwaiter<Result> _003C_003Eu__1;

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
		private struct _003CDisconnected_003Ed__15 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncVoidMethodBuilder _003C_003Et__builder;

			private TaskAwaiter<Result> _003C_003Eu__1;

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

		private static ISocketConnection Socket;

		private static Dictionary<string, TaskCompletionSource<WssMessage>> WaitingForMessages;

		private static Dictionary<string, Action<WssMessage>> SubscribedMessageListeners;

		private static Dictionary<string, WssMessage> UnhandledMessages;

		private static string GatewayUrl => null;

		[AsyncStateMachine(typeof(_003CWaitForMessage_003Ed__6))]
		public static Task<ResultAnd<WssMessage>> WaitForMessage(string messageOperation, bool checkPreviousUnhandledMessages = false)
		{
			return null;
		}

		[AsyncStateMachine(typeof(_003CDoMessageHandshake_003Ed__7<>))]
		public static Task<ResultAnd<T>> DoMessageHandshake<T>(WssMessage message) where T : struct
		{
			return null;
		}

		public static void CancelWaitingFor(string messageOperation)
		{
		}

		private static void CancelAllAwaitingMessages()
		{
		}

		[AsyncStateMachine(typeof(_003CShutdown_003Ed__10))]
		public static Task Shutdown()
		{
			return null;
		}

		[AsyncStateMachine(typeof(_003CEnsureConnection_003Ed__11))]
		private static Task<Result> EnsureConnection()
		{
			return null;
		}

		[AsyncStateMachine(typeof(_003CSend_003Ed__12))]
		public static Task<Result> Send(WssMessage message)
		{
			return null;
		}

		private static void Receive(WssMessages messages)
		{
		}

		private static void ProcessErrorObject(WssMessage message)
		{
		}

		[AsyncStateMachine(typeof(_003CDisconnected_003Ed__15))]
		private static void Disconnected()
		{
		}
	}
}
