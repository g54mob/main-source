using System.Collections.Generic;
using QFSW.QC;
using UnityEngine;
using UnityEngine.Scripting;

[Preserve]
public class CollectionNameSuggestor : BasicCachedQcSuggestor<string>
{
	private List<string> _collectionNames;

	private bool LazyInit()
	{
		if (_collectionNames != null)
		{
			return true;
		}
		CollectionsCommands collectionsCommands = Object.FindFirstObjectByType<CollectionsCommands>();
		if (collectionsCommands == null)
		{
			return false;
		}
		_collectionNames = new List<string>();
		foreach (CollectionsCommands.Collection collection in collectionsCommands.Collections)
		{
			_collectionNames.Add(collection.name);
		}
		foreach (CollectionsCommands.Collection categoryCollection in collectionsCommands.categoryCollections)
		{
			_collectionNames.Add(categoryCollection.name);
		}
		return true;
	}

	protected override bool CanProvideSuggestions(SuggestionContext context, SuggestorOptions options)
	{
		if (LazyInit())
		{
			return context.HasTag<CollectionNameTag>();
		}
		return false;
	}

	protected override IQcSuggestion ItemToSuggestion(string item)
	{
		return new RawSuggestion(item, singleLiteral: true);
	}

	protected override IEnumerable<string> GetItems(SuggestionContext context, SuggestorOptions options)
	{
		return _collectionNames;
	}
}
