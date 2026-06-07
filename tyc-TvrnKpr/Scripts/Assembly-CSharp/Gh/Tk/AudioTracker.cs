using System.Collections.Generic;
using UnityEngine;

namespace Gh.Tk
{
	public class AudioTracker : MonoBehaviour
	{
		private const float _updateInterval = 0.2f;

		private float _lastUpdate;

		public AnimationCurve captureRadius;

		[Tooltip("X is the distance from Sphere (0 being in the sphere, 1 being a radius away. Y is the score when at that distance")]
		public AnimationCurve emitterFactor;

		public CameraRigBase attachedCameraRig;

		private static Dictionary<string, float> _previousRtpcValues;

		private static SoundEngineStateControl _happinessStateControl;

		[DropDownChoice(new string[] { "None", "Angry", "Neutral", "Happy" })]
		public string debug_HappinessOverride;

		public bool enableDebugInfo;

		public Dictionary<string, float> Debug_RaceGenderCounts { get; private set; }

		public float Debug_ScreenPopulation { get; private set; }

		public string Debug_HappinessLevel { get; private set; }

		private void Update()
		{
		}

		private float GetCaptureRadius()
		{
			return 0f;
		}

		private float GetCaptureRadiusMultiplier(Transform point)
		{
			return 0f;
		}

		public static void Reset()
		{
		}

		private void UpdateTaproomAmbience()
		{
		}

		private void OnGUI()
		{
		}

		private void OnDrawGizmos()
		{
		}
	}
}
