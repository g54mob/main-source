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

	private GameMode gameMode;

	public GameMode GameMode
	{
		get
		{
			return gameMode;
		}
		set
		{
			gameMode = value;
			UpdateInfo();
		}
	}

	public override void LoadData()
	{
		GameMode = base.Data as GameMode;
	}

	private void UpdateInfo()
	{
		if ((bool)GameMode)
		{
			icon.sprite = GameMode.Icon;
			modeName.text = GameMode.DisplayName.GetLocalizedString();
			modeDescription.text = GameMode.Description.GetLocalizedString();
			Dictionary<string, object> dictionary = new Dictionary<string, object>
			{
				{ "pause", GameMode.AllowPause },
				{ "build-during-pause", GameMode.BuildDuringPause },
				{ "default-round-delay", GameMode.DefaultRoundDelay },
				{ "first-round-delay", GameMode.FirstRoundDelay },
				{ "max-crystal-finders", GameMode.MaxCrystalFindersAmount },
				{ "cycles-reward", GameMode.GoldenCoinMultiplierCycles },
				{ "chests-reward", GameMode.GoldenCoinMultiplierChests },
				{ "victory-reward", GameMode.GoldenCoinMultiplierVictory }
			};
			string localizedString = new LocalizedString("UI_GameModeMenu", "UI_GameModeMenu_gameMode_tooltip").GetLocalizedString(dictionary);
			modeTooltip.TooltipText = localizedString;
		}
	}
}
