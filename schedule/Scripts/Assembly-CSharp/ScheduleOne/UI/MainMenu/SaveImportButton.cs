using UnityEngine;
using UnityEngine.UI;

namespace ScheduleOne.UI.MainMenu
{
	[RequireComponent(typeof(Button))]
	public class SaveImportButton : MonoBehaviour
	{
		public ImportScreen ImportScreen;

		public MainMenuScreen ParentScreen;

		public int SaveSlotIndex;

		public static string TempImportPath => null;

		private void Awake()
		{
		}

		private void Clicked()
		{
		}

		public static void UnzipSaveFile(string zipFilePath, string destinationFolderPath)
		{
		}

		public static string ShowOpenFileDialog()
		{
			return null;
		}
	}
}
