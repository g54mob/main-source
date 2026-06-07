using System;
using System.Collections.Generic;
using Assets.Scripts.Craft;
using Assets.Scripts.Craft.Parts;
using UnityEngine;

namespace Assets.Scripts.Flight.Simulation.CustomWheelCollider
{
	public class ResizableWheelCollider : MonoBehaviour
	{
		private class IgnoredGameObject
		{
			public GameObject GameObject { get; set; }

			public int Layer { get; set; }
		}

		public float _forwardSlip;

		public float _frictionNormal = 1f;

		public float _frictionOffroad = 1f;

		public float _sidewaysSlip;

		public float WheelRadius = 0.25f;

		private Vector3 _center;

		private Transform _dummyWheel;

		private WheelFrictionCurveSource _forwardFriction;

		private Color _gizmoColor = Color.green;

		private Vector3 _groundVelocity;

		private List<IgnoredGameObject> _ignoredGameObjects;

		private bool _isGrounded;

		private float _maxSpringForce;

		private Joint _parkingBrake;

		private IRigidBody _rigidbody;

		private WheelFrictionCurveSource _sidewaysFriction;

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

		[SerializeField]
		private Transform SuspensionTransform;

		[SerializeField]
		private Transform WheelMesh;

		public float AngularVelocityFrictionScale { get; set; }

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
			}
		}

		public bool CollideWithAircraftLayer { get; set; }

		public List<PartData> ConnectedParts { get; private set; }

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

		public float MaxAngularVelocity { get; set; }

		public float MomentOfInertia => 0.5f * _wheelMass * WheelRadius * WheelRadius;

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

		public float NoSuspensionTraction { get; set; }

		public bool Offroad { get; private set; }

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

		public float Rpm
		{
			get
			{
				return _wheelAngularVelocity * (30f / MathF.PI);
			}
			set
			{
				_wheelAngularVelocity = value / (30f / MathF.PI);
			}
		}

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
				Center = new Vector3(0f, _suspensionDistance, 0f);
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
				_maxSpringForce = _suspensionSpring.Spring * 4f;
			}
		}

		public event Action<float> OnFastTouchdown;

		public void ClearIgnoredGameObjects()
		{
			if (_ignoredGameObjects != null)
			{
				_ignoredGameObjects.Clear();
			}
		}

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

		public void DisableParkingBrakeImmediate()
		{
			if (_parkingBrake != null)
			{
				UnityEngine.Object.DestroyImmediate(_parkingBrake);
			}
			_parkingBrake = null;
		}

		public void IgnoreGameObjectInRaycast(GameObject g)
		{
			if (_ignoredGameObjects == null)
			{
				_ignoredGameObjects = new List<IgnoredGameObject>();
			}
			IgnoredGameObject item = new IgnoredGameObject
			{
				GameObject = g
			};
			_ignoredGameObjects.Add(item);
		}

		public void SetWheelFrictionScalars(float frictionNormal, float frictionOffroad)
		{
			_frictionNormal = frictionNormal;
			_frictionOffroad = frictionOffroad;
		}

		public void SetWheelStateGrounded(Collider groundCollider, Vector3 groundNormal)
		{
			_gizmoColor = Color.green;
			_isGrounded = true;
			_surfaceNormal = groundNormal;
			if (groundCollider is TerrainCollider)
			{
				_surfaceFriction = 0.7f * _frictionOffroad;
				Offroad = true;
			}
			else
			{
				_surfaceFriction = 1f * _frictionNormal;
				Offroad = false;
			}
			Rigidbody attachedRigidbody = groundCollider.attachedRigidbody;
			if (attachedRigidbody != null)
			{
				_groundVelocity = attachedRigidbody.linearVelocity;
			}
			else
			{
				_groundVelocity = Vector3.zero;
			}
		}

		public void SetWheelStateInAir()
		{
			_suspensionCompression = 0f;
			_gizmoColor = Color.blue;
			_isGrounded = false;
			_groundVelocity = Vector3.zero;
		}

		protected virtual void Awake()
		{
			_dummyWheel = new GameObject("DummyWheel").transform;
			_dummyWheel.transform.parent = base.transform.parent;
			_dummyWheel.transform.localEulerAngles = Vector3.zero;
			_dummyWheel.transform.localPosition = Vector3.zero;
			Center = Vector3.zero;
			_suspensionDistance = 0f;
			_suspensionCompression = 0f;
			Mass = 1f;
			BrakeInput = 0f;
			SuspensionEnabled = true;
			_surfaceFriction = 1f;
			_suspensionSpring = default(JointSpringSource);
			ConnectedParts = new List<PartData>();
		}

		protected virtual void FixedUpdate()
		{
			if (PauseManager.Paused || Rigidbody.Type != RigidBodyType.Local)
			{
				return;
			}
			if (SuspensionEnabled)
			{
				UpdateSuspension();
			}
			UpdateWheel();
			if (_isGrounded)
			{
				if (_rigidbody != null)
				{
					CalculateSlips();
					CalculateLandingImpact();
					CalculateForcesFromSlips();
					_rigidbody.AddForceAtPosition(_totalForce, base.transform.position);
				}
			}
			else if (_parkingBrake != null)
			{
				DisableParkingBrake();
			}
			_wasGrounded = _isGrounded;
			if (!SuspensionEnabled)
			{
				SetWheelStateInAir();
			}
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
			if (PauseManager.Paused)
			{
				return;
			}
			_wheelRotationAngle += _wheelAngularVelocity * 57.29578f * Time.deltaTime;
			if (WheelMesh != null)
			{
				if (WheelMesh == SuspensionTransform)
				{
					WheelMesh.localEulerAngles = new Vector3(_wheelRotationAngle, _wheelSteerAngle, 0f);
				}
				else
				{
					WheelMesh.localEulerAngles = new Vector3(_wheelRotationAngle, 0f, 0f);
				}
			}
			if (SuspensionTransform != null)
			{
				if (SuspensionTransform != WheelMesh)
				{
					SuspensionTransform.localEulerAngles = new Vector3(0f, _wheelSteerAngle, 0f);
				}
				Vector3 localPosition = SuspensionTransform.localPosition;
				localPosition.y = base.transform.localPosition.y;
				SuspensionTransform.localPosition = localPosition;
			}
		}

		private void CalculateForcesFromSlips()
		{
			_totalForce = Vector3.zero;
			float num = 0f;
			if (SuspensionEnabled)
			{
				num = (_suspensionCompression - _suspensionDistance * _suspensionSpring.TargetPosition) * _suspensionSpring.Spring;
				float num2 = _suspensionCompression - _suspensionCompressionPrev;
				if (num2 < 0f)
				{
					num2 = 0f;
				}
				num += num2 / Time.deltaTime * _suspensionSpring.Damper;
				if (num > _maxSpringForce)
				{
					num = _maxSpringForce;
				}
				Vector3 vector = _dummyWheel.up * num;
				vector = Vector3.Project(vector, _surfaceNormal);
				_totalForce += vector;
			}
			else
			{
				num = NoSuspensionTraction;
			}
			float stiffness = num;
			_forwardFriction.Stiffness = stiffness;
			_sidewaysFriction.Stiffness = stiffness;
			Vector3 vector2 = _dummyWheel.forward * (Mathf.Sign(_forwardSlip) * _forwardFriction.Evaluate(_forwardSlip) * _surfaceFriction);
			float slip = Mathf.Abs(_sidewaysSlip);
			vector2 -= _dummyWheel.right * (Mathf.Sign(_sidewaysSlip) * _sidewaysFriction.Evaluate(slip) * _surfaceFriction);
			_totalForce += vector2;
			UpdateParkingBrake();
		}

		private void CalculateLandingImpact()
		{
			if (_isGrounded && !_wasGrounded)
			{
				float num = new Vector2(_forwardSlip, _sidewaysSlip).magnitude / WheelRadius;
				_wheelAngularVelocity -= _forwardSlip / WheelRadius;
				if (num > 120f)
				{
					this.OnFastTouchdown?.Invoke(num / 120f - 1f);
				}
			}
		}

		private void CalculateSlips()
		{
			Vector3 lhs = _rigidbody.velocity - _groundVelocity;
			_speedOverGround = lhs.magnitude;
			Vector3 forward = _dummyWheel.forward;
			Vector3 vector = -_dummyWheel.right;
			Vector3 rhs = Vector3.Dot(lhs, forward) * forward;
			Vector3 rhs2 = Vector3.Dot(lhs, vector) * vector;
			_forwardSlip = (0f - Mathf.Sign(Vector3.Dot(forward, rhs))) * rhs.magnitude + _wheelAngularVelocity * WheelRadius;
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
			int num = 9451520;
			if (CollideWithAircraftLayer)
			{
				num |= 0x200000;
			}
			Vector3 origin = _dummyWheel.position + _dummyWheel.up * WheelRadius;
			if (_ignoredGameObjects != null)
			{
				for (int i = 0; i < _ignoredGameObjects.Count; i++)
				{
					_ignoredGameObjects[i].Layer = _ignoredGameObjects[i].GameObject.layer;
					_ignoredGameObjects[i].GameObject.layer = 2;
				}
			}
			float maxDistance = WheelRadius * 2f + _suspensionDistance;
			RaycastHit hitInfo;
			bool flag = Physics.Raycast(new Ray(origin, -_dummyWheel.up), out hitInfo, maxDistance, num);
			if (_ignoredGameObjects != null)
			{
				for (int j = 0; j < _ignoredGameObjects.Count; j++)
				{
					_ignoredGameObjects[j].GameObject.layer = _ignoredGameObjects[j].Layer;
				}
			}
			if (hitInfo.collider != null && hitInfo.collider.gameObject.layer == 21)
			{
				PartScript componentInParent = hitInfo.collider.GetComponentInParent<PartScript>();
				if (componentInParent != null && ConnectedParts.Contains(componentInParent.Part))
				{
					flag = false;
					IgnoreGameObjectInRaycast(hitInfo.collider.gameObject);
				}
			}
			if (flag)
			{
				SetWheelStateGrounded(hitInfo.collider, hitInfo.normal);
				_suspensionCompressionPrev = _suspensionCompression;
				_suspensionCompression = _suspensionDistance + WheelRadius - (hitInfo.point - _dummyWheel.position).magnitude;
				if (_suspensionCompression > _suspensionDistance)
				{
					_suspensionCompression = _suspensionDistance;
					_gizmoColor = Color.red;
				}
			}
			else
			{
				SetWheelStateInAir();
			}
		}

		private void UpdateWheel()
		{
			_dummyWheel.localEulerAngles = new Vector3(0f, _wheelSteerAngle, 0f);
			base.transform.localEulerAngles = new Vector3(_wheelRotationAngle, _wheelSteerAngle, 0f);
			base.transform.localPosition = _dummyWheel.localPosition - Vector3.up * (_suspensionDistance - _suspensionCompression);
			if (_rigidbody != null)
			{
				if (_isGrounded)
				{
					float num = Mathf.Sign(_forwardSlip) * _forwardFriction.Evaluate(_forwardSlip) / (WheelRadius * _wheelMass * AngularVelocityFrictionScale) * Time.deltaTime;
					_wheelAngularVelocity -= num;
				}
				else
				{
					_wheelAngularVelocity *= 1f - 0.1f * Time.deltaTime;
				}
				_wheelAngularVelocity += 2f * _wheelMotorTorque / (_wheelMass * WheelRadius * WheelRadius) * Time.deltaTime;
				_wheelBrakeTorque = BrakeInput * BrakeTorque;
				float b = 2f * _wheelBrakeTorque / (_wheelMass * WheelRadius * WheelRadius) * Time.deltaTime;
				_wheelAngularVelocity -= Mathf.Sign(_wheelAngularVelocity) * Mathf.Min(Mathf.Abs(_wheelAngularVelocity), b);
				if (MaxAngularVelocity > 0f)
				{
					_wheelAngularVelocity = Mathf.Clamp(_wheelAngularVelocity, 0f - MaxAngularVelocity, MaxAngularVelocity);
				}
			}
		}
	}
}
