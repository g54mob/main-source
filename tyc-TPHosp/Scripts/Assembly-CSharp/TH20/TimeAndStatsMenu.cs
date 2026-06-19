using System;
using FullInspector;
using I2.Loc;
using TH20.EventAwardSilver;
using TH20.EventUnlockItem;
using TH20.UI;
using TMPro;
using UnityEngine;

namespace TH20
{
	public class TimeAndStatsMenu : MenuBase, TH20.EventAwardSilver.Interface, IGameEventCallback, TH20.EventUnlockItem.Interface
	{
		[InspectorMargin(8)]
		[InspectorHeader("Text")]
		[SerializeField]
		private TMP_Text _balanceText;

		[SerializeField]
		private TMP_Text _silverText;

		[SerializeField]
		private TMP_Text _shortMonthText;

		[SerializeField]
		private TMP_Text _dayNumberText;

		[InspectorMargin(8)]
		[InspectorHeader("Progress Bars")]
		[SerializeField]
		private ProgressBarMaskable _reputationMaskable;

		[SerializeField]
		private TMP_Text _prestigeText;

		[SerializeField]
		private ProgressBarMaskable _prestigeMaskable;

		[InspectorMargin(8)]
		[InspectorHeader("Buttons")]
		[SerializeField]
		private DynamicButton _pauseButton;

		[SerializeField]
		private DynamicButton _slowButton;

		[SerializeField]
		private DynamicButton _playButton;

		[SerializeField]
		private DynamicButton _fastForwardButton;

		[SerializeField]
		private Color _unselectedColor;

		[SerializeField]
		private Color _selectedColor;

		[InspectorMargin(8)]
		[InspectorHeader("Tooltips")]
		[SerializeField]
		private TooltipSpawner _balanceTooltipSpawner;

		[SerializeField]
		private TooltipSpawner _yearTooltipSpawner;

		[SerializeField]
		private TooltipSpawner _hospitalLevelTooltipSpawner;

		[SerializeField]
		private TooltipSpawner _reputationTooltipSpawner;

		[InspectorMargin(8)]
		[SerializeField]
		private LocalisedString _revenueLocalisedString;

		[SerializeField]
		private LocalisedString _expensesLocalisedString;

		[SerializeField]
		private LocalisedString _netIncomeLocalisedString;

		[SerializeField]
		private LocalisedString _totalSilverLocalisedString;

		[SerializeField]
		private LocalisedString _hospitalLevelTooltipLocalisedString;

		[SerializeField]
		private LocalisedString _reputationTooltipLocalisedString;

		[InspectorMargin(8)]
		[SerializeField]
		private LocalisedString _reputationVeryPoorLocalisedString;

		[SerializeField]
		private LocalisedString _reputationPoorLocalisedString;

		[SerializeField]
		private LocalisedString _reputationFineLocalisedString;

		[SerializeField]
		private LocalisedString _reputationGoodLocalisedString;

		[SerializeField]
		private LocalisedString _reputationGreatLocalisedString;

		[InspectorMargin(8)]
		[SerializeField]
		private int _slowButtonTimeScaleIndex;

		[SerializeField]
		private int _playButtonTimeScaleIndex;

		[SerializeField]
		private int _fastForwardButtonTimeScaleIndex;

		private Color _balancePostiveColor;

		[SerializeField]
		private Color _balanceNegativeColor;

		private Level _level;

		private GameTime _gameTime;

		private TimelineManager _timelineManager;

		public void Setup(Level level, TimelineManager timelineManager, GameTime gameTime)
		{
			_level = level;
			_gameTime = gameTime;
			_timelineManager = timelineManager;
			TimelineManager timelineManager2 = _timelineManager;
			timelineManager2.OnTimelineUpdated = (Action<int, int, int>)Delegate.Combine(timelineManager2.OnTimelineUpdated, new Action<int, int, int>(OnTimelineUpdated));
			PrestigeTracker prestigeTracker = _level.PrestigeTracker;
			prestigeTracker.OnPrestigeChangedEvent = (Action<PrestigeTracker>)Delegate.Combine(prestigeTracker.OnPrestigeChangedEvent, new Action<PrestigeTracker>(OnPrestigeChangedEvent));
			ReputationTracker reputationTracker = _level.ReputationTracker;
			reputationTracker.OnReputationChangedEvent = (Action<float>)Delegate.Combine(reputationTracker.OnReputationChangedEvent, new Action<float>(OnReputationChangedEvent));
			LocalizationManager.OnLocalizeEvent += OnLocalize;
			FinanceManager financeManager = _level.FinanceManager;
			financeManager.OnBalanceUpdated = (Action<int>)Delegate.Combine(financeManager.OnBalanceUpdated, new Action<int>(OnBalanceUpdated));
			_level.Metagame.OnSilverAwarded.Add(this);
			_level.Metagame.OnItemUnlocked.Add(this);
			_balancePostiveColor = _balanceText.color;
			_pauseButton.onPrimaryDown.AddListener(OnPauseButtonClick);
			_slowButton.onPrimaryDown.AddListener(OnSlowButtonPrimaryDown);
			_playButton.onPrimaryDown.AddListener(OnPlayButtonPrimaryDown);
			_fastForwardButton.onPrimaryDown.AddListener(OnFastForwardButtonPrimaryDown);
			GameTime gameTime2 = _gameTime;
			gameTime2.OnPauseChange = (Action<bool>)Delegate.Combine(gameTime2.OnPauseChange, new Action<bool>(OnPauseChange));
			GameTime gameTime3 = _gameTime;
			gameTime3.OnTimeScaleChange = (Action<int>)Delegate.Combine(gameTime3.OnTimeScaleChange, new Action<int>(OnTimeScaleChange));
			_silverText.text = StringUtils.FormatCurrencyWithoutSymbol(_level.Metagame.TotalSilver());
			SetSelectedButton(_gameTime.IsPausedByUser, _gameTime.TimeScaleIndex);
			SetBalanceText(_level.FinanceManager.Balance);
			OnTimelineUpdated(_timelineManager.Day, _timelineManager.Month, _timelineManager.Year);
			OnPrestigeChangedEvent(_level.PrestigeTracker);
			OnReputationChangedEvent(_level.ReputationTracker.OverallReputation);
			_yearTooltipSpawner.SetDataProvider(delegate(Tooltip tooltip)
			{
				string arg = string.Format(ScriptLocalization.Tooltip.TimeAndStatsMenu_Year_CS, timelineManager.Year + 1);
				string arg2 = (_level.Config.DisplayNameLocalised.IsNull() ? "???" : _level.Config.DisplayNameLocalised.Translation);
				if (_level.IsSandbox())
				{
					arg2 = SandboxSaveManager.CurrentSettings.DisplayName;
				}
				tooltip.Text = $"{arg}\n{arg2}";
			});
			_reputationTooltipSpawner.SetDataProvider(delegate(Tooltip tooltip)
			{
				TooltipReputation obj = (TooltipReputation)tooltip;
				string text = ((_reputationMaskable.Progress < 0.2f) ? _reputationVeryPoorLocalisedString.Translation : ((_reputationMaskable.Progress < 0.4f) ? _reputationPoorLocalisedString.Translation : ((_reputationMaskable.Progress < 0.6f) ? _reputationFineLocalisedString.Translation : ((!(_reputationMaskable.Progress < 0.8f)) ? _reputationGreatLocalisedString.Translation : _reputationGoodLocalisedString.Translation))));
				obj.ReputationDescription.text = ScriptLocalization.Misc.Reputation_CS + ScriptLocalization.Misc.ColonSeparator_CS + text;
				obj.Text = _reputationTooltipLocalisedString.Translation;
			});
			_hospitalLevelTooltipSpawner.SetDataProvider(delegate(Tooltip tooltip)
			{
				tooltip.Text = _hospitalLevelTooltipLocalisedString.Translation;
			});
			_balanceTooltipSpawner.SetDataProvider(delegate(Tooltip tooltip)
			{
				TooltipBalance obj = (TooltipBalance)tooltip;
				LevelStatsDatabase.MonthStats latestCompletedMonthStats = _level.LevelStatsDatabase.GetLatestCompletedMonthStats();
				int revenue = latestCompletedMonthStats.Revenue;
				int regularExpenses = latestCompletedMonthStats.RegularExpenses;
				int num = revenue - regularExpenses;
				obj.RevenueText.text = _revenueLocalisedString.Translation.Replace("{[AMOUNT]}", StringUtils.FormatCurrency(revenue));
				obj.ExpensesText.text = _expensesLocalisedString.Translation.Replace("{[AMOUNT]}", StringUtils.FormatCurrency(regularExpenses));
				obj.NetIncomeText.text = _netIncomeLocalisedString.Translation.Replace("{[AMOUNT]}", StringUtils.FormatCurrency(num));
				obj.SilverText.text = _totalSilverLocalisedString.Translation.Replace("{[AMOUNT]}", StringUtils.FormatSilverCurrency(_level.Metagame.TotalSilver()));
			});
			foreach (ChallengeBudget item in _level.ChallengeManager.GetActiveChallengesOfType<ChallengeBudget>())
			{
				if (item != null && item.ShouldShowRunningCosts())
				{
					RunningCostsDisplay componentInChildren = GetComponentInChildren<RunningCostsDisplay>(includeInactive: true);
					if (componentInChildren != null)
					{
						GameObjectUtils.SetActive(componentInChildren.gameObject, isActive: true);
						componentInChildren.Initialise(item);
						break;
					}
				}
			}
		}

		public void OnSilverAwardedEvent(int sliverAmount)
		{
			_silverText.text = StringUtils.FormatCurrencyWithoutSymbol(_level.Metagame.TotalSilver());
		}

		public void OnItemUnlockedEvent(ISilverUnlockable item)
		{
			_silverText.text = StringUtils.FormatCurrencyWithoutSymbol(_level.Metagame.TotalSilver());
		}

		private void OnSlowButtonPrimaryDown()
		{
			if (!_gameTime.IsSuperPaused)
			{
				if (_gameTime.IsPausedByUser)
				{
					_gameTime.IsPausedByUser = false;
				}
				_gameTime.TimeScaleIndex = _slowButtonTimeScaleIndex;
			}
		}

		private void OnPlayButtonPrimaryDown()
		{
			if (!_gameTime.IsSuperPaused)
			{
				if (_gameTime.IsPausedByUser)
				{
					_gameTime.IsPausedByUser = false;
				}
				_gameTime.TimeScaleIndex = _playButtonTimeScaleIndex;
			}
		}

		private void OnFastForwardButtonPrimaryDown()
		{
			if (!_gameTime.IsSuperPaused)
			{
				if (_gameTime.IsPausedByUser)
				{
					_gameTime.IsPausedByUser = false;
				}
				_gameTime.TimeScaleIndex = _fastForwardButtonTimeScaleIndex;
			}
		}

		private void OnPauseButtonClick()
		{
			if (!_gameTime.IsSuperPaused)
			{
				_gameTime.TogglePause();
			}
		}

		private void OnTimeScaleChange(int timeScale)
		{
			SetSelectedButton(_gameTime.IsPausedByUser, timeScale);
		}

		private void OnPauseChange(bool isPaused)
		{
			SetSelectedButton(isPaused, _gameTime.TimeScaleIndex);
		}

		private void SetSelectedButton(bool isPaused, int timeScale)
		{
			if (isPaused)
			{
				_pauseButton.GetComponent<ButtonAnimator>().CurrentState = ButtonAnimator.State.Selected;
				_slowButton.GetComponent<ButtonAnimator>().CurrentState = ButtonAnimator.State.Selectable;
				_playButton.GetComponent<ButtonAnimator>().CurrentState = ButtonAnimator.State.Selectable;
				_fastForwardButton.GetComponent<ButtonAnimator>().CurrentState = ButtonAnimator.State.Selectable;
				_slowButton.image.color = _unselectedColor;
				_fastForwardButton.image.color = _unselectedColor;
			}
			else if (timeScale == _slowButtonTimeScaleIndex)
			{
				_pauseButton.GetComponent<ButtonAnimator>().CurrentState = ButtonAnimator.State.Selectable;
				_slowButton.GetComponent<ButtonAnimator>().CurrentState = ButtonAnimator.State.Selected;
				_playButton.GetComponent<ButtonAnimator>().CurrentState = ButtonAnimator.State.Selected;
				_fastForwardButton.GetComponent<ButtonAnimator>().CurrentState = ButtonAnimator.State.Selectable;
				_slowButton.image.color = _selectedColor;
				_fastForwardButton.image.color = _unselectedColor;
			}
			else if (timeScale == _playButtonTimeScaleIndex)
			{
				_pauseButton.GetComponent<ButtonAnimator>().CurrentState = ButtonAnimator.State.Selectable;
				_slowButton.GetComponent<ButtonAnimator>().CurrentState = ButtonAnimator.State.Selectable;
				_playButton.GetComponent<ButtonAnimator>().CurrentState = ButtonAnimator.State.Selected;
				_fastForwardButton.GetComponent<ButtonAnimator>().CurrentState = ButtonAnimator.State.Selectable;
				_slowButton.image.color = _unselectedColor;
				_fastForwardButton.image.color = _unselectedColor;
			}
			else if (timeScale >= _fastForwardButtonTimeScaleIndex)
			{
				_pauseButton.GetComponent<ButtonAnimator>().CurrentState = ButtonAnimator.State.Selectable;
				_slowButton.GetComponent<ButtonAnimator>().CurrentState = ButtonAnimator.State.Selectable;
				_playButton.GetComponent<ButtonAnimator>().CurrentState = ButtonAnimator.State.Selected;
				_fastForwardButton.GetComponent<ButtonAnimator>().CurrentState = ButtonAnimator.State.Selected;
				_slowButton.image.color = _unselectedColor;
				_fastForwardButton.image.color = _selectedColor;
			}
		}

		private void OnTimelineUpdated(int day, int month, int year)
		{
			_shortMonthText.text = GameDate.GetMonthShortNameUppercase(month);
			_dayNumberText.text = StringUtils.FormatNumericDay(day);
		}

		private void OnPrestigeChangedEvent(PrestigeTracker prestigeTracker)
		{
			_prestigeText.text = ScriptLocalization.Misc.PrestigeLevel_CS.Replace("{0}", prestigeTracker.Level.ToString());
			_prestigeMaskable.SetProgressSmooth(prestigeTracker.Progress);
		}

		private void OnReputationChangedEvent(float newReputation)
		{
			_reputationMaskable.SetProgressSmooth(newReputation);
		}

		private void OnBalanceUpdated(int newBalance)
		{
			SetBalanceText(newBalance);
		}

		private void SetBalanceText(int balance)
		{
			if (balance >= 0)
			{
				if (_balanceText.color != _balancePostiveColor)
				{
					_balanceText.color = _balancePostiveColor;
				}
			}
			else if (_balanceText.color != _balanceNegativeColor)
			{
				_balanceText.color = _balanceNegativeColor;
			}
			_balanceText.text = StringUtils.FormatCurrencyWithoutSymbol(balance);
		}

		private void OnDestroy()
		{
			TimelineManager timelineManager = _timelineManager;
			timelineManager.OnTimelineUpdated = (Action<int, int, int>)Delegate.Remove(timelineManager.OnTimelineUpdated, new Action<int, int, int>(OnTimelineUpdated));
			LocalizationManager.OnLocalizeEvent -= OnLocalize;
			PrestigeTracker prestigeTracker = _level.PrestigeTracker;
			prestigeTracker.OnPrestigeChangedEvent = (Action<PrestigeTracker>)Delegate.Remove(prestigeTracker.OnPrestigeChangedEvent, new Action<PrestigeTracker>(OnPrestigeChangedEvent));
			ReputationTracker reputationTracker = _level.ReputationTracker;
			reputationTracker.OnReputationChangedEvent = (Action<float>)Delegate.Remove(reputationTracker.OnReputationChangedEvent, new Action<float>(OnReputationChangedEvent));
			FinanceManager financeManager = _level.FinanceManager;
			financeManager.OnBalanceUpdated = (Action<int>)Delegate.Remove(financeManager.OnBalanceUpdated, new Action<int>(OnBalanceUpdated));
			GameTime gameTime = _gameTime;
			gameTime.OnPauseChange = (Action<bool>)Delegate.Remove(gameTime.OnPauseChange, new Action<bool>(OnPauseChange));
			GameTime gameTime2 = _gameTime;
			gameTime2.OnTimeScaleChange = (Action<int>)Delegate.Remove(gameTime2.OnTimeScaleChange, new Action<int>(OnTimeScaleChange));
			_level.Metagame.OnSilverAwarded.Remove(this);
			_level.Metagame.OnItemUnlocked.Remove(this);
		}

		private void OnLocalize()
		{
			if (_level.PrestigeTracker != null)
			{
				OnPrestigeChangedEvent(_level.PrestigeTracker);
			}
		}
	}
}
