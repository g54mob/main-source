using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TooltipUI_levelBossInfo : TooltipUI
{
	[SerializeField]
	private TextMeshProUGUI bossNameText;

	[SerializeField]
	private TextMeshProUGUI bossDescriptionText;

	[SerializeField]
	private TextMeshProUGUI rewardDescriptionText;

	public override void Setup(Dictionary<string, object> data)
	{
		LevelData levelData = data["levelData"] as LevelData;
		LevelsProgressionManager.FLevelProgressionInfo obj = data["levelInfo"] as LevelsProgressionManager.FLevelProgressionInfo;
		if (obj.BossRevealed)
		{
			bossNameText.text = levelData.BossName;
			bossDescriptionText.text = levelData.BossDescription;
		}
		else
		{
			bossNameText.text = "?";
			bossDescriptionText.text = levelData.BossHiddenDescription;
		}
		if (obj.BossDefeated)
		{
			rewardDescriptionText.text = levelData.RewardDescription;
		}
		else
		{
			rewardDescriptionText.text = levelData.RewardHiddenDescription;
		}
		GetComponent<AutoTransformRebuild>().RebuildTransform();
	}
}
