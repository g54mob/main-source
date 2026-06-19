using System;
using FullInspector;
using I2.Loc;
using JetBrains.Annotations;

namespace TH20
{
	[Serializable]
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class StaffChallengeSubGoalDefinitionQualification : SubGoalDefinition
	{
		public SharedInstance<QualificationDefinition> Qualification;

		public override ObjectiveSubGoal CreateSubGoal(Objective owner)
		{
			return new StaffChallengeLevelObjectiveQualification(owner, this);
		}

		public override string GoalText(Objective objective)
		{
			if (!Qualification.NotNull())
			{
				return ScriptLocalization.Challenges_SubGoals.LearnAnyQualification_Goal_CS;
			}
			return LocalisedString.Replace(ScriptLocalization.Challenges_SubGoals.LearnQualification_Goal_CS, "{[QUALIFICATION]}", Qualification.Instance.NameLocalised.Translation);
		}

		public override bool HasBeenAchieved(Level level)
		{
			return false;
		}
	}
}
