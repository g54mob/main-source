using ScheduleOne.Audio;
using ScheduleOne.ItemFramework;
using ScheduleOne.Map;
using ScheduleOne.NPCs.Behaviour;
using ScheduleOne.NPCs.Schedules;
using ScheduleOne.PlayerScripts;
using UnityEngine;

namespace ScheduleOne.NPCs.CharacterClasses
{
	public class SewerGoblin : NPC
	{
		public enum ESewerGoblinState
		{
			Inactive = 0,
			Attacking = 1,
			Retrieving = 2,
			Retreating = 3
		}

		public const int COOLDOWN_HOURS_BETWEEN_DEPLOYS = 12;

		public const float HOURLY_DEPLOY_CHANCE = 0.1f;

		public const float NORMALIZED_HEALTH_THRESHOLD_TO_RETREAT = 0.5f;

		public const float RETREAT_CHANCE_AFTER_HIT = 0.3f;

		public const int MAX_CANCELLED_RETRIEVE_ATTEMPTS = 3;

		[Header("References")]
		public NPCEnterableBuilding SewerHidingBuilding;

		public NPCEvent_StayInBuilding StayInBuildingEvent;

		public ItemDefinition PacifyItem;

		public SewerGoblinRetrieveBehaviour RetrieveBehaviour;

		public AudioSourceController ExitSound;

		[HideInInspector]
		public int cancelledRetrieveAttempts;

		private bool NetworkInitialize___EarlyScheduleOne_002ENPCs_002ECharacterClasses_002ESewerGoblinAssembly_002DCSharp_002Edll_Excuted;

		private bool NetworkInitialize__LateScheduleOne_002ENPCs_002ECharacterClasses_002ESewerGoblinAssembly_002DCSharp_002Edll_Excuted;

		public Player TargetPlayer { get; private set; }

		public ESewerGoblinState CurrentState { get; private set; }

		public int HoursSinceLastDeploy { get; set; }

		public override void Awake()
		{
		}

		protected override void Start()
		{
		}

		private void Update()
		{
		}

		private void OnMinPass()
		{
		}

		private void OnHourPass()
		{
		}

		public void DeployToPlayer(Player player)
		{
		}

		private void AttackTarget()
		{
		}

		public void Retreat()
		{
		}

		protected override void EnterBuilding(string buildingGUID, int doorIndex)
		{
		}

		protected override void ExitBuilding(NPCEnterableBuilding building)
		{
		}

		public void DeployToLocalPlayer()
		{
		}

		private void OnSuccesfulCombatHit()
		{
		}

		private bool CanBeginRetieve()
		{
			return false;
		}

		private void BeginRetrieve()
		{
		}

		private void OnRetrieveCancel()
		{
		}

		private void OnRetrieveSuccess()
		{
		}

		public bool IsPlayerValidTarget(Player player)
		{
			return false;
		}

		public bool IsPlayerHoldingPacifyItem(Player player)
		{
			return false;
		}

		public override void ProcessImpactForce(Vector3 forcePoint, Vector3 forceDirection, float force)
		{
		}

		private void OnTakeDamage(float damageAmount)
		{
		}

		public override void NetworkInitialize___Early()
		{
		}

		public override void NetworkInitialize__Late()
		{
		}

		public override void NetworkInitializeIfDisabled()
		{
		}

		protected virtual void Awake_UserLogic_ScheduleOne_002ENPCs_002ECharacterClasses_002ESewerGoblin_Assembly_002DCSharp_002Edll()
		{
		}
	}
}
