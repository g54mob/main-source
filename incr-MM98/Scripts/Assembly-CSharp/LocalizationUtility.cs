using Cysharp.Text;
using UnityEngine.Localization;
using UnityEngine.Localization.Settings;
using UnityEngine.Localization.Tables;
using ZLinq;

public static class LocalizationUtility
{
	public static LocalizedString Find(LocTable table, string key)
	{
		LocalizedDatabase<StringTable, StringTableEntry>.TableEntryResult tableEntry = LocalizationSettings.StringDatabase.GetTableEntry(table.Value(), key, LocalizationSettings.SelectedLocale ?? LocalizationSettings.ProjectLocale);
		if (tableEntry.Entry != null)
		{
			return new LocalizedString(tableEntry.Table.SharedData.TableCollectionNameGuid, tableEntry.Entry.KeyId);
		}
		return new LocalizedString();
	}

	public static LocalizedString Random(LocTable key)
	{
		StringTable table = LocalizationSettings.StringDatabase.GetTable(key.Value(), LocalizationSettings.SelectedLocale ?? LocalizationSettings.ProjectLocale);
		return new LocalizedString(table.SharedData.TableCollectionNameGuid, table.SharedData.Entries.AsValueEnumerable().Random().Id);
	}

	public static LocalizedString For(DatacenterState x)
	{
		return Find(LocTable.General, ZString.Format("world_status_{0}", x.ToString().ToLower()));
	}

	public static LocalizedString For(ResearchNodeDirectory x)
	{
		return Find(LocTable.General, ZString.Format("research_{0}", x.ToString().ToLower()));
	}

	public static LocalizedString For(BackgroundSkin x)
	{
		return Find(LocTable.General, ZString.Format("backgrounds_{0}", x.ToString().ToLower()));
	}

	public static LocalizedString For(CursorSkin x)
	{
		return Find(LocTable.Customizations, ZString.Format("cursors_{0}", x.ToString().ToLower()));
	}

	public static LocalizedString For(GnormanSkin x)
	{
		return Find(LocTable.Customizations, ZString.Format("gnormans_{0}", x.ToString().ToLower()));
	}

	public static LocalizedString For(Modifier x)
	{
		return Find(LocTable.Modifiers, ZString.Format("modifier_{0}", x.type.ToString().ToLower()));
	}
}
