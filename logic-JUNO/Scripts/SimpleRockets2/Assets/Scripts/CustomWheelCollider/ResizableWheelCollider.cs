using System;
using System.Collections.Generic;
using Assets.Scripts.Craft.Parts;
using Assets.Scripts.Flight;
using ModApi;
using ModApi.Craft.Parts;
using ModApi.Math;
using ModApi.Ui.Inspector;
using UnityEngine;

namespace Assets.Scripts.CustomWheelCollider
{
	public class ResizableWheelCollider : MonoBehaviour
	{
		private class IgnoredGameObject
		{
			public bool Active;

			public GameObject GameObject;

			public int Layer;
		}

		private Vector3 _center;

		private Transform _dummyWheel;

		private WheelFrictionCurveSource _forwardFriction;

		private float _forwardSlip;

		private float _frictionNormal = 1f;

		private float _frictionOffroad = 1f;

		private Color _gizmoColor = Color.green;

		private Vector3 _groundVelocity;

		private List<IgnoredGameObject> _ignoredGameObjects;

		private bool _isGrounded;

		private bool _isPart;

		private Collider _lastGroundCollider;

		private float _maxSpringForce;

		private Joint _parkingBrake;

		private Rigidbody _rigidbody;

		private WheelFrictionCurveSource _sidewaysFriction;

		private float _sidewaysSlip;

		private float _surfaceFriction;

		private float _surfaceFrictionTarget = 0.5f;

		private Vector3 _surfaceNormal;

		private float _suspensionCompression;

		private float _suspensionCompressionPrev;

		private float _suspensionDistance;

		private JointSpringSource _suspensionSpring;

		[SerializeField]
		private Transform _suspensionTransform;

		private Vector3 _totalForce;

		private float _wheelAngularVelocity;

		private float _wheelBrakeTorque;

		private float _wheelMass;

		[SerializeField]
		private Transform _wheelMesh;

		private float _wheelMotorTorque;

		private float _wheelRotationAngle;

		private float _wheelSteerAngle;

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

		public Transform DummyWheel => _dummyWheel;

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

		public Collider LastGroundCollider => _lastGroundCollider;

		public Vector3 LastGroundNormal { get; set; }

		public Vector3 LastGroundPoint { get; set; }

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

		public float OffroadPercentage { get; private set; }

		public IPartScript PartScript { get; set; }

		public Rigidbody Rigidbody
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

		public float Rpm => _wheelAngularVelocity * (30f / MathF.PI);

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

		public float SuspensionCompression => _suspensionCompression;

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

		public float WheelRadius { get; set; } = 0.25f;

		public float WheelRotationAngle
		{
			get
			{
				return _wheelRotationAngle;
			}
			set
			{
				_wheelRotationAngle = value;
			}
		}

		public float WheelWidth { get; set; } = 0.25f;

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

		public void OnGenerateInspectorModel(InspectorModel model, int direction)
		{
			model.Add(new TextModel("RPM", () => (Rpm * (float)direction).ToString("0.000")), "Wheel");
			model.Add(new TextModel("Motor Torque", () => Units.GetTorqueString(_wheelMotorTorque * (float)direction)), "Wheel");
			model.Add(new TextModel("Brake Torque", () => Units.GetTorqueString(_wheelBrakeTorque)), "Wheel");
			if (Application.isEditor)
			{
				model.Add(new TextModel("Wheel Mass", () => Units.GetMassString(Mass)), "Wheel");
				model.Add(new TextModel("Velocity", () => Units.GetVelocityString(_rigidbody.velocity.magnitude)), "Wheel");
				model.Add(new TextModel("Angular Vel K", () => $"{AngularVelocityFrictionScale:n2}"), "Wheel");
				SliderModel sliderModel = new SliderModel("Angular Vel K", () => AngularVelocityFrictionScale, delegate(float x)
				{
					AngularVelocityFrictionScale = x;
				});
				sliderModel.MinValue = 0.25f;
				sliderModel.MaxValue = 25f;
				sliderModel.ValueFormatter = (float x) => x.ToString();
				model.Add(sliderModel, "Wheel");
				model.Add(new TextModel("Forward Slip", () => ForwardSlip.ToString("0.000")), "Wheel");
				model.Add(new TextModel("Side Slip", () => SidewaysSlip.ToString("0.000")), "Wheel");
				model.Add(new TextModel("Fwd Friction", () => (_forwardFriction.Evaluate(_forwardSlip) / _forwardFriction.Stiffness * (float)direction).ToString("0.000")), "Wheel");
				model.Add(new TextModel("Side Friction", () => (_sidewaysFriction.Evaluate(_sidewaysSlip) / _sidewaysFriction.Stiffness * (float)direction).ToString("0.000")), "Wheel");
				model.Add(new TextModel("Forward Stiffness", () => _forwardFriction.Stiffness.ToString("0.000")), "Wheel");
				model.Add(new TextModel("Offroad Percentage", () => Utilities.FormatPercentage(OffroadPercentage) ?? ""), "Wheel");
				model.Add(new TextModel("SurfaceFriction", () => SurfaceFriction.ToString("0.000")), "Wheel");
				model.Add(new TextModel("SuspensionCompression", () => SuspensionCompression.ToString("0.000")), "Wheel");
				model.Add(new TextModel("SuspensionDistance", () => SuspensionDistance.ToString("0.000")), "Wheel");
				model.Add(new TextModel("Max Spring", () => _maxSpringForce.ToString("0.000")), "Wheel");
				model.Add(new TextModel("Damper", () => SuspensionSpring.Damper.ToString("0.000")), "Wheel");
			}
		}

		public void RecalculateFrameState()
		{
			DestroyParkingBrakeJoint();
		}

		public void SetWheelFrictionScalars(float frictionNormal, float frictionOffroad)
		{
			_frictionNormal = frictionNormal;
			_frictionOffroad = frictionOffroad;
		}

		public void SetWheelStateGrounded(Collider groundCollider, Vector3 groundNormal, Vector3 contactPoint, bool isPart = false)
		{
			_gizmoColor = Color.green;
			LastGroundPoint = contactPoint;
			LastGroundNormal = groundNormal;
			_isGrounded = true;
			_isPart = isPart;
			_surfaceNormal = groundNormal;
			if (groundCollider != _lastGroundCollider)
			{
				_surfaceFrictionTarget = groundCollider.material.dynamicFriction;
				if (groundCollider.TryGetComponent<TireFrictionDefinition>(out var component))
				{
					OffroadPercentage = component.OffroadPercentage;
					_surfaceFrictionTarget *= Mathf.Lerp(_frictionNormal, _frictionOffroad, OffroadPercentage);
				}
				else if (groundCollider.gameObject.layer == 26)
				{
					OffroadPercentage = 0f;
					_surfaceFrictionTarget *= _frictionNormal;
				}
				else
				{
					OffroadPercentage = 1f;
					_surfaceFrictionTarget *= _frictionOffroad;
				}
				_lastGroundCollider = groundCollider;
			}
			Rigidbody attachedRigidbody = groundCollider.attachedRigidbody;
			if (attachedRigidbody != null)
			{
				_groundVelocity = attachedRigidbody.velocity;
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

		public void UpdateWheelRotation()
		{
			if (_wheelMesh != null)
			{
				if (_wheelMesh == _suspensionTransform)
				{
					_wheelMesh.localEulerAngles = new Vector3(_wheelRotationAngle, _wheelSteerAngle, 0f);
				}
				else
				{
					_wheelMesh.localEulerAngles = new Vector3(_wheelRotationAngle, 0f, 0f);
				}
			}
		}

		private void Awake()
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
			_surfaceFrictionTarget = 1f;
			_suspensionSpring = default(JointSpringSource);
		}

		private void CalculateForcesFromSlips()
		{
			_totalForce = Vector3.zero;
			float num;
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
			float num3 = num;
			_forwardFriction.Stiffness = num3 * 2f;
			_sidewaysFriction.Stiffness = num3 * 2f;
			_surfaceFriction = Mathf.Lerp(_surfaceFriction, _surfaceFrictionTarget, Time.deltaTime * 0.5f);
			Vector3 vector2 = Mathf.Sign(_forwardSlip) * _forwardFriction.Evaluate(_forwardSlip) * _surfaceFriction * _dummyWheel.forward;
			float slip = Mathf.Abs(_sidewaysSlip);
			vector2 -= Mathf.Sign(_sidewaysSlip) * _sidewaysFriction.Evaluate(slip) * _surfaceFriction * _dummyWheel.right;
			_totalForce += vector2;
			UpdateParkingBrake();
		}

		private void CalculateSlips()
		{
			Vector3 lhs = _rigidbody.velocity + PartScript.CraftScript.ReferenceFrame.FrameSurfaceVelocity - _groundVelocity;
			Vector3 forward = _dummyWheel.forward;
			Vector3 vector = -_dummyWheel.right;
			Vector3 rhs = Vector3.Dot(lhs, forward) * forward;
			Vector3 rhs2 = Vector3.Dot(lhs, vector) * vector;
			_forwardSlip = (0f - Mathf.Sign(Vector3.Dot(forward, rhs))) * rhs.magnitude + _wheelAngularVelocity * WheelRadius;
			_sidewaysSlip = (0f - Mathf.Sign(Vector3.Dot(vector, rhs2))) * rhs2.magnitude;
		}

		private void CreateParkingBrakeJoint()
		{
			SpringJoint springJoint = _rigidbody.gameObject.AddComponent<SpringJoint>();
			springJoint.spring = 500f;
			springJoint.damper = 25f;
			springJoint.maxDistance = 0f;
			springJoint.minDistance = 0f;
			springJoint.breakForce = springJoint.spring * 2f;
			_parkingBrake = springJoint;
		}

		private void DestroyParkingBrakeJoint()
		{
			if (_parkingBrake != null)
			{
				UnityEngine.Object.Destroy(_parkingBrake);
				_parkingBrake = null;
			}
		}

		private void FixedUpdate()
		{
			if (!Game.InFlightScene)
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
				CalculateSlips();
				CalculateForcesFromSlips();
				if (_rigidbody != null)
				{
					_rigidbody.AddForceAtPosition(_totalForce, base.transform.position);
					if (_isPart && _lastGroundCollider?.attachedRigidbody != null)
					{
						_lastGroundCollider.attachedRigidbody.AddForceAtPosition(-_totalForce, LastGroundPoint);
					}
				}
			}
			else
			{
				DestroyParkingBrakeJoint();
			}
			if (!SuspensionEnabled)
			{
				SetWheelStateInAir();
			}
		}

		private void OnDrawGizmosSelected()
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

		private void Update()
		{
			if (!Game.InFlightScene || FlightSceneScript.Instance.TimeManager.Paused || FlightSceneScript.Instance.TimeManager.CurrentMode.WarpMode)
			{
				return;
			}
			_wheelRotationAngle += _wheelAngularVelocity * 57.29578f * Time.deltaTime;
			UpdateWheelRotation();
			if (_suspensionTransform != null)
			{
				if (_suspensionTransform != _wheelMesh)
				{
					_suspensionTransform.localEulerAngles = new Vector3(0f, _wheelSteerAngle, 0f);
				}
				Vector3 localPosition = _suspensionTransform.localPosition;
				localPosition.y = base.transform.localPosition.y;
				_suspensionTransform.localPosition = localPosition;
			}
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
				DestroyParkingBrakeJoint();
			}
		}

		private void UpdateSuspension()
		{
			int num = 603979776;
			num |= int.MinValue;
			float num2 = WheelRadius * 0.5f;
			Vector3 position = _dummyWheel.position;
			Vector3 right = _dummyWheel.right;
			Vector3 up = _dummyWheel.up;
			Vector3 vector = -up;
			Vector3 vector2 = 0.05f * WheelWidth * right;
			Vector3 vector3 = 1.01f * WheelRadius * up;
			Vector3 vector4 = position + vector3 + vector2;
			Vector3 vector5 = position + vector3 - vector2;
			int num3 = ((_ignoredGameObjects != null) ? _ignoredGameObjects.Count : 0);
			if (num3 > 0)
			{
				for (int i = 0; i < num3; i++)
				{
					IgnoredGameObject ignoredGameObject = _ignoredGameObjects[i];
					ignoredGameObject.Active = ignoredGameObject.GameObject.activeInHierarchy;
					if (ignoredGameObject.Active)
					{
						ignoredGameObject.Layer = ignoredGameObject.GameObject.layer;
						ignoredGameObject.GameObject.layer = 2;
					}
				}
			}
			float maxDistance = WheelRadius * 2f + _suspensionDistance - num2;
			RaycastHit hitInfo;
			bool flag = Physics.CapsuleCast(vector4, vector5, num2, vector, out hitInfo, maxDistance, num, QueryTriggerInteraction.Ignore);
			if (num3 > 0)
			{
				for (int j = 0; j < num3; j++)
				{
					IgnoredGameObject ignoredGameObject2 = _ignoredGameObjects[j];
					if (ignoredGameObject2.Active)
					{
						ignoredGameObject2.GameObject.layer = ignoredGameObject2.Layer;
					}
				}
			}
			if (hitInfo.collider != null && hitInfo.collider.gameObject.layer == 31)
			{
				PartScript componentInParent = hitInfo.collider.GetComponentInParent<PartScript>();
				if (componentInParent != null)
				{
					if (componentInParent.CraftScript == PartScript.CraftScript)
					{
						flag = false;
						IgnoreGameObjectInRaycast(hitInfo.collider.gameObject);
					}
				}
				else
				{
					flag = false;
					IgnoreGameObjectInRaycast(hitInfo.collider.gameObject);
				}
			}
			if (flag)
			{
				SetWheelStateGrounded(hitInfo.collider, hitInfo.normal, hitInfo.point, hitInfo.collider.gameObject.layer == 31);
				_suspensionCompressionPrev = _suspensionCompression;
				Vector3 vector6 = vector4 + (vector5 - vector4) * 0.5f + vector * hitInfo.distance + vector * num2;
				_suspensionCompression = _suspensionDistance + WheelRadius - (vector6 - position).magnitude;
				if (_suspensionCompression > _suspensionDistance)
				{
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
			base.transform.localPosition = _dummyWheel.localPosition - Vector3.up * (_suspensionDistance - Mathf.Clamp(_suspensionCompression, 0f, _suspensionDistance));
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
