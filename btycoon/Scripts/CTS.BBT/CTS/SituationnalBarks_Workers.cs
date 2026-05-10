using CTS.BBT;
using CTS.BBT.AI;
using CTS.Core;
using CTS.StockInventory;
using UnityEngine;

namespace CTS
{
	public class SituationnalBarks_Workers : SituationnalBarks
	{
		[SerializeField]
		private SituationlBarkSO _vampireEnter;

		[SerializeField]
		private SituationlBarkSO _hadBodyBag;

		[SerializeField]
		private SituationlBarkSO _monthnegatif;

		[SerializeField]
		private SituationlBarkSO _machinekillsomeone;

		[SerializeField]
		private SituationlBarkSO _winAPrestigeLevel;

		[SerializeField]
		private SituationlBarkSO _closeBar;

		[SerializeField]
		private SituationlBarkSO _openBar;

		[SerializeField]
		private SituationlBarkSO _vigilance50;

		[SerializeField]
		private SituationlBarkSO _vigilance75;

		[SerializeField]
		private SituationlBarkSO _fridgeFull;

		[SerializeField]
		private StringKey<StockType> _stockToMonitor;

		[SerializeField]
		private SituationlBarkSO _hunterEnterBar;

		[SerializeField]
		private SituationlBarkSO _panicInTheBar;

		[SerializeField]
		private SituationlBarkSO _noMoreSewerInTheBar;

		private bool _vigilanceIsUp50;

		private bool _vigilanceIsUp75;

		private void Awake()
		{
			AgentActionEnterBar.AgentEnteredBar += AgentActionEnterBar_AgentEnteredBar;
			Prestige.PrestigeLevelUp += Prestige_PrestigeGained;
			FinancialMoneyStats.NegatifMonth += FinancialMoneyStats_NegatifMonth;
			MachineBase.VictimDead += MachineBase_VictimDead;
			LevelParameters.OnBarOpenedStatusChanged += LevelParameters_OnBarOpenedStatusChanged;
			VigilanceHandlers.VigilanceChanged += VigilanceHandlers_VigilancePercentageChanged;
			Stocks.BarStock.StockChanged += BarStock_StockChanged;
			PanicCounter.PanicActive += PanicCounter_PanicActive;
			SewerHole.SoldSewerHole += SewerHole_SoldSewerHole;
			Customer.SpawnCustomer += Customer_SpawnCustomer;
		}

		private void OnDestroy()
		{
			AgentActionEnterBar.AgentEnteredBar -= AgentActionEnterBar_AgentEnteredBar;
			Prestige.PrestigeLevelUp -= Prestige_PrestigeGained;
			FinancialMoneyStats.NegatifMonth -= FinancialMoneyStats_NegatifMonth;
			MachineBase.VictimDead -= MachineBase_VictimDead;
			LevelParameters.OnBarOpenedStatusChanged -= LevelParameters_OnBarOpenedStatusChanged;
			VigilanceHandlers.VigilanceChanged -= VigilanceHandlers_VigilancePercentageChanged;
			Stocks.BarStock.StockChanged -= BarStock_StockChanged;
			PanicCounter.PanicActive -= PanicCounter_PanicActive;
			SewerHole.SoldSewerHole -= SewerHole_SoldSewerHole;
			Customer.SpawnCustomer -= Customer_SpawnCustomer;
		}

		private void PanicCounter_PanicActive(bool obj)
		{
			CalLSO(_panicInTheBar);
		}

		private void BarStock_StockChanged(StockInventory<StockStack, StockItemSO>.StockChangedData data)
		{
			if (!(data.StockType != _stockToMonitor) && data.StockCapacity.MaxCapacity.HasValue && data.StockCapacity.CurrentCapacity == data.StockCapacity.MaxCapacity.Value)
			{
				CalLSO(_fridgeFull);
			}
		}

		private void Customer_SpawnCustomer(Customer obj)
		{
			if (obj.IsVampire)
			{
				CalLSO(_vampireEnter);
			}
		}

		private void AgentActionEnterBar_AgentEnteredBar(Agent obj)
		{
			if (obj is Customer && ((Customer)obj).IsHunter)
			{
				CalLSO(_hunterEnterBar);
			}
		}

		private void Prestige_PrestigeGained()
		{
			CalLSO(_winAPrestigeLevel);
		}

		private void FinancialMoneyStats_NegatifMonth()
		{
			CalLSO(_monthnegatif);
		}

		public void BodyBag()
		{
			CalLSO(_hadBodyBag);
		}

		private void MachineBase_VictimDead()
		{
			CalLSO(_machinekillsomeone);
		}

		private void VigilanceHandlers_VigilancePercentageChanged(int obj)
		{
			if (obj > 75)
			{
				Vigilance70();
				return;
			}
			_vigilanceIsUp75 = false;
			if (obj > 50)
			{
				Vigilance50();
			}
			else
			{
				_vigilanceIsUp50 = false;
			}
		}

		private void Vigilance70()
		{
			if (!_vigilanceIsUp75)
			{
				CalLSO(_vigilance75);
				_vigilanceIsUp75 = true;
			}
		}

		private void Vigilance50()
		{
			if (!_vigilanceIsUp50)
			{
				CalLSO(_vigilance50);
				_vigilanceIsUp50 = true;
			}
		}

		private void LevelParameters_OnBarOpenedStatusChanged(bool obj)
		{
			if (obj)
			{
				CalLSO(_openBar);
			}
			else
			{
				CalLSO(_closeBar);
			}
		}

		private void SewerHole_SoldSewerHole()
		{
			CalLSO(_noMoreSewerInTheBar);
		}

		protected override void CalLSO(SituationlBarkSO situationlBarkSO)
		{
			if (!TryGetComponent<Worker>(out var component) || !(component != null) || component.IsEngaged)
			{
				base.CalLSO(situationlBarkSO);
			}
		}
	}
}
