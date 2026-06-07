using System.Collections.Generic;
using CTS.Utilities;
using NorskaLib.GoogleSheetsDatabase;
using UnityEngine;

namespace CTS
{
	[CreateAssetMenu(fileName = "Furniture Data Importer", menuName = "BBT/Data/Furniture Data Importer")]
	public class FurnitureDataImporter : DataImporter, IRevert
	{
		[PageName("Furnitures")]
		[HideInInspector]
		public List<FurnitureImportData> FurnituresData;

		protected override void LoadData()
		{
		}
	}
}
