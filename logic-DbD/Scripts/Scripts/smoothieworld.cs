public class smoothieworld : WebsiteDownload
{
	public void GenerateNutritionTable()
	{
		if (LevelManager.GetCurrLevel() != 5)
		{
			FailPopup(Messages.NutritionDownloadFailed());
			return;
		}
		string tableName = "nutrition_facts";
		if (DatabaseUtils.ContainsTable(tableName))
		{
			FailPopup(Messages.AlreadyDownloaded(tableName));
			return;
		}
		Level5.CreateNutritionFactsTable();
		SuccessPopupMessage(notificationPrefab, Messages.SuccessfullyDownloaded(tableName));
		iconGenerator.GenerateDeleteonlyIcon(tableName);
	}
}
