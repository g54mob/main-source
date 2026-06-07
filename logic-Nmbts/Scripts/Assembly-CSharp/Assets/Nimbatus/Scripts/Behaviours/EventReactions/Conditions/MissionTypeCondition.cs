using System.Collections.Generic;
using Assets.Nimbatus.Scripts.Missions;
using Assets.Nimbatus.Scripts.Persistence;

namespace Assets.Nimbatus.Scripts.Behaviours.EventReactions.Conditions
{
	public class MissionTypeCondition : NimbatusCondition
	{
		public List<EMissionType> MissionTypes = new List<EMissionType>();

		public override bool IsTrue()
		{
			if (SerializableMonobehaviour<MissionManager, MissionData>.Instance.ActiveMission != null)
			{
				return MissionTypes.Contains(SerializableMonobehaviour<MissionManager, MissionData>.Instance.ActiveMission.MissionType);
			}
			return false;
		}
	}
}
