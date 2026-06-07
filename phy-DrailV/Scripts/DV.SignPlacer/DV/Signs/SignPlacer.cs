using System;
using System.Collections.Generic;
using System.Linq;
using DV.OriginShift;
using Unity.Linq;
using UnityEngine;

namespace DV.Signs
{
	public class SignPlacer : MonoBehaviour
	{
		private class CurveSegmentInfo
		{
			public BezierCurve curve;

			public float segmentLength;

			public float minRadius;

			public float bezierStartT;

			public float bezierEndT;

			public float assignedSpeed;

			public float GetSpeed()
			{
				if (!(assignedSpeed <= 0f))
				{
					return assignedSpeed;
				}
				return GetMaxSpeedForRadius();
			}

			public float GetMaxSpeedForRadius()
			{
				if (minRadius < 50f)
				{
					return 10f;
				}
				if (minRadius < 70f)
				{
					return 20f;
				}
				if (minRadius < 95f)
				{
					return 30f;
				}
				if (minRadius < 130f)
				{
					return 40f;
				}
				if (minRadius < 170f)
				{
					return 50f;
				}
				if (minRadius < 230f)
				{
					return 60f;
				}
				if (minRadius < 360f)
				{
					return 70f;
				}
				if (minRadius < 700f)
				{
					return 80f;
				}
				if (minRadius < 900f)
				{
					return 90f;
				}
				if (minRadius < 1200f)
				{
					return 100f;
				}
				return 120f;
			}

			public float GetGradeAngle()
			{
				Vector3 pointAt = curve.GetPointAt(bezierStartT);
				Vector3 pointAt2 = curve.GetPointAt(bezierEndT);
				return Mathf.Abs(pointAt.y - pointAt2.y) / Vector3.Distance(pointAt, pointAt2);
			}

			public Grade GetGrade()
			{
				Vector3 pointAt = curve.GetPointAt(bezierStartT);
				Vector3 pointAt2 = curve.GetPointAt(bezierEndT);
				if (GetGradeAngle() < 0.005f)
				{
					return Grade.Flat;
				}
				if (!(pointAt2.y > pointAt.y))
				{
					return Grade.Decline;
				}
				return Grade.Incline;
			}

			public CurveSegmentInfo ShallowCopy()
			{
				return (CurveSegmentInfo)MemberwiseClone();
			}
		}

		private class SignData
		{
			private readonly bool flip;

			private readonly BezierCurve placementCurve;

			private readonly float placementT;

			private Sign sign;

			public SignData(bool flip, BezierCurve placementCurve, float placementT)
			{
				this.flip = flip;
				this.placementCurve = placementCurve ?? throw new ArgumentNullException("placementCurve");
				this.placementT = placementT;
			}

			public Vector3 GetPosition()
			{
				return placementCurve.GetPointAt(placementT);
			}

			public Quaternion GetRotation()
			{
				Vector3 vector = placementCurve.GetTangentAt(placementT);
				if (!flip)
				{
					vector = -vector;
				}
				return Quaternion.LookRotation(vector);
			}

			public Sign GetSign()
			{
				if (sign == null)
				{
					sign = new Sign(placementT * 100f % 10f < 3f);
				}
				return sign;
			}

			public RailTrack GetTrack()
			{
				return placementCurve.GetComponent<RailTrack>();
			}
		}

		private const float TRACK_END_SPACING = 3f;

		private const float FIRST_TRACK_SIGN_DISTANCE = 15f;

		private const float SIGN_PULL_BACK_DISTANCE = 100f;

		private const float LAST_SEGMENT_CONNECTED_MAX_SPEED = 60f;

		private const float LAST_SEGMENT_UNCONNECTED_MAX_SPEED = 20f;

		private const float YARD_OR_SHORT_TRACK_AFTER_JUNCTION_MAX_SPEED = 50f;

		private const float MIN_TRACK_LENGTH = 100f;

		private const float FLAT_GRADE_THRESHOLD = 0.005f;

		private const float SPEED_ZERO_REMOVER_MULT = 0.1f;

		private const float PREVENT_SPEED_UP_RANGE = 200f;

		private const float SPEED_AHEAD_ARROW_TOLERANCE = 20f;

		public float minArcLength = 300f;

		public float error = 1f;

		public float minimizeSpeedDiffThreshold = 30f;

		public float minimizeSpeedSegmentLengthThreshold = 300f;

		public float lastSegmentOptimalLength = 250f;

		public float sideways = 2f;

		public Transform parentTo;

		public bool clearParent = true;

		public List<string> noSignsTrackNameMarks;

		[Header("Debug")]
		public bool sceneViewReverse;

		public bool mergeSameSpeedSigns = true;

		public bool minimizeSpeedDifference = true;

		public bool placeTrackSigns = true;

		public bool placeJunctionSigns = true;

		private static List<CurveSegmentInfo> GetSegmentInfos(BezierCurve curve, float error, float minArcLength, bool reverse)
		{
			List<BezierArcApproximation.Arc> list = new List<BezierArcApproximation.Arc>();
			BezierArcApproximation.CalculateArcs(curve, error, list);
			if (reverse)
			{
				list.Reverse();
				for (int i = 0; i < list.Count; i++)
				{
					BezierArcApproximation.Arc arc = list[i];
					BezierArcApproximation.Arc value = list[i];
					value.s = arc.e;
					value.e = arc.s;
					value.bezierStartT = arc.bezierEndT;
					value.bezierEndT = arc.bezierStartT;
					list[i] = value;
				}
			}
			List<List<float>> list2 = SignPlacerUtils.ChunkifyNumbers(list.Select((BezierArcApproximation.Arc a) => a.Length).ToList(), minArcLength);
			List<List<BezierArcApproximation.Arc>> list3 = new List<List<BezierArcApproximation.Arc>>();
			int num = 0;
			for (int num2 = 0; num2 < list2.Count; num2++)
			{
				List<BezierArcApproximation.Arc> list4 = new List<BezierArcApproximation.Arc>();
				for (int num3 = 0; num3 < list2[num2].Count; num3++)
				{
					list4.Add(list[num]);
					num++;
				}
				list3.Add(list4);
			}
			List<CurveSegmentInfo> list5 = new List<CurveSegmentInfo>();
			for (int num4 = 0; num4 < list3.Count; num4++)
			{
				List<BezierArcApproximation.Arc> list6 = list3[num4];
				CurveSegmentInfo curveSegmentInfo = new CurveSegmentInfo
				{
					curve = curve,
					bezierStartT = list6.First().bezierStartT,
					bezierEndT = list6.Last().bezierEndT,
					minRadius = float.PositiveInfinity
				};
				foreach (BezierArcApproximation.Arc item in list6)
				{
					curveSegmentInfo.segmentLength += item.Length;
					if (item.r < curveSegmentInfo.minRadius)
					{
						curveSegmentInfo.minRadius = item.r;
					}
				}
				if (num4 + 1 < list3.Count)
				{
					float firstXMeters = curveSegmentInfo.GetSpeed() * 2f;
					float minRadiusInFirstXMeters = GetMinRadiusInFirstXMeters(list3[num4 + 1], firstXMeters);
					if (minRadiusInFirstXMeters < curveSegmentInfo.minRadius)
					{
						float minRadius = (Mathf.Clamp(curveSegmentInfo.minRadius, minRadiusInFirstXMeters, 1200f) + minRadiusInFirstXMeters) / 2f;
						curveSegmentInfo.minRadius = minRadius;
					}
				}
				list5.Add(curveSegmentInfo);
			}
			return list5;
		}

		private static float GetMinRadiusInFirstXMeters(List<BezierArcApproximation.Arc> arcs, float firstXMeters)
		{
			if (arcs == null || arcs.Count == 0)
			{
				Debug.LogError("Must have at least one arc");
				return 0f;
			}
			if (firstXMeters <= 0f)
			{
				Debug.LogError("firstXMeters must be positive");
				return 0f;
			}
			float num = float.PositiveInfinity;
			float num2 = 0f;
			for (int i = 0; i < arcs.Count; i++)
			{
				if (!(num2 < firstXMeters))
				{
					break;
				}
				BezierArcApproximation.Arc arc = arcs[i];
				num2 += arc.Length;
				if (arc.r < num)
				{
					num = arc.r;
				}
			}
			return num;
		}

		private static List<CurveSegmentInfo> SplitLastSegmentIfNeeded(List<CurveSegmentInfo> infos, float optimalLength)
		{
			infos = new List<CurveSegmentInfo>(infos);
			CurveSegmentInfo curveSegmentInfo = infos.Last();
			bool flag = curveSegmentInfo.bezierStartT > curveSegmentInfo.bezierEndT;
			if (curveSegmentInfo.segmentLength > 2f * optimalLength)
			{
				CurveSegmentInfo curveSegmentInfo2 = curveSegmentInfo.ShallowCopy();
				curveSegmentInfo.segmentLength -= optimalLength;
				curveSegmentInfo2.segmentLength = optimalLength;
				float num = optimalLength / curveSegmentInfo.curve.length;
				if (flag)
				{
					curveSegmentInfo.bezierEndT += num;
				}
				else
				{
					curveSegmentInfo.bezierEndT -= num;
				}
				curveSegmentInfo2.bezierStartT = curveSegmentInfo.bezierEndT;
				infos.Add(curveSegmentInfo2);
			}
			else if ((double)curveSegmentInfo.segmentLength > 1.5 * (double)optimalLength)
			{
				CurveSegmentInfo curveSegmentInfo3 = curveSegmentInfo.ShallowCopy();
				curveSegmentInfo3.segmentLength = (curveSegmentInfo.segmentLength *= 0.5f);
				curveSegmentInfo3.bezierStartT = (curveSegmentInfo.bezierEndT = (curveSegmentInfo.bezierStartT + curveSegmentInfo.bezierEndT) * 0.5f);
				infos.Add(curveSegmentInfo3);
			}
			return infos;
		}

		private static List<CurveSegmentInfo> MergeSameSpeed(List<CurveSegmentInfo> infos)
		{
			infos = new List<CurveSegmentInfo>(infos);
			for (int num = infos.Count - 1; num > 0; num--)
			{
				CurveSegmentInfo curveSegmentInfo = infos[num - 1];
				CurveSegmentInfo curveSegmentInfo2 = infos[num];
				if (!(Mathf.Abs(curveSegmentInfo2.GetGradeAngle() - curveSegmentInfo.GetGradeAngle()) >= 0.005f))
				{
					float speed = curveSegmentInfo.GetSpeed();
					float speed2 = curveSegmentInfo2.GetSpeed();
					if (speed == speed2)
					{
						curveSegmentInfo.bezierEndT = curveSegmentInfo2.bezierEndT;
						curveSegmentInfo.segmentLength += curveSegmentInfo2.segmentLength;
						curveSegmentInfo.minRadius = Mathf.Min(curveSegmentInfo.minRadius, curveSegmentInfo2.minRadius);
						infos.RemoveAt(num);
					}
				}
			}
			return infos;
		}

		private static List<CurveSegmentInfo> MinimizeSpeedDifference(List<CurveSegmentInfo> infos, float speedDiffThreshold, float segmentLengthThreshold)
		{
			infos = new List<CurveSegmentInfo>(infos);
			foreach (var item in SignPlacerUtils.MinimizeSpeedDifference(infos.Select((CurveSegmentInfo i) => (i.GetSpeed(), segmentLength: i.segmentLength)).ToList(), speedDiffThreshold, segmentLengthThreshold))
			{
				switch (item.op)
				{
				case SignPlacerUtils.Operation.Insert:
				{
					CurveSegmentInfo curveSegmentInfo = infos[item.index - 1];
					CurveSegmentInfo curveSegmentInfo2 = infos[item.index];
					CurveSegmentInfo curveSegmentInfo3 = new CurveSegmentInfo();
					curveSegmentInfo3.assignedSpeed = item.value;
					curveSegmentInfo3.bezierStartT = (curveSegmentInfo.bezierStartT + curveSegmentInfo.bezierEndT) / 2f;
					curveSegmentInfo.bezierEndT = curveSegmentInfo3.bezierStartT;
					curveSegmentInfo3.bezierEndT = curveSegmentInfo2.bezierStartT;
					curveSegmentInfo3.curve = curveSegmentInfo.curve;
					curveSegmentInfo3.minRadius = curveSegmentInfo.minRadius;
					curveSegmentInfo.segmentLength /= 2f;
					curveSegmentInfo3.segmentLength = curveSegmentInfo.segmentLength;
					infos.Insert(item.index, curveSegmentInfo3);
					break;
				}
				case SignPlacerUtils.Operation.Update:
					infos[item.index].assignedSpeed = item.value;
					break;
				default:
					throw new NotImplementedException(item.op.ToString());
				}
			}
			return infos;
		}

		private CurveSegmentInfo GetSegmentInfoAfterJunction(Junction.Branch branch)
		{
			if (branch.track == null)
			{
				Debug.LogError("Branch's track is null");
				return null;
			}
			Junction junction = (branch.first ? branch.track.outJunction : branch.track.inJunction);
			if (junction == null)
			{
				Debug.LogError("Expected junction on the other end of the branch");
				return null;
			}
			Junction.Branch inBranch = junction.inBranch;
			RailTrack track = inBranch.track;
			if (track == null)
			{
				Debug.LogWarning("Junction's inBranch is not connected");
				return null;
			}
			bool reverse = !inBranch.first;
			CurveSegmentInfo curveSegmentInfo = GetSegmentInfos(track.curve, error, minArcLength, reverse)[0];
			if (!ShouldIncludeTrack(track))
			{
				curveSegmentInfo.assignedSpeed = Mathf.Min(50f, curveSegmentInfo.GetSpeed());
			}
			return curveSegmentInfo;
		}

		private static bool ShouldIncludeTrack(RailTrack rt)
		{
			if (rt.curve.length < 100f)
			{
				return false;
			}
			if (rt.name.StartsWith("[Y]") || rt.name.StartsWith("[#]"))
			{
				return false;
			}
			return true;
		}

		public List<GameObject> PlaceSigns()
		{
			if ((bool)parentTo && clearParent)
			{
				parentTo.gameObject.Children().ToList().ForEach(UnityEngine.Object.DestroyImmediate);
			}
			List<SignData> list = new List<SignData>();
			if (placeTrackSigns)
			{
				list.AddRange(GetTrackSigns());
			}
			if (placeJunctionSigns)
			{
				list.AddRange(GetJunctionSigns());
			}
			if (noSignsTrackNameMarks != null && noSignsTrackNameMarks.Count > 0)
			{
				list.RemoveAll((SignData signData) => noSignsTrackNameMarks.Any((string mark) => signData.GetTrack().name.StartsWith(mark)));
			}
			return list.Select(PlaceSign).ToList();
		}

		private List<SignData> GetTrackSigns()
		{
			RailTrack component = GetComponent<RailTrack>();
			RailTrack[] array = ((!component) ? UnityEngine.Object.FindObjectsOfType<RailTrack>().Where(ShouldIncludeTrack).ToArray() : new RailTrack[1] { component });
			List<SignData> list = new List<SignData>();
			RailTrack[] array2 = array;
			foreach (RailTrack rt in array2)
			{
				list.AddRange(GetTrackSigns(rt, reverse: false));
				list.AddRange(GetTrackSigns(rt, reverse: true));
			}
			return list;
		}

		private List<SignData> GetJunctionSigns()
		{
			Junction component = GetComponent<Junction>();
			Junction[] source = ((!component) ? UnityEngine.Object.FindObjectsOfType<Junction>() : new Junction[1] { component });
			return source.SelectMany(GetJunctionSigns).ToList();
		}

		private List<SignData> GetJunctionSigns(Junction j)
		{
			List<SignData> list = new List<SignData>();
			if (j.inBranch.track == null)
			{
				Debug.LogWarning("Skipping placing signs for junction, no track is connected to inBranch", j);
				return list;
			}
			List<Junction.Branch> list2 = new List<Junction.Branch>();
			for (int i = 0; i < j.outBranches.Count; i++)
			{
				Junction.Branch branch = j.outBranches[i];
				Junction.Branch branch2 = (branch.first ? branch.track.outBranch : branch.track.inBranch);
				if (branch2.track == null)
				{
					Debug.LogWarning($"Skipping placing signs for junction, no track is connected to outBranches[{i}]", j);
					return list;
				}
				list2.Add(branch2);
			}
			BezierCurve curve = j.inBranch.track.curve;
			bool flag = !j.inBranch.first;
			if (ShouldIncludeTrack(j.inBranch.track) && curve.length > 8f)
			{
				float num = 3f / curve.length;
				if (flag)
				{
					num = 1f - num;
				}
				SignData signData = new SignData(!flag, curve, num);
				bool flag2 = j.transform.parent.name.Contains("left");
				for (int k = 0; k < 2; k++)
				{
					Junction.Branch branch3 = list2[k];
					List<CurveSegmentInfo> list3 = GetSegmentInfos(branch3.track.curve, reverse: !branch3.first, error: error, minArcLength: minArcLength);
					if (minimizeSpeedDifference)
					{
						list3 = MinimizeSpeedDifference(list3, minimizeSpeedDiffThreshold, float.MaxValue);
					}
					CurveSegmentInfo curveSegmentInfo = list3[0];
					if (!ShouldIncludeTrack(branch3.track))
					{
						curveSegmentInfo.assignedSpeed = Mathf.Min(50f, curveSegmentInfo.GetSpeed());
					}
					if ((k == 1) ^ flag2)
					{
						curveSegmentInfo.assignedSpeed = Mathf.Min(60f, curveSegmentInfo.GetSpeed());
					}
					signData.GetSign().SpeedLimit(curveSegmentInfo.GetSpeed() * 0.1f).Arrow(k == 0);
				}
				list.Add(signData);
			}
			return list;
		}

		private List<SignData> GetTrackSigns(RailTrack rt, bool reverse)
		{
			BezierCurve curve = rt.curve;
			List<CurveSegmentInfo> segmentInfos = GetSegmentInfos(curve, error, minArcLength, reverse);
			segmentInfos = SplitLastSegmentIfNeeded(segmentInfos, lastSegmentOptimalLength);
			CurveSegmentInfo curveSegmentInfo = segmentInfos.Last();
			bool flag = (reverse ? rt.inIsConnected : rt.outIsConnected);
			bool flag2 = (reverse ? rt.inJunction : rt.outJunction) != null;
			bool flag3 = flag && !flag2 && (reverse ? rt.inBranch.track : rt.outBranch.track).name == "[track diverging]";
			float num = float.PositiveInfinity;
			if (!flag)
			{
				num = 20f;
			}
			else if (flag3 || flag2)
			{
				num = 60f;
			}
			else
			{
				CurveSegmentInfo segmentInfoAfterJunction = GetSegmentInfoAfterJunction(reverse ? rt.inBranch : rt.outBranch);
				if (segmentInfoAfterJunction != null)
				{
					num = segmentInfoAfterJunction.GetSpeed();
					_ = (reverse ? rt.inBranch.track : rt.outBranch.track).name;
				}
			}
			if (curveSegmentInfo.GetSpeed() > num)
			{
				curveSegmentInfo.assignedSpeed = Mathf.Clamp(curveSegmentInfo.GetSpeed(), 0f, num);
			}
			if (mergeSameSpeedSigns)
			{
				segmentInfos = MergeSameSpeed(segmentInfos);
			}
			if (minimizeSpeedDifference)
			{
				segmentInfos = MinimizeSpeedDifference(segmentInfos, minimizeSpeedDiffThreshold, minimizeSpeedSegmentLengthThreshold);
			}
			List<SignData> list = new List<SignData>();
			for (int i = 0; i < segmentInfos.Count; i++)
			{
				CurveSegmentInfo curveSegmentInfo2 = segmentInfos[i];
				CurveSegmentInfo curveSegmentInfo3 = segmentInfos[Mathf.Max(0, i - 1)];
				CurveSegmentInfo curveSegmentInfo4 = segmentInfos[Mathf.Min(i + 1, segmentInfos.Count - 1)];
				if (curveSegmentInfo2.GetSpeed() > curveSegmentInfo4.GetSpeed() && curveSegmentInfo2.segmentLength <= 200f)
				{
					curveSegmentInfo2.assignedSpeed = curveSegmentInfo4.GetSpeed();
				}
				float placementT;
				if (i == 0)
				{
					if (!(reverse ? rt.outIsConnected : rt.inIsConnected))
					{
						continue;
					}
					float num2 = 15f / curve.length;
					if (reverse)
					{
						num2 *= -1f;
					}
					placementT = Mathf.Clamp01(curveSegmentInfo2.bezierStartT + num2);
				}
				else
				{
					float num3 = 0f;
					if (curveSegmentInfo2.GetSpeed() < curveSegmentInfo3.GetSpeed())
					{
						num3 = 100f / curve.length;
					}
					if (reverse)
					{
						num3 *= -1f;
					}
					placementT = Mathf.Clamp01(curveSegmentInfo2.bezierStartT - num3);
				}
				SignData signData = new SignData(reverse, rt.curve, placementT);
				Sign sign = signData.GetSign();
				if (i == segmentInfos.Count - 1)
				{
					curveSegmentInfo2.assignedSpeed = Mathf.Min(curveSegmentInfo3.GetSpeed(), curveSegmentInfo2.GetSpeed(), 60f);
					if (flag2)
					{
						sign.UpcomingJunction();
						sign.UpcomingJunctionDistance(curveSegmentInfo2.segmentLength);
					}
					else if (!flag)
					{
						sign.UpcomingTrackEnd();
					}
				}
				sign.SpeedLimit(curveSegmentInfo2.GetSpeed() * 0.1f);
				if (i < segmentInfos.Count - 2 && curveSegmentInfo4.GetSpeed() >= curveSegmentInfo2.GetSpeed() + 20f)
				{
					sign.UpcomingSpeedUp();
				}
				if (curveSegmentInfo4.GetSpeed() <= curveSegmentInfo2.GetSpeed() - 20f || (i == segmentInfos.Count - 1 && curveSegmentInfo2.GetSpeed() > 60f))
				{
					sign.UpcomingSpeedDown();
				}
				if (i < 1 || Mathf.Abs(curveSegmentInfo2.GetGradeAngle() - curveSegmentInfo3.GetGradeAngle()) >= 0.005f)
				{
					sign.Grade(curveSegmentInfo2.GetGrade(), curveSegmentInfo2.GetGradeAngle());
				}
				list.Add(signData);
			}
			return list;
		}

		private GameObject PlaceSign(SignData signData)
		{
			GameObject obj = signData.GetSign().Make();
			obj.transform.position = signData.GetPosition();
			obj.transform.rotation = signData.GetRotation();
			obj.transform.Translate(0f - sideways, 0f, 0f, Space.Self);
			Vector3 eulerAngles = obj.transform.localRotation.eulerAngles;
			eulerAngles.x = 0f;
			obj.transform.localRotation = Quaternion.Euler(eulerAngles);
			obj.AddComponent<SignDebug>().text = string.Join("\n", from sp in signData.GetSign().signParameters
				where !string.IsNullOrWhiteSpace(sp.signText)
				select sp.signText);
			obj.transform.SetParent(parentTo ? parentTo : DV.OriginShift.OriginShift.parentContainer);
			return obj;
		}

		private void Start()
		{
			Debug.Log("Placing signs", this);
			PlaceSigns();
		}
	}
}
