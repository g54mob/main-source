using Brewery.Bar.PhysicalServing;
using Brewery.NPC.Simple;
using InteractionSystem;
using Unity.Collections;
using Unity.Netcode;
using UnityEngine;

namespace Brewery.Stand
{
	[RequireComponent(typeof(SimpleNPCController))]
	public class NPCStandServingTarget : NetworkBehaviour, IInteractable
	{
		[Header("References")]
		[SerializeField]
		private SimpleNPCController npcController;

		[SerializeField]
		private NPCDrinkRequestPanel requestPanel;

		[Header("Configuration")]
		[SerializeField]
		private float interactionDistance;

		[SerializeField]
		private int interactionPriority;

		[Header("UI Display")]
		[SerializeField]
		private Transform worldSpaceUIAnchor;

		private NetworkVariable<bool> _netIsAtStand;

		private NetworkVariable<bool> _netIsWaitingForPayment;

		private NetworkVariable<float> _netPaymentAmount;

		private NetworkVariable<FixedString128Bytes> _netDrinkName;

		private NetworkVariable<FixedString128Bytes> _netDrinkItemId;

		private NetworkVariable<float> _netStandMaxWaitTime;

		private ulong npcNetworkId;

		public bool IsAtStand => false;

		public bool IsWaitingForPayment => false;

		public float PaymentAmount => 0f;

		public string PendingDrinkName => null;

		public string PendingDrinkItemId => null;

		public float StandMaxWaitTime => 0f;

		private void Awake()
		{
		}

		public override void OnNetworkSpawn()
		{
		}

		private void Update()
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

		private bool CanShowInteraction()
		{
			return false;
		}

		[ServerRpc(RequireOwnership = false)]
		private void CollectPaymentServerRpc(ulong clientId, ServerRpcParams rpcParams = default(ServerRpcParams))
		{
		}

		[ClientRpc]
		private void PlayCoinRattleClientRpc(Vector3 position)
		{
		}

		[ClientRpc]
		private void NotifyPaymentCollectedClientRpc(string drinkName, float price, ulong targetClientId)
		{
		}

		protected override void __initializeVariables()
		{
		}

		protected override void __initializeRpcs()
		{
		}

		private static void __rpc_handler_1484559491(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
		{
		}

		private static void __rpc_handler_937848981(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
		{
		}

		private static void __rpc_handler_507755349(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
		{
		}

		protected internal override string __getTypeName()
		{
			return null;
		}
	}
}
