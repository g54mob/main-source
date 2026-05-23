using UnityEngine;

namespace Events.UI
{
	[CreateAssetMenu(menuName = "Events/UI/InfoPanels/UpdateInfoPanelEvent", fileName = "UpdateInfoPanelEvent", order = 0)]
	public class UpdateInfoPanelEvent : BaseEvent<InfoPanelDto>
	{
	}
}
