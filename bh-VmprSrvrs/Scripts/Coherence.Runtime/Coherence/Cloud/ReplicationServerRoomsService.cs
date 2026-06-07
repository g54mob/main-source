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
	public class ReplicationServerRoomsService : IRoomsService, IDisposable
	{
		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		private struct _003CAwaitForPreviousRequestAsync_003Ed__25 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder _003C_003Et__builder;

			public ReplicationServerRoomsService _003C_003E4__this;

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

			public ReplicationServerRoomsService _003C_003E4__this;

			public RoomCreationOptions roomCreationOptions;

			private SelfHostedRoomCreationOptions _003CcastedRoomCreationOptions_003E5__2;

			private TaskAwaiter<IReadOnlyList<RoomData>> _003C_003Eu__1;

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
		private struct _003CFetchRoomsAsync_003Ed__23 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder<IReadOnlyList<RoomData>> _003C_003Et__builder;

			public ReplicationServerRoomsService _003C_003E4__this;

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
		private struct _003CIsOnline_003Ed__17 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder<bool> _003C_003Et__builder;

			public ReplicationServerRoomsService _003C_003E4__this;

			private TaskAwaiter<bool> _003C_003Eu__1;

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
		private struct _003CRemoveRoomAsync_003Ed__19 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder _003C_003Et__builder;

			public ulong roomId;

			public ReplicationServerRoomsService _003C_003E4__this;

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

		private readonly IRequestFactory requestFactory;

		private readonly RoomsCache roomsCache;

		private readonly IRuntimeSettings runtimeSettings;

		private readonly Logger logger;

		private readonly string roomsResolveEndpoint;

		private readonly string localRoomsGetMethod;

		private readonly string localRoomsCreateMethod;

		private readonly string localRoomsDeleteMethod;

		private string localRoomsIp;

		private int localRoomsApiPort;

		private string endpoint;

		private List<Action<RequestResponse<IReadOnlyList<RoomData>>>> fetchRoomsCallbackList;

		private bool isFetchingRooms;

		private readonly bool shouldDisposeRequestFactory;

		public IReadOnlyList<RoomData> CachedRooms => null;

		public ReplicationServerRoomsService(string ip = null, int? apiPort = null, IRequestFactory requestFactory = null, IRuntimeSettings runtimeSettings = null)
		{
		}

		[AsyncStateMachine(typeof(_003CIsOnline_003Ed__17))]
		public Task<bool> IsOnline()
		{
			return null;
		}

		public void RemoveRoom(ulong roomId, string secret, Action<RequestResponse<string>> onRequestFinished)
		{
		}

		[AsyncStateMachine(typeof(_003CRemoveRoomAsync_003Ed__19))]
		public Task RemoveRoomAsync(ulong roomId, string secret)
		{
			return null;
		}

		public void CreateRoom(Action<RequestResponse<RoomData>> onRequestFinished, RoomCreationOptions roomCreationOptions)
		{
		}

		[AsyncStateMachine(typeof(_003CCreateRoomAsync_003Ed__21))]
		public Task<RoomData> CreateRoomAsync(RoomCreationOptions roomCreationOptions)
		{
			return null;
		}

		public void FetchRooms(Action<RequestResponse<IReadOnlyList<RoomData>>> onRequestFinished, string[] tags = null)
		{
		}

		[AsyncStateMachine(typeof(_003CFetchRoomsAsync_003Ed__23))]
		public Task<IReadOnlyList<RoomData>> FetchRoomsAsync(string[] tags = null)
		{
			return null;
		}

		private SelfHostedRoomCreationOptions GetCastedRoomCreationOptions(RoomCreationOptions roomCreationOptions)
		{
			return null;
		}

		[AsyncStateMachine(typeof(_003CAwaitForPreviousRequestAsync_003Ed__25))]
		private Task AwaitForPreviousRequestAsync()
		{
			return null;
		}

		private bool WaitForOngoingRequest(Action<RequestResponse<IReadOnlyList<RoomData>>> onRequestFinished)
		{
			return false;
		}

		private List<RoomData> OnFetchLocal(string text, string[] tags)
		{
			return null;
		}

		private string GetRemoveRoomPath(string pathParams)
		{
			return null;
		}

		private RoomData GetLocalRoomDataFromResponse(SelfHostedRoomCreationOptions roomCreationOptions, string text)
		{
			return default(RoomData);
		}

		private static string GetLocalRoomCreationRequestBody(SelfHostedRoomCreationOptions roomCreationOptions)
		{
			return null;
		}

		public void Dispose()
		{
		}
	}
}
