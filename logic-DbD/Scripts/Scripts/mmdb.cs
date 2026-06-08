using UnityEngine;
using UnityEngine.UI;

public class mmdb : WebsiteDownload
{
	[SerializeField]
	private Button movieDownloads;

	public static string TABLE_NAME = "movies";

	public void MoviesButton()
	{
		if (LevelManager.GetCurrLevel() != 5)
		{
			FailPopup(Messages.MoviesDownloadFailed());
			return;
		}
		if (DatabaseUtils.ContainsTable(TABLE_NAME))
		{
			FailPopup(Messages.AlreadyDownloaded(TABLE_NAME));
			return;
		}
		Level5.CreateMovieTable();
		iconGenerator.GenerateDeleteonlyIcon(TABLE_NAME);
		SuccessPopup(notificationPrefab, TABLE_NAME);
	}
}
