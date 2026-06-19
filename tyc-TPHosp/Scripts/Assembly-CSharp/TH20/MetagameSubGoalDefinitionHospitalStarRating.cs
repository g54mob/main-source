using FullInspector;
using I2.Loc;

namespace TH20
{
	public class MetagameSubGoalDefinitionHospitalStarRating : SubGoalDefinition
	{
		public MetagameHospitalRecord.StarIndex Target;

		public SharedInstance<LevelConfig> LevelConfig;

		public override string GoalText(Objective objective)
		{
			string hospitalStarRating_Goal_CS = ScriptLocalization.Challenges_SubGoals.HospitalStarRating_Goal_CS;
			hospitalStarRating_Goal_CS = hospitalStarRating_Goal_CS.Replace("{[LEVEL]}", LevelConfig.Instance.GetLocalisedDisplayName());
			LocalisationParams.Set("COUNT", (int)(Target + 1));
			LocalisationParams.Localise(ref hospitalStarRating_Goal_CS);
			return hospitalStarRating_Goal_CS;
		}

		public override bool HasBeenAchieved(Level level)
		{
			return false;
		}

		public override ObjectiveSubGoal CreateSubGoal(Objective owner)
		{
			return new MetagameSubGoalHospitalStarRating(owner, this);
		}
	}
}
