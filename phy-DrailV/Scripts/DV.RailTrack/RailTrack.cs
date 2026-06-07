using System;
using System.Collections.Generic;
using System.Linq;
using DV.OriginShift;
using DV.PointSet;
using UnityEngine;

[RequireComponent(typeof(BezierCurve))]
public class RailTrack : MonoBehaviour
{
	public enum NoiseTaper
	{
		None = 0,
		Start = 1,
		End = 2
	}

	public const string COLLIDERS = "COLLIDERS";

	public const string TRACK_ID_GO_NAME = "[track id]";

	public const string JUNCTION_DIVERGING_TRACK_NAME = "[track diverging]";

	public const string JUNCTION_THROUGH_TRACK_NAME = "[track through]";

	public const float DEFAULT_JOINT_SPAN = 50f;

	public const float COLLIDER_RESOLUTION_BEFORE_SIMPLIFY = 0.5f;

	public const float COLLIDER_CURVE_SIMPLIFY_FACTOR = 0.7f;

	public const float COLLIDER_EXTRA_LENGTH = 1.03f;

	public const float DEFAULT_BEZIER_RESOLUTION = 0.5f;

	[Tooltip("Prevents Rail Manager from changing this track if true")]
	public bool dontChange;

	[Tooltip("Whether to generate procedural meshes (gravel, rails, sleepers & anchors) while playing")]
	public bool generateMeshes = true;

	[Tooltip("Whether to generate colliders on Start")]
	public bool generateColliders = true;

	public NoiseTaper noiseTaper;

	public float age;

	public RailType railType;

	public BaseType baseType;

	public HideFlags proceduralCollidersHideFlags;

	public Junction inJunction;

	public Junction outJunction;

	public Junction.Branch inBranch;

	public Junction.Branch outBranch;

	public bool overrideDefaultJointsSpan;

	[Tooltip("Track joints will be separated by this value in METERS. Only used for sound. Set to 0 for continuosly welded track")]
	public float jointsSpan = 50f;

	public static Dictionary<RailTrack, EquiPointSet> pointSets = new Dictionary<RailTrack, EquiPointSet>();

	private EquiPointSet pointSet;

	public Vector2[] ceilingHeightVertices;

	private BezierCurve _curve;

	[NonSerialized]
	public bool isJunctionTrack;

	private bool initialized;

	public float JointsSpan
	{
		get
		{
			if (!overrideDefaultJointsSpan)
			{
				return 50f;
			}
			return jointsSpan;
		}
	}

	public BezierCurve curve
	{
		get
		{
			if ((bool)_curve)
			{
				return _curve;
			}
			_curve = GetComponent<BezierCurve>();
			return _curve;
		}
	}

	public bool inIsConnected
	{
		get
		{
			if (!(inJunction != null))
			{
				if (inBranch != null)
				{
					return inBranch.track != null;
				}
				return false;
			}
			return true;
		}
	}

	public bool outIsConnected
	{
		get
		{
			if (!(outJunction != null))
			{
				if (outBranch != null)
				{
					return outBranch.track != null;
				}
				return false;
			}
			return true;
		}
	}

	public event Action<RailTrack> TrackPointsUpdated;

	public void TrackPointsUpdated_Invoke()
	{
		this.TrackPointsUpdated?.Invoke(this);
	}

	public void Init()
	{
		if (initialized)
		{
			return;
		}
		initialized = true;
		if (!CurveIsValid())
		{
			Debug.LogError("RailTrack '" + base.name + "' curve is not valid", this);
			return;
		}
		if (curve.resolution < 0.45f || curve.resolution > 0.55f)
		{
			Debug.LogWarning($"RailTrack '{base.name}' resolution {curve.resolution} is out of expected range, changing it to {0.5f}", this);
			curve.resolution = 0.5f;
		}
		isJunctionTrack = inJunction != null && inJunction.outBranches.Any((Junction.Branch outBranch) => outBranch.track == this);
		WarnIfCurveIsNotUsingConnected();
		WarnIfNodesAreRotated();
		WarnIfConnectionsAreDisjoint();
		GetKinkedPointSet();
		if (generateColliders)
		{
			CreateCollider();
		}
	}

	private void Awake()
	{
		Init();
	}

	private void OnDestroy()
	{
		pointSet = null;
		pointSets.Remove(this);
	}

	public Transform GetInNodeT()
	{
		if (!inJunction)
		{
			if (inBranch == null || !inBranch.track)
			{
				return null;
			}
			return inBranch.GetNode().transform;
		}
		return inJunction.transform;
	}

	public Transform GetOutNodeT()
	{
		if (!outJunction)
		{
			if (outBranch == null || !outBranch.track)
			{
				return null;
			}
			return outBranch.GetNode().transform;
		}
		return outJunction.transform;
	}

	public Junction.Branch GetInBranch()
	{
		if ((bool)inJunction)
		{
			return inJunction.GetNextBranch(this, first: true);
		}
		if (inBranch != null && inBranch.track != null)
		{
			return inBranch;
		}
		return null;
	}

	public List<Junction.Branch> GetAllInBranches()
	{
		if ((bool)inJunction)
		{
			return inJunction.GetAllNextPotentialBranches(this, first: true);
		}
		if (inBranch != null && inBranch.track != null)
		{
			return new List<Junction.Branch> { inBranch };
		}
		return null;
	}

	public Junction.Branch GetOutBranch()
	{
		if ((bool)outJunction)
		{
			return outJunction.GetNextBranch(this, first: false);
		}
		if (outBranch != null && outBranch.track != null)
		{
			return outBranch;
		}
		return null;
	}

	public List<Junction.Branch> GetAllOutBranches()
	{
		if ((bool)outJunction)
		{
			return outJunction.GetAllNextPotentialBranches(this, first: false);
		}
		if (outBranch != null && outBranch.track != null)
		{
			return new List<Junction.Branch> { outBranch };
		}
		return null;
	}

	public void ConnectInToClosestJunction()
	{
		Junction junction = FindClosestJunction(curve[0].position);
		if ((bool)junction)
		{
			inJunction = junction;
			inJunction.inBranch = new Junction.Branch(this, first: true);
			inJunction.enabled = !inJunction.enabled;
			inJunction.enabled = !inJunction.enabled;
			MoveInToConnected();
		}
		else
		{
			Debug.LogWarning("No junctions near IN have been found", this);
		}
	}

	public void ConnectOutToClosestJunction()
	{
		Junction junction = FindClosestJunction(curve.Last().position);
		if ((bool)junction)
		{
			outJunction = junction;
			outJunction.inBranch = new Junction.Branch(this, first: false);
			outJunction.enabled = !outJunction.enabled;
			outJunction.enabled = !outJunction.enabled;
			MoveOutToConnected();
		}
		else
		{
			Debug.LogWarning("No junctions near OUT have been found", this);
		}
	}

	public void MovePointToBranchEnd(BezierPoint bezierPoint, Junction.Branch branch)
	{
		if ((bool)branch.track)
		{
			bezierPoint.position = branch.GetNode().position;
		}
		Repaint();
	}

	public void ConnectInToClosestBranch()
	{
		ConnectToClosestBranch(curve[0], first: true);
	}

	public void ConnectOutToClosestBranch()
	{
		ConnectToClosestBranch(curve.Last(), first: false);
	}

	private void ConnectToClosestBranch(BezierPoint bezierPoint, bool first)
	{
		if ((bool)(first ? inJunction : outJunction))
		{
			Debug.LogWarning("There is an " + (first ? "IN" : "OUT") + " junction on this track. If you want to assign a branch, dereference junction first", this);
			return;
		}
		Junction.Branch branch = FindClosestBranch(bezierPoint.position);
		Junction.Branch branch2 = new Junction.Branch(this, first);
		if (branch != null && (bool)branch.track)
		{
			if (first)
			{
				inBranch = branch;
			}
			else
			{
				outBranch = branch;
			}
			if (branch.first)
			{
				branch.track.inBranch = branch2;
			}
			else
			{
				branch.track.outBranch = branch2;
			}
		}
		else
		{
			Debug.LogWarning("No nearby track ends have been found", this);
		}
		MovePointToBranchEnd(bezierPoint, first ? inBranch : outBranch);
	}

	public Junction FindClosestJunction(Vector3 point, float maxRange = 5f)
	{
		float num = float.PositiveInfinity;
		Junction[] junctions = RailTrackRegistryBase.Junctions;
		Junction result = null;
		Junction[] array = junctions;
		foreach (Junction junction in array)
		{
			if (!(junction == null))
			{
				float num2 = Vector3.SqrMagnitude(point - junction.transform.position);
				if (!(num2 > maxRange * maxRange) && num2 < num)
				{
					num = num2;
					result = junction;
				}
			}
		}
		return result;
	}

	public Junction.Branch FindClosestBranch(Vector3 fromPoint, float maxRange = 5f)
	{
		float num = float.PositiveInfinity;
		RailTrack[] railTracks = RailTrackRegistryBase.RailTracks;
		RailTrack railTrack = null;
		bool first = false;
		RailTrack[] array = railTracks;
		foreach (RailTrack railTrack2 in array)
		{
			if (!(railTrack2 == this) && (bool)railTrack2.curve && railTrack2.curve.pointCount >= 2)
			{
				BezierPoint bezierPoint = railTrack2.curve[0];
				BezierPoint bezierPoint2 = railTrack2.curve.Last();
				float num2 = Vector3.SqrMagnitude(fromPoint - bezierPoint.position);
				if (num2 < maxRange * maxRange && num2 < num)
				{
					num = num2;
					railTrack = railTrack2;
					first = true;
				}
				float num3 = Vector3.SqrMagnitude(fromPoint - bezierPoint2.position);
				if (num3 < maxRange * maxRange && num3 < num)
				{
					num = num3;
					railTrack = railTrack2;
					first = false;
				}
			}
		}
		if (railTrack == null)
		{
			return null;
		}
		return new Junction.Branch(railTrack, first);
	}

	public void MoveInToConnected()
	{
		Transform inNodeT = GetInNodeT();
		if ((bool)inNodeT)
		{
			curve[0].position = inNodeT.position;
		}
	}

	public void MoveOutToConnected()
	{
		Transform outNodeT = GetOutNodeT();
		if ((bool)outNodeT)
		{
			curve.Last().position = outNodeT.position;
		}
		else
		{
			Debug.Log("No T", this);
		}
	}

	public void AlignInHandle()
	{
		if (!inIsConnected)
		{
			Debug.LogError("Track not connected", this);
			return;
		}
		if ((bool)inJunction)
		{
			AlignHandleToTransformForward(curve[0], inJunction.transform);
			return;
		}
		BezierPoint bezierPoint = GetInBranch().GetBezierPoint();
		AlignHandleToBezierPoint(curve[0], bezierPoint);
	}

	public void AlignOutHandle()
	{
		if (!outIsConnected)
		{
			Debug.LogError("Track not connected", this);
			return;
		}
		if ((bool)outJunction)
		{
			AlignHandleToTransformForward(curve.Last(), outJunction.transform);
			return;
		}
		BezierPoint bezierPoint = GetOutBranch().GetBezierPoint();
		AlignHandleToBezierPoint(curve.Last(), bezierPoint);
	}

	private void AlignHandleToTransformForward(BezierPoint thisBP, Transform t)
	{
		thisBP.handle2 = GetHandleProjectedToTransformForward(thisBP, t);
	}

	private void AlignHandleToBezierPoint(BezierPoint thisBP, BezierPoint otherBP)
	{
		if ((bool)otherBP)
		{
			thisBP.handle2 = GetHandleProjectedToBezierPointDirection(thisBP, otherBP);
		}
	}

	private Vector3 GetHandleProjectedToTransformForward(BezierPoint thisBP, Transform t)
	{
		Vector3 onNormal = thisBP.transform.InverseTransformDirection(t.forward);
		return Vector3.Project(thisBP.handle2, onNormal);
	}

	private Vector3 GetHandleProjectedToBezierPointDirection(BezierPoint thisBP, BezierPoint otherBP)
	{
		if (!otherBP)
		{
			return Vector3.one;
		}
		Vector3 direction = otherBP.transform.TransformDirection(otherBP.handle1);
		Vector3 onNormal = thisBP.transform.InverseTransformDirection(direction);
		return Vector3.Project(thisBP.handle2, onNormal);
	}

	public EquiPointSet GetKinkedPointSet()
	{
		if (pointSet != null || pointSets.TryGetValue(this, out pointSet))
		{
			return pointSet;
		}
		if (!CurveIsValid())
		{
			return null;
		}
		pointSet = EquiPointSet.FromBezierEquidistant(curve, curve.resolution);
		if (pointSet == null)
		{
			return null;
		}
		if (railType != null && railType.kinkScale > 0f && railType.kinkFrequency > 0f)
		{
			KinkPointSet(pointSet, railType.kinkScale, railType.verticalKinkScale, railType.kinkFrequency, 1, 4, railType.rotationKinkScale, 1f);
		}
		pointSets.Add(this, pointSet);
		return pointSet;
	}

	public EquiPointSet GetUnkinkedPointSet(float interpolationResolution = 0f)
	{
		if (interpolationResolution <= 0f)
		{
			interpolationResolution = curve.resolution;
		}
		return EquiPointSet.FromBezierEquidistant(curve, interpolationResolution);
	}

	private void KinkPointSet(EquiPointSet pSet, float horizontalKinkScale = 1f, float verticalKinkScale = 1f, float frequency = 1f, int octaves = 4, int startEndBuffer = 4, float rotationScale = 0f, float maxOffsetInCM = -1f)
	{
		if (frequency == 0f || (horizontalKinkScale == 0f && verticalKinkScale == 0f))
		{
			return;
		}
		octaves = 1;
		for (int i = 0; i < pSet.points.Length; i++)
		{
			float num = 0f;
			float num2 = 0f;
			float num3 = 0f;
			float num4 = (float)pSet.points[i].span;
			for (int j = 0; j < octaves; j++)
			{
				num += (-0.5f + Mathf.PerlinNoise(num4 * frequency, 234.34f)) * horizontalKinkScale;
				num2 += (-0.5f + Mathf.PerlinNoise(145.54f, num4 * frequency)) * verticalKinkScale;
				num3 += (-0.5f + Mathf.PerlinNoise(4761f, num4 * frequency)) * rotationScale;
			}
			float t = 1f;
			Vector3 vector = Vector3.Cross(pSet.points[i].forward.normalized, pSet.points[i].up.normalized);
			Vector3d vector3d = new Vector3d(vector * num + Vector3.up * num2);
			if (startEndBuffer > 0)
			{
				if (i < startEndBuffer)
				{
					t = (float)i / (float)startEndBuffer;
				}
				else if (i > pSet.points.Length - startEndBuffer)
				{
					t = (float)(pSet.points.Length - 1 - i) / (float)startEndBuffer;
				}
				if (maxOffsetInCM > 0f)
				{
					float num5 = (float)vector3d.magnitude * 1000f;
					if (num5 > maxOffsetInCM)
					{
						vector3d = vector3d.normalized * Mathf.Lerp(maxOffsetInCM, num5, t) * 0.0010000000474974513;
					}
				}
			}
			if (noiseTaper != NoiseTaper.None)
			{
				float num6 = ((noiseTaper == NoiseTaper.Start) ? Mathf.InverseLerp(0f, Mathf.Min((float)pointSet.span, 1f), num4) : Mathf.InverseLerp((float)pointSet.span, Mathf.Max((float)pointSet.span - 1f, 0f), num4));
				vector3d *= (double)num6;
				num3 *= num6;
			}
			pSet.points[i].position = pSet.points[i].position + vector3d;
			pSet.points[i].up = Quaternion.LookRotation(pSet.points[i].forward, pSet.points[i].up) * Quaternion.Euler(0f, 0f, num3) * pSet.points[i].up;
		}
		pSet.RecalculateSpans();
	}

	public void DestroyProceduralColliders()
	{
		UnityEngine.Object.DestroyImmediate(base.transform.Find("COLLIDERS")?.gameObject);
	}

	public void CreateCollider()
	{
		if (baseType == null)
		{
			Debug.LogWarning("RailTrack '" + base.name + "' won't have a collider, base type is null", this);
			return;
		}
		if (baseType.collidersPrefab == null)
		{
			Debug.LogWarning("RailTrack '" + base.name + "' won't have a collider, its base type doesn't have collidersPrefab set", this);
			return;
		}
		DestroyProceduralColliders();
		MakeColliders(this, baseType.collidersPrefab, proceduralCollidersHideFlags);
	}

	public static void MakeColliders(RailTrack railTrack, GameObject collidersPrefab, HideFlags hideFlags)
	{
		EquiPointSet unkinkedPointSet = railTrack.GetUnkinkedPointSet(0.5f);
		List<Vector3> list = new List<Vector3>();
		LineUtility.Simplify(unkinkedPointSet.points.Select((EquiPointSet.Point p) => railTrack.transform.InverseTransformPoint((Vector3)p.position)).ToList(), 0.7f, list);
		GameObject gameObject = new GameObject("COLLIDERS");
		gameObject.transform.SetParent(railTrack.transform, worldPositionStays: false);
		gameObject.hideFlags = hideFlags;
		for (int num = 0; num < list.Count - 1; num++)
		{
			Vector3 vector = list[num];
			Vector3 vector2 = list[num + 1];
			Vector3 localPosition = Vector3.Lerp(vector, vector2, 0.5f);
			Vector3 forward = vector2 - vector;
			GameObject obj = UnityEngine.Object.Instantiate(collidersPrefab);
			obj.transform.SetParent(gameObject.transform, worldPositionStays: false);
			obj.name = collidersPrefab.name;
			Vector3 localScale = obj.transform.localScale;
			localScale.z = forward.magnitude * 1.03f;
			obj.transform.localScale = localScale;
			obj.transform.localPosition = localPosition;
			obj.transform.localRotation = Quaternion.LookRotation(forward);
		}
	}

	public float SampleCeilingHeight(float t)
	{
		if (ceilingHeightVertices == null || ceilingHeightVertices.Length == 0)
		{
			return float.PositiveInfinity;
		}
		if (t <= ceilingHeightVertices[0].x)
		{
			return ceilingHeightVertices[0].y;
		}
		if (t >= ceilingHeightVertices[ceilingHeightVertices.Length - 1].x)
		{
			return ceilingHeightVertices[ceilingHeightVertices.Length - 1].y;
		}
		int num = 0;
		int num2 = ceilingHeightVertices.Length;
		while (num < num2)
		{
			int num3 = (num + num2) / 2;
			if (ceilingHeightVertices[num3].x < t)
			{
				num = num3 + 1;
			}
			else
			{
				num2 = num3;
			}
		}
		Vector2 vector = ceilingHeightVertices[num2 - 1];
		Vector2 vector2 = ceilingHeightVertices[num2];
		float num4 = vector.y + (vector2.y - vector.y) * ((t - vector.x) / (vector2.x - vector.x));
		if (!float.IsNaN(num4))
		{
			return num4;
		}
		return float.PositiveInfinity;
	}

	public bool CurveIsValid()
	{
		if (curve != null && curve.pointCount > 1 && curve[0] != null && curve.Last() != null)
		{
			return curve.resolution > 0.0001f;
		}
		return false;
	}

	public void WarnIfCurveIsNotUsingConnected()
	{
		_ = dontChange;
	}

	public bool IsCurveNotUsingConnectedBezierPoints()
	{
		if (!CurveIsValid())
		{
			return false;
		}
		for (int i = 0; i < curve.pointCount; i++)
		{
			if (curve[i].handleStyle != BezierPoint.HandleStyle.Connected && (double)(curve[i].handle1.normalized + curve[i].handle2.normalized).magnitude > 0.001)
			{
				return true;
			}
		}
		return false;
	}

	public bool WarnIfNodesAreRotated()
	{
		bool result = false;
		BezierPoint[] anchorPoints = curve.GetAnchorPoints();
		foreach (BezierPoint bezierPoint in anchorPoints)
		{
			if (bezierPoint.transform.localEulerAngles != Vector3.zero)
			{
				Debug.LogError("Track " + base.name + " has a rotated bezier point, all points must have 0,0,0 local rotation. YOU MUST FIX THAT!", bezierPoint.gameObject);
				result = true;
			}
		}
		return result;
	}

	public void WarnIfConnectionsAreDisjoint()
	{
		float dist;
		if (inJunction != null)
		{
			if (IsTooFar(curve[0], inJunction.inBranch, out dist))
			{
				Debug.LogError($"Track {base.name} inJunction inBranch is too far ({dist} m)", this);
			}
			foreach (Junction.Branch outBranch in inJunction.outBranches)
			{
				if (IsTooFar(curve[0], outBranch, out dist))
				{
					Debug.LogError($"Track {base.name} inJunction outBranch is too far ({dist} m)", this);
				}
			}
		}
		if (inBranch?.track != null && IsTooFar(curve[0], inBranch, out dist))
		{
			Debug.LogError($"Track {base.name} inBranch is too far ({dist} m)", this);
		}
		if (outJunction != null)
		{
			if (IsTooFar(curve.Last(), outJunction.inBranch, out dist))
			{
				Debug.LogError($"Track {base.name} outJunction inBranch is too far ({dist} m)", this);
			}
			foreach (Junction.Branch outBranch2 in outJunction.outBranches)
			{
				_ = outBranch2;
				if (IsTooFar(curve.Last(), outJunction.inBranch, out dist))
				{
					Debug.LogError($"Track {base.name} outJunction outBranch is too far ({dist} m)", this);
				}
			}
		}
		if (this.outBranch?.track != null && IsTooFar(curve.Last(), this.outBranch, out dist))
		{
			Debug.LogError($"Track {base.name} outBranch is too far ({dist} m)", this);
		}
		bool IsTooFar(BezierPoint point, Junction.Branch branch, out float reference)
		{
			reference = (point.position - branch.GetBezierPoint().position).magnitude;
			return reference > 0.01f;
		}
	}

	public static (RailTrack track, EquiPointSet.Point? point) GetClosest(Vector3 toPoint, float minDistFromEnd = 0f, ICollection<RailTrack> allTracks = null)
	{
		if (allTracks == null)
		{
			allTracks = RailTrackRegistryBase.RailTracks;
		}
		if (allTracks.Count == 0)
		{
			return (track: null, point: null);
		}
		RailTrack item = null;
		EquiPointSet.Point? item2 = null;
		float num = float.PositiveInfinity;
		foreach (RailTrack allTrack in allTracks)
		{
			(EquiPointSet.Point?, float) closestPoint = GetClosestPoint(allTrack, toPoint, minDistFromEnd);
			if (closestPoint.Item2 < num)
			{
				num = closestPoint.Item2;
				item = allTrack;
				item2 = closestPoint.Item1.Value;
			}
		}
		return (track: item, point: item2);
	}

	public static (EquiPointSet.Point? closestPoint, float distanceToPoint) GetClosestPoint(RailTrack track, Vector3 toPoint, float minDistFromEnd = 0f)
	{
		EquiPointSet kinkedPointSet = track.GetKinkedPointSet();
		if (kinkedPointSet == null)
		{
			return (closestPoint: null, distanceToPoint: float.PositiveInfinity);
		}
		Vector3 currentMove = OriginShift.currentMove;
		toPoint -= currentMove;
		EquiPointSet.Point? item = null;
		float num = float.PositiveInfinity;
		minDistFromEnd *= minDistFromEnd;
		int i = 0;
		Vector3d position = kinkedPointSet.points[0].position;
		Vector3d position2 = kinkedPointSet.points[kinkedPointSet.points.Length - 1].position;
		for (; i < kinkedPointSet.points.Length; i++)
		{
			EquiPointSet.Point value = kinkedPointSet.points[i];
			float num2 = Vector3.SqrMagnitude((Vector3)value.position - toPoint);
			bool flag = Vector3d.SqrMagnitude(position - value.position) >= (double)minDistFromEnd;
			bool flag2 = Vector3d.SqrMagnitude(position2 - value.position) >= (double)minDistFromEnd;
			if (num2 < num && flag && flag2)
			{
				num = num2;
				item = value;
			}
		}
		return (closestPoint: item, distanceToPoint: num);
	}

	public static EquiPointSet.Point? GetPointWithinRangeWithYOffset(RailTrack track, Vector3 targetPoint, float range, float trackPointsYOffset = 0f)
	{
		EquiPointSet kinkedPointSet = track.GetKinkedPointSet();
		if (kinkedPointSet == null)
		{
			return null;
		}
		Vector3 currentMove = OriginShift.currentMove;
		targetPoint -= currentMove;
		EquiPointSet.Point? result = null;
		float num = float.PositiveInfinity;
		float num2 = (float)kinkedPointSet.points[0].spanToNextPoint;
		bool flag = false;
		int num3;
		for (int i = 0; i < kinkedPointSet.points.Length; i += num3)
		{
			EquiPointSet.Point value = kinkedPointSet.points[i];
			float magnitude = ((Vector3)value.position + value.up * trackPointsYOffset - targetPoint).magnitude;
			num3 = 1;
			if (magnitude <= range)
			{
				flag = true;
				if (magnitude < num)
				{
					num = magnitude;
					result = value;
				}
			}
			else
			{
				if (flag)
				{
					break;
				}
				num3 = Mathf.Clamp(Mathf.FloorToInt((magnitude - range) / num2), 1, int.MaxValue);
			}
		}
		return result;
	}

	private void Repaint()
	{
	}
}
