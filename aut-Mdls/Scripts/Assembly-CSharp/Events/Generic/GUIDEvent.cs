using System;
using UnityEngine;

namespace Events.Generic
{
	[CreateAssetMenu(menuName = "Events/Generic/GUIDEvent", fileName = "GUIDEvent", order = 0)]
	public class GUIDEvent : BaseEvent<Guid>
	{
	}
}
