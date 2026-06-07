using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Coherence.Runtime;

namespace Coherence.Cloud
{
	public class MatchmakerClient
	{
		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		private struct _003CMatch_003Ed__4 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder<MatchResponse> _003C_003Et__builder;

			public MatchmakerClient _003C_003E4__this;

			public string region;

			public string team;

			public string payload;

			public string[] friends;

			public string[] tags;

			private TaskAwaiter<string> _003C_003Eu__1;

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

		private IRequestFactory requestFactory;

		private IAuthClientInternal authClient;

		public MatchmakerClient(RequestFactory requestFactory, AuthClient authClient)
		{
		}

		internal MatchmakerClient(IRequestFactory requestFactory, IAuthClientInternal authClient)
		{
		}

		[AsyncStateMachine(typeof(_003CMatch_003Ed__4))]
		public Task<MatchResponse> Match(string region, string team, string payload, string[] tags, string[] friends)
		{
			return null;
		}
	}
}
