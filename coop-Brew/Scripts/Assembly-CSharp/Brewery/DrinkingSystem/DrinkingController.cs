using System;
using System.Runtime.CompilerServices;
using Brewery.Audio;
using Brewery.Items;
using Brewery.Pee;
using InventorySystem;
using ParticleEffects;
using Synty.AnimationBaseLocomotion.Samples.InputSystem;
using Unity.Collections;
using Unity.Netcode;
using UnityEngine;

namespace Brewery.DrinkingSystem
{
	[RequireComponent(typeof(Animator))]
	public class DrinkingController : NetworkBehaviour
	{
		[Header("References")]
		[SerializeField]
		private Animator animator;

		[SerializeField]
		private InputReader inputReader;

		[SerializeField]
		private InventoryManager inventoryManager;

		[SerializeField]
		private Transform dropPoint;

		[SerializeField]
		private Transform drinkSocket;

		[SerializeField]
		private AnimationEventHandler animationEventHandler;

		[SerializeField]
		private DrinkEffectsController drinkEffectsController;

		[SerializeField]
		private PeeController peeController;

		[Header("Layer Configuration")]
		[Tooltip("Index of UpperBody_Combat layer")]
		[SerializeField]
		private int drinkLayerIndex;

		[Tooltip("Speed of layer weight fade in/out (higher = faster)")]
		[Range(1f, 20f)]
		[SerializeField]
		private float layerFadeSpeed;

		[Header("Drop Settings")]
		[SerializeField]
		private float dropForce;

		[Header("Animation")]
		[Tooltip("Duration of the appear/disappear animation")]
		[SerializeField]
		private float animationDuration;

		[Tooltip("Slight overshoot for a 'pop' feel (1.0 = no overshoot)")]
		[SerializeField]
		private float scaleOvershoot;

		[Header("Realtime Adjustment")]
		[Tooltip("When enabled, item offsets are updated every frame for tweaking in play mode")]
		[SerializeField]
		private bool realtimeOffsetAdjustment;

		[Header("Throwing")]
		[Tooltip("Force applied forward when throwing an empty bottle")]
		[SerializeField]
		private float throwForce;

		[Tooltip("Upward force added when throwing an empty bottle")]
		[SerializeField]
		private float throwUpwardForce;

		[Tooltip("Random spin torque applied on throw")]
		[SerializeField]
		private float throwSpinTorque;

		[Tooltip("Override throw origin (defaults to drink socket)")]
		[SerializeField]
		private Transform throwOrigin;

		[Tooltip("Animator layer used for throw (UpperBody_Attacking for better mask)")]
		[SerializeField]
		private int throwLayerIndex;

		[Tooltip("Primary particle effect for bottle impact (glass shatter)")]
		[SerializeField]
		private ParticleEffectManager.ParticleType bottleImpactParticle;

		[Tooltip("Secondary particle effect for bottle impact (debris/dust)")]
		[SerializeField]
		private ParticleEffectManager.ParticleType bottleSecondaryImpactParticle;

		[Tooltip("Primary particle effect for molotov impact (glass shatter)")]
		[SerializeField]
		private ParticleEffectManager.ParticleType molotovImpactParticle;

		[Tooltip("Secondary particle effect for molotov impact (fire explosion)")]
		[SerializeField]
		private ParticleEffectManager.ParticleType molotovExplosionParticle;

		[Tooltip("How much of the player's current velocity to add to the throw")]
		[SerializeField]
		private float inheritVelocityFactor;

		[Header("Debug")]
		[SerializeField]
		private bool showDebugLogs;

		[Header("Moped IK Override")]
		[SerializeField]
		private bool overrideMopedHandIkWhileDriving;

		[Range(0f, 1f)]
		[SerializeField]
		private float drivingLeftHandIkWeight;

		[Range(0f, 1f)]
		[SerializeField]
		private float drivingRightHandIkWeight;

		private NetworkVariable<FixedString64Bytes> syncedHeldItemId;

		private NetworkVariable<BeerDataSnapshot> syncedHeldBeverageMetadata;

		private BeverageItem currentDrink;

		private EmptyBottleItem currentEmptyBottle;

		private MolotovItem currentMolotov;

		private Item currentGenericItem;

		private int currentDrinkSlotIndex;

		private int currentBottleSlotIndex;

		private int currentMolotovSlotIndex;

		private int currentGenericSlotIndex;

		private int lastSelectedSlotIndex;

		private float drinkLayerWeight;

		private float throwLayerWeight;

		private bool isHoldingDrink;

		private bool isDrinking;

		private bool isThrowing;

		private bool suppressDrinkLayerForHammer;

		private GameObject spawnedDrinkVisual;

		private Item currentHeldItemForOffsets;

		private GameObject predictedBottleInstance;

		private float predictedBottleTimeout;

		private const float PredictedBottleLifetime = 3f;

		private Transform cachedCork;

		private bool isAnimatingIn;

		private bool hasSubscribedToEvents;

		private CharacterController characterController;

		private Rigidbody cachedRigidbody;

		private static readonly int IsDrinkingHash;

		private static readonly int IsHoldingDrinkHash;

		private static readonly int ThrowBottleHash;

		private static readonly int IsDrivingHash;

		public bool ShouldOverrideMopedHandIkWeights => false;

		public float DrivingLeftHandIkWeight => 0f;

		public float DrivingRightHandIkWeight => 0f;

		public bool IsHoldingDrink => false;

		public bool IsDrinking => false;

		public bool IsThrowing => false;

		public event Action<BeerDataSnapshot> OnLocalDrinkConsumed
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		private void Awake()
		{
		}

		private void OnEnable()
		{
		}

		private void SubscribeToOwnerEvents()
		{
		}

		private void UnsubscribeFromOwnerEvents()
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

		private void LateUpdate()
		{
		}

		private void EnsureVisualExists()
		{
		}

		public void OnVehicleExit()
		{
		}

		private void UpdateDrinkLayer()
		{
		}

		private void UpdateThrowLayer()
		{
		}

		private void OnHeldItemChanged(FixedString64Bytes oldValue, FixedString64Bytes newValue)
		{
		}

		private void HandleSlotChanged(int slotIndex)
		{
		}

		private void HandleItemEquippedStateChanged(bool isEquipped)
		{
		}

		private void HandleInventoryUpdated()
		{
		}

		private void SpawnDrinkVisual(BeverageItem beverage)
		{
		}

		private void ApplyBeverageVisualToHeldItem()
		{
		}

		private void OnBeverageMetadataChanged(BeerDataSnapshot prev, BeerDataSnapshot current)
		{
		}

		private void SpawnEmptyBottleVisual(EmptyBottleItem emptyBottle)
		{
		}

		private void SpawnMolotovVisual(MolotovItem molotov)
		{
		}

		private void DestroyDrinkVisual()
		{
		}

		private void DisablePhysicsOnVisual(GameObject visual)
		{
		}

		private void HandleDrinkPressed()
		{
		}

		private void HandleDrinkFinished()
		{
		}

		private void HandleDrinkStart()
		{
		}

		public void TriggerThrowAnimationExternal()
		{
		}

		private Item GetCurrentThrowable()
		{
			return null;
		}

		private void StartThrow()
		{
		}

		public void HandleBottleThrowRelease()
		{
		}

		public void HandleBottleThrowFinished()
		{
		}

		private void SpawnPredictedProjectile(Item throwable, Vector3 origin, Vector3 forward, Vector3 inheritedVelocity)
		{
		}

		[ServerRpc]
		private void ThrowItemServerRpc(Vector3 origin, Vector3 forward, Vector3 inheritedVelocity, int slotIndex, ServerRpcParams rpcParams = default(ServerRpcParams))
		{
		}

		private void SpawnBottleProjectile(EmptyBottleItem emptyBottle, int slotIndex, Vector3 origin, Vector3 forward, Vector3 inheritedVelocity)
		{
		}

		private void SpawnMolotovProjectile(MolotovItem molotovItem, int slotIndex, Vector3 origin, Vector3 forward, Vector3 inheritedVelocity)
		{
		}

		private GameObject SpawnProjectileBase(GameObject prefab, Vector3 origin, Vector3 forward, Vector3 inheritedVelocity)
		{
			return null;
		}

		private void SpawnPredictedMolotov(Vector3 origin, Vector3 forward, Vector3 inheritedVelocity)
		{
		}

		[ServerRpc]
		private void PopCorkServerRpc()
		{
		}

		[ClientRpc]
		private void PopCorkClientRpc()
		{
		}

		private Transform FindCorkInHierarchy(Transform parent)
		{
			return null;
		}

		private void AnimateCorkPop(GameObject cork)
		{
		}

		[ServerRpc]
		private void DrinkBeverageServerRpc(int slotIndex, ServerRpcParams rpcParams = default(ServerRpcParams))
		{
		}

		private void ApplyPlainDrinkEffects(NetworkObject playerObject, BeverageItem drinkItem)
		{
		}

		private void SpawnDroppedBottle(Item emptyBottle, Transform playerTransform)
		{
		}

		[ClientRpc]
		private void ClearPredictedBottleClientRpc(ClientRpcParams rpcParams = default(ClientRpcParams))
		{
		}

		private bool IsInputBlocked()
		{
			return false;
		}

		private void GetThrowOriginAndForward(out Vector3 origin, out Vector3 forward)
		{
			origin = default(Vector3);
			forward = default(Vector3);
		}

		private Vector3 GetPlayerVelocity()
		{
			return default(Vector3);
		}

		private void SpawnPredictedBottle(Vector3 origin, Vector3 forward, Vector3 inheritedVelocity)
		{
		}

		private void CleanupPredictedBottle()
		{
		}

		private void UpdatePredictedBottle()
		{
		}

		private bool IsEmptyBottle(Item item, out EmptyBottleItem emptyBottle)
		{
			emptyBottle = null;
			return false;
		}

		private bool IsMolotov(Item item, out MolotovItem molotov)
		{
			molotov = null;
			return false;
		}

		private bool IsGenericHoldableItem(Item item)
		{
			return false;
		}

		private void SpawnGenericItemVisual(Item item)
		{
		}

		protected override void __initializeVariables()
		{
		}

		protected override void __initializeRpcs()
		{
		}

		private static void __rpc_handler_1689563211(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
		{
		}

		private static void __rpc_handler_1847389289(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
		{
		}

		private static void __rpc_handler_3928967049(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
		{
		}

		private static void __rpc_handler_1999763183(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
		{
		}

		private static void __rpc_handler_246816954(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
		{
		}

		protected internal override string __getTypeName()
		{
			return null;
		}
	}
}
