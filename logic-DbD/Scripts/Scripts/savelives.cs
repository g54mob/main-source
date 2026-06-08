using System;

public class savelives : WebsiteDownload
{
	public enum Tiers
	{
		Patriots = 150,
		Champions = 250,
		Heroes = 500
	}

	public static string[] TABLE_NAMES = new string[3] { "heroes", "champions", "patriots" };

	public void GenerateDonatorTable(string tableName)
	{
		if (LevelManager.GetCurrLevel() != 6)
		{
			FailPopup(Messages.DonatorDownloadFailed());
			return;
		}
		if (DatabaseUtils.ContainsTable(tableName))
		{
			FailPopup(Messages.AlreadyDownloaded(tableName));
			return;
		}
		WikiLevel.CreateDonorsTable(tableName, GetTier(tableName));
		iconGenerator.GenerateDeleteonlyIcon(tableName);
		SuccessPopupMessage(notificationPrefab, Messages.SuccessfullyDownloaded(tableName));
	}

	public static Tiers GetTier(string tableName)
	{
		return tableName switch
		{
			"patriots" => Tiers.Patriots, 
			"champions" => Tiers.Champions, 
			"heroes" => Tiers.Heroes, 
			_ => throw new ArgumentException(tableName + " is not a valid tier in savelives.Tiers"), 
		};
	}
}
