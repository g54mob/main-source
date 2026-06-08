public class clowncar : WebsiteDownload
{
	public static string TABLE_NAME = "drivers";

	public void GenerateRentalsTable()
	{
		if (LevelManager.GetCurrLevel() != 6)
		{
			FailPopup(Messages.ClownDownloadFailed());
			return;
		}
		if (DatabaseUtils.ContainsTable(TABLE_NAME))
		{
			FailPopup(Messages.AlreadyDownloaded(TABLE_NAME));
			return;
		}
		WikiLevel.CreateDriversTable(TABLE_NAME);
		iconGenerator.GenerateDeleteonlyIcon(TABLE_NAME);
		SuccessPopupMessage(notificationPrefab, Messages.SuccessfullyDownloaded(TABLE_NAME));
	}
}
