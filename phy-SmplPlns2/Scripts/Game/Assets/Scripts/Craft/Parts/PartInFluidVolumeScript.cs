using Assets.Scripts.Levels;
using BuoyancyToolkit;
using UnityEngine;

namespace Assets.Scripts.Craft.Parts
{
	[RequireComponent(typeof(Collider))]
	public abstract class PartInFluidVolumeScript : MonoBehaviour
	{
		public PartScript _part;

		public AnimationCurve ImpactVelocityAdjustment;

		public bool IsMassModifierOnly;

		public float MassModifier = 1f;

		protected static float _boundsExtentBias = 0.01f;

		protected static int[] _samplesAtQuality = new int[3] { 3, 8, 16 };

		protected static FluidVolume _waterFluidVolume = null;

		protected static GameObject _waterSurfaceParticleEffects;

		protected static float _weightFactorBias = 0f;

		[SerializeField]
		[HideInInspector]
		protected float _angularDragScalar = 1f;

		[SerializeField]
		[HideInInspector]
		protected Collider _buoyancyCollider;

		[SerializeField]
		[HideInInspector]
		protected float _dragScalar = 1f;

		protected bool _firstFrame = true;

		[SerializeField]
		[HideInInspector]
		protected int _ignoreLayers;

		protected float _initialWeightFactor;

		protected float _inverseVolume;

		protected bool _isCompletelySubmerged;

		protected bool _isSubmerged;

		protected float _lastFixedImpulse;

		protected float _maxParticlesAndEmissionRate;

		protected float _nonfluidAngularDrag;

		protected float _nonfluidDrag;

		protected float _originalMass = -1f;

		[SerializeField]
		[HideInInspector]
		protected BuoyancyQuality _quality = BuoyancyQuality.Medium;

		[SerializeField]
		[HideInInspector]
		protected int _samples = 8;

		protected float _totalAngularDrag;

		protected bool _totalCompletelySubmerged;

		protected float _totalDrag;

		protected bool _totalSubmerged;

		[SerializeField]
		[HideInInspector]
		protected bool _useWeighting = true;

		[SerializeField]
		[HideInInspector]
		protected float _weightFactor = 1.5f;

		public float AngularDragScalar
		{
			get
			{
				return _angularDragScalar;
			}
			set
			{
				_angularDragScalar = value;
			}
		}

		public Rigidbody BuoyanceForceRigidBody
		{
			get
			{
				if (_part != null)
				{
					return _part.Body.GetComponent<Rigidbody>();
				}
				return null;
			}
		}

		public Collider BuoyancyCollider
		{
			get
			{
				return _buoyancyCollider;
			}
			set
			{
				if (_buoyancyCollider != value)
				{
					_buoyancyCollider = value;
					Recalculate();
				}
			}
		}

		public float BuoyancyScale { get; set; }

		public float DragScalar
		{
			get
			{
				return _dragScalar;
			}
			set
			{
				_dragScalar = value;
			}
		}

		public int IgnoreLayers
		{
			get
			{
				return _ignoreLayers;
			}
			set
			{
				_ignoreLayers = value;
			}
		}

		public bool IsCompletelySubmerged => _isCompletelySubmerged;

		public bool IsSubmerged => _isSubmerged;

		public float NonfluidAngularDrag
		{
			get
			{
				return _nonfluidAngularDrag;
			}
			set
			{
				_nonfluidAngularDrag = value;
			}
		}

		public float NonfluidDrag
		{
			get
			{
				return _nonfluidDrag;
			}
			set
			{
				_nonfluidDrag = value;
			}
		}

		public float PartVolume { get; set; }

		public BuoyancyQuality Quality
		{
			get
			{
				return _quality;
			}
			set
			{
				BuoyancyQuality buoyancyQuality = (BuoyancyQuality)Mathf.Clamp((int)value, 0, 3);
				if (_quality != buoyancyQuality)
				{
					_quality = buoyancyQuality;
					if (_quality != BuoyancyQuality.Custom)
					{
						_samples = _samplesAtQuality[(int)_quality];
					}
					Recalculate();
				}
			}
		}

		public int Samples
		{
			get
			{
				return _samples;
			}
			set
			{
				_quality = BuoyancyQuality.Custom;
				int num = Mathf.Clamp(value, 1, 100);
				if (_samples != num)
				{
					_samples = num;
					Recalculate();
				}
			}
		}

		public bool UseWeighting
		{
			get
			{
				return _useWeighting;
			}
			set
			{
				if (_useWeighting != value)
				{
					_useWeighting = value;
					if (_useWeighting)
					{
						Recalculate();
					}
				}
			}
		}

		public float WeightFactor
		{
			get
			{
				return _weightFactor;
			}
			set
			{
				_weightFactor = value;
			}
		}

		public virtual void OnFluidVolumeEnter()
		{
		}

		public virtual void OnFluidVolumeExit()
		{
		}

		public virtual void Recalculate()
		{
			if (_useWeighting && _buoyancyCollider != null)
			{
				_inverseVolume = 1f / CalculateApproximateVolume();
			}
		}

		protected float CalculateApproximateVolume()
		{
			Bounds bounds = _buoyancyCollider.bounds;
			bounds.Expand(_boundsExtentBias);
			float y = bounds.size.y;
			float num = bounds.size.x / (float)_samples;
			float num2 = bounds.size.z / (float)_samples;
			float num3 = 0f;
			for (int i = 0; i < _samples; i++)
			{
				for (int j = 0; j < _samples; j++)
				{
					Vector3 vector = new Vector3(num * ((float)i + 0.5f), 0f, num2 * ((float)j + 0.5f));
					if (_buoyancyCollider.Raycast(new Ray(bounds.min + vector, Vector3.up), out var hitInfo, y) && _buoyancyCollider.Raycast(new Ray(bounds.min + Vector3.up * bounds.size.y + vector, Vector3.down), out var hitInfo2, y))
					{
						num3 += (y - hitInfo.distance - hitInfo2.distance) * num * num2;
					}
				}
			}
			if (num3 == 0f)
			{
				num3 = y * num * num2 + 0.0001f;
			}
			return num3;
		}

		protected virtual void LateUpdate()
		{
			if (_firstFrame)
			{
				_firstFrame = false;
			}
		}

		protected virtual void Start()
		{
			BuoyancyCollider = GetComponent<Collider>();
			if (_waterFluidVolume == null)
			{
				_waterFluidVolume = LevelBase.CurrentLevel.WaterVolume.GetComponent<FluidVolume>();
			}
			Recalculate();
			_part = base.transform.GetComponentInParent<PartScript>();
			_originalMass = _part.Part.LoadedMass;
		}

		protected virtual void Update()
		{
		}
	}
}
