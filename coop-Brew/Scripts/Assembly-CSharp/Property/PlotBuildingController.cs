using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using BrewGame.SaveSystem.Integration;
using InventorySystem;
using PlacementSystem;
using Synty.AnimationBaseLocomotion.Samples.InputSystem;
using Unity.Netcode;
using UnityEngine;

namespace Property
{
	[RequireComponent(typeof(Collider))]
	public class PlotBuildingController : NetworkBehaviour, ISaveable
	{
		private struct OriginalTransform
		{
			public Vector3 localPosition;

			public Quaternion localRotation;

			public Vector3 localScale;
		}

		[CompilerGenerated]
		private sealed class _003CAnimationFailsafe_003Ed__72 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public float timeout;

			public GameObject part;

			public PlotBuildingController _003C_003E4__this;

			public Vector3 finalScale;

			public Vector3 finalLocalPos;

			public Quaternion finalLocalRot;

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
			public _003CAnimationFailsafe_003Ed__72(int _003C_003E1__state)
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

		[Header("Build Parts")]
		[Tooltip("Root GameObject containing the house structure. Auto-finds disabled mesh children in hierarchy order.")]
		[SerializeField]
		private Transform houseRoot;

		[Tooltip("Auto-detected build parts (disabled mesh children). Shown for debugging - populated at runtime.")]
		[SerializeField]
		private List<GameObject> buildParts;

		[Header("Hold-to-Build Settings")]
		[Tooltip("How long player must hold F to build one part")]
		[SerializeField]
		private float holdDuration;

		[Tooltip("Cost per build step in Construction Materials (0 = free building)")]
		[SerializeField]
		private int costPerStep;

		[Tooltip("Construction Materials item (auto-detected if null)")]
		[SerializeField]
		private Item constructionMaterialsItem;

		[Header("Animation Settings")]
		[Tooltip("Duration of the scale-in animation")]
		[SerializeField]
		private float animationDuration;

		[Tooltip("Starting scale for the animated part (0 = invisible)")]
		[SerializeField]
		private float startScale;

		[Tooltip("Animation easing type")]
		[SerializeField]
		private LeanTweenType easeType;

		[Header("Effects")]
		[Tooltip("Play build sound when placing a part")]
		[SerializeField]
		private bool playBuildSound;

		[Tooltip("Spawn build particles when placing a part")]
		[SerializeField]
		private bool spawnBuildParticles;

		[Header("UI Settings")]
		[Tooltip("Fixed position for the build UI. If not set, uses the build zone's transform.")]
		[SerializeField]
		private Transform uiAnchorOverride;

		[Header("Occlusion")]
		[Tooltip("Optional: OcclusionPortal to disable occlusion while house is unbuilt. When the house is not fully built, the portal is OPEN (no occlusion). When fully built, the portal is CLOSED (normal occlusion).")]
		[SerializeField]
		private OcclusionPortal occlusionPortal;

		[Tooltip("If true, automatically find OcclusionPortal on parent House or this GameObject")]
		[SerializeField]
		private bool autoFindOcclusionPortal;

		[Header("Debug")]
		[SerializeField]
		private bool showDebugLogs;

		private NetworkVariable<int> buildProgress;

		private House parentHouse;

		private PropertyManager propertyManager;

		private Collider buildZoneCollider;

		private bool isPlayerInZone;

		private bool isLocalPlayerPhysicallyInZone;

		private ulong playerInZoneClientId;

		private NetworkObject localPlayerNetworkObject;

		private InputReader localInputReader;

		private bool isHoldingBuild;

		private float holdStartTime;

		private int buildCountThisHold;

		private int holdStartProgress;

		private Animator playerAnimator;

		private static readonly int BuildHammerHash;

		private HammerItem hammerItemRef;

		private PlayerPlacementController playerPlacementController;

		private InventoryManager playerInventory;

		private HashSet<GameObject> animatingParts;

		private const float ANIMATION_FAILSAFE_MULTIPLIER = 2f;

		private Dictionary<GameObject, OriginalTransform> originalTransforms;

		private bool isSubscribedToOwnershipList;

		private float _nextRecoveryCheckTime;

		private bool _animatorParamChecked;

		private bool _animatorHasBuildHammerParam;

		private Animator _animatorParamCheckedFor;

		[Header("Material Swap (Up to 4 Variants)")]
		[Tooltip("Material variant 1. Assign in inspector.")]
		[SerializeField]
		private Material materialVariant1;

		[Tooltip("Material variant 2. Assign in inspector.")]
		[SerializeField]
		private Material materialVariant2;

		[Tooltip("Material variant 3 (optional). Assign in inspector.")]
		[SerializeField]
		private Material materialVariant3;

		[Tooltip("Material variant 4 (optional). Assign in inspector.")]
		[SerializeField]
		private Material materialVariant4;

		public bool IsBuildComplete => false;

		public bool IsPlotOwned => false;

		public ulong PlotOwnerClientId => 0uL;

		public string SaveableId => null;

		public int SavePriority => 0;

		public int GetBuildProgress()
		{
			return 0;
		}

		public int GetTotalBuildSteps()
		{
			return 0;
		}

		public Transform GetCurrentBuildPartTransform()
		{
			return null;
		}

		private Transform GetUIAnchor()
		{
			return null;
		}

		private void Awake()
		{
		}

		private new void OnDestroy()
		{
		}

		private void Update()
		{
		}

		private void AutoDetectBuildParts()
		{
		}

		public override void OnNetworkSpawn()
		{
		}

		public override void OnNetworkDespawn()
		{
		}

		private void SubscribeToInput()
		{
		}

		private void UnsubscribeFromInput()
		{
		}

		private void OnLocalInputReaderReady(InputReader reader)
		{
		}

		private void OnBuildKeyPressed()
		{
		}

		private void StartHoldToBuild()
		{
		}

		private void UpdateHoldToBuild()
		{
		}

		private float GetEffectiveBuildDuration()
		{
			return 0f;
		}

		private void CompleteBuild()
		{
		}

		private void CancelHoldToBuild()
		{
		}

		private void SetHammerAnimation(bool active)
		{
		}

		[ServerRpc(RequireOwnership = false)]
		private void RequestBuildStepServerRpc(ServerRpcParams rpcParams = default(ServerRpcParams))
		{
		}

		[ClientRpc]
		private void NotifyInsufficientMaterialsClientRpc(int playerHas, int required, ClientRpcParams rpcParams = default(ClientRpcParams))
		{
		}

		[ClientRpc]
		private void PlayBuildAnimationClientRpc(int partIndex, Vector3 builderPosition)
		{
		}

		private void PlayBuildAnimation(GameObject part, Vector3 builderPosition)
		{
		}

		private void FinalizePartAnimation(GameObject part, Vector3 finalLocalPos, Quaternion finalLocalRot, Vector3 finalScale)
		{
		}

		[IteratorStateMachine(typeof(_003CAnimationFailsafe_003Ed__72))]
		private IEnumerator AnimationFailsafe(GameObject part, Vector3 finalLocalPos, Quaternion finalLocalRot, Vector3 finalScale, float timeout)
		{
			return null;
		}

		private void CleanupAllAnimations()
		{
		}

		private void PlayBuildEffects(Vector3 position)
		{
		}

		private void OnBuildProgressChanged(int previousValue, int newValue)
		{
		}

		private void SyncBuildVisualsImmediate()
		{
		}

		private void SpawnChildNetworkObjects(GameObject part)
		{
		}

		private void SpawnAllChildNetworkObjects()
		{
		}

		private void UpdateOcclusionPortalState()
		{
		}

		public void OnPlotPurchased(ulong ownerClientId)
		{
		}

		private void OnTriggerEnter(Collider other)
		{
		}

		private void OnTriggerExit(Collider other)
		{
		}

		private bool IsPlayerInsideBuildZone(NetworkObject playerObj)
		{
			return false;
		}

		private void TryRecoverBuildZoneActivation()
		{
		}

		private void CachePlayerComponents(Collider playerCollider, NetworkObject networkObject)
		{
		}

		private void ActivateBuildZoneForOwner(NetworkObject networkObject)
		{
		}

		private void DeactivateBuildZone()
		{
		}

		private void OnHouseOwnershipListChanged(NetworkListEvent<HouseOwnership> changeEvent)
		{
		}

		private void SubscribeToInventory()
		{
		}

		private void UnsubscribeFromInventory()
		{
		}

		private void OnInventoryChanged()
		{
		}

		private bool IsHammerSelected()
		{
			return false;
		}

		private void ShowBuildPrompt()
		{
		}

		private void HideBuildPrompt()
		{
		}

		private void UpdateBuildPrompt()
		{
		}

		private string GetBuildPromptText()
		{
			return null;
		}

		[ContextMenu("Refresh Build Parts")]
		private void RefreshBuildParts()
		{
		}

		[ContextMenu("Enable All Build Parts")]
		private void EnableAllBuildParts()
		{
		}

		[ContextMenu("Disable All Build Parts")]
		private void DisableAllBuildParts()
		{
		}

		private Material[] GetAssignedVariants()
		{
			return null;
		}

		[ContextMenu("Apply Material 1")]
		private void ApplyMaterialVariant1()
		{
		}

		[ContextMenu("Apply Material 2")]
		private void ApplyMaterialVariant2()
		{
		}

		[ContextMenu("Apply Material 3")]
		private void ApplyMaterialVariant3()
		{
		}

		[ContextMenu("Apply Material 4")]
		private void ApplyMaterialVariant4()
		{
		}

		private void SwapToMaterial(Material targetMaterial, string targetName)
		{
		}

		[ContextMenu("Count Material Usage")]
		private void CountMaterialUsage()
		{
		}

		public Dictionary<string, object> CaptureState()
		{
			return null;
		}

		public void RestoreState(Dictionary<string, object> state)
		{
		}

		private void RegisterWithSaveSystem()
		{
		}

		private void UnregisterFromSaveSystem()
		{
		}

		[ClientRpc]
		public void SyncDoorStateClientRpc(bool isOpen, int gateIndex)
		{
		}

		protected override void __initializeVariables()
		{
		}

		protected override void __initializeRpcs()
		{
		}

		private static void __rpc_handler_2215516303(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
		{
		}

		private static void __rpc_handler_2101027254(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
		{
		}

		private static void __rpc_handler_2421214384(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
		{
		}

		private static void __rpc_handler_4247612600(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
		{
		}

		protected internal override string __getTypeName()
		{
			return null;
		}
	}
}
