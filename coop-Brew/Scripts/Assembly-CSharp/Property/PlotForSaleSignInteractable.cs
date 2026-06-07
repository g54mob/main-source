using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using InteractionSystem;
using Unity.Netcode;
using UnityEngine;

namespace Property
{
	[RequireComponent(typeof(NetworkObject))]
	public class PlotForSaleSignInteractable : NetworkBehaviour, IInteractable
	{
		[CompilerGenerated]
		private sealed class _003CDelayedOwnershipCheck_003Ed__38 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public PlotForSaleSignInteractable _003C_003E4__this;

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
			public _003CDelayedOwnershipCheck_003Ed__38(int _003C_003E1__state)
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
		private float interactionDistance;

		[SerializeField]
		private int interactionPriority;

		[Header("UI Display")]
		[Tooltip("Optional: Transform for world-space UI positioning")]
		[SerializeField]
		private Transform worldSpaceUIAnchor;

		[Header("Visual Feedback")]
		[Tooltip("The 'For Sale' sign - visible when NOT purchased, animates out on purchase")]
		[SerializeField]
		private GameObject forSaleSignObject;

		[Tooltip("The postal box - visible when purchased, animates in on purchase")]
		[SerializeField]
		private GameObject postalBoxObject;

		[Tooltip("Optional particle effect for 'For Sale' indication")]
		[SerializeField]
		private ParticleSystem forSaleParticles;

		[Header("Animation Settings")]
		[Tooltip("Duration of the pop in/out animation")]
		[SerializeField]
		private float animationDuration;

		[Tooltip("Delay before postal box appears after sign disappears")]
		[SerializeField]
		private float postalBoxDelay;

		[Header("References")]
		[Tooltip("The PlotBuildingController on this plot (auto-detected if not assigned)")]
		[SerializeField]
		private PlotBuildingController buildingController;

		[Header("Debug")]
		[SerializeField]
		private bool showDebugLogs;

		[Header("Rent Status (Read-Only)")]
		[SerializeField]
		private string _rentTimeRemaining;

		[SerializeField]
		private string _accumulatedRent;

		private House parentHouse;

		private PropertyManager propertyManager;

		private bool isHousePurchased;

		private bool isAnimating;

		private Vector3 forSaleSignOriginalScale;

		private Vector3 postalBoxOriginalScale;

		public House ParentHouse => null;

		public HouseData HouseData => null;

		public bool IsPurchased => false;

		public new ulong OwnerClientId => 0uL;

		public string PlotName => null;

		public int PlotPrice => 0;

		public bool IsFullyBuilt => false;

		private void Awake()
		{
		}

		private void AutoDetectChildObjects()
		{
		}

		private void CacheOriginalScales()
		{
		}

		private void EnsurePostalBoxCollider()
		{
		}

		private void SetInitialVisibility()
		{
		}

		public override void OnNetworkSpawn()
		{
		}

		[IteratorStateMachine(typeof(_003CDelayedOwnershipCheck_003Ed__38))]
		private IEnumerator DelayedOwnershipCheck()
		{
			return null;
		}

		private void OnHouseOwnershipListChanged(NetworkListEvent<HouseOwnership> changeEvent)
		{
		}

		public override void OnNetworkDespawn()
		{
		}

		public new void OnDestroy()
		{
		}

		private void CancelAnimations()
		{
		}

		private void OnOwnershipChanged(string houseId, ulong newOwnerId)
		{
		}

		private void CheckOwnershipState(bool skipAnimation = false)
		{
		}

		private void UpdateVisuals()
		{
		}

		private void AnimatePurchaseTransition()
		{
		}

		private void AnimatePostalBoxIn()
		{
		}

		private void AnimateUnpurchaseTransition()
		{
		}

		private void AnimateForSaleSignIn()
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

		[ClientRpc]
		private void OpenPurchaseUIClientRpc(ClientRpcParams rpcParams = default(ClientRpcParams))
		{
		}

		public bool ShouldRemainFocused(ulong clientId)
		{
			return false;
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

		public void RefreshOwnershipState()
		{
		}

		protected override void __initializeVariables()
		{
		}

		protected override void __initializeRpcs()
		{
		}

		private static void __rpc_handler_2455825035(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
		{
		}

		protected internal override string __getTypeName()
		{
			return null;
		}
	}
}
