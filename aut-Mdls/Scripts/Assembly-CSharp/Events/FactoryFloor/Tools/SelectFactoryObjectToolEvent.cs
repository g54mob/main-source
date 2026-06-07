using System;
using System.Collections.Generic;
using UnityEngine;

namespace Events.FactoryFloor.Tools
{
	[CreateAssetMenu(menuName = "Events/Tools/SelectFactoryObjectToolEvent", fileName = "SelectFactoryObjectToolEvent", order = 0)]
	public class SelectFactoryObjectToolEvent : BaseEvent<List<Type>>
	{
	}
}
