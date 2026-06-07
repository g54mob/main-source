using Presentation.UI.Menus.MenuEvents.MenuData;
using UnityEngine;

namespace Events.UI.Overlays
{
	[CreateAssetMenu(menuName = "Events/UI/Overlays/ShowMenuModalDialogEvent", fileName = "ShowMenuModalDialogEvent", order = 0)]
	public class ShowMenuModalDialogEvent : BaseEvent<AbstractUIModalDialogData>
	{
	}
}
