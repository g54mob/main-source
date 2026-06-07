using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Coherence.Common;

namespace Coherence.Cloud
{
	public class CloudRooms : IAsyncDisposable, IDisposable
	{
		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		private struct _003CDisposeAsync_003Ed__22 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncValueTaskMethodBuilder _003C_003Et__builder;

			public CloudRooms _003C_003E4__this;

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
		private struct _003CRefreshRegionsAsync_003Ed__20 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder<IReadOnlyList<string>> _003C_003Et__builder;

			public CloudRooms _003C_003E4__this;

			private TaskAwaiter<IReadOnlyList<string>> _003C_003Eu__1;

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

		private IRuntimeSettings runtimeSettings;

		private IAuthClientInternal authClient;

		private IRequestFactoryInternal requestFactory;

		private RoomRegionsService roomRegionsService;

		private LobbiesService lobbyService;

		private Dictionary<string, CloudRoomsService> roomServices;

		private bool shouldDisposeRequestFactoryAndAuthClient;

		public IReadOnlyList<string> Regions => null;

		public LobbiesService LobbyService => null;

		public bool IsConnectedToCloud => false;

		public bool IsLoggedIn => false;

		internal CloudRooms()
		{
		}

		public CloudRooms(CloudCredentialsPair credentialsPair = null, IRuntimeSettings runtimeSettings = null)
		{
		}

		internal CloudRooms(CloudCredentialsPair credentialsPair = null, IRuntimeSettings runtimeSettings = null, IPlayerAccountProvider playerAccountProvider = null)
		{
		}

		public CloudRoomsService GetRoomServiceForRegion(string region)
		{
			return null;
		}

		public void RefreshRegions(Action<RequestResponse<IReadOnlyList<string>>> callback)
		{
		}

		[AsyncStateMachine(typeof(_003CRefreshRegionsAsync_003Ed__20))]
		public Task<IReadOnlyList<string>> RefreshRegionsAsync()
		{
			return null;
		}

		public void Dispose()
		{
		}

		[AsyncStateMachine(typeof(_003CDisposeAsync_003Ed__22))]
		public ValueTask DisposeAsync()
		{
			return default(ValueTask);
		}
	}
}
