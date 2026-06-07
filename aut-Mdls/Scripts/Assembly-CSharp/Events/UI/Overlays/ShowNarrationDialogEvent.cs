using UnityEngine;

namespace Events.UI.Overlays
{
	[CreateAssetMenu(menuName = "Events/UI/Overlays/ShowNarrationDialogEvent", fileName = "ShowNarrationDialogEvent", order = 0)]
	public class ShowNarrationDialogEvent : BaseEvent<NarrationDto>
	{
	}
}
