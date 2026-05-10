namespace CTS
{
	public abstract class Profile
	{
		public abstract string GetName();

		public abstract void PlayProfile();

		public void BackupAndClear()
		{
			BackupAndClearProfile(GetName());
		}

		public static void BackupAndClearProfile(string profileName)
		{
			ES3Settings globalFolderSettings = SaveSettings.GetGlobalFolderSettings();
			string text = (globalFolderSettings.path = "Saves/" + profileName + "/");
			if (!ES3.DirectoryExists(globalFolderSettings))
			{
				return;
			}
			string[] files = ES3.GetFiles(globalFolderSettings);
			foreach (string text2 in files)
			{
				if (text2.EndsWith(".sav") || text2.EndsWith(".png"))
				{
					globalFolderSettings.path = text + text2;
					ES3.CreateBackup(globalFolderSettings);
					ES3.DeleteFile(globalFolderSettings);
				}
			}
		}

		public abstract bool DoesLevelHaveSave(MapInfoSO mapInfo);
	}
}
