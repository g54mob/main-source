using System;
using System.Collections.Generic;
using ModApi.Craft;
using ModApi.Craft.Parts;
using ModApi.GameLoop;
using ModApi.GameLoop.Interfaces;
using UnityEngine;

namespace UnityFS
{
	public class Wing : AircraftAttachment, IDesignerStart, IGameLoopItem, IFlightStart, IFlightFixedUpdate
	{
		public AnimationCurve CD;

		public AnimationCurve CL;

		public AnimationCurve CM;

		[HideInInspector]
		public float AngleOfAttack;

		public bool DebugEnabled;

		public float FluidDensity;

		public int SectionCount = 10;

		public int Version = 1;

		[HideInInspector]
		public float WingTipAngle;

		public float WingTipSweep;

		public float WingTipWidthZeroToOne = 1f;

		public float MaxBreakForce = float.PositiveInfinity;

		private Vector3 _aerodynamicCenterLocalSpace;

		private Vector3 _aerodynamicCenterWorldSpace;

		private List<ControlSurface> _controlSurfaces = new List<ControlSurface>();

		private float _lastAvMag;

		private float _liftLineChordPosition = 0.75f;

		private Transform _transform;

		private WingSection[] _wingSections;

		public Vector3 AerodynamicCenterLocalSpace => _aerodynamicCenterLocalSpace;

		public Vector3 AerodynamicCenterWorldSpace => _aerodynamicCenterWorldSpace;

		public float DragForceMagnitude { get; private set; }

		public Vector3 DragForceVector { get; private set; }

		public bool HasStarted { get; private set; }

		public float LiftForceMagnitude { get; set; }

		public Vector3 LiftForceVector { get; private set; }

		public Vector3 MomentumForceVector { get; private set; }

		public IPartScript PartScript { get; set; }

		public bool SimulateRealtime { get; set; }

		public float WingAreaZeroDeflection { get; private set; }

		void IDesignerStart.DesignerStart(in DesignerFrameData frame)
		{
			HasStarted = true;
		}

		void IFlightFixedUpdate.FlightFixedUpdate(in FlightFrameData frame)
		{
			if (SimulateRealtime)
			{
				Simulate(applyForces: true);
			}
		}

		void IFlightStart.FlightStart(in FlightFrameData frame)
		{
			PrecalculateSections();
			HasStarted = true;
		}

		public void PrecalculateSections()
		{
			Transform transform = _transform;
			Vector3 position = transform.position;
			Vector3 localScale = transform.localScale;
			Vector3 forward = transform.forward;
			Vector3 vector = transform.right * (localScale.x * 0.5f);
			Vector3 vector2 = forward * (localScale.z * 0.5f);
			Vector3 vector3 = vector2 * WingTipWidthZeroToOne;
			Vector3 vector4 = position - vector;
			Vector3 vector5 = position + vector + forward * WingTipSweep;
			Vector3 vector6 = vector4 + vector2;
			Vector3 vector7 = vector4 - vector2;
			Vector3 vector8 = vector5 + vector3;
			Vector3 vector9 = vector5 - vector3;
			Vector3 vector10 = vector8 - vector6;
			Vector3 vector11 = vector9 - vector7;
			_wingSections = new WingSection[SectionCount];
			float num = SectionCount;
			float num2 = 0f;
			for (int i = 0; i < SectionCount; i++)
			{
				Vector3 rootLeadingEdge = vector6 + vector10 * ((float)i / num);
				Vector3 tipLeadingEdge = vector6 + vector10 * ((float)(i + 1) / num);
				Vector3 tipTrailingEdge = vector7 + vector11 * ((float)(i + 1) / num);
				Vector3 rootTrailingEdge = vector7 + vector11 * ((float)i / num);
				ControlSurface controlSurface = null;
				for (int j = 0; j < _controlSurfaces.Count; j++)
				{
					ControlSurface controlSurface2 = _controlSurfaces[j];
					if (controlSurface2.AffectedSections != null && controlSurface2.AffectedSections[i])
					{
						if (controlSurface != null)
						{
							Debug.Log("More than one control surface found to be affecting a single wing section.");
						}
						controlSurface = controlSurface2;
					}
				}
				WingSection wingSection = new WingSection(transform, controlSurface, i, rootLeadingEdge, rootTrailingEdge, tipLeadingEdge, tipTrailingEdge, _liftLineChordPosition);
				_wingSections[i] = wingSection;
				num2 += wingSection.Area;
			}
			WingAreaZeroDeflection = num2;
		}

		public void RegisterControlSurface(ControlSurface controlSurface)
		{
			_controlSurfaces.Add(controlSurface);
		}

		public void Simulate(bool applyForces)
		{
			Rigidbody rigidbody = null;
			float num = 50000000f / (float)SectionCount;
			Vector3 zero = Vector3.zero;
			float num2 = 0f;
			float num3 = 0f;
			Vector3 right = _transform.right;
			Vector3 vector = Vector3.zero;
			Vector3 vector2 = Vector3.zero;
			Vector3 zero2 = Vector3.zero;
			Vector3 vector3 = Vector3.zero;
			float num4 = 0f;
			if (applyForces)
			{
				IBodyScript bodyScript = PartScript.BodyScript;
				rigidbody = bodyScript.RigidBody;
				if (rigidbody == null || rigidbody.isKinematic)
				{
					return;
				}
				vector = bodyScript.SurfaceVelocity;
				vector2 = rigidbody.worldCenterOfMass;
				zero2 = rigidbody.angularVelocity;
				vector3 = zero2.normalized;
				num4 = zero2.magnitude;
				if (num4 > 100f && num4 > _lastAvMag)
				{
					num4 = Mathf.Lerp(_lastAvMag, num4, Time.deltaTime);
				}
				_lastAvMag = num4;
			}
			if (vector.sqrMagnitude > 122500f)
			{
				vector = vector.normalized * 350f;
			}
			Vector3 vector4 = (DragForceVector = Vector3.zero);
			Vector3 momentumForceVector = (LiftForceVector = vector4);
			MomentumForceVector = momentumForceVector;
			for (int i = 0; i < SectionCount; i++)
			{
				WingSection wingSection = _wingSections[i];
				wingSection.Update();
				Vector3 aerodynamicCenter = wingSection.AerodynamicCenter;
				if (applyForces)
				{
					Vector3d lhs = wingSection.ChordLine;
					_ = lhs.magnitude;
					lhs.Normalize();
					Vector3d vector3d = -vector;
					Vector3d vector3d2 = aerodynamicCenter - vector2;
					Vector3d vector3d3 = Vector3d.Cross(vector3, vector3d2.normalized);
					vector3d3 *= 0.0 - (double)num4 * vector3d2.magnitude;
					vector3d += vector3d3;
					Vector3d vector3d4 = right;
					vector3d -= vector3d4 * Vector3d.Dot(vector3d4, vector3d);
					Vector3 rhs = (Vector3)vector3d;
					if (vector3d.magnitude > 0.009999999776482582)
					{
						Vector3d normalized = vector3d.normalized;
						double val = Vector3d.Dot(lhs, -normalized);
						val = Math.Min(Math.Max(-1.0, val), 1.0);
						val = Math.Acos(val);
						val = val * 180.0 / Math.PI;
						float num5 = (float)Vector3d.Dot((_transform.localScale.x < 0f) ? (-wingSection.Up) : wingSection.Up, normalized);
						AngleOfAttack = (float)((num5 < 0f) ? (0.0 - val) : val);
						float num6 = 0f;
						float num7 = 0f;
						float area = wingSection.Area;
						if (CL != null && CD != null)
						{
							float num8 = 0.645f * area * rhs.sqrMagnitude;
							num6 = num8 * CL.Evaluate(AngleOfAttack);
							num7 = num8 * CD.Evaluate(AngleOfAttack);
						}
						else
						{
							float num9 = MathF.PI * 2f * (AngleOfAttack * (MathF.PI / 180f));
							float num10 = 1.29f;
							float magnitude = rhs.magnitude;
							num6 = num9 * area * 0.5f * num10 * (magnitude * magnitude);
							float num11 = 0.045f;
							num7 = 0.5f * num11 * num10 * (magnitude * magnitude) * area;
						}
						float num12 = 0.01f * FluidDensity;
						num6 *= num12;
						num7 *= num12;
						if (float.IsNaN(num6))
						{
							Debug.LogError("Lift force is NaN");
							return;
						}
						if (float.IsNaN(num7))
						{
							Debug.LogError("Drag force is NaN");
							return;
						}
						num6 = Mathf.Clamp(num6, 0f - num, num);
						num7 = Mathf.Clamp(num7, 0f, num);
						Vector3 zero4 = Vector3.zero;
						if (Mathf.Abs(num6) > 0.01f || Version == 1)
						{
							zero4 = Vector3.Cross(right, rhs);
							zero4.Normalize();
							zero4 *= num6;
							rigidbody.AddForceAtPosition(zero4, aerodynamicCenter, ForceMode.Force);
							LiftForceVector += zero4;
							float num13 = Math.Abs(num6);
							num2 += num13;
							zero += aerodynamicCenter * num13;
						}
						if (num7 > 0.01f || Version == 1)
						{
							Vector3 vector6 = (Vector3)normalized;
							vector6 *= num7;
							rigidbody.AddForceAtPosition(vector6, aerodynamicCenter, ForceMode.Force);
							DragForceVector += vector6;
							num3 += num7;
						}
						if (DebugEnabled)
						{
							Debug.Log($"{AngleOfAttack}");
						}
					}
				}
				else
				{
					zero += aerodynamicCenter;
				}
			}
			if (SimulateRealtime)
			{
				if (num2 > 0f)
				{
					zero /= num2;
				}
			}
			else
			{
				zero /= (float)SectionCount;
			}
			if (applyForces && !PartScript.Disconnected && num2 > MaxBreakForce)
			{
				PartScript.BodyScript.BodyCollisionHandler.DisconnectPart(PartScript);
			}
			_aerodynamicCenterLocalSpace = _transform.InverseTransformPoint(zero);
			_aerodynamicCenterWorldSpace = zero;
			LiftForceMagnitude = num2;
			DragForceMagnitude = num3;
		}

		public void UpdateStaticAerodynamicCenter()
		{
			PrecalculateSections();
			_aerodynamicCenterWorldSpace = Vector3.zero;
			if (SectionCount > 0)
			{
				float num = 0f;
				for (int i = 0; i < SectionCount; i++)
				{
					WingSection wingSection = _wingSections[i];
					wingSection.Update();
					_aerodynamicCenterWorldSpace += wingSection.AerodynamicCenter * wingSection.Area;
					num += wingSection.Area;
				}
				_aerodynamicCenterWorldSpace /= num;
				_aerodynamicCenterLocalSpace = _transform.InverseTransformPoint(_aerodynamicCenterWorldSpace);
			}
		}

		protected virtual void Awake()
		{
			_transform = base.transform;
			_controlSurfaces = new List<ControlSurface>();
		}
	}
}
