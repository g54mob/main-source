using Brewery.Data;
using Brewery.Items;
using Brewery.NPC.Data;
using Unity.Netcode;
using UnityEngine;

namespace Brewery.NPC.Simple
{
	[RequireComponent(typeof(AStarNPCMotor))]
	public class SimpleNPCController : NetworkBehaviour
	{
		public enum DrinkingStatus
		{
			NotAtBar = 0,
			WaitingForDrink = 1,
			ActivelyDrinking = 2,
			Resting = 3
		}

		[Header("Components")]
		[SerializeField]
		private AStarNPCMotor motor;

		[SerializeField]
		private SimpleNPCAnimator npcAnimator;

		[Header("Profile")]
		[Tooltip("NPC profile data (set by manager on spawn)")]
		[SerializeField]
		private NPCProfile profile;

		[Header("NPC Info")]
		[SerializeField]
		private string npcName;

		[Header("Clerk Specific (Store Clerk NPCs)")]
		[Tooltip("NPC role - determines behavior (Townsfolk vs StoreClerk)")]
		[SerializeField]
		private NPCRoles npcRole;

		[Tooltip("Assigned work location (set automatically from profile)")]
		[SerializeField]
		private WorkLocation assignedWorkLocation;

		private int workLocationSlotIndex;

		[SerializeField]
		private float playerProximityCheckRadius;

		[SerializeField]
		private float clerkRotationSpeed;

		private bool isClerkOffDuty;

		[Header("Faction (For Drink Purchasing)")]
		[Tooltip("Which faction this NPC belongs to (affects drink prices and refused tags)")]
		[SerializeField]
		private FactionData factionData;

		[Header("Timing (Randomized Per NPC)")]
		[Tooltip("Reduced defaults for faster observable behavior. Original: 5-15s")]
		[SerializeField]
		private float minHomeTime;

		[SerializeField]
		private float maxHomeTime;

		[SerializeField]
		private float minHotspotTime;

		[SerializeField]
		private float maxHotspotTime;

		[Header("Bar Behavior")]
		[Tooltip("Max time NPC will stay at bar before giving up and going home (total)")]
		[SerializeField]
		private float maxBarSpotWaitTime;

		[Tooltip("Max time NPC will wait for a SINGLE drink before giving up and leaving")]
		[SerializeField]
		private float maxWaitTimePerDrink;

		[Tooltip("Try to purchase drink every X seconds while at bar")]
		[SerializeField]
		private float purchaseAttemptInterval;

		[Tooltip("Change wander position every X seconds (standing spots only)")]
		[SerializeField]
		private float wanderInterval;

		[Tooltip("How close NPC needs to be to bar spot to consider arrived (meters)")]
		[SerializeField]
		private float barSpotArrivalDistance;

		[Header("Drinking Behavior")]
		[Tooltip("Hand bone to hold drink (right hand)")]
		[SerializeField]
		private Transform drinkHandBone;

		[Tooltip("Trigger sip animation every X seconds while actively drinking")]
		[SerializeField]
		private float sipInterval;

		[Tooltip("How long NPC actively drinks each beverage (sips during this time)")]
		[SerializeField]
		private float drinkDuration;

		[Tooltip("Rest time after finishing a drink before buying next one")]
		[SerializeField]
		private float timeBetweenDrinks;

		[Header("Raid Avoidance")]
		[Tooltip("Detection radius for nearby raiding thugs (NPCs flee when thugs get this close)")]
		[SerializeField]
		private float thugDetectionRadius;

		[Tooltip("Layer mask for detecting thugs (should include 'Thug' layer)")]
		[SerializeField]
		private LayerMask thugLayerMask;

		[Header("Debug")]
		[SerializeField]
		private bool showDebugLogs;

		[Tooltip("TESTING ONLY: Skip home/hotspot and go directly to bar on spawn")]
		[SerializeField]
		private bool forceGoToBarOnStart;

		private NPCState currentState;

		private float stateTimer;

		private Vector3 homePosition;

		private Transform currentDestination;

		private SimpleBarLocation currentBar;

		private BarSpot currentBarSpot;

		private float nextPurchaseAttempt;

		private float nextWanderTime;

		private bool isSitting;

		private Vector3 standingSpotCenter;

		private float walkingToSpotStartTime;

		private float walkingToSpotTimeout;

		private int drinksConsumed;

		private int drinksGoal;

		private GameObject currentDrinkObject;

		private string currentDrinkName;

		private float nextSipTime;

		private bool isHoldingDrink;

		private bool isActiveDrinking;

		private float currentDrinkStartTime;

		private float currentDrinkFinishTime;

		private float restPeriodEndTime;

		private bool isRegisteredForServing;

		private float waitingStartTime;

		private float nextWaveTime;

		private bool _visitorBehaviorOverride;

		private NetworkVariable<int> networkState;

		private NPCContext ctx;

		private NPCNavigationBehavior navigation;

		private NPCBarSelectionBehavior barSelection;

		private NPCBarExitBehavior barExit;

		private NPCDrinkingBehavior drinking;

		private NPCTownRoutineBehavior townRoutine;

		private NPCBarVisitBehavior barVisit;

		private NPCClerkBehavior clerk;

		private NPCSpeechBubbleController speechBubble;

		private SimpleNPCLifeBrain _lifeBrain;

		private float _lastRepathAttemptTime;

		private int _repathAttemptCount;

		private const float REPATH_COOLDOWN = 0.75f;

		private const int MAX_REPATH_ATTEMPTS = 4;

		public bool IsAtBar => false;

		public bool IsAtHome => false;

		public bool VisitorBehaviorOverride
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public string NpcName => null;

		public NPCProfile Profile => null;

		public bool IsRegisteredForServing => false;

		public bool IsHoldingDrink => false;

		public bool IsInCombat => false;

		public NPCSpeechBubbleController SpeechBubble => null;

		public bool UseNewBrainSystem => false;

		public NPCState GetCurrentState()
		{
			return default(NPCState);
		}

		public float GetWaitingTime()
		{
			return 0f;
		}

		public float GetMaxWaitTime()
		{
			return 0f;
		}

		public float GetWaitingProgress()
		{
			return 0f;
		}

		public string GetWaitingTimeFormatted()
		{
			return null;
		}

		public string GetDisplayName()
		{
			return null;
		}

		public FactionData GetFaction()
		{
			return null;
		}

		public void Say(string trigger, float duration = -1f)
		{
		}

		public int GetDrinksConsumed()
		{
			return 0;
		}

		public int GetDrinksGoal()
		{
			return 0;
		}

		public DrinkingStatus GetDrinkingStatus()
		{
			return default(DrinkingStatus);
		}

		public float GetRestTimeRemaining()
		{
			return 0f;
		}

		public bool IsReadyForNextDrink()
		{
			return false;
		}

		internal NPCDrinkingBehavior GetDrinkingBehavior()
		{
			return null;
		}

		internal NPCBarVisitBehavior GetBarVisitBehavior()
		{
			return null;
		}

		internal NPCContext GetContext()
		{
			return null;
		}

		public void ClearBarSpotReference()
		{
		}

		internal void SpawnDrinkVisualClientRpcWrapper(string beverageName)
		{
		}

		internal void RemoveDrinkVisualClientRpcWrapper()
		{
		}

		internal void SpawnDrinkVisualWithMetadataClientRpcWrapper(string beverageName, BeerDataSnapshot metadata)
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

		private void InitializeContext()
		{
		}

		private void InitializeModules()
		{
		}

		private void Update()
		{
		}

		private bool IsWorkHours()
		{
			return false;
		}

		private void UpdateTownsfolkBehavior()
		{
		}

		private void UpdateWalking(string destination)
		{
		}

		private void UpdateAtBar()
		{
		}

		private void SyncContextToFields()
		{
		}

		public void InitializeWithProfile(NPCProfile npcProfile, Vector3 homePos)
		{
		}

		[ContextMenu("\ud83e\uddea Force Go To Bar Now")]
		public void ForceGoToBar()
		{
		}

		[ContextMenu("\ud83c\udfe0 Force Go Home Now")]
		public void ForceGoHome()
		{
		}

		public void ForceFleeFromRaid()
		{
		}

		public void UpdateHomePosition(Vector3 newHomePosition)
		{
		}

		public void ForceClerkLeaveWork()
		{
		}

		public void ReceiveDrinkFromBarman(string beverageName, BeerDataSnapshot? metadata = null)
		{
		}

		public void HoldDrinkWithoutDrinking(string beverageName, BeerDataSnapshot? metadata = null)
		{
		}

		public void StartDrinkingHeldDrink()
		{
		}

		[ClientRpc]
		private void SpawnDrinkVisualClientRpc(string beverageName)
		{
		}

		[ClientRpc]
		private void SpawnDrinkVisualWithMetadataClientRpc(string beverageName, BeerDataSnapshot metadata)
		{
		}

		[ClientRpc]
		private void RemoveDrinkVisualClientRpc()
		{
		}

		[ClientRpc]
		private void PlayGulpSoundClientRpc(Vector3 position)
		{
		}

		internal void PlayGulpSoundClientRpcWrapper(Vector3 position)
		{
		}

		[ClientRpc]
		private void SetDrunkForDurationClientRpc(float duration)
		{
		}

		internal void SetDrunkForDurationClientRpcWrapper(float duration)
		{
		}

		[ClientRpc]
		private void ShowSpeechBubbleClientRpc(string text, float duration)
		{
		}

		private void FindWorkLocation(string locationId)
		{
		}

		private bool HasArrived(float customDistance = -1f)
		{
			return false;
		}

		private bool TryRepathToBarSpot()
		{
			return false;
		}

		private bool TryWarpToValidPosition()
		{
			return false;
		}

		private bool TryChooseDifferentSpot()
		{
			return false;
		}

		private void ResetRepathState()
		{
		}

		private void OnDrawGizmosSelected()
		{
		}

		protected override void __initializeVariables()
		{
		}

		protected override void __initializeRpcs()
		{
		}

		private static void __rpc_handler_2188699146(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
		{
		}

		private static void __rpc_handler_2352282392(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
		{
		}

		private static void __rpc_handler_3873540487(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
		{
		}

		private static void __rpc_handler_2063835826(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
		{
		}

		private static void __rpc_handler_3107387620(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
		{
		}

		private static void __rpc_handler_982841272(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
		{
		}

		protected internal override string __getTypeName()
		{
			return null;
		}
	}
}
