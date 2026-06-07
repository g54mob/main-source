using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace Dreamteck.Splines
{
	[AddComponentMenu("Dreamteck/Splines/Spline Computer")]
	[ExecuteInEditMode]
	public class SplineComputer : MonoBehaviour
	{
		public enum Space
		{
			World = 0,
			Local = 1
		}

		public enum EvaluateMode
		{
			Cached = 0,
			Calculate = 1
		}

		public enum SampleMode
		{
			Default = 0,
			Uniform = 1,
			Optimized = 2
		}

		public enum UpdateMode
		{
			Update = 0,
			FixedUpdate = 1,
			LateUpdate = 2,
			AllUpdate = 3,
			None = 4
		}

		[Serializable]
		internal class NodeLink
		{
			[SerializeField]
			internal Node node;

			[SerializeField]
			internal int pointIndex;

			internal List<Node.Connection> GetConnections(SplineComputer exclude)
			{
				Node.Connection[] connections = node.GetConnections();
				List<Node.Connection> list = new List<Node.Connection>();
				for (int i = 0; i < connections.Length; i++)
				{
					if (!(connections[i].spline == exclude))
					{
						list.Add(connections[i]);
					}
				}
				return list;
			}
		}

		[HideInInspector]
		public bool multithreaded;

		[HideInInspector]
		public UpdateMode updateMode;

		[HideInInspector]
		public TriggerGroup[] triggerGroups = new TriggerGroup[0];

		[HideInInspector]
		[SerializeField]
		[FormerlySerializedAs("spline")]
		private Spline _spline = new Spline(Spline.Type.CatmullRom);

		[HideInInspector]
		private SampleCollection _sampleCollection = new SampleCollection();

		[HideInInspector]
		[SerializeField]
		[FormerlySerializedAs("originalSamplePercents")]
		private double[] _originalSamplePercents = new double[0];

		[HideInInspector]
		[SerializeField]
		private bool _is2D;

		[HideInInspector]
		[SerializeField]
		private bool hasSamples;

		[HideInInspector]
		[SerializeField]
		[Range(0.001f, 45f)]
		private float _optimizeAngleThreshold = 0.5f;

		[HideInInspector]
		[SerializeField]
		private Space _space = Space.Local;

		[HideInInspector]
		[SerializeField]
		private SampleMode _sampleMode;

		[HideInInspector]
		[SerializeField]
		private SplineUser[] _subscribers = new SplineUser[0];

		[HideInInspector]
		[SerializeField]
		private SplineSample[] _rawSamples = new SplineSample[0];

		private Matrix4x4 _localToWorldMatrix = Matrix4x4.identity;

		private Matrix4x4 _worldToLocalMatrix = Matrix4x4.identity;

		[HideInInspector]
		[SerializeField]
		[FormerlySerializedAs("nodes")]
		private NodeLink[] _nodes = new NodeLink[0];

		private bool _rebuildPending;

		private bool _trsCached;

		private Transform _trs;

		private bool _queueResample;

		private bool _queueRebuild;

		public Space space
		{
			get
			{
				return _space;
			}
			set
			{
				if (value != _space)
				{
					SplinePoint[] points = GetPoints();
					_space = value;
					SetPoints(points);
				}
			}
		}

		public Spline.Type type
		{
			get
			{
				return _spline.type;
			}
			set
			{
				if (value != _spline.type)
				{
					_spline.type = value;
					Rebuild(forceUpdateAll: true);
				}
			}
		}

		public float knotParametrization
		{
			get
			{
				return _spline.knotParametrization;
			}
			set
			{
				float num = _spline.knotParametrization;
				_spline.knotParametrization = value;
				if (num != _spline.knotParametrization)
				{
					Rebuild(forceUpdateAll: true);
				}
			}
		}

		public bool linearAverageDirection
		{
			get
			{
				return _spline.linearAverageDirection;
			}
			set
			{
				if (value != _spline.linearAverageDirection)
				{
					_spline.linearAverageDirection = value;
					Rebuild(forceUpdateAll: true);
				}
			}
		}

		public bool is2D
		{
			get
			{
				return _is2D;
			}
			set
			{
				if (value != _is2D)
				{
					_is2D = value;
					SetPoints(GetPoints());
				}
			}
		}

		public int sampleRate
		{
			get
			{
				return _spline.sampleRate;
			}
			set
			{
				if (value != _spline.sampleRate)
				{
					if (value < 2)
					{
						value = 2;
					}
					_spline.sampleRate = value;
					Rebuild(forceUpdateAll: true);
				}
			}
		}

		public float optimizeAngleThreshold
		{
			get
			{
				return _optimizeAngleThreshold;
			}
			set
			{
				if (value != _optimizeAngleThreshold)
				{
					if (value < 0.001f)
					{
						value = 0.001f;
					}
					_optimizeAngleThreshold = value;
					if (_sampleMode == SampleMode.Optimized)
					{
						Rebuild(forceUpdateAll: true);
					}
				}
			}
		}

		public SampleMode sampleMode
		{
			get
			{
				return _sampleMode;
			}
			set
			{
				if (value != _sampleMode)
				{
					_sampleMode = value;
					Rebuild(forceUpdateAll: true);
				}
			}
		}

		public AnimationCurve customValueInterpolation
		{
			get
			{
				return _spline.customValueInterpolation;
			}
			set
			{
				_spline.customValueInterpolation = value;
				Rebuild();
			}
		}

		public AnimationCurve customNormalInterpolation
		{
			get
			{
				return _spline.customNormalInterpolation;
			}
			set
			{
				_spline.customNormalInterpolation = value;
				Rebuild();
			}
		}

		public int iterations => _spline.iterations;

		public double moveStep => _spline.moveStep;

		public bool isClosed => _spline.isClosed;

		public int pointCount => _spline.points.Length;

		public int sampleCount => _sampleCollection.length;

		public SplineSample this[int index]
		{
			get
			{
				UpdateSampleCollection();
				return _sampleCollection.samples[index];
			}
		}

		public SplineSample[] rawSamples => _rawSamples;

		public Vector3 position => _localToWorldMatrix.MultiplyPoint3x4(Vector3.zero);

		public Quaternion rotation => _localToWorldMatrix.rotation;

		public Vector3 scale => _localToWorldMatrix.lossyScale;

		public int subscriberCount => _subscribers.Length;

		public Transform trs
		{
			get
			{
				if (!_trsCached)
				{
					_trs = base.transform;
					_trsCached = true;
				}
				return _trs;
			}
		}

		private bool useMultithreading => multithreaded;

		public event EmptySplineHandler onRebuild;

		private void Awake()
		{
			ResampleTransform();
		}

		private void FixedUpdate()
		{
			if (updateMode == UpdateMode.FixedUpdate || updateMode == UpdateMode.AllUpdate)
			{
				RunUpdate();
			}
		}

		private void LateUpdate()
		{
			if (updateMode == UpdateMode.LateUpdate || updateMode == UpdateMode.AllUpdate)
			{
				RunUpdate();
			}
		}

		private void Update()
		{
			if (updateMode == UpdateMode.Update || updateMode == UpdateMode.AllUpdate)
			{
				RunUpdate();
			}
		}

		private void RunUpdate(bool immediate = false)
		{
			bool flag = ResampleTransformIfNeeded();
			if (_sampleCollection.samples.Length != _rawSamples.Length)
			{
				flag = true;
			}
			if (useMultithreading && _queueRebuild)
			{
				RebuildUsers(immediate);
			}
			if (_queueResample)
			{
				if (useMultithreading)
				{
					if (flag)
					{
						SplineThreading.Run(CalculateWithoutTransform);
					}
					else
					{
						SplineThreading.Run(CalculateWithTransform);
					}
				}
				else
				{
					CalculateSamples(!flag);
				}
			}
			if (flag)
			{
				if (useMultithreading)
				{
					SplineThreading.Run(TransformSamples);
				}
				else
				{
					TransformSamples();
				}
			}
			if (!useMultithreading && _queueRebuild)
			{
				RebuildUsers(immediate);
			}
			void CalculateWithTransform()
			{
				CalculateSamples();
			}
			void CalculateWithoutTransform()
			{
				CalculateSamples(transformSamples: false);
			}
		}

		private void OnEnable()
		{
			if (_rebuildPending)
			{
				_rebuildPending = false;
				Rebuild();
			}
		}

		public void GetSamples(SampleCollection collection)
		{
			UpdateSampleCollection();
			collection.samples = _sampleCollection.samples;
			collection.optimizedIndices = _sampleCollection.optimizedIndices;
			collection.sampleMode = _sampleMode;
		}

		private void UpdateSampleCollection()
		{
			if (_sampleCollection.samples.Length != _rawSamples.Length)
			{
				TransformSamples();
			}
		}

		private bool ResampleTransformIfNeeded()
		{
			bool result = false;
			if (!trs.hasChanged)
			{
				return false;
			}
			trs.hasChanged = false;
			if (_localToWorldMatrix != trs.localToWorldMatrix)
			{
				ResampleTransform();
				_queueRebuild = true;
				result = true;
			}
			return result;
		}

		public void ResampleTransform()
		{
			_localToWorldMatrix = trs.localToWorldMatrix;
			_worldToLocalMatrix = trs.worldToLocalMatrix;
		}

		public void Subscribe(SplineUser input)
		{
			if (!IsSubscribed(input))
			{
				ArrayUtility.Add(ref _subscribers, input);
			}
		}

		public void Unsubscribe(SplineUser input)
		{
			for (int i = 0; i < _subscribers.Length; i++)
			{
				if (_subscribers[i] == input)
				{
					ArrayUtility.RemoveAt(ref _subscribers, i);
					break;
				}
			}
		}

		public bool IsSubscribed(SplineUser user)
		{
			for (int i = 0; i < _subscribers.Length; i++)
			{
				if (_subscribers[i] == user)
				{
					return true;
				}
			}
			return false;
		}

		public SplineUser[] GetSubscribers()
		{
			SplineUser[] array = new SplineUser[_subscribers.Length];
			_subscribers.CopyTo(array, 0);
			return array;
		}

		public SplinePoint[] GetPoints(Space getSpace = Space.World)
		{
			SplinePoint[] array = new SplinePoint[_spline.points.Length];
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = _spline.points[i];
				if (_space == Space.Local && getSpace == Space.World)
				{
					array[i].position = TransformPoint(array[i].position);
					array[i].tangent = TransformPoint(array[i].tangent);
					array[i].tangent2 = TransformPoint(array[i].tangent2);
					array[i].normal = TransformDirection(array[i].normal);
				}
			}
			return array;
		}

		public SplinePoint GetPoint(int index, Space getSpace = Space.World)
		{
			if (index < 0 || index >= _spline.points.Length)
			{
				return default(SplinePoint);
			}
			if (_space == Space.Local && getSpace == Space.World)
			{
				ResampleTransformIfNeeded();
				SplinePoint result = _spline.points[index];
				result.position = TransformPoint(result.position);
				result.tangent = TransformPoint(result.tangent);
				result.tangent2 = TransformPoint(result.tangent2);
				result.normal = TransformDirection(result.normal);
				return result;
			}
			return _spline.points[index];
		}

		public Vector3 GetPointPosition(int index, Space getSpace = Space.World)
		{
			if (_space == Space.Local && getSpace == Space.World)
			{
				ResampleTransformIfNeeded();
				return TransformPoint(_spline.points[index].position);
			}
			return _spline.points[index].position;
		}

		public Vector3 GetPointNormal(int index, Space getSpace = Space.World)
		{
			if (_space == Space.Local && getSpace == Space.World)
			{
				ResampleTransformIfNeeded();
				return TransformDirection(_spline.points[index].normal).normalized;
			}
			return _spline.points[index].normal;
		}

		public Vector3 GetPointTangent(int index, Space getSpace = Space.World)
		{
			if (_space == Space.Local && getSpace == Space.World)
			{
				ResampleTransformIfNeeded();
				return TransformPoint(_spline.points[index].tangent);
			}
			return _spline.points[index].tangent;
		}

		public Vector3 GetPointTangent2(int index, Space getSpace = Space.World)
		{
			if (_space == Space.Local && getSpace == Space.World)
			{
				ResampleTransformIfNeeded();
				return TransformPoint(_spline.points[index].tangent2);
			}
			return _spline.points[index].tangent2;
		}

		public float GetPointSize(int index, Space getSpace = Space.World)
		{
			return _spline.points[index].size;
		}

		public Color GetPointColor(int index, Space getSpace = Space.World)
		{
			return _spline.points[index].color;
		}

		private void Make2D(ref SplinePoint point)
		{
			point.Flatten(LinearAlgebraUtility.Axis.Z);
		}

		public void SetPoints(SplinePoint[] points, Space setSpace = Space.World)
		{
			ResampleTransformIfNeeded();
			bool flag = false;
			if (points.Length != _spline.points.Length)
			{
				flag = true;
				if (points.Length < 3)
				{
					Break();
				}
				_spline.points = new SplinePoint[points.Length];
				SetAllDirty();
			}
			for (int i = 0; i < points.Length; i++)
			{
				SplinePoint point = points[i];
				if (_spline.points.Length > i)
				{
					point.isDirty = _spline.points[i].isDirty;
				}
				if (_space == Space.Local && setSpace == Space.World)
				{
					point.position = InverseTransformPoint(points[i].position);
					point.tangent = InverseTransformPoint(points[i].tangent);
					point.tangent2 = InverseTransformPoint(points[i].tangent2);
					point.normal = InverseTransformDirection(points[i].normal);
				}
				if (_is2D)
				{
					Make2D(ref point);
				}
				if (point != _spline.points[i])
				{
					point.isDirty = true;
					flag = true;
				}
				_spline.points[i] = point;
			}
			if (flag)
			{
				Rebuild();
				UpdateConnectedNodes(points);
			}
		}

		public void SetPointPosition(int index, Vector3 pos, Space setSpace = Space.World)
		{
			if (index >= 0)
			{
				ResampleTransformIfNeeded();
				if (index >= _spline.points.Length)
				{
					AppendPoints(index + 1 - _spline.points.Length);
				}
				Vector3 vector = pos;
				if (_space == Space.Local && setSpace == Space.World)
				{
					vector = InverseTransformPoint(pos);
				}
				if (vector != _spline.points[index].position)
				{
					SetDirty(index);
					_spline.points[index].SetPosition(vector);
					Rebuild();
					SetNodeForPoint(index, GetPoint(index));
				}
			}
		}

		public void SetPointTangents(int index, Vector3 tan1, Vector3 tan2, Space setSpace = Space.World)
		{
			if (index >= 0)
			{
				ResampleTransformIfNeeded();
				if (index >= _spline.points.Length)
				{
					AppendPoints(index + 1 - _spline.points.Length);
				}
				Vector3 vector = tan1;
				Vector3 vector2 = tan2;
				if (_space == Space.Local && setSpace == Space.World)
				{
					vector = InverseTransformPoint(tan1);
					vector2 = InverseTransformPoint(tan2);
				}
				bool flag = false;
				if (vector2 != _spline.points[index].tangent2)
				{
					flag = true;
					_spline.points[index].SetTangent2Position(vector2);
				}
				if (vector != _spline.points[index].tangent)
				{
					flag = true;
					_spline.points[index].SetTangentPosition(vector);
				}
				if (_is2D)
				{
					Make2D(ref _spline.points[index]);
				}
				if (flag)
				{
					SetDirty(index);
					Rebuild();
					SetNodeForPoint(index, GetPoint(index));
				}
			}
		}

		public void SetPointNormal(int index, Vector3 nrm, Space setSpace = Space.World)
		{
			if (index < 0)
			{
				return;
			}
			ResampleTransformIfNeeded();
			if (index >= _spline.points.Length)
			{
				AppendPoints(index + 1 - _spline.points.Length);
			}
			Vector3 vector = nrm;
			if (_space == Space.Local && setSpace == Space.World)
			{
				vector = InverseTransformDirection(nrm);
			}
			if (vector != _spline.points[index].normal)
			{
				SetDirty(index);
				_spline.points[index].normal = vector;
				if (_is2D)
				{
					Make2D(ref _spline.points[index]);
				}
				Rebuild();
				SetNodeForPoint(index, GetPoint(index));
			}
		}

		public void SetPointSize(int index, float size)
		{
			if (index >= 0)
			{
				if (index >= _spline.points.Length)
				{
					AppendPoints(index + 1 - _spline.points.Length);
				}
				if (size != _spline.points[index].size)
				{
					SetDirty(index);
					_spline.points[index].size = size;
					Rebuild();
					SetNodeForPoint(index, GetPoint(index));
				}
			}
		}

		public void SetPointColor(int index, Color color)
		{
			if (index >= 0)
			{
				if (index >= _spline.points.Length)
				{
					AppendPoints(index + 1 - _spline.points.Length);
				}
				if (color != _spline.points[index].color)
				{
					SetDirty(index);
					_spline.points[index].color = color;
					Rebuild();
					SetNodeForPoint(index, GetPoint(index));
				}
			}
		}

		public void SetPoint(int index, SplinePoint point, Space setSpace = Space.World)
		{
			if (index >= 0)
			{
				ResampleTransformIfNeeded();
				if (index >= _spline.points.Length)
				{
					AppendPoints(index + 1 - _spline.points.Length);
				}
				SplinePoint point2 = point;
				if (_space == Space.Local && setSpace == Space.World)
				{
					point2.position = InverseTransformPoint(point.position);
					point2.tangent = InverseTransformPoint(point.tangent);
					point2.tangent2 = InverseTransformPoint(point.tangent2);
					point2.normal = InverseTransformDirection(point.normal);
				}
				if (_is2D)
				{
					Make2D(ref point2);
				}
				if (point2 != _spline.points[index])
				{
					point2.isDirty = true;
					_spline.points[index] = point2;
					Rebuild();
					SetNodeForPoint(index, point);
				}
			}
		}

		private void AppendPoints(int count)
		{
			SplinePoint[] array = new SplinePoint[_spline.points.Length + count];
			_spline.points.CopyTo(array, 0);
			_spline.points = array;
			Rebuild(forceUpdateAll: true);
		}

		public double GetPointPercent(int pointIndex)
		{
			double num = DMath.Clamp01((double)pointIndex / (double)(_spline.points.Length - 1));
			if (_spline.isClosed)
			{
				num = DMath.Clamp01((double)pointIndex / (double)_spline.points.Length);
			}
			if (_sampleMode != SampleMode.Uniform)
			{
				return num;
			}
			if (_originalSamplePercents.Length <= 1)
			{
				return 0.0;
			}
			for (int num2 = _originalSamplePercents.Length - 2; num2 >= 0; num2--)
			{
				if (_originalSamplePercents[num2] < num)
				{
					double t = DMath.InverseLerp(_originalSamplePercents[num2], _originalSamplePercents[num2 + 1], num);
					return DMath.Lerp(_rawSamples[num2].percent, _rawSamples[num2 + 1].percent, t);
				}
			}
			return 0.0;
		}

		public int PercentToPointIndex(double percent, Spline.Direction direction = Spline.Direction.Forward)
		{
			int num = _spline.points.Length - 1;
			if (isClosed)
			{
				num = _spline.points.Length;
			}
			if (_sampleMode == SampleMode.Uniform)
			{
				GetSamplingValues(percent, out var index, out var lerp);
				if (lerp > 0.0 && index < _originalSamplePercents.Length - 1)
				{
					lerp = DMath.Lerp(_originalSamplePercents[index], _originalSamplePercents[index + 1], lerp);
					if (direction == Spline.Direction.Forward)
					{
						return DMath.FloorInt(lerp * (double)num);
					}
					return DMath.CeilInt(lerp * (double)num);
				}
				if (direction == Spline.Direction.Forward)
				{
					return DMath.FloorInt(_originalSamplePercents[index] * (double)num);
				}
				return DMath.CeilInt(_originalSamplePercents[index] * (double)num);
			}
			int num2 = 0;
			num2 = ((direction != Spline.Direction.Forward) ? DMath.CeilInt(percent * (double)num) : DMath.FloorInt(percent * (double)num));
			if (num2 >= _spline.points.Length)
			{
				num2 = 0;
			}
			return num2;
		}

		public Vector3 EvaluatePosition(double percent)
		{
			return EvaluatePosition(percent, EvaluateMode.Cached);
		}

		public Vector3 EvaluatePosition(double percent, EvaluateMode mode = EvaluateMode.Cached)
		{
			if (mode == EvaluateMode.Calculate)
			{
				return TransformPoint(_spline.EvaluatePosition(percent));
			}
			UpdateSampleCollection();
			return _sampleCollection.EvaluatePosition(percent);
		}

		public Vector3 EvaluatePosition(int pointIndex, EvaluateMode mode = EvaluateMode.Cached)
		{
			return EvaluatePosition(GetPointPercent(pointIndex), mode);
		}

		public SplineSample Evaluate(double percent)
		{
			return Evaluate(percent, EvaluateMode.Cached);
		}

		public SplineSample Evaluate(double percent, EvaluateMode mode = EvaluateMode.Cached)
		{
			SplineSample result = default(SplineSample);
			Evaluate(percent, ref result, mode);
			return result;
		}

		public SplineSample Evaluate(int pointIndex)
		{
			SplineSample result = default(SplineSample);
			Evaluate(pointIndex, ref result);
			return result;
		}

		public void Evaluate(int pointIndex, ref SplineSample result)
		{
			Evaluate(GetPointPercent(pointIndex), ref result);
		}

		public void Evaluate(double percent, ref SplineSample result)
		{
			Evaluate(percent, ref result, EvaluateMode.Cached);
		}

		public void Evaluate(double percent, ref SplineSample result, EvaluateMode mode = EvaluateMode.Cached)
		{
			if (mode == EvaluateMode.Calculate)
			{
				_spline.Evaluate(percent, ref result);
				TransformSample(ref result);
			}
			else
			{
				UpdateSampleCollection();
				_sampleCollection.Evaluate(percent, ref result);
			}
		}

		public void Evaluate(ref SplineSample[] results, double from = 0.0, double to = 1.0)
		{
			UpdateSampleCollection();
			_sampleCollection.Evaluate(ref results, from, to);
		}

		public void EvaluatePositions(ref Vector3[] positions, double from = 0.0, double to = 1.0)
		{
			UpdateSampleCollection();
			_sampleCollection.EvaluatePositions(ref positions, from, to);
		}

		public double Travel(double start, float distance, out float moved, Spline.Direction direction = Spline.Direction.Forward)
		{
			UpdateSampleCollection();
			return _sampleCollection.Travel(start, distance, direction, out moved);
		}

		public double Travel(double start, float distance, Spline.Direction direction = Spline.Direction.Forward)
		{
			float moved;
			return Travel(start, distance, out moved, direction);
		}

		public double TravelUnclampedLoop(double start, float distance, out float moved, Spline.Direction direction = Spline.Direction.Forward)
		{
			UpdateSampleCollection();
			return _sampleCollection.TravelUnclampedLoop(start, distance, direction, out moved);
		}

		public void ApplyFloatingOriginOffset(Vector3 offset)
		{
			SplineSample[] samples = _sampleCollection.samples;
			for (int i = 0; i < samples.Length; i++)
			{
				samples[i].position += offset;
			}
		}

		[Obsolete("This project override is obsolete, please use Project(Vector3 position, ref SplineSample result, double from = 0.0, double to = 1.0, EvaluateMode mode = EvaluateMode.Cached, int subdivisions = 4) instead")]
		public void Project(ref SplineSample result, Vector3 position, double from = 0.0, double to = 1.0, EvaluateMode mode = EvaluateMode.Cached, int subdivisions = 4)
		{
			Project(position, ref result, from, to, mode, subdivisions);
		}

		public void Project(Vector3 worldPoint, ref SplineSample result, double from = 0.0, double to = 1.0, EvaluateMode mode = EvaluateMode.Cached, int subdivisions = 4)
		{
			if (mode == EvaluateMode.Calculate)
			{
				worldPoint = InverseTransformPoint(worldPoint);
				double percent = _spline.Project(InverseTransformPoint(worldPoint), subdivisions, from, to);
				_spline.Evaluate(percent, ref result);
				TransformSample(ref result);
			}
			else
			{
				UpdateSampleCollection();
				_sampleCollection.Project(worldPoint, _spline.points.Length, ref result, from, to);
			}
		}

		public SplineSample Project(Vector3 worldPoint, double from = 0.0, double to = 1.0)
		{
			SplineSample result = default(SplineSample);
			Project(worldPoint, ref result, from, to);
			return result;
		}

		public float CalculateLength(double from = 0.0, double to = 1.0)
		{
			if (!hasSamples)
			{
				return 0f;
			}
			UpdateSampleCollection();
			return _sampleCollection.CalculateLength(from, to);
		}

		private void TransformSample(ref SplineSample result)
		{
			result.position = _localToWorldMatrix.MultiplyPoint3x4(result.position);
			result.forward = _localToWorldMatrix.MultiplyVector(result.forward);
			result.up = _localToWorldMatrix.MultiplyVector(result.up);
		}

		public void Rebuild(bool forceUpdateAll = false)
		{
			if (forceUpdateAll)
			{
				SetAllDirty();
			}
			_queueResample = updateMode != UpdateMode.None;
		}

		public void RebuildImmediate()
		{
			RebuildImmediate(calculateSamples: true, forceUpdateAll: true);
		}

		public void RebuildImmediate(bool calculateSamples = true, bool forceUpdateAll = false)
		{
			if (calculateSamples)
			{
				_queueResample = true;
				if (forceUpdateAll)
				{
					SetAllDirty();
				}
			}
			else
			{
				_queueResample = false;
			}
			RunUpdate(immediate: true);
		}

		private void RebuildUsers(bool immediate = false)
		{
			for (int num = _subscribers.Length - 1; num >= 0; num--)
			{
				if (_subscribers[num] != null)
				{
					if (immediate)
					{
						_subscribers[num].RebuildImmediate();
					}
					else
					{
						_subscribers[num].Rebuild();
					}
				}
				else
				{
					ArrayUtility.RemoveAt(ref _subscribers, num);
				}
			}
			if (this.onRebuild != null)
			{
				this.onRebuild();
			}
			_queueRebuild = false;
		}

		private void SetAllDirty()
		{
			for (int i = 0; i < _spline.points.Length; i++)
			{
				_spline.points[i].isDirty = true;
			}
		}

		private void SetDirty(int index)
		{
			if (sampleMode == SampleMode.Uniform)
			{
				SetAllDirty();
			}
			else
			{
				_spline.points[index].isDirty = true;
			}
		}

		private void CalculateSamples(bool transformSamples = true)
		{
			_queueResample = false;
			_queueRebuild = true;
			if (_spline.points.Length == 0)
			{
				if (_rawSamples.Length != 0)
				{
					_rawSamples = new SplineSample[0];
					if (transformSamples)
					{
						TransformSamples();
					}
				}
				return;
			}
			if (_spline.points.Length == 1)
			{
				if (_rawSamples.Length != 1)
				{
					_rawSamples = new SplineSample[1];
					if (transformSamples)
					{
						TransformSamples();
					}
				}
				_spline.Evaluate(0.0, ref _rawSamples[0]);
				return;
			}
			if (_sampleMode == SampleMode.Uniform)
			{
				_spline.EvaluateUniform(ref _rawSamples, ref _originalSamplePercents);
				if (transformSamples)
				{
					TransformSamples();
				}
			}
			else
			{
				if (_originalSamplePercents.Length != 0)
				{
					_originalSamplePercents = new double[0];
				}
				if (_rawSamples.Length != _spline.iterations)
				{
					_rawSamples = new SplineSample[_spline.iterations];
					for (int i = 0; i < _rawSamples.Length; i++)
					{
						_rawSamples[i] = default(SplineSample);
					}
				}
				if (_sampleCollection.samples.Length != _rawSamples.Length)
				{
					_sampleCollection.samples = new SplineSample[_rawSamples.Length];
				}
				for (int j = 0; j < _rawSamples.Length; j++)
				{
					double percent = (double)j / (double)(_rawSamples.Length - 1);
					if (IsDirtySample(percent))
					{
						_spline.Evaluate(percent, ref _rawSamples[j]);
						_sampleCollection.samples[j].FastCopy(ref _rawSamples[j]);
						if (transformSamples && _space == Space.Local)
						{
							TransformSample(ref _sampleCollection.samples[j]);
						}
					}
				}
				if (_sampleMode == SampleMode.Optimized && _rawSamples.Length > 2)
				{
					OptimizeSamples(space == Space.Local);
				}
				else if (_sampleCollection.optimizedIndices.Length != 0)
				{
					_sampleCollection.optimizedIndices = new int[0];
				}
			}
			_sampleCollection.sampleMode = _sampleMode;
			hasSamples = _sampleCollection.length > 0;
			for (int k = 0; k < _spline.points.Length; k++)
			{
				_spline.points[k].isDirty = false;
			}
		}

		private void OptimizeSamples(bool transformSamples)
		{
			if (_sampleCollection.optimizedIndices.Length != _rawSamples.Length)
			{
				_sampleCollection.optimizedIndices = new int[_rawSamples.Length];
			}
			Vector3 vector = _rawSamples[0].forward;
			List<SplineSample> list = new List<SplineSample>();
			for (int i = 0; i < _rawSamples.Length; i++)
			{
				SplineSample result = _rawSamples[i];
				if (transformSamples)
				{
					TransformSample(ref result);
				}
				Vector3 vector2 = result.forward;
				if (i < _rawSamples.Length - 1)
				{
					Vector3 vector3 = _rawSamples[i + 1].position;
					if (transformSamples)
					{
						vector3 = _localToWorldMatrix.MultiplyPoint3x4(vector3);
					}
					vector2 = vector3 - result.position;
				}
				if (Vector3.Angle(vector, vector2) >= _optimizeAngleThreshold || i == 0 || i == _rawSamples.Length - 1)
				{
					list.Add(result);
					vector = vector2;
				}
				_sampleCollection.optimizedIndices[i] = list.Count - 1;
			}
			_sampleCollection.samples = list.ToArray();
		}

		private void TransformSamples()
		{
			if (_sampleCollection.samples.Length != _rawSamples.Length)
			{
				_sampleCollection.samples = new SplineSample[_rawSamples.Length];
			}
			if (_sampleMode == SampleMode.Optimized && _rawSamples.Length > 2)
			{
				OptimizeSamples(_space == Space.Local);
				return;
			}
			for (int i = 0; i < _rawSamples.Length; i++)
			{
				_sampleCollection.samples[i].FastCopy(ref _rawSamples[i]);
				if (_space == Space.Local)
				{
					TransformSample(ref _sampleCollection.samples[i]);
				}
			}
		}

		private bool IsDirtySample(double percent)
		{
			if (_sampleMode == SampleMode.Uniform)
			{
				return true;
			}
			int num = PercentToPointIndex(percent);
			int num2 = num - 1;
			int num3 = num + 2;
			if (_spline.type == Spline.Type.Bezier || _spline.type == Spline.Type.Linear)
			{
				num2 = num;
				num3 = num + 1;
			}
			int num4 = Mathf.Clamp(num2, 0, _spline.points.Length - 1);
			int num5 = Mathf.Clamp(num3, 0, _spline.points.Length - 1);
			for (int i = num4; i <= num5; i++)
			{
				if (_spline.points[i].isDirty)
				{
					return true;
				}
			}
			if (_spline.isClosed)
			{
				if (num2 < 0)
				{
					for (int j = num2 + _spline.points.Length; j < _spline.points.Length; j++)
					{
						if (_spline.points[j].isDirty)
						{
							return true;
						}
					}
				}
				if (num3 >= _spline.points.Length)
				{
					for (int k = 0; k <= num3 - _spline.points.Length; k++)
					{
						if (_spline.points[k].isDirty)
						{
							return true;
						}
					}
				}
			}
			if (num > 0 && !_spline.points[num].isDirty)
			{
				int num6 = _spline.points.Length - 1;
				if (_spline.isClosed)
				{
					num6 = _spline.points.Length;
				}
				if (Mathf.Abs((float)((double)num / (double)num6 - percent)) <= 1E-05f)
				{
					return _spline.points[num - 1].isDirty;
				}
			}
			return false;
		}

		public void Break()
		{
			Break(0);
		}

		public void Break(int at)
		{
			if (_spline.isClosed)
			{
				_spline.Break(at);
				SetAllDirty();
				Rebuild();
			}
		}

		public void Close()
		{
			if (!_spline.isClosed)
			{
				if (_spline.points.Length >= 3)
				{
					_spline.Close();
					SetAllDirty();
					Rebuild();
				}
				else
				{
					Debug.LogError("Spline " + base.name + " needs at least 3 points before it can be closed. Current points: " + _spline.points.Length);
				}
			}
		}

		public void CatToBezierTangents()
		{
			_spline.CatToBezierTangents();
			SetPoints(_spline.points, Space.Local);
		}

		public bool Raycast(out RaycastHit hit, out double hitPercent, LayerMask layerMask, double resolution = 1.0, double from = 0.0, double to = 1.0, QueryTriggerInteraction hitTriggers = QueryTriggerInteraction.UseGlobal)
		{
			resolution = DMath.Clamp01(resolution);
			Spline.FormatFromTo(ref from, ref to, preventInvert: false);
			double num = from;
			Vector3 vector = EvaluatePosition(num);
			hitPercent = 0.0;
			do
			{
				double a = num;
				num = DMath.Move(num, to, moveStep / resolution);
				Vector3 vector2 = EvaluatePosition(num);
				if (Physics.Linecast(vector, vector2, out hit, layerMask, hitTriggers))
				{
					double t = (hit.point - vector).sqrMagnitude / (vector2 - vector).sqrMagnitude;
					hitPercent = DMath.Lerp(a, num, t);
					return true;
				}
				vector = vector2;
			}
			while (num != to);
			return false;
		}

		public bool RaycastAll(out RaycastHit[] hits, out double[] hitPercents, LayerMask layerMask, double resolution = 1.0, double from = 0.0, double to = 1.0, QueryTriggerInteraction hitTriggers = QueryTriggerInteraction.UseGlobal)
		{
			resolution = DMath.Clamp01(resolution);
			Spline.FormatFromTo(ref from, ref to, preventInvert: false);
			double num = from;
			Vector3 vector = EvaluatePosition(num);
			List<RaycastHit> list = new List<RaycastHit>();
			List<double> list2 = new List<double>();
			bool result = false;
			do
			{
				double a = num;
				num = DMath.Move(num, to, moveStep / resolution);
				Vector3 vector2 = EvaluatePosition(num);
				RaycastHit[] array = Physics.RaycastAll(vector, vector2 - vector, Vector3.Distance(vector, vector2), layerMask, hitTriggers);
				for (int i = 0; i < array.Length; i++)
				{
					result = true;
					double t = (array[i].point - vector).sqrMagnitude / (vector2 - vector).sqrMagnitude;
					list2.Add(DMath.Lerp(a, num, t));
					list.Add(array[i]);
				}
				vector = vector2;
			}
			while (num != to);
			hits = list.ToArray();
			hitPercents = list2.ToArray();
			return result;
		}

		public TriggerGroup AddTriggerGroup()
		{
			TriggerGroup triggerGroup = new TriggerGroup();
			ArrayUtility.Add(ref triggerGroups, triggerGroup);
			return triggerGroup;
		}

		public SplineTrigger AddTrigger(int triggerGroup, double position, SplineTrigger.Type type)
		{
			return AddTrigger(triggerGroup, position, type, "API Trigger", Color.white);
		}

		public SplineTrigger AddTrigger(int triggerGroup, double position, SplineTrigger.Type type, string name, Color color)
		{
			while (triggerGroups.Length <= triggerGroup)
			{
				AddTriggerGroup();
			}
			return triggerGroups[triggerGroup].AddTrigger(position, type, name, color);
		}

		public void RemoveTrigger(int triggerGroup, int triggerIndex)
		{
			if (triggerGroups.Length <= triggerGroup || triggerGroup < 0)
			{
				Debug.LogError("Cannot delete trigger - trigger group " + triggerIndex + " does not exist");
			}
			else
			{
				triggerGroups[triggerGroup].RemoveTrigger(triggerIndex);
			}
		}

		public void CheckTriggers(double start, double end, SplineUser user = null)
		{
			for (int i = 0; i < triggerGroups.Length; i++)
			{
				triggerGroups[i].Check(start, end);
			}
		}

		public void CheckTriggers(int group, double start, double end)
		{
			if (group < 0 || group >= triggerGroups.Length)
			{
				Debug.LogError("Trigger group " + group + " does not exist");
			}
			else
			{
				triggerGroups[group].Check(start, end);
			}
		}

		public void ResetTriggers()
		{
			for (int i = 0; i < triggerGroups.Length; i++)
			{
				triggerGroups[i].Reset();
			}
		}

		public void ResetTriggers(int group)
		{
			if (group < 0 || group >= triggerGroups.Length)
			{
				Debug.LogError("Trigger group " + group + " does not exist");
				return;
			}
			for (int i = 0; i < triggerGroups[group].triggers.Length; i++)
			{
				triggerGroups[group].triggers[i].Reset();
			}
		}

		public List<Node.Connection> GetJunctions(int pointIndex)
		{
			for (int i = 0; i < _nodes.Length; i++)
			{
				if (_nodes[i].pointIndex == pointIndex)
				{
					return _nodes[i].GetConnections(this);
				}
			}
			return new List<Node.Connection>();
		}

		public Dictionary<int, List<Node.Connection>> GetJunctions(double start = 0.0, double end = 1.0)
		{
			UpdateSampleCollection();
			_sampleCollection.GetSamplingValues(start, out var _, out var _);
			Dictionary<int, List<Node.Connection>> dictionary = new Dictionary<int, List<Node.Connection>>();
			float num = (float)(_spline.points.Length - 1) * (float)start;
			float num2 = (float)(_spline.points.Length - 1) * (float)end;
			for (int i = 0; i < _nodes.Length; i++)
			{
				bool flag = false;
				if (end > start && (float)_nodes[i].pointIndex > num && (float)_nodes[i].pointIndex < num2)
				{
					flag = true;
				}
				else if ((float)_nodes[i].pointIndex < num && (float)_nodes[i].pointIndex > num2)
				{
					flag = true;
				}
				if (!flag && Mathf.Abs(num - (float)_nodes[i].pointIndex) <= 0.0001f)
				{
					flag = true;
				}
				if (!flag && Mathf.Abs(num2 - (float)_nodes[i].pointIndex) <= 0.0001f)
				{
					flag = true;
				}
				if (flag)
				{
					dictionary.Add(_nodes[i].pointIndex, _nodes[i].GetConnections(this));
				}
			}
			return dictionary;
		}

		public void ConnectNode(Node node, int pointIndex)
		{
			if (node == null)
			{
				Debug.LogError("Missing Node");
				return;
			}
			if (pointIndex < 0 || pointIndex >= _spline.points.Length)
			{
				Debug.Log("Invalid point index " + pointIndex);
				return;
			}
			for (int i = 0; i < _nodes.Length; i++)
			{
				if (_nodes[i].node == null || (_nodes[i].pointIndex != pointIndex && !(_nodes[i].node == node)))
				{
					continue;
				}
				Node.Connection[] connections = _nodes[i].node.GetConnections();
				for (int j = 0; j < connections.Length; j++)
				{
					if (connections[j].spline == this)
					{
						Debug.LogError("Node " + node.name + " is already connected to spline " + base.name + " at point " + _nodes[i].pointIndex);
						return;
					}
				}
				AddNodeLink(node, pointIndex);
				Debug.Log("Node link already exists");
				return;
			}
			node.AddConnection(this, pointIndex);
			AddNodeLink(node, pointIndex);
		}

		public void DisconnectNode(int pointIndex)
		{
			for (int i = 0; i < _nodes.Length; i++)
			{
				if (_nodes[i].pointIndex == pointIndex)
				{
					_nodes[i].node.RemoveConnection(this, pointIndex);
					ArrayUtility.RemoveAt(ref _nodes, i);
					break;
				}
			}
		}

		private void AddNodeLink(Node node, int pointIndex)
		{
			NodeLink nodeLink = new NodeLink();
			nodeLink.node = node;
			nodeLink.pointIndex = pointIndex;
			ArrayUtility.Add(ref _nodes, nodeLink);
			UpdateConnectedNodes();
		}

		public Dictionary<int, Node> GetNodes(double start = 0.0, double end = 1.0)
		{
			UpdateSampleCollection();
			_sampleCollection.GetSamplingValues(start, out var _, out var _);
			Dictionary<int, Node> dictionary = new Dictionary<int, Node>();
			float num = (float)(_spline.points.Length - 1) * (float)start;
			float num2 = (float)(_spline.points.Length - 1) * (float)end;
			for (int i = 0; i < _nodes.Length; i++)
			{
				bool flag = false;
				if (end > start && (float)_nodes[i].pointIndex > num && (float)_nodes[i].pointIndex < num2)
				{
					flag = true;
				}
				else if ((float)_nodes[i].pointIndex < num && (float)_nodes[i].pointIndex > num2)
				{
					flag = true;
				}
				if (!flag && Mathf.Abs(num - (float)_nodes[i].pointIndex) <= 0.0001f)
				{
					flag = true;
				}
				if (!flag && Mathf.Abs(num2 - (float)_nodes[i].pointIndex) <= 0.0001f)
				{
					flag = true;
				}
				if (flag)
				{
					dictionary.Add(_nodes[i].pointIndex, _nodes[i].node);
				}
			}
			return dictionary;
		}

		public Node GetNode(int pointIndex)
		{
			if (pointIndex < 0 || pointIndex >= _spline.points.Length)
			{
				return null;
			}
			for (int i = 0; i < _nodes.Length; i++)
			{
				if (_nodes[i].pointIndex == pointIndex)
				{
					return _nodes[i].node;
				}
			}
			return null;
		}

		public void TransferNode(int pointIndex, int newPointIndex)
		{
			if (newPointIndex < 0 || newPointIndex >= _spline.points.Length)
			{
				Debug.LogError("Invalid new point index " + newPointIndex);
				return;
			}
			if (GetNode(newPointIndex) != null)
			{
				Debug.LogError("Cannot move node to point " + newPointIndex + ". Point already connected to a node");
				return;
			}
			Node node = GetNode(pointIndex);
			if (node == null)
			{
				Debug.LogError("No node connected to point " + pointIndex);
				return;
			}
			DisconnectNode(pointIndex);
			SplineSample splineSample = Evaluate(newPointIndex);
			node.transform.position = splineSample.position;
			node.transform.rotation = splineSample.rotation;
			ConnectNode(node, newPointIndex);
		}

		public void ShiftNodes(int startIndex, int endIndex, int shift)
		{
			int num = endIndex;
			int num2 = startIndex;
			if (startIndex > endIndex)
			{
				num = startIndex;
				num2 = endIndex;
			}
			for (int num3 = num; num3 >= num2; num3--)
			{
				if (GetNode(num3) != null)
				{
					TransferNode(num3, num3 + shift);
				}
			}
		}

		public void GetConnectedComputers(List<SplineComputer> computers, List<int> connectionIndices, List<int> connectedIndices, double percent, Spline.Direction direction, bool includeEqual)
		{
			if (computers == null)
			{
				computers = new List<SplineComputer>();
			}
			if (connectionIndices == null)
			{
				connectionIndices = new List<int>();
			}
			if (connectedIndices == null)
			{
				connectionIndices = new List<int>();
			}
			computers.Clear();
			connectionIndices.Clear();
			connectedIndices.Clear();
			int num = Mathf.FloorToInt((float)(_spline.points.Length - 1) * (float)percent);
			for (int i = 0; i < _nodes.Length; i++)
			{
				bool flag = false;
				if (includeEqual)
				{
					flag = ((direction != Spline.Direction.Forward) ? (_nodes[i].pointIndex <= num) : (_nodes[i].pointIndex >= num));
				}
				if (!flag)
				{
					continue;
				}
				Node.Connection[] connections = _nodes[i].node.GetConnections();
				for (int j = 0; j < connections.Length; j++)
				{
					if (connections[j].spline != this)
					{
						computers.Add(connections[j].spline);
						connectionIndices.Add(_nodes[i].pointIndex);
						connectedIndices.Add(connections[j].pointIndex);
					}
				}
			}
		}

		public List<SplineComputer> GetConnectedComputers()
		{
			List<SplineComputer> computers = new List<SplineComputer>();
			computers.Add(this);
			if (_nodes.Length == 0)
			{
				return computers;
			}
			GetConnectedComputers(ref computers);
			return computers;
		}

		public void GetSamplingValues(double percent, out int index, out double lerp)
		{
			UpdateSampleCollection();
			_sampleCollection.GetSamplingValues(percent, out index, out lerp);
		}

		private void GetConnectedComputers(ref List<SplineComputer> computers)
		{
			SplineComputer splineComputer = computers[computers.Count - 1];
			if (splineComputer == null)
			{
				return;
			}
			for (int i = 0; i < splineComputer._nodes.Length; i++)
			{
				if (splineComputer._nodes[i].node == null)
				{
					continue;
				}
				Node.Connection[] connections = splineComputer._nodes[i].node.GetConnections();
				for (int j = 0; j < connections.Length; j++)
				{
					bool flag = false;
					if (connections[j].spline == this)
					{
						continue;
					}
					for (int k = 0; k < computers.Count; k++)
					{
						if (computers[k] == connections[j].spline)
						{
							flag = true;
							break;
						}
					}
					if (!flag)
					{
						computers.Add(connections[j].spline);
						GetConnectedComputers(ref computers);
					}
				}
			}
		}

		private void RemoveNodeLinkAt(int index)
		{
			NodeLink[] array = new NodeLink[_nodes.Length - 1];
			for (int i = 0; i < _nodes.Length; i++)
			{
				if (i != index)
				{
					if (i < index)
					{
						array[i] = _nodes[i];
					}
					else
					{
						array[i - 1] = _nodes[i];
					}
				}
			}
			_nodes = array;
		}

		private void SetNodeForPoint(int index, SplinePoint worldPoint)
		{
			for (int i = 0; i < _nodes.Length; i++)
			{
				if (_nodes[i].pointIndex == index)
				{
					_nodes[i].node.UpdatePoint(this, _nodes[i].pointIndex, worldPoint);
					break;
				}
			}
		}

		private void UpdateConnectedNodes(SplinePoint[] worldPoints)
		{
			for (int i = 0; i < _nodes.Length; i++)
			{
				if (_nodes[i].node == null)
				{
					RemoveNodeLinkAt(i);
					i--;
					Rebuild();
					continue;
				}
				bool flag = false;
				Node.Connection[] connections = _nodes[i].node.GetConnections();
				for (int j = 0; j < connections.Length; j++)
				{
					if (connections[j].spline == this)
					{
						flag = true;
						break;
					}
				}
				if (!flag)
				{
					RemoveNodeLinkAt(i);
					i--;
					Rebuild();
				}
				else
				{
					_nodes[i].node.UpdatePoint(this, _nodes[i].pointIndex, worldPoints[_nodes[i].pointIndex]);
					_nodes[i].node.UpdateConnectedComputers(this);
				}
			}
		}

		private void UpdateConnectedNodes()
		{
			for (int i = 0; i < _nodes.Length; i++)
			{
				if (_nodes[i] == null || _nodes[i].node == null)
				{
					RemoveNodeLinkAt(i);
					Rebuild();
					i--;
					continue;
				}
				bool flag = false;
				Node.Connection[] connections = _nodes[i].node.GetConnections();
				for (int j = 0; j < connections.Length; j++)
				{
					if (connections[j].spline == this && connections[j].pointIndex == _nodes[i].pointIndex)
					{
						flag = true;
						break;
					}
				}
				if (flag)
				{
					_nodes[i].node.UpdatePoint(this, _nodes[i].pointIndex, GetPoint(_nodes[i].pointIndex));
					continue;
				}
				RemoveNodeLinkAt(i);
				Rebuild();
				i--;
			}
		}

		public Vector3 TransformPoint(Vector3 point)
		{
			return _localToWorldMatrix.MultiplyPoint3x4(point);
		}

		public Vector3 InverseTransformPoint(Vector3 point)
		{
			return _worldToLocalMatrix.MultiplyPoint3x4(point);
		}

		public Vector3 TransformDirection(Vector3 direction)
		{
			return _localToWorldMatrix.MultiplyVector(direction);
		}

		public Vector3 InverseTransformDirection(Vector3 direction)
		{
			return _worldToLocalMatrix.MultiplyVector(direction);
		}
	}
}
