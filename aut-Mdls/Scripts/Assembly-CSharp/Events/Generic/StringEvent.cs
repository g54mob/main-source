using UnityEngine;

namespace Events.Generic
{
	[CreateAssetMenu(menuName = "Events/Generic/StringEvent", fileName = "StringEvent", order = 0)]
	public class StringEvent : BaseEvent<string>
	{
	}
}
