using System.Collections;

public interface ILeaderboardHelper
{
	IEnumerator FindOrCreateLeaderboard(string pchLeaderboardName);

	IEnumerator FindLeaderboard(string pchLeaderboardName);

	CreateOrFindResult GetCreateOrFindResult();

	IEnumerator DownloadLeaderboardEntryForLocalUser(SuperBugLeaderboard leaderboard);

	DownloadEntryResult GetDownloadEntryResult();

	IEnumerator UploadEntry(SuperBugLeaderboard leaderboard);

	UploadEntryResult GetUploadResult();

	IEnumerator GetEntryCount(SuperBugLeaderboard leaderboard);

	EntryCountResult GetEntryCountResult();
}
