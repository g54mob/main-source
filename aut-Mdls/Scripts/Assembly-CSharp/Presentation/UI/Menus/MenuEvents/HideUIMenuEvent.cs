using Events;
using Presentation.UI.Menus.MenuEvents.MenuData;
using UnityEngine;

namespace Presentation.UI.Menus.MenuEvents
{
	[CreateAssetMenu(menuName = "Events/UI/Menu/Hide UI Menu Event", fileName = "HideUIMenuEvent", order = 0)]
	public class HideUIMenuEvent : BaseEvent<AbstractUIMenuData>
	{
	}
}
