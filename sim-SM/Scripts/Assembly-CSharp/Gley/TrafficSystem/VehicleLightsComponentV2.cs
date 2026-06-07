using Gley.UrbanSystem.Internal;
using UnityEngine;

namespace Gley.TrafficSystem
{
	public class VehicleLightsComponentV2 : MonoBehaviour, IVehicleLightsComponent
	{
		[Tooltip("Blinking interval")]
		public float blinkTime;

		[Tooltip("A GameObject containing all main lights - will be active based on Manager API calls")]
		public GameObject[] frontLights;

		[Tooltip("A GameObject containing all reverse lights - will be active if a vehicle is reversing")]
		public GameObject[] reverseLights;

		[Tooltip("A GameObject containing all rear lights - will be active if main lights are active")]
		public GameObject[] rearLights;

		[Tooltip("A GameObject containing all brake lights - will be active when a vehicle is braking")]
		public GameObject[] stopLights;

		[Tooltip("A GameObject containing all blinker left lights - will be active when car turns left")]
		public GameObject[] blinkerLeft;

		[Tooltip("A GameObject containing all blinker right lights - will be active when car turns right")]
		public GameObject[] blinkerRight;

		private float currentTime;

		private bool updateLights;

		private bool leftBlink;

		private bool rightBlink;

		public void Initialize()
		{
		}

		public void DeactivateLights()
		{
		}

		private void LightsSetup()
		{
		}

		public void SetBrakeLights(bool active)
		{
		}

		public void SetMainLights(bool active)
		{
		}

		public void SetReverseLights(bool active)
		{
		}

		public void SetBlinker(BlinkType blinkType)
		{
		}

		public void UpdateLights(float realtimeSinceStartup)
		{
		}
	}
}
