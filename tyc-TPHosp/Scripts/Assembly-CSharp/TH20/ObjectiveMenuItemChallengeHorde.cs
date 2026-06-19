using I2.Loc;
using TMPro;
using UnityEngine;

namespace TH20
{
	public class ObjectiveMenuItemChallengeHorde : ObjectiveMenuItemBase
	{
		[SerializeField]
		private TMP_Text _titleText;

		[SerializeField]
		private TMP_Text _waveText;

		[SerializeField]
		private TMP_Text _infoText;

		private ChallengeHorde _challenge;

		public override void Initialise(Level level, Objective objective)
		{
			base.Initialise(level, objective);
			_challenge = objective as ChallengeHorde;
			Refresh();
		}

		private void Update()
		{
			Refresh();
		}

		private void Refresh()
		{
			_titleText.text = _challenge.GetTitleText();
			_waveText.text = ScriptLocalization.Challenges.Horde_ObjectiveMenuWave_CS.Replace("{[WAVE]}", (_challenge.WaveIndex + 1).ToString());
			string term = ((_challenge.Countdown != 0) ? ScriptLocalization.Challenges.Horde_ObjectiveMenuCountdown_CS : ScriptLocalization.Challenges.Horde_ObjectiveMenuProgress_CS);
			term = LocalisedString.Replace(term, new SubPair[6]
			{
				new SubPair("{[REMAIN]}", _challenge.NumRemaining),
				new SubPair("{[STREAK]}", _challenge.CureStreak),
				new SubPair("{[CURED]}", _challenge.Cured),
				new SubPair("{[PROCESSED]}", _challenge.TotalPatients),
				new SubPair("{[PERCENT]}", StringUtils.FormatPercentageValue(_challenge.CureRatePercent)),
				new SubPair("{[TARGET]}", StringUtils.FormatPercentageValue(_challenge.TargetCureRatePercent))
			});
			LocalisationParams.Set("DAYS", _challenge.Countdown);
			_infoText.text = LocalisationParams.Localise(ref term);
		}
	}
}
