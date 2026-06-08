public class allin_howto : WebsiteDownload
{
	public static string CARD_TABLE = "card_drawings";

	public static string BETS_TABLE = "bigball_bets";

	public void GenerateCardDrawingsTable()
	{
		if (LevelManager.GetCurrLevel() != 8)
		{
			FailPopup(Messages.GenericDownloadFailed());
			return;
		}
		string cARD_TABLE = CARD_TABLE;
		if (DatabaseUtils.ContainsTable(cARD_TABLE))
		{
			FailPopup(Messages.AlreadyDownloaded(cARD_TABLE));
			return;
		}
		Level8.CreateCardDrawingsTable(cARD_TABLE);
		iconGenerator.GenerateDeleteonlyIcon(cARD_TABLE);
		SuccessPopupMessage(notificationPrefab, Messages.SuccessfullyDownloaded(cARD_TABLE));
	}

	public void GeneratePredictionRateTable()
	{
		if (LevelManager.GetCurrLevel() != 8)
		{
			FailPopup(Messages.GenericDownloadFailed());
			return;
		}
		string bETS_TABLE = BETS_TABLE;
		if (DatabaseUtils.ContainsTable(bETS_TABLE))
		{
			FailPopup(Messages.AlreadyDownloaded(bETS_TABLE));
			return;
		}
		Level8.CreatePredictionsTable(bETS_TABLE);
		iconGenerator.GenerateDeleteonlyIcon(bETS_TABLE);
		SuccessPopupMessage(notificationPrefab, Messages.SuccessfullyDownloaded(bETS_TABLE));
	}
}
