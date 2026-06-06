using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using InteractionSystem;
using Unity.Netcode;
using UnityEngine;

namespace Vehicle.VanShelf
{
	[RequireComponent(typeof(NetworkObject))]
	[RequireComponent(typeof(VanShelfInventoryManager))]
	public class VanShelfInteractable : NetworkBehaviour, IInteractable
	{
		[CompilerGenerated]
		private sealed class _003CAnimateDoors_003Ed__39 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public VanShelfInteractable _003C_003E4__this;

			public bool open;

			private float _003CleftTargetAngle_003E5__2;

			private float _003CrightTargetAngle_003E5__3;

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
			public _003CAnimateDoors_003Ed__39(int _003C_003E1__state)
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

		[Header("Interaction Settings")]
		[SerializeField]
		private string interactionName;

		[SerializeField]
		private float interactionDistance;

		[SerializeField]
		private int interactionPriority;

		[Header("UI Display")]
		[Tooltip("Optional: Transform for world-space UI positioning. Leave null for default screen-space HUD.")]
		[SerializeField]
		private Transform worldSpaceUIAnchor;

		[Header("References")]
		[SerializeField]
		private VanShelfInventoryManager vanShelfInventory;

		[Header("Debug")]
		[SerializeField]
		private bool showDebugLogs;

		[Header("Cargo Door Animation")]
		[SerializeField]
		private Transform leftDoor;

		[SerializeField]
		private Transform rightDoor;

		[SerializeField]
		private float doorOpenAngle;

		[SerializeField]
		private float doorAnimationSpeed;

		private Coroutine doorAnimationCoroutine;

		private bool doorsOpen;

		private NetworkVariable<bool> doorsOpenState;

		public ulong VanShelfInventoryNetworkId => 0uL;

		public VanShelfInventoryManager Inventory => null;

		private void Awake()
		{
		}

		public override void OnNetworkSpawn()
		{
		}

		public override void OnNetworkDespawn()
		{
		}

		public string GetInteractionPrompt()
		{
			return null;
		}

		public bool CanInteract(ulong clientId)
		{
			return false;
		}

		public void Interact(ulong clientId)
		{
		}

		public float GetInteractionDistance()
		{
			return 0f;
		}

		public Transform GetInteractionTransform()
		{
			return null;
		}

		public int GetInteractionPriority()
		{
			return 0;
		}

		public void OnInteractionFocus()
		{
		}

		public void OnInteractionLoseFocus()
		{
		}

		public Transform GetWorldSpaceUIAnchor()
		{
			return null;
		}

		public void RequestVanShelfInventoryAccess()
		{
		}

		[ServerRpc(RequireOwnership = false)]
		private void RequestVanShelfInventoryAccessServerRpc(ServerRpcParams rpcParams = default(ServerRpcParams))
		{
		}

		[ClientRpc]
		private void OpenVanShelfInventoryClientRpc(ulong vanShelfInventoryNetworkObjectId, ClientRpcParams rpcParams = default(ClientRpcParams))
		{
		}

		public void OpenDoors()
		{
		}

		public void CloseDoors()
		{
		}

		[ServerRpc(RequireOwnership = false)]
		private void RequestOpenDoorsServerRpc()
		{
		}

		[ServerRpc(RequireOwnership = false)]
		private void RequestCloseDoorsServerRpc()
		{
		}

		private void OnDoorsStateChanged(bool previousValue, bool newValue)
		{
		}

		private void AnimateDoorsOpen()
		{
		}

		private void AnimateDoorsClose()
		{
		}

		[IteratorStateMachine(typeof(_003CAnimateDoors_003Ed__39))]
		private IEnumerator AnimateDoors(bool open)
		{
			return null;
		}

		private void OnDrawGizmosSelected()
		{
		}

		protected override void __initializeVariables()
		{
		}

		protected override void __initializeRpcs()
		{
		}

		private static void __rpc_handler_2617890054(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
		{
		}

		private static void __rpc_handler_3027568051(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
		{
		}

		private static void __rpc_handler_3853336914(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
		{
		}

		private static void __rpc_handler_2236658896(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
		{
		}

		protected internal override string __getTypeName()
		{
			return null;
		}
	}
}
