public class CampaignLevelModel : BaseModel
{
	public const string LevelCompletedEvent = "CampaignLevelModel.LevelCompletedEvent";

	public const string PlayabilityChangedEvent = "CampaignLevelModel.PlayabilityChangedEvent";

	private LevelModel levelModel;

	private bool isLevelPlayable;

	public LevelModel LevelModel => levelModel;

	public string LevelIndex { get; private set; }

	public bool IsLevelPlayable
	{
		get
		{
			return isLevelPlayable;
		}
		set
		{
			isLevelPlayable = value;
			NotifyChange("CampaignLevelModel.PlayabilityChangedEvent");
		}
	}

	public CampaignLevelModel(LevelModel levelModel, string levelIndex)
	{
		this.levelModel = levelModel;
		LevelIndex = levelIndex;
		levelModel.NotifyChangeEvent += LevelModelChangeHandler;
		isLevelPlayable = false;
	}

	private void LevelModelChangeHandler(string eventName, object[] data)
	{
		if (eventName == "LevelModel.BestTimeChangedEvent")
		{
			NotifyChange("CampaignLevelModel.LevelCompletedEvent");
		}
	}
}
