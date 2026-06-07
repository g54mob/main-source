using Events;
using Presentation.UI.Menus.MenuEvents.MenuData;
using UnityEngine;

namespace Presentation.UI.Menus.MenuEvents
{
	[CreateAssetMenu(menuName = "Events/UI/Menu/Show UI Menu Event", fileName = "ShowUIMenuEvent", order = 0)]
	public class ShowUIMenuEvent : BaseEvent<AbstractUIMenuData>
	{
	}
}
