using System.Globalization;
using TMPro;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.Localization.Settings;
using UnityEngine.UI;

public class EndGameInfoUI : MonoBehaviour
{
	[SerializeField]
	private bool isTutorial;

	[SerializeField]
	private TextMeshProUGUI levelNameText;

	[SerializeField]
	private TextMeshProUGUI modeNameText;

	[Header("Main info")]
	[SerializeField]
	private TextMeshProUGUI dayReachedNumberText;

	[SerializeField]
	private TextMeshProUGUI dayReachedDaytimeText;

	[SerializeField]
	private GameObject newRecordObject;

	[SerializeField]
	private TextMeshProUGUI scoreText;

	[SerializeField]
	private TextMeshProUGUI goldenCoinsText;

	[SerializeField]
	private TooltipComponent_text goldenCoinsTooltip;

	[Header("Stats info")]
	[SerializeField]
	private TextMeshProUGUI killedEnemiesText;

	[SerializeField]
	private TextMeshProUGUI damageDealtText;

	[SerializeField]
	private TextMeshProUGUI resourcesText;

	[SerializeField]
	private TextMeshProUGUI playTimeText;

	public void UpdateData()
	{
		CultureInfo cultureInfo = new CultureInfo(LocalizationSettings.SelectedLocale.Identifier.Code);
		if (isTutorial)
		{
			levelNameText.text = LocalizationSettings.StringDatabase.GetLocalizedString("Levels", "Level_tutorial_name", null, FallbackBehavior.UseProjectSettings);
			modeNameText.text = "";
		}
		else
		{
			if ((bool)MatchInfo.instance.CurrentLevelData)
			{
				levelNameText.text = MatchInfo.instance.CurrentLevelData.DisplayName.GetLocalizedString();
			}
			else
			{
				levelNameText.text = "?";
			}
			if ((bool)MatchInfo.instance?.CurrentGameMode)
			{
				modeNameText.text = MatchInfo.instance.CurrentGameMode.DisplayName.GetLocalizedString();
				TextMeshProUGUI textMeshProUGUI = modeNameText;
				textMeshProUGUI.text = textMeshProUGUI.text + " - " + MatchSettings.GetDifficultyName(LTFunctionLibrary.GetMatchInfo().CurrentMatchSettings.MatchDifficulty);
				if (LTFunctionLibrary.GetMatchInfo().CurrentMatchMode == EMatchMode.Endless)
				{
					TextMeshProUGUI textMeshProUGUI2 = modeNameText;
					textMeshProUGUI2.text = textMeshProUGUI2.text + " - " + MatchSettings.GetMapSizeName(LTFunctionLibrary.GetMatchInfo().CurrentMatchSettings.MapSize);
				}
			}
		}
		int num = LTFunctionLibrary.GetCyclesManager().CurrentCycle + 1;
		dayReachedNumberText.text = num.ToString();
		string text = ((LTFunctionLibrary.GetCyclesManager().CurrentCycleMode == ECycleMode.Neutral) ? new LocalizedString("UI_InGame", "UI_InGame_finalStats_day_label").GetLocalizedString() : new LocalizedString("UI_InGame", "UI_InGame_finalStats_night_label").GetLocalizedString());
		dayReachedDaytimeText.text = "(" + text + ")";
		if (!isTutorial && (bool)MatchInfo.instance.CurrentLevelData)
		{
			int num2 = LTFunctionLibrary.GetLTGameManager().CalculateScore();
			scoreText.text = num2.ToString("N0", cultureInfo);
			int score = LTFunctionLibrary.GetLevelsProgressionManager().GetLevelProgressionInfoByID(MatchInfo.instance.CurrentLevelData.Id).GetScore(MatchInfo.instance.CurrentMatchSettings.MapSize);
			bool active = num2 == score;
			newRecordObject.SetActive(active);
		}
		else
		{
			newRecordObject.SetActive(value: false);
		}
		if (isTutorial)
		{
			goldenCoinsText.text = 1.ToString() ?? "";
			goldenCoinsTooltip.gameObject.SetActive(value: false);
		}
		else
		{
			goldenCoinsText.text = LTFunctionLibrary.GetLTGameManager().CalculateMoneyReward(LTFunctionLibrary.GetLTGameManager().GameState == LTGameManager.EGameState.Victory, includeChests: true).ToString();
			LayoutRebuilder.ForceRebuildLayoutImmediate(goldenCoinsText.transform as RectTransform);
			LayoutRebuilder.ForceRebuildLayoutImmediate(goldenCoinsText.transform.parent as RectTransform);
			if (MatchInfo.instance.CurrentMatchMode != EMatchMode.Endless)
			{
				string text2 = "";
				if ((bool)MatchInfo.instance.CurrentLevelData)
				{
					float num3 = FunctionLibrary.RoundToDecimals((float)MatchInfo.instance.CurrentLevelData.MoneyPerWave * MatchInfo.instance.CurrentMatchSettings.GoldenCoinMultiplierCycles, 2);
					int chestCoins = LTFunctionLibrary.GetLTGameManager().ChestCoins;
					text2 = "- " + string.Format(LocalizationSettings.StringDatabase.GetLocalizedString("UI_InGame", "UI_InGame_finalStats_reward_tooltip_base", null, FallbackBehavior.UseProjectSettings), num3, Mathf.CeilToInt((float)(num - 1) * num3));
					if (chestCoins > 0)
					{
						text2 = text2 + "\n- " + string.Format(LocalizationSettings.StringDatabase.GetLocalizedString("UI_InGame", "UI_InGame_finalStats_reward_tooltip_chest", null, FallbackBehavior.UseProjectSettings), chestCoins);
					}
					if (LTFunctionLibrary.GetLTGameManager().GameState == LTGameManager.EGameState.Victory)
					{
						int num4 = 0;
						if (LTFunctionLibrary.GetLevelsProgressionManager().GetLevelVictories(MatchInfo.instance.CurrentLevelData.Id) == 1)
						{
							num4 = Mathf.CeilToInt((float)MatchInfo.instance.CurrentLevelData.MoneyFirstVictory * MatchInfo.instance.CurrentMatchSettings.GoldenCoinMultiplierVictory);
							text2 = text2 + "\n- " + string.Format(LocalizationSettings.StringDatabase.GetLocalizedString("UI_InGame", "UI_InGame_finalStats_reward_tooltip_firstVictory", null, FallbackBehavior.UseProjectSettings), num4);
						}
						else
						{
							num4 = Mathf.CeilToInt((float)MatchInfo.instance.CurrentLevelData.MoneyVictory * MatchInfo.instance.CurrentMatchSettings.GoldenCoinMultiplierVictory);
							text2 = text2 + "\n- " + string.Format(LocalizationSettings.StringDatabase.GetLocalizedString("UI_InGame", "UI_InGame_finalStats_reward_tooltip_victory", null, FallbackBehavior.UseProjectSettings), num4);
						}
					}
				}
				goldenCoinsTooltip.TooltipText = text2;
			}
		}
		int totalKilledEnemies = LTFunctionLibrary.GetGameStatsManager().GetTotalKilledEnemies();
		killedEnemiesText.text = totalKilledEnemies.ToString("N0", cultureInfo);
		int num5 = Mathf.RoundToInt(LTFunctionLibrary.GetGameStatsManager().GetTotalDamageReport().TotalDamage);
		damageDealtText.text = num5.ToString("N0", cultureInfo);
		int totalObtainedResources = LTFunctionLibrary.GetGameStatsManager().GetTotalObtainedResources();
		resourcesText.text = totalObtainedResources.ToString("N0", cultureInfo);
		playTimeText.text = FunctionLibrary.MillisecondsToHourMinuteSeconds((int)LTFunctionLibrary.GetTimeManager().GetTimeMilliseconds());
	}
}
