using System;
using ModApi.Craft;
using ModApi.Math;
using UnityEngine;
using UnityFS;

namespace Assets.Scripts.Craft.Parts.Modifiers.Propulsion.Propeller
{
	public class PropellerScript : AircraftAttachment
	{
		[HideInInspector]
		public float AngleOfAttack;

		public Vector3 CalculatedDragForce;

		public Vector3 CalculatedLiftForce;

		public GameObject Container;

		public float FluidDensityRatio;

		public float PrecomputedDragMag;

		public MonoBehaviour PropEngine;

		public Rigidbody RigidBodyToAddDragTo;

		public Rigidbody RigidBodyToAddForceTo;

		public int SectionCount = 1;

		public bool SimulateRealtime = true;

		public Vector3 WingRootChordEdge;

		[HideInInspector]
		public float WingTipAngle;

		public Vector3 WingTipChordEdge;

		public float WingTipSweep;

		public float WingTipWidthZeroToOne = 1f;

		private FastAvg _avgDrag = new FastAvg(10);

		private FastAvg _avgLift = new FastAvg(10);

		private Rigidbody _bodyPropIsIn;

		private ICraftScript _craftScript;

		[SerializeField]
		[Range(0.1f, 5f)]
		private float _debugChordScale;

		[SerializeField]
		[Range(0.05f, 50f)]
		private float _debugDiameter;

		[SerializeField]
		[Range(0.01f, 10f)]
		private float _debugDragScalar = 1f;

		private bool _debugFirstFrameValidate = true;

		[SerializeField]
		[Range(1f, 800f)]
		private float _debugMaxFuildDensityRatio = 200f;

		[SerializeField]
		[Range(1f, 100000f)]
		private float _debugMaxMotorTorque;

		[SerializeField]
		[Range(0.1f, 10f)]
		private float _debugThrustScalar = 1f;

		private float _propCountLiftAdjustment;

		private PropellerAssemblyScript _propellerAssembly;

		private PropPhysicsInfoScript _propPhysicsInfo;

		private Vector3 _wingRootLeadingEdge = Vector3.zero;

		private Vector3 _wingRootTrailingEdge = Vector3.zero;

		private Vector3 _wingTipLeadingEdge = Vector3.zero;

		private Vector3 _wingTipTrailingEdge = Vector3.zero;

		public Vector3 AerodynamicCenterWorldSpace { get; private set; }

		public float CoeffecientOfDrag { get; private set; }

		public float CoeffecientOfLift { get; private set; }

		public float GeometricPitch { get; private set; }

		public float MaxSlip { get; private set; }

		public Vector3 PrecomputedLift { get; private set; }

		public Vector3 PropellerVelocity { get; private set; }

		public float Slip { get; private set; }

		public float TheoreticalMaxSpeed { get; private set; }

		private float HalfPropellerLength { get; set; }

		private Vector3 RotationAxis => base.transform.forward;

		public static float CalculatePitchDegrees(float geometricPitch, float diameter)
		{
			return 57.29578f * Mathf.Atan(geometricPitch / (MathF.PI * diameter));
		}

		public static float CalculateSlip(float rpm, float geometricPitch, float velocity)
		{
			float num = geometricPitch * rpm / 60f;
			return velocity / num;
		}

		public static float CalculateTheoreticalMaxSpeed(float geometricPitch, float rpmAbs)
		{
			return geometricPitch * rpmAbs / 60f;
		}

		public void CalculateForces(float angleOfAttack, float rpm, float fluidDensityRatio, out Vector3 liftForce, out Vector3 dragForce)
		{
			UpdateWingGeometry();
			Vector3 right = base.transform.right;
			Vector3 vector = (PropellerVelocity = GetRotationalVelocity(rpm));
			Vector3 wingRootLeadingEdge = _wingRootLeadingEdge;
			Vector3 tipLeadingEdge = _wingRootLeadingEdge + (_wingTipLeadingEdge - _wingRootLeadingEdge);
			Vector3 tipTrailingEdge = _wingRootTrailingEdge + (_wingTipTrailingEdge - _wingRootTrailingEdge);
			Vector3 wingRootTrailingEdge = _wingRootTrailingEdge;
			Vector3 rhs = -vector;
			float magnitude = rhs.magnitude;
			float num = CalculateArea(wingRootLeadingEdge, tipLeadingEdge, tipTrailingEdge, wingRootTrailingEdge);
			float num2 = 1.29f;
			float num3 = magnitude;
			float num4 = 0.5f * num2 * (num3 * num3) * num;
			float num5 = ((Mathf.Sign(angleOfAttack) > 0f) ? 1f : 0.9f);
			float num6 = (CoeffecientOfLift = _propellerAssembly.Airfoil.CL.Evaluate(angleOfAttack) * num5);
			float num8 = 20f * _propellerAssembly.Data.ThrustScalar * _propellerAssembly.DynamicThrustScalar;
			float num9 = num6 * num4 * num8;
			float num10 = (CoeffecientOfDrag = _propellerAssembly.Airfoil.CD.Evaluate(angleOfAttack));
			float num12 = num10 * num4 * 35f * _propellerAssembly.Data.DragScalar;
			liftForce = Vector3.Cross(right, rhs);
			liftForce.Normalize();
			liftForce *= num9 * fluidDensityRatio;
			Vector3 rotationAxis = RotationAxis;
			dragForce = -rotationAxis;
			dragForce.Normalize();
			dragForce *= num12 * fluidDensityRatio;
			liftForce *= _propCountLiftAdjustment;
			liftForce *= (float)_propellerAssembly.BladeCount;
			liftForce *= 0.01f;
			float speedOfSound = _craftScript.FlightData.AtmosphereSample.SpeedOfSound;
			float num13 = speedOfSound * 0.9f;
			float num14 = speedOfSound - num13;
			if (Game.InFlightScene)
			{
				float magnitude2 = (_propellerAssembly.PartScript.CraftScript.ReferenceFrame.FrameSurfaceVelocity + RigidBodyToAddForceTo.velocity).magnitude;
				if (magnitude2 > num13)
				{
					float value = 1f - (magnitude2 - num13) / num14;
					value = Mathf.Clamp01(value);
					liftForce *= value;
				}
			}
			dragForce *= _propCountLiftAdjustment;
			dragForce *= (float)_propellerAssembly.BladeCount;
			dragForce *= 0.01f;
			if (!float.IsNaN(liftForce.magnitude) && !float.IsInfinity(liftForce.magnitude))
			{
				float num15 = _avgLift.Avg * 10f;
				_avgLift.AddValue(liftForce.magnitude);
				if (_avgLift.Count == _avgLift.Capacity && num15 > 0f && liftForce.magnitude > num15)
				{
					liftForce = Vector3.ClampMagnitude(liftForce, num15);
				}
			}
			if (!float.IsNaN(dragForce.magnitude) && !float.IsInfinity(dragForce.magnitude))
			{
				float num16 = _avgDrag.Avg * 10f;
				_avgDrag.AddValue(dragForce.magnitude);
				if (_avgDrag.Count == _avgDrag.Capacity && num16 > 0f && dragForce.magnitude > num16)
				{
					dragForce = Vector3.ClampMagnitude(dragForce, num16);
				}
			}
		}

		public float CalculateRpmAtNoSlip(float velocity)
		{
			float geometricPitch = GeometricPitch;
			return velocity / geometricPitch * 60f;
		}

		public void DoFixedUpdate()
		{
			if (SimulateRealtime && _propellerAssembly.PropellerPhysicsEnabled)
			{
				Simulate(applyForces: true);
				return;
			}
			AngleOfAttack = 0f;
			TheoreticalMaxSpeed = 0f;
			Slip = 0f;
			CoeffecientOfDrag = 0f;
			CoeffecientOfLift = 0f;
			GeometricPitch = 0f;
			_propellerAssembly.RegisterLiftFromPropPhysics(Vector3.zero);
			_propellerAssembly.RegisterDragFromPropPhysics(Vector3.zero);
		}

		public float GetGeometricPitch()
		{
			float propellerPitchDegrees = _propellerAssembly.PropellerPitchDegrees;
			if (!Mathf.Approximately(propellerPitchDegrees, 90f))
			{
				return Mathf.Tan(MathF.PI / 180f * propellerPitchDegrees) * MathF.PI * _propellerAssembly.Diameter;
			}
			return float.MaxValue;
		}

		public void Initialize(Rigidbody propellerBody, Rigidbody bodyPropIsAttachedTo, PropPhysicsInfoScript propPhysicsInfo)
		{
			_propPhysicsInfo = propPhysicsInfo;
			_propellerAssembly = base.transform.GetComponentInParent<PropellerAssemblyScript>();
			_craftScript = _propellerAssembly.PartScript.CraftScript;
			RigidBodyToAddForceTo = bodyPropIsAttachedTo;
			RigidBodyToAddDragTo = propellerBody;
			_bodyPropIsIn = propellerBody;
			Container = base.transform.parent.gameObject;
			_propCountLiftAdjustment = 1f / Mathf.Pow(_propellerAssembly.BladeCount, 0.15f);
			FluidDensityRatio = GetFluidDensityRatio();
			MaxSlip = 1f;
			UpdateWingSize();
		}

		public void OnDrawGizmos()
		{
			UpdateWingGeometry();
			Gizmos.color = Color.blue;
			Gizmos.DrawLine(_wingRootLeadingEdge, _wingTipLeadingEdge);
			Gizmos.color = Color.red;
			Gizmos.DrawLine(_wingTipTrailingEdge, _wingRootTrailingEdge);
			Gizmos.color = Color.blue;
			Gizmos.DrawLine(_wingRootTrailingEdge, _wingRootLeadingEdge);
			Gizmos.DrawLine(_wingTipLeadingEdge, _wingTipTrailingEdge);
			Gizmos.color = Color.yellow;
			Gizmos.DrawLine(WingRootChordEdge, WingTipChordEdge);
			Gizmos.color = Color.green;
			Gizmos.DrawSphere(AerodynamicCenterWorldSpace, 0.1f);
			Gizmos.DrawRay(AerodynamicCenterWorldSpace, CalculatedLiftForce);
			Gizmos.color = Color.red;
			Gizmos.DrawRay(AerodynamicCenterWorldSpace, CalculatedDragForce);
		}

		public void OnPropellerRebuilt(PropPhysicsInfoScript propPhysicsInfoScript)
		{
			_propPhysicsInfo = propPhysicsInfoScript;
		}

		public void SetMaxSlip(float maxSlip)
		{
			MaxSlip = Mathf.Clamp01(maxSlip);
		}

		public void Simulate(bool applyForces)
		{
			GeometricPitch = GetGeometricPitch();
			TheoreticalMaxSpeed = CalculateTheoreticalMaxSpeed(GeometricPitch, _propellerAssembly.RpmAbs);
			Slip = GetSlip(TheoreticalMaxSpeed);
			AngleOfAttack = GetEffectiveAngleOfAttack(Slip);
			CalculateForces(AngleOfAttack, _propellerAssembly.Rpm, FluidDensityRatio, out var liftForce, out var dragForce);
			liftForce *= _debugThrustScalar;
			dragForce *= _debugDragScalar;
			_propellerAssembly.RegisterLiftFromPropPhysics(liftForce);
			_propellerAssembly.RegisterDragFromPropPhysics(dragForce);
			if (applyForces && !float.IsNaN(liftForce.magnitude) && !float.IsInfinity(liftForce.magnitude))
			{
				RigidBodyToAddForceTo.AddForceAtPosition(liftForce, base.transform.position, ForceMode.Force);
			}
			CalculatedLiftForce = liftForce;
			CalculatedDragForce = dragForce;
		}

		public void Start()
		{
			_debugChordScale = _propellerAssembly.Data.ChordScale;
			_debugDiameter = _propellerAssembly.Data.Diameter;
			if (_propellerAssembly.ConnectedMotor != null)
			{
				_debugMaxMotorTorque = _propellerAssembly.ConnectedMotor.Data.Torque;
			}
		}

		public void Update()
		{
			if (_propellerAssembly.EngineDestroyed)
			{
				UnityEngine.Object.Destroy(this);
			}
			else
			{
				FluidDensityRatio = GetFluidDensityRatio();
			}
		}

		public void UpdateWingShape()
		{
			UpdateWingSize();
			UpdateWingGeometry();
		}

		internal float GetBladePitch(float effectivePitch, float slip)
		{
			if (slip > 1f)
			{
				return Mathf.Clamp(Mathf.Abs(effectivePitch / slip), effectivePitch, 1f);
			}
			return effectivePitch;
		}

		private static float CalculateArea(Vector3 rootLeadingEdge, Vector3 tipLeadingEdge, Vector3 tipTrailingEdge, Vector3 rootTrailingEdge)
		{
			float magnitude = (tipLeadingEdge - rootLeadingEdge).magnitude;
			float magnitude2 = (tipTrailingEdge - tipLeadingEdge).magnitude;
			float magnitude3 = (rootTrailingEdge - tipTrailingEdge).magnitude;
			float magnitude4 = (rootLeadingEdge - rootTrailingEdge).magnitude;
			float num = (magnitude + magnitude2 + magnitude3 + magnitude4) * 0.5f;
			return Mathf.Sqrt((num - magnitude) * (num - magnitude2) * (num - magnitude3) * (num - magnitude4));
		}

		private float GetEffectiveAngleOfAttack(float currentSlip)
		{
			return _propellerAssembly.PropellerPitchDegrees * (1f - currentSlip);
		}

		private float GetFluidDensityRatio()
		{
			float value = 1f;
			float t = 0f;
			if (Game.InFlightScene)
			{
				value = _propellerAssembly.PartScript.CraftScript.AtmosphereSample.AirDensity;
				t = _propellerAssembly.PartScript.WaterPhysics.UnderWaterAmount;
			}
			else if (Game.InDesignerScene)
			{
				value = Game.Instance.Designer.PerformanceAnalysis.AtmosphereSample.AirDensity;
				t = 0f;
			}
			return Mathf.Lerp(Mathf.Clamp(value, 0f, 5f), _debugMaxFuildDensityRatio, t);
		}

		private Vector3 GetRotationalVelocity(float rpm)
		{
			float num = MathF.PI * HalfPropellerLength * 2f * (rpm / 360f);
			return RotationAxis * num;
		}

		private float GetSlip(float theoreticalMaxSpeed)
		{
			float f = ((theoreticalMaxSpeed != 0f && Game.InFlightScene) ? (_propellerAssembly.transform.InverseTransformDirection(_propellerAssembly.PartScript.CraftScript.ReferenceFrame.FrameSurfaceVelocity + RigidBodyToAddDragTo.velocity).z / theoreticalMaxSpeed) : 0f);
			return Mathf.Clamp(Mathf.Abs(f), 0f, MaxSlip);
		}

		private void OnValidate()
		{
			if (!_debugFirstFrameValidate)
			{
				_propellerAssembly.Data.Diameter = _debugDiameter;
				_propellerAssembly.Data.ChordScale = _debugChordScale;
				_propellerAssembly.UpdateScale(repositionConnectedParts: false);
				UpdateWingSize();
				_bodyPropIsIn.mass = _propellerAssembly.Data.MassDry;
				_bodyPropIsIn.maxAngularVelocity = CraftBuilder.GetMaxAngularVelocityForBody(_bodyPropIsIn.mass);
				if (_propellerAssembly.ConnectedMotor != null)
				{
					_propellerAssembly.ConnectedMotor.Data.Torque = _debugMaxMotorTorque;
				}
			}
			else
			{
				_debugFirstFrameValidate = false;
			}
		}

		private void SetWorldScale(Vector3 worldScale)
		{
			Vector3 lossyScale = base.transform.parent.lossyScale;
			Vector3 localScale = new Vector3(worldScale.x / lossyScale.x, worldScale.y / lossyScale.y, worldScale.z / lossyScale.z);
			base.transform.localScale = localScale;
		}

		private void UpdateWingGeometry()
		{
			Vector3 position = base.transform.position;
			Vector3 vector = base.transform.position + base.transform.right * base.transform.lossyScale.x;
			vector += base.transform.forward * WingTipSweep;
			float num = base.transform.lossyScale.z * 0.5f;
			_wingRootLeadingEdge = position + base.transform.forward * num;
			_wingRootTrailingEdge = position - base.transform.forward * num;
			_wingTipLeadingEdge = vector + base.transform.forward * (num * WingTipWidthZeroToOne);
			_wingTipTrailingEdge = vector - base.transform.forward * (num * WingTipWidthZeroToOne);
			WingRootChordEdge = (_wingRootLeadingEdge - _wingRootTrailingEdge) * 0.75f + _wingRootTrailingEdge;
			WingTipChordEdge = (_wingTipLeadingEdge - _wingTipTrailingEdge) * 0.75f + _wingTipTrailingEdge;
			AerodynamicCenterWorldSpace = (WingRootChordEdge - WingTipChordEdge) * 0.5f + WingTipChordEdge;
			HalfPropellerLength = Vector3.Distance(_wingTipLeadingEdge, _wingRootLeadingEdge) / 2f;
			float num2 = base.transform.parent.lossyScale.y / 2f;
			base.transform.localPosition = new Vector3(base.transform.localPosition.x, Mathf.Clamp((0f - num2) / 2f, 0f, float.MaxValue), base.transform.localPosition.z);
		}

		private void UpdateWingSize()
		{
			base.transform.localScale = Vector3.one;
			SetWorldScale(_propPhysicsInfo.GetWorldScaleVector3One());
		}
	}
}
