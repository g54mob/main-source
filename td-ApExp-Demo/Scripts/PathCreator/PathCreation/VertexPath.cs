using PathCreation.Utility;
using UnityEngine;

namespace PathCreation
{
	public class VertexPath
	{
		public struct TimeOnPathData
		{
			public readonly int previousIndex;

			public readonly int nextIndex;

			public readonly float percentBetweenIndices;

			public TimeOnPathData(int prev, int next, float percentBetweenIndices)
			{
				previousIndex = prev;
				nextIndex = next;
				this.percentBetweenIndices = percentBetweenIndices;
			}
		}

		public readonly PathSpace space;

		public readonly bool isClosedLoop;

		public readonly Vector3[] localPoints;

		public readonly Vector3[] localTangents;

		public readonly Vector3[] localNormals;

		public readonly float[] times;

		public readonly float length;

		public readonly float[] cumulativeLengthAtEachVertex;

		public readonly Bounds bounds;

		public readonly Vector3 up;

		private const int accuracy = 10;

		private const float minVertexSpacing = 0.01f;

		private Transform transform;

		public int NumPoints => localPoints.Length;

		public VertexPath(BezierPath bezierPath, Transform transform, float maxAngleError = 0.3f, float minVertexDst = 0f)
			: this(bezierPath, VertexPathUtility.SplitBezierPathByAngleError(bezierPath, maxAngleError, minVertexDst, 10f), transform)
		{
		}

		public VertexPath(BezierPath bezierPath, Transform transform, float vertexSpacing)
			: this(bezierPath, VertexPathUtility.SplitBezierPathEvenly(bezierPath, Mathf.Max(vertexSpacing, 0.01f), 10f), transform)
		{
		}

		private VertexPath(BezierPath bezierPath, VertexPathUtility.PathSplitData pathSplitData, Transform transform)
		{
			this.transform = transform;
			space = bezierPath.Space;
			isClosedLoop = bezierPath.IsClosed;
			int count = pathSplitData.vertices.Count;
			length = pathSplitData.cumulativeLength[count - 1];
			localPoints = new Vector3[count];
			localNormals = new Vector3[count];
			localTangents = new Vector3[count];
			cumulativeLengthAtEachVertex = new float[count];
			times = new float[count];
			bounds = new Bounds((pathSplitData.minMax.Min + pathSplitData.minMax.Max) / 2f, pathSplitData.minMax.Max - pathSplitData.minMax.Min);
			up = ((bounds.size.z > bounds.size.y) ? Vector3.up : Vector3.forward);
			Vector3 vector = up;
			for (int i = 0; i < localPoints.Length; i++)
			{
				localPoints[i] = pathSplitData.vertices[i];
				localTangents[i] = pathSplitData.tangents[i];
				cumulativeLengthAtEachVertex[i] = pathSplitData.cumulativeLength[i];
				times[i] = cumulativeLengthAtEachVertex[i] / length;
				if (space == PathSpace.xyz)
				{
					if (i == 0)
					{
						localNormals[0] = Vector3.Cross(vector, pathSplitData.tangents[0]).normalized;
						continue;
					}
					Vector3 vector2 = localPoints[i] - localPoints[i - 1];
					float sqrMagnitude = vector2.sqrMagnitude;
					Vector3 vector3 = vector - vector2 * 2f / sqrMagnitude * Vector3.Dot(vector2, vector);
					Vector3 vector4 = localTangents[i - 1] - vector2 * 2f / sqrMagnitude * Vector3.Dot(vector2, localTangents[i - 1]);
					Vector3 vector5 = localTangents[i] - vector4;
					float num = Vector3.Dot(vector5, vector5);
					Vector3 vector6 = vector3 - vector5 * 2f / num * Vector3.Dot(vector5, vector3);
					Vector3 normalized = Vector3.Cross(vector6, localTangents[i]).normalized;
					localNormals[i] = normalized;
					vector = vector6;
				}
				else
				{
					localNormals[i] = Vector3.Cross(localTangents[i], up) * (bezierPath.FlipNormals ? 1 : (-1));
				}
			}
			if (space == PathSpace.xyz && isClosedLoop)
			{
				float num2 = Vector3.SignedAngle(localNormals[localNormals.Length - 1], localNormals[0], localTangents[0]);
				if (Mathf.Abs(num2) > 0.1f)
				{
					for (int j = 1; j < localNormals.Length; j++)
					{
						float num3 = (float)j / ((float)localNormals.Length - 1f);
						Quaternion quaternion = Quaternion.AngleAxis(num2 * num3, localTangents[j]);
						localNormals[j] = quaternion * localNormals[j] * ((!bezierPath.FlipNormals) ? 1 : (-1));
					}
				}
			}
			if (space != PathSpace.xyz)
			{
				return;
			}
			for (int k = 0; k < pathSplitData.anchorVertexMap.Count - 1; k++)
			{
				int anchorIndex = (isClosedLoop ? ((k + 1) % bezierPath.NumSegments) : (k + 1));
				float num4 = bezierPath.GetAnchorNormalAngle(k) + bezierPath.GlobalNormalsAngle;
				float target = bezierPath.GetAnchorNormalAngle(anchorIndex) + bezierPath.GlobalNormalsAngle;
				float num5 = Mathf.DeltaAngle(num4, target);
				int num6 = pathSplitData.anchorVertexMap[k];
				int num7 = pathSplitData.anchorVertexMap[k + 1] - num6;
				if (k == pathSplitData.anchorVertexMap.Count - 2)
				{
					num7++;
				}
				for (int l = 0; l < num7; l++)
				{
					int num8 = num6 + l;
					float num9 = (float)l / ((float)num7 - 1f);
					Quaternion quaternion2 = Quaternion.AngleAxis(num4 + num5 * num9, localTangents[num8]);
					localNormals[num8] = quaternion2 * localNormals[num8] * ((!bezierPath.FlipNormals) ? 1 : (-1));
				}
			}
		}

		public void UpdateTransform(Transform transform)
		{
			this.transform = transform;
		}

		public Vector3 GetTangent(int index)
		{
			return MathUtility.TransformDirection(localTangents[index], transform, space);
		}

		public Vector3 GetNormal(int index)
		{
			return MathUtility.TransformDirection(localNormals[index], transform, space);
		}

		public Vector3 GetPoint(int index)
		{
			return MathUtility.TransformPoint(localPoints[index], transform, space);
		}

		public Vector3 GetPointAtDistance(float dst, EndOfPathInstruction endOfPathInstruction = EndOfPathInstruction.Loop)
		{
			float t = dst / length;
			return GetPointAtTime(t, endOfPathInstruction);
		}

		public Vector3 GetDirectionAtDistance(float dst, EndOfPathInstruction endOfPathInstruction = EndOfPathInstruction.Loop)
		{
			float t = dst / length;
			return GetDirection(t, endOfPathInstruction);
		}

		public Vector3 GetNormalAtDistance(float dst, EndOfPathInstruction endOfPathInstruction = EndOfPathInstruction.Loop)
		{
			float t = dst / length;
			return GetNormal(t, endOfPathInstruction);
		}

		public Quaternion GetRotationAtDistance(float dst, EndOfPathInstruction endOfPathInstruction = EndOfPathInstruction.Loop)
		{
			float t = dst / length;
			return GetRotation(t, endOfPathInstruction);
		}

		public Vector3 GetPointAtTime(float t, EndOfPathInstruction endOfPathInstruction = EndOfPathInstruction.Loop)
		{
			TimeOnPathData timeOnPathData = CalculatePercentOnPathData(t, endOfPathInstruction);
			return Vector3.Lerp(GetPoint(timeOnPathData.previousIndex), GetPoint(timeOnPathData.nextIndex), timeOnPathData.percentBetweenIndices);
		}

		public Vector3 GetDirection(float t, EndOfPathInstruction endOfPathInstruction = EndOfPathInstruction.Loop)
		{
			TimeOnPathData timeOnPathData = CalculatePercentOnPathData(t, endOfPathInstruction);
			return MathUtility.TransformDirection(Vector3.Lerp(localTangents[timeOnPathData.previousIndex], localTangents[timeOnPathData.nextIndex], timeOnPathData.percentBetweenIndices), transform, space);
		}

		public Vector3 GetNormal(float t, EndOfPathInstruction endOfPathInstruction = EndOfPathInstruction.Loop)
		{
			TimeOnPathData timeOnPathData = CalculatePercentOnPathData(t, endOfPathInstruction);
			return MathUtility.TransformDirection(Vector3.Lerp(localNormals[timeOnPathData.previousIndex], localNormals[timeOnPathData.nextIndex], timeOnPathData.percentBetweenIndices), transform, space);
		}

		public Quaternion GetRotation(float t, EndOfPathInstruction endOfPathInstruction = EndOfPathInstruction.Loop)
		{
			TimeOnPathData timeOnPathData = CalculatePercentOnPathData(t, endOfPathInstruction);
			Vector3.Lerp(localTangents[timeOnPathData.previousIndex], localTangents[timeOnPathData.nextIndex], timeOnPathData.percentBetweenIndices);
			Vector3 p = Vector3.Lerp(localNormals[timeOnPathData.previousIndex], localNormals[timeOnPathData.nextIndex], timeOnPathData.percentBetweenIndices);
			return Quaternion.LookRotation(Vector3.forward, MathUtility.TransformDirection(p, transform, space));
		}

		public Vector3 GetClosestPointOnPath(Vector3 worldPoint)
		{
			TimeOnPathData timeOnPathData = CalculateClosestPointOnPathData(worldPoint);
			return Vector3.Lerp(GetPoint(timeOnPathData.previousIndex), GetPoint(timeOnPathData.nextIndex), timeOnPathData.percentBetweenIndices);
		}

		public float GetClosestTimeOnPath(Vector3 worldPoint)
		{
			TimeOnPathData timeOnPathData = CalculateClosestPointOnPathData(worldPoint);
			return Mathf.Lerp(times[timeOnPathData.previousIndex], times[timeOnPathData.nextIndex], timeOnPathData.percentBetweenIndices);
		}

		public float GetClosestDistanceAlongPath(Vector3 worldPoint)
		{
			TimeOnPathData timeOnPathData = CalculateClosestPointOnPathData(worldPoint);
			return Mathf.Lerp(cumulativeLengthAtEachVertex[timeOnPathData.previousIndex], cumulativeLengthAtEachVertex[timeOnPathData.nextIndex], timeOnPathData.percentBetweenIndices);
		}

		private TimeOnPathData CalculatePercentOnPathData(float t, EndOfPathInstruction endOfPathInstruction)
		{
			switch (endOfPathInstruction)
			{
			case EndOfPathInstruction.Loop:
				if (t < 0f)
				{
					t += (float)Mathf.CeilToInt(Mathf.Abs(t));
				}
				t %= 1f;
				break;
			case EndOfPathInstruction.Reverse:
				t = Mathf.PingPong(t, 1f);
				break;
			case EndOfPathInstruction.Stop:
				t = Mathf.Clamp01(t);
				break;
			}
			int num = 0;
			int num2 = NumPoints - 1;
			int num3 = Mathf.RoundToInt(t * (float)(NumPoints - 1));
			do
			{
				if (t <= times[num3])
				{
					num2 = num3;
				}
				else
				{
					num = num3;
				}
				num3 = (num2 + num) / 2;
			}
			while (num2 - num > 1);
			float percentBetweenIndices = Mathf.InverseLerp(times[num], times[num2], t);
			return new TimeOnPathData(num, num2, percentBetweenIndices);
		}

		private TimeOnPathData CalculateClosestPointOnPathData(Vector3 worldPoint)
		{
			float num = float.MaxValue;
			Vector3 vector = Vector3.zero;
			int num2 = 0;
			int num3 = 0;
			for (int i = 0; i < localPoints.Length; i++)
			{
				int num4 = i + 1;
				if (num4 >= localPoints.Length)
				{
					if (!isClosedLoop)
					{
						break;
					}
					num4 %= localPoints.Length;
				}
				Vector3 vector2 = MathUtility.ClosestPointOnLineSegment(worldPoint, GetPoint(i), GetPoint(num4));
				float sqrMagnitude = (worldPoint - vector2).sqrMagnitude;
				if (sqrMagnitude < num)
				{
					num = sqrMagnitude;
					vector = vector2;
					num2 = i;
					num3 = num4;
				}
			}
			float magnitude = (GetPoint(num2) - GetPoint(num3)).magnitude;
			float percentBetweenIndices = (vector - GetPoint(num2)).magnitude / magnitude;
			return new TimeOnPathData(num2, num3, percentBetweenIndices);
		}
	}
}
