using System;
using FullInspector;
using I2.Loc;
using JetBrains.Annotations;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.WithMembers)]
	public class SubGoalDefinitionPromoteStaff : SubGoalDefinition
	{
		public SharedInstance<StaffDefinition> StaffType;

		public int TargetNumPromotions;

		public override ObjectiveSubGoal CreateSubGoal(Objective owner)
		{
			return new SubGoalPromoteStaff(owner, this);
		}

		public override string GoalText(Objective objective)
		{
			string text = ((StaffType == null) ? ScriptLocalization.Challenges_SubGoals.StaffPromote_Goal_CS : (StaffType.Instance._type switch
			{
				StaffDefinition.Type.Doctor => ScriptLocalization.Challenges_SubGoals.StaffPromote_Doctor_Goal_CS, 
				StaffDefinition.Type.Nurse => ScriptLocalization.Challenges_SubGoals.StaffPromote_Nurse_Goal_CS, 
				StaffDefinition.Type.Assistant => ScriptLocalization.Challenges_SubGoals.StaffPromote_Assistant_Goal_CS, 
				StaffDefinition.Type.Janitor => ScriptLocalization.Challenges_SubGoals.StaffPromote_Janitor_Goal_CS, 
				_ => throw new ArgumentOutOfRangeException(), 
			}));
			LocalisationParams.Set("COUNT", TargetNumPromotions);
			LocalisationParams.Localise(ref text);
			return text;
		}

		public override bool HasBeenAchieved(Level level)
		{
			return false;
		}
	}
}
