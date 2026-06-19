using I2.Loc;
using TH20.UI;
using TMPro;
using UnityEngine;

namespace TH20
{
	public class ObjectiveMenuItemChallengeBudget : ObjectiveMenuItemBase
	{
		[SerializeField]
		private TMP_Text _titleText;

		[SerializeField]
		private TMP_Text _budgetText;

		[SerializeField]
		private ProgressBarMaskable _cureRateBar;

		[SerializeField]
		private TMP_Text[] _statsText;

		[SerializeField]
		private GameObject _statsContainer;

		[SerializeField]
		private GameObject[] _statsWellbeingProgressBars;

		[SerializeField]
		private GameObject[] _statsVibeProgressBars;

		[SerializeField]
		private GameObject _wellbeingIcon;

		[SerializeField]
		private GameObject _vibeIcon;

		private GameObject[] _statsProgressBarsInternal;

		private ChallengeBudget _challenge;

		private int _currentColourMapping;

		public override void Initialise(Level level, Objective objective)
		{
			base.Initialise(level, objective);
			_challenge = objective as ChallengeBudget;
			_titleText.text = objective.GetTitleText();
			TooltipSpawner component = _titleText.GetComponent<TooltipSpawner>();
			if (component != null)
			{
				component.SetDataProvider(TooltipDataProvider);
			}
			if (_challenge.ShouldUseVibeIcon())
			{
				_statsProgressBarsInternal = _statsVibeProgressBars;
			}
			else
			{
				_statsProgressBarsInternal = _statsWellbeingProgressBars;
			}
			Refresh();
			TMP_Text[] statsText = _statsText;
			for (int i = 0; i < statsText.Length; i++)
			{
				GameObjectUtils.SetActive(statsText[i].gameObject, isActive: false);
			}
			GameObject[] statsWellbeingProgressBars = _statsWellbeingProgressBars;
			for (int i = 0; i < statsWellbeingProgressBars.Length; i++)
			{
				GameObjectUtils.SetActive(statsWellbeingProgressBars[i].gameObject, isActive: false);
			}
			statsWellbeingProgressBars = _statsVibeProgressBars;
			for (int i = 0; i < statsWellbeingProgressBars.Length; i++)
			{
				GameObjectUtils.SetActive(statsWellbeingProgressBars[i].gameObject, isActive: false);
			}
			GameObjectUtils.SetActive(_statsContainer, isActive: false);
			if (_wellbeingIcon != null)
			{
				GameObjectUtils.SetActive(_wellbeingIcon, isActive: false);
			}
			if (_vibeIcon != null)
			{
				GameObjectUtils.SetActive(_vibeIcon, isActive: false);
			}
			_currentColourMapping = -1;
		}

		private void TooltipDataProvider(Tooltip tooltip)
		{
			if (_challenge != null && _challenge.ShouldShowRunningCosts())
			{
				string descriptionText = _challenge.GetDescriptionText();
				descriptionText = descriptionText.Replace("{[LOWER]}", StringUtils.FormatPercentageValue(_challenge.MinBudgetPercent * 0.01f));
				descriptionText = descriptionText.Replace("{[UPPER]}", StringUtils.FormatPercentageValue(_challenge.MaxBudgetPercent * 0.01f));
				tooltip.Text = descriptionText;
			}
		}

		private void Update()
		{
			Refresh();
		}

		private string GetLocStringForStat(LevelStatsDatabase.Stat stat)
		{
			return LocalizationManager.GetTranslation("Challenges/Budget_ObjectiveMenu" + stat.ToString() + "_CS");
		}

		private void Refresh()
		{
			switch (_challenge.ChallengeStatus)
			{
			case Challenge.ChallengeState.InProgress:
				if (_challenge.AveragedStats.Count == 0)
				{
					string newValue = $"{_challenge.PatientsCured}/{_challenge.PatientsProcessed}";
					_cureRateBar.SetProgressSmooth(_challenge.CureRate);
					_cureRateBar.LabelText = ScriptLocalization.Challenges.Budget_ObjectiveMenuCureRate_CS.Replace("{[RATE]}", newValue);
				}
				else
				{
					GameObjectUtils.SetActive(_budgetText.gameObject, isActive: false);
					if (_challenge.ShouldUseVibeIcon())
					{
						if (_vibeIcon != null)
						{
							GameObjectUtils.SetActive(_vibeIcon, isActive: true);
						}
					}
					else if (_wellbeingIcon != null)
					{
						GameObjectUtils.SetActive(_wellbeingIcon, isActive: true);
					}
					int num = 0;
					foreach (ChallengeBudgetAvgStat averagedStat in _challenge.AveragedStats)
					{
						if (_statsText.Length > num)
						{
							string newValue2 = $"{averagedStat.AvgValue}%";
							_statsText[num].text = GetLocStringForStat(averagedStat.Stat).Replace("{[RATE]}", newValue2);
						}
						if (_statsProgressBarsInternal.Length > num)
						{
							ProgressBarMaskable componentInChildren = _statsProgressBarsInternal[num].GetComponentInChildren<ProgressBarMaskable>();
							if ((bool)componentInChildren)
							{
								GameObjectUtils.SetActive(_statsProgressBarsInternal[num].gameObject, isActive: true);
								componentInChildren.SetProgressSmooth((float)MathUtils.Clamp(averagedStat.AvgValue / 100f, 0.0, 1.0));
							}
						}
						num++;
					}
					float num2 = (float)_challenge.CurrentScore / (float)_challenge.MaxScore;
					_cureRateBar.SetProgressSmooth(num2);
					_cureRateBar.LabelText = string.Empty;
					float num3 = Mathf.Lerp(_challenge.MinBudgetPercent, _challenge.MaxBudgetPercent, num2);
					ColourPercentMapping[] colourPercentMappings = _challenge.ColourPercentMappings;
					for (int i = 0; i < colourPercentMappings.Length; i++)
					{
						if (num3 <= colourPercentMappings[i].upToPercent)
						{
							if (i != _currentColourMapping)
							{
								GradientColorKey[] array = new GradientColorKey[2];
								array[0].color = colourPercentMappings[i].Colour;
								array[0].time = 0f;
								array[1].color = colourPercentMappings[i].Colour;
								array[1].time = 1f;
								GradientAlphaKey[] array2 = new GradientAlphaKey[2];
								array2[0].alpha = 1f;
								array2[0].time = 1f;
								array2[1].alpha = 1f;
								array2[1].time = 1f;
								_cureRateBar.BarGradient.SetKeys(array, array2);
								_currentColourMapping = i;
							}
							break;
						}
					}
					GameObjectUtils.SetActive(_statsContainer, isActive: true);
				}
				_budgetText.text = LocalisedString.Replace(ScriptLocalization.Challenges.Budget_ObjectiveMenuItem_CS, new SubPair[3]
				{
					new SubPair("{[COST]}", StringUtils.FormatCurrency(_challenge.RunningCost)),
					new SubPair("{[PERCENT]}", StringUtils.FormatPercentageValue(_challenge.BudgetPercent)),
					new SubPair("{[MONTH]}", GameDate.GetMonthShortName(_challenge.NextPeriod))
				});
				break;
			case Challenge.ChallengeState.WaitingToIssueDebrief:
				GameObjectUtils.SetActive(base.gameObject, isActive: false);
				break;
			}
		}
	}
}
