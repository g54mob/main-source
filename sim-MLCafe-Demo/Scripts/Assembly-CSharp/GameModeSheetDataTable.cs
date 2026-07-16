using System;
using System.Collections.Generic;
using NorskaLib.Spreadsheets;

[Serializable]
public class GameModeSheetDataTable
{
	[SpreadsheetPage("StringTable_GameModes")]
	public List<GameModeTableData> modeData;
}
