using UnityEngine;
using UnityEngine.UI;

namespace ScheduleOne.UI.MainMenu
{
	[RequireComponent(typeof(Button))]
	public class SaveExportButton : MonoBehaviour
	{
		public int SaveSlotIndex;

		private void Awake()
		{
		}

		private void Clicked()
		{
		}

		public static string ShowSaveFileDialog(string fileName)
		{
			return null;
		}

		public static void ZipSaveFolder(string sourceFolderPath, string destinationZipPath)
		{
		}
	}
}
