using System.Collections.Generic;
using System.Runtime.CompilerServices;
using FishNet.Connection;
using FishNet.Object;
using FishNet.Object.Synchronizing;
using FishNet.Serializing;
using FishNet.Transporting;
using ScheduleOne.Dialogue;
using ScheduleOne.Growing;
using ScheduleOne.ItemFramework;
using ScheduleOne.Management;
using ScheduleOne.NPCs.Behaviour;
using ScheduleOne.ObjectScripts;
using ScheduleOne.Persistence.Datas;
using ScheduleOne.Property;
using ScheduleOne.StationFramework;
using ScheduleOne.UI.Management;
using UnityEngine;

namespace ScheduleOne.Employees
{
	public class Botanist : Employee, IConfigurable
	{
		public const float CriticalWateringThreshold = 0.2f;

		public const float WateringThreshold = 0.3f;

		public const float MoistureLevelRandomMin = 0.9f;

		public const float MoistureLevelRandomMax = 1f;

		public const float SoilPourTime = 10f;

		public const float WaterPourTime = 10f;

		public const float AdditivePourTime = 10f;

		public const float SeedSowTime = 15f;

		public const float IndividualHarvestTime = 1f;

		public const float ApplySpawnTime = 15f;

		[Header("References")]
		public Sprite typeIcon;

		[SerializeField]
		protected ConfigurationReplicator configReplicator;

		[Header("UI")]
		public BotanistUIElement WorldspaceUIPrefab;

		public Transform uiPoint;

		[Header("Settings")]
		public int MaxAssignedPots;

		public DialogueContainer NoAssignedStationsDialogue;

		public DialogueContainer UnspecifiedPotsDialogue;

		public DialogueContainer NullDestinationPotsDialogue;

		public DialogueContainer MissingMaterialsDialogue;

		public DialogueContainer NoPotsRequireWorkDialogue;

		private StartDryingRackBehaviour _startDryingRackBehaviour;

		private StopDryingRackBehaviour _stopDryingRackBehaviour;

		private UseSpawnStationBehaviour _useSpawnStationBehaviour;

		private AddSoilToGrowContainerBehaviour _addSoilToGrowContainerBehaviour;

		private ApplyAdditiveToGrowContainerBehaviour _applyAdditiveToGrowContainerBehaviour;

		private SowSeedInPotBehaviour _sowSeedInPotBehaviour;

		private WaterPotBehaviour _waterPotBehaviour;

		private HarvestPotBehaviour _harvestPotBehaviour;

		private MistMushroomBedBehaviour _mistMushroomBedBehaviour;

		private HarvestMushroomBedBehaviour _harvestMushroomBedBehaviour;

		private ApplySpawnToMushroomBedBehaviour _applySpawnToMushroomBedBehaviour;

		private List<ScheduleOne.NPCs.Behaviour.Behaviour> _workBehaviours;

		public SyncVar<NetworkObject> syncVar____003CCurrentPlayerConfigurer_003Ek__BackingField;

		private bool NetworkInitialize___EarlyScheduleOne_002EEmployees_002EBotanistAssembly_002DCSharp_002Edll_Excuted;

		private bool NetworkInitialize__LateScheduleOne_002EEmployees_002EBotanistAssembly_002DCSharp_002Edll_Excuted;

		public EntityConfiguration Configuration => null;

		protected BotanistConfiguration configuration { get; set; }

		public ConfigurationReplicator ConfigReplicator => null;

		public EConfigurableType ConfigurableType => default(EConfigurableType);

		public WorldspaceUIElement WorldspaceUI { get; set; }

		public NetworkObject CurrentPlayerConfigurer
		{
			[CompilerGenerated]
			get
			{
				return null;
			}
			[CompilerGenerated]
			set
			{
			}
		}

		public Sprite TypeIcon => null;

		public Transform Transform => null;

		public Transform UIPoint => null;

		public bool CanBeSelected => false;

		public ScheduleOne.Property.Property ParentProperty => null;

		public NetworkObject SyncAccessor__003CCurrentPlayerConfigurer_003Ek__BackingField
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		[ServerRpc(RequireOwnership = false, RunLocally = true)]
		public void SetConfigurer(NetworkObject player)
		{
		}

		public override void Awake()
		{
		}

		protected override void UpdateBehaviour()
		{
		}

		private bool IsEntityAccessible(ITransitEntity entity)
		{
			return false;
		}

		private void StartDryingRack(DryingRack rack)
		{
		}

		private void StopDryingRack(DryingRack rack)
		{
		}

		public override void OnSpawnServer(NetworkConnection connection)
		{
		}

		public void SendConfigurationToClient(NetworkConnection conn)
		{
		}

		protected override void AssignProperty(ScheduleOne.Property.Property prop, bool warp)
		{
		}

		protected override void UnassignProperty()
		{
		}

		protected override void ResetConfiguration()
		{
		}

		protected override void Fire()
		{
		}

		private bool CanMoveDryableToRack(out QualityItemInstance dryable, out DryingRack destinationRack, out int moveQuantity)
		{
			dryable = null;
			destinationRack = null;
			moveQuantity = default(int);
			return false;
		}

		public QualityItemInstance GetDryableInSupplies()
		{
			return null;
		}

		private DryingRack GetAssignedDryingRackFor(QualityItemInstance dryable, out int rackInputCapacity)
		{
			rackInputCapacity = default(int);
			return null;
		}

		protected override bool ShouldIdle()
		{
			return false;
		}

		public override EmployeeHome GetHome()
		{
			return null;
		}

		public ITransitEntity GetSuppliesAsTransitEntity()
		{
			return null;
		}

		private Pot GetPotForWatering(float threshold)
		{
			return null;
		}

		private List<GrowContainer> GetGrowContainersForSoilPour()
		{
			return null;
		}

		private List<Pot> GetPotsReadyForSeed()
		{
			return null;
		}

		private List<GrowContainer> GetGrowContainersForAdditives()
		{
			return null;
		}

		private List<Pot> GetPotsForHarvest()
		{
			return null;
		}

		private MushroomBed GetMushroomBedForMisting(float threshold)
		{
			return null;
		}

		private List<MushroomBed> GetMushroomBedsForHarvest()
		{
			return null;
		}

		private List<MushroomBed> GetBedsReadyForSpawn()
		{
			return null;
		}

		private List<DryingRack> GetRacksToStart()
		{
			return null;
		}

		private List<DryingRack> GetRacksToStop()
		{
			return null;
		}

		private List<DryingRack> GetRacksReadyToMove()
		{
			return null;
		}

		private List<MushroomSpawnStation> GetSpawnStationsReadyToUse()
		{
			return null;
		}

		private List<MushroomSpawnStation> GetSpawnStationsReadyToMove()
		{
			return null;
		}

		public WorldspaceUIElement CreateWorldspaceUI()
		{
			return null;
		}

		public void DestroyWorldspaceUI()
		{
		}

		public override NPCData GetNPCData()
		{
			return null;
		}

		public override DynamicSaveData GetSaveData()
		{
			return null;
		}

		public override List<string> WriteData(string parentFolderPath)
		{
			return null;
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

		private void RpcWriter___Server_SetConfigurer_3323014238(NetworkObject player)
		{
		}

		public void RpcLogic___SetConfigurer_3323014238(NetworkObject player)
		{
		}

		private void RpcReader___Server_SetConfigurer_3323014238(PooledReader PooledReader0, Channel channel, NetworkConnection conn)
		{
		}

		public virtual bool ReadSyncVar___ScheduleOne_002EEmployees_002EBotanist(PooledReader PooledReader0, uint UInt321, bool Boolean2)
		{
			return false;
		}

		protected virtual void Awake_UserLogic_ScheduleOne_002EEmployees_002EBotanist_Assembly_002DCSharp_002Edll()
		{
		}
	}
}
