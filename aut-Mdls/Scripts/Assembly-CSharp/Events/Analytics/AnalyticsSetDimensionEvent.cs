using UnityEngine;

namespace Events.Analytics
{
	[CreateAssetMenu(menuName = "Events/Analytics/Set Dimension Event", fileName = "AnalyticsSetDimensionEvent", order = 4)]
	public class AnalyticsSetDimensionEvent : BaseEvent<(string key, string value)>
	{
	}
}
