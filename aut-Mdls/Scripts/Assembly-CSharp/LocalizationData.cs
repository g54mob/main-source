using System.Collections.Generic;
using AYellowpaper.SerializedCollections;
using UnityEngine;

public class LocalizationData : ScriptableObject
{
	public LanguageCode Language;

	public SerializedDictionary<string, string> Items;

	public List<FontFallbackEntry> FontFallbacks;
}
