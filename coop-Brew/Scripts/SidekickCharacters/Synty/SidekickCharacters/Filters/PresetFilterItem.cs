using System.Collections.Generic;
using Synty.SidekickCharacters.Database;
using Synty.SidekickCharacters.Database.DTO;
using Synty.SidekickCharacters.Enums;

namespace Synty.SidekickCharacters.Filters
{
	public class PresetFilterItem
	{
		public DatabaseManager DbManager;

		public SidekickPresetFilter Filter;

		public FilterCombineType CombineType;

		private List<SidekickPartPreset> _filteredPresets;

		public PresetFilterItem(DatabaseManager dbManager, SidekickPresetFilter filter, FilterCombineType combineType)
		{
		}

		public List<SidekickPartPreset> GetFilteredPresets()
		{
			return null;
		}
	}
}
