using System;
using System.Collections.Generic;
using System.Linq;
using PathCreation.Utility;
using UnityEngine;

namespace PathCreation
{
	[Serializable]
	public class BezierPath
	{
		public enum ControlMode
		{
			Aligned = 0,
			Mirrored = 1,
			Free = 2,
			Automatic = 3
		}

		[SerializeField]
		[HideInInspector]
		private List<Vector3> points;

		[SerializeField]
		[HideInInspector]
		private bool isClosed;

		[SerializeField]
		[HideInInspector]
		private PathSpace space;

		[SerializeField]
		[HideInInspector]
		private ControlMode controlMode;

		[SerializeField]
		[HideInInspector]
		private float autoControlLength = 0.3f;

		[SerializeField]
		[HideInInspector]
		private bool boundsUpToDate;

		[SerializeField]
		[HideInInspector]
		private Bounds bounds;

		[SerializeField]
		[HideInInspector]
		private List<float> perAnchorNormalsAngle;

		[SerializeField]
		[HideInInspector]
		private float globalNormalsAngle;

		[SerializeField]
		[HideInInspector]
		private bool flipNormals;

		public Vector3 this[int i] => GetPoint(i);

		public int NumPoints => points.Count;

		public int NumAnchorPoints
		{
			get
			{
				if (!IsClosed)
				{
					return (points.Count + 2) / 3;
				}
				return points.Count / 3;
			}
		}

		public int NumSegments => points.Count / 3;

		public PathSpace Space
		{
			get
			{
				return space;
			}
			set
			{
				if (value != space)
				{
					PathSpace previousSpace = space;
					space = value;
					UpdateToNewPathSpace(previousSpace);
				}
			}
		}

		public bool IsClosed
		{
			get
			{
				return isClosed;
			}
			set
			{
				if (isClosed != value)
				{
					isClosed = value;
					UpdateClosedState();
				}
			}
		}

		public ControlMode ControlPointMode
		{
			get
			{
				return controlMode;
			}
			set
			{
				if (controlMode != value)
				{
					controlMode = value;
					if (controlMode == ControlMode.Automatic)
					{
						AutoSetAllControlPoints();
						NotifyPathModified();
					}
				}
			}
		}

		public float AutoControlLength
		{
			get
			{
				return autoControlLength;
			}
			set
			{
				value = Mathf.Max(value, 0.01f);
				if (autoControlLength != value)
				{
					autoControlLength = value;
					AutoSetAllControlPoints();
					NotifyPathModified();
				}
			}
		}

		public bool FlipNormals
		{
			get
			{
				return flipNormals;
			}
			set
			{
				if (flipNormals != value)
				{
					flipNormals = value;
					NotifyPathModified();
				}
			}
		}

		public float GlobalNormalsAngle
		{
			get
			{
				return globalNormalsAngle;
			}
			set
			{
				if (value != globalNormalsAngle)
				{
					globalNormalsAngle = value;
					NotifyPathModified();
				}
			}
		}

		public Bounds PathBounds
		{
			get
			{
				if (!boundsUpToDate)
				{
					UpdateBounds();
				}
				return bounds;
			}
		}

		public event Action OnModified;

		public BezierPath(Vector3 centre, bool isClosed = false, PathSpace space = PathSpace.xyz)
		{
			Vector3 vector = ((space == PathSpace.xz) ? Vector3.forward : Vector3.up);
			float num = 2f;
			float num2 = 0.5f;
			float num3 = 1f;
			points = new List<Vector3>
			{
				centre + Vector3.left * num,
				centre + Vector3.left * num3 + vector * num2,
				centre + Vector3.right * num3 - vector * num2,
				centre + Vector3.right * num
			};
			perAnchorNormalsAngle = new List<float> { 0f, 0f };
			Space = space;
			IsClosed = isClosed;
		}

		public BezierPath(IEnumerable<Vector3> points, bool isClosed = false, PathSpace space = PathSpace.xyz)
		{
			Vector3[] array = points.ToArray();
			if (array.Length < 2)
			{
				Debug.LogError("Path requires at least 2 anchor points.");
			}
			else
			{
				controlMode = ControlMode.Automatic;
				this.points = new List<Vector3>
				{
					array[0],
					Vector3.zero,
					Vector3.zero,
					array[1]
				};
				perAnchorNormalsAngle = new List<float>(new float[2]);
				for (int i = 2; i < array.Length; i++)
				{
					AddSegmentToEnd(array[i]);
					perAnchorNormalsAngle.Add(0f);
				}
			}
			Space = space;
			IsClosed = isClosed;
		}

		public BezierPath(IEnumerable<Vector2> transforms, bool isClosed = false, PathSpace space = PathSpace.xy)
			: this(transforms.Select((Vector2 p) => new Vector3(p.x, p.y)), isClosed, space)
		{
		}

		public BezierPath(IEnumerable<Transform> transforms, bool isClosed = false, PathSpace space = PathSpace.xy)
			: this(transforms.Select((Transform t) => t.position), isClosed, space)
		{
		}

		public BezierPath(IEnumerable<Vector2> points, PathSpace space = PathSpace.xyz, bool isClosed = false)
			: this(points.Select((Vector2 p) => new Vector3(p.x, p.y)), isClosed, space)
		{
		}

		public Vector3 GetPoint(int i)
		{
			return points[i];
		}

		public void SetPoint(int i, Vector3 localPosition, bool suppressPathModifiedEvent = false)
		{
			points[i] = localPosition;
			if (!suppressPathModifiedEvent)
			{
				NotifyPathModified();
			}
		}

		public void AddSegmentToEnd(Vector3 anchorPos)
		{
			if (!isClosed)
			{
				int num = points.Count - 1;
				Vector3 vector = points[num] - points[num - 1];
				if (controlMode != ControlMode.Mirrored && controlMode != ControlMode.Automatic)
				{
					float magnitude = (points[num] - anchorPos).magnitude;
					vector = (points[num] - points[num - 1]).normalized * magnitude * 0.5f;
				}
				Vector3 vector2 = points[num] + vector;
				Vector3 item = (anchorPos + vector2) * 0.5f;
				points.Add(vector2);
				points.Add(item);
				points.Add(anchorPos);
				perAnchorNormalsAngle.Add(perAnchorNormalsAngle[perAnchorNormalsAngle.Count - 1]);
				if (controlMode == ControlMode.Automatic)
				{
					AutoSetAllAffectedControlPoints(points.Count - 1);
				}
				NotifyPathModified();
			}
		}

		public void AddSegmentToStart(Vector3 anchorPos)
		{
			if (!isClosed)
			{
				Vector3 vector = points[0] - points[1];
				if (controlMode != ControlMode.Mirrored && controlMode != ControlMode.Automatic)
				{
					float magnitude = (points[0] - anchorPos).magnitude;
					vector = vector.normalized * magnitude * 0.5f;
				}
				Vector3 vector2 = points[0] + vector;
				Vector3 item = (anchorPos + vector2) * 0.5f;
				points.Insert(0, anchorPos);
				points.Insert(1, item);
				points.Insert(2, vector2);
				perAnchorNormalsAngle.Insert(0, perAnchorNormalsAngle[0]);
				if (controlMode == ControlMode.Automatic)
				{
					AutoSetAllAffectedControlPoints(0);
				}
				NotifyPathModified();
			}
		}

		public void SplitSegment(Vector3 anchorPos, int segmentIndex, float splitTime)
		{
			splitTime = Mathf.Clamp01(splitTime);
			if (controlMode == ControlMode.Automatic)
			{
				points.InsertRange(segmentIndex * 3 + 2, new Vector3[3]
				{
					Vector3.zero,
					anchorPos,
					Vector3.zero
				});
				AutoSetAllAffectedControlPoints(segmentIndex * 3 + 3);
			}
			else
			{
				Vector3[][] array = CubicBezierUtility.SplitCurve(GetPointsInSegment(segmentIndex), splitTime);
				points.InsertRange(segmentIndex * 3 + 2, new Vector3[3]
				{
					array[0][2],
					array[1][0],
					array[1][1]
				});
				int num = segmentIndex * 3 + 3;
				MovePoint(num - 2, array[0][1], suppressPathModifiedEvent: true);
				MovePoint(num + 2, array[1][2], suppressPathModifiedEvent: true);
				MovePoint(num, anchorPos, suppressPathModifiedEvent: true);
				if (controlMode == ControlMode.Mirrored)
				{
					float num2 = ((array[0][2] - anchorPos).magnitude + (array[1][1] - anchorPos).magnitude) / 2f;
					MovePoint(num + 1, anchorPos + (array[1][1] - anchorPos).normalized * num2, suppressPathModifiedEvent: true);
				}
			}
			int index = (segmentIndex + 1) % perAnchorNormalsAngle.Count;
			_ = perAnchorNormalsAngle.Count;
			float a = perAnchorNormalsAngle[segmentIndex];
			float b = perAnchorNormalsAngle[index];
			float item = Mathf.LerpAngle(a, b, splitTime);
			perAnchorNormalsAngle.Insert(index, item);
			NotifyPathModified();
		}

		public void DeleteSegment(int anchorIndex)
		{
			if (NumSegments <= 2 && (isClosed || NumSegments <= 1))
			{
				return;
			}
			if (anchorIndex == 0)
			{
				if (isClosed)
				{
					points[points.Count - 1] = points[2];
				}
				points.RemoveRange(0, 3);
			}
			else if (anchorIndex == points.Count - 1 && !isClosed)
			{
				points.RemoveRange(anchorIndex - 2, 3);
			}
			else
			{
				points.RemoveRange(anchorIndex - 1, 3);
			}
			perAnchorNormalsAngle.RemoveAt(anchorIndex / 3);
			if (controlMode == ControlMode.Automatic)
			{
				AutoSetAllControlPoints();
			}
			NotifyPathModified();
		}

		public Vector3[] GetPointsInSegment(int segmentIndex)
		{
			segmentIndex = Mathf.Clamp(segmentIndex, 0, NumSegments - 1);
			return new Vector3[4]
			{
				this[segmentIndex * 3],
				this[segmentIndex * 3 + 1],
				this[segmentIndex * 3 + 2],
				this[LoopIndex(segmentIndex * 3 + 3)]
			};
		}

		public void MovePoint(int i, Vector3 pointPos, bool suppressPathModifiedEvent = false)
		{
			if (space == PathSpace.xy)
			{
				pointPos.z = 0f;
			}
			else if (space == PathSpace.xz)
			{
				pointPos.y = 0f;
			}
			Vector3 vector = pointPos - points[i];
			bool flag = i % 3 == 0;
			if (!flag && controlMode == ControlMode.Automatic)
			{
				return;
			}
			points[i] = pointPos;
			if (controlMode == ControlMode.Automatic)
			{
				AutoSetAllAffectedControlPoints(i);
			}
			else if (flag)
			{
				if (i + 1 < points.Count || isClosed)
				{
					points[LoopIndex(i + 1)] += vector;
				}
				if (i - 1 >= 0 || isClosed)
				{
					points[LoopIndex(i - 1)] += vector;
				}
			}
			else if (controlMode != ControlMode.Free)
			{
				bool num = (i + 1) % 3 == 0;
				int num2 = (num ? (i + 2) : (i - 2));
				int i2 = (num ? (i + 1) : (i - 1));
				if ((num2 >= 0 && num2 < points.Count) || isClosed)
				{
					float num3 = 0f;
					if (controlMode == ControlMode.Aligned)
					{
						num3 = (points[LoopIndex(i2)] - points[LoopIndex(num2)]).magnitude;
					}
					else if (controlMode == ControlMode.Mirrored)
					{
						num3 = (points[LoopIndex(i2)] - points[i]).magnitude;
					}
					Vector3 normalized = (points[LoopIndex(i2)] - pointPos).normalized;
					points[LoopIndex(num2)] = points[LoopIndex(i2)] + normalized * num3;
				}
			}
			if (!suppressPathModifiedEvent)
			{
				NotifyPathModified();
			}
		}

		public Bounds CalculateBoundsWithTransform(Transform transform)
		{
			MinMax3D minMax3D = new MinMax3D();
			for (int i = 0; i < NumSegments; i++)
			{
				Vector3[] pointsInSegment = GetPointsInSegment(i);
				for (int j = 0; j < pointsInSegment.Length; j++)
				{
					pointsInSegment[j] = MathUtility.TransformPoint(pointsInSegment[j], transform, space);
				}
				minMax3D.AddValue(pointsInSegment[0]);
				minMax3D.AddValue(pointsInSegment[3]);
				foreach (float item in CubicBezierUtility.ExtremePointTimes(pointsInSegment[0], pointsInSegment[1], pointsInSegment[2], pointsInSegment[3]))
				{
					minMax3D.AddValue(CubicBezierUtility.EvaluateCurve(pointsInSegment, item));
				}
			}
			return new Bounds((minMax3D.Min + minMax3D.Max) / 2f, minMax3D.Max - minMax3D.Min);
		}

		public float GetAnchorNormalAngle(int anchorIndex)
		{
			return perAnchorNormalsAngle[anchorIndex] % 360f;
		}

		public void SetAnchorNormalAngle(int anchorIndex, float angle)
		{
			angle = (angle + 360f) % 360f;
			if (perAnchorNormalsAngle[anchorIndex] != angle)
			{
				perAnchorNormalsAngle[anchorIndex] = angle;
				NotifyPathModified();
			}
		}

		public void ResetNormalAngles()
		{
			for (int i = 0; i < perAnchorNormalsAngle.Count; i++)
			{
				perAnchorNormalsAngle[i] = 0f;
			}
			globalNormalsAngle = 0f;
			NotifyPathModified();
		}

		private void UpdateBounds()
		{
			if (boundsUpToDate)
			{
				return;
			}
			MinMax3D minMax3D = new MinMax3D();
			for (int i = 0; i < NumSegments; i++)
			{
				Vector3[] pointsInSegment = GetPointsInSegment(i);
				minMax3D.AddValue(pointsInSegment[0]);
				minMax3D.AddValue(pointsInSegment[3]);
				foreach (float item in CubicBezierUtility.ExtremePointTimes(pointsInSegment[0], pointsInSegment[1], pointsInSegment[2], pointsInSegment[3]))
				{
					minMax3D.AddValue(CubicBezierUtility.EvaluateCurve(pointsInSegment, item));
				}
			}
			boundsUpToDate = true;
			bounds = new Bounds((minMax3D.Min + minMax3D.Max) / 2f, minMax3D.Max - minMax3D.Min);
		}

		private void AutoSetAllAffectedControlPoints(int updatedAnchorIndex)
		{
			for (int i = updatedAnchorIndex - 3; i <= updatedAnchorIndex + 3; i += 3)
			{
				if ((i >= 0 && i < points.Count) || isClosed)
				{
					AutoSetAnchorControlPoints(LoopIndex(i));
				}
			}
			AutoSetStartAndEndControls();
		}

		private void AutoSetAllControlPoints()
		{
			if (NumAnchorPoints > 2)
			{
				for (int i = 0; i < points.Count; i += 3)
				{
					AutoSetAnchorControlPoints(i);
				}
			}
			AutoSetStartAndEndControls();
		}

		private void AutoSetAnchorControlPoints(int anchorIndex)
		{
			Vector3 vector = points[anchorIndex];
			Vector3 zero = Vector3.zero;
			float[] array = new float[2];
			if (anchorIndex - 3 >= 0 || isClosed)
			{
				Vector3 vector2 = points[LoopIndex(anchorIndex - 3)] - vector;
				zero += vector2.normalized;
				array[0] = vector2.magnitude;
			}
			if (anchorIndex + 3 >= 0 || isClosed)
			{
				Vector3 vector3 = points[LoopIndex(anchorIndex + 3)] - vector;
				zero -= vector3.normalized;
				array[1] = 0f - vector3.magnitude;
			}
			zero.Normalize();
			for (int i = 0; i < 2; i++)
			{
				int num = anchorIndex + i * 2 - 1;
				if ((num >= 0 && num < points.Count) || isClosed)
				{
					points[LoopIndex(num)] = vector + zero * array[i] * autoControlLength;
				}
			}
		}

		private void AutoSetStartAndEndControls()
		{
			if (isClosed)
			{
				if (NumAnchorPoints == 2)
				{
					Vector3 normalized = (points[3] - points[0]).normalized;
					float magnitude = (points[0] - points[3]).magnitude;
					Vector3 vector = Vector3.Cross(normalized, (space == PathSpace.xy) ? Vector3.forward : Vector3.up);
					points[1] = points[0] + vector * magnitude / 2f;
					points[5] = points[0] - vector * magnitude / 2f;
					points[2] = points[3] + vector * magnitude / 2f;
					points[4] = points[3] - vector * magnitude / 2f;
				}
				else
				{
					AutoSetAnchorControlPoints(0);
					AutoSetAnchorControlPoints(points.Count - 3);
				}
			}
			else if (NumAnchorPoints == 2)
			{
				points[1] = points[0] + (points[3] - points[0]) * 0.25f;
				points[2] = points[3] + (points[0] - points[3]) * 0.25f;
			}
			else
			{
				points[1] = (points[0] + points[2]) * 0.5f;
				points[points.Count - 2] = (points[points.Count - 1] + points[points.Count - 3]) * 0.5f;
			}
		}

		private void UpdateToNewPathSpace(PathSpace previousSpace)
		{
			if (previousSpace == PathSpace.xyz)
			{
				Vector3 size = PathBounds.size;
				float num = Mathf.Min(size.x, size.y, size.z);
				for (int i = 0; i < NumPoints; i++)
				{
					if (space == PathSpace.xy)
					{
						float x = ((num == size.x) ? points[i].z : points[i].x);
						float y = ((num == size.y) ? points[i].z : points[i].y);
						points[i] = new Vector3(x, y, 0f);
					}
					else if (space == PathSpace.xz)
					{
						float x2 = ((num == size.x) ? points[i].y : points[i].x);
						float z = ((num == size.z) ? points[i].y : points[i].z);
						points[i] = new Vector3(x2, 0f, z);
					}
				}
			}
			else if (space != PathSpace.xyz)
			{
				for (int j = 0; j < NumPoints; j++)
				{
					if (space == PathSpace.xy)
					{
						points[j] = new Vector3(points[j].x, points[j].z, 0f);
					}
					else if (space == PathSpace.xz)
					{
						points[j] = new Vector3(points[j].x, 0f, points[j].y);
					}
				}
			}
			NotifyPathModified();
		}

		private void UpdateClosedState()
		{
			if (isClosed)
			{
				Vector3 item = points[points.Count - 1] * 2f - points[points.Count - 2];
				Vector3 item2 = points[0] * 2f - points[1];
				if (controlMode != ControlMode.Mirrored && controlMode != ControlMode.Automatic)
				{
					float magnitude = (points[points.Count - 1] - points[0]).magnitude;
					item = points[points.Count - 1] + (points[points.Count - 1] - points[points.Count - 2]).normalized * magnitude * 0.5f;
					item2 = points[0] + (points[0] - points[1]).normalized * magnitude * 0.5f;
				}
				points.Add(item);
				points.Add(item2);
			}
			else
			{
				points.RemoveRange(points.Count - 2, 2);
			}
			if (controlMode == ControlMode.Automatic)
			{
				AutoSetStartAndEndControls();
			}
			if (this.OnModified != null)
			{
				this.OnModified();
			}
		}

		private int LoopIndex(int i)
		{
			return (i + points.Count) % points.Count;
		}

		public void NotifyPathModified()
		{
			boundsUpToDate = false;
			if (this.OnModified != null)
			{
				this.OnModified();
			}
		}
	}
}
