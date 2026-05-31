using CTS.BBT;
using CTS.BBT.AI;
using CTS.Core;
using UnityEngine;

namespace CTS
{
	public class Level01QuestChain : QuestChain
	{
		private bool _hungerSystemEnabled;

		[field: SerializeField]
		public Level01PrestigeData StartPrestigeData { get; private set; }

		[field: SerializeField]
		public Level01PrestigeData ScenarizedPrestigeData { get; private set; }

		[field: SerializeField]
		public Level01PrestigeData NormalPrestigeData { get; private set; }

		[field: SerializeField]
		public Prestige PrestigeManager { get; private set; }

		[field: SerializeField]
		internal LevelParameters LevelParameters { get; private set; }

		[field: SerializeField]
		internal CustomerSpawner CustomerSpawner { get; private set; }

		[field: SerializeField]
		public StockMonthlyDelivery StockMonthlyDelivery { get; private set; }

		[field: SerializeField]
		public StockDeliveryData ScenerizedStockDeliveryData { get; private set; }

		public MissionBasket MissionBasket
		{
			get
			{
				if (!CTSSingleton<StoreBaskets>.InstanceExists())
				{
					return null;
				}
				return CTSSingleton<StoreBaskets>.Instance.MainMissionBasket;
			}
		}

		public LockToggle StoreButtonLocker { get; } = new LockToggle();

		public LockToggle OpenBarButtonDisplayLocker { get; } = new LockToggle();

		public LockToggle OpenBarButtonLocker { get; } = new LockToggle();

		public LockToggle AgencyButtonLocker { get; } = new LockToggle();

		public LockToggle BarButtonLocker { get; } = new LockToggle();

		public LockToggle FurnitureShopLocker { get; } = new LockToggle();

		public LockToggle ConstructionDestructionLocker { get; } = new LockToggle();

		public LockToggle ConstructionInteriorLocker { get; } = new LockToggle();

		public LockToggle ConstructionZoneLocker { get; } = new LockToggle();

		public LockToggle MachinesUILocker { get; } = new LockToggle();

		public LockToggle WorkerManagerLocker { get; } = new LockToggle();

		public Worker FirstWorker { get; set; }

		public Customer PreviousInhabitant { get; set; }

		protected override void OnDisabled()
		{
			base.OnDisabled();
			WorkerHirePanel.Hiring -= OnHiring;
		}

		protected override void OnEnabled()
		{
			base.OnEnabled();
			WorkerHirePanel.Hiring += OnHiring;
		}

		private void OnDestroy()
		{
			ContextualAction.UnlockAction<ContextualActionSuckBloodKill>();
			ContextualAction.UnlockAction<ContextualActionHypnosis>();
			ContextualAction.UnlockAction<ContextualActionWipeMemory>();
			ContextualAction.UnlockAction<ContextualActionOpenUI>();
			MachinesUILocker.Unlock();
			ToggleWorkersGlobalAutonomy(value: true);
		}

		private void OnHiring(Agent worker)
		{
			worker.Statistics.Paused = !_hungerSystemEnabled;
		}

		protected override void QuestChainInitialization()
		{
			base.QuestChainInitialization();
			PrestigeManager.SetPrestigeData(StartPrestigeData);
			BBTUI.SetupCanvasLock(BBTUI.Instance.ButtonID_Stocks, StoreButtonLocker, doLock: true);
			BBTUI.SetupCanvasLock(BBTUI.Instance.ButtonID_OpenBar, OpenBarButtonDisplayLocker, doLock: true);
			BBTUI.SetupCanvasLock(BBTUI.Instance.ButtonID_GoToAgency, AgencyButtonLocker, doLock: true);
			BBTUI.SetupCanvasLock(BBTUI.Instance.ButtonID_FurnitureShop, FurnitureShopLocker, doLock: true);
			BBTUI.SetupCanvasLock(BBTUI.Instance.ButtonID_DestructionTool, ConstructionDestructionLocker, doLock: true);
			BBTUI.SetupCanvasLock(BBTUI.Instance.ButtonID_InteriorTool, ConstructionInteriorLocker, doLock: true);
			BBTUI.SetupCanvasLock(BBTUI.Instance.ButtonID_RoomTypeTool, ConstructionZoneLocker, doLock: true);
			BBTUI.SetupCanvasLock(BBTUI.Instance.ButtonID_Machines, MachinesUILocker, doLock: true);
			BBTUI.SetupCanvasLock(BBTUI.Instance.ButtonID_WorkerManager, WorkerManagerLocker, doLock: true);
			BBTUI.SetupButtonLock(BBTUI.Instance.ButtonID_GoToBar, BarButtonLocker, doLock: false);
			BBTUI.SetupButtonLock(BBTUI.Instance.ButtonID_OpenBar, OpenBarButtonLocker, doLock: false);
			ContextualAction.LockAction<ContextualActionSuckBloodKill>();
			ContextualAction.LockAction<ContextualActionHypnosis>();
			ContextualAction.LockAction<ContextualActionWipeMemory>();
			ContextualAction.LockAction<ContextualActionOpenUI>();
			ToggleWorkersGlobalAutonomy(value: false);
		}

		public void BarkFirstWorker(string text, float duration)
		{
			Barks.BarkAgent(FirstWorker, text, duration);
		}

		public void BarkPreviousInhabitant(string text, float duration)
		{
			Barks.BarkAgent(PreviousInhabitant, text, duration);
		}

		public void ToggleWorkersGlobalAutonomy(bool value)
		{
			Worker.CVarAutonomyEnabled.SetCurrentValue(value);
		}

		public void SetScenarizedPrestige()
		{
			PrestigeManager.SetPrestigeData(ScenarizedPrestigeData);
		}

		public void SwitchPrestigeDataToNormal()
		{
			PrestigeManager.SetPrestigeData(NormalPrestigeData);
		}

		public void SetHungerActive(bool active)
		{
			if (_hungerSystemEnabled == active)
			{
				return;
			}
			_hungerSystemEnabled = active;
			foreach (Worker item in WorkerList.All)
			{
				item.Statistics.SetStatisticFromUnitInterval(EAgentStatistics.Hunger, 1f);
				item.Statistics.Paused = !_hungerSystemEnabled;
			}
		}

		public void SetScenerizedStock(bool scenerized)
		{
			StockMonthlyDelivery.ForceCustomMonthlyDelivery(scenerized ? ScenerizedStockDeliveryData : null);
		}

		public void UnlockStore()
		{
			StoreButtonLocker.Unlock();
		}
	}
}
