using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.UI;

public class GameModeUI : UIListElement
{
	[SerializeField]
	private Image icon;

	[SerializeField]
	private TextMeshProUGUI modeName;

	[SerializeField]
	private TextMeshProUGUI modeDescription;

	[SerializeField]
	private TooltipComponent_text modeTooltip;

	private MatchSettings matchSettings;

	public MatchSettings MatchSettings
	{
		get
		{
			return matchSettings;
		}
		set
		{
			matchSettings = value;
			UpdateInfo();
		}
	}

	public override void LoadData()
	{
		MatchSettings = base.Data as MatchSettings;
	}

	private void UpdateInfo()
	{
		if ((bool)MatchSettings)
		{
			icon.sprite = MatchSettings.Icon;
			modeName.text = MatchSettings.DisplayName.GetLocalizedString();
			modeDescription.text = MatchSettings.Description.GetLocalizedString();
			Dictionary<string, object> dictionary = new Dictionary<string, object>
			{
				{ "pause", MatchSettings.AllowPause },
				{ "build-during-pause", MatchSettings.BuildDuringPause },
				{
					"enemies-life",
					Mathf.RoundToInt(MatchSettings.EnemyLifeMultiplier * 100f)
				},
				{ "default-round-delay", MatchSettings.DefaultRoundDelay },
				{ "first-round-delay", MatchSettings.FirstRoundDelay },
				{ "max-crystal-finders", MatchSettings.MaxCrystalFindersAmount },
				{ "cycles-reward", MatchSettings.GoldenCoinMultiplierCycles },
				{ "chests-reward", MatchSettings.GoldenCoinMultiplierChests },
				{ "victory-reward", MatchSettings.GoldenCoinMultiplierVictory }
			};
			string localizedString = new LocalizedString("UI_GameModeMenu", "UI_GameModeMenu_gameMode_tooltip").GetLocalizedString(dictionary);
			modeTooltip.TooltipText = localizedString;
		}
	}
}
