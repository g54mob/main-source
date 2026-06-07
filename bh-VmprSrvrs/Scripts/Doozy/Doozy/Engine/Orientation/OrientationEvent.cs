using System;
using UnityEngine.Events;

namespace Doozy.Engine.Orientation
{
	[Serializable]
	public class OrientationEvent : UnityEvent<DetectedOrientation>
	{
	}
}
