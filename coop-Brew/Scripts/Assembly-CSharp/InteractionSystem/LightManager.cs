using System.Collections.Generic;
using UnityEngine;

namespace InteractionSystem
{
	[DefaultExecutionOrder(-100)]
	public class LightManager : MonoBehaviour
	{
		[Header("Auto Turn-Off Settings")]
		[Tooltip("Hour at which all lights automatically turn off (0-23)")]
		[Range(0f, 23f)]
		[SerializeField]
		private int turnOffHour;

		[Tooltip("Minute at which all lights automatically turn off (0-59)")]
		[Range(0f, 59f)]
		[SerializeField]
		private int turnOffMinute;

		[Header("Debug")]
		[SerializeField]
		private bool showDebugLogs;

		private HashSet<LightSwitchInteractable> registeredLights;

		private float previousNormalizedTime;

		private float turnOffNormalizedTime;

		private int lastTurnOffDay;

		public static LightManager Instance { get; private set; }

		public int RegisteredLightCount => 0;

		public int LightsOnCount => 0;

		private void Awake()
		{
		}

		private void Start()
		{
		}

		private void Update()
		{
		}

		private void OnDestroy()
		{
		}

		public void RegisterLight(LightSwitchInteractable light)
		{
		}

		public void UnregisterLight(LightSwitchInteractable light)
		{
		}

		private void CheckAutoTurnOff()
		{
		}

		private bool WasTimeCrossed(float previous, float current, float target)
		{
			return false;
		}

		public void TurnOffAllLights()
		{
		}

		public void TurnOnAllLights()
		{
		}

		[ContextMenu("Turn Off All Lights")]
		private void DebugTurnOffAllLights()
		{
		}

		[ContextMenu("Turn On All Lights")]
		private void DebugTurnOnAllLights()
		{
		}
	}
}
