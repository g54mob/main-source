using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace CTS
{
	public static class GoogleSheetDataImporter
	{
		public static async void ImportAll(bool saveData = false)
		{
			await Import(Resources.LoadAll<DataImporter>(string.Empty), saveData);
			await Import(Addressables.LoadAssetsAsync<DataImporter>("GoogleSheet").WaitForCompletion(), saveData);
		}

		private static async Task Import(IList<DataImporter> toImport, bool saveData = false)
		{
			try
			{
				if (toImport == null || toImport.Count == 0)
				{
					return;
				}
				List<Task> list = new List<Task>();
				foreach (DataImporter item in toImport)
				{
					if (item.ImportOnStart)
					{
						list.Add(item.ImportDataFromGoogleSheet(saveData));
					}
				}
				await Task.WhenAll(list);
			}
			catch (Exception)
			{
				throw;
			}
		}
	}
}
