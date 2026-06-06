using System.Collections.Generic;
using InteractionSystem;
using Unity.Netcode;
using UnityEngine;

namespace Brewery.Destruction.Extensible
{
	[RequireComponent(typeof(NetworkObject))]
	public class DestroyableStructure : NetworkBehaviour, IInteractable
	{
		public enum StructureState : byte
		{
			Pristine = 0,
			Destroyed = 1,
			Repairing = 2
		}

		[Header("Behaviours to Affect")]
		[Tooltip("Explicitly configured list of DestroyableBehaviours that will be triggered when this structure is hit.")]
		[SerializeField]
		private List<DestroyableBehaviour> behaviours;

		[Header("Repair Settings")]
		[SerializeField]
		private float repairAnimationDuration;

		[SerializeField]
		private float interactionDistance;

		[SerializeField]
		private int interactionPriority;

		[Header("UI Display")]
		[SerializeField]
		private Transform worldSpaceUIAnchor;

		[Header("Settings Reference")]
		[SerializeField]
		private DestroyableSettings settings;

		[Header("Debug")]
		[SerializeField]
		private bool showDebugLogs;

		private NetworkVariable<StructureState> currentState;

		private int pendingRepairCount;

		public StructureState CurrentState => default(StructureState);

		private void Awake()
		{
		}

		private void InitializeBehaviours()
		{
		}

		public override void OnNetworkSpawn()
		{
		}

		public override void OnNetworkDespawn()
		{
		}

		private void OnStateChanged(StructureState prev, StructureState next)
		{
		}

		public void TriggerDestruction(Vector3 impactForce, Vector3 impactPoint)
		{
		}

		private void StartRepair()
		{
		}

		[ClientRpc]
		private void TriggerRepairClientRpc()
		{
		}

		private void OnBehaviourRepairComplete()
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

		protected override void __initializeVariables()
		{
		}

		protected override void __initializeRpcs()
		{
		}

		private static void __rpc_handler_2748601915(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
		{
		}

		protected internal override string __getTypeName()
		{
			return null;
		}
	}
}
