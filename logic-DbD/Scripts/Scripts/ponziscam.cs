public class ponziscam : WebsiteDownload
{
	public void GenerateFamilyTree()
	{
		if (LevelManager.GetCurrLevel() < 8)
		{
			FailPopup(Messages.GenericDownloadFailed());
			return;
		}
		string tableName = "ponzi_scams";
		if (DatabaseUtils.ContainsTable(tableName))
		{
			FailPopup(Messages.AlreadyDownloaded(tableName));
			return;
		}
		HintManager.SetQueryState(2);
		Level8.CreateFamilyTreeTable(tableName);
		iconGenerator.GenerateDeleteonlyIcon(tableName);
		SuccessPopupMessage(notificationPrefab, Messages.SuccessfullyDownloaded(tableName));
	}
}
