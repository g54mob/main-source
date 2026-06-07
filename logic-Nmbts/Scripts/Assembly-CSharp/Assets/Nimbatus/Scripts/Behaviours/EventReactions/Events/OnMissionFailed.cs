using Assets.Nimbatus.Scripts.Missions;

namespace Assets.Nimbatus.Scripts.Behaviours.EventReactions.Events
{
	public class OnMissionFailed : NimbatusEvent
	{
		protected override void Subscribe()
		{
			MissionManager.OnMissionFailed += MissionFailed;
		}

		private void MissionFailed(NimbatusMission mission)
		{
			RaiseEvent();
		}

		protected override void Unsubscribe()
		{
			MissionManager.OnMissionFailed -= MissionFailed;
		}
	}
}
