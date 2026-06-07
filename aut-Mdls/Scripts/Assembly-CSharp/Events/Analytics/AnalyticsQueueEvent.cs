using System.Collections.Generic;
using UnityEngine;

namespace Events.Analytics
{
	[CreateAssetMenu(menuName = "Events/Analytics/Queue Event", fileName = "AnalyticsQueueEvent", order = 0)]
	public class AnalyticsQueueEvent : BaseEvent<List<(string, float)>>
	{
	}
}
