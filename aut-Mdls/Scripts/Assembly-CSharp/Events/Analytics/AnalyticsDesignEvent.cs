using UnityEngine;

namespace Events.Analytics
{
	[CreateAssetMenu(menuName = "Events/Analytics/Design Event", fileName = "AnalyticsDesignEvent", order = 0)]
	public class AnalyticsDesignEvent : BaseEvent<(string, float)>
	{
	}
}
