using System;
using FullInspector;
using I2.Loc;
using JetBrains.Annotations;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.WithMembers)]
	public class SubGoalDefinitionHireStaff : SubGoalDefinition
	{
		public SharedInstance<StaffDefinition> StaffDefinition;

		public int StaffCount;

		public bool IncludeExisting = true;

		public override ObjectiveSubGoal CreateSubGoal(Objective owner)
		{
			return new SubGoalHireStaff(owner, this);
		}

		public StaffDefinition GetStaffDefinition()
		{
			if (!StaffDefinition.NotNull())
			{
				return null;
			}
			return StaffDefinition.Instance;
		}

		public override string GoalText(Objective objective)
		{
			string text = (StaffDefinition.IsNull() ? ScriptLocalization.Challenges_SubGoals.HireStaff_Goal_CS : (StaffDefinition.Instance._type switch
			{
				TH20.StaffDefinition.Type.Doctor => ScriptLocalization.Challenges_SubGoals.HireStaff_Doctor_Goal_CS, 
				TH20.StaffDefinition.Type.Nurse => ScriptLocalization.Challenges_SubGoals.HireStaff_Nurse_Goal_CS, 
				TH20.StaffDefinition.Type.Assistant => ScriptLocalization.Challenges_SubGoals.HireStaff_Assistant_Goal_CS, 
				TH20.StaffDefinition.Type.Janitor => ScriptLocalization.Challenges_SubGoals.HireStaff_Janitor_Goal_CS, 
				_ => throw new ArgumentOutOfRangeException(), 
			}));
			LocalisationParams.Set("COUNT", StaffCount);
			LocalisationParams.Localise(ref text);
			return text;
		}

		public override bool HasBeenAchieved(Level level)
		{
			if (IncludeExisting)
			{
				return level.CharacterManager.GetStaffOfType(GetStaffDefinition()).Count >= StaffCount;
			}
			return false;
		}
	}
}
