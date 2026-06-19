using I2.Loc;
using TMPro;
using UnityEngine;

namespace TH20
{
	public class ObjectiveMenuItemChallengeWaveObjectivesHorde : ObjectiveMenuItemBase
	{
		[SerializeField]
		private TMP_Text _titleText;

		[SerializeField]
		private TMP_Text _waveText;

		[SerializeField]
		private TMP_Text _infoText;

		private ChallengeWaveObjectivesHorde _challenge;

		public override void Initialise(Level level, Objective objective)
		{
			base.Initialise(level, objective);
			_challenge = objective as ChallengeWaveObjectivesHorde;
			Refresh();
		}

		private void Update()
		{
			Refresh();
		}

		private void Refresh()
		{
			if (_titleText != null)
			{
				_titleText.text = _challenge.GetTitleText();
			}
			if (_waveText != null)
			{
				_waveText.text = ScriptLocalization.Challenges.Horde_ObjectiveMenuWave_CS.Replace("{[WAVE]}", (_challenge.WaveNum + 1).ToString());
			}
			if (!(_infoText != null))
			{
				return;
			}
			string empty = string.Empty;
			if (_challenge.Countdown != 0)
			{
				empty = ScriptLocalization.Challenges.Horde_ObjectiveMenuCountdown_CS;
				LocalisationParams.Set("DAYS", _challenge.Countdown);
			}
			else
			{
				string text = string.Empty;
				Objective activeWaveObjective = _challenge.GetActiveWaveObjective();
				if (activeWaveObjective != null)
				{
					ObjectiveSubGoal mostImportantUnfinishedSubGoal = activeWaveObjective.GetMostImportantUnfinishedSubGoal();
					if (mostImportantUnfinishedSubGoal != null)
					{
						text = mostImportantUnfinishedSubGoal.Definition.GoalText(activeWaveObjective);
						string text2 = mostImportantUnfinishedSubGoal.ProgressText();
						if (!string.IsNullOrEmpty(text2))
						{
							text += "\n";
							text += text2;
						}
					}
				}
				else
				{
					text = ScriptLocalization.Challenges.WaveObjectivesHorde_WaveObjectiveComplete_CS;
				}
				empty = ScriptLocalization.Challenges.WaveObjectivesHorde_ObjectiveMenuProgress_CS;
				empty = LocalisedString.Replace(empty, new SubPair[3]
				{
					new SubPair("{[PROCESSED]}", _challenge.NumProcessed),
					new SubPair("{[REMAIN]}", _challenge.NumRemaining),
					new SubPair("{[WAVEOBJECTIVE]}", text)
				});
			}
			LocalisationParams.Localise(ref empty);
			_infoText.text = empty;
		}
	}
}
