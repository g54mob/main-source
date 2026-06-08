public class SessionQuest_TilesPlaced : SessionQuest
{
	public override string GetDescription(int level = -1)
	{
		string description = base.GetDescription(level);
		return LocalizationManager.Instance.ApplySpecificLanguageNumberingGrammar(description, TargetCount(level));
	}

	public override void StartWatching(SessionQuestWatcher sessionQuestWatcher)
	{
		base.StartWatching(sessionQuestWatcher);
		if (!base.Completed)
		{
			tilePlacementEventBroadcaster.OnTilePlaced_QuestsProcessed += AddProgress;
		}
	}

	private void AddProgress(Tile newTile, bool isPlacedByPlayer)
	{
		if (isPlacedByPlayer)
		{
			currentProgress++;
			ProgressChanged(save: true);
			ExecuteFulfillment();
		}
	}

	public override void StopWatching()
	{
		base.StopWatching();
		tilePlacementEventBroadcaster.OnTilePlaced_QuestsProcessed -= AddProgress;
	}
}
