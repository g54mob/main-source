using Events;
using Presentation.UI.Menus.HudPanelTabGroups;
using UnityEngine;

namespace Presentation.UI.Menus.MenuEvents
{
	[CreateAssetMenu(menuName = "Events/UI/HideHudPanelEvent", fileName = "HideHudPanelEvent", order = 0)]
	public class HideHudPanelEvent : BaseEvent<TabGroupPanelSO>
	{
	}
}
