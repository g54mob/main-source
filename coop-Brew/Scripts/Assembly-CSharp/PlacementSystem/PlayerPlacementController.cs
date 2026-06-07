using InventorySystem;
using Synty.AnimationBaseLocomotion.Samples.InputSystem;
using Unity.Netcode;
using UnityEngine;

namespace PlacementSystem
{
	[RequireComponent(typeof(NetworkObject))]
	public class PlayerPlacementController : NetworkBehaviour
	{
		public enum PlacementState
		{
			Idle = 0,
			Previewing = 1,
			Placed = 2
		}

		[Header("References")]
		[SerializeField]
		private InventoryManager inventoryManager;

		[SerializeField]
		private InputReader inputReader;

		[SerializeField]
		private PlacementPreviewController previewController;

		[Header("Settings")]
		[SerializeField]
		private GameObject placedObjectPrefabFallback;

		[Header("Validation Layer Masks")]
		[SerializeField]
		private LayerMask floorLayerMask;

		[SerializeField]
		private LayerMask wallLayerMask;

		[SerializeField]
		private LayerMask storageFloorLayerMask;

		[SerializeField]
		private LayerMask placedObjectLayerMask;

		[Tooltip("Layer for house floors. Furniture can ONLY be placed on this layer.")]
		[SerializeField]
		private LayerMask housingLayerMask;

		private PlacementState currentState;

		private Item currentPlaceableItem;

		private int lastSelectedSlot;

		private bool lastHUDValidState;

		private string lastHUDBlockReason;

		public bool IsInPlacementMode => false;

		public void CancelPlacement()
		{
		}

		private void Awake()
		{
		}

		public override void OnNetworkSpawn()
		{
		}

		public override void OnNetworkDespawn()
		{
		}

		private void OnSelectedSlotChanged(int slotIndex)
		{
		}

		private void EnterPlacementMode(Item item)
		{
		}

		private void ExitPlacementMode()
		{
		}

		private void Update()
		{
		}

		private void OnRotateCW()
		{
		}

		private void OnRotateCCW()
		{
		}

		private void UpdatePlacementHUD()
		{
		}

		private void ShowPlacementHUD(bool isValid, string blockReason)
		{
		}

		private void OnInteract()
		{
		}

		private void OnCancel()
		{
		}

		[ServerRpc]
		private void RequestPlaceItemServerRpc(string itemId, int inventorySlotIndex, Vector3 worldPosition, Quaternion worldRotation, ServerRpcParams rpcParams = default(ServerRpcParams))
		{
		}

		private bool ValidatePlacement(Vector3 position, Quaternion rotation, Item item, GameObject placingPlayer, ulong clientId, out string failReason, out string houseId, out Transform houseRoot)
		{
			failReason = null;
			houseId = null;
			houseRoot = null;
			return false;
		}

		private bool ValidateFurniturePlacement(Vector3 position, Quaternion rotation, Item item, GameObject placingPlayer, ulong clientId, out string failReason, out string houseId, out Transform houseRoot)
		{
			failReason = null;
			houseId = null;
			houseRoot = null;
			return false;
		}

		private bool ValidateStandardPlacement(Vector3 position, Quaternion rotation, Item item, GameObject placingPlayer, out string failReason)
		{
			failReason = null;
			return false;
		}

		private bool CheckFurnitureCollisions(Vector3 position, Quaternion rotation, Item item, GameObject placingPlayer, Collider housingFloorToIgnore, PlacedObject surfaceFurnitureToIgnore, out string failReason)
		{
			failReason = null;
			return false;
		}

		private bool CheckStandardCollisions(Vector3 position, Quaternion rotation, Item item, GameObject placingPlayer, out string failReason)
		{
			failReason = null;
			return false;
		}

		private Collider[] GetFurnitureOverlapsForPrefab(Collider prefabCol, Vector3 worldPosition, Quaternion worldRotation, Vector3 prefabRootScale)
		{
			return null;
		}

		private Collider[] GetOverlapsForPrefabCollider(Collider prefabCol, Vector3 worldPosition, Quaternion worldRotation, Vector3 prefabRootScale)
		{
			return null;
		}

		private bool IsOnFloorLayer(GameObject obj)
		{
			return false;
		}

		private bool IsOnStorageFloorLayer(GameObject obj)
		{
			return false;
		}

		private bool IsOnHousingLayer(GameObject obj)
		{
			return false;
		}

		private bool IsPartOfPlayer(GameObject obj, GameObject player)
		{
			return false;
		}

		[ClientRpc]
		private void NotifyPlacementFailedClientRpc(ulong targetClientId, string reason)
		{
		}

		[ClientRpc]
		private void NotifyFurniturePlacedClientRpc(ulong furnitureNetworkId, string houseId)
		{
		}

		protected override void __initializeVariables()
		{
		}

		protected override void __initializeRpcs()
		{
		}

		private static void __rpc_handler_814184330(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
		{
		}

		private static void __rpc_handler_492786756(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
		{
		}

		private static void __rpc_handler_2226294499(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
		{
		}

		protected internal override string __getTypeName()
		{
			return null;
		}
	}
}
