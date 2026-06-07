using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Coherence.Cloud;
using Coherence.Common;
using Coherence.Log;

namespace Coherence.Runtime
{
	public class AnalyticsClient
	{
		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		private struct _003COnConnect_003Ed__7 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncVoidMethodBuilder _003C_003Et__builder;

			public AnalyticsClient _003C_003E4__this;

			private YieldAwaitable.YieldAwaiter _003C_003Eu__1;

			private TaskAwaiter<string> _003C_003Eu__2;

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

		private readonly Logger logger;

		private string cachedAnalyticsId;

		private readonly IRequestFactory requestFactory;

		private readonly IRuntimeSettings runtimeSettings;

		private readonly IPlayerAccountProvider playerAccountProvider;

		internal AnalyticsClient()
		{
		}

		internal AnalyticsClient(IPlayerAccountProvider playerAccountProvider, IRuntimeSettings runtimeSettings, IRequestFactory requestFactory)
		{
		}

		[AsyncStateMachine(typeof(_003COnConnect_003Ed__7))]
		private void OnConnect()
		{
		}
	}
}
