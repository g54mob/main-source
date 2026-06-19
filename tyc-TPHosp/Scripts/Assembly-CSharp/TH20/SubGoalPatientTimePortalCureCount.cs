using I2.Loc;
using JetBrains.Annotations;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.WithMembers)]
	public class SubGoalPatientTimePortalCureCount : SubGoalPatientTimePortal
	{
		public SubGoalPatientTimePortalCureCount(Objective owner, SubGoalDefinitionPatientTimePortalCureCount definition)
			: base(owner, definition)
		{
		}

		public override int Score()
		{
			return NumCured();
		}

		public override string ProgressText()
		{
			string text = ScriptLocalization.Challenges_SubGoals.PortalCured_Progress_CS;
			LocalisationParams.Set("CURED", NumCured());
			LocalisationParams.Set("COUNT", Target());
			LocalisationParams.Localise(ref text);
			return text;
		}
	}
}
