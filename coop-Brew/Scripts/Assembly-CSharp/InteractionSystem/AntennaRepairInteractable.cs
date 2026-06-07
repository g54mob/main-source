using Unity.Netcode;
using UnityEngine;

namespace InteractionSystem
{
	[RequireComponent(typeof(NetworkObject))]
	public class AntennaRepairInteractable : NetworkBehaviour, IInteractable
	{
		[Header("References")]
		[Tooltip("The speaker this antenna repairs")]
		[SerializeField]
		private SpeakerController linkedSpeaker;

		[Tooltip("The antenna transform to animate (mesh/model)")]
		[SerializeField]
		private Transform antennaTransform;

		[Header("Repair Animation")]
		[Tooltip("Duration of the repair animation")]
		[SerializeField]
		private float repairDuration;

		[Tooltip("Easing type for the repair animation")]
		[SerializeField]
		private LeanTweenType repairEase;

		[Header("Interaction Settings")]
		[SerializeField]
		private float interactionDistance;

		[SerializeField]
		private int interactionPriority;

		[Header("UI Display")]
		[Tooltip("Optional: Transform for world-space UI positioning")]
		[SerializeField]
		private Transform worldSpaceUIAnchor;

		private Vector3 _brokenRotation;

		private void Awake()
		{
		}

		public override void OnNetworkSpawn()
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

		[ClientRpc]
		private void PlayRepairAnimationClientRpc()
		{
		}

		protected override void __initializeVariables()
		{
		}

		protected override void __initializeRpcs()
		{
		}

		private static void __rpc_handler_1847758(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
		{
		}

		protected internal override string __getTypeName()
		{
			return null;
		}
	}
}
