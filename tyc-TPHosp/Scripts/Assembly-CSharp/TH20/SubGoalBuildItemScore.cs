using JetBrains.Annotations;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.WithMembers)]
	public class SubGoalBuildItemScore : SubGoalBuildItem
	{
		public SubGoalBuildItemScore(Objective owner, SubGoalDefinitionBuildItem definition)
			: base(owner, definition)
		{
		}

		public override bool IsDefinitionValid()
		{
			return base.Definition is SubGoalDefinitionBuildItemScore;
		}

		public override float PercentComplete()
		{
			return (float)(base.Definition as SubGoalDefinitionBuildItemScore).ItemMultiplier * base.PercentComplete();
		}

		public override string ProgressText()
		{
			string text = (base.Definition as SubGoalDefinitionBuildItemScore).ProgressLocString.Translation;
			LocalisationParams.Set("SCORE", (int)(100f * PercentComplete()));
			LocalisationParams.Localise(ref text);
			return text;
		}
	}
}
