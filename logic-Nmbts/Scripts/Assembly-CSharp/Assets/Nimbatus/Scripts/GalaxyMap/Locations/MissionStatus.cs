using System;
using Assets.Nimbatus.Scripts.Missions;

namespace Assets.Nimbatus.Scripts.GalaxyMap.Locations
{
	[Serializable]
	public class MissionStatus
	{
		public EMissionType Mission;

		public bool Completed;

		public MissionStatus()
		{
		}

		public MissionStatus(EMissionType mission)
		{
			Mission = mission;
			Completed = false;
		}
	}
}
