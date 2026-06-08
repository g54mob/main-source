public class rent4ever : WebsiteDownload
{
	public static string TABLE_NAME = "rentals";

	public void GenerateRentalsTable()
	{
		if (LevelManager.GetCurrLevel() != 6)
		{
			FailPopup(Messages.RentDownloadFailed());
			return;
		}
		string tableName = "rentals";
		if (DatabaseUtils.ContainsTable(tableName))
		{
			FailPopup(Messages.RentAlreadyDownloaded());
			return;
		}
		WikiLevel.CreateRentalsTable(tableName);
		iconGenerator.GenerateDeleteonlyIcon(tableName);
		SuccessPopupMessage(notificationPrefab, Messages.RentSuccess());
	}
}
