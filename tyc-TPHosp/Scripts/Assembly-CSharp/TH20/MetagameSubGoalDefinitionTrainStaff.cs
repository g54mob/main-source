using System;
using FullInspector;
using I2.Loc;

namespace TH20
{
	public class MetagameSubGoalDefinitionTrainStaff : SubGoalDefinition
	{
		public SharedInstance<StaffDefinition> StaffType;

		public SharedInstance<QualificationDefinition> QualificationType;

		public int TargetTrainingCount;

		public override ObjectiveSubGoal CreateSubGoal(Objective owner)
		{
			return new MetagameSubGoalTrainStaff(owner, this);
		}

		public override string GoalText(Objective objective)
		{
			string text = (StaffType.NotNull() ? (QualificationType.NotNull() ? (StaffType.Instance._type switch
			{
				StaffDefinition.Type.Doctor => ScriptLocalization.Challenges_SubGoals.StaffTrain_DoctorQualification_Goal_CS, 
				StaffDefinition.Type.Nurse => ScriptLocalization.Challenges_SubGoals.StaffTrain_NurseQualification_Goal_CS, 
				StaffDefinition.Type.Assistant => ScriptLocalization.Challenges_SubGoals.StaffTrain_AssistantQualification_Goal_CS, 
				StaffDefinition.Type.Janitor => ScriptLocalization.Challenges_SubGoals.StaffTrain_JanitorQualification_Goal_CS, 
				_ => throw new ArgumentOutOfRangeException(), 
			}) : (StaffType.Instance._type switch
			{
				StaffDefinition.Type.Doctor => ScriptLocalization.Challenges_SubGoals.StaffTrain_Doctor_Goal_CS, 
				StaffDefinition.Type.Nurse => ScriptLocalization.Challenges_SubGoals.StaffTrain_Nurse_Goal_CS, 
				StaffDefinition.Type.Assistant => ScriptLocalization.Challenges_SubGoals.StaffTrain_Assistant_Goal_CS, 
				StaffDefinition.Type.Janitor => ScriptLocalization.Challenges_SubGoals.StaffTrain_Janitor_Goal_CS, 
				_ => throw new ArgumentOutOfRangeException(), 
			})) : ((!QualificationType.NotNull()) ? ScriptLocalization.Challenges_SubGoals.StaffTrain_Goal_CS : ScriptLocalization.Challenges_SubGoals.StaffTrain_Qualification_Goal_CS));
			if (QualificationType.NotNull())
			{
				text = text.Replace("{[QUALIFICATION]}", QualificationType.Instance.NameLocalised.Translation);
			}
			LocalisationParams.Set("COUNT", TargetTrainingCount);
			LocalisationParams.Localise(ref text);
			return text;
		}

		public override bool HasBeenAchieved(Level level)
		{
			return false;
		}
	}
}
