using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace Coherence.Cloud
{
	public class LobbyOwnerSession
	{
		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		private struct _003CAddOrUpdateLobbyAttributesAsync_003Ed__10 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder<bool> _003C_003Et__builder;

			public LobbyOwnerSession _003C_003E4__this;

			public List<CloudAttribute> attributes;

			private Task<string> _003Ctask_003E5__2;

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
		private struct _003CKickPlayerAsync_003Ed__7 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder<bool> _003C_003Et__builder;

			public LobbyOwnerSession _003C_003E4__this;

			public LobbyPlayer player;

			private Task<string> _003Ctask_003E5__2;

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
		private struct _003CStartGameSessionAsync_003Ed__12 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder<bool> _003C_003Et__builder;

			public LobbyOwnerSession _003C_003E4__this;

			public int? maxPlayers;

			public bool unlistLobby;

			public bool closeLobby;

			private Task<string> _003Ctask_003E5__2;

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

		private LobbyData lobbyData;

		private IAuthClientInternal authClient;

		private IRequestFactory requestFactory;

		private static readonly string lobbiesResolveEndpoint;

		public LobbyOwnerSession(LobbyData lobbyData, AuthClient authClient, RequestFactory requestFactory)
		{
		}

		internal LobbyOwnerSession(LobbyData lobbyData, IAuthClientInternal authClient, IRequestFactory requestFactory)
		{
		}

		public void KickPlayer(LobbyPlayer player, Action<RequestResponse<bool>> onRequestFinished)
		{
		}

		[AsyncStateMachine(typeof(_003CKickPlayerAsync_003Ed__7))]
		public Task<bool> KickPlayerAsync(LobbyPlayer player)
		{
			return null;
		}

		public TimeSpan GetAddOrUpdateLobbyAttributesCooldown()
		{
			return default(TimeSpan);
		}

		public void AddOrUpdateLobbyAttributes(List<CloudAttribute> attributes, Action<RequestResponse<bool>> onRequestFinished)
		{
		}

		[AsyncStateMachine(typeof(_003CAddOrUpdateLobbyAttributesAsync_003Ed__10))]
		public Task<bool> AddOrUpdateLobbyAttributesAsync(List<CloudAttribute> attributes)
		{
			return null;
		}

		public void StartGameSession(Action<RequestResponse<bool>> onRequestFinished, int? maxPlayers = null, bool unlistLobby = true, bool closeLobby = false)
		{
		}

		[AsyncStateMachine(typeof(_003CStartGameSessionAsync_003Ed__12))]
		public Task<bool> StartGameSessionAsync(int? maxPlayers = null, bool unlistLobby = true, bool closeLobby = false)
		{
			return null;
		}
	}
}
