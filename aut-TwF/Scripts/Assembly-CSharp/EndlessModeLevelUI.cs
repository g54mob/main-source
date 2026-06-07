using System;
using TMPro;
using UnityEngine;
using UnityEngine.Localization.Settings;
using UnityEngine.UI;

public class EndlessModeLevelUI : MonoBehaviour
{
	[SerializeField]
	private TextMeshProUGUI levelNameText;

	[SerializeField]
	private Image levelThumbnail;

	[SerializeField]
	private TextMeshProUGUI scoreText;

	[SerializeField]
	private TooltipComponent_text scoreTooltip;

	private LevelData levelData;

	public event Action<LevelData> onButtonPressed;

	public void SetLevel(LevelsProgressionManager.FLevelProgressionInfo levelInfo)
	{
		levelData = levelInfo.LevelData;
		levelNameText.text = levelData.DisplayName.GetLocalizedString();
		levelThumbnail.sprite = levelData.Thumbnail;
		GetComponent<AutoTransformRebuild>().RebuildTransform();
	}

	public void UpdateScore(EMapSize mapSize)
	{
		int score = LTFunctionLibrary.GetLevelsProgressionManager().GetLevelProgressionInfoByID(levelData.Id).GetScore(mapSize);
		if (score == 0)
		{
			scoreText.text = "-";
		}
		else
		{
			scoreText.text = score.ToString();
		}
		string localizedString = LocalizationSettings.StringDatabase.GetLocalizedString("UI_EndlessModeMenu", "UI_EndlessModeMenu_tooltip_bestScore", null, FallbackBehavior.UseProjectSettings);
		scoreTooltip.TooltipText = string.Format(localizedString, MatchSettings.GetMapSizeName(mapSize));
		GetComponent<AutoTransformRebuild>().RebuildTransform();
	}

	public void OnLevelPressed()
	{
		this.onButtonPressed?.Invoke(levelData);
	}
}
