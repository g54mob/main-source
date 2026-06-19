using System;
using System.Collections.Generic;
using I2.Loc;
using PugMod;
using QFSW.QC;
using UnityEngine;
using UnityEngine.Scripting;

[Preserve]
public class ObjectNameSuggestor : BasicCachedQcSuggestor<string>
{
	public static readonly Dictionary<string, ObjectID> _itemTranslationToObjectID = new Dictionary<string, ObjectID>(StringComparer.OrdinalIgnoreCase);

	public ObjectNameSuggestor()
	{
		if (_itemTranslationToObjectID.Count == 0)
		{
			GetLocalizedObjectID();
		}
	}

	public static void GetLocalizedObjectID()
	{
		_itemTranslationToObjectID.Clear();
		ObjectID[] array = (ObjectID[])Enum.GetValues(typeof(ObjectID));
		for (int i = 0; i < array.Length; i++)
		{
			ObjectID objectID = array[i];
			if (LocalizationManager.TryGetTranslation("Items/" + objectID, out var Translation, FixForRTL: true, 0, ignoreRTLnumbers: true, applyParameters: false, null, "English") && !_itemTranslationToObjectID.TryAdd(Translation, objectID))
			{
				Debug.LogWarning($"Duplicate object name \"{Translation}\" for ObjectID \"{objectID}\" and \"{_itemTranslationToObjectID[Translation]}\".");
			}
		}
		IEnumerable<LoadedMod> loadedMods = API.ModLoader.LoadedMods;
		if (API.Authoring == null)
		{
			return;
		}
		foreach (LoadedMod item in loadedMods)
		{
			foreach (UnityEngine.Object asset in item.Assets)
			{
				if (asset is GameObject gameObject && gameObject.TryGetComponent<ObjectAuthoring>(out var component))
				{
					AddTranslatedModObjectID(component.objectName);
				}
			}
		}
	}

	private static void AddTranslatedModObjectID(string modObjectName)
	{
		ObjectID objectID = API.Authoring.GetObjectID(modObjectName);
		if (objectID != ObjectID.None && LocalizationManager.TryGetTranslation("Items/" + modObjectName, out var Translation, FixForRTL: true, 0, ignoreRTLnumbers: true, applyParameters: false, null, "English"))
		{
			_itemTranslationToObjectID.TryAdd(Translation, objectID);
		}
	}

	protected override bool CanProvideSuggestions(SuggestionContext context, SuggestorOptions options)
	{
		return context.HasTag<ObjectNameSuggestorTag>();
	}

	protected override IQcSuggestion ItemToSuggestion(string item)
	{
		return new RawSuggestion(item, singleLiteral: true);
	}

	protected override IEnumerable<string> GetItems(SuggestionContext context, SuggestorOptions options)
	{
		return _itemTranslationToObjectID.Keys;
	}
}
