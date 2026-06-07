using System;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.Localization.Settings;

public abstract class ScriptableData<T> : ScriptableData where T : struct, Enum
{
	public T ID => (T)Enum.ToObject(typeof(T), guid);

	public LocalizedString TitleLocalized => Find(LocalizationTable, base.TitleKey);

	public LocalizedString DescriptionLocalized => Find(LocalizationTable, base.DescriptionKey);

	public override void GenerateId()
	{
		guid = new System.Random().Next(0, int.MaxValue);
	}

	protected override void GenerateEnum()
	{
	}

	private static LocalizedString Find(LocTable table, string key)
	{
		LocalizedDatabase<UnityEngine.Localization.Tables.StringTable, UnityEngine.Localization.Tables.StringTableEntry>.TableEntryResult tableEntry = LocalizationSettings.StringDatabase.GetTableEntry(table.Value(), key, LocalizationSettings.SelectedLocale ?? LocalizationSettings.ProjectLocale);
		if (tableEntry.Entry != null)
		{
			return new LocalizedString(tableEntry.Table.SharedData.TableCollectionNameGuid, tableEntry.Entry.KeyId);
		}
		return new LocalizedString();
	}
}
public abstract class ScriptableData : ScriptableObject
{
	public string key;

	public int guid;

	public string TitleKey
	{
		get
		{
			if (!string.IsNullOrEmpty(LocalizationPrefix))
			{
				return LocalizationPrefix + "_" + key?.ToLower();
			}
			return key?.ToLower();
		}
	}

	public string DescriptionKey => TitleKey + "_description";

	protected abstract string LocalizationPrefix { get; }

	protected abstract LocTable LocalizationTable { get; }

	[Conditional("UNITY_EDITOR")]
	public abstract void GenerateId();

	[Conditional("UNITY_EDITOR")]
	protected abstract void GenerateEnum();
}
