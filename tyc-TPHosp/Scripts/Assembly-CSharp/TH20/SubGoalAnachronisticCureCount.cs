using I2.Loc;
using JetBrains.Annotations;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.WithMembers)]
	public class SubGoalAnachronisticCureCount : SubGoalAnachronisticCure
	{
		private int _numSuccess;

		public SubGoalAnachronisticCureCount(Objective owner, SubGoalDefinitionAnachronisticCure definition)
			: base(owner, definition)
		{
		}

		protected override void Record(bool success)
		{
			base.Record(success);
			if (success)
			{
				_numSuccess++;
			}
		}

		public override int Score()
		{
			return _numSuccess;
		}

		public override string ProgressText()
		{
			string text = ScriptLocalization.Challenges_SubGoals.AnachronisticCured_Progress_CS;
			LocalisationParams.Set("CURED", _numSuccess);
			LocalisationParams.Set("COUNT", Target());
			LocalisationParams.Localise(ref text);
			return text;
		}
	}
}
