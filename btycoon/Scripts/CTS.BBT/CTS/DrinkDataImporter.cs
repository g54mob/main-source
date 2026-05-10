using System.Collections.Generic;
using CTS.Utilities;
using NorskaLib.GoogleSheetsDatabase;
using UnityEngine;

namespace CTS
{
	[CreateAssetMenu(fileName = "Drink Data Importer", menuName = "BBT/Data/Drink Data Importer")]
	public class DrinkDataImporter : DataImporter, IRevert
	{
		[PageName("Drink")]
		[HideInInspector]
		public List<DrinkImportData> DrinkData;

		protected override void LoadData()
		{
		}
	}
}
