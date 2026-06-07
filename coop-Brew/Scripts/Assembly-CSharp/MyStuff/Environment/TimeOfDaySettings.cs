using System.Collections.Generic;
using UnityEngine;

namespace MyStuff.Environment
{
	[CreateAssetMenu(fileName = "TimeOfDaySettings", menuName = "Environment/Time of Day Settings", order = 1)]
	public class TimeOfDaySettings : ScriptableObject
	{
		[Header("=== General Settings ===")]
		[Tooltip("Length of a full in-game day in real-world seconds (default: 1200 = 20 minutes)")]
		[SerializeField]
		private float dayLengthInRealSeconds;

		[Tooltip("Initial hour when the system starts (0-23)")]
		[SerializeField]
		[Range(0f, 23f)]
		private int initialClockHour;

		[Tooltip("Initial minute when the system starts (0-59)")]
		[SerializeField]
		[Range(0f, 59f)]
		private int initialClockMinute;

		[Tooltip("Time scale multiplier (1.0 = normal speed, 2.0 = double speed)")]
		[SerializeField]
		[Range(0f, 10f)]
		private float timeScale;

		[Tooltip("Start with time paused?")]
		[SerializeField]
		private bool startPaused;

		[Header("=== Time Thresholds (0-1 Normalized) ===")]
		[Tooltip("When dawn phase begins (default: 0.25 = 06:00) - extended for longer night")]
		[SerializeField]
		[Range(0f, 1f)]
		private float dawnStartT01;

		[Tooltip("When sunrise occurs (default: 0.27 = 06:30) - sun fully risen")]
		[SerializeField]
		[Range(0f, 1f)]
		private float sunriseT01;

		[Tooltip("When sunset occurs (default: 0.75 = 18:00)")]
		[SerializeField]
		[Range(0f, 1f)]
		private float sunsetT01;

		[Tooltip("When dusk phase ends (default: 0.80 = 19:12)")]
		[SerializeField]
		[Range(0f, 1f)]
		private float duskEndT01;

		[Header("=== Light Intensity Curves ===")]
		[Tooltip("Sun elevation angle over the day (-90 to +90 degrees). 0 = horizon, 90 = zenith")]
		[SerializeField]
		private AnimationCurve sunElevationCurve;

		[Tooltip("Sun azimuth angle over the day (0-360 degrees, optional rotation)")]
		[SerializeField]
		private AnimationCurve sunAzimuthCurve;

		[Tooltip("Sun directional light intensity over the day (0-2)")]
		[SerializeField]
		private AnimationCurve sunIntensityCurve;

		[Tooltip("Moon directional light intensity over the day (0-2)")]
		[SerializeField]
		private AnimationCurve moonIntensityCurve;

		[Tooltip("Ambient light intensity multiplier over the day (0-2)")]
		[SerializeField]
		private AnimationCurve ambientIntensityCurve;

		[Header("=== Atmosphere Curves ===")]
		[Tooltip("Fog density over the day (0-0.1 typical)")]
		[SerializeField]
		private AnimationCurve fogDensityCurve;

		[Tooltip("Skybox exposure value over the day (0-2, for procedural skybox)")]
		[SerializeField]
		private AnimationCurve skyboxExposureCurve;

		[Header("=== Color Gradients ===")]
		[Tooltip("Sun color over the day")]
		[SerializeField]
		private Gradient sunColorGradient;

		[Tooltip("Moon color over the day")]
		[SerializeField]
		private Gradient moonColorGradient;

		[Tooltip("Ambient light color over the day")]
		[SerializeField]
		private Gradient ambientColorGradient;

		[Tooltip("Fog color over the day")]
		[SerializeField]
		private Gradient fogColorGradient;

		[Tooltip("Skybox sky tint color over the day (for procedural skybox)")]
		[SerializeField]
		private Gradient skyTintGradient;

		[Tooltip("Skybox ground color over the day (for procedural skybox)")]
		[SerializeField]
		private Gradient groundColorGradient;

		[Header("=== Light Configuration ===")]
		[Tooltip("Optional reference to day sun directional light (auto-created if null)")]
		[SerializeField]
		private Light daySunLight;

		[Tooltip("Optional reference to night moon directional light (auto-created if null)")]
		[SerializeField]
		private Light nightMoonLight;

		[Tooltip("Shadow strength for day sun (0-1)")]
		[SerializeField]
		[Range(0f, 1f)]
		private float dayShadowStrength;

		[Tooltip("Shadow strength for night moon (0-1)")]
		[SerializeField]
		[Range(0f, 1f)]
		private float nightShadowStrength;

		[Tooltip("Toggle shadows off when light is not in active phase (performance)")]
		[SerializeField]
		private bool toggleShadowsOutsidePhase;

		[Tooltip("Minimum intensity before light is considered inactive")]
		[SerializeField]
		private float minIntensityThreshold;

		[Tooltip("Maximum intensity clamp for day sun")]
		[SerializeField]
		private float maxSunIntensity;

		[Tooltip("Maximum intensity clamp for night moon")]
		[SerializeField]
		private float maxMoonIntensity;

		[Header("=== Atmosphere Configuration ===")]
		[Tooltip("Enable fog updates")]
		[SerializeField]
		private bool enableFog;

		[Tooltip("Update ambient lighting")]
		[SerializeField]
		private bool updateAmbient;

		[Tooltip("Update skybox parameters (requires compatible material)")]
		[SerializeField]
		private bool updateSkybox;

		[Tooltip("Update reflection probes at phase transitions (expensive)")]
		[SerializeField]
		private bool updateReflectionProbes;

		[Tooltip("Atmosphere update rate in Hz (lower = better performance)")]
		[SerializeField]
		[Range(1f, 60f)]
		private float atmosphereUpdateRateHz;

		[Header("=== Networking Configuration ===")]
		[Tooltip("Network sync rate in Hz (lower = less bandwidth)")]
		[SerializeField]
		[Range(1f, 30f)]
		private float networkSendRateHz;

		[Tooltip("Client smoothing time for time synchronization (seconds)")]
		[SerializeField]
		[Range(0.1f, 2f)]
		private float clientSmoothingTime;

		[Tooltip("Enable catch-up for late joiners")]
		[SerializeField]
		private bool catchUpOnJoin;

		[Tooltip("Maximum catch-up speed multiplier")]
		[SerializeField]
		[Range(1f, 20f)]
		private float maxCatchUpSpeed;

		[Header("=== Editor Preview ===")]
		[Tooltip("Enable preview mode in editor (updates lighting in edit mode)")]
		[SerializeField]
		private bool previewInEditor;

		[Tooltip("Preview time slider (0-1 over 24 hours)")]
		[SerializeField]
		[Range(0f, 1f)]
		private float previewTime;

		[Header("=== Scheduled Events ===")]
		[Tooltip("List of time-triggered events")]
		[SerializeField]
		private List<TimeEvent> scheduledEvents;

		public float DayLengthInRealSeconds => 0f;

		public int InitialClockHour => 0;

		public int InitialClockMinute => 0;

		public float TimeScale => 0f;

		public bool StartPaused => false;

		public float DawnStartT01 => 0f;

		public float SunriseT01 => 0f;

		public float SunsetT01 => 0f;

		public float DuskEndT01 => 0f;

		public AnimationCurve SunElevationCurve => null;

		public AnimationCurve SunAzimuthCurve => null;

		public AnimationCurve SunIntensityCurve => null;

		public AnimationCurve MoonIntensityCurve => null;

		public AnimationCurve AmbientIntensityCurve => null;

		public AnimationCurve FogDensityCurve => null;

		public AnimationCurve SkyboxExposureCurve => null;

		public Gradient SunColorGradient => null;

		public Gradient MoonColorGradient => null;

		public Gradient AmbientColorGradient => null;

		public Gradient FogColorGradient => null;

		public Gradient SkyTintGradient => null;

		public Gradient GroundColorGradient => null;

		public Light DaySunLight
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public Light NightMoonLight
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public float DayShadowStrength => 0f;

		public float NightShadowStrength => 0f;

		public bool ToggleShadowsOutsidePhase => false;

		public float MinIntensityThreshold => 0f;

		public float MaxSunIntensity => 0f;

		public float MaxMoonIntensity => 0f;

		public bool EnableFog => false;

		public bool UpdateAmbient => false;

		public bool UpdateSkybox => false;

		public bool UpdateReflectionProbes => false;

		public float AtmosphereUpdateRateHz => 0f;

		public float NetworkSendRateHz => 0f;

		public float ClientSmoothingTime => 0f;

		public bool CatchUpOnJoin => false;

		public float MaxCatchUpSpeed => 0f;

		public bool PreviewInEditor => false;

		public float PreviewTime
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public List<TimeEvent> ScheduledEvents => null;

		public bool ValidateThresholds(out string error)
		{
			error = null;
			return false;
		}

		public TimePhase GetPhaseAtTime(float normalizedTime)
		{
			return default(TimePhase);
		}

		public void NormalizedTimeToClockTime(float normalizedTime, out int hours, out int minutes)
		{
			hours = default(int);
			minutes = default(int);
		}

		public float ClockTimeToNormalizedTime(int hours, int minutes)
		{
			return 0f;
		}

		private void OnValidate()
		{
		}

		private void InitializeDefaultCurves()
		{
		}

		private void InitializeDefaultGradients()
		{
		}
	}
}
