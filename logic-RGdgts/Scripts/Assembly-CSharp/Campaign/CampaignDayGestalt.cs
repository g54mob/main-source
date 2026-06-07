using NodeCanvas.StateMachines;
using UnityEngine;

namespace Campaign
{
	[CreateAssetMenu]
	public class CampaignDayGestalt : FSM
	{
		public bool morningMail;

		public bool overrideStartTime;

		public DayTime startTime;
	}
}
