using System;
using System.Collections.Generic;
using System.Linq;
using DV.OriginShift;
using UnityEngine;

[RequireComponent(typeof(RailTrack))]
public class TurntableRailTrack : MonoBehaviour
{
	public delegate void TracksUpdatedDelegate(RailTrack frontTrack, RailTrack backTrack);

	[Serializable]
	public class TrackEnd
	{
		public RailTrack track;

		public bool isFirst;

		public float angle;

		public Vector3 GetPosition()
		{
			return (isFirst ? track.curve[0] : track.curve.Last()).position;
		}

		public BezierPoint GetPoint()
		{
			if (!isFirst)
			{
				return track.curve.Last();
			}
			return track.curve[0];
		}
	}

	public const float ANGLE_STEP = 0.01f;

	public const float ANGLE_THRESHOLD = 0.5f;

	public const float SEARCH_RADIUS_ALLOWED_OFFSET = 0.3f;

	private const float SNAPPING_ANGLE_DISTANCE_DEGREES = 3f;

	public string uniqueID;

	public Transform visuals;

	public List<TrackEnd> trackEnds = new List<TrackEnd>();

	private RailTrack _track;

	public Transform frontHandle;

	public Transform rearHandle;

	[NonSerialized]
	public TrackEnd frontClosest;

	[NonSerialized]
	public TrackEnd rearClosest;

	[NonSerialized]
	public float targetYRotation;

	[NonSerialized]
	public float currentYRotation;

	public RailTrack Track
	{
		get
		{
			if (_track == null)
			{
				_track = GetComponent<RailTrack>();
			}
			return _track;
		}
	}

	public float SearchRadius => Track.curve.length * 0.5f;

	public event TracksUpdatedDelegate TracksUpdated;

	public bool IsTrackEndInRange(float distance)
	{
		if (distance > SearchRadius - 0.3f)
		{
			return distance < SearchRadius + 0.3f;
		}
		return false;
	}

	public void RotateToTargetRotation(bool forceConnectionRefresh = false)
	{
		float num = currentYRotation;
		currentYRotation = targetYRotation;
		float num2 = currentYRotation - num;
		if (Mathf.Abs(num2) == 0f)
		{
			if (forceConnectionRefresh)
			{
				UpdateTrackConnection();
			}
			return;
		}
		Vector3 position = base.transform.position;
		Quaternion rotationToApply = Quaternion.Euler(0f, num2, 0f);
		for (int i = 0; i < Track.curve.pointCount; i++)
		{
			BezierPoint bezierPoint = Track.curve[i];
			bezierPoint.position = RotateAroundPoint(bezierPoint.position, position, rotationToApply);
			bezierPoint.handle1 = RotateAroundPoint(bezierPoint.handle1, Vector3.zero, rotationToApply);
			if (bezierPoint.handleStyle != BezierPoint.HandleStyle.Connected)
			{
				bezierPoint.handle2 = RotateAroundPoint(bezierPoint.handle2, Vector3.zero, rotationToApply);
			}
		}
		Track.GetKinkedPointSet().RotateAroundPoint(new Vector3d(position - OriginShift.currentMove), rotationToApply);
		Track.TrackPointsUpdated_Invoke();
		visuals.Rotate(0f, num2, 0f, Space.Self);
		UpdateTrackConnection();
	}

	private Vector3 RotateAroundPoint(Vector3 position, Vector3 rotateAnchor, Quaternion rotationToApply)
	{
		Vector3 vector = position - rotateAnchor;
		Vector3 vector2 = rotationToApply * vector;
		return rotateAnchor + vector2;
	}

	private void UpdateTrackConnection()
	{
		bool flag = false;
		float num = currentYRotation;
		TrackEnd connectedTrackEndOnAngle = GetConnectedTrackEndOnAngle(num);
		if (frontClosest != connectedTrackEndOnAngle)
		{
			if (frontClosest != null)
			{
				if (frontClosest.isFirst)
				{
					frontClosest.track.inBranch = null;
					frontClosest.track.GetComponent<RailTrackLogicTrackSwitching>().UpdateLogicInTrackConnection();
				}
				else
				{
					frontClosest.track.outBranch = null;
					frontClosest.track.GetComponent<RailTrackLogicTrackSwitching>().UpdateLogicOutTrackConnection();
				}
			}
			frontClosest = connectedTrackEndOnAngle;
			if (frontClosest != null)
			{
				Junction.Branch branch = new Junction.Branch(Track, first: true);
				if (frontClosest.isFirst)
				{
					frontClosest.track.inBranch = branch;
					frontClosest.track.GetComponent<RailTrackLogicTrackSwitching>().UpdateLogicInTrackConnection();
				}
				else
				{
					frontClosest.track.outBranch = branch;
					frontClosest.track.GetComponent<RailTrackLogicTrackSwitching>().UpdateLogicOutTrackConnection();
				}
				Track.inBranch = new Junction.Branch(frontClosest.track, frontClosest.isFirst);
				Track.GetComponent<RailTrackLogicTrackSwitching>().UpdateLogicInTrackConnection();
			}
			else
			{
				Track.inBranch = null;
				Track.GetComponent<RailTrackLogicTrackSwitching>().UpdateLogicInTrackConnection();
			}
			flag = true;
		}
		TrackEnd connectedTrackEndOnAngle2 = GetConnectedTrackEndOnAngle(num + 180f);
		if (rearClosest != connectedTrackEndOnAngle2)
		{
			if (rearClosest != null)
			{
				if (rearClosest.isFirst)
				{
					rearClosest.track.inBranch = null;
					rearClosest.track.GetComponent<RailTrackLogicTrackSwitching>().UpdateLogicInTrackConnection();
				}
				else
				{
					rearClosest.track.outBranch = null;
					rearClosest.track.GetComponent<RailTrackLogicTrackSwitching>().UpdateLogicOutTrackConnection();
				}
			}
			rearClosest = connectedTrackEndOnAngle2;
			if (rearClosest != null)
			{
				Junction.Branch branch2 = new Junction.Branch(Track, first: false);
				if (rearClosest.isFirst)
				{
					rearClosest.track.inBranch = branch2;
					rearClosest.track.GetComponent<RailTrackLogicTrackSwitching>().UpdateLogicInTrackConnection();
				}
				else
				{
					rearClosest.track.outBranch = branch2;
					rearClosest.track.GetComponent<RailTrackLogicTrackSwitching>().UpdateLogicOutTrackConnection();
				}
				Track.outBranch = new Junction.Branch(rearClosest.track, rearClosest.isFirst);
				Track.GetComponent<RailTrackLogicTrackSwitching>().UpdateLogicOutTrackConnection();
			}
			else
			{
				Track.outBranch = null;
				Track.GetComponent<RailTrackLogicTrackSwitching>().UpdateLogicOutTrackConnection();
			}
			flag = true;
		}
		if (flag)
		{
			this.TracksUpdated?.Invoke(frontClosest?.track, rearClosest?.track);
		}
	}

	public float ClosestSnappingAngle()
	{
		float num = AngleRange0To360(currentYRotation);
		float num2 = AngleRange0To360(currentYRotation + 180f);
		float result = -1f;
		float num3 = float.MaxValue;
		for (int i = 0; i < trackEnds.Count; i++)
		{
			float f = AngleRangeNeg180To180(trackEnds[i].angle - num);
			f = Mathf.Abs(f);
			float f2 = AngleRangeNeg180To180(trackEnds[i].angle - num2);
			f2 = Mathf.Abs(f2);
			float num4 = ((f <= f2) ? f : f2);
			if (num4 <= 3f && num4 < num3)
			{
				num3 = num4;
				result = trackEnds[i].angle;
			}
		}
		return result;
	}

	private TrackEnd GetConnectedTrackEndOnAngle(float angle)
	{
		angle = AngleRange0To360(angle);
		for (int i = 0; i < trackEnds.Count; i++)
		{
			if (AnglesEqual(trackEnds[i].angle, angle, 0.5f))
			{
				return trackEnds[i];
			}
		}
		return null;
	}

	public static float AngleRange0To360(float angle)
	{
		if (angle < 0f)
		{
			angle += 360f;
		}
		if (angle >= 360f)
		{
			angle -= 360f;
		}
		return angle;
	}

	public static float AngleRangeNeg180To180(float angle)
	{
		if (angle >= 180f)
		{
			angle -= 360f;
		}
		if (angle < -180f)
		{
			angle += 360f;
		}
		return angle;
	}

	public static bool AnglesEqual(float angleA, float angleB, float tolerance)
	{
		return Mathf.Abs(Mathf.DeltaAngle(angleA, angleB)) < tolerance;
	}

	public static bool AnglesEqual(float angleA, float angleB)
	{
		return AnglesEqual(angleA, angleB, 0.01f);
	}

	public List<TrackEnd> FindTrackEnds()
	{
		return (from te in (from rt in UnityEngine.Object.FindObjectsOfType<RailTrack>()
				where rt != Track
				select rt).Select(GetTrackEnd)
			where te != null
			select te).ToList();
	}

	public void ResetTrackEndsAngle()
	{
		foreach (TrackEnd trackEnd in trackEnds)
		{
			trackEnd.angle = GetAngleForTrackEnd(trackEnd.GetPosition());
		}
	}

	public TrackEnd GetTrackEnd(RailTrack rt)
	{
		BezierPoint bezierPoint = rt.curve[0];
		BezierPoint bezierPoint2 = rt.curve.Last();
		Vector3 vector = (Track.curve[0].position + Track.curve.Last().position) / 2f;
		bool flag = IsTrackEndInRange(Vector3.Magnitude(bezierPoint.position - vector));
		bool flag2 = IsTrackEndInRange(Vector3.Magnitude(bezierPoint2.position - vector));
		if (flag && flag2)
		{
			Debug.LogError("Rail track '" + rt.name + "' has both ends in search radius, this will definitely cause glitches, skipping track", rt);
			return null;
		}
		if (flag)
		{
			if (rt.inJunction != null)
			{
				Debug.LogError("Rail track '" + rt.name + "' has a bad end in range, it's a junction, skipping track", rt);
				return null;
			}
			return new TrackEnd
			{
				isFirst = true,
				track = rt,
				angle = GetAngleForTrackEnd(bezierPoint.position)
			};
		}
		if (flag2)
		{
			if (rt.outJunction != null)
			{
				Debug.LogError("Rail track '" + rt.name + "' has a bad end in range, it's a junction, skipping track", rt);
				return null;
			}
			return new TrackEnd
			{
				isFirst = false,
				track = rt,
				angle = GetAngleForTrackEnd(bezierPoint2.position)
			};
		}
		return null;
	}

	private float GetAngleForTrackEnd(Vector3 trackEndPosition)
	{
		float num = float.MaxValue;
		float result = -1f;
		for (float num2 = 0f; num2 < 360f; num2 += 0.01f)
		{
			Quaternion quaternion = Quaternion.Euler(0f, num2, 0f);
			float num3 = Vector3.SqrMagnitude(trackEndPosition - (base.transform.position + quaternion * base.transform.forward * SearchRadius));
			if (num3 < num)
			{
				result = num2;
				num = num3;
			}
		}
		return result;
	}
}
