using System.Collections.Generic;

public class TooltipComponent_levelBossInfo : TooltipComponent
{
	private LevelData levelData;

	private LevelsProgressionManager.FLevelProgressionInfo levelInfo;

	public void Setup(LevelData levelData, LevelsProgressionManager.FLevelProgressionInfo levelInfo)
	{
		this.levelData = levelData;
		this.levelInfo = levelInfo;
		InvokeDataChanged();
	}

	protected override Dictionary<string, object> GetData()
	{
		return new Dictionary<string, object>
		{
			{ "levelData", levelData },
			{ "levelInfo", levelInfo }
		};
	}
}
