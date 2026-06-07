using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
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
				return null;
			}
		}

		[HideInInspector]
		public bool multithreaded;

		[HideInInspector]
		public UpdateMode updateMode;

		[HideInInspector]
		public TriggerGroup[] triggerGroups;

		[HideInInspector]
		[SerializeField]
		[FormerlySerializedAs("spline")]
		private Spline _spline;

		[HideInInspector]
		private SampleCollection _sampleCollection;

		[HideInInspector]
		[SerializeField]
		[FormerlySerializedAs("originalSamplePercents")]
		private double[] _originalSamplePercents;

		[HideInInspector]
		[SerializeField]
		private bool _is2D;

		[HideInInspector]
		[SerializeField]
		private bool hasSamples;

		[HideInInspector]
		[SerializeField]
		[Range(0.001f, 45f)]
		private float _optimizeAngleThreshold;

		[HideInInspector]
		[SerializeField]
		private Space _space;

		[HideInInspector]
		[SerializeField]
		private SampleMode _sampleMode;

		[HideInInspector]
		[SerializeField]
		private SplineUser[] _subscribers;

		[HideInInspector]
		[SerializeField]
		private SplineSample[] _rawSamples;

		private Matrix4x4 _localToWorldMatrix;

		private Matrix4x4 _worldToLocalMatrix;

		[HideInInspector]
		[SerializeField]
		[FormerlySerializedAs("nodes")]
		private NodeLink[] _nodes;

		private bool _rebuildPending;

		private bool _trsCached;

		private Transform _trs;

		private bool _queueResample;

		private bool _queueRebuild;

		public Space space
		{
			get
			{
				return default(Space);
			}
			set
			{
			}
		}

		public Spline.Type type
		{
			get
			{
				return default(Spline.Type);
			}
			set
			{
			}
		}

		public float knotParametrization
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public bool linearAverageDirection
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public bool is2D
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public int sampleRate
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public float optimizeAngleThreshold
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public SampleMode sampleMode
		{
			get
			{
				return default(SampleMode);
			}
			set
			{
			}
		}

		public AnimationCurve customValueInterpolation
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public AnimationCurve customNormalInterpolation
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public int iterations => 0;

		public double moveStep => 0.0;

		public bool isClosed => false;

		public int pointCount => 0;

		public int sampleCount => 0;

		public SplineSample this[int index] => default(SplineSample);

		public SplineSample[] rawSamples => null;

		public Vector3 position => default(Vector3);

		public Quaternion rotation => default(Quaternion);

		public Vector3 scale => default(Vector3);

		public int subscriberCount => 0;

		public Transform trs => null;

		private bool useMultithreading => false;

		public event EmptySplineHandler onRebuild
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

		private void Awake()
		{
		}

		private void FixedUpdate()
		{
		}

		private void LateUpdate()
		{
		}

		private void Update()
		{
		}

		private void RunUpdate(bool immediate = false)
		{
		}

		private void OnEnable()
		{
		}

		public void GetSamples(SampleCollection collection)
		{
		}

		private void UpdateSampleCollection()
		{
		}

		private bool ResampleTransformIfNeeded()
		{
			return false;
		}

		public void ResampleTransform()
		{
		}

		public void Subscribe(SplineUser input)
		{
		}

		public void Unsubscribe(SplineUser input)
		{
		}

		public bool IsSubscribed(SplineUser user)
		{
			return false;
		}

		public SplineUser[] GetSubscribers()
		{
			return null;
		}

		public SplinePoint[] GetPoints(Space getSpace = Space.World)
		{
			return null;
		}

		public SplinePoint GetPoint(int index, Space getSpace = Space.World)
		{
			return default(SplinePoint);
		}

		public Vector3 GetPointPosition(int index, Space getSpace = Space.World)
		{
			return default(Vector3);
		}

		public Vector3 GetPointNormal(int index, Space getSpace = Space.World)
		{
			return default(Vector3);
		}

		public Vector3 GetPointTangent(int index, Space getSpace = Space.World)
		{
			return default(Vector3);
		}

		public Vector3 GetPointTangent2(int index, Space getSpace = Space.World)
		{
			return default(Vector3);
		}

		public float GetPointSize(int index, Space getSpace = Space.World)
		{
			return 0f;
		}

		public Color GetPointColor(int index, Space getSpace = Space.World)
		{
			return default(Color);
		}

		private void Make2D(ref SplinePoint point)
		{
		}

		public void SetPoints(SplinePoint[] points, Space setSpace = Space.World)
		{
		}

		public void SetPointPosition(int index, Vector3 pos, Space setSpace = Space.World)
		{
		}

		public void SetPointTangents(int index, Vector3 tan1, Vector3 tan2, Space setSpace = Space.World)
		{
		}

		public void SetPointNormal(int index, Vector3 nrm, Space setSpace = Space.World)
		{
		}

		public void SetPointSize(int index, float size)
		{
		}

		public void SetPointColor(int index, Color color)
		{
		}

		public void SetPoint(int index, SplinePoint point, Space setSpace = Space.World)
		{
		}

		private void AppendPoints(int count)
		{
		}

		public double GetPointPercent(int pointIndex)
		{
			return 0.0;
		}

		public int PercentToPointIndex(double percent, Spline.Direction direction = Spline.Direction.Forward)
		{
			return 0;
		}

		public Vector3 EvaluatePosition(double percent)
		{
			return default(Vector3);
		}

		public Vector3 EvaluatePosition(double percent, EvaluateMode mode = EvaluateMode.Cached)
		{
			return default(Vector3);
		}

		public Vector3 EvaluatePosition(int pointIndex, EvaluateMode mode = EvaluateMode.Cached)
		{
			return default(Vector3);
		}

		public SplineSample Evaluate(double percent)
		{
			return default(SplineSample);
		}

		public SplineSample Evaluate(double percent, EvaluateMode mode = EvaluateMode.Cached)
		{
			return default(SplineSample);
		}

		public SplineSample Evaluate(int pointIndex)
		{
			return default(SplineSample);
		}

		public void Evaluate(int pointIndex, ref SplineSample result)
		{
		}

		public void Evaluate(double percent, ref SplineSample result)
		{
		}

		public void Evaluate(double percent, ref SplineSample result, EvaluateMode mode = EvaluateMode.Cached)
		{
		}

		public void Evaluate(ref SplineSample[] results, double from = 0.0, double to = 1.0)
		{
		}

		public void EvaluatePositions(ref Vector3[] positions, double from = 0.0, double to = 1.0)
		{
		}

		public double Travel(double start, float distance, out float moved, Spline.Direction direction = Spline.Direction.Forward)
		{
			moved = default(float);
			return 0.0;
		}

		public double Travel(double start, float distance, Spline.Direction direction = Spline.Direction.Forward)
		{
			return 0.0;
		}

		[Obsolete("This project override is obsolete, please use Project(Vector3 position, ref SplineSample result, double from = 0.0, double to = 1.0, EvaluateMode mode = EvaluateMode.Cached, int subdivisions = 4) instead")]
		public void Project(ref SplineSample result, Vector3 position, double from = 0.0, double to = 1.0, EvaluateMode mode = EvaluateMode.Cached, int subdivisions = 4)
		{
		}

		public void Project(Vector3 worldPoint, ref SplineSample result, double from = 0.0, double to = 1.0, EvaluateMode mode = EvaluateMode.Cached, int subdivisions = 4)
		{
		}

		public SplineSample Project(Vector3 worldPoint, double from = 0.0, double to = 1.0)
		{
			return default(SplineSample);
		}

		public float CalculateLength(double from = 0.0, double to = 1.0)
		{
			return 0f;
		}

		private void TransformSample(ref SplineSample result)
		{
		}

		public void Rebuild(bool forceUpdateAll = false)
		{
		}

		public void RebuildImmediate()
		{
		}

		public void RebuildImmediate(bool calculateSamples = true, bool forceUpdateAll = false)
		{
		}

		private void RebuildUsers(bool immediate = false)
		{
		}

		private void SetAllDirty()
		{
		}

		private void SetDirty(int index)
		{
		}

		private void CalculateSamples(bool transformSamples = true)
		{
		}

		private void OptimizeSamples(bool transformSamples)
		{
		}

		private void TransformSamples()
		{
		}

		private bool IsDirtySample(double percent)
		{
			return false;
		}

		public void Break()
		{
		}

		public void Break(int at)
		{
		}

		public void Close()
		{
		}

		public void CatToBezierTangents()
		{
		}

		public bool Raycast(out RaycastHit hit, out double hitPercent, LayerMask layerMask, double resolution = 1.0, double from = 0.0, double to = 1.0, QueryTriggerInteraction hitTriggers = QueryTriggerInteraction.UseGlobal)
		{
			hit = default(RaycastHit);
			hitPercent = default(double);
			return false;
		}

		public bool RaycastAll(out RaycastHit[] hits, out double[] hitPercents, LayerMask layerMask, double resolution = 1.0, double from = 0.0, double to = 1.0, QueryTriggerInteraction hitTriggers = QueryTriggerInteraction.UseGlobal)
		{
			hits = null;
			hitPercents = null;
			return false;
		}

		public TriggerGroup AddTriggerGroup()
		{
			return null;
		}

		public SplineTrigger AddTrigger(int triggerGroup, double position, SplineTrigger.Type type)
		{
			return null;
		}

		public SplineTrigger AddTrigger(int triggerGroup, double position, SplineTrigger.Type type, string name, Color color)
		{
			return null;
		}

		public void RemoveTrigger(int triggerGroup, int triggerIndex)
		{
		}

		public void CheckTriggers(double start, double end, SplineUser user = null)
		{
		}

		public void CheckTriggers(int group, double start, double end)
		{
		}

		public void ResetTriggers()
		{
		}

		public void ResetTriggers(int group)
		{
		}

		public List<Node.Connection> GetJunctions(int pointIndex)
		{
			return null;
		}

		public Dictionary<int, List<Node.Connection>> GetJunctions(double start = 0.0, double end = 1.0)
		{
			return null;
		}

		public void ConnectNode(Node node, int pointIndex)
		{
		}

		public void DisconnectNode(int pointIndex)
		{
		}

		private void AddNodeLink(Node node, int pointIndex)
		{
		}

		public Dictionary<int, Node> GetNodes(double start = 0.0, double end = 1.0)
		{
			return null;
		}

		public Node GetNode(int pointIndex)
		{
			return null;
		}

		public void TransferNode(int pointIndex, int newPointIndex)
		{
		}

		public void ShiftNodes(int startIndex, int endIndex, int shift)
		{
		}

		public void GetConnectedComputers(List<SplineComputer> computers, List<int> connectionIndices, List<int> connectedIndices, double percent, Spline.Direction direction, bool includeEqual)
		{
		}

		public List<SplineComputer> GetConnectedComputers()
		{
			return null;
		}

		public void GetSamplingValues(double percent, out int index, out double lerp)
		{
			index = default(int);
			lerp = default(double);
		}

		private void GetConnectedComputers(ref List<SplineComputer> computers)
		{
		}

		private void RemoveNodeLinkAt(int index)
		{
		}

		private void SetNodeForPoint(int index, SplinePoint worldPoint)
		{
		}

		private void UpdateConnectedNodes(SplinePoint[] worldPoints)
		{
		}

		private void UpdateConnectedNodes()
		{
		}

		public Vector3 TransformPoint(Vector3 point)
		{
			return default(Vector3);
		}

		public Vector3 InverseTransformPoint(Vector3 point)
		{
			return default(Vector3);
		}

		public Vector3 TransformDirection(Vector3 direction)
		{
			return default(Vector3);
		}

		public Vector3 InverseTransformDirection(Vector3 direction)
		{
			return default(Vector3);
		}
	}
}
