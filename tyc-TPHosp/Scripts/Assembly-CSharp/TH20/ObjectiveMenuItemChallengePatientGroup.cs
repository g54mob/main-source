using I2.Loc;
using TH20.UI;
using TMPro;
using UnityEngine;

namespace TH20
{
	public class ObjectiveMenuItemChallengePatientGroup : ObjectiveMenuItemBase
	{
		[SerializeField]
		private TMP_Text _titleText;

		[SerializeField]
		private TMP_Text _inProgressText;

		[SerializeField]
		private TMP_Text _curedFailedText;

		[SerializeField]
		private GameObject _timeLimitBar;

		[SerializeField]
		private TMP_Text _timeLimitText;

		[SerializeField]
		private ProgressBarMaskable _timeLimitBarImage;

		private ChallengeSpecialPatient _challenge;

		public override void Initialise(Level level, Objective objective)
		{
			base.Initialise(level, objective);
			_challenge = objective as ChallengeSpecialPatient;
			_titleText.text = objective.GetTitleText();
			Refresh();
		}

		private void Refresh()
		{
			switch (_challenge.ChallengeStatus)
			{
			case Challenge.ChallengeState.WaitingToStart:
				_inProgressText.text = LocalisedString.GetTranslationPlural("Challenges/ArrivingInDays_CS", _challenge.DaysUntilStartingChallenge);
				_inProgressText.text = string.Format(_inProgressText.text, _challenge.DaysUntilStartingChallenge);
				_curedFailedText.text = string.Empty;
				GameObjectUtils.SetActive(_timeLimitBar, isActive: false);
				break;
			case Challenge.ChallengeState.InProgress:
				if (_challenge.PatientsInProgress <= 0)
				{
					_inProgressText.text = ScriptLocalization.Challenges.InArriving_CS;
				}
				else
				{
					_inProgressText.text = string.Format(ScriptLocalization.Challenges.InProgress_CS, _challenge.PatientsInProgress);
				}
				_curedFailedText.text = string.Format(ScriptLocalization.Challenges.PatientsCuredAndFailed_CS, _challenge.PatientsCured, _challenge.PatientsFailed);
				GameObjectUtils.SetActive(_timeLimitBar, _objective.Definition.IsTimed);
				if (_objective.Definition.IsTimed)
				{
					int timeLength = _objective.Definition.TimeLength;
					float num = (float)_objective.DaysElapsed / (float)timeLength;
					if (_timeLimitText != null)
					{
						_timeLimitText.text = LocalisedString.GetTranslationPlural("Challenges/TimeLimit_CS", _objective.DaysElapsed);
						_timeLimitText.text = string.Format(_timeLimitText.text, _objective.DaysElapsed, _objective.Definition.TimeLength);
					}
					if (_timeLimitBar != null && _timeLimitBarImage != null)
					{
						_timeLimitBarImage.SetProgressSmooth(1f - num);
					}
				}
				break;
			case Challenge.ChallengeState.WaitingToIssueDebrief:
				GameObjectUtils.SetActive(base.gameObject, isActive: false);
				break;
			}
		}

		private void Update()
		{
			Refresh();
		}
	}
}
