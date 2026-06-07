using UnityEngine;

namespace Simulator.GameWorld
{
	public class BillsManager : WorldManager
	{
		[field: SerializeField]
		[field: ReadOnly(false, false)]
		public RentBill RentBill { get; private set; }

		[field: SerializeField]
		[field: ReadOnly(false, false)]
		public ElecBill ElecBill { get; private set; }

		[field: SerializeField]
		[field: ReadOnly(false, false)]
		public SalariesBill SalariesBill { get; private set; }

		public virtual float GetTotalBills()
		{
			return RentBill.DueAmount + ElecBill.DueAmount + SalariesBill.DueAmount;
		}

		public virtual void TryPayAll()
		{
			RentBill.TryPay();
			ElecBill.TryPay();
			SalariesBill.TryPay();
		}

		protected override void OnWorldEvent(EWorldEvent worldEvent)
		{
			base.OnWorldEvent(worldEvent);
			switch (worldEvent)
			{
			case EWorldEvent.LOADING_PHASE1:
				Load();
				break;
			case EWorldEvent.SAVE:
				Save();
				break;
			}
		}

		protected override void OnGameEvent(EGameEvent gameEvent)
		{
			base.OnGameEvent(gameEvent);
			switch (gameEvent)
			{
			case EGameEvent.DAY_END:
				OnDayEnd();
				break;
			case EGameEvent.DAY_START:
				OnDayStart();
				break;
			}
		}

		private void OnDayStart()
		{
			RentBill.HandleScoreMalus();
			ElecBill.HandleScoreMalus();
			SalariesBill.HandleScoreMalus();
		}

		protected virtual void OnDayEnd()
		{
			RentBill.UnPaid();
			ElecBill.UnPaid();
			SalariesBill.UnPaid();
		}

		protected virtual void Load()
		{
			SaveClass_Bills bills = SaveManager.CurrentSave.bills;
			RentBill = bills.rentBill;
			ElecBill = bills.elecBill;
			SalariesBill = bills.salariesBill;
		}

		protected virtual void Save()
		{
			SaveClass_Bills bills = SaveManager.CurrentSave.bills;
			bills.rentBill = RentBill;
			bills.elecBill = ElecBill;
			bills.salariesBill = SalariesBill;
		}
	}
}
