using System;
using UnityEngine;

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
		private SplineComputer _spline;

		[SerializeField]
		[HideInInspector]
		private bool _autoUpdate = true;

		[SerializeField]
		[HideInInspector]
		protected RotationModifier _rotationModifier = new RotationModifier();

		[SerializeField]
		[HideInInspector]
		protected OffsetModifier _offsetModifier = new OffsetModifier();

		[SerializeField]
		[HideInInspector]
		protected ColorModifier _colorModifier = new ColorModifier();

		[SerializeField]
		[HideInInspector]
		protected SizeModifier _sizeModifier = new SizeModifier();

		[SerializeField]
		[HideInInspector]
		private SplineSample _clipFromSample;

		[SerializeField]
		[HideInInspector]
		private SplineSample _clipToSample;

		[SerializeField]
		[HideInInspector]
		private bool _loopSamples;

		[SerializeField]
		[HideInInspector]
		private double _clipFrom;

		[SerializeField]
		[HideInInspector]
		private double _clipTo = 1.0;

		[SerializeField]
		[HideInInspector]
		private float animClipFrom;

		[SerializeField]
		[HideInInspector]
		private float animClipTo = 1f;

		private SampleCollection _sampleCollection = new SampleCollection();

		private bool rebuild;

		private bool getSamples;

		private bool postBuild;

		private Transform _trs;

		private bool _hasTransform;

		private SplineSample _workSample;

		private int _sampleCount;

		private int _startSampleIndex;

		protected SplineSample evalResult;

		[HideInInspector]
		public volatile bool multithreaded;

		[HideInInspector]
		public bool buildOnAwake = true;

		[HideInInspector]
		public bool buildOnEnable;

		public SplineComputer spline
		{
			get
			{
				return _spline;
			}
			set
			{
				if (value != _spline)
				{
					if (_spline != null)
					{
						_spline.Unsubscribe(this);
					}
					_spline = value;
					if (_spline != null)
					{
						_spline.Subscribe(this);
						Rebuild();
					}
					OnSplineChanged();
				}
			}
		}

		public double clipFrom
		{
			get
			{
				return _clipFrom;
			}
			set
			{
				if (value != _clipFrom)
				{
					animClipFrom = (float)_clipFrom;
					_clipFrom = DMath.Clamp01(value);
					if (_clipFrom > _clipTo && !_spline.isClosed)
					{
						_clipTo = _clipFrom;
					}
					getSamples = true;
					Rebuild();
				}
			}
		}

		public double clipTo
		{
			get
			{
				return _clipTo;
			}
			set
			{
				if (value != _clipTo)
				{
					animClipTo = (float)_clipTo;
					_clipTo = DMath.Clamp01(value);
					if (_clipTo < _clipFrom && !_spline.isClosed)
					{
						_clipFrom = _clipTo;
					}
					getSamples = true;
					Rebuild();
				}
			}
		}

		public bool autoUpdate
		{
			get
			{
				return _autoUpdate;
			}
			set
			{
				if (value != _autoUpdate)
				{
					_autoUpdate = value;
					if (value)
					{
						Rebuild();
					}
				}
			}
		}

		public bool loopSamples
		{
			get
			{
				return _loopSamples;
			}
			set
			{
				if (value != _loopSamples)
				{
					_loopSamples = value;
					if (!_loopSamples && _clipTo < _clipFrom)
					{
						double num = _clipTo;
						_clipTo = _clipFrom;
						_clipFrom = num;
					}
					Rebuild();
				}
			}
		}

		public double span
		{
			get
			{
				if (samplesAreLooped)
				{
					return 1.0 - _clipFrom + _clipTo;
				}
				return _clipTo - _clipFrom;
			}
		}

		public bool samplesAreLooped
		{
			get
			{
				if (_loopSamples)
				{
					return _clipFrom >= _clipTo;
				}
				return false;
			}
		}

		public RotationModifier rotationModifier => _rotationModifier;

		public OffsetModifier offsetModifier => _offsetModifier;

		public ColorModifier colorModifier => _colorModifier;

		public SizeModifier sizeModifier => _sizeModifier;

		protected Transform trs => _trs;

		protected bool hasTransform => _hasTransform;

		public int sampleCount => _sampleCount;

		public event EmptySplineHandler onPostBuild;

		protected virtual void Awake()
		{
			CacheTransform();
			if (buildOnAwake && Application.isPlaying)
			{
				RebuildImmediate();
			}
			else
			{
				GetSamples();
			}
		}

		protected void CacheTransform()
		{
			_trs = base.transform;
			_hasTransform = true;
		}

		protected virtual void Reset()
		{
		}

		protected virtual void OnEnable()
		{
			if (buildOnEnable)
			{
				RebuildImmediate();
			}
		}

		protected virtual void OnDisable()
		{
		}

		protected virtual void OnDestroy()
		{
		}

		protected virtual void OnDidApplyAnimationProperties()
		{
			bool flag = false;
			if (_clipFrom != (double)animClipFrom || _clipTo != (double)animClipTo)
			{
				flag = true;
			}
			_clipFrom = animClipFrom;
			_clipTo = animClipTo;
			Rebuild();
			if (flag)
			{
				GetSamples();
			}
		}

		public void GetSampleRaw(int index, ref SplineSample sample)
		{
			if (index == 0)
			{
				sample.FastCopy(ref _clipFromSample);
				return;
			}
			if (index == _sampleCount - 1)
			{
				sample.FastCopy(ref _clipToSample);
				return;
			}
			ClampLoopSampleIndex(ref index);
			sample.FastCopy(ref _sampleCollection.samples[index]);
		}

		public double GetSamplePercent(int index)
		{
			if (index == 0)
			{
				return _clipFromSample.percent;
			}
			if (index == _sampleCount - 1)
			{
				return _clipToSample.percent;
			}
			ClampLoopSampleIndex(ref index);
			return _sampleCollection.samples[index].percent;
		}

		private void ClampLoopSampleIndex(ref int index)
		{
			if (index >= _sampleCount)
			{
				index = _sampleCount - 1;
			}
			if (samplesAreLooped)
			{
				_sampleCollection.GetSamplingValues(clipFrom, out var sampleIndex, out var _);
				index = sampleIndex + index;
				if (index >= _sampleCollection.length)
				{
					index -= _sampleCollection.length;
				}
			}
			else
			{
				index = _startSampleIndex + index;
			}
		}

		public void GetSample(int index, ref SplineSample target)
		{
			GetSampleRaw(index, ref _workSample);
			ModifySample(ref _workSample, ref target);
		}

		public void GetSampleWithAngleCompensation(int index, ref SplineSample target)
		{
			GetSampleRaw(index, ref target);
			ModifySample(ref target, ref target);
			if (index > 0 && index < sampleCount - 1)
			{
				GetSampleRaw(index - 1, ref _workSample);
				ModifySample(ref _workSample, ref _workSample);
				Vector3 vector = target.position - _workSample.position;
				GetSampleRaw(index + 1, ref _workSample);
				ModifySample(ref _workSample, ref _workSample);
				Vector3 vector2 = _workSample.position - target.position;
				target.size *= 1f / Mathf.Sqrt(Vector3.Dot(vector.normalized, vector2.normalized) * 0.5f + 0.5f);
			}
		}

		public virtual void Rebuild()
		{
			if (autoUpdate)
			{
				rebuild = (getSamples = true);
			}
		}

		public virtual void RebuildImmediate()
		{
			try
			{
				GetSamples();
				Build();
				PostBuild();
			}
			catch (Exception ex)
			{
				Debug.LogError(ex.Message);
			}
			rebuild = false;
			getSamples = false;
		}

		private void Update()
		{
			if (updateMethod == UpdateMethod.Update)
			{
				Run();
				RunUpdate();
				LateRun();
			}
		}

		private void LateUpdate()
		{
			if (updateMethod == UpdateMethod.LateUpdate)
			{
				Run();
				RunUpdate();
				LateRun();
			}
		}

		private void FixedUpdate()
		{
			if (updateMethod == UpdateMethod.FixedUpdate)
			{
				Run();
				RunUpdate();
				LateRun();
			}
		}

		private void RunUpdate()
		{
			if (rebuild)
			{
				if (multithreaded)
				{
					if (getSamples)
					{
						SplineThreading.Run(ResampleAndBuildThreaded);
					}
					else
					{
						SplineThreading.Run(BuildThreaded);
					}
				}
				else
				{
					if (getSamples || _spline.sampleMode == SplineComputer.SampleMode.Optimized)
					{
						GetSamples();
					}
					Build();
					postBuild = true;
				}
				rebuild = false;
			}
			if (postBuild)
			{
				PostBuild();
				this.onPostBuild?.Invoke();
				postBuild = false;
			}
		}

		private void BuildThreaded()
		{
			while (postBuild)
			{
			}
			Build();
			postBuild = true;
		}

		private void ResampleAndBuildThreaded()
		{
			while (postBuild)
			{
			}
			GetSamples();
			Build();
			postBuild = true;
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

		public void ModifySample(ref SplineSample source, ref SplineSample destination)
		{
			destination = source;
			ModifySample(ref destination);
		}

		public void ModifySample(ref SplineSample sample)
		{
			ApplyModifier(_offsetModifier, ref sample);
			ApplyModifier(_rotationModifier, ref sample);
			ApplyModifier(_colorModifier, ref sample);
			ApplyModifier(_sizeModifier, ref sample);
		}

		private void ApplyModifier(SplineSampleModifier modifier, ref SplineSample sample)
		{
			if (modifier.useClippedPercent)
			{
				ClipPercent(ref sample.percent);
			}
			modifier.Apply(ref sample);
			if (modifier.useClippedPercent)
			{
				UnclipPercent(ref sample.percent);
			}
		}

		public void SetClipRange(double from, double to)
		{
			if (!_spline.isClosed && to < from)
			{
				to = from;
			}
			_clipFrom = DMath.Clamp01(from);
			_clipTo = DMath.Clamp01(to);
			GetSamples();
			Rebuild();
		}

		private void GetSamples()
		{
			getSamples = false;
			if (spline == null)
			{
				_sampleCollection.samples = new SplineSample[0];
				_sampleCount = 0;
				return;
			}
			_spline.GetSamples(_sampleCollection);
			if (_sampleCollection.length == 0)
			{
				_sampleCount = 0;
				return;
			}
			if (_clipFrom != 0.0)
			{
				_sampleCollection.Evaluate(clipFrom, ref _clipFromSample);
			}
			else
			{
				_clipFromSample = _sampleCollection.samples[0];
			}
			if (_clipTo != 1.0)
			{
				_sampleCollection.Evaluate(_clipTo, ref _clipToSample);
			}
			else
			{
				_clipToSample = _sampleCollection.samples[_sampleCollection.length - 1];
			}
			_sampleCount = _sampleCollection.GetClippedSampleCount(_clipFrom, _clipTo, out var _, out var _);
			_sampleCollection.GetSamplingValues(_clipFrom, out _startSampleIndex, out var _);
		}

		public double ClipPercent(double percent)
		{
			ClipPercent(ref percent);
			return percent;
		}

		public void ClipPercent(ref double percent)
		{
			if (_sampleCollection.length == 0)
			{
				percent = 0.0;
			}
			else if (samplesAreLooped)
			{
				if (percent >= clipFrom && percent <= 1.0)
				{
					percent = DMath.InverseLerp(clipFrom, clipFrom + span, percent);
				}
				else if (percent <= clipTo)
				{
					percent = DMath.InverseLerp(clipTo - span, clipTo, percent);
				}
				else if (DMath.InverseLerp(clipTo, clipFrom, percent) < 0.5)
				{
					percent = 1.0;
				}
				else
				{
					percent = 0.0;
				}
			}
			else
			{
				percent = DMath.InverseLerp(clipFrom, clipTo, percent);
			}
		}

		public double UnclipPercent(double percent)
		{
			UnclipPercent(ref percent);
			return percent;
		}

		public void UnclipPercent(ref double percent)
		{
			if (samplesAreLooped)
			{
				if (span <= 1E-05)
				{
					percent = clipFrom;
					return;
				}
				double num = (1.0 - clipFrom) / span;
				if (percent < num)
				{
					percent = DMath.Lerp(clipFrom, 1.0, percent / num);
				}
				else
				{
					if (clipTo == 0.0)
					{
						percent = 0.0;
						return;
					}
					percent = DMath.Lerp(0.0, clipTo, (percent - num) / (clipTo / span));
				}
			}
			else
			{
				if (percent == 0.0)
				{
					percent = clipFrom;
					return;
				}
				if (percent == 1.0)
				{
					percent = clipTo;
					return;
				}
				percent = DMath.Lerp(clipFrom, clipTo, percent);
			}
			percent = DMath.Clamp01(percent);
		}

		private int GetSampleIndex(double percent)
		{
			_sampleCollection.GetSamplingValues(UnclipPercent(percent), out var sampleIndex, out var _);
			return sampleIndex;
		}

		public Vector3 EvaluatePosition(double percent)
		{
			return _sampleCollection.EvaluatePosition(UnclipPercent(percent));
		}

		public void Evaluate(double percent, ref SplineSample result)
		{
			_sampleCollection.Evaluate(UnclipPercent(percent), ref result);
			result.percent = DMath.Clamp01(percent);
		}

		public SplineSample Evaluate(double percent)
		{
			SplineSample result = default(SplineSample);
			Evaluate(percent, ref result);
			result.percent = DMath.Clamp01(percent);
			return result;
		}

		public void Evaluate(ref SplineSample[] results, double from = 0.0, double to = 1.0)
		{
			_sampleCollection.Evaluate(ref results, UnclipPercent(from), UnclipPercent(to));
			for (int i = 0; i < results.Length; i++)
			{
				ClipPercent(ref results[i].percent);
			}
		}

		public void EvaluatePositions(ref Vector3[] positions, double from = 0.0, double to = 1.0)
		{
			_sampleCollection.EvaluatePositions(ref positions, UnclipPercent(from), UnclipPercent(to));
		}

		public double Travel(double start, float distance, Spline.Direction direction, out float moved)
		{
			moved = 0f;
			if (direction == Spline.Direction.Forward && start >= 1.0)
			{
				return 1.0;
			}
			if (direction == Spline.Direction.Backward && start <= 0.0)
			{
				return 0.0;
			}
			if (distance == 0f)
			{
				return DMath.Clamp01(start);
			}
			double num = _sampleCollection.Travel(UnclipPercent(start), distance, direction, out moved, clipFrom, clipTo);
			double num2 = ClipPercent(num);
			moved -= (float)(num - num2);
			return num2;
		}

		public double Travel(double start, float distance, Spline.Direction direction = Spline.Direction.Forward)
		{
			float moved;
			return Travel(start, distance, direction, out moved);
		}

		public double TravelWithOffset(double start, float distance, Spline.Direction direction, Vector3 offset, out float moved)
		{
			moved = 0f;
			if (direction == Spline.Direction.Forward && start >= 1.0)
			{
				return 1.0;
			}
			if (direction == Spline.Direction.Backward && start <= 0.0)
			{
				return 0.0;
			}
			if (distance == 0f)
			{
				return DMath.Clamp01(start);
			}
			double percent = _sampleCollection.TravelWithOffset(UnclipPercent(start), distance, direction, offset, out moved, clipFrom, clipTo);
			return ClipPercent(percent);
		}

		public virtual void Project(Vector3 position, ref SplineSample result, double from = 0.0, double to = 1.0)
		{
			if (!(_spline == null))
			{
				_sampleCollection.Project(position, _spline.pointCount, ref result, UnclipPercent(from), UnclipPercent(to));
				ClipPercent(ref result.percent);
			}
		}

		public float CalculateLength(double from = 0.0, double to = 1.0, bool preventInvert = true)
		{
			return _sampleCollection.CalculateLength(UnclipPercent(from), UnclipPercent(to), preventInvert);
		}

		public float CalculateLengthWithOffset(Vector3 offset, double from = 0.0, double to = 1.0)
		{
			return _sampleCollection.CalculateLengthWithOffset(offset, UnclipPercent(from), UnclipPercent(to));
		}

		public virtual void OnBeforeSerialize()
		{
		}

		public virtual void OnAfterDeserialize()
		{
		}

		protected static Vector3 TransformOffset(SplineSample sample, Vector3 localOffset)
		{
			return (sample.right * localOffset.x + sample.up * localOffset.y + sample.forward * localOffset.z) * sample.size;
		}
	}
}
