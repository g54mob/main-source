using Brewery.Data;
using Brewery.NPC.Data;
using Brewery.Stand;
using Unity.Netcode;
using UnityEngine;

namespace Brewery.NPC.Simple
{
	internal class NPCContext
	{
		public SimpleNPCPersonality Personality;

		public INPCMotor Motor;

		public SimpleNPCAnimator Animator;

		public Transform Transform;

		public NetworkObject NetworkObject;

		public bool IsServer;

		public NPCProfile Profile;

		public FactionData Faction;

		public string NpcName;

		public NPCRoles NpcRole;

		public NPCState CurrentState;

		public Vector3 HomePosition;

		public float StateTimer;

		public Transform CurrentDestination;

		public SimpleBarLocation CurrentBar;

		public BarSpot CurrentBarSpot;

		public float NextPurchaseAttempt;

		public float NextWanderTime;

		public bool IsSitting;

		public Vector3 StandingSpotCenter;

		public float WalkingToSpotStartTime;

		public float WalkingToSpotTimeout;

		public int DrinksConsumed;

		public int DrinksGoal;

		public GameObject CurrentDrinkObject;

		public string CurrentDrinkName;

		public float NextSipTime;

		public bool IsHoldingDrink;

		public bool IsActiveDrinking;

		public float CurrentDrinkStartTime;

		public float CurrentDrinkFinishTime;

		public float RestPeriodEndTime;

		public bool IsRegisteredForServing;

		public float WaitingStartTime;

		public float NextWaveTime;

		public StandLocation CurrentStand;

		public int StandDrinksGoal;

		public int StandDrinksConsumed;

		public bool IsAtStand;

		public float StandWaitingStartTime;

		public float StandMaxWaitTime;

		public bool IsWaitingForPayment;

		public float PendingPaymentAmount;

		public string PendingDrinkName;

		public string PendingDrinkItemId;

		public float PaymentWaitStartTime;

		public WorkLocation AssignedWorkLocation;

		public int WorkLocationSlotIndex;

		public bool IsClerkOffDuty;

		public NetworkVariable<int> NetworkState;

		public float MinHomeTime;

		public float MaxHomeTime;

		public float MinHotspotTime;

		public float MaxHotspotTime;

		public float MaxBarSpotWaitTime;

		public float MaxWaitTimePerDrink;

		public float PurchaseAttemptInterval;

		public float WanderInterval;

		public float BarSpotArrivalDistance;

		public Transform DrinkHandBone;

		public float SipInterval;

		public float DrinkDuration;

		public float TimeBetweenDrinks;

		public float ThugDetectionRadius;

		public LayerMask ThugLayerMask;

		public float PlayerProximityCheckRadius;

		public float ClerkRotationSpeed;

		public bool ShowDebugLogs;

		public float StandBasePatience;

		public float StandDrinkDuration;

		public float StandWanderRadius;

		public float StandWanderInterval;

		public float StandLeaveTimeout;

		public float StandSipInterval;

		public float StandRestBetweenDrinks;
	}
}
