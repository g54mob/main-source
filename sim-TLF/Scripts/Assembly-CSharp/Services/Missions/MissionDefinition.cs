using System;
using System.Collections.Generic;

namespace Services.Missions
{
	[Serializable]
	public class MissionDefinition
	{
		public string MissionId;

		public string Title;

		public string Description;

		public List<ObjectiveDefinition> Objectives = new List<ObjectiveDefinition>();

		public List<string> Prerequisites = new List<string>();

		public MissionReward Reward = new MissionReward();
	}
}
