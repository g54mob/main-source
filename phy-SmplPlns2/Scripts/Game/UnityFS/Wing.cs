using System;
using System.Collections.Generic;
using Assets.Scripts.Craft;
using Assets.Scripts.Flight;
using UnityEngine;

namespace UnityFS
{
	[AddComponentMenu("UnityFS/Dynamics/Wing")]
	public class Wing : AircraftAttachment
	{
		private class WingSection
		{
			private Vector3[] _aerodynamicCenterLocal;

			private float[] _area;

			private Vector3[] _chordLineLocal;

			private ControlSurface _controlSurface;

			private int _deflectionKeyframeCount;

			private int _deflectionKeyframeRange = 5;

			private float[] _deflectionKeyframeValues;

			private int _sectionIndex;

			private Vector3[] _upLocal;

			private Transform _wingTransform;

			public Vector3 AerodynamicCenter { get; private set; }

			public float Area { get; private set; }

			public Vector3 ChordLine { get; private set; }

			public Vector3 Up { get; private set; }

			public WingSection(Transform wingTransform, ControlSurface controlSurface, int sectionIndex, Vector3 rootLeadingEdge, Vector3 rootTrailingEdge, Vector3 tipLeadingEdge, Vector3 tipTrailingEdge, float liftLineChordPosition, bool inPlaneDesigner)
			{
				_wingTransform = wingTransform;
				_controlSurface = controlSurface;
				_sectionIndex = sectionIndex;
				if (_controlSurface == null)
				{
					_deflectionKeyframeValues = new float[1];
					Vector3 vector = CalculateChordLine(rootLeadingEdge, tipLeadingEdge, tipTrailingEdge, rootTrailingEdge);
					_chordLineLocal = new Vector3[1] { wingTransform.InverseTransformDirection(vector) };
					_aerodynamicCenterLocal = new Vector3[1] { wingTransform.InverseTransformPoint(CalculateAerodynamicCenter(rootLeadingEdge, tipLeadingEdge, tipTrailingEdge, rootTrailingEdge, liftLineChordPosition)) };
					_upLocal = new Vector3[1] { wingTransform.InverseTransformDirection(CalculateUp(rootLeadingEdge, tipLeadingEdge, tipTrailingEdge, rootTrailingEdge, vector, liftLineChordPosition)) };
					_area = new float[1] { CalculateArea(rootLeadingEdge, tipLeadingEdge, tipTrailingEdge, rootTrailingEdge) };
					return;
				}
				_deflectionKeyframeCount = (int)_controlSurface.MaxDeflectionDegrees / _deflectionKeyframeRange;
				if (_controlSurface.MaxDeflectionDegrees % (float)_deflectionKeyframeRange > 0f)
				{
					_deflectionKeyframeCount++;
				}
				if (inPlaneDesigner)
				{
					_deflectionKeyframeCount = 0;
				}
				int num = _deflectionKeyframeCount * 2 + 1;
				_deflectionKeyframeValues = new float[num];
				_chordLineLocal = new Vector3[num];
				_aerodynamicCenterLocal = new Vector3[num];
				_upLocal = new Vector3[num];
				_area = new float[num];
				_deflectionKeyframeValues[0] = 0f;
				Vector3 vector2 = CalculateChordLine(rootLeadingEdge, tipLeadingEdge, tipTrailingEdge, rootTrailingEdge);
				_chordLineLocal[0] = wingTransform.InverseTransformDirection(vector2);
				_aerodynamicCenterLocal[0] = wingTransform.InverseTransformPoint(CalculateAerodynamicCenter(rootLeadingEdge, tipLeadingEdge, tipTrailingEdge, rootTrailingEdge, liftLineChordPosition));
				_upLocal[0] = wingTransform.InverseTransformDirection(CalculateUp(rootLeadingEdge, tipLeadingEdge, tipTrailingEdge, rootTrailingEdge, vector2, liftLineChordPosition));
				_area[0] = CalculateArea(rootLeadingEdge, tipLeadingEdge, tipTrailingEdge, rootTrailingEdge);
				for (int i = 1; i <= _deflectionKeyframeCount; i++)
				{
					float num2 = 0f;
					num2 = ((i != _deflectionKeyframeCount) ? ((float)(_deflectionKeyframeRange * i)) : _controlSurface.MaxDeflectionDegrees);
					int num3 = 1;
					while (num3 == 1 || num3 == -1)
					{
						Vector3 PointA = rootLeadingEdge;
						Vector3 PointB = tipLeadingEdge;
						Vector3 PointC = tipTrailingEdge;
						Vector3 PointD = rootTrailingEdge;
						_controlSurface.CurrentDeflection = num2 * (float)num3;
						_controlSurface.ModifyWingGeometry(_sectionIndex, ref PointA, ref PointB, ref PointC, ref PointD);
						int num4 = ((num3 == 1) ? i : (i + _deflectionKeyframeCount));
						_deflectionKeyframeValues[num4] = num2 * (float)num3;
						vector2 = CalculateChordLine(PointA, PointB, PointC, PointD);
						_chordLineLocal[num4] = wingTransform.InverseTransformDirection(vector2);
						_aerodynamicCenterLocal[num4] = wingTransform.InverseTransformPoint(CalculateAerodynamicCenter(PointA, PointB, PointC, PointD, liftLineChordPosition));
						_upLocal[num4] = wingTransform.InverseTransformDirection(CalculateUp(PointA, PointB, PointC, PointD, vector2, liftLineChordPosition));
						_area[num4] = CalculateArea(PointA, PointB, PointC, PointD);
						num3 -= 2;
					}
				}
				_controlSurface.CurrentDeflection = 0f;
			}

			public void Update()
			{
				if (_controlSurface == null || _controlSurface.CurrentDeflection == 0f)
				{
					ChordLine = _wingTransform.TransformDirection(_chordLineLocal[0]);
					AerodynamicCenter = _wingTransform.TransformPoint(_aerodynamicCenterLocal[0]);
					Up = _wingTransform.TransformDirection(_upLocal[0]);
					Area = _area[0];
					return;
				}
				float currentDeflection = _controlSurface.CurrentDeflection;
				int num = Math.Abs((int)currentDeflection / _deflectionKeyframeRange);
				int num2 = ((num < _deflectionKeyframeCount) ? (num + 1) : num);
				float num3 = _deflectionKeyframeValues[num2] - _deflectionKeyframeValues[num];
				float t = (Mathf.Abs(currentDeflection) - (float)(num * _deflectionKeyframeRange)) / num3;
				if (currentDeflection < 0f)
				{
					num2 += _deflectionKeyframeCount;
					if (num != 0)
					{
						num += _deflectionKeyframeCount;
					}
				}
				if (num != num2)
				{
					ChordLine = _wingTransform.TransformDirection(Vector3.Lerp(_chordLineLocal[num], _chordLineLocal[num2], t));
					AerodynamicCenter = _wingTransform.TransformPoint(Vector3.Lerp(_aerodynamicCenterLocal[num], _aerodynamicCenterLocal[num2], t));
					Up = _wingTransform.TransformDirection(Vector3.Lerp(_upLocal[num], _upLocal[num2], t));
					Area = Mathf.Lerp(_area[num], _area[num2], t);
				}
				else
				{
					ChordLine = _wingTransform.TransformDirection(_chordLineLocal[num]);
					AerodynamicCenter = _wingTransform.TransformPoint(_aerodynamicCenterLocal[num]);
					Up = _wingTransform.TransformDirection(_upLocal[num]);
					Area = _area[num];
				}
			}

			private Vector3 CalculateAerodynamicCenter(Vector3 rootLeadingEdge, Vector3 tipLeadingEdge, Vector3 tipTrailingEdge, Vector3 rootTrailingEdge, float liftLineChordPosition)
			{
				Vector3 vector = rootTrailingEdge + (rootLeadingEdge - rootTrailingEdge) * liftLineChordPosition;
				Vector3 vector2 = tipTrailingEdge + (tipLeadingEdge - tipTrailingEdge) * liftLineChordPosition - vector;
				return vector + vector2 * 0.5f;
			}

			private float CalculateArea(Vector3 rootLeadingEdge, Vector3 tipLeadingEdge, Vector3 tipTrailingEdge, Vector3 rootTrailingEdge)
			{
				float magnitude = (tipLeadingEdge - rootLeadingEdge).magnitude;
				float magnitude2 = (tipTrailingEdge - tipLeadingEdge).magnitude;
				float magnitude3 = (rootTrailingEdge - tipTrailingEdge).magnitude;
				float magnitude4 = (rootLeadingEdge - rootTrailingEdge).magnitude;
				float num = (magnitude + magnitude2 + magnitude3 + magnitude4) * 0.5f;
				return Mathf.Sqrt((num - magnitude) * (num - magnitude2) * (num - magnitude3) * (num - magnitude4));
			}

			private Vector3 CalculateChordLine(Vector3 rootLeadingEdge, Vector3 tipLeadingEdge, Vector3 tipTrailingEdge, Vector3 rootTrailingEdge)
			{
				return (rootLeadingEdge + (tipLeadingEdge - rootLeadingEdge) * 0.5f - (rootTrailingEdge + (tipTrailingEdge - rootTrailingEdge) * 0.5f)).normalized;
			}

			private Vector3 CalculateUp(Vector3 rootLeadingEdge, Vector3 tipLeadingEdge, Vector3 tipTrailingEdge, Vector3 rootTrailingEdge, Vector3 chordLine, float liftLineChordPosition)
			{
				Vector3 vector = rootTrailingEdge + (rootLeadingEdge - rootTrailingEdge) * liftLineChordPosition;
				return Vector3.Cross(chordLine, (tipTrailingEdge + (tipLeadingEdge - tipTrailingEdge) * liftLineChordPosition - vector).normalized).normalized;
			}
		}

		public Aerofoil Aerofoil;

		public AircraftScript Aircraft;

		[HideInInspector]
		public float AngleOfAttack;

		public float FluidDensityRatio;

		public GameObject GameObjectWithRigidBody;

		public int SectionCount = 10;

		[HideInInspector]
		public float WingTipAngle;

		public float WingTipSweep;

		public float WingTipWidthZeroToOne = 1f;

		private Vector3 _aerodynamicCenterLocalSpace;

		private List<ControlSurface> _controlSurfaces = new List<ControlSurface>();

		private float _liftLineChordPosition = 0.75f;

		private Rigidbody _rigidBodyToActUpon;

		private Transform _transform;

		private WingSection[] _wingSections;

		public Vector3 AerodynamicCenterLocalSpace => _aerodynamicCenterLocalSpace;

		public Vector3 AerodynamicCenterWorldSpace => base.transform.TransformPoint(AerodynamicCenterLocalSpace);

		public float DragForceMagnitude { get; set; }

		public float LiftForceMagnitude { get; set; }

		public float SignedLiftForceMagnitude { get; set; }

		public Rigidbody RigidBodyToActUpon
		{
			get
			{
				return _rigidBodyToActUpon;
			}
			set
			{
				_rigidBodyToActUpon = value;
			}
		}

		public bool SimulateRealtime { get; set; }

		public bool Underwater { get; set; }

		public float DragScale { get; set; }

		public float LiftScale { get; set; }

		public float WaveDragMultiplier { get; set; }

		public void Simulate(bool applyForces)
		{
			float num = 50000f / (float)SectionCount;
			Vector3 zero = Vector3.zero;
			float num2 = 0f;
			float num3 = 0f;
			float num4 = 0f;
			Vector3 right = _transform.right;
			Vector3 vector = Vector3.zero;
			Vector3 vector2 = Vector3.zero;
			Vector3 zero2 = Vector3.zero;
			Vector3 lhs = Vector3.zero;
			float num5 = 0f;
			if (RigidBodyToActUpon != null && applyForces)
			{
				vector = RigidBodyToActUpon.linearVelocity;
				vector2 = RigidBodyToActUpon.worldCenterOfMass;
				zero2 = RigidBodyToActUpon.angularVelocity;
				lhs = zero2.normalized;
				num5 = zero2.magnitude;
			}
			for (int i = 0; i < SectionCount; i++)
			{
				WingSection wingSection = _wingSections[i];
				wingSection.Update();
				Vector3 aerodynamicCenter = wingSection.AerodynamicCenter;
				if (applyForces)
				{
					Vector3 rhs = -(vector - (Underwater ? Vector3.zero : Aircraft.WindVelocity));
					Vector3 vector3 = aerodynamicCenter - vector2;
					Vector3 vector4 = Vector3.Cross(lhs, vector3.normalized);
					vector4 *= 0f - num5 * vector3.magnitude;
					rhs += vector4;
					Vector3 vector5 = right;
					float num6 = Vector3.Dot(vector5, rhs);
					vector5 *= num6;
					rhs -= vector5;
					Vector3 normalized = rhs.normalized;
					AngleOfAttack = Vector3.Dot(wingSection.ChordLine, -normalized);
					AngleOfAttack = Mathf.Clamp(AngleOfAttack, -1f, 1f);
					AngleOfAttack = Mathf.Acos(AngleOfAttack);
					AngleOfAttack *= 57.29578f;
					Vector3 vector6 = wingSection.Up;
					if (_transform.localScale.x < 0f)
					{
						vector6 = -vector6;
					}
					if (Vector3.Dot(vector6, normalized) < 0f)
					{
						AngleOfAttack = 0f - AngleOfAttack;
					}
					float num7 = 0f;
					float num8 = 0f;
					if (Aerofoil != null)
					{
						float num9 = 0.645f * wingSection.Area * 0.01f * rhs.sqrMagnitude;
						num7 = Aerofoil.CL.Evaluate(AngleOfAttack) * num9;
						num8 = Aerofoil.CD.Evaluate(AngleOfAttack) * num9;
					}
					num7 *= FluidDensityRatio;
					num8 *= FluidDensityRatio * WaveDragMultiplier;
					if (float.IsNaN(num7))
					{
						Debug.Log("Lift force is NaN");
						return;
					}
					if (float.IsNaN(num8))
					{
						Debug.Log("Drag force is NaN");
						return;
					}
					num7 = Mathf.Clamp(num7, 0f - num, num);
					num8 = Mathf.Clamp(num8, 0f, num);
					Vector3 force = Vector3.Cross(right, rhs);
					force.Normalize();
					force *= num7 * LiftScale;
					Vector3 force2 = normalized;
					force2 *= num8 * DragScale;
					RigidBodyToActUpon.AddForceAtPosition(force, aerodynamicCenter, ForceMode.Force);
					RigidBodyToActUpon.AddForceAtPosition(force2, aerodynamicCenter, ForceMode.Force);
					float num10 = Math.Abs(num7);
					num2 += num10;
					num3 += num8;
					num4 += num7;
					zero += aerodynamicCenter * num10;
				}
				else
				{
					zero += aerodynamicCenter;
				}
			}
			if (applyForces)
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
			_aerodynamicCenterLocalSpace = _transform.InverseTransformPoint(zero);
			LiftForceMagnitude = num2;
			DragForceMagnitude = num3;
			SignedLiftForceMagnitude = num4;
		}

		protected virtual void Awake()
		{
			_transform = base.transform;
		}

		protected virtual void FixedUpdate()
		{
			if (SimulateRealtime && !PauseManager.Paused)
			{
				Simulate(applyForces: true);
			}
		}

		protected virtual void Start()
		{
			if (SimulateRealtime)
			{
				RigidBodyToActUpon = GameObjectWithRigidBody.GetComponent<Rigidbody>();
			}
			_controlSurfaces = new List<ControlSurface>();
			ControlSurface[] components = base.gameObject.GetComponents<ControlSurface>();
			foreach (ControlSurface item in components)
			{
				_controlSurfaces.Add(item);
			}
			PrecalculateSections();
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
					if (controlSurface2.AffectedSections[i])
					{
						if (controlSurface != null)
						{
							Debug.Log("More than one control surface found to be affecting a single wing section.");
						}
						controlSurface = controlSurface2;
					}
				}
				_wingSections[i] = new WingSection(transform, controlSurface, i, rootLeadingEdge, rootTrailingEdge, tipLeadingEdge, tipTrailingEdge, _liftLineChordPosition, !SimulateRealtime);
			}
		}
	}
}
