using System;
using UnityEngine;
using UnityEngine.Events;

namespace GamingIsLove.Footsteps
{
	[Serializable]
	public class FootstepEvent : UnityEvent<Transform, FootstepEffect, Vector3, Vector3>
	{
	}
}
