using System.Collections.Generic;
using Synty.SidekickCharacters.API;
using Synty.SidekickCharacters.Enums;

namespace Synty.SidekickCharacters.Filters
{
	public class FilterGroup
	{
		public SidekickRuntime Runtime;

		public FilterCombineType CombineType;

		private Dictionary<CharacterPartType, List<string>> _filteredParts;

		private List<FilterItem> _filterItems;

		private List<FilterGroup> _subGroups;

		public void AddFilterSubGroup(FilterGroup subGroup)
		{
		}

		public void AddFilterItem(FilterItem filterItem)
		{
		}

		public void RemoveFilterItem(FilterItem filterItem)
		{
		}

		public void ResetFiltersForSpeciesChange()
		{
		}

		public Dictionary<CharacterPartType, List<string>> GetFilteredParts()
		{
			return null;
		}
	}
}
