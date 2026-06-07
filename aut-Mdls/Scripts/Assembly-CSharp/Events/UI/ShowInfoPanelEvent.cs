using UnityEngine;

namespace Events.UI
{
	[CreateAssetMenu(menuName = "Events/UI/InfoPanels/ShowInfoPanelEvent", fileName = "ShowInfoPanelEvent", order = 0)]
	public class ShowInfoPanelEvent : BaseEvent<InfoPanelDto>
	{
	}
}
