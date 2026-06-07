using System;
using UnityEngine;
using UnityEngine.Events;

namespace DV.CabControls.VRTK
{
	[Serializable]
	public class SwipeEvent : UnityEvent<Vector3, bool>
	{
	}
}
