using UnityEngine;
using UnityEngine.UI;

public class teachersonly_data : WebsiteDownload
{
	[SerializeField]
	private Button studentNames;

	public static string TABLE_NAME = "students";

	public void GenerateStudentsTable()
	{
		if (GenerateTable(TABLE_NAME))
		{
			UniversityLevel.CreateStudentsTable();
			iconGenerator.GenerateDeleteonlyIcon(TABLE_NAME);
		}
	}

	private bool GenerateTable(string TABLE_NAME)
	{
		if (LevelManager.GetCurrLevel() != 7)
		{
			FailPopup(Messages.LZUDownloadFailed());
			return false;
		}
		if (DatabaseUtils.ContainsTable(TABLE_NAME))
		{
			FailPopup(Messages.AlreadyDownloaded(TABLE_NAME));
			return false;
		}
		SuccessPopup(notificationPrefab, TABLE_NAME);
		return true;
	}
}
