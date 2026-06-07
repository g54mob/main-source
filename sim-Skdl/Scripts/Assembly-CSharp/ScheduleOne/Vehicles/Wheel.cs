using ScheduleOne.Audio;
using ScheduleOne.Core;
using ScheduleOne.Experimental;
using ScheduleOne.Weather;
using UnityEngine;

namespace ScheduleOne.Vehicles
{
	public class Wheel : MonoBehaviour
	{
		public const float SIDEWAY_SLIP_THRESHOLD = 0.2f;

		public const float FORWARD_SLIP_THRESHOLD = 0.8f;

		public const float DRIFT_AUDIO_THRESHOLD = 0.2f;

		public const float MIN_SPEED_FOR_DRIFT = 8f;

		public const float WHEEL_ANIMATION_DISTANCE = 40f;

		public const float HandbrakeFowardStiffnessMultiplier_Front = 0.9f;

		public const float HandbrakeSidewayStiffnessMultiplier_Front = 0.7f;

		public const float HandbrakeFowardStiffnessMultiplier_Rear = 0.9f;

		public const float HandbrakeSidewayStiffnessMultiplier_Rear = 0.3f;

		public bool DEBUG_MODE;

		[Header("References")]
		public Transform wheelModel;

		public Transform modelContainer;

		public WheelCollider wheelCollider;

		public Transform axleConnectionPoint;

		public Collider staticCollider;

		public ParticleSystem DriftParticles;

		[Header("Data")]
		[SerializeField]
		private WheelData _defaultData;

		[SerializeField]
		private WheelOverrideData _rainOverrideData;

		[Header("Settings")]
		public bool DriftParticlesEnabled;

		[Header("Drift Audio")]
		public bool DriftAudioEnabled;

		public AudioSourceController DriftAudioSource;

		private float defaultForwardStiffness;

		private float defaultSidewaysStiffness;

		private LandVehicle vehicle;

		private Vector3 lastFixedUpdatePosition;

		private WheelHit wheelData;

		private WheelFrictionCurve forwardCurve;

		private WheelFrictionCurve sidewaysCurve;

		private VehicleSettings _settings;

		public bool IsDrifting { get; protected set; }

		public bool IsDrifting_Smoothed => false;

		public float DriftTime { get; protected set; }

		public float DriftIntensity { get; protected set; }

		public bool IsSteerWheel { get; set; }

		private void Awake()
		{
		}

		protected virtual void Start()
		{
		}

		public void FixedUpdateWheel()
		{
		}

		public void FakeWheelRotation()
		{
		}

		private void CheckDrifting()
		{
		}

		private void UpdateDriftEffects()
		{
		}

		private void UpdateDriftAudio()
		{
		}

		private void ApplyFriction()
		{
		}

		public virtual void SetPhysicsEnabled(bool enabled)
		{
		}

		public bool IsWheelGrounded()
		{
			return false;
		}

		public void OnWeatherChange(WeatherConditions newConditions)
		{
		}

		[Button]
		private void ApplyDefaultWheelModelPosition()
		{
		}
	}
}
