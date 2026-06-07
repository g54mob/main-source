using System.Collections.Generic;
using UnityEngine;

namespace Events.Generic
{
	[CreateAssetMenu(menuName = "Events/Generic/IntListEvent", fileName = "IntListEvent", order = 0)]
	public class IntListEvent : BaseEvent<List<int>>
	{
	}
}
