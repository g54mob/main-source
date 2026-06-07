using Events;
using Presentation.UI.Menus.HudPanelTabGroups;
using UnityEngine;

namespace Presentation.UI.Menus.MenuEvents
{
	[CreateAssetMenu(menuName = "Events/UI/ShowHudPanelEvent", fileName = "ShowHudPanelEvent", order = 0)]
	public class ShowHudPanelEvent : BaseEvent<AbstractHudPanelData>
	{
	}
}
