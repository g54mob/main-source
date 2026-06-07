using System;
using Simulator;

namespace Tabletop.GameWorld
{
	public class UI_CollectionFilterDropdown : UI_FilterDropdown
	{
		protected override int GetFiltersCount()
		{
			return Enum.GetValues(typeof(ECollectionFilterType)).Length;
		}

		protected override void OnInstantiateFilterToggle(int index, NavToggle filterToggle)
		{
			filterToggle.Toggle.isOn = CollectionSettings.GetDefaultFilterState((ECollectionFilterType)index);
			filterToggle.GetComponentInChildren<SimulatorText>().SetTerm(CollectionSettings.GetFilterTypeTerm((ECollectionFilterType)index));
		}
	}
}
