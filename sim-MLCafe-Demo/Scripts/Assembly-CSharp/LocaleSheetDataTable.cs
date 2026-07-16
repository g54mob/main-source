using System;
using System.Collections.Generic;
using NorskaLib.Spreadsheets;

[Serializable]
public class LocaleSheetDataTable
{
	[SpreadsheetPage("StringTable_Items")]
	public List<LocaleTableData> itemData;

	[SpreadsheetPage("StringTable_ComputerElements")]
	public List<LocaleTableData> computerElementData;

	[SpreadsheetPage("StringTable_UserInterface")]
	public List<LocaleTableData> userInterfaceData;

	[SpreadsheetPage("StringTable_AnomalyTags")]
	public List<LocaleTableData> anomalyTagData;

	[SpreadsheetPage("StringTable_ProductBoard")]
	public List<LocaleTableData> productBoardData;

	[SpreadsheetPage("StringTable_Dialogs")]
	public List<LocaleTableData> dialogData;

	public Dictionary<LocalizationDataTable.Tables, List<LocaleTableData>> tables => new Dictionary<LocalizationDataTable.Tables, List<LocaleTableData>>
	{
		[LocalizationDataTable.Tables.Items] = itemData,
		[LocalizationDataTable.Tables.ComputerElements] = computerElementData,
		[LocalizationDataTable.Tables.UI] = userInterfaceData,
		[LocalizationDataTable.Tables.AnomalyTags] = anomalyTagData,
		[LocalizationDataTable.Tables.ProductBoard] = productBoardData,
		[LocalizationDataTable.Tables.Dialogs] = dialogData
	};

	public List<LocaleTableData> GetTable(LocalizationDataTable.Tables table)
	{
		return tables.GetValueOrDefault(table);
	}

	public List<LocaleTableData> GetAllTables()
	{
		List<LocaleTableData> list = new List<LocaleTableData>();
		list.AddRange(itemData);
		list.AddRange(computerElementData);
		list.AddRange(userInterfaceData);
		list.AddRange(anomalyTagData);
		list.AddRange(productBoardData);
		list.AddRange(dialogData);
		return list;
	}
}
