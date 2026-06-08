using UnityEngine;
using UnityEngine.UI;

public class guild_votes : WebsiteDownload
{
	[SerializeField]
	private Button button;

	public void DownloadVotes()
	{
		if (LevelManager.GetCurrLevel() != 6)
		{
			FailPopup(Messages.GuildMembersServerDown());
			return;
		}
		string tableName = "election_results";
		if (DatabaseUtils.ContainsTable(tableName))
		{
			FailPopup(Messages.AlreadyDownloaded(tableName));
			return;
		}
		SuccessPopupMessage(notificationPrefab, Messages.SuccessfullyDownloaded(tableName));
		WikiLevel.CreateVotesTable(tableName);
		iconGenerator.GenerateDeleteonlyIcon(tableName);
	}
}
