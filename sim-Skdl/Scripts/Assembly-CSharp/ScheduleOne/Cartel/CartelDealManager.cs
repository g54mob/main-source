using FishNet.Connection;
using FishNet.Object;
using FishNet.Serializing;
using FishNet.Transporting;
using ScheduleOne.Core;
using ScheduleOne.Economy;
using ScheduleOne.ItemFramework;
using ScheduleOne.NPCs;
using ScheduleOne.Persistence.Datas;
using ScheduleOne.Product;
using ScheduleOne.Quests;
using ScheduleOne.Storage;
using UnityEngine;

namespace ScheduleOne.Cartel
{
	public class CartelDealManager : NetworkBehaviour
	{
		public const int DEAL_DUE_TIME_DAYS = 3;

		public const float PAYMENT_MULTIPLIER = 0.65f;

		public const int DEAL_COOLDOWN_HOURS = 24;

		[Header("References")]
		public NPC RequestingNPC;

		public Quest_DealForCartel DealQuest;

		public WorldStorageEntity DeliveryEntity;

		public Transform CashSpawnPoint;

		public Quest MethRequestPrereqQuest;

		public Supplier CokeRequestPrereqSupplier;

		[Header("Settings")]
		public CashPickup CashPrefab;

		public ProductDefinition[] RequestableWeed;

		public ProductDefinition MethDefinition;

		public ProductDefinition CocaineDefinition;

		public int ProductQuantityMin;

		public int ProductQuantityMax;

		private bool NetworkInitialize___EarlyScheduleOne_002ECartel_002ECartelDealManagerAssembly_002DCSharp_002Edll_Excuted;

		private bool NetworkInitialize__LateScheduleOne_002ECartel_002ECartelDealManagerAssembly_002DCSharp_002Edll_Excuted;

		public CartelDealInfo ActiveDeal { get; private set; }

		public int HoursUntilNextDealRequest { get; private set; }

		public virtual void Awake()
		{
		}

		private void Start()
		{
		}

		public override void OnSpawnServer(NetworkConnection connection)
		{
		}

		private void MinPass()
		{
		}

		private void OnTimeSkip(int mins)
		{
		}

		private void HourPass()
		{
		}

		public void SetHoursUntilDealRequest(int hours)
		{
		}

		private void SleepEnd()
		{
		}

		private void MarkDealOverdue()
		{
		}

		private void ExpireDeal()
		{
		}

		private void CheckDealCompletion()
		{
		}

		private void CompleteDeal()
		{
		}

		private void DepositCash(float amount)
		{
		}

		[Button]
		private void StartDeal()
		{
		}

		public void LoadDeal(CartelDealInfo dealInfo)
		{
		}

		[TargetRpc]
		[ObserversRpc(RunLocally = true)]
		private void InitializeDealQuest(NetworkConnection conn, CartelDealInfo dealInfo)
		{
		}

		private void SendRequestMessage(CartelDealInfo dealInfo)
		{
		}

		private void SendOverdueMessage()
		{
		}

		private void SendExpiryMessage()
		{
		}

		public void Load(CartelData data)
		{
		}

		private void CartelStatusChange(ECartelStatus oldStatus, ECartelStatus newStatus)
		{
		}

		public virtual void NetworkInitialize___Early()
		{
		}

		public virtual void NetworkInitialize__Late()
		{
		}

		public override void NetworkInitializeIfDisabled()
		{
		}

		private void RpcWriter___Observers_InitializeDealQuest_2137933519(NetworkConnection conn, CartelDealInfo dealInfo)
		{
		}

		private void RpcLogic___InitializeDealQuest_2137933519(NetworkConnection conn, CartelDealInfo dealInfo)
		{
		}

		private void RpcReader___Observers_InitializeDealQuest_2137933519(PooledReader PooledReader0, Channel channel)
		{
		}

		private void RpcWriter___Target_InitializeDealQuest_2137933519(NetworkConnection conn, CartelDealInfo dealInfo)
		{
		}

		private void RpcReader___Target_InitializeDealQuest_2137933519(PooledReader PooledReader0, Channel channel)
		{
		}

		private void Awake_UserLogic_ScheduleOne_002ECartel_002ECartelDealManager_Assembly_002DCSharp_002Edll()
		{
		}
	}
}
