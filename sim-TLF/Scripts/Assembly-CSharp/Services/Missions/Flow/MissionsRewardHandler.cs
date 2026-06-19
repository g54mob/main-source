namespace Services.Missions.Flow
{
	public class MissionsRewardHandler
	{
		public MissionRewardConfig ReachReward;

		public MissionsRewardHandler()
		{
			ReachReward = new MissionRewardConfig
			{
				Objective = ObjectiveType.Reach,
				MinReward = 15f,
				MaxReward = 45f
			};
		}
	}
}
