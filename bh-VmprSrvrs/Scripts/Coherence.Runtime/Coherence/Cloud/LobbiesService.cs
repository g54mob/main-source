using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Coherence.Common;
using Coherence.Log;

namespace Coherence.Cloud
{
	public class LobbiesService : IAsyncDisposable, IDisposable
	{
		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		private struct _003CCreateLobbyAsync_003Ed__21 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder<LobbySession> _003C_003Et__builder;

			public LobbiesService _003C_003E4__this;

			public CreateLobbyOptions createOptions;

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
		private struct _003CDisposeAsync_003Ed__36 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncValueTaskMethodBuilder _003C_003Et__builder;

			public LobbiesService _003C_003E4__this;

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
		private struct _003CFetchLobbyStatsAsync_003Ed__32 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder<LobbyStats> _003C_003Et__builder;

			public List<string> tags;

			public List<string> regions;

			public LobbiesService _003C_003E4__this;

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
		private struct _003CFindLobbiesAsync_003Ed__24 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder<IReadOnlyList<LobbyData>> _003C_003Et__builder;

			public FindLobbyOptions findOptions;

			public LobbiesService _003C_003E4__this;

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
		private struct _003CFindOrCreateLobbyAsync_003Ed__18 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder<LobbySession> _003C_003Et__builder;

			public LobbiesService _003C_003E4__this;

			public CreateLobbyOptions createOptions;

			public FindLobbyOptions findOptions;

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
		private struct _003CGetActiveLobbySessionForLobbyId_003Ed__33 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder<LobbySession> _003C_003Et__builder;

			public LobbiesService _003C_003E4__this;

			public string lobbyId;

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

		[CompilerGenerated]
		private sealed class _003CGetLobbySessions_003Ed__34 : IEnumerable<LobbySession>, IEnumerable, IEnumerator<LobbySession>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private LobbySession _003C_003E2__current;

			private int _003C_003El__initialThreadId;

			public LobbiesService _003C_003E4__this;

			private List<LobbySession> _003CdisposedSessions_003E5__2;

			private Dictionary<string, LobbySession>.ValueCollection.Enumerator _003C_003E7__wrap2;

			LobbySession IEnumerator<LobbySession>.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			[DebuggerHidden]
			public _003CGetLobbySessions_003Ed__34(int _003C_003E1__state)
			{
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				return false;
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			private void _003C_003Em__Finally1()
			{
			}

			[DebuggerHidden]
			void IEnumerator.Reset()
			{
			}

			[DebuggerHidden]
			IEnumerator<LobbySession> IEnumerable<LobbySession>.GetEnumerator()
			{
				return null;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return null;
			}
		}

		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		private struct _003CJoinLobbyAsync_003Ed__26 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder<LobbySession> _003C_003Et__builder;

			public LobbyData lobby;

			public List<CloudAttribute> playerAttr;

			public string secret;

			public LobbiesService _003C_003E4__this;

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
		private struct _003CRefreshLobbyAsync_003Ed__28 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder<LobbyData> _003C_003Et__builder;

			public LobbiesService _003C_003E4__this;

			public LobbyData lobby;

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
		private struct _003CRefreshLobbyAsync_003Ed__30 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder<LobbyData> _003C_003Et__builder;

			public string lobbyId;

			public LobbiesService _003C_003E4__this;

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

		private readonly IRuntimeSettings runtimeSettings;

		private readonly Logger logger;

		private static readonly string lobbiesResolveEndpoint;

		private static readonly string playCallback;

		private Dictionary<string, LobbySession> lobbySessions;

		private List<Action<RequestResponse<IReadOnlyList<LobbyData>>>> fetchLobbiesCallbackList;

		private bool shouldDisposeRequestFactoryAndAuthClient;

		public event Action<string, RoomData> OnPlaySessionStarted
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

		internal event Action<RoomData> OnPlaySessionStartedInternal
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

		public LobbiesService(CloudCredentialsPair credentialsPair = null, IRuntimeSettings runtimeSettings = null)
		{
		}

		public TimeSpan GetFindOrCreateLobbyCooldown()
		{
			return default(TimeSpan);
		}

		public void FindOrCreateLobby(FindLobbyOptions findOptions, CreateLobbyOptions createOptions, Action<RequestResponse<LobbySession>> onRequestFinished)
		{
		}

		[AsyncStateMachine(typeof(_003CFindOrCreateLobbyAsync_003Ed__18))]
		public Task<LobbySession> FindOrCreateLobbyAsync(FindLobbyOptions findOptions, CreateLobbyOptions createOptions)
		{
			return null;
		}

		public TimeSpan GetCreateLobbyCooldown()
		{
			return default(TimeSpan);
		}

		public void CreateLobby(CreateLobbyOptions createOptions, Action<RequestResponse<LobbySession>> onRequestFinished)
		{
		}

		[AsyncStateMachine(typeof(_003CCreateLobbyAsync_003Ed__21))]
		public Task<LobbySession> CreateLobbyAsync(CreateLobbyOptions createOptions)
		{
			return null;
		}

		public TimeSpan GetFindLobbiesCooldown()
		{
			return default(TimeSpan);
		}

		public void FindLobbies(Action<RequestResponse<IReadOnlyList<LobbyData>>> onRequestFinished, FindLobbyOptions findOptions = null)
		{
		}

		[AsyncStateMachine(typeof(_003CFindLobbiesAsync_003Ed__24))]
		public Task<IReadOnlyList<LobbyData>> FindLobbiesAsync(FindLobbyOptions findOptions = null)
		{
			return null;
		}

		public void JoinLobby(LobbyData lobby, Action<RequestResponse<LobbySession>> onRequestFinished, List<CloudAttribute> playerAttr = null, string secret = null)
		{
		}

		[AsyncStateMachine(typeof(_003CJoinLobbyAsync_003Ed__26))]
		public Task<LobbySession> JoinLobbyAsync(LobbyData lobby, List<CloudAttribute> playerAttr = null, string secret = null)
		{
			return null;
		}

		public void RefreshLobby(LobbyData lobby, Action<RequestResponse<LobbyData>> onRequestFinished)
		{
		}

		[AsyncStateMachine(typeof(_003CRefreshLobbyAsync_003Ed__28))]
		public Task<LobbyData> RefreshLobbyAsync(LobbyData lobby)
		{
			return null;
		}

		public void RefreshLobby(string lobbyId, Action<RequestResponse<LobbyData>> onRequestFinished)
		{
		}

		[AsyncStateMachine(typeof(_003CRefreshLobbyAsync_003Ed__30))]
		public Task<LobbyData> RefreshLobbyAsync(string lobbyId)
		{
			return null;
		}

		public void FetchLobbyStats(Action<RequestResponse<LobbyStats>> onRequestFinished, List<string> tags = null, List<string> regions = null)
		{
		}

		[AsyncStateMachine(typeof(_003CFetchLobbyStatsAsync_003Ed__32))]
		public Task<LobbyStats> FetchLobbyStatsAsync(List<string> tags = null, List<string> regions = null)
		{
			return null;
		}

		[AsyncStateMachine(typeof(_003CGetActiveLobbySessionForLobbyId_003Ed__33))]
		public Task<LobbySession> GetActiveLobbySessionForLobbyId(string lobbyId)
		{
			return null;
		}

		[IteratorStateMachine(typeof(_003CGetLobbySessions_003Ed__34))]
		public IEnumerable<LobbySession> GetLobbySessions()
		{
			return null;
		}

		public void Dispose()
		{
		}

		[AsyncStateMachine(typeof(_003CDisposeAsync_003Ed__36))]
		public ValueTask DisposeAsync()
		{
			return default(ValueTask);
		}

		private LobbyData DeserializeLobbyData(string response)
		{
			return default(LobbyData);
		}

		private void AppendSimSlug(CreateLobbyOptions options)
		{
		}

		private List<LobbyData> OnFetch(string text)
		{
			return null;
		}

		private LobbySession CreateActiveLobbySession(LobbyData lobby)
		{
			return null;
		}

		private void CreateActiveLobbySessionIfPlayerIsInLobby(LobbyData updatedLobby)
		{
		}

		private bool WaitForOngoingRequest(Action<RequestResponse<IReadOnlyList<LobbyData>>> onRequestFinished)
		{
			return false;
		}

		private void OnPlayStarted(string responseBody)
		{
		}

		private void AddTokenToRoom(ref RoomData room)
		{
		}

		private void OnLogout()
		{
		}
	}
}
