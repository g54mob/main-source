using System.Globalization;
using TMPro;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.Localization.Settings;

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
	private TextMeshProUGUI playTimeText;

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

	public void UpdateData()
	{
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
			if ((bool)MatchInfo.instance?.CurrentMatchSettings)
			{
				modeNameText.text = MatchInfo.instance.CurrentMatchSettings.DisplayName.GetLocalizedString();
			}
		}
		int num = LTFunctionLibrary.GetCyclesManager().CurrentCycle + 1;
		dayReachedNumberText.text = num.ToString();
		string text = ((LTFunctionLibrary.GetCyclesManager().CurrentCycleMode == ECycleMode.Neutral) ? new LocalizedString("UI_InGame", "UI_InGame_finalStats_day_label").GetLocalizedString() : new LocalizedString("UI_InGame", "UI_InGame_finalStats_night_label").GetLocalizedString());
		dayReachedDaytimeText.text = "(" + text + ")";
		playTimeText.text = FunctionLibrary.MillisecondsToHourMinuteSeconds((int)LTFunctionLibrary.GetTimeManager().GetTimeMilliseconds());
		if (isTutorial)
		{
			goldenCoinsText.text = 1.ToString() ?? "";
			goldenCoinsTooltip.gameObject.SetActive(value: false);
		}
		else
		{
			goldenCoinsText.text = LTFunctionLibrary.GetLTGameManager().CalculateMoneyReward(LTFunctionLibrary.GetLTGameManager().GameState == LTGameManager.EGameState.Victory, includeChests: true).ToString();
			string text2 = "";
			if ((bool)MatchInfo.instance.CurrentLevelData)
			{
				float num2 = FunctionLibrary.RoundToDecimals((float)MatchInfo.instance.CurrentLevelData.MoneyPerWave * MatchInfo.instance.CurrentMatchSettings.GoldenCoinMultiplierCycles, 2);
				int chestCoins = LTFunctionLibrary.GetLTGameManager().ChestCoins;
				text2 = "- " + string.Format(LocalizationSettings.StringDatabase.GetLocalizedString("UI_InGame", "UI_InGame_finalStats_reward_tooltip_base", null, FallbackBehavior.UseProjectSettings), num2, Mathf.CeilToInt((float)(num - 1) * num2));
				if (chestCoins > 0)
				{
					text2 = text2 + "\n- " + string.Format(LocalizationSettings.StringDatabase.GetLocalizedString("UI_InGame", "UI_InGame_finalStats_reward_tooltip_chest", null, FallbackBehavior.UseProjectSettings), chestCoins);
				}
				if (LTFunctionLibrary.GetLTGameManager().GameState == LTGameManager.EGameState.Victory)
				{
					int num3 = 0;
					if (LTFunctionLibrary.GetLevelsProgressionManager().GetLevelVictories(MatchInfo.instance.CurrentLevelData.Id) == 1)
					{
						num3 = Mathf.CeilToInt((float)MatchInfo.instance.CurrentLevelData.MoneyFirstVictory * MatchInfo.instance.CurrentMatchSettings.GoldenCoinMultiplierVictory);
						text2 = text2 + "\n- " + string.Format(LocalizationSettings.StringDatabase.GetLocalizedString("UI_InGame", "UI_InGame_finalStats_reward_tooltip_firstVictory", null, FallbackBehavior.UseProjectSettings), num3);
					}
					else
					{
						num3 = Mathf.CeilToInt((float)MatchInfo.instance.CurrentLevelData.MoneyVictory * MatchInfo.instance.CurrentMatchSettings.GoldenCoinMultiplierVictory);
						text2 = text2 + "\n- " + string.Format(LocalizationSettings.StringDatabase.GetLocalizedString("UI_InGame", "UI_InGame_finalStats_reward_tooltip_victory", null, FallbackBehavior.UseProjectSettings), num3);
					}
				}
			}
			goldenCoinsTooltip.TooltipText = text2;
		}
		CultureInfo cultureInfo = new CultureInfo(LocalizationSettings.SelectedLocale.Identifier.Code);
		int totalKilledEnemies = LTFunctionLibrary.GetGameStatsManager().GetTotalKilledEnemies();
		killedEnemiesText.text = totalKilledEnemies.ToString("N0", cultureInfo);
		int num4 = Mathf.RoundToInt(LTFunctionLibrary.GetGameStatsManager().GetTotalDamageReport().TotalDamage);
		damageDealtText.text = num4.ToString("N0", cultureInfo);
		int totalObtainedResources = LTFunctionLibrary.GetGameStatsManager().GetTotalObtainedResources();
		resourcesText.text = totalObtainedResources.ToString("N0", cultureInfo);
	}
}
