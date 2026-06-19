using System.Collections.Generic;
using QFSW.QC;
using UnityEngine;
using UnityEngine.Scripting;

[Preserve]
public class LoadoutNameSuggestor : BasicCachedQcSuggestor<string>
{
	private List<string> _loadoutNames;

	private bool LazyInit()
	{
		if (_loadoutNames != null)
		{
			return true;
		}
		LoadoutCommands loadoutCommands = Object.FindFirstObjectByType<LoadoutCommands>();
		if (loadoutCommands == null)
		{
			return false;
		}
		_loadoutNames = new List<string>();
		foreach (LoadoutCommands.Loadout loadout in loadoutCommands.loadouts)
		{
			_loadoutNames.Add(loadout.name);
		}
		return true;
	}

	protected override bool CanProvideSuggestions(SuggestionContext context, SuggestorOptions options)
	{
		if (LazyInit())
		{
			return context.HasTag<LoadoutNameTag>();
		}
		return false;
	}

	protected override IQcSuggestion ItemToSuggestion(string item)
	{
		return new RawSuggestion(item, singleLiteral: true);
	}

	protected override IEnumerable<string> GetItems(SuggestionContext context, SuggestorOptions options)
	{
		return _loadoutNames;
	}
}
