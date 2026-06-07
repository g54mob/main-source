using System;
using System.Collections.Generic;
using Assets.Scripts.Craft.Parts;
using Assets.Scripts.Flight;
using ModApi.Craft.Parts;
using ModApi.Math;
using ModApi.Ui.Inspector;
using UnityEngine;

namespace Assets.Scripts.CustomWheelCollider
{
	public class ResizableWheelColliderNew : MonoBehaviour
	{
		public enum SuspensionTravelType
		{
			LocalUp = 0,
			AlongGravity = 1
		}

		private class IgnoredGameObject
		{
			public bool Active;

			public GameObject GameObject;

			public int Layer;
		}

		[SerializeField]
		private bool _autoInitialize;

		private Vector3 _castDirection;

		private float _colliderPenetration;

		[SerializeField]
		private ResizableWheelColliderData _data = new ResizableWheelColliderData();

		private CapsuleCollider _fallbackCollider;

		private WheelFrictionCurveSource _forwardFriction;

		[SerializeField]
		private float _forwardSlip;

		private float _frictionNormal = 1f;

		private float _frictionOffroad = 1f;

		private Color _gizmoColor = Color.green;

		private Vector3 _groundVelocity;

		private List<IgnoredGameObject> _ignoredGameObjects;

		[SerializeField]
		private bool _isGrounded;

		private bool _isInitialized;

		private Collider _lastGroundCollider;

		private float _maxSpringForce;

		private float _motorThrottle;

		private Joint _parkingBrake;

		private Vector3 _positionLastFrame;

		private Rigidbody _rigidbody;

		private Vector3 _sideSlipForce;

		private WheelFrictionCurveSource _sidewaysFriction;

		[SerializeField]
		private float _sidewaysSlip;

		[SerializeField]
		private float _surfaceFriction;

		private Vector3 _surfaceNormal;

		private float _suspensionCompression;

		private float _suspensionCompressionPrev;

		private Vector3 _suspensionForce;

		private JointSpringSource _suspensionSpring;

		private Vector3 _totalForce;

		private Vector3 _totalSlipForces;

		private Vector3 _tractionSlipForce;

		private Vector3 _velocity;

		[SerializeField]
		private float _wheelAngularVelocity;

		private float _wheelBrakeTorque;

		private float _wheelEffectiveTorque;

		private float _wheelInternalFriction;

		[SerializeField]
		private Transform _wheelSpinRoot;

		[Range(-30f, 30f)]
		[SerializeField]
		private float _wheelSteerAngle;

		[SerializeField]
		private Transform _wheelSuspensionTravelRoot;

		[SerializeField]
		private Transform _wheelTurnRoot;

		public float AngularVelocityFrictionScale { get; set; }

		public float BrakeInput { get; set; }

		public bool CollideWithAircraftLayer { get; set; }

		public float ConnectedBodyMass { get; private set; }

		public float ContactPatchPercent { get; private set; }

		public float ContactPatchWidth { get; private set; }

		public ResizableWheelColliderData Data => _data;

		public bool EnableInternalFriction { get; set; }

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

		public Func<Vector3> FrameLinearVelocity { get; set; }

		public Func<Vector3> GravityNorm { get; set; }

		public bool IsGrounded => _isGrounded;

		public Collider LastGroundCollider => _lastGroundCollider;

		public Vector3 LastGroundNormal { get; set; }

		public Vector3 LastGroundPoint { get; set; }

		public float MaxAngularVelocity { get; set; }

		public float MomentOfInertia => 0.5f * _data.SimulatedRotationalMass * _data.Radius * _data.Radius;

		public float MotorThrottle
		{
			get
			{
				return _motorThrottle;
			}
			set
			{
				_motorThrottle = value;
			}
		}

		public float NoSuspensionTraction { get; set; }

		public float OffroadPercentage { get; private set; }

		public IPartScript PartScript { get; set; }

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

		public Vector3 SpinAxis { get; private set; }

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

		public Vector3 SurfaceNormalWheelUp { get; private set; }

		public float SuspensionCompression => _suspensionCompression;

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

		public Vector3 SuspensionTravelDir { get; private set; }

		public Vector3 TractionDir { get; private set; }

		public Vector3 WheelColliderCenter { get; private set; }

		public Vector3 WheelColliderCenterLocal { get; private set; }

		public Vector3 WheelLinearVelocity { get; private set; }

		public Transform WheelSpinRoot
		{
			get
			{
				return _wheelSpinRoot;
			}
			set
			{
				_wheelSpinRoot = value;
			}
		}

		public Transform WheelSuspensionTravelRoot
		{
			get
			{
				return _wheelSuspensionTravelRoot;
			}
			set
			{
				_wheelSuspensionTravelRoot = value;
			}
		}

		public Transform WheelTurnRoot
		{
			get
			{
				return _wheelTurnRoot;
			}
			set
			{
				_wheelTurnRoot = value;
			}
		}

		public void ClearIgnoredGameObjects()
		{
			_ignoredGameObjects?.Clear();
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

		public void Initialize(Rigidbody body)
		{
			_isInitialized = true;
			_rigidbody = body;
			ConfigureColliderForceSettings();
			if (_fallbackCollider == null)
			{
				_fallbackCollider = base.gameObject.AddComponent<CapsuleCollider>();
				_fallbackCollider.sharedMaterial = UnityEngine.Object.Instantiate(Game.Instance.ResourceLoader.Load<PhysicMaterial>("Craft/Parts/PhysicsMaterials/FrictionlessPhysicsMaterial"));
				_fallbackCollider.height = Data.Radius * 1.9f / _fallbackCollider.transform.lossyScale.y;
				_fallbackCollider.radius = 0.1f;
			}
		}

		public void OnGenerateInspectorModel(InspectorModel model)
		{
			model.Add(new TextModel("RPM", () => Rpm.ToString("0.000")), "Wheel");
			model.Add(new TextModel("Motor Torque", () => Units.GetTorqueString(_wheelEffectiveTorque)), "Wheel");
			model.Add(new TextModel("Brake Torque", () => Units.GetTorqueString(_wheelBrakeTorque)), "Wheel");
			if (Application.isEditor)
			{
				model.Add(new TextModel("Velocity", () => _velocity.magnitude.ToString("0.000")), "Wheel");
				model.Add(new TextModel("Angular Vel K", () => AngularVelocityFrictionScale.ToString("0.000")), "Wheel");
				model.Add(new TextModel("Forward Slip", () => ForwardSlip.ToString("0.000")), "Wheel");
				model.Add(new TextModel("Side Slip", () => SidewaysSlip.ToString("0.000")), "Wheel");
				model.Add(new TextModel("Fwd Friction", () => (_forwardFriction.Evaluate(_forwardSlip) / _forwardFriction.Stiffness).ToString("0.000")), "Wheel");
				model.Add(new TextModel("Side Friction", () => (_sidewaysFriction.Evaluate(_sidewaysSlip) / _sidewaysFriction.Stiffness).ToString("0.000")), "Wheel");
				model.Add(new TextModel("Forward Stiffness", () => _forwardFriction.Stiffness.ToString("0.000")), "Wheel");
				model.Add(new TextModel("SurfaceFriction", () => SurfaceFriction.ToString("0.000")), "Wheel");
				model.Add(new TextModel("SuspensionCompression", () => SuspensionCompression.ToString("0.000")), "Wheel");
				model.Add(new TextModel("SuspensionDistance", () => _data.SuspensionDistance.ToString("0.000")), "Wheel");
				model.Add(new TextModel("WheelMass", () => _data.SimulatedRotationalMass.ToString("0.000")), "Wheel");
				model.Add(new TextModel("Max Spring", () => _maxSpringForce.ToString("0.000")), "Wheel");
				model.Add(new TextModel("Damper", () => SuspensionSpring.Damper.ToString("0.000")), "Wheel");
			}
		}

		public void OnMassChanged()
		{
			ConfigureColliderForceSettings();
		}

		public void RecalculateFrameState(Vector3 positionDelta, Vector3 velocityDelta)
		{
			_positionLastFrame += positionDelta;
			DestroyParkingBrakeJoint();
		}

		public void SetFallbackColliderRadius(float radius)
		{
			_fallbackCollider.radius = radius;
		}

		public void SetRigidBody(Rigidbody body)
		{
			_rigidbody = body;
		}

		public void SetWheelFrictionScalars(float frictionNormal, float frictionOffroad)
		{
			_frictionNormal = frictionNormal;
			_frictionOffroad = frictionOffroad;
		}

		public void SetWheelStateGrounded(Collider groundCollider, Vector3 groundNormal, Vector3 contactPoint)
		{
			_gizmoColor = Color.green;
			_isGrounded = true;
			LastGroundPoint = contactPoint;
			LastGroundNormal = groundNormal;
			_surfaceNormal = groundNormal;
			SurfaceNormalWheelUp = -Vector3.Cross(SpinAxis, Vector3.Cross(SpinAxis, _surfaceNormal));
			TractionDir = Vector3.Cross(_surfaceNormal, SpinAxis);
			ContactPatchPercent = Vector3.Dot(SurfaceNormalWheelUp, groundNormal);
			ContactPatchWidth = ContactPatchPercent * _data.Width;
			if (groundCollider != _lastGroundCollider)
			{
				_surfaceFriction = groundCollider.material.dynamicFriction;
				TireFrictionDefinition component = groundCollider.GetComponent<TireFrictionDefinition>();
				if (component != null)
				{
					OffroadPercentage = component.OffroadPercentage;
					_surfaceFriction *= Mathf.Lerp(_frictionNormal, _frictionOffroad, OffroadPercentage);
				}
				else
				{
					OffroadPercentage = 1f;
					_surfaceFriction *= _frictionOffroad;
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
			SetSuspensionCompression(0f);
			ContactPatchPercent = 0f;
			ContactPatchWidth = 0f;
			_gizmoColor = Color.blue;
			_isGrounded = false;
			_groundVelocity = Vector3.zero;
		}

		private void Awake()
		{
			BrakeInput = 0f;
			_surfaceFriction = 1f;
			_suspensionSpring = default(JointSpringSource);
		}

		private void CalculateForces()
		{
			_totalForce = Vector3.zero;
			float num;
			if (Data.SuspensionEnabled)
			{
				num = (_suspensionCompression - _data.SuspensionDistance * _suspensionSpring.TargetPosition) * _suspensionSpring.Spring;
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
				_suspensionForce = -SuspensionTravelDir * num;
				_suspensionForce = Vector3.Project(_suspensionForce, _surfaceNormal);
				Vector3 vector = _colliderPenetration * _suspensionSpring.Spring * -GravityNorm();
				_totalForce += _suspensionForce + vector;
			}
			else
			{
				num = NoSuspensionTraction;
			}
			float num3 = num;
			_forwardFriction.Stiffness = num3 * 2f;
			_sidewaysFriction.Stiffness = num3 * 2f;
			float num4 = Mathf.Sign(_forwardSlip) * _forwardFriction.Evaluate(_forwardSlip) * _surfaceFriction;
			_tractionSlipForce = TractionDir * num4;
			_sideSlipForce = Mathf.Sign(_sidewaysSlip) * _sidewaysFriction.Evaluate(Mathf.Abs(_sidewaysSlip)) * _surfaceFriction * -SpinAxis;
			_totalSlipForces = _sideSlipForce + _tractionSlipForce;
			_totalForce += _totalSlipForces;
			UpdateParkingBrake();
		}

		private void CalculateSlips()
		{
			Vector3 wheelLinearVelocity = WheelLinearVelocity;
			Vector3 tractionDir = TractionDir;
			Vector3 rhs = -SpinAxis;
			float num = Vector3.Dot(wheelLinearVelocity, tractionDir);
			float num2 = Vector3.Dot(wheelLinearVelocity, rhs);
			float num3 = _wheelAngularVelocity * _data.Radius;
			_forwardSlip = num3 - num;
			if (float.IsNaN(_forwardSlip))
			{
				_forwardSlip = 0f;
			}
			_sidewaysSlip = 0f - num2;
			if (float.IsNaN(_sidewaysSlip))
			{
				_sidewaysSlip = 0f;
			}
		}

		private void ConfigureColliderForceSettings()
		{
			PartScript part = GetComponentInParent<PartScript>();
			if (part != null)
			{
				PartScript = part;
				GravityNorm = () => part.CraftScript.GravityNormal;
				FrameLinearVelocity = () => part.CraftScript.ReferenceFrame.FrameSurfaceVelocity;
				ConnectedBodyMass = part.CraftScript.Mass;
			}
			else
			{
				GravityNorm = () => Physics.gravity.normalized;
				FrameLinearVelocity = () => Vector3.zero;
				ConnectedBodyMass = _rigidbody.mass;
			}
			float num = _data.CalculateFrictionScale() * 1f;
			float num2 = num * 0.5f;
			CreateFrictionCurves(_data.SlipForwardExtremum, num * _data.TractionForward, _data.SlipForwardAsymptote, num2 * _data.TractionForward, _data.SlipSidewaysExtremum, num * _data.TractionSideways, _data.SlipSidewaysAsymptote, num2 * _data.TractionSideways);
			SuspensionSpring = CreateDefaultSuspension();
			float num3 = _data.SimulatedRotationalMass / PartScript.CraftScript.Mass;
			AngularVelocityFrictionScale = Mathf.Lerp(25f, 1f, Mathf.Clamp01(num3 * 100f / 5f));
			_wheelInternalFriction = ConnectedBodyMass / 4f * 0.01f;
		}

		private JointSpringSource CreateDefaultSuspension()
		{
			PartScript componentInParent = GetComponentInParent<PartScript>();
			float num = 0f;
			float num2 = _data.SimulatedRotationalMass;
			if (componentInParent != null)
			{
				Vector3 vector = base.transform.InverseTransformPoint(componentInParent.CraftScript.CenterOfMass.position);
				num2 = componentInParent.CraftScript.Mass;
				vector.y = 0f;
				num = vector.magnitude;
			}
			JointSpringSource result = default(JointSpringSource);
			float num3 = _data.SuspensionDistance * (1f - Data.SuspensionStiffness);
			result.Spring = num2 * 9.81f / num3;
			result.Damper = result.Spring / 50f;
			NoSuspensionTraction = num2 * 9.81f * 0.9f;
			if (num > 1f)
			{
				result.Spring /= num;
				result.Damper /= num;
				NoSuspensionTraction /= num;
			}
			result.Spring *= _data.SpringForceScale;
			result.Damper *= _data.DamperScale;
			result.TargetPosition = 0f;
			return result;
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
			if (!_isInitialized || !Game.InFlightScene)
			{
				return;
			}
			_velocity = (base.transform.position - _positionLastFrame) / Time.deltaTime;
			_positionLastFrame = base.transform.position;
			Vector3 vector = MathUtils.ConvertAngularToLinearVelocity(_rigidbody.angularVelocity, _rigidbody.position, WheelColliderCenter);
			WheelLinearVelocity = vector + _velocity + FrameLinearVelocity() - _groundVelocity;
			SuspensionTravelDir = -base.transform.up;
			SpinAxis = base.transform.right;
			if (Data.SuspensionEnabled)
			{
				UpdateSuspension();
			}
			UpdateWheel();
			if (_isGrounded)
			{
				CalculateSlips();
				CalculateForces();
				if (_rigidbody != null)
				{
					_rigidbody.AddForceAtPosition(_totalForce, WheelColliderCenter);
				}
			}
			else
			{
				DestroyParkingBrakeJoint();
			}
			if (!Data.SuspensionEnabled)
			{
				SetWheelStateInAir();
			}
		}

		private Vector3 GetGizmoPoint(int pointNum, int totalPoints)
		{
			Vector3 vector = _data.Radius * new Vector3(0f, Mathf.Sin((float)pointNum / (float)totalPoints * MathF.PI * 2f) / base.transform.lossyScale.y, Mathf.Cos((float)pointNum / (float)totalPoints * MathF.PI * 2f) / base.transform.lossyScale.z);
			return base.transform.TransformPoint(WheelColliderCenterLocal + vector);
		}

		private void OnDrawGizmosSelected()
		{
			Gizmos.color = _gizmoColor;
			Gizmos.DrawLine(WheelColliderCenter, WheelColliderCenter + SuspensionTravelDir * _data.Radius);
			Vector3 vector = GetGizmoPoint(0, 20);
			for (int i = 1; i <= 20; i++)
			{
				Vector3 gizmoPoint = GetGizmoPoint(i, 20);
				Gizmos.DrawLine(vector, gizmoPoint);
				vector = gizmoPoint;
			}
			if (_isGrounded)
			{
				Gizmos.color = Color.red;
				Gizmos.DrawSphere(LastGroundPoint, _data.Radius * 0.3f);
				Gizmos.color = Color.blue;
				Gizmos.DrawLine(WheelColliderCenter, WheelColliderCenter + _totalForce);
				Gizmos.color = Color.cyan;
				Gizmos.DrawLine(WheelColliderCenter, WheelColliderCenter + _sideSlipForce);
				Gizmos.color = Color.green;
				Gizmos.DrawLine(WheelColliderCenter, WheelColliderCenter + _tractionSlipForce);
			}
			Gizmos.color = Color.yellow;
			Gizmos.DrawLine(base.transform.position, WheelColliderCenter);
			Vector3 vector2 = Vector3.Cross(-SuspensionTravelDir, SpinAxis) * 0.1f;
			Vector3 vector3 = -vector2;
			Gizmos.DrawLine(base.transform.position + vector2, base.transform.position + vector3);
			Gizmos.DrawLine(WheelColliderCenter + vector2, WheelColliderCenter + vector3);
			Gizmos.color = Color.white;
			Gizmos.DrawLine(WheelColliderCenter, WheelColliderCenter + TractionDir);
			Gizmos.color = Color.white;
		}

		private void OnValidate()
		{
			if (_autoInitialize)
			{
				_autoInitialize = false;
				Initialize(GetComponentInParent<Rigidbody>());
			}
		}

		private void SetSuspensionCompression(float compressionDist)
		{
			_suspensionCompressionPrev = _suspensionCompression;
			_suspensionCompression = compressionDist;
			float num = _data.SuspensionDistance - Mathf.Clamp(_suspensionCompression, 0f, _data.SuspensionDistance);
			SetWheelColliderPosition(base.transform.position + SuspensionTravelDir * num);
		}

		private void SetWheelColliderLocalPosition(Vector3 localPosition)
		{
			WheelColliderCenterLocal = localPosition;
			WheelColliderCenter = base.transform.TransformPoint(localPosition);
			if (_wheelSuspensionTravelRoot != null)
			{
				_wheelSuspensionTravelRoot.position = WheelColliderCenter;
			}
		}

		private void SetWheelColliderPosition(Vector3 worldPosition)
		{
			WheelColliderCenterLocal = base.transform.InverseTransformPoint(worldPosition);
			WheelColliderCenter = worldPosition;
			_fallbackCollider.center = WheelColliderCenterLocal;
			if (_wheelSuspensionTravelRoot != null)
			{
				_wheelSuspensionTravelRoot.position = WheelColliderCenter;
			}
		}

		private void Update()
		{
			if (_isInitialized && Game.InFlightScene && !FlightSceneScript.Instance.TimeManager.Paused && !FlightSceneScript.Instance.TimeManager.CurrentMode.WarpMode)
			{
				if (_wheelSpinRoot != null)
				{
					float num = Rpm / 60f * Time.deltaTime;
					float x = -360f * num;
					_wheelSpinRoot.Rotate(new Vector3(x, 0f, 0f), Space.Self);
				}
				if (_wheelTurnRoot != null)
				{
					_wheelTurnRoot.localEulerAngles = new Vector3(0f, _wheelSteerAngle, 0f);
				}
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
			if (CollideWithAircraftLayer)
			{
				num |= int.MinValue;
			}
			_castDirection = SuspensionTravelDir;
			float num2 = _data.Radius * 0.5f;
			Vector3 position = base.transform.position;
			Vector3 spinAxis = SpinAxis;
			Vector3 vector = -_castDirection;
			Vector3 vector2 = 0.05f * _data.Width * spinAxis;
			Vector3 vector3 = 1.01f * _data.Radius * vector;
			Vector3 point = position + vector3 + vector2;
			Vector3 point2 = position + vector3 - vector2;
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
			float maxDistance = _data.Radius * 2f + _data.SuspensionDistance - num2;
			RaycastHit hitInfo;
			bool flag = Physics.CapsuleCast(point, point2, num2, _castDirection, out hitInfo, maxDistance, num, QueryTriggerInteraction.Ignore);
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
			if (hitInfo.collider != null && hitInfo.collider.gameObject.layer == 31 && PartScript != null)
			{
				PartScript componentInParent = hitInfo.collider.GetComponentInParent<PartScript>();
				if (componentInParent != null && componentInParent.CraftScript == PartScript.CraftScript)
				{
					flag = false;
					IgnoreGameObjectInRaycast(hitInfo.collider.gameObject);
				}
			}
			if (flag)
			{
				SetWheelStateGrounded(hitInfo.collider, hitInfo.normal, hitInfo.point);
				float num4 = _data.Radius + _data.SuspensionDistance;
				float magnitude = (hitInfo.point - position).magnitude;
				float num5 = num4 - magnitude;
				SetSuspensionCompression(num5);
				if (num5 > _data.SuspensionDistance)
				{
					_gizmoColor = Color.red;
					_colliderPenetration = num5 - _data.SuspensionDistance;
				}
				else
				{
					_colliderPenetration = 0f;
				}
			}
			else
			{
				SetWheelStateInAir();
			}
		}

		private void UpdateWheel()
		{
			base.transform.localEulerAngles = new Vector3(0f, _wheelSteerAngle, 0f);
			if (_isGrounded)
			{
				float num = Mathf.Sign(_forwardSlip) * _forwardFriction.Evaluate(_forwardSlip) / (_data.Radius * _data.SimulatedRotationalMass * AngularVelocityFrictionScale) * Time.deltaTime;
				_wheelAngularVelocity -= num;
			}
			else
			{
				_wheelAngularVelocity *= 1f - 0.1f * Time.deltaTime;
			}
			float num2 = 2f * _motorThrottle * _data.MaxTorqueAtWheel * 0.01f;
			float num3 = Rpm / Data.MaxWheelRpm;
			float num4 = Mathf.Clamp01(1f - num3 * num3);
			float num5 = (_wheelEffectiveTorque = num2 * num4) / (_data.SimulatedRotationalMass * _data.Radius * _data.Radius) * Time.deltaTime;
			_wheelAngularVelocity += num5;
			_wheelBrakeTorque = BrakeInput * _data.BrakeTorque * 0.01f;
			float num6 = (float)(EnableInternalFriction ? 1 : 0) * _wheelInternalFriction;
			float b = 2f * (_wheelBrakeTorque + num6) / (_data.SimulatedRotationalMass * _data.Radius * _data.Radius) * Time.deltaTime;
			b = Mathf.Sign(_wheelAngularVelocity) * Mathf.Min(Mathf.Abs(_wheelAngularVelocity), b);
			_wheelAngularVelocity -= b;
			if (MaxAngularVelocity > 0f)
			{
				_wheelAngularVelocity = Mathf.Clamp(_wheelAngularVelocity, 0f - MaxAngularVelocity, MaxAngularVelocity);
			}
			if (float.IsNaN(_wheelAngularVelocity))
			{
				_wheelAngularVelocity = 0f;
			}
		}
	}
}
