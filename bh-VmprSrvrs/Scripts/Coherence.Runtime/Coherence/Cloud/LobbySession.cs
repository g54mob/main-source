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
	public class LobbySession : IDisposableInternal, IDisposable
	{
		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		private struct _003CAddOrUpdateMyAttributesAsync_003Ed__73 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder<bool> _003C_003Et__builder;

			public LobbySession _003C_003E4__this;

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
		private struct _003CLeaveLobbyAsync_003Ed__67 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder<bool> _003C_003Et__builder;

			public LobbySession _003C_003E4__this;

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
		private struct _003CRefreshLobbyAsync_003Ed__65 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder _003C_003Et__builder;

			public LobbySession _003C_003E4__this;

			private TaskAwaiter<LobbyData> _003C_003Eu__1;

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
		private struct _003CSendMessageAsync_003Ed__70 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder<bool> _003C_003Et__builder;

			public LobbySession _003C_003E4__this;

			public List<string> messages;

			public List<LobbyPlayer> targets;

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

		private LobbiesService lobbiesService;

		private LobbyData lobbyData;

		private IAuthClientInternal authClient;

		private IRequestFactory requestFactory;

		private LobbyOwnerSession lobbyOwnerSession;

		private LobbyPlayer? myPlayer;

		private LobbyPlayer ownerPlayer;

		private static readonly string lobbiesResolveEndpoint;

		private static readonly string messageReceivedCallback;

		private static readonly string playerJoinedCallback;

		private static readonly string playerLeftCallback;

		private static readonly string playerAttributesChanged;

		private static readonly string lobbyOwnerChanged;

		private static readonly string lobbyAttributesChanged;

		private readonly Logger logger;

		public LobbyData LobbyData => default(LobbyData);

		public LobbyPlayer? MyPlayer => null;

		public LobbyPlayer OwnerPlayer => default(LobbyPlayer);

		public LobbyOwnerSession LobbyOwnerActions => null;

		public bool IsDisposed { get; private set; }

		string IDisposableInternal.InitializationContext
		{
			[CompilerGenerated]
			get
			{
				return null;
			}
			[CompilerGenerated]
			set
			{
			}
		}

		string IDisposableInternal.InitializationStackTrace
		{
			[CompilerGenerated]
			get
			{
				return null;
			}
			[CompilerGenerated]
			set
			{
			}
		}

		bool IDisposableInternal.IsDisposed
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public event Action<LobbySession, MessagesReceived> OnMessageReceived
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public event Action<LobbySession, LobbyPlayer> OnPlayerJoined
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public event Action<LobbySession, LobbyPlayer, string> OnPlayerLeft
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public event Action<LobbySession, LobbyPlayer, IReadOnlyList<CloudAttribute>> OnPlayerAttributesChanged
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public event Action<LobbySession, LobbyPlayer> OnLobbyOwnerChanged
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public event Action<LobbySession, IReadOnlyList<CloudAttribute>> OnLobbyAttributesChanged
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public event Action<LobbySession> OnLobbyUpdated
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public event Action<LobbySession> OnLobbyDisposed
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public LobbySession(LobbiesService lobbiesService, LobbyData lobbyData, AuthClient authClient, RequestFactory requestFactory)
		{
		}

		internal LobbySession(LobbiesService lobbiesService, LobbyData lobbyData, IAuthClientInternal authClient, IRequestFactory requestFactory)
		{
		}

		public void RefreshLobby(Action onFinished)
		{
		}

		[AsyncStateMachine(typeof(_003CRefreshLobbyAsync_003Ed__65))]
		public Task RefreshLobbyAsync()
		{
			return null;
		}

		public void LeaveLobby(Action<RequestResponse<bool>> onRequestFinished)
		{
		}

		[AsyncStateMachine(typeof(_003CLeaveLobbyAsync_003Ed__67))]
		public Task<bool> LeaveLobbyAsync()
		{
			return null;
		}

		public TimeSpan GetSendMessageCooldown()
		{
			return default(TimeSpan);
		}

		public void SendMessage(List<string> messages, Action<RequestResponse<bool>> onRequestFinished, List<LobbyPlayer> targets = null)
		{
		}

		[AsyncStateMachine(typeof(_003CSendMessageAsync_003Ed__70))]
		public Task<bool> SendMessageAsync(List<string> messages, List<LobbyPlayer> targets = null)
		{
			return null;
		}

		public TimeSpan GetAddOrUpdateMyAttributesCooldown()
		{
			return default(TimeSpan);
		}

		public void AddOrUpdateMyAttributes(List<CloudAttribute> attributes, Action<RequestResponse<bool>> onRequestFinished)
		{
		}

		[AsyncStateMachine(typeof(_003CAddOrUpdateMyAttributesAsync_003Ed__73))]
		public Task<bool> AddOrUpdateMyAttributesAsync(List<CloudAttribute> attributes)
		{
			return null;
		}

		~LobbySession()
		{
		}

		public void Dispose()
		{
		}

		private void OnLogout()
		{
		}

		private void ThrowIfDisposed()
		{
		}

		private void ParseLobbyData()
		{
		}

		private void UpdateLobbyOwnerSession()
		{
		}

		private void OnMessageReceivedHandler(string responseBody)
		{
		}

		private void OnPlayerJoinedHandler(string responseBody)
		{
		}

		private void OnPlayerLeftHandler(string responseBody)
		{
		}

		private void OnPlayerAttributesChangedHandler(string responseBody)
		{
		}

		private void OnLobbyOwnerChangedHandler(string responseBody)
		{
		}

		private void OnLobbyAttributesChangedHandler(string responseBody)
		{
		}
	}
}
