using InteractionSystem;
using InventorySystem;
using Unity.Netcode;
using UnityEngine;

namespace PlacementSystem
{
	[DisallowMultipleComponent]
	[RequireComponent(typeof(NetworkObject))]
	public class PlacedObject : NetworkBehaviour, IInteractable
	{
		[Header("Placement Data")]
		[SerializeField]
		private Item sourceItem;

		[SerializeField]
		private Vector3 placedWorldPosition;

		[SerializeField]
		private Quaternion placedWorldRotation;

		[Header("Interaction")]
		[SerializeField]
		private string interactionPrompt;

		[SerializeField]
		private float interactionDistance;

		[SerializeField]
		private float holdDuration;

		[Header("UI Display")]
		[Tooltip("Optional: Transform for world-space UI positioning. Leave null for default screen-space HUD.")]
		[SerializeField]
		private Transform worldSpaceUIAnchor;

		[Header("Pre-placed Objects")]
		[Tooltip("Enable for stations pre-placed in scene. They will be usable without going through placement system.")]
		[SerializeField]
		private bool forceIsPlaced;

		[Tooltip("Unique ID for scene-placed objects. Used to track pickup across save/load. Auto-generated if empty.")]
		[SerializeField]
		private string sceneObjectId;

		[Header("Debug")]
		[SerializeField]
		private bool showDebugLogs;

		private NetworkVariable<ulong> placerClientId;

		private NetworkVariable<bool> isPlaced;

		[SerializeField]
		private string placedInHouseId;

		private Transform houseRoot;

		public Item SourceItem => null;

		public Vector3 PlacedWorldPosition => default(Vector3);

		public Quaternion PlacedWorldRotation => default(Quaternion);

		public float HoldDuration => 0f;

		public bool IsPlaced => false;

		public bool IsScenePlaced => false;

		public string SceneObjectId => null;

		public string PlacedInHouseId => null;

		public Transform HouseRoot => null;

		public void SetPlacedInHouse(string houseId, Transform houseRootTransform = null)
		{
		}

		private void Awake()
		{
		}

		public void Initialize(Item item, Vector3 worldPosition, Quaternion worldRotation, ulong placerId)
		{
		}

		private void ValidateColliderSetup()
		{
		}

		public override void OnNetworkSpawn()
		{
		}

		public override void OnNetworkDespawn()
		{
		}

		private void NotifyBarFactionManager(bool isPlaced)
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

		public bool ShouldRemainFocused(ulong clientId)
		{
			return false;
		}

		[ServerRpc(RequireOwnership = false)]
		public void RequestPickupServerRpc(ServerRpcParams rpcParams = default(ServerRpcParams))
		{
		}

		[ClientRpc]
		private void SendPickupFailedClientRpc(string reason, ClientRpcParams rpcParams = default(ClientRpcParams))
		{
		}

		protected override void __initializeVariables()
		{
		}

		protected override void __initializeRpcs()
		{
		}

		private static void __rpc_handler_4040184839(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
		{
		}

		private static void __rpc_handler_781718916(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
		{
		}

		protected internal override string __getTypeName()
		{
			return null;
		}
	}
}
