using System;
using System.Collections.Generic;
using CTS.Core;
using NaughtyAttributes;
using TMPro;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.Localization.Settings;

namespace CTS
{
	public class UI_BarPrestigeData : MonoBehaviour
	{
		[Serializable]
		private struct PrestigeSuccess
		{
			public int PrestigeLevel;

			public string succeskey;
		}

		[SerializeField]
		private LocalizedString _levelKey;

		[SerializeField]
		private LocalizedString _attractivityKey;

		[SerializeField]
		private LocalizedString _turnoverKey;

		[SerializeField]
		private LocalizedString _secKey;

		[SerializeField]
		private LocalizedString _ratioKey;

		[SerializeField]
		private TMP_Text _levelTitleText;

		[SerializeField]
		private TMP_Text _attractivityTitleText;

		[SerializeField]
		private TMP_Text _turnoverTitleText;

		[SerializeField]
		private TMP_Text _ratioTitleText;

		[SerializeField]
		private TMP_Text _levelValueText;

		[SerializeField]
		private TMP_Text _attractivityValueText;

		[SerializeField]
		private TMP_Text _turnoverValueText;

		[SerializeField]
		private TMP_Text _ratioValueText;

		[SerializeField]
		[Foldout("Prestige Success")]
		private List<PrestigeSuccess> _listSuccess;

		private void Start()
		{
			LocalizationSettings.SelectedLocaleChanged += LocalizationSettings_SelectedLocaleChanged;
			Prestige.PrestigeLevelChanged += PrestigeLevelChanged;
			Prestige.PrestigeChanged += PrestigeChanged;
		}

		private void OnDestroy()
		{
			LocalizationSettings.SelectedLocaleChanged -= LocalizationSettings_SelectedLocaleChanged;
			Prestige.PrestigeLevelChanged -= PrestigeLevelChanged;
			Prestige.PrestigeChanged -= PrestigeChanged;
		}

		private void PrestigeChanged(PrestigeLevelData data, float currentPrestige)
		{
			LocalizationSettings_SelectedLocaleChanged(null);
		}

		private void PrestigeLevelChanged(PrestigeLevelData data)
		{
			LocalizationSettings_SelectedLocaleChanged(null);
		}

		private void LocalizationSettings_SelectedLocaleChanged(Locale obj)
		{
			if (!MonoSingleton<Prestige>.InstanceExists() || MonoSingleton<Prestige>.Instance.CurrentPrestigeLevel == null)
			{
				return;
			}
			UpdateLevelText(MonoSingleton<Prestige>.Instance.CurrentPrestigeLevel.Level, MonoSingleton<Prestige>.Instance.GetNextStepPrestige(), MonoSingleton<Prestige>.Instance.CurrentPrestige);
			UpdateAttractivity(MonoSingleton<Prestige>.Instance.CurrentPrestigeLevel.MaxPopulation);
			UpdateTurnover(MonoSingleton<Prestige>.Instance.CurrentPrestigeLevel.TimeBetweenSpawnsInSeconds);
			UpdateRatio(1, (int)MonoSingleton<Prestige>.Instance.CurrentPrestigeLevel.VampireRatio);
			int level = MonoSingleton<Prestige>.Instance.CurrentPrestigeLevel.Level;
			foreach (PrestigeSuccess item in _listSuccess)
			{
				if (level >= item.PrestigeLevel)
				{
					AchievementManager.UnlockAchievement(item.succeskey);
				}
			}
		}

		private void UpdateLevelText(int currentLevel, float pointsForNextLevel, float currentPoints)
		{
			_levelTitleText.text = _levelKey.GetLocalizedStringSafe() + " " + currentLevel;
			currentPoints = MathF.Floor(currentPoints);
			_levelValueText.text = currentPoints + "/" + pointsForNextLevel;
		}

		private void UpdateAttractivity(int attractivity)
		{
			_attractivityTitleText.text = _attractivityKey.GetLocalizedStringSafe();
			_attractivityValueText.text = attractivity.ToString();
		}

		private void UpdateTurnover(float turnover)
		{
			_turnoverTitleText.text = _turnoverKey.GetLocalizedStringSafe();
			_turnoverValueText.text = turnover + " " + _secKey.GetLocalizedStringSafe();
		}

		private void UpdateRatio(int ratioVampire, int ratioHuman)
		{
			_ratioTitleText.text = _ratioKey.GetLocalizedStringSafe();
			_ratioValueText.text = ratioVampire + "/" + ratioHuman;
		}
	}
}
