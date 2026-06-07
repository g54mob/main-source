using GameAnalyticsSDK;
using UnityEngine;

namespace Events.Analytics
{
	[CreateAssetMenu(menuName = "Events/Analytics/Resource Event", fileName = "AnalyticsResourceEvent", order = 1)]
	public class AnalyticsResourceEvent : BaseEvent<(GAResourceFlowType, string, string, float, string)>
	{
	}
}
