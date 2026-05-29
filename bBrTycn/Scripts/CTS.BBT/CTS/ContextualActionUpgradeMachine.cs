using System;
using CTS.BBT;
using CTS.BBT.TechTree;
using CTS.Core;

namespace CTS
{
	[Serializable]
	[Obsolete("This functionality was discontinued after the integration of the new machine management interface - Dorian 13/08/24")]
	internal sealed class ContextualActionUpgradeMachine : MenuContextualAction<MachineBase>
	{
		private MachineUpgrade _machineUpgrade;

		private MachineTechTree _machineTechTree;

		private EMachineUpgrade _nextUpgrade;

		private int _upgradeCost;

		public override void Setup()
		{
			_machineUpgrade = contextActor.MachineUpgrade;
			_machineTechTree = contextActor.MachineTechTree;
		}

		public override string GetDisplayName()
		{
			return $"{base.CurrentDisplayText.GetLocalizedString()} ${_upgradeCost}";
		}

		public override bool ShowAlways()
		{
			if ((object)_machineUpgrade == null)
			{
				return false;
			}
			if (_machineUpgrade.upgradeIsDisabled)
			{
				return false;
			}
			return true;
		}

		protected override bool CanBePerformed()
		{
			_nextUpgrade = _machineUpgrade.currentLevel + 1;
			_upgradeCost = _machineUpgrade.machinePriceToUpgrade[_nextUpgrade];
			if (MonoSingleton<MoneyHandler>.Instance.CurrentMoney < _upgradeCost)
			{
				return false;
			}
			return (int)(TechTreeManager.GetTechnologyResearchLevel(_machineTechTree.TechTreeTechnologyRequiered) - 1) > (int)_machineUpgrade.currentLevel;
		}

		protected override void Execution()
		{
			_machineUpgrade.Upgrade();
		}
	}
}
