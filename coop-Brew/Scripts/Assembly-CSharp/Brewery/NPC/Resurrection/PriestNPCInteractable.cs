using Brewery.NPC.Simple;
using HighlightPlus;
using InteractionSystem;
using Unity.Netcode;
using UnityEngine;

namespace Brewery.NPC.Resurrection
{
	[RequireComponent(typeof(NetworkObject))]
	public class PriestNPCInteractable : NetworkBehaviour, IInteractable
	{
		[Header("Settings")]
		[SerializeField]
		private float interactionDistance;

		[SerializeField]
		private int interactionPriority;

		[SerializeField]
		private string priestDisplayName;

		[Header("Debug")]
		[SerializeField]
		private bool showDebugLogs;

		private HighlightEffect highlightEffect;

		private Transform interactionAnchor;

		private SimpleNPCHeadLook headLook;

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

		private bool CanInteractInternal()
		{
			return false;
		}

		private void LookAtPlayer(Transform player)
		{
		}

		[Rpc(SendTo.SpecifiedInParams)]
		private void OpenResurrectionUIClientRpc(RpcParams rpcParams = default(RpcParams))
		{
		}

		protected override void __initializeVariables()
		{
		}

		protected override void __initializeRpcs()
		{
		}

		private static void __rpc_handler_1240156616(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
		{
		}

		protected internal override string __getTypeName()
		{
			return null;
		}
	}
}
