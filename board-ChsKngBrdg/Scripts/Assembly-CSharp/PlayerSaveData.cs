using System.Collections.Generic;

public class PlayerSaveData
{
	public OverworldTrollManager.OverworldState overworldState;

	public OverworldTrollManager.Ending ending;

	public int totalCheatCount;

	public int totalAttemptCount;

	public int totalScrapCount;

	public float totalGameTime;

	public bool firstGameinScene;

	public List<PageFogEntry> pageFogEntries = new List<PageFogEntry>();

	public PlayerSaveData(OverworldTrollManager.OverworldState overworldState, OverworldTrollManager.Ending ending, int totalCheatCount, int totalAttemptCount, int totalScrapCount, float totalGameTime, bool firstGameinScene, List<PageFogEntry> pageFogEntries)
	{
		this.overworldState = overworldState;
		this.ending = ending;
		this.totalCheatCount = totalCheatCount;
		this.totalAttemptCount = totalAttemptCount;
		this.totalScrapCount = totalScrapCount;
		this.totalGameTime = totalGameTime;
		this.firstGameinScene = firstGameinScene;
		this.pageFogEntries = pageFogEntries;
	}
}
