using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Coherence.Common;
using Coherence.Runtime;
using UnityEngine;

namespace Coherence.Cloud
{
	public class CloudService : IDisposable
	{
		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		private struct _003CDisposeAsync_003Ed__51 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncValueTaskMethodBuilder _003C_003Et__builder;

			public CloudService _003C_003E4__this;

			public bool waitForOngoingOperationsToFinish;

			private ValueTask _003CdisposeRooms_003E5__2;

			private ValueTask _003CdisposeWorlds_003E5__3;

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
		private struct _003CWaitForCloudServiceLoginAsync_003Ed__48 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder<bool> _003C_003Et__builder;

			public int millisecondsPollDelay;

			public CloudService _003C_003E4__this;

			private Awaitable.Awaiter _003C_003Eu__1;

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
		private struct _003CWaitForCloudServiceLoginAsync_003Ed__49 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder<bool> _003C_003Et__builder;

			public CloudService _003C_003E4__this;

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

		[CompilerGenerated]
		private sealed class _003CWaitForCloudServiceLoginRoutine_003Ed__47 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public CloudService _003C_003E4__this;

			object IEnumerator<object>.Current
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
			public _003CWaitForCloudServiceLoginRoutine_003Ed__47(int _003C_003E1__state)
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

			[DebuggerHidden]
			void IEnumerator.Reset()
			{
			}
		}

		internal const string RequestIDHeader = "X-Coherence-Request-ID";

		internal const string ClientVersionHeader = "X-Coherence-Client";

		internal const string SchemaIdHeader = "X-Coherence-Schema-ID";

		internal const string RSVersionHeader = "X-Coherence-Engine";

		internal bool shouldDisposeRequestFactoryAndAuthClient;

		private readonly IRequestFactory requestFactory;

		private readonly IAuthClientInternal authClient;

		private readonly IRuntimeSettings runtimeSettings;

		private IPlayerAccountProvider playerAccountProvider;

		private bool shouldDisposePlayerAccountProvider;

		public bool IsConnectedToCloud => false;

		public bool IsLoggedIn => false;

		public IRuntimeSettings RuntimeSettings => null;

		public WorldsService Worlds { get; }

		public CloudRooms Rooms { get; }

		public GameServices GameServices { get; }

		public IGameServersService GameServers { get; }

		internal AnalyticsClient AnalyticsClient { get; private set; }

		internal IRequestFactory RequestFactory => null;

		internal IAuthClientInternal AuthClient => null;

		internal IPlayerAccountProvider PlayerAccountProvider => null;

		public event Action OnConnectionLost
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

		public static CloudService ForClient(IRuntimeSettings runtimeSettings = null)
		{
			return null;
		}

		internal static CloudService ForClient([MaybeNull] IPlayerAccountProvider playerAccountProvider, IRuntimeSettings runtimeSettings = null, CloudUniqueId cloudUniqueId = default(CloudUniqueId), bool autoLoginAsGuest = false)
		{
			return null;
		}

		internal static CloudService ForSimulator(IRuntimeSettings runtimeSettings = null)
		{
			return null;
		}

		[Obsolete("This constructor will be removed in a future version. ForClient should be used instead.")]
		[Deprecated("08/2024", 1, 3, 1)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public CloudService(string uniqueId = null, bool autoLoginAsGuest = true, IRuntimeSettings runtimeSettings = null)
		{
		}

		private CloudService(CloudCredentialsPair credentials, IRuntimeSettings runtimeSettings, IPlayerAccountProvider playerAccountProvider)
		{
		}

		internal CloudService(CloudCredentialsPair credentials, IRuntimeSettings runtimeSettings, IPlayerAccountProvider playerAccountProvider, GameServices gameServices, CloudRooms rooms, WorldsService worlds, AnalyticsClient analyticsClient, GameServersService gameServers)
		{
		}

		[IteratorStateMachine(typeof(_003CWaitForCloudServiceLoginRoutine_003Ed__47))]
		public IEnumerator WaitForCloudServiceLoginRoutine()
		{
			return null;
		}

		[AsyncStateMachine(typeof(_003CWaitForCloudServiceLoginAsync_003Ed__48))]
		public Task<bool> WaitForCloudServiceLoginAsync(int millisecondsPollDelay)
		{
			return null;
		}

		[AsyncStateMachine(typeof(_003CWaitForCloudServiceLoginAsync_003Ed__49))]
		internal Task<bool> WaitForCloudServiceLoginAsync()
		{
			return null;
		}

		public void Dispose()
		{
		}

		[AsyncStateMachine(typeof(_003CDisposeAsync_003Ed__51))]
		internal ValueTask DisposeAsync(bool waitForOngoingOperationsToFinish)
		{
			return default(ValueTask);
		}

		private void OnWebSocketError()
		{
		}
	}
}
