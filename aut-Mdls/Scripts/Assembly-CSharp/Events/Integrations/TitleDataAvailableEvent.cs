using Integrations.Data;
using UnityEngine;

namespace Events.Integrations
{
	[CreateAssetMenu(menuName = "Events/Integrations/TitleDataAvailableEvent", fileName = "TitleDataAvailableEvent", order = 0)]
	public class TitleDataAvailableEvent : BaseEvent<TitleData>
	{
	}
}
