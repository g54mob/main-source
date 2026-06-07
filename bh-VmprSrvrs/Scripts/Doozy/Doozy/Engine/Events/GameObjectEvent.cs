using System;
using UnityEngine;
using UnityEngine.Events;

namespace Doozy.Engine.Events
{
	[Serializable]
	public class GameObjectEvent : UnityEvent<GameObject>
	{
	}
}
