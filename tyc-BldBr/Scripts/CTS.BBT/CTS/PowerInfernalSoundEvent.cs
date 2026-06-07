using System;
using UnityEngine;

namespace CTS
{
	public class PowerInfernalSoundEvent : MonoBehaviour
	{
		public static event Action LaunchSound;

		public void LaunchInfernalSoundEvent()
		{
			Debug.Log("Launch");
			PowerInfernalSoundEvent.LaunchSound?.Invoke();
		}
	}
}
