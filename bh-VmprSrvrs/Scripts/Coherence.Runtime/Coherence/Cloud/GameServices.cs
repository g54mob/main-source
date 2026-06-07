using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace Coherence.Cloud
{
	public class GameServices : IDisposable
	{
		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		private struct _003CDisposeAsync_003Ed__16 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncValueTaskMethodBuilder _003C_003Et__builder;

			public GameServices _003C_003E4__this;

			public bool waitForOngoingOperationsToFinish;

			private ValueTaskAwaiter _003C_003Eu__1;

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

		internal readonly IAuthClientInternal authService;

		public IAuthClient AuthService { get; }

		public MatchmakerClient MatchmakerService { get; }

		public CloudStorage CloudStorage { get; }

		public KvStoreClient KvStoreService { get; }

		internal GameServices()
		{
		}

		public GameServices(CloudCredentialsPair credentialsPair)
		{
		}

		public void Dispose()
		{
		}

		[AsyncStateMachine(typeof(_003CDisposeAsync_003Ed__16))]
		internal ValueTask DisposeAsync(bool waitForOngoingOperationsToFinish)
		{
			return default(ValueTask);
		}
	}
}
