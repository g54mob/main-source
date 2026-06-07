using UnityEngine;

namespace ScheduleOne.Weather
{
	public class DayNightController : MonoBehaviour
	{
		private const float SunShadowStrength = 0.95f;

		private const float MoonShadowStrength = 0.8f;

		[SerializeField]
		[Header("Components")]
		private GameObject _lightPivot;

		[SerializeField]
		private MeshRenderer _skyRenderer;

		[Header("Lights")]
		[SerializeField]
		private Light _sunLight;

		[SerializeField]
		private Light _moonLight;

		[SerializeField]
		private Light _ambientLight;

		[SerializeField]
		private AnimationCurve _fadeInCurve;

		[SerializeField]
		private AnimationCurve _fadeOutCurve;

		[SerializeField]
		[Header("Debugging & Development")]
		private float _debugRotationSpeed;

		[SerializeField]
		private float _debugTimeSpeed;

		[SerializeField]
		private bool _enableDebugTimeControl;

		[SerializeField]
		private bool _debugAutoUpdateTime;

		[SerializeField]
		[Range(0f, 24f)]
		private float _timeInHours;

		private float _timePercentage;

		private bool _isDay;

		private Quaternion _currentSunRotation;

		private Quaternion _currentMoonRotation;

		[SerializeField]
		private DayNightPhaseTimes _dayNightPhaseTimes;

		public const float MAX_LIGHT_INTENSITY = 4f;

		public bool EnableDebugTimeControl => false;

		private void Update()
		{
		}

		public SkyState EvaluateSky(SkySettings activeSettings, SkySettings neighbourSettings, float blend, SkySettings overrideSkySettings = null, float overrideBlend = 0f)
		{
			return null;
		}

		private SkyState EvaluateSky(SkyState state, SkySettings activeSettings, SkySettings neighbourSettings, float blend, float timeInTwentyFourHour, float timePercentage)
		{
			return null;
		}

		private SkyState BlendSky(SkyState from, SkyState to, float blend)
		{
			return null;
		}

		public float EvaluateFloatByTimeOfDay(DynamicGradient gradient)
		{
			return 0f;
		}

		public Color EvaluateColorByTimeOfDay(DynamicGradient gradient)
		{
			return default(Color);
		}

		private void UpdateSky(SkyState skyState)
		{
		}

		private void SetLights(bool isDay)
		{
		}

		private void UpdateRotation()
		{
		}

		private void SnapRotation()
		{
		}

		public void SetRotation()
		{
		}

		public void UpdateTime(float normalisedTime)
		{
		}

		public void OnTick()
		{
		}

		public void OnTimeSet(float normalisedTime)
		{
		}

		private bool IsDay(float timeInTwentyFourHour)
		{
			return false;
		}
	}
}
