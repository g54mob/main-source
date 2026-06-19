using System.Collections.Generic;
using QFSW.QC;
using UnityEngine;
using UnityEngine.Scripting;

[Preserve]
public class CustomSceneNameSuggestor : BasicCachedQcSuggestor<string>
{
	private const string CUSTOM_SCENES_TABLE_PATH = "Scenes/CustomScenesDataTable";

	private List<string> _customSceneNames = new List<string>();

	public CustomSceneNameSuggestor()
	{
		foreach (CustomScenesDataTable.Scene scene in Resources.Load<CustomScenesDataTable>("Scenes/CustomScenesDataTable").scenes)
		{
			_customSceneNames.Add(scene.sceneName);
		}
	}

	protected override bool CanProvideSuggestions(SuggestionContext context, SuggestorOptions options)
	{
		return context.HasTag<CustomSceneNameTag>();
	}

	protected override IQcSuggestion ItemToSuggestion(string item)
	{
		return new RawSuggestion(item, singleLiteral: true);
	}

	protected override IEnumerable<string> GetItems(SuggestionContext context, SuggestorOptions options)
	{
		return _customSceneNames;
	}
}
