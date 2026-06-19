using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

[RuntimeInitializeOnScriptableDataLoad]
public class TextDataBlock : ScriptableDataBlock
{
	[Serializable]
	public class SerializableDictionary<TKey, TValue> : Dictionary<TKey, TValue>, ISerializationCallbackReceiver
	{
		[SerializeField]
		private List<TKey> keys = new List<TKey>();

		[SerializeField]
		private List<TValue> values = new List<TValue>();

		public void OnBeforeSerialize()
		{
			keys.Clear();
			values.Clear();
			using Enumerator enumerator = GetEnumerator();
			while (enumerator.MoveNext())
			{
				KeyValuePair<TKey, TValue> current = enumerator.Current;
				keys.Add(current.Key);
				values.Add(current.Value);
			}
		}

		public void OnAfterDeserialize()
		{
			Clear();
			if (keys.Count != values.Count)
			{
				throw new Exception($"there are {keys.Count} keys and {values.Count} values after deserialization. Make sure that both key and value types are serializable.");
			}
			for (int i = 0; i < keys.Count; i++)
			{
				Add(keys[i], values[i]);
			}
		}
	}

	[SerializeField]
	[FormerlySerializedAs("localizedTexts")]
	private SerializableDictionary<DataBlockAddress, LocalizedText> m_localizedTexts = new SerializableDictionary<DataBlockAddress, LocalizedText>();

	[SerializeField]
	[TextArea(0, 20)]
	private string m_localizationHint;

	[SerializeField]
	private LocalizedText m_prevImportPrimaryEntry;

	[SerializeField]
	private bool m_shouldBeLocalized = true;

	[SerializeField]
	[HideInInspector]
	private string m_header;

	private static Dictionary<LanguageDataBlock, Dictionary<string, TextDataBlock>> s_textLookups;

	public string header => m_header;

	public string title => GetLocalized().title;

	public string description => GetLocalized().description;

	public bool TryGetLocalized(DataBlockRef<LanguageDataBlock> language, out LocalizedText value)
	{
		return m_localizedTexts.TryGetValue(language.address, out value);
	}

	public LocalizedText GetLocalized(LanguageDataBlock language)
	{
		if (!TryGetLocalized(language, out var value))
		{
			Debug.LogError($"{this} has no entry for {language}");
			return new LocalizedText
			{
				title = "NOTLOCALIZED",
				description = "NOTLOCALIZED"
			};
		}
		return value;
	}

	public LocalizedText GetLocalized()
	{
		return GetLocalized(LanguageDataBlock.activeLanguage);
	}

	public static LocalizedText GetLocalized(string key)
	{
		LanguageDataBlock activeLanguage = LanguageDataBlock.activeLanguage;
		if (activeLanguage == null || !s_textLookups.TryGetValue(activeLanguage, out var value))
		{
			return new LocalizedText
			{
				title = "NOLANGUAGE",
				description = "NOLANGUAGE"
			};
		}
		if (!value.TryGetValue(key, out var value2))
		{
			return new LocalizedText
			{
				title = "INVALIDKEY",
				description = "INVALIDKEY"
			};
		}
		return value2.GetLocalized(activeLanguage);
	}

	[RuntimeInitializeOnScriptableDataLoad]
	public static void InitializeLookups()
	{
		s_textLookups = new Dictionary<LanguageDataBlock, Dictionary<string, TextDataBlock>>();
		if (!ScriptableData.TryGetDataBlocks(out IReadOnlyList<LanguageDataBlock> dataBlocks))
		{
			Debug.Log("No LanguageDataBlocks");
			return;
		}
		if (!ScriptableData.TryGetDataBlocks(out IReadOnlyList<TextDataBlock> dataBlocks2))
		{
			Debug.Log("No TextDataBlock");
			return;
		}
		foreach (LanguageDataBlock item in dataBlocks)
		{
			Dictionary<string, TextDataBlock> dictionary = new Dictionary<string, TextDataBlock>();
			foreach (TextDataBlock item2 in dataBlocks2)
			{
				if (string.IsNullOrEmpty(item2.header))
				{
					dictionary.Add(item2.name, item2);
				}
				else
				{
					dictionary.Add(item2.header + "/" + item2.name, item2);
				}
			}
			s_textLookups.Add(item, dictionary);
		}
	}

	public bool ValidateForLanguage(LanguageDataBlock language)
	{
		if (!m_localizedTexts.ContainsKey(language.address))
		{
			LocalizedText value = new LocalizedText(language.address);
			m_localizedTexts.Add(language.address, value);
			return false;
		}
		return true;
	}
}
