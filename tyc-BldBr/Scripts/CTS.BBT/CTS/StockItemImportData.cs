using System.Collections.Generic;
using CTS.Utilities;
using NorskaLib.GoogleSheetsDatabase;
using UnityEngine;

namespace CTS
{
	[CreateAssetMenu(fileName = "StockItem Data Importer", menuName = "BBT/Data/StockItem Data Importer")]
	public class StockItemImportData : DataImporter, IRevert
	{
		[PageName("StockItems")]
		[HideInInspector]
		public List<StockItemSOImportData> StockItemData;

		protected override void LoadData()
		{
		}
	}
}
