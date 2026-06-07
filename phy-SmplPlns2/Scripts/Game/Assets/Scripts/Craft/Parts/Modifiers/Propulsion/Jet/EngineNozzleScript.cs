using UnityEngine;

namespace Assets.Scripts.Craft.Parts.Modifiers.Propulsion.Jet
{
	public class EngineNozzleScript : MonoBehaviour
	{
		[SerializeField]
		private DistortionEffectScript _distortionEffect;

		private EngineCommon _engine;

		private IExhaustSystem _exhaustSystem;

		[SerializeField]
		private Transform _forceNozzleTransform;

		[SerializeField]
		private Transform _gimbalPivot;

		[SerializeField]
		private float _gimbalSpeed;

		private float _maxGimbalAngle;

		private Vector3 _pitchAxis;

		private Vector3 _rollAxis;

		private Quaternion _targetRotation = Quaternion.identity;

		[SerializeField]
		private float _thrustScale = 1f;

		private VariableNozzleAnimationScript _variableNozzleAnimation;

		private Vector3 _yawAxis;

		public bool CanGimbalRoll { get; internal set; }

		public float CurrentThrust { get; private set; }

		public IRigidBody RigidBody { get; set; }

		public float ThrustScale => _thrustScale;

		public void Activate()
		{
			_exhaustSystem?.SetActive(active: true);
			_distortionEffect?.Activate();
		}

		public void Deactivate()
		{
			if (_maxGimbalAngle > 0f && _gimbalPivot != null)
			{
				_gimbalPivot.localRotation = Quaternion.identity;
			}
			_exhaustSystem?.UpdateExhaust(0f, 0f);
			_distortionEffect?.Deactivate();
			CurrentThrust = 0f;
		}

		public void FlightUpdate(float exhaustThrottle, float afterburnerThrottle, float distortion)
		{
			if (_exhaustSystem != null)
			{
				if (_variableNozzleAnimation != null)
				{
					_exhaustSystem.NozzleRadius = _variableNozzleAnimation.NozzleRadius / base.transform.lossyScale.x;
				}
				_exhaustSystem.UpdateExhaust(exhaustThrottle, afterburnerThrottle);
			}
			_distortionEffect?.FlightUpdate(distortion);
		}

		public void Initialize(EngineCommon engine, float gimbalSpeed)
		{
			_engine = engine;
			_maxGimbalAngle = engine.MaxGimbalAngle;
			_gimbalSpeed *= gimbalSpeed;
			if (_forceNozzleTransform == null)
			{
				_forceNozzleTransform = base.transform;
			}
		}

		public void RecalculateGimbalAxes(Transform craftCom)
		{
			if (!(_gimbalPivot == null))
			{
				Vector3 vector = craftCom.InverseTransformPoint(_gimbalPivot.position);
				_pitchAxis = _gimbalPivot.InverseTransformDirection(craftCom.right);
				_yawAxis = _gimbalPivot.InverseTransformDirection(craftCom.up);
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
					_rollAxis = _gimbalPivot.InverseTransformDirection(direction);
				}
				else
				{
					CanGimbalRoll = false;
					_rollAxis = Vector3.zero;
				}
			}
		}

		public void UpdateNozzle(float thrust, bool applyForce)
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
				_gimbalPivot.localRotation = Quaternion.Lerp(_gimbalPivot.localRotation, _targetRotation, _gimbalSpeed * num);
			}
			if (thrust != 0f && _thrustScale > 0f)
			{
				CurrentThrust = thrust * _thrustScale;
				Vector3 force = _forceNozzleTransform.up * CurrentThrust;
				if (applyForce)
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
			_exhaustSystem = GetComponentInChildren<IExhaustSystem>(includeInactive: true);
			_variableNozzleAnimation = GetComponentInChildren<VariableNozzleAnimationScript>();
			_distortionEffect?.Initialize();
		}
	}
}
