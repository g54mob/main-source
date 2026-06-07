using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace Coherence.Cloud
{
	public class CloudCredentialsPair
	{
		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		private struct _003CDisposeAsync_003Ed__7 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncValueTaskMethodBuilder _003C_003Et__builder;

			public IAuthClient authClient;

			public IRequestFactory requestFactory;

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

		public IAuthClient AuthClient;

		public IRequestFactory RequestFactory;

		internal readonly IAuthClientInternal authClient;

		internal readonly IRequestFactoryInternal requestFactory;

		public CloudCredentialsPair(AuthClient authClient, RequestFactory requestFactory)
		{
		}

		internal CloudCredentialsPair(IAuthClientInternal authClient, IRequestFactoryInternal requestFactory)
		{
		}

		public static void Dispose(IAuthClient authClient, IRequestFactory requestFactory)
		{
		}

		[AsyncStateMachine(typeof(_003CDisposeAsync_003Ed__7))]
		public static ValueTask DisposeAsync(IAuthClient authClient, IRequestFactory requestFactory)
		{
			return default(ValueTask);
		}
	}
}
