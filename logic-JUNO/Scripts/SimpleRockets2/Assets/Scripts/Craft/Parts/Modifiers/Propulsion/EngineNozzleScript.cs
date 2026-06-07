using Assets.Scripts.Flight.Sim;
using ModApi;
using ModApi.Flight;
using UnityEngine;

namespace Assets.Scripts.Craft.Parts.Modifiers.Propulsion
{
	public class EngineNozzleScript : MonoBehaviour
	{
		private bool _activated;

		[SerializeField]
		private DistortionEffectScript _distortionEffect;

		private float _distortionStartLifetime;

		private EngineCommon _engine;

		private IExhaustSystem _exhaustSystem;

		private Transform _forceNozzleTransform;

		private float _maxGimbalAngle;

		private float _maxThrust;

		private Vector3 _pitchAxis;

		private Vector3 _rollAxis;

		[SerializeField]
		private SmokeTrailScript _smokeTrail;

		private Quaternion _targetRotation = Quaternion.identity;

		[SerializeField]
		private float _thrustScale = 1f;

		private Transform _visualNozzleTransform;

		private Vector3 _yawAxis;

		public bool CanGimbalRoll { get; internal set; }

		public float CurrentThrust { get; private set; }

		public float GimbalSpeed { get; set; } = 1f;

		public Rigidbody RigidBody { get; set; }

		public float ThrustScale => _thrustScale;

		public void Activate()
		{
			_activated = true;
			_exhaustSystem?.SetActive(active: true);
			_distortionEffect?.Activate();
			_exhaustSystem?.UpdateExhaust(0f);
			_smokeTrail?.gameObject.SetActive(value: true);
		}

		public void Deactivate()
		{
			_activated = false;
			if (_maxGimbalAngle > 0f)
			{
				_forceNozzleTransform.localRotation = Quaternion.identity;
				_visualNozzleTransform.localRotation = Quaternion.identity;
			}
			_exhaustSystem?.UpdateExhaust(0f);
			_distortionEffect?.Deactivate();
			if (_smokeTrail != null)
			{
				_smokeTrail.EmissionEnabled = false;
			}
			CurrentThrust = 0f;
		}

		public void DisableSmokeParticleSystem()
		{
			_smokeTrail?.gameObject.SetActive(value: false);
		}

		public void FlightUpdate(float exhaustThrottle, float distortion, Vector3 surfaceVelocity, float smokeOpacity, float light, float expansionSize)
		{
			if (_smokeTrail != null)
			{
				_smokeTrail.EmissionEnabled = exhaustThrottle > 0f;
				_smokeTrail.Light = light;
				_smokeTrail.EmissionOpacity = smokeOpacity;
				_smokeTrail.Intensity = 0.5f * (exhaustThrottle + 1f);
				_smokeTrail.ExpansionSize = expansionSize;
				_smokeTrail.FlightUpdate(surfaceVelocity);
			}
			_exhaustSystem?.UpdateExhaust(exhaustThrottle);
			_distortionEffect?.FlightUpdate(distortion);
			if (_maxGimbalAngle > 0f)
			{
				_visualNozzleTransform.localRotation = _forceNozzleTransform.localRotation;
			}
		}

		public void Initialize(EngineCommon engine)
		{
			_engine = engine;
			_visualNozzleTransform = base.transform;
			_maxGimbalAngle = engine.MaxGimbalAngle;
			_forceNozzleTransform = new GameObject(base.gameObject.name + "-ForceTransform").transform;
			_forceNozzleTransform.SetParent(base.transform.parent, worldPositionStays: false);
			_forceNozzleTransform.SetLocalPositionAndRotation(base.transform.localPosition, base.transform.localRotation);
		}

		public void OnTimeMultiplierModeChanged(TimeMultiplierModeChangedEvent e)
		{
			if (e.EnteredWarpMode)
			{
				_smokeTrail?.gameObject.SetActive(value: false);
				_distortionEffect?.Deactivate();
			}
			else if (_activated)
			{
				_smokeTrail?.gameObject.SetActive(value: true);
				_distortionEffect?.Activate();
			}
		}

		public void RecalculateGimbalAxes(Transform craftCom)
		{
			Vector3 vector = craftCom.InverseTransformPoint(_visualNozzleTransform.position);
			_pitchAxis = _visualNozzleTransform.InverseTransformDirection(craftCom.right);
			_yawAxis = _visualNozzleTransform.InverseTransformDirection(craftCom.up);
			if (vector.z < 0f)
			{
				_pitchAxis *= -1f;
				_yawAxis *= -1f;
			}
			vector.z = 0f;
			if (vector.magnitude > 0.1f)
			{
				CanGimbalRoll = true;
				Vector3 direction = craftCom.TransformDirection(vector.normalized);
				_rollAxis = _visualNozzleTransform.InverseTransformDirection(direction);
			}
			else
			{
				CanGimbalRoll = false;
				_rollAxis = Vector3.zero;
			}
		}

		public void UpdateNozzle(float thrust, CraftNode craftNode)
		{
			if (_maxGimbalAngle > 0f)
			{
				Quaternion quaternion = Quaternion.AngleAxis(_engine.Yaw * _maxGimbalAngle, _yawAxis);
				Quaternion quaternion2 = Quaternion.AngleAxis(_engine.Pitch * _maxGimbalAngle, _pitchAxis);
				if (CanGimbalRoll)
				{
					Quaternion quaternion3 = Quaternion.AngleAxis(_engine.Roll * _maxGimbalAngle, _rollAxis);
					_targetRotation = quaternion * quaternion2 * quaternion3;
				}
				else
				{
					_targetRotation = quaternion * quaternion2;
				}
				float num = Mathf.Clamp(Time.deltaTime, 0f, 0.05f);
				_forceNozzleTransform.localRotation = Quaternion.Lerp(_forceNozzleTransform.localRotation, _targetRotation, GimbalSpeed * num);
			}
			if (thrust != 0f && _thrustScale > 0f)
			{
				CurrentThrust = thrust * _thrustScale;
				Vector3 force = _forceNozzleTransform.up * CurrentThrust;
				if (craftNode != null)
				{
					craftNode.AddTimeWarpForce(force);
				}
				else
				{
					RigidBody.AddForceAtPosition(force, _forceNozzleTransform.position);
				}
			}
			else
			{
				CurrentThrust = 0f;
			}
		}

		protected virtual void Awake()
		{
			_exhaustSystem = GetComponentInChildren<IExhaustSystem>();
			if (_exhaustSystem != null)
			{
				Utilities.SetLayerRecursive(_exhaustSystem.GameObject, 0);
			}
			_distortionEffect?.Initialize();
		}
	}
}
