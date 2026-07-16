using System.Collections.Generic;
using NorskaLib.Spreadsheets;
using UnityEngine;

[CreateAssetMenu(fileName = "GameModeSpreadsheetDataTable", menuName = "GameModeSpreadsheetDataTable")]
public class GameModeDataTable : SpreadsheetsContainerBase
{
	[SpreadsheetContent]
	[SerializeField]
	private GameModeSheetDataTable content;

	public GameModeSheetDataTable Content => content;

	public List<GameModeTableData> GlobalTable()
	{
		return content.modeData;
	}

	public T GetGameModeKeyValue<T>(string key, int mode)
	{
		return content.modeData.Find((GameModeTableData x) => x.HasKey(key)).GetValue<T>(mode);
	}
}
