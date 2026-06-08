using UnityEngine;
using UnityEngine.UI;

public class selectyourstar : WebsiteDownload
{
	[SerializeField]
	private Button starsDownloads;

	public static string TABLE_NAME = "stars";

	private static bool downloaded = false;

	protected override void Start()
	{
		base.Start();
		if (downloaded)
		{
			UIUtils.SetButtonColorSelected(starsDownloads);
		}
	}

	public void GenerateStarsTable()
	{
		if (LevelManager.GetCurrLevel() != 5)
		{
			FailPopup(Messages.StarsDownloadFailed());
			return;
		}
		if (DatabaseUtils.ContainsTable(TABLE_NAME))
		{
			FailPopup(Messages.StarAlreadyDownloaded());
			return;
		}
		Level5.CreateStarsTable();
		iconGenerator.GenerateDeleteonlyIcon(TABLE_NAME);
		SuccessPopupMessage(notificationPrefab, Messages.StarDownloadSuccess());
		downloaded = true;
		UIUtils.SetButtonColorSelected(starsDownloads);
	}
}
