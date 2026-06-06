using System.Collections.Generic;
using Brewery.Items;
using Brewery.Systems;
using InventorySystem;
using Synty.AnimationBaseLocomotion.Samples.InputSystem;
using Unity.Collections;
using Unity.Netcode;
using UnityEngine;

namespace Brewery.CarryingSystem
{
	[RequireComponent(typeof(Animator))]
	public class CarryingController : NetworkBehaviour
	{
		[Header("References")]
		[SerializeField]
		private Animator animator;

		[SerializeField]
		private InputReader inputReader;

		[SerializeField]
		private InventoryManager inventoryManager;

		[SerializeField]
		private Transform carrySocket;

		[Header("Layer Configuration")]
		[Tooltip("Index of the two-handed carrying animation layer (barrel/crate)")]
		[SerializeField]
		private int carryLayerIndex;

		[Tooltip("Speed of layer weight fade in/out (higher = faster)")]
		[Range(1f, 20f)]
		[SerializeField]
		private float layerFadeSpeed;

		[Header("Crate Offsets")]
		[SerializeField]
		private Vector3 cratePositionOffset;

		[SerializeField]
		private Vector3 crateRotationOffset;

		[SerializeField]
		private Vector3 crateScale;

		[Header("Barrel Offsets")]
		[SerializeField]
		private Vector3 barrelPositionOffset;

		[SerializeField]
		private Vector3 barrelRotationOffset;

		[SerializeField]
		private Vector3 barrelScale;

		[Header("Animation")]
		[Tooltip("Duration of the appear/disappear animation")]
		[SerializeField]
		private float animationDuration;

		[Tooltip("Slight overshoot for a 'pop' feel (1.0 = no overshoot)")]
		[SerializeField]
		private float scaleOvershoot;

		[Header("Crate Rattle")]
		[Tooltip("Minimum time between rattle triggers")]
		[SerializeField]
		private float rattleCooldown;

		[Tooltip("Volume of bottle clink sound")]
		[Range(0f, 1f)]
		[SerializeField]
		private float rattleVolume;

		[Header("Debug")]
		[Tooltip("When enabled, position/rotation offsets are updated in realtime for tweaking")]
		[SerializeField]
		private bool realtimeOffsetAdjustment;

		private NetworkVariable<FixedString64Bytes> syncedCarriedItemId;

		private NetworkVariable<CrateMetadata> syncedCrateMetadata;

		private Item currentCarriedItem;

		private int currentCarriedSlotIndex;

		private float carryLayerWeight;

		private bool isCarrying;

		private GameObject spawnedCarryVisual;

		private CrateDisplayController crateDisplayController;

		private bool isCarryingCrate;

		private bool isCarryingSensor;

		private bool isAnimatingOut;

		private bool isAnimatingIn;

		private bool wasMoving;

		private float lastRattleTime;

		private const float CRATE_POLL_INTERVAL = 0.25f;

		private float crateContentCheckTimer;

		private int lastKnownCrateItemCount;

		private Dictionary<int, BeerDataSnapshot> carriedCrateBeverageMetadata;

		private bool hasSubscribedToInventory;

		private bool isInVehicle;

		private bool isSuppressed;

		private static readonly int IsCarryingHash;

		public bool IsCarryingTwoHanded => false;

		public Item CurrentCarriedItem => null;

		public GameObject CurrentVisual => null;

		private void Awake()
		{
		}

		private void OnEnable()
		{
		}

		public void SuppressCarrying()
		{
		}

		public void RestoreCarrying()
		{
		}

		public void OnVehicleEnter()
		{
		}

		public void OnVehicleExit()
		{
		}

		private void SubscribeToInventoryEvents()
		{
		}

		private void UnsubscribeFromInventoryEvents()
		{
		}

		public override void OnNetworkSpawn()
		{
		}

		private void OnDisable()
		{
		}

		private void Update()
		{
		}

		private void CheckCrateContentsChanged()
		{
		}

		private void SubscribeToCrateMetadataEvents()
		{
		}

		private void UnsubscribeFromCrateMetadataEvents()
		{
		}

		private void HandleCrateMetadataChangedEvent(ulong ownerId, int slotIndex, InventoryType inventoryType)
		{
		}

		private void CheckForRattle()
		{
		}

		private void TriggerCrateRattle()
		{
		}

		private void LateUpdate()
		{
		}

		private void ApplyOffsetsRealtime()
		{
		}

		private void ApplyOffsets()
		{
		}

		private Vector3 GetTargetScale()
		{
			return default(Vector3);
		}

		private void HandleSlotChanged(int slotIndex)
		{
		}

		private void ClearCarrying()
		{
		}

		private void HandleItemEquippedStateChanged(bool isEquipped)
		{
		}

		private void HandleInventoryUpdated()
		{
		}

		private void HandleInventorySlotChanged(int slotIndex, InventorySlot slot)
		{
		}

		private CrateMetadata GetCrateMetadataFromInventory(int slotIndex)
		{
			return default(CrateMetadata);
		}

		private void OnCarriedItemChanged(FixedString64Bytes oldValue, FixedString64Bytes newValue)
		{
		}

		private void SpawnCarryVisual(Item item)
		{
		}

		private void OnCrateMetadataChanged(CrateMetadata oldValue, CrateMetadata newValue)
		{
		}

		private void DestroyCarryVisual()
		{
		}

		private void DisablePhysicsOnVisual(GameObject visual)
		{
		}

		private void ApplyCrateBeverageVisualsFromInventory()
		{
		}

		private void ApplyStoredCrateBeverageVisuals()
		{
		}

		[ServerRpc]
		private void SyncCrateBeverageVisualServerRpc(int crateSlot, BeerDataSnapshot snapshot)
		{
		}

		[ClientRpc]
		private void SyncCrateBeverageVisualClientRpc(int crateSlot, BeerDataSnapshot snapshot)
		{
		}

		protected override void __initializeVariables()
		{
		}

		protected override void __initializeRpcs()
		{
		}

		private static void __rpc_handler_3478959877(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
		{
		}

		private static void __rpc_handler_1374096860(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
		{
		}

		protected internal override string __getTypeName()
		{
			return null;
		}
	}
}
