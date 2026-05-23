using UnityEngine;

namespace Events.UI
{
	[CreateAssetMenu(menuName = "Events/UI/SetCursorTextEvent", fileName = "SetCursorTextEvent", order = 0)]
	public class SetCursorTextEvent : BaseEvent<string>
	{
	}
}
