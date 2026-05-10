using System;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.Localization.Settings;
using UnityEngine.UI;

public class NewGameLevelUI : MonoBehaviour
{
	[SerializeField]
	private TextMeshProUGUI levelNameText;

	[SerializeField]
	private Image levelThumbnail;

	[SerializeField]
	private TextMeshProUGUI moneyPerWaveText;

	[SerializeField]
	private TextMeshProUGUI moneyPerVictoryText;

	[SerializeField]
	private TextMeshProUGUI bossNightText;

	[SerializeField]
	private GameObject levelCompletedObject;

	[SerializeField]
	private GameObject levelCompletedExpertObject;

	[SerializeField]
	private GameObject bossDefeatedObject;

	[SerializeField]
	private GameObject bossDefeatedExpertObject;

	[Header("Tooltips")]
	[SerializeField]
	private TooltipComponent_text moneyPerVictoryTooltip;

	[SerializeField]
	private TooltipComponent_levelBossInfo bossTooltip;

	[Header("Demo")]
	[SerializeField]
	private LevelData demoLevelData;

	private LevelData levelData;

	public event Action<LevelData> onButtonPressed;

	private void Start()
	{
		if ((bool)demoLevelData)
		{
			SetLevel(LTFunctionLibrary.GetLevelsProgressionManager().LevelProgressionInfos.First((LevelsProgressionManager.FLevelProgressionInfo x) => x.LevelData.Id == demoLevelData.Id));
		}
	}

	public void SetLevel(LevelsProgressionManager.FLevelProgressionInfo levelInfo)
	{
		levelData = levelInfo.LevelData;
		levelNameText.text = levelData.DisplayName.GetLocalizedString();
		levelThumbnail.sprite = levelData.Thumbnail;
		moneyPerWaveText.text = levelData.MoneyPerWave.ToString();
		moneyPerVictoryText.text = (levelInfo.Completed ? levelData.MoneyVictory.ToString() : levelData.MoneyFirstVictory.ToString());
		moneyPerVictoryTooltip.TooltipText = LocalizationSettings.StringDatabase.GetLocalizedString("UI_NewGameMenu", levelInfo.Completed ? "UI_NewGameMenu_tooltip_coinsPerVictory" : "UI_NewGameMenu_tooltip_coinsPerFirstVictory", null, FallbackBehavior.UseProjectSettings);
		bossNightText.text = levelData.TotalDays().ToString();
		bossTooltip.Setup(levelData, levelInfo);
		levelCompletedObject.SetActive(!levelInfo.CompletedInExpertMode && levelInfo.Completed);
		levelCompletedExpertObject.SetActive(levelInfo.CompletedInExpertMode);
		bossDefeatedObject.SetActive(!levelInfo.BossDefeatedInExpertMode && levelInfo.BossDefeated);
		bossDefeatedExpertObject.SetActive(levelInfo.BossDefeatedInExpertMode);
		GetComponent<AutoTransformRebuild>().RebuildTransform();
	}

	public void OnLevelPressed()
	{
		this.onButtonPressed?.Invoke(levelData);
	}
}
