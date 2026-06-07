using System;
using UnityEngine;
using UnityEngine.Events;

namespace MalbersAnimations.Events
{
	[Serializable]
	public class ComponentEvent : UnityEvent<Component>
	{
	}
}
