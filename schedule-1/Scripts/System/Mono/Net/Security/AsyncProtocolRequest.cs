using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;

namespace Mono.Net.Security
{
	internal abstract class AsyncProtocolRequest
	{
		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		private struct _003CStartOperation_003Ed__23 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder<AsyncProtocolResult> _003C_003Et__builder;

			public AsyncProtocolRequest _003C_003E4__this;

			public CancellationToken cancellationToken;

			private ConfiguredTaskAwaitable.ConfiguredTaskAwaiter _003C_003Eu__1;

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
		private struct _003CProcessOperation_003Ed__24 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder _003C_003Et__builder;

			public CancellationToken cancellationToken;

			public AsyncProtocolRequest _003C_003E4__this;

			private AsyncOperationStatus _003Cstatus_003E5__2;

			private AsyncOperationStatus _003CnewStatus_003E5__3;

			private ConfiguredTaskAwaitable<int?>.ConfiguredTaskAwaiter _003C_003Eu__1;

			private ConfiguredTaskAwaitable.ConfiguredTaskAwaiter _003C_003Eu__2;

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
		private struct _003CInnerRead_003Ed__25 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder<int?> _003C_003Et__builder;

			public AsyncProtocolRequest _003C_003E4__this;

			public CancellationToken cancellationToken;

			private int? _003CtotalRead_003E5__2;

			private int _003CrequestedSize_003E5__3;

			private ConfiguredTaskAwaitable<int>.ConfiguredTaskAwaiter _003C_003Eu__1;

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

		private int Started;

		private int RequestedSize;

		private int WriteRequested;

		private readonly object locker;

		public MobileAuthenticatedStream Parent { get; }

		public bool RunSynchronously { get; }

		public string Name => null;

		public int UserResult { get; protected set; }

		public AsyncProtocolRequest(MobileAuthenticatedStream parent, bool sync)
		{
		}

		internal void RequestRead(int size)
		{
		}

		internal void RequestWrite()
		{
		}

		[AsyncStateMachine(typeof(_003CStartOperation_003Ed__23))]
		internal Task<AsyncProtocolResult> StartOperation(CancellationToken cancellationToken)
		{
			return null;
		}

		[AsyncStateMachine(typeof(_003CProcessOperation_003Ed__24))]
		private Task ProcessOperation(CancellationToken cancellationToken)
		{
			return null;
		}

		[AsyncStateMachine(typeof(_003CInnerRead_003Ed__25))]
		private Task<int?> InnerRead(CancellationToken cancellationToken)
		{
			return null;
		}

		protected abstract AsyncOperationStatus Run(AsyncOperationStatus status);

		public override string ToString()
		{
			return null;
		}
	}
}
