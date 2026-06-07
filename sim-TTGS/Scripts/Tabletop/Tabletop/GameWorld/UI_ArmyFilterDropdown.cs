using System;
using Simulator;

namespace Tabletop.GameWorld
{
	public class UI_ArmyFilterDropdown : UI_FilterDropdown
	{
		protected override int GetFiltersCount()
		{
			return Enum.GetValues(typeof(EMiniatureArmy)).Length - 1;
		}

		protected override void OnInstantiateFilterToggle(int index, NavToggle filterToggle)
		{
			filterToggle.GetComponentInChildren<SimulatorText>().SetTerm(MiniatureSettings.GetArmyTerm((EMiniatureArmy)index));
		}

		public bool IsArmyActive(EMiniatureArmy army)
		{
			return IsFilterActive((int)army);
		}
	}
}
