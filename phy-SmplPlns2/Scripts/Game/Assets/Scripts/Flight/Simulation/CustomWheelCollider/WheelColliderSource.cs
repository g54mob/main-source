using System;
using Assets.Scripts.Craft;
using UnityEngine;

namespace Assets.Scripts.Flight.Simulation.CustomWheelCollider
{
	public class WheelColliderSource : MonoBehaviour
	{
		public Transform SuspensionTransform;

		public Transform WheelMesh;

		public float WheelRadius = 0.25f;

		private Vector3 _center;

		private Transform _dummyWheel;

		private WheelFrictionCurveSource _forwardFriction;

		private float _forwardSlip;

		private Color _gizmoColor = Color.green;

		private Vector3 _groundVelocity;

		private bool _isGrounded;

		private float _maxSpringForce;

		private Joint _parkingBrake;

		private Vector3 _prevPosition;

		private RaycastHit _raycastHit;

		private IRigidBody _rigidbody;

		private WheelFrictionCurveSource _sidewaysFriction;

		private float _sidewaysSlip;

		private float _speedOverGround;

		private float _surfaceFriction;

		private Vector3 _surfaceNormal;

		private float _suspensionCompression;

		private float _suspensionCompressionPrev;

		private float _suspensionDistance;

		private JointSpringSource _suspensionSpring;

		private Vector3 _totalForce;

		private bool _wasGrounded;

		private float _wheelAngularVelocity;

		private float _wheelBrakeTorque;

		private float _wheelMass;

		private float _wheelMotorTorque;

		private float _wheelRotationAngle;

		private float _wheelSteerAngle;

		public float BrakeInput { get; set; }

		public float BrakeTorque { get; set; }

		public Vector3 Center
		{
			get
			{
				return _center;
			}
			set
			{
				_center = value;
				_dummyWheel.localPosition = base.transform.localPosition + _center;
				_prevPosition = _dummyWheel.localPosition;
			}
		}

		public WheelFrictionCurveSource ForwardFriction
		{
			get
			{
				return _forwardFriction;
			}
			set
			{
				_forwardFriction = value;
			}
		}

		public float ForwardSlip => _forwardSlip;

		public bool IsGrounded => _isGrounded;

		public float Mass
		{
			get
			{
				return _wheelMass;
			}
			set
			{
				_wheelMass = Mathf.Max(value, 0.0001f);
			}
		}

		public float MotorTorque
		{
			get
			{
				return _wheelMotorTorque;
			}
			set
			{
				_wheelMotorTorque = value;
			}
		}

		public IRigidBody Rigidbody
		{
			get
			{
				return _rigidbody;
			}
			set
			{
				_rigidbody = value;
			}
		}

		public float RPM => _wheelAngularVelocity * MathF.PI / 180f;

		public float Scale { get; set; }

		public WheelFrictionCurveSource SidewaysFriction
		{
			get
			{
				return _sidewaysFriction;
			}
			set
			{
				_sidewaysFriction = value;
			}
		}

		public float SidewaysSlip => _sidewaysSlip;

		public float SpeedOverGround
		{
			get
			{
				if (!_isGrounded)
				{
					return 0f;
				}
				return _speedOverGround;
			}
		}

		public float SteerAngle
		{
			get
			{
				return _wheelSteerAngle;
			}
			set
			{
				_wheelSteerAngle = value;
			}
		}

		public float SurfaceFriction => _surfaceFriction;

		public float SuspensionDistance
		{
			get
			{
				return _suspensionDistance;
			}
			set
			{
				_suspensionDistance = value;
				Center = new Vector3(0f, _suspensionDistance / Scale, 0f);
			}
		}

		public bool SuspensionEnabled { get; set; }

		public JointSpringSource SuspensionSpring
		{
			get
			{
				return _suspensionSpring;
			}
			set
			{
				_suspensionSpring = value;
				_maxSpringForce = _suspensionSpring.Spring * 0.5f;
			}
		}

		public event Action<float> OnFastTouchdown;

		public void CreateFrictionCurves(float forwardExtremumSlip, float forwardExtremumForce, float forwardAsymptoteSlip, float forwardAsymptoteForce, float sidewaysExtremumSlip, float sidewaysExtremumForce, float sidewaysAsymptoteSlip, float sidewaysAsymptoteForce)
		{
			_forwardFriction = new WheelFrictionCurveSource(forwardExtremumSlip, forwardExtremumForce, forwardAsymptoteSlip, forwardAsymptoteForce);
			_sidewaysFriction = new WheelFrictionCurveSource(sidewaysExtremumSlip, sidewaysExtremumForce, sidewaysAsymptoteSlip, sidewaysAsymptoteForce);
		}

		public void DisableParkingBrake()
		{
			if (_parkingBrake != null)
			{
				UnityEngine.Object.Destroy(_parkingBrake);
			}
			_parkingBrake = null;
		}

		protected virtual void Awake()
		{
			Scale = 1f;
			_dummyWheel = new GameObject("DummyWheel").transform;
			_dummyWheel.transform.parent = base.transform.parent;
			_dummyWheel.transform.localEulerAngles = Vector3.zero;
			_dummyWheel.transform.localPosition = Vector3.zero;
			Center = Vector3.zero;
			_suspensionDistance = 0f;
			_suspensionCompression = 0f;
			Mass = 0.01f;
			BrakeInput = 0f;
			SuspensionEnabled = true;
			_surfaceFriction = 1f;
			_suspensionSpring = default(JointSpringSource);
		}

		protected virtual void FixedUpdate()
		{
			if (PauseManager.Paused)
			{
				return;
			}
			IRigidBody rigidbody = Rigidbody;
			if (rigidbody == null || rigidbody.Type != RigidBodyType.Local)
			{
				return;
			}
			UpdateSuspension();
			UpdateWheel();
			if (_isGrounded)
			{
				CalculateSlips();
				CalculateLandingImpact();
				CalculateForcesFromSlips();
				if (_rigidbody != null)
				{
					_rigidbody.AddForceAtPosition(_totalForce, base.transform.position);
				}
			}
			else if (_parkingBrake != null)
			{
				DisableParkingBrake();
			}
			_wasGrounded = _isGrounded;
		}

		protected virtual void OnDrawGizmosSelected()
		{
			Gizmos.color = _gizmoColor;
			if (_dummyWheel != null)
			{
				Gizmos.DrawLine(base.transform.position - _dummyWheel.up * WheelRadius, base.transform.position + _dummyWheel.up * (_suspensionDistance - _suspensionCompression));
			}
			Vector3 vector = base.transform.TransformPoint(WheelRadius * new Vector3(0f, Mathf.Sin(0f), Mathf.Cos(0f)));
			for (int i = 1; i <= 20; i++)
			{
				Vector3 vector2 = base.transform.TransformPoint(WheelRadius * new Vector3(0f, Mathf.Sin((float)i / 20f * MathF.PI * 2f), Mathf.Cos((float)i / 20f * MathF.PI * 2f)));
				Gizmos.DrawLine(vector, vector2);
				vector = vector2;
			}
			Gizmos.color = Color.white;
		}

		protected virtual void Update()
		{
			if (!PauseManager.Paused)
			{
				if (WheelMesh != null)
				{
					WheelMesh.localEulerAngles = new Vector3(_wheelRotationAngle, 0f, 0f);
				}
				if (SuspensionTransform != null)
				{
					Vector3 localEulerAngles = SuspensionTransform.localEulerAngles;
					SuspensionTransform.localEulerAngles = new Vector3(localEulerAngles.x, _wheelSteerAngle, localEulerAngles.z);
					SuspensionTransform.localPosition = base.transform.localPosition;
				}
			}
		}

		private void CalculateForcesFromSlips()
		{
			_totalForce = Vector3.zero;
			float num = 0f;
			if (SuspensionEnabled)
			{
				num = (_suspensionCompression - _suspensionDistance * _suspensionSpring.TargetPosition) * _suspensionSpring.Spring;
				if (num > _maxSpringForce)
				{
					num = _maxSpringForce;
				}
				Vector3 vector = _dummyWheel.up * num;
				float num2 = _suspensionCompression - _suspensionCompressionPrev;
				if (num2 < 0f)
				{
					num2 = 0f;
				}
				vector += _dummyWheel.up * num2 / Time.fixedDeltaTime * _suspensionSpring.Damper;
				vector = Vector3.Project(vector, _surfaceNormal);
				_totalForce += vector;
			}
			float stiffness = num;
			_forwardFriction.Stiffness = stiffness;
			_sidewaysFriction.Stiffness = stiffness;
			Vector3 vector2 = _dummyWheel.forward * (Mathf.Sign(_forwardSlip) * _forwardFriction.Evaluate(_forwardSlip) * _surfaceFriction);
			float num3 = Mathf.Abs(_sidewaysSlip);
			if (Mathf.Abs(_wheelAngularVelocity) > 1000f)
			{
				num3 -= 0.05f;
				if (num3 < 0f)
				{
					num3 = 0f;
				}
				float num4 = 2f;
				float num5 = num3 / num4;
				if (num5 < 1f)
				{
					num3 = num5 * num5 * num4;
				}
			}
			vector2 -= _dummyWheel.right * (Mathf.Sign(_sidewaysSlip) * _sidewaysFriction.Evaluate(num3) * _surfaceFriction);
			vector2 = Vector3.ProjectOnPlane(vector2, _surfaceNormal);
			_totalForce += vector2;
			UpdateParkingBrake();
		}

		private void CalculateLandingImpact()
		{
			if (!_wasGrounded)
			{
				float num = new Vector2(_forwardSlip, _sidewaysSlip).magnitude / WheelRadius;
				num *= Mathf.Clamp(Mathf.Abs(Rigidbody.GetPointVelocity(_raycastHit.point).y - _groundVelocity.y), 0.5f, 4f) / 2f;
				_wheelAngularVelocity -= _forwardSlip * 57.29578f / WheelRadius;
				if (num > 260f)
				{
					this.OnFastTouchdown?.Invoke(num / 260f - 1f);
				}
			}
		}

		private void CalculateSlips()
		{
			Vector3 lhs = Rigidbody.GetPointVelocity(_raycastHit.point) - _groundVelocity;
			_prevPosition = _dummyWheel.position;
			_speedOverGround = lhs.magnitude;
			Vector3 forward = _dummyWheel.forward;
			Vector3 vector = -_dummyWheel.right;
			Vector3 rhs = Vector3.Dot(lhs, forward) * forward;
			Vector3 rhs2 = Vector3.Dot(lhs, vector) * vector;
			_forwardSlip = (0f - Mathf.Sign(Vector3.Dot(forward, rhs))) * rhs.magnitude + _wheelAngularVelocity * MathF.PI / 180f * WheelRadius;
			_sidewaysSlip = (0f - Mathf.Sign(Vector3.Dot(vector, rhs2))) * rhs2.magnitude;
		}

		private void CreateParkingBrakeJoint()
		{
			SpringJoint springJoint = _rigidbody.PhysxRigidBody.gameObject.AddComponent<SpringJoint>();
			springJoint.spring = 500f;
			springJoint.damper = 25f;
			springJoint.maxDistance = 0f;
			springJoint.minDistance = 0f;
			springJoint.breakForce = springJoint.spring * 2f;
			_parkingBrake = springJoint;
		}

		private void UpdateParkingBrake()
		{
			if (BrakeInput >= 0.9f && Mathf.Abs(_forwardSlip) < 1f && Mathf.Abs(_sidewaysSlip) < 1f && _rigidbody.velocity.magnitude < 1f)
			{
				if (_parkingBrake == null)
				{
					CreateParkingBrakeJoint();
				}
			}
			else if (_parkingBrake != null)
			{
				DisableParkingBrake();
			}
		}

		private void UpdateSuspension()
		{
			if (Physics.Raycast(new Ray(_dummyWheel.position + _dummyWheel.up * WheelRadius, -_dummyWheel.up), out _raycastHit, WheelRadius * 2f + _suspensionDistance, 9443328))
			{
				if (!_isGrounded)
				{
					_prevPosition = _dummyWheel.position;
				}
				_gizmoColor = Color.green;
				_isGrounded = true;
				_surfaceNormal = _raycastHit.normal;
				_suspensionCompressionPrev = _suspensionCompression;
				_suspensionCompression = _suspensionDistance + WheelRadius - (_raycastHit.point - _dummyWheel.position).magnitude;
				if (_suspensionCompression > _suspensionDistance)
				{
					_suspensionCompression = _suspensionDistance;
					_gizmoColor = Color.red;
				}
				if (_raycastHit.collider is TerrainCollider)
				{
					_surfaceFriction = 0.7f;
				}
				else
				{
					_surfaceFriction = 1f;
				}
				Rigidbody attachedRigidbody = _raycastHit.collider.attachedRigidbody;
				if (attachedRigidbody != null)
				{
					_groundVelocity = attachedRigidbody.linearVelocity;
				}
				else
				{
					_groundVelocity = Vector3.zero;
				}
			}
			else
			{
				_suspensionCompression = 0f;
				_gizmoColor = Color.blue;
				_isGrounded = false;
			}
		}

		private void UpdateWheel()
		{
			_dummyWheel.localEulerAngles = new Vector3(0f, _wheelSteerAngle, 0f);
			_wheelRotationAngle += _wheelAngularVelocity * Time.fixedDeltaTime;
			base.transform.localEulerAngles = new Vector3(_wheelRotationAngle, _wheelSteerAngle, 0f);
			base.transform.localPosition = _dummyWheel.localPosition - Vector3.up * (_suspensionDistance - _suspensionCompression) / Scale;
			if (_wheelMotorTorque == 0f)
			{
				if (_isGrounded)
				{
					_wheelAngularVelocity -= Mathf.Sign(_forwardSlip) * _forwardFriction.Evaluate(_forwardSlip) / (MathF.PI * 2f * WheelRadius) / _wheelMass * Time.fixedDeltaTime;
				}
				else
				{
					_wheelAngularVelocity *= 1f - 0.1f * Time.fixedDeltaTime;
				}
			}
			_wheelAngularVelocity += _wheelMotorTorque / WheelRadius / _wheelMass * Time.fixedDeltaTime;
			_wheelBrakeTorque = BrakeInput * BrakeTorque;
			_wheelAngularVelocity -= Mathf.Sign(_wheelAngularVelocity) * Mathf.Min(Mathf.Abs(_wheelAngularVelocity), _wheelBrakeTorque * WheelRadius / _wheelMass * Time.fixedDeltaTime);
		}
	}
}
