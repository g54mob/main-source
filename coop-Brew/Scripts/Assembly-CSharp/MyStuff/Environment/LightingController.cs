using UnityEngine;

namespace MyStuff.Environment
{
	public class LightingController : MonoBehaviour
	{
		[Header("References")]
		[Tooltip("Day sun directional light")]
		[SerializeField]
		private Light sunLight;

		[Tooltip("Night moon directional light")]
		[SerializeField]
		private Light moonLight;

		[Header("Configuration")]
		[Tooltip("Settings asset")]
		[SerializeField]
		private TimeOfDaySettings settings;

		[Header("Debug")]
		[Tooltip("Show debug logs")]
		[SerializeField]
		private bool showDebugLogs;

		private Transform sunTransform;

		private Transform moonTransform;

		private Behaviour _sunLensFlare;

		private bool _lensFlareSearched;

		private const float HORIZON_FADE_ANGLE = 5f;

		public Light SunLight => null;

		public Light MoonLight => null;

		private void Awake()
		{
		}

		private void FindSunLensFlare()
		{
		}

		public void AssignLights(Light sun, Light moon)
		{
		}

		public void AssignSettings(TimeOfDaySettings newSettings)
		{
		}

		public void UpdateLighting(float normalizedTime)
		{
		}

		private void UpdateSunLight(float normalizedTime)
		{
		}

		private void UpdateMoonLight(float normalizedTime)
		{
		}
	}
}
