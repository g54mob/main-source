using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Coherence.Log;

namespace Coherence.Cloud
{
	public class RoomRegionsService
	{
		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		private struct _003CFetchRegionsAsync_003Ed__13 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder<IReadOnlyList<string>> _003C_003Et__builder;

			public RoomRegionsService _003C_003E4__this;

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

		private IRequestFactory requestFactory;

		private IAuthClientInternal authClient;

		private readonly Logger logger;

		private readonly string regionEndpoint;

		private List<string> regions;

		private readonly List<Action<RequestResponse<IReadOnlyList<string>>>> fetchRegionsCallbackList;

		private bool isFetchingRegionsAsync;

		public IReadOnlyList<string> Regions => null;

		public RoomRegionsService(RequestFactory requestFactory, AuthClient authClient)
		{
		}

		internal RoomRegionsService(IRequestFactory requestFactory, IAuthClientInternal authClient)
		{
		}

		public TimeSpan GetFetchRegionsCooldown()
		{
			return default(TimeSpan);
		}

		public void FetchRegions(Action<RequestResponse<IReadOnlyList<string>>> onRequestFinished)
		{
		}

		[AsyncStateMachine(typeof(_003CFetchRegionsAsync_003Ed__13))]
		public Task<IReadOnlyList<string>> FetchRegionsAsync()
		{
			return null;
		}

		private void IterateCallbackList(RequestResponse<IReadOnlyList<string>> response)
		{
		}
	}
}
