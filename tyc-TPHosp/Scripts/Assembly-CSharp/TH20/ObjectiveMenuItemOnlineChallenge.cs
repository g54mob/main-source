using I2.Loc;
using TH20.UI;
using TMPro;
using UnityEngine;

namespace TH20
{
	public class ObjectiveMenuItemOnlineChallenge : ObjectiveMenuItemBase
	{
		[SerializeField]
		private Localize _objectiveText;

		[SerializeField]
		private Localize _playerPositionText;

		[SerializeField]
		private TMP_Text _playerScoreText;

		[SerializeField]
		private TMP_Text _timeLimitText;

		[SerializeField]
		private ProgressBarMaskable _timeLimitBarImage;

		private OnlineChallengeObjective _onlineObjective;

		private bool _subscribedToTimeline;

		public override void Initialise(Level level, Objective objective)
		{
			base.Initialise(level, objective);
			_objectiveText.SetTerm(objective.Definition.NameLocalised.Term);
			_onlineObjective = objective as OnlineChallengeObjective;
			RefreshPosition();
			RefreshTimeLimit();
			RefreshScore();
		}

		private void OnEnable()
		{
			if (_level != null)
			{
				_level.AddTimelineUpdateListener(OnTimelineUpdated);
				_subscribedToTimeline = true;
			}
		}

		protected override void OnDisable()
		{
			if (_subscribedToTimeline && _level != null)
			{
				_level.RemoveTimelineUpdateListener(OnTimelineUpdated);
				_subscribedToTimeline = false;
			}
		}

		private void RefreshScore()
		{
			if (_onlineObjective != null)
			{
				switch (_onlineObjective.Definition.ScoreDisplayMode)
				{
				case OnlineChallengeDefinition.ScoreDisplayType.Number:
					_playerScoreText.text = $"{ScriptLocalization.Misc.Score_CS}{ScriptLocalization.Misc.ColonSeparator_CS}{StringUtils.FormatNumber((int)_onlineObjective.GetLocalPlayerScore())}";
					break;
				case OnlineChallengeDefinition.ScoreDisplayType.Currency:
					_playerScoreText.text = $"{ScriptLocalization.Misc.Score_CS}{ScriptLocalization.Misc.ColonSeparator_CS}{StringUtils.FormatCurrency((int)_onlineObjective.GetLocalPlayerScore())}";
					break;
				case OnlineChallengeDefinition.ScoreDisplayType.Percentage:
					_playerScoreText.text = $"{ScriptLocalization.Misc.Score_CS}{ScriptLocalization.Misc.ColonSeparator_CS}{StringUtils.FormatPercentageValue(_onlineObjective.GetLocalPlayerScore())}";
					break;
				}
			}
		}

		private void RefreshPosition()
		{
			if (_onlineObjective != null)
			{
				_playerPositionText.SetTerm(_onlineObjective.GetLocalPlayerPositionString());
			}
		}

		private void RefreshTimeLimit()
		{
			if (_onlineObjective != null)
			{
				int timeLength = _objective.Definition.TimeLength;
				float num = (float)_objective.DaysElapsed / (float)timeLength;
				_timeLimitText.text = LocalisedString.GetTranslationPlural("Challenges/TimeLimit_CS", _objective.DaysElapsed);
				_timeLimitText.text = string.Format(_timeLimitText.text, _objective.DaysElapsed, _objective.Definition.TimeLength);
				_timeLimitBarImage.SetProgressSmooth(1f - num);
			}
		}

		private void Update()
		{
			RefreshScore();
		}

		private void OnTimelineUpdated(int day, int month, int year)
		{
			RefreshPosition();
			RefreshTimeLimit();
		}
	}
}
