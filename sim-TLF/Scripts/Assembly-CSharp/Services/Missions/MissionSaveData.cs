using System;
using System.Collections.Generic;

namespace Services.Missions
{
	[Serializable]
	public class MissionSaveData
	{
		public List<MissionInstance> ActiveMissions = new List<MissionInstance>();

		public List<MissionInstance> CompletedMissions = new List<MissionInstance>();
	}
}
