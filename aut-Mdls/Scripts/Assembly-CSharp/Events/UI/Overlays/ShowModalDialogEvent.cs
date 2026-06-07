using Presentation.UI.Menus.MenuEvents.MenuData;
using UnityEngine;

namespace Events.UI.Overlays
{
	[CreateAssetMenu(menuName = "Events/UI/Overlays/ShowModalDialogEvent", fileName = "ShowModalDialogEvent", order = 0)]
	public class ShowModalDialogEvent : BaseEvent<AbstractUIModalDialogData>
	{
	}
}
