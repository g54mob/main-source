using System.Collections.Generic;
using NorskaLib.Spreadsheets;
using UnityEngine;

[CreateAssetMenu(fileName = "LocaleSpreadsheetDataTable", menuName = "LocaleSpreadsheetDataTable")]
public class LocalizationDataTable : SpreadsheetsContainerBase
{
	public enum Tables
	{
		SearchAll = -1,
		Items = 0,
		ComputerElements = 1,
		UI = 2,
		AnomalyTags = 3,
		ProductBoard = 4,
		Dialogs = 5
	}

	[SpreadsheetContent]
	[SerializeField]
	private LocaleSheetDataTable content;

	public LocaleSheetDataTable Content => content;

	public List<LocaleTableData> GlobalTable()
	{
		return content.GetAllTables();
	}

	public Dictionary<Tables, List<LocaleTableData>> GetAllTables()
	{
		return content.tables;
	}

	public string GetLocalizedString(string key, int language, Tables table = Tables.SearchAll)
	{
		if (table != Tables.SearchAll)
		{
			return content.GetTable(table).Find((LocaleTableData x) => x.HasKey(key)).GetLocaleString(language);
		}
		for (int num = 0; num < GlobalTable().Count; num++)
		{
			if (GlobalTable()[num].HasKey(key))
			{
				return GlobalTable()[num].GetLocaleString(language);
			}
		}
		return "No localization with key: '" + key + "' was found!";
	}

	public string GetLocalizedString(string key, int language, List<LocaleTableData> tableData)
	{
		LocaleTableData localeTableData = tableData.Find((LocaleTableData x) => x.HasKey(key));
		if (localeTableData != null)
		{
			return localeTableData.GetLocaleString(language);
		}
		return "No localization with key: '" + key + "' was found!";
	}
}
