using System;
using Unity.Profiling;
using UnityEngine;
using WaveHarmonic.Crest.Internal;
using WaveHarmonic.Crest.Utility;

namespace WaveHarmonic.Crest
{
	[AddComponentMenu("Crest/Physics/Crest Floating Object")]
	public sealed class FloatingObject : ManagedBehaviour<WaterRenderer>
	{
		[Serializable]
		private sealed class DebugFields
		{
			[Tooltip("Draw queries for each force point as gizmos.")]
			[SerializeField]
			internal bool _DrawQueries;
		}

		[Tooltip("The rigid body to affect.\n\nIt will automatically get the sibling rigid body if not set.")]
		[SerializeField]
		private Rigidbody _RigidBody;

		[Tooltip("The model to use for buoyancy.\n\nAlign Normal is simple and only uses a few queries whilst Probes is more advanced and uses a few queries per probe. Cannot be changed at runtime after Start.")]
		[SerializeField]
		private FloatingObjectModel _Model;

		[Tooltip("Which water collision layer to target.")]
		[SerializeField]
		private CollisionLayer _Layer = CollisionLayer.AfterAnimatedWaves;

		[Header("Buoyancy")]
		[Tooltip("Strength of buoyancy force.\n\nFor probes, roughly a mass to force ratio of 100 to 1 to keep the center of mass near the surface. For Align Normal, default value is for a default sphere with a default rigidbody.")]
		[SerializeField]
		private float _BuoyancyForceStrength = 10f;

		[Tooltip("Strength of torque applied to match boat orientation to water normal.")]
		[SerializeField]
		private float _BuoyancyTorqueStrength = 8f;

		[Tooltip("Clamps the buoyancy force to this value.\n\nUseful for handling fully submerged objects.")]
		[SerializeField]
		private float _MaximumBuoyancyForce = 100f;

		[Tooltip("Height offset from transform center to bottom of boat (if any).\n\nDefault value is for a default sphere. Having this value be an accurate measurement from center to bottom is not necessary.")]
		[SerializeField]
		private float _CenterToBottomOffset = -1f;

		[Tooltip("Approximate hydrodynamics of 'surfing' down waves.")]
		[SerializeField]
		private float _AccelerateDownhill;

		[SpaceAttribute(10f)]
		[Tooltip("Query points for buoyancy.\n\nOnly applicable to Probes model.")]
		[SerializeField]
		internal FloatingObjectProbe[] _Probes = new FloatingObjectProbe[0];

		[Header("Drag")]
		[Tooltip("Drag when in water.\n\nAdditive to the drag declared on the rigid body.")]
		[SerializeField]
		private Vector3 _Drag = new Vector3(2f, 3f, 1f);

		[Tooltip("Angular drag when in water.\n\nAdditive to the angular drag declared on the rigid body.")]
		[SerializeField]
		private float _AngularDrag = 0.2f;

		[Tooltip("Vertical offset for where drag force should be applied.")]
		[SerializeField]
		private float _ForceHeightOffset;

		[Header("Wave Response")]
		[Tooltip("Width of object for physics purposes.\n\nThe larger this value, the more filtered/smooth the wave response will be. If larger wavelengths cannot be filtered, increase the LOD Levels")]
		[SerializeField]
		private float _ObjectWidth = 3f;

		[Tooltip("Computes a separate normal based on boat length to get more accurate orientations.\n\nRequires the cost of an extra collision sample.")]
		[SerializeField]
		private bool _UseObjectLength;

		[Tooltip("Length dimension of boat.\n\nOnly used if Use Boat Length is enabled.")]
		[SerializeField]
		private float _ObjectLength = 3f;

		[SpaceAttribute(10f)]
		[SerializeField]
		private DebugFields _Debug = new DebugFields();

		internal const string k_FixedUpdateMarker = "Crest.FloatingObject.FixedUpdate";

		private static readonly ProfilerMarker s_FixedUpdateMarker = new ProfilerMarker("Crest.FloatingObject.FixedUpdate");

		private readonly SampleCollisionHelper _SampleHeightHelper = new SampleCollisionHelper();

		private readonly SampleFlowHelper _SampleFlowHelper = new SampleFlowHelper();

		private Vector3[] _QueryPoints;

		private Vector3[] _QueryResultDisplacements;

		private Vector3[] _QueryResultVelocities;

		private Vector3[] _QueryResultNormal;

		internal FloatingObjectProbe[] _Probe = new FloatingObjectProbe[1]
		{
			new FloatingObjectProbe
			{
				_Weight = 1f
			}
		};

		private const float k_WaterDensity = 1000f;

		private float _TotalWeight;

		public float AccelerateDownhill
		{
			get
			{
				return _AccelerateDownhill;
			}
			set
			{
				_AccelerateDownhill = value;
			}
		}

		public float AngularDrag
		{
			get
			{
				return _AngularDrag;
			}
			set
			{
				_AngularDrag = value;
			}
		}

		public float BuoyancyForceStrength
		{
			get
			{
				return _BuoyancyForceStrength;
			}
			set
			{
				_BuoyancyForceStrength = value;
			}
		}

		public float BuoyancyTorqueStrength
		{
			get
			{
				return _BuoyancyTorqueStrength;
			}
			set
			{
				_BuoyancyTorqueStrength = value;
			}
		}

		public float CenterToBottomOffset
		{
			get
			{
				return _CenterToBottomOffset;
			}
			set
			{
				_CenterToBottomOffset = value;
			}
		}

		public Vector3 Drag
		{
			get
			{
				return _Drag;
			}
			set
			{
				_Drag = value;
			}
		}

		public float ForceHeightOffset
		{
			get
			{
				return _ForceHeightOffset;
			}
			set
			{
				_ForceHeightOffset = value;
			}
		}

		public CollisionLayer Layer
		{
			get
			{
				return _Layer;
			}
			set
			{
				_Layer = value;
			}
		}

		public float MaximumBuoyancyForce
		{
			get
			{
				return _MaximumBuoyancyForce;
			}
			set
			{
				_MaximumBuoyancyForce = value;
			}
		}

		public FloatingObjectModel Model
		{
			get
			{
				return _Model;
			}
			set
			{
				_Model = value;
			}
		}

		public float ObjectLength
		{
			get
			{
				return _ObjectLength;
			}
			set
			{
				_ObjectLength = value;
			}
		}

		public float ObjectWidth
		{
			get
			{
				return _ObjectWidth;
			}
			set
			{
				_ObjectWidth = value;
			}
		}

		public FloatingObjectProbe[] Probes
		{
			get
			{
				return _Probes;
			}
			set
			{
				_Probes = value;
			}
		}

		public Rigidbody RigidBody
		{
			get
			{
				return _RigidBody;
			}
			set
			{
				_RigidBody = value;
			}
		}

		public bool UseObjectLength
		{
			get
			{
				return _UseObjectLength;
			}
			set
			{
				_UseObjectLength = value;
			}
		}

		public bool InWater { get; private set; }

		private bool Advanced => _Model == FloatingObjectModel.Probes;

		private protected override Action<WaterRenderer> OnFixedUpdateMethod => OnFixedUpdate;

		private protected override void OnStart()
		{
			base.OnStart();
			if (_RigidBody == null)
			{
				TryGetComponent<Rigidbody>(out _RigidBody);
			}
			FloatingObjectProbe[] array = (Advanced ? _Probes : _Probe);
			int num = (Advanced ? (array.Length + 1) : array.Length);
			_QueryPoints = new Vector3[num];
			_QueryResultDisplacements = new Vector3[num];
			_QueryResultVelocities = new Vector3[num];
			if (!Advanced)
			{
				_QueryResultNormal = new Vector3[num];
			}
		}

		private void OnFixedUpdate(WaterRenderer water)
		{
			FloatingObjectProbe[] array = (Advanced ? _Probes : _Probe);
			ICollisionProvider provider = water.AnimatedWavesLod.Provider;
			_TotalWeight = 0f;
			for (int i = 0; i < array.Length; i++)
			{
				FloatingObjectProbe floatingObjectProbe = array[i];
				_TotalWeight += floatingObjectProbe._Weight;
				_QueryPoints[i] = base.transform.TransformPoint(floatingObjectProbe._Position + new Vector3(0f, _RigidBody.centerOfMass.y, 0f));
			}
			_QueryPoints[^1] = base.transform.position + new Vector3(0f, _RigidBody.centerOfMass.y, 0f);
			provider.Query(GetHashCode(), _ObjectWidth, _QueryPoints, _QueryResultDisplacements, _QueryResultNormal, _QueryResultVelocities, _Layer);
			if (Advanced && _Debug._DrawQueries)
			{
				for (int j = 0; j < array.Length; j++)
				{
					Vector3 position = _QueryPoints[j];
					position.y = water.SeaLevel + _QueryResultDisplacements[j].y;
					DebugUtility.DrawCross(Debug.DrawLine, position, 1f, Color.magenta);
				}
			}
			Vector3 vector = _QueryResultVelocities[^1];
			_SampleFlowHelper.Sample(base.transform.position, out var flow, _ObjectWidth);
			vector += new Vector3(flow.x, 0f, flow.y);
			if (_Debug._DrawQueries)
			{
				Debug.DrawLine(base.transform.position + 5f * Vector3.up, base.transform.position + 5f * Vector3.up + vector, new Color(1f, 1f, 1f, 0.6f));
			}
			if (Advanced)
			{
				float num = 1000f * Mathf.Abs(Physics.gravity.y);
				InWater = false;
				for (int k = 0; k < array.Length; k++)
				{
					float num2 = water.SeaLevel + _QueryResultDisplacements[k].y - _QueryPoints[k].y;
					if (!(num2 > 0f))
					{
						continue;
					}
					InWater = true;
					if (_TotalWeight > 0f)
					{
						Vector3 vector2 = _BuoyancyForceStrength * array[k]._Weight * num * num2 * Vector3.up / _TotalWeight;
						if (_MaximumBuoyancyForce < float.PositiveInfinity)
						{
							vector2 = Vector3.ClampMagnitude(vector2, _MaximumBuoyancyForce);
						}
						_RigidBody.AddForceAtPosition(vector2, _QueryPoints[k]);
					}
				}
				if (!InWater)
				{
					return;
				}
			}
			else
			{
				float num3 = _QueryResultDisplacements[0].y + water.SeaLevel;
				float num4 = num3 - base.transform.position.y - _CenterToBottomOffset;
				Vector3 vector3 = _QueryResultNormal[0];
				if (_Debug._DrawQueries)
				{
					Vector3 position2 = base.transform.position;
					position2.y = num3;
					DebugUtility.DrawCross(Debug.DrawLine, position2, vector3, 1f, Color.red);
				}
				InWater = num4 > 0f;
				if (!InWater)
				{
					return;
				}
				float num5 = _BuoyancyForceStrength * num4 * num4 * num4;
				Vector3 velocity = Physics.gravity;
				Vector3 vector4 = num5 * -velocity.normalized;
				if (_MaximumBuoyancyForce < float.PositiveInfinity)
				{
					vector4 = Vector3.ClampMagnitude(vector4, _MaximumBuoyancyForce);
				}
				_RigidBody.AddForce(vector4, ForceMode.Acceleration);
				if (_AccelerateDownhill > 0f)
				{
					_RigidBody.AddForce(_AccelerateDownhill * (0f - Physics.gravity.y) * new Vector3(vector3.x, 0f, vector3.z), ForceMode.Acceleration);
				}
				Vector3 vector5 = vector3;
				Vector3 normal = Vector3.up;
				if (_UseObjectLength && _SampleHeightHelper.SampleHeight(base.transform.position, out var _, out velocity, out normal, _ObjectLength, _Layer))
				{
					Vector3 forward = base.transform.forward;
					forward.y = 0f;
					forward.Normalize();
					vector5 -= Vector3.Dot(forward, vector5) * forward;
					Vector3 right = base.transform.right;
					right.y = 0f;
					right.Normalize();
					normal -= Vector3.Dot(right, normal) * right;
				}
				if (_Debug._DrawQueries)
				{
					Debug.DrawLine(base.transform.position, base.transform.position + 5f * vector5, Color.green);
				}
				if (_Debug._DrawQueries && _UseObjectLength)
				{
					Debug.DrawLine(base.transform.position, base.transform.position + 5f * normal, Color.yellow);
				}
				Vector3 vector6 = Vector3.Cross(base.transform.up, vector5);
				_RigidBody.AddTorque(vector6 * _BuoyancyTorqueStrength, ForceMode.Acceleration);
				if (_UseObjectLength)
				{
					Vector3 vector7 = Vector3.Cross(base.transform.up, normal);
					_RigidBody.AddTorque(vector7 * _BuoyancyTorqueStrength, ForceMode.Acceleration);
				}
				_RigidBody.AddTorque((0f - _AngularDrag) * _RigidBody.angularVelocity);
			}
			if (_Drag != Vector3.zero)
			{
				Vector3 vector8 = _RigidBody.linearVelocity - vector;
				Vector3 position3 = _RigidBody.worldCenterOfMass + _ForceHeightOffset * Vector3.up;
				_RigidBody.AddForceAtPosition(_Drag.x * Vector3.Dot(base.transform.right, -vector8) * base.transform.right, position3, ForceMode.Acceleration);
				_RigidBody.AddForceAtPosition(_Drag.y * Vector3.Dot(Vector3.up, -vector8) * Vector3.up, position3, ForceMode.Acceleration);
				_RigidBody.AddForceAtPosition(_Drag.z * Vector3.Dot(base.transform.forward, -vector8) * base.transform.forward, position3, ForceMode.Acceleration);
			}
		}
	}
}
