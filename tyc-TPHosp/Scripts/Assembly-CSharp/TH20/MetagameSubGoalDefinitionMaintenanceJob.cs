using System;
using I2.Loc;

namespace TH20
{
	public class MetagameSubGoalDefinitionMaintenanceJob : SubGoalDefinition
	{
		public int NumOfJobs;

		public JobMaintenance.JobDescription JobType;

		public override ObjectiveSubGoal CreateSubGoal(Objective owner)
		{
			return new MetagameSubGoalMaintenanceJob(owner, this);
		}

		public override string GoalText(Objective objective)
		{
			string text = JobType switch
			{
				JobMaintenance.JobDescription.BrokenMachine => ScriptLocalization.Challenges_SubGoals.CompleteMaintenance_Machine_Goal_CS, 
				JobMaintenance.JobDescription.BlockedToilet => ScriptLocalization.Challenges_SubGoals.CompleteMaintenance_Toilet_Goal_CS, 
				JobMaintenance.JobDescription.OutOfStock => ScriptLocalization.Challenges_SubGoals.CompleteMaintenance_Stock_Goal_CS, 
				JobMaintenance.JobDescription.WiltedPlant => ScriptLocalization.Challenges_SubGoals.CompleteMaintenance_Plant_Goal_CS, 
				JobMaintenance.JobDescription.Litter => ScriptLocalization.Challenges_SubGoals.CompleteMaintenance_Litter_Goal_CS, 
				JobMaintenance.JobDescription.MedicalWaste => ScriptLocalization.Challenges_SubGoals.CompleteMaintenance_Waste_Goal_CS, 
				JobMaintenance.JobDescription.Ghost => ScriptLocalization.Challenges_SubGoals.CompleteMaintenance_Ghost_Goal_CS, 
				_ => throw new ArgumentOutOfRangeException(), 
			};
			LocalisationParams.Set("COUNT", NumOfJobs);
			LocalisationParams.Localise(ref text);
			return text;
		}

		public override bool HasBeenAchieved(Level level)
		{
			return false;
		}
	}
}
