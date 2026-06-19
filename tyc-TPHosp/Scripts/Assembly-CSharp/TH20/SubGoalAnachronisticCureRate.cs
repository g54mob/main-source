using I2.Loc;
using JetBrains.Annotations;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.WithMembers)]
	public class SubGoalAnachronisticCureRate : SubGoalAnachronisticCure
	{
		public SubGoalAnachronisticCureRate(Objective owner, SubGoalDefinitionAnachronisticCure definition)
			: base(owner, definition)
		{
		}

		public override int Score()
		{
			if (_historyLength <= 0)
			{
				return 0;
			}
			return 100 * NumSuccess() / _historyLength;
		}

		public override string ProgressText()
		{
			int value = NumSuccess();
			string text = ScriptLocalization.Challenges_SubGoals.AnachronisticCureRate_Progress_CS;
			LocalisationParams.Set("CURED", value);
			LocalisationParams.Set("TOTAL", _historyLength);
			LocalisationParams.Set("SCORE", StringUtils.FormatPercentageValue((float)Score() / 100f));
			LocalisationParams.Localise(ref text);
			return text;
		}
	}
}
