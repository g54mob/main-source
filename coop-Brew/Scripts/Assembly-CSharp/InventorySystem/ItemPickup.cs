using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using InteractionSystem;
using Unity.Netcode;
using UnityEngine;

namespace InventorySystem
{
	[RequireComponent(typeof(NetworkObject))]
	public class ItemPickup : NetworkBehaviour, IInteractable
	{
		[CompilerGenerated]
		private sealed class _003CDelayedDespawnCoroutine_003Ed__47 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public ItemPickup _003C_003E4__this;

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
			public _003CDelayedDespawnCoroutine_003Ed__47(int _003C_003E1__state)
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

		[CompilerGenerated]
		private sealed class _003CFollowPlayerCoroutine_003Ed__49 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public ItemPickup _003C_003E4__this;

			private float _003Celapsed_003E5__2;

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
			public _003CFollowPlayerCoroutine_003Ed__49(int _003C_003E1__state)
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

		[CompilerGenerated]
		private sealed class _003CTemporarilyIgnoreLocalPlayerCollision_003Ed__30 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public ItemPickup _003C_003E4__this;

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
			public _003CTemporarilyIgnoreLocalPlayerCollision_003Ed__30(int _003C_003E1__state)
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

		[Header("Item Configuration")]
		[SerializeField]
		private Item item;

		[SerializeField]
		private int quantity;

		[Header("Pickup Settings")]
		[SerializeField]
		private float pickupDistance;

		[SerializeField]
		private float rotationSpeed;

		[SerializeField]
		private float bobHeight;

		[SerializeField]
		private float bobSpeed;

		[Header("Visual Effects")]
		[SerializeField]
		private bool enableRotation;

		[SerializeField]
		private bool enableBobbing;

		[Header("Physics")]
		[Tooltip("When enabled, item uses Rigidbody physics instead of floating. Requires Rigidbody component.")]
		[SerializeField]
		private bool usePhysics;

		[Header("Auto Pickup")]
		[SerializeField]
		private bool autoPickup;

		[SerializeField]
		private float autoPickupDistance;

		[SerializeField]
		private float pickupAnimDuration;

		[SerializeField]
		private float pickupHeightOffset;

		[SerializeField]
		private float pickupCooldownAfterDrop;

		[Header("UI Display")]
		[Tooltip("Optional: Transform for world-space UI positioning. Leave null for default screen-space HUD.")]
		[SerializeField]
		private Transform worldSpaceUIAnchor;

		private Vector3 startPosition;

		private bool isBeingPickedUp;

		private float pickupAvailableTime;

		private NetworkObject targetPlayer;

		private float pickupStartTime;

		private Material _highlightMaterial;

		private Renderer _cachedRenderer;

		public Item Item => null;

		public int Quantity => 0;

		private void Awake()
		{
		}

		private void Start()
		{
		}

		public override void OnDestroy()
		{
		}

		public override void OnNetworkSpawn()
		{
		}

		[IteratorStateMachine(typeof(_003CTemporarilyIgnoreLocalPlayerCollision_003Ed__30))]
		private IEnumerator TemporarilyIgnoreLocalPlayerCollision()
		{
			return null;
		}

		private void Update()
		{
		}

		private void CheckProximityPickup()
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

		private int TryPickupImmediate(ulong clientId, InventoryManager inventoryManager)
		{
			return 0;
		}

		public void Interact(ulong clientId)
		{
		}

		[ClientRpc]
		private void UpdateQuantityClientRpc(int newQuantity)
		{
		}

		[ClientRpc]
		private void HideBeforeDespawnClientRpc()
		{
		}

		public override void OnNetworkDespawn()
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

		private void StartAutoPickup(ulong clientId, NetworkObject playerNetworkObject)
		{
		}

		[IteratorStateMachine(typeof(_003CDelayedDespawnCoroutine_003Ed__47))]
		private IEnumerator DelayedDespawnCoroutine()
		{
			return null;
		}

		[ClientRpc]
		private void PlayPickupAnimationClientRpc(ulong playerNetworkObjectId, ulong clientId)
		{
		}

		[IteratorStateMachine(typeof(_003CFollowPlayerCoroutine_003Ed__49))]
		private IEnumerator FollowPlayerCoroutine(ulong clientId)
		{
			return null;
		}

		private void DespawnPickup()
		{
		}

		private InventoryManager GetPlayerInventory(ulong clientId)
		{
			return null;
		}

		[ClientRpc]
		private void PickupEffectClientRpc()
		{
		}

		[ClientRpc]
		private void InventoryFullClientRpc(ulong targetClientId)
		{
		}

		public void SetItem(Item newItem, int newQuantity = 1)
		{
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

		private static void __rpc_handler_2046482830(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
		{
		}

		private static void __rpc_handler_2872577807(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
		{
		}

		private static void __rpc_handler_1365143123(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
		{
		}

		private static void __rpc_handler_4097740277(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
		{
		}

		private static void __rpc_handler_4002833775(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
		{
		}

		protected internal override string __getTypeName()
		{
			return null;
		}
	}
}
