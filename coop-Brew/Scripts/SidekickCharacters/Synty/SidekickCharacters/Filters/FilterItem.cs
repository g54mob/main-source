using System.Collections.Generic;
using Synty.SidekickCharacters.API;
using Synty.SidekickCharacters.Database.DTO;
using Synty.SidekickCharacters.Enums;

namespace Synty.SidekickCharacters.Filters
{
	public class FilterItem
	{
		public SidekickRuntime Runtime;

		public SidekickPartFilter Filter;

		public FilterCombineType CombineType;

		private Dictionary<CharacterPartType, List<string>> _filteredParts;

		public FilterItem(SidekickRuntime runtime, SidekickPartFilter filter, FilterCombineType combineType)
		{
		}

		public void ResetPartsForSpeciesChange()
		{
		}

		public Dictionary<CharacterPartType, List<string>> GetFilteredParts()
		{
			return null;
		}
	}
}
