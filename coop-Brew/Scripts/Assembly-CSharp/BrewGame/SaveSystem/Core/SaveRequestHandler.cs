using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Unity.Netcode;
using UnityEngine;

namespace BrewGame.SaveSystem.Core
{
	public class SaveRequestHandler : NetworkBehaviour
	{
		[StructLayout(LayoutKind.Auto)]
		[CompilerGenerated]
		private struct _003CPerformSaveAndNotifyClient_003Ed__12 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder _003C_003Et__builder;

			public SaveRequestHandler _003C_003E4__this;

			public ulong clientId;

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

		[StructLayout(LayoutKind.Auto)]
		[CompilerGenerated]
		private struct _003CPerformSaveOnServer_003Ed__13 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder<bool> _003C_003Et__builder;

			public SaveRequestHandler _003C_003E4__this;

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

		[StructLayout(LayoutKind.Auto)]
		[CompilerGenerated]
		private struct _003CRequestSaveAsync_003Ed__10 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder<bool> _003C_003Et__builder;

			public SaveRequestHandler _003C_003E4__this;

			private Task _003CtimeoutTask_003E5__2;

			private TaskAwaiter<bool> _003C_003Eu__1;

			private TaskAwaiter<Task> _003C_003Eu__2;

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

		[Header("Debug")]
		[SerializeField]
		private bool showDebugLogs;

		private Dictionary<ulong, bool> pendingSaveRequests;

		private TaskCompletionSource<bool> clientSaveCompletionSource;

		private bool isWaitingForSaveResponse;

		public static SaveRequestHandler Instance { get; private set; }

		public bool IsWaitingForSave => false;

		private void Awake()
		{
		}

		public override void OnDestroy()
		{
		}

		[AsyncStateMachine(typeof(_003CRequestSaveAsync_003Ed__10))]
		public Task<bool> RequestSaveAsync()
		{
			return null;
		}

		[Rpc(SendTo.Server, RequireOwnership = false)]
		private void RequestSaveServerRpc(RpcParams rpcParams = default(RpcParams))
		{
		}

		[AsyncStateMachine(typeof(_003CPerformSaveAndNotifyClient_003Ed__12))]
		private Task PerformSaveAndNotifyClient(ulong clientId)
		{
			return null;
		}

		[AsyncStateMachine(typeof(_003CPerformSaveOnServer_003Ed__13))]
		private Task<bool> PerformSaveOnServer()
		{
			return null;
		}

		[ClientRpc]
		private void SaveCompleteClientRpc(bool success, ClientRpcParams clientRpcParams = default(ClientRpcParams))
		{
		}

		protected override void __initializeVariables()
		{
		}

		protected override void __initializeRpcs()
		{
		}

		private static void __rpc_handler_300684604(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
		{
		}

		private static void __rpc_handler_1232824365(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
		{
		}

		protected internal override string __getTypeName()
		{
			return null;
		}
	}
}
