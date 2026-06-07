using GameAnalyticsSDK;
using UnityEngine;

namespace Events.Analytics
{
	[CreateAssetMenu(menuName = "Events/Analytics/Progression Timed Event", fileName = "AnalyticsProgressionTimedEvent", order = 3)]
	public class AnalyticsProgressionTimedEvent : BaseEvent<(GAProgressionStatus, string, string, string, int)>
	{
	}
}
