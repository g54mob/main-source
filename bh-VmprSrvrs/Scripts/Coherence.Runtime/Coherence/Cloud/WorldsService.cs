using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Coherence.Common;
using Coherence.Log;

namespace Coherence.Cloud
{
	public class WorldsService : IAsyncDisposable, IDisposable
	{
		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		private struct _003CAwaitForPreviousRequestAsync_003Ed__18 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder _003C_003Et__builder;

			public WorldsService _003C_003E4__this;

			private YieldAwaitable.YieldAwaiter _003C_003Eu__1;

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
		private struct _003CDisposeAsync_003Ed__20 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncValueTaskMethodBuilder _003C_003Et__builder;

			public WorldsService _003C_003E4__this;

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

		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		private struct _003CFetchWorldsAsync_003Ed__15 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder<IReadOnlyList<WorldData>> _003C_003Et__builder;

			public WorldsService _003C_003E4__this;

			public string region;

			public string simSlug;

			private TaskAwaiter _003C_003Eu__1;

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

		internal IAuthClientInternal authClient;

		private readonly string worldsResolveEndpoint;

		private readonly IRuntimeSettings runtimeSettings;

		private readonly Logger logger;

		private List<Action<RequestResponse<IReadOnlyList<WorldData>>>> fetchWorldsCallbackList;

		private bool isFetchingWorlds;

		private bool shouldDisposeRequestFactoryAndAuthClient;

		public bool IsLoggedIn => false;

		internal WorldsService()
		{
		}

		public WorldsService(CloudCredentialsPair credentialsPair, IRuntimeSettings runtimeSettings)
		{
		}

		internal WorldsService([MaybeNull] CloudCredentialsPair credentialsPair, [MaybeNull] IRuntimeSettings runtimeSettings, [MaybeNull] IPlayerAccountProvider playerAccountProvider)
		{
		}

		public TimeSpan GetFetchWorldsCooldown()
		{
			return default(TimeSpan);
		}

		public void FetchWorlds(Action<RequestResponse<IReadOnlyList<WorldData>>> onRequestFinished, string region = "", string simSlug = "")
		{
		}

		[AsyncStateMachine(typeof(_003CFetchWorldsAsync_003Ed__15))]
		public Task<IReadOnlyList<WorldData>> FetchWorldsAsync(string region = "", string simSlug = "")
		{
			return null;
		}

		private void PostProcessWorldData(WorldData[] worldList)
		{
		}

		private bool WaitForOngoingRequest(Action<RequestResponse<IReadOnlyList<WorldData>>> onRequestFinished)
		{
			return false;
		}

		[AsyncStateMachine(typeof(_003CAwaitForPreviousRequestAsync_003Ed__18))]
		private Task AwaitForPreviousRequestAsync()
		{
			return null;
		}

		public void Dispose()
		{
		}

		[AsyncStateMachine(typeof(_003CDisposeAsync_003Ed__20))]
		public ValueTask DisposeAsync()
		{
			return default(ValueTask);
		}
	}
}
