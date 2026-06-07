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
	public class CloudRoomsService : IRoomsService, IAsyncDisposable, IDisposable
	{
		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		private struct _003CAwaitForPreviousRequestAsync_003Ed__27 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder _003C_003Et__builder;

			public CloudRoomsService _003C_003E4__this;

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
		private struct _003CCreateRoomAsync_003Ed__21 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder<RoomData> _003C_003Et__builder;

			public CloudRoomsService _003C_003E4__this;

			public RoomCreationOptions roomCreationOptions;

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
		private struct _003CDisposeAsync_003Ed__34 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncValueTaskMethodBuilder _003C_003Et__builder;

			public CloudRoomsService _003C_003E4__this;

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
		private struct _003CFetchRoomsAsync_003Ed__26 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder<IReadOnlyList<RoomData>> _003C_003Et__builder;

			public CloudRoomsService _003C_003E4__this;

			public string[] tags;

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

		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		private struct _003CMatchRoomAsync_003Ed__23 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder<RoomMatchResponse> _003C_003Et__builder;

			public string[] tags;

			public CloudRoomsService _003C_003E4__this;

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
		private struct _003CRemoveRoomAsync_003Ed__17 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder _003C_003Et__builder;

			public ulong uniqueID;

			public string secret;

			public CloudRoomsService _003C_003E4__this;

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
		private struct _003CUnlistRoomAsync_003Ed__18 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder _003C_003Et__builder;

			public ulong uniqueID;

			public string secret;

			public CloudRoomsService _003C_003E4__this;

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

		private IRequestFactory requestFactory;

		private RoomsCache roomsCache;

		private IAuthClientInternal authClient;

		private readonly IRuntimeSettings runtimeSettings;

		private readonly Logger logger;

		private readonly string roomsResolveEndpoint;

		private List<Action<RequestResponse<IReadOnlyList<RoomData>>>> fetchRoomsCallbackList;

		private bool isFetchingRooms;

		private string region;

		private bool shouldDisposeRequestFactoryAndAuthClient;

		public IReadOnlyList<RoomData> CachedRooms => null;

		public CloudRoomsService(string region, CloudCredentialsPair credentialsPair, IRuntimeSettings runtimeSettings)
		{
		}

		internal CloudRoomsService(string region, [MaybeNull] CloudCredentialsPair credentialsPair, [MaybeNull] IRuntimeSettings runtimeSettings, [MaybeNull] IPlayerAccountProvider playerAccountProvider)
		{
		}

		public TimeSpan GetRemoveRoomCooldown()
		{
			return default(TimeSpan);
		}

		public void RemoveRoom(ulong uniqueID, string secret, Action<RequestResponse<string>> onRequestFinished)
		{
		}

		public void UnlistRoom(ulong uniqueID, string secret, Action<RequestResponse<string>> onRequestFinished)
		{
		}

		[AsyncStateMachine(typeof(_003CRemoveRoomAsync_003Ed__17))]
		public Task RemoveRoomAsync(ulong uniqueID, string secret)
		{
			return null;
		}

		[AsyncStateMachine(typeof(_003CUnlistRoomAsync_003Ed__18))]
		public Task UnlistRoomAsync(ulong uniqueID, string secret)
		{
			return null;
		}

		public TimeSpan GetCreateRoomCooldown()
		{
			return default(TimeSpan);
		}

		public void CreateRoom(Action<RequestResponse<RoomData>> onRequestFinished, RoomCreationOptions roomCreationOptions)
		{
		}

		[AsyncStateMachine(typeof(_003CCreateRoomAsync_003Ed__21))]
		public Task<RoomData> CreateRoomAsync(RoomCreationOptions roomCreationOptions)
		{
			return null;
		}

		public void MatchRoom(Action<RequestResponse<RoomMatchResponse>> onRequestFinished, string[] tags = null)
		{
		}

		[AsyncStateMachine(typeof(_003CMatchRoomAsync_003Ed__23))]
		public Task<RoomMatchResponse> MatchRoomAsync(string[] tags = null)
		{
			return null;
		}

		public TimeSpan GetFetchRoomsCooldown()
		{
			return default(TimeSpan);
		}

		public void FetchRooms(Action<RequestResponse<IReadOnlyList<RoomData>>> onRequestFinished, string[] tags = null)
		{
		}

		[AsyncStateMachine(typeof(_003CFetchRoomsAsync_003Ed__26))]
		public Task<IReadOnlyList<RoomData>> FetchRoomsAsync(string[] tags = null)
		{
			return null;
		}

		[AsyncStateMachine(typeof(_003CAwaitForPreviousRequestAsync_003Ed__27))]
		private Task AwaitForPreviousRequestAsync()
		{
			return null;
		}

		private RoomData DeserializeCreatedRoom(string textResponse)
		{
			return default(RoomData);
		}

		private bool WaitForOngoingRequest(Action<RequestResponse<IReadOnlyList<RoomData>>> onRequestFinished)
		{
			return false;
		}

		private List<RoomData> OnFetch(string text, string sessionToken)
		{
			return null;
		}

		private string GetRoomCreationRequestBody(RoomCreationOptions roomCreationOptions)
		{
			return null;
		}

		private SessionToken GetAuthToken()
		{
			return default(SessionToken);
		}

		public void Dispose()
		{
		}

		[AsyncStateMachine(typeof(_003CDisposeAsync_003Ed__34))]
		public ValueTask DisposeAsync()
		{
			return default(ValueTask);
		}
	}
}
