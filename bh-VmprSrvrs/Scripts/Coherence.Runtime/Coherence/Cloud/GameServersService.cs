using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Coherence.Common;
using Coherence.Log;

namespace Coherence.Cloud
{
	public class GameServersService : IGameServersService, IAsyncDisposable, IDisposable
	{
		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		private struct _003CDeleteAsync_003Ed__18 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder _003C_003Et__builder;

			public GameServersService _003C_003E4__this;

			public ulong serverId;

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

		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		private struct _003CDeployAsync_003Ed__11 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder<GameServerDeployResult> _003C_003Et__builder;

			public GameServerDeployOptions deployOptions;

			public GameServersService _003C_003E4__this;

			private string _003CreqName_003E5__2;

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

		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		private struct _003CDisposeAsync_003Ed__23 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncValueTaskMethodBuilder _003C_003Et__builder;

			public GameServersService _003C_003E4__this;

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
		private struct _003CGetAsync_003Ed__14 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder<GameServerData> _003C_003Et__builder;

			public GameServersService _003C_003E4__this;

			public ulong serverId;

			private string _003CreqName_003E5__2;

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

		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		private struct _003CListAsync_003Ed__12 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder<List<GameServerData>> _003C_003Et__builder;

			public GameServerListOptions listOptions;

			public GameServersService _003C_003E4__this;

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

		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		private struct _003CMatchAsync_003Ed__13 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder<OptionalGameServerData> _003C_003Et__builder;

			public GameServerMatchOptions matchOptions;

			public GameServersService _003C_003E4__this;

			private string _003CreqName_003E5__2;

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

		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		private struct _003CResumeAsync_003Ed__16 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder _003C_003Et__builder;

			public GameServersService _003C_003E4__this;

			public ulong serverId;

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
		private struct _003CSuspendAsync_003Ed__15 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder _003C_003Et__builder;

			public GameServersService _003C_003E4__this;

			public ulong serverId;

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

		private readonly Logger logger;

		private readonly IAuthClient authClient;

		private readonly IRequestFactory requestFactory;

		private readonly string authToken;

		private const string DeployPath = "/gameservers";

		private const string ListPath = "/gameservers";

		private const string MatchPath = "/gameservers/match";

		private SecretsCache secretsCache;

		private bool shouldDisposeRequestFactoryAndAuthClient;

		internal GameServersService()
		{
		}

		public GameServersService(CloudCredentialsPair credentialsPair = null, IRuntimeSettings runtimeSettings = null)
		{
		}

		[AsyncStateMachine(typeof(_003CDeployAsync_003Ed__11))]
		public Task<GameServerDeployResult> DeployAsync(GameServerDeployOptions deployOptions)
		{
			return null;
		}

		[AsyncStateMachine(typeof(_003CListAsync_003Ed__12))]
		public Task<List<GameServerData>> ListAsync(GameServerListOptions listOptions)
		{
			return null;
		}

		[AsyncStateMachine(typeof(_003CMatchAsync_003Ed__13))]
		public Task<OptionalGameServerData> MatchAsync(GameServerMatchOptions matchOptions)
		{
			return null;
		}

		[AsyncStateMachine(typeof(_003CGetAsync_003Ed__14))]
		public Task<GameServerData> GetAsync(ulong serverId)
		{
			return null;
		}

		[AsyncStateMachine(typeof(_003CSuspendAsync_003Ed__15))]
		public Task SuspendAsync(ulong serverId)
		{
			return null;
		}

		[AsyncStateMachine(typeof(_003CResumeAsync_003Ed__16))]
		public Task ResumeAsync(ulong serverId)
		{
			return null;
		}

		private Task SetStateAsync(ulong serverId, bool suspended)
		{
			return null;
		}

		[AsyncStateMachine(typeof(_003CDeleteAsync_003Ed__18))]
		public Task DeleteAsync(ulong serverId)
		{
			return null;
		}

		private static string GetGetPath(ulong id)
		{
			return null;
		}

		private static string GetStatePath(ulong id)
		{
			return null;
		}

		private static string GetDeletePath(ulong id)
		{
			return null;
		}

		public void Dispose()
		{
		}

		[AsyncStateMachine(typeof(_003CDisposeAsync_003Ed__23))]
		public ValueTask DisposeAsync()
		{
			return default(ValueTask);
		}
	}
}
