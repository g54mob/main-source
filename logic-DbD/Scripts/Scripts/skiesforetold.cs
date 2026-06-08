public class skiesforetold : WebsiteDownload
{
	public static string TABLE_NAME = "past_forecasts";

	public void GenerateWeatherTable()
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
		Level8.CreateWeatherTable(tABLE_NAME);
		iconGenerator.GenerateDeleteonlyIcon(tABLE_NAME);
		SuccessPopupMessage(notificationPrefab, Messages.SuccessfullyDownloaded(tABLE_NAME));
	}
}
