using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Serialization;

namespace Dreamteck.Splines
{
	[ExecuteInEditMode]
	public class SplineUser : MonoBehaviour, ISerializationCallbackReceiver
	{
		public enum UpdateMethod
		{
			Update = 0,
			FixedUpdate = 1,
			LateUpdate = 2
		}

		[HideInInspector]
		public UpdateMethod updateMethod;

		[SerializeField]
		[HideInInspector]
		[FormerlySerializedAs("_computer")]
		private SplineComputer _spline;

		[SerializeField]
		[HideInInspector]
		private bool _autoUpdate;

		[SerializeField]
		[HideInInspector]
		protected RotationModifier _rotationModifier;

		[SerializeField]
		[HideInInspector]
		protected OffsetModifier _offsetModifier;

		[SerializeField]
		[HideInInspector]
		protected ColorModifier _colorModifier;

		[SerializeField]
		[HideInInspector]
		protected SizeModifier _sizeModifier;

		[SerializeField]
		[HideInInspector]
		private SampleCollection sampleCollection;

		[SerializeField]
		[HideInInspector]
		private SplineSample clipFromSample;

		[SerializeField]
		[HideInInspector]
		private SplineSample clipToSample;

		[SerializeField]
		[HideInInspector]
		private bool _loopSamples;

		[SerializeField]
		[HideInInspector]
		private double _clipFrom;

		[SerializeField]
		[HideInInspector]
		private double _clipTo;

		[SerializeField]
		[HideInInspector]
		private float animClipFrom;

		[SerializeField]
		[HideInInspector]
		private float animClipTo;

		private bool rebuild;

		private bool getSamples;

		private bool postBuild;

		private Transform _trs;

		private bool _hasTransform;

		[SerializeField]
		[HideInInspector]
		private int _sampleCount;

		[SerializeField]
		[HideInInspector]
		private int startSampleIndex;

		protected SplineSample evalResult;

		[HideInInspector]
		public bool multithreaded;

		[HideInInspector]
		public bool buildOnAwake;

		[HideInInspector]
		public bool buildOnEnable;

		[SerializeField]
		[HideInInspector]
		private bool _isUpdated;

		public SplineComputer spline
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public double clipFrom
		{
			get
			{
				return 0.0;
			}
			set
			{
			}
		}

		public double clipTo
		{
			get
			{
				return 0.0;
			}
			set
			{
			}
		}

		public bool autoUpdate
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public bool loopSamples
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public double span => 0.0;

		public bool samplesAreLooped => false;

		public RotationModifier rotationModifier => null;

		public OffsetModifier offsetModifier => null;

		public ColorModifier colorModifier => null;

		public SizeModifier sizeModifier => null;

		protected Transform trs => null;

		protected bool hasTransform => false;

		public int sampleCount => 0;

		public event EmptySplineHandler onPostBuild
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		protected virtual void Awake()
		{
		}

		protected void CacheTransform()
		{
		}

		protected virtual void Reset()
		{
		}

		protected virtual void OnEnable()
		{
		}

		protected virtual void OnDisable()
		{
		}

		protected virtual void OnDestroy()
		{
		}

		protected virtual void OnDidApplyAnimationProperties()
		{
		}

		public SplineSample GetSampleRaw(int index)
		{
			return null;
		}

		public void GetSample(int index, SplineSample target)
		{
		}

		public virtual void Rebuild()
		{
		}

		public virtual void RebuildImmediate()
		{
		}

		private void Update()
		{
		}

		private void LateUpdate()
		{
		}

		private void FixedUpdate()
		{
		}

		private void RunUpdate()
		{
		}

		private void BuildThreaded()
		{
		}

		private void ResampleAndBuildThreaded()
		{
		}

		protected virtual void Run()
		{
		}

		protected virtual void LateRun()
		{
		}

		protected virtual void Build()
		{
		}

		protected virtual void PostBuild()
		{
		}

		protected virtual void OnSplineChanged()
		{
		}

		public void ModifySample(SplineSample source, SplineSample destination)
		{
		}

		public void ModifySample(SplineSample sample)
		{
		}

		public void SetClipRange(double from, double to)
		{
		}

		private void GetSamples()
		{
		}

		public double ClipPercent(double percent)
		{
			return 0.0;
		}

		public void ClipPercent(ref double percent)
		{
		}

		public double UnclipPercent(double percent)
		{
			return 0.0;
		}

		public void UnclipPercent(ref double percent)
		{
		}

		private int GetSampleIndex(double percent)
		{
			return 0;
		}

		public Vector3 EvaluatePosition(double percent)
		{
			return default(Vector3);
		}

		public void Evaluate(double percent, SplineSample result)
		{
		}

		public SplineSample Evaluate(double percent)
		{
			return null;
		}

		public void Evaluate(ref SplineSample[] results, double from = 0.0, double to = 1.0)
		{
		}

		public void EvaluatePositions(ref Vector3[] positions, double from = 0.0, double to = 1.0)
		{
		}

		public double Travel(double start, float distance, Spline.Direction direction, out float moved)
		{
			moved = default(float);
			return 0.0;
		}

		public double Travel(double start, float distance, Spline.Direction direction = Spline.Direction.Forward)
		{
			return 0.0;
		}

		public double TravelWithOffset(double start, float distance, Spline.Direction direction, Vector3 offset, out float moved)
		{
			moved = default(float);
			return 0.0;
		}

		public virtual void Project(Vector3 position, SplineSample result, double from = 0.0, double to = 1.0)
		{
		}

		public float CalculateLength(double from = 0.0, double to = 1.0)
		{
			return 0f;
		}

		public float CalculateLengthWithOffset(Vector3 offset, double from = 0.0, double to = 1.0)
		{
			return 0f;
		}

		public virtual void OnBeforeSerialize()
		{
		}

		public virtual void OnAfterDeserialize()
		{
		}

		protected static Vector3 TransformOffset(SplineSample sample, Vector3 localOffset)
		{
			return default(Vector3);
		}
	}
}
