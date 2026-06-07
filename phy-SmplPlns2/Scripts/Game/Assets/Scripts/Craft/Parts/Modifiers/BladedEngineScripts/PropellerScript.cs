using System;
using System.Collections.Generic;
using UnityEngine;
using UnityFS;

namespace Assets.Scripts.Craft.Parts.Modifiers.BladedEngineScripts
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

		public bool SimulateRealtime;

		public Vector3 WingRootChordEdge;

		[HideInInspector]
		public float WingTipAngle;

		public Vector3 WingTipChordEdge;

		public float WingTipSweep;

		public float WingTipWidthZeroToOne = 1f;

		private BladedEngineScript _bladedEngine;

		private List<ControlSurface> _controlSurfaces = new List<ControlSurface>();

		private float _propCountLiftAdjustment;

		private Transform _rotationDirection;

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

		public void CalculateForces(float angleOfAttack, float rpm, float fluidDensityRatio, out Vector3 liftForce, out Vector3 dragForce)
		{
			UpdateWingGeometry();
			Vector3 right = base.transform.right;
			Vector3 vector = Vector3.zero;
			if (RigidBodyToAddDragTo != null)
			{
				vector = (PropellerVelocity = GetRotationalVelocity(rpm));
			}
			Vector3 wingRootLeadingEdge = _wingRootLeadingEdge;
			Vector3 tipLeadingEdge = _wingRootLeadingEdge + (_wingTipLeadingEdge - _wingRootLeadingEdge);
			Vector3 tipTrailingEdge = _wingRootTrailingEdge + (_wingTipTrailingEdge - _wingRootTrailingEdge);
			Vector3 wingRootTrailingEdge = _wingRootTrailingEdge;
			Vector3 rhs = -vector;
			float num = 0f;
			float num2 = 0f;
			float magnitude = rhs.magnitude;
			float num3 = CalculateArea(wingRootLeadingEdge, tipLeadingEdge, tipTrailingEdge, wingRootTrailingEdge);
			float num4 = (CoeffecientOfLift = _bladedEngine.Airfoil.CL.Evaluate(angleOfAttack));
			num4 *= 30f;
			float num6 = 1.29f;
			float num7 = magnitude;
			num = num4 * num3 * 0.5f * num6 * (num7 * num7);
			float num8 = (CoeffecientOfDrag = _bladedEngine.Airfoil.CD.Evaluate(angleOfAttack));
			num8 *= 20f;
			num2 = 0.5f * num8 * num6 * (num7 * num7) * num3;
			liftForce = Vector3.Cross(right, rhs);
			liftForce.Normalize();
			liftForce *= num * fluidDensityRatio;
			Vector3 forward = _rotationDirection.forward;
			dragForce = -forward;
			dragForce.Normalize();
			dragForce *= num2 * fluidDensityRatio;
			if (liftForce.magnitude < 4000000f)
			{
				liftForce *= _propCountLiftAdjustment;
				liftForce *= (float)_bladedEngine.PropellerCount;
				liftForce *= 0.01f;
				Vector3 vector2 = RigidBodyToAddForceTo.linearVelocity - _bladedEngine.PartScript.Aircraft.WindVelocity;
				if (vector2.magnitude > 306.261f)
				{
					float value = 1f - (vector2.magnitude - 306.261f) / 34.029022f;
					value = Mathf.Clamp01(value);
					liftForce *= value;
				}
			}
			if (dragForce.magnitude < 4000000f)
			{
				dragForce *= _propCountLiftAdjustment;
				dragForce *= (float)_bladedEngine.PropellerCount;
				dragForce *= 0.01f;
			}
			dragForce *= _bladedEngine.DragScalar;
			liftForce *= _bladedEngine.LiftScalar;
		}

		public float GetBladePitch(float effectivePitch, float slip)
		{
			if (slip > 1f)
			{
				return Mathf.Clamp(Mathf.Abs(effectivePitch / slip), effectivePitch, 1f);
			}
			return effectivePitch;
		}

		public float GetGeometricPitch()
		{
			return Mathf.Tan(MathF.PI / 180f * _bladedEngine.PropellerPitchDegrees) * MathF.PI * _bladedEngine.Diameter;
		}

		public float GetTheoreticalMaxSpeed(float geometricPitch)
		{
			return geometricPitch * _bladedEngine.RpmAbs / 60f;
		}

		public void Initialize()
		{
			_bladedEngine = PropEngine as BladedEngineScript;
			float propellerPitch = _bladedEngine.PropellerPitch;
			_bladedEngine.PropellerPitch = 0f;
			_rotationDirection = new GameObject("RotationDirection").transform;
			_rotationDirection.parent = base.transform;
			_rotationDirection.localEulerAngles = Vector3.zero;
			_rotationDirection.localPosition = Vector3.zero;
			_rotationDirection.parent = Container.transform;
			_propCountLiftAdjustment = 1f / Mathf.Pow(_bladedEngine.PropellerCount, 0.15f);
			_bladedEngine.PropellerPitch = propellerPitch;
			FluidDensityRatio = _bladedEngine.PartScript.Aircraft.AtmosphereSample.AirDensityRatio;
			MaxSlip = 1f;
		}

		public void SetMaxSlip(float maxSlip)
		{
			MaxSlip = Mathf.Clamp01(maxSlip);
		}

		public void Simulate(bool applyForces)
		{
			GeometricPitch = GetGeometricPitch();
			TheoreticalMaxSpeed = GetTheoreticalMaxSpeed(GeometricPitch);
			Slip = GetSlip(TheoreticalMaxSpeed);
			AngleOfAttack = GetEffectiveAngleOfAttack(Slip);
			CalculateForces(AngleOfAttack, _bladedEngine.Rpm, FluidDensityRatio, out var liftForce, out var dragForce);
			_bladedEngine.RegisterLiftFromProp(liftForce);
			_bladedEngine.RegisterDragFromProp(dragForce);
			if (float.IsFinite(liftForce.magnitude))
			{
				RigidBodyToAddForceTo.AddForceAtPosition(liftForce, RigidBodyToAddForceTo.transform.position, ForceMode.Force);
			}
			CalculatedLiftForce = liftForce;
			CalculatedDragForce = dragForce;
		}

		protected virtual void FixedUpdate()
		{
			if (((_bladedEngine.EngineThrottle > 0f && _bladedEngine.Fuel > 0f) || _bladedEngine.SimulatePropellersAtZeroThrottle) && SimulateRealtime && _bladedEngine.PropellerPhysicsEnabled)
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
			_bladedEngine.RegisterLiftFromProp(Vector3.zero);
			_bladedEngine.RegisterDragFromProp(Vector3.zero);
		}

		protected virtual void OnDestroy()
		{
			if (_rotationDirection != null)
			{
				UnityEngine.Object.Destroy(_rotationDirection.gameObject);
			}
		}

		protected virtual void OnDrawGizmos()
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

		protected virtual void Start()
		{
			_controlSurfaces = new List<ControlSurface>();
			ControlSurface[] components = base.gameObject.GetComponents<ControlSurface>();
			foreach (ControlSurface item in components)
			{
				_controlSurfaces.Add(item);
			}
			Collider[] componentsInChildren = base.transform.parent.GetComponentsInChildren<Collider>();
			for (int i = 0; i < componentsInChildren.Length; i++)
			{
				componentsInChildren[i].enabled = false;
			}
		}

		protected virtual void Update()
		{
			if (_bladedEngine.EngineDestroyed)
			{
				UnityEngine.Object.Destroy(this);
			}
			else
			{
				FluidDensityRatio = _bladedEngine.PartScript.Aircraft.AtmosphereSample.AirDensityRatio;
			}
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

		private void ApplyPrecomputedForces()
		{
			RigidBodyToAddForceTo.AddForceAtPosition(PrecomputedLift, RigidBodyToAddForceTo.transform.position, ForceMode.Force);
			RigidBodyToAddDragTo.AddForceAtPosition((_bladedEngine.ReverseRotation ? _rotationDirection.forward : (-_rotationDirection.forward)) * PrecomputedDragMag, AerodynamicCenterWorldSpace, ForceMode.Force);
		}

		private float GetEffectiveAngleOfAttack(float currentSlip)
		{
			return _bladedEngine.PropellerPitchDegrees * (1f - currentSlip);
		}

		private Vector3 GetRotationalVelocity(float rpm)
		{
			float num = MathF.PI * HalfPropellerLength * 2f * (rpm / 360f);
			return _rotationDirection.forward * num;
		}

		private float GetSlip(float theoreticalMaxSpeed)
		{
			float value;
			if (theoreticalMaxSpeed == 0f)
			{
				value = 0f;
			}
			else
			{
				Vector3 direction = RigidBodyToAddDragTo.linearVelocity - _bladedEngine.PartScript.Aircraft.WindVelocity;
				value = RigidBodyToAddDragTo.transform.InverseTransformDirection(direction).z / theoreticalMaxSpeed;
			}
			return Mathf.Clamp(value, 0f, MaxSlip);
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
	}
}
