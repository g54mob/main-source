public class bigball_stats : WebsiteDownload
{
	public static string TABLE_NAME = "games_history";

	public void GeneratePastSchedulesTable()
	{
		if (LevelManager.GetCurrLevel() != 8)
		{
			FailPopup(Messages.GenericDownloadFailed());
			return;
		}
		string tABLE_NAME = TABLE_NAME;
		if (DatabaseUtils.ContainsTable(tABLE_NAME))
		{
			FailPopup(Messages.AlreadyDownloaded(tABLE_NAME));
			return;
		}
		Level8.CreateGamesTable(tABLE_NAME);
		iconGenerator.GenerateDeleteonlyIcon(tABLE_NAME);
		SuccessPopupMessage(notificationPrefab, Messages.SuccessfullyDownloaded(tABLE_NAME));
	}
}
