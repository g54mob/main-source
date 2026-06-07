using System;
using System.Collections.Generic;
using Factory;
using FixMath;
using UnityEngine;
using Utils.Geometry;

namespace Motorways.Utility
{
	public static class Spline
	{
		public class BezierSpline
		{
			public class Serializer : PrimitiveSerializer
			{
				public override bool Serialize(object obj, ExportContext context)
				{
					if (obj is BezierSpline bezierSpline)
					{
						context.Writer.Write(value: true);
						ISerializer serializer = SerializerLibrary.GetSerializer<Vector2>();
						serializer.Serialize(bezierSpline.inPoint, context);
						serializer.Serialize(bezierSpline.inHandle, context);
						serializer.Serialize(bezierSpline.outHandle, context);
						serializer.Serialize(bezierSpline.outPoint, context);
						return true;
					}
					context.Writer.Write(value: false);
					return true;
				}

				public override object Deserialize(object existingObj, ImportContext context)
				{
					if (context.Reader.ReadBoolean())
					{
						ISerializer serializer = SerializerLibrary.GetSerializer<Vector2>();
						return new BezierSpline((Vector2)serializer.Deserialize(null, context), (Vector2)serializer.Deserialize(null, context), (Vector2)serializer.Deserialize(null, context), (Vector2)serializer.Deserialize(null, context));
					}
					return null;
				}
			}

			public readonly Vector2 inPoint;

			public readonly Vector2 inHandle;

			public readonly Vector2 outHandle;

			public readonly Vector2 outPoint;

			public BezierSpline(Vector2 inP, Vector2 inH, Vector2 outH, Vector2 outP)
			{
				inPoint = inP;
				inHandle = inH;
				outHandle = outH;
				outPoint = outP;
			}

			public Vector2 Evaluate(float time)
			{
				return EvaluateBezier(time, inPoint, inHandle, outHandle, outPoint);
			}

			public Vector2 EvaluateLinear(float time)
			{
				return Vector2.Lerp(inPoint, outPoint, time);
			}

			public Vector2 EvaluateTangent(float time)
			{
				float num = inPoint.x + (inHandle.x - inPoint.x) * time;
				float num2 = inPoint.y + (inHandle.y - inPoint.y) * time;
				float num3 = inHandle.x + (outHandle.x - inHandle.x) * time;
				float num4 = inHandle.y + (outHandle.y - inHandle.y) * time;
				float num5 = outHandle.x + (outPoint.x - outHandle.x) * time;
				float num6 = outHandle.y + (outPoint.y - outHandle.y) * time;
				float num7 = num + (num3 - num) * time;
				float num8 = num2 + (num4 - num2) * time;
				float num9 = num3 + (num5 - num3) * time;
				float num10 = num4 + (num6 - num4) * time;
				float x = num9 - num7;
				float y = num10 - num8;
				return new Vector2(x, y);
			}

			public float Length(int resolution = 25)
			{
				float num = 0f;
				for (int i = 0; i < resolution; i++)
				{
					float time = 1f / (float)resolution * (float)i;
					Vector2 a = Evaluate(time);
					float time2 = 1f / (float)resolution * (float)(i + 1);
					Vector2 b = Evaluate(time2);
					num += Vector2.Distance(a, b);
				}
				return num;
			}

			public RasterizedSpline Rasterize(int resolution)
			{
				List<Vector2> list = new List<Vector2>(resolution);
				float num = 1f / (float)(resolution - 1);
				for (int i = 0; i < resolution; i++)
				{
					Vector2 item = Evaluate(num * (float)i);
					list.Add(item);
				}
				return new RasterizedSpline(list);
			}

			public RasterizedSpline RasterizeWithTangents(int resolution)
			{
				List<Vector2> list = new List<Vector2>(resolution);
				List<Vector2> list2 = new List<Vector2>(resolution);
				float num = 1f / (float)(resolution - 1);
				for (int i = 0; i < resolution; i++)
				{
					float time = num * (float)i;
					Vector2 item = Evaluate(time);
					Vector2 item2 = EvaluateTangent(time);
					item2.Normalize();
					list.Add(item);
					list2.Add(item2);
				}
				return new RasterizedSpline(list, list2);
			}

			public RasterizedSpline RasterizeWithOffset(float distance, int resolution)
			{
				RasterizedSpline rasterizedSpline = RasterizeWithTangents(resolution);
				List<Vector2> list = new List<Vector2>(resolution);
				for (int i = 0; i < rasterizedSpline.Resolution; i++)
				{
					Vector2 vector = rasterizedSpline.Positions[i];
					Vector2 normal = rasterizedSpline.Tangents[i].GetNormal();
					list.Add(vector + normal * distance);
				}
				return new RasterizedSpline(list);
			}

			public List<Vector2> EvaluateTangents(int resolution)
			{
				List<Vector2> list = new List<Vector2>(resolution);
				float num = 1f / (float)(resolution - 1);
				for (int i = 0; i < resolution; i++)
				{
					Vector2 item = EvaluateTangent(num * (float)i);
					list.Add(item);
				}
				return list;
			}

			public static BezierSpline Lerp(BezierSpline a, BezierSpline b, float t)
			{
				return new BezierSpline(Vector2.LerpUnclamped(a.inPoint, b.inPoint, t), Vector2.LerpUnclamped(a.inHandle, b.inHandle, t), Vector2.LerpUnclamped(a.outHandle, b.outHandle, t), Vector2.LerpUnclamped(a.outPoint, b.outPoint, t));
			}

			protected bool Equals(BezierSpline other)
			{
				if (inPoint.Equals(other.inPoint) && inHandle.Equals(other.inHandle) && outHandle.Equals(other.outHandle))
				{
					return outPoint.Equals(other.outPoint);
				}
				return false;
			}
		}

		public class BezierSplineWithRotation : BezierSpline
		{
			public readonly Quaternion startRotation;

			public readonly Quaternion endRotation;

			public BezierSplineWithRotation(Vector2 inP, Vector2 inH, Vector2 outH, Vector2 outP, Quaternion inRot, Quaternion outRot)
				: base(inP, inH, outH, outP)
			{
				startRotation = inRot;
				endRotation = outRot;
			}

			public Quaternion EvaluateRotation(float time)
			{
				return Quaternion.Slerp(startRotation, endRotation, time);
			}
		}

		public class BezierSplineFixed
		{
			public class Serializer : PrimitiveSerializer
			{
				public override bool Serialize(object obj, ExportContext context)
				{
					if (obj is BezierSplineFixed bezierSplineFixed)
					{
						context.Writer.Write(value: true);
						ISerializer serializer = SerializerLibrary.GetSerializer<Vector2Fixed>();
						serializer.Serialize(bezierSplineFixed.inPoint, context);
						serializer.Serialize(bezierSplineFixed.inHandle, context);
						serializer.Serialize(bezierSplineFixed.outHandle, context);
						serializer.Serialize(bezierSplineFixed.outPoint, context);
						return true;
					}
					context.Writer.Write(value: false);
					return true;
				}

				public override object Deserialize(object existingObj, ImportContext context)
				{
					if (context.Reader.ReadBoolean())
					{
						ISerializer serializer = SerializerLibrary.GetSerializer<Vector2Fixed>();
						return new BezierSplineFixed((Vector2Fixed)serializer.Deserialize(null, context), (Vector2Fixed)serializer.Deserialize(null, context), (Vector2Fixed)serializer.Deserialize(null, context), (Vector2Fixed)serializer.Deserialize(null, context));
					}
					return null;
				}
			}

			public readonly Vector2Fixed inPoint;

			public readonly Vector2Fixed inHandle;

			public readonly Vector2Fixed outHandle;

			public readonly Vector2Fixed outPoint;

			public BezierSplineFixed(Vector2Fixed inP, Vector2Fixed inH, Vector2Fixed outH, Vector2Fixed outP)
			{
				inPoint = inP;
				inHandle = inH;
				outHandle = outH;
				outPoint = outP;
			}

			public Vector2Fixed Evaluate(Fix64 time)
			{
				return EvaluateBezier(time, inPoint, inHandle, outHandle, outPoint);
			}

			public Fix64 Length(int resolution = 25)
			{
				Fix64 zero = Fix64.Zero;
				Fix64 fix = Fix64.One / (Fix64)resolution;
				for (int i = 0; i < resolution; i++)
				{
					Fix64 time = fix * (Fix64)i;
					Vector2Fixed a = Evaluate(time);
					Fix64 time2 = fix * (Fix64)(i + 1);
					Vector2Fixed b = Evaluate(time2);
					zero += Vector2Fixed.Distance(a, b);
				}
				return zero;
			}

			public List<Vector2Fixed> Rasterize(int resolution)
			{
				List<Vector2Fixed> list = new List<Vector2Fixed>(resolution);
				Fix64 fix = Fix64.One / ((Fix64)resolution - Fix64.One);
				for (Fix64 zero = Fix64.Zero; zero < (Fix64)resolution; zero += Fix64.One)
				{
					Vector2Fixed item = Evaluate(fix * zero);
					list.Add(item);
				}
				return list;
			}
		}

		public class PiecewiseBezierSpline
		{
			private struct IndexInfo
			{
				public int segmentIndex;

				public float tValue;

				public IndexInfo(int segmentIndex, float tValue)
				{
					this.segmentIndex = segmentIndex;
					this.tValue = tValue;
				}
			}

			public BezierSpline[] segments;

			public PiecewiseBezierSpline(BezierSpline[] segments)
			{
				this.segments = segments;
			}

			public Vector2 Evaluate(float t)
			{
				IndexInfo indexInfo = ComputeIndexInfo(t);
				return segments[indexInfo.segmentIndex].Evaluate(indexInfo.tValue);
			}

			public Vector2 EvaluateTangent(float t)
			{
				IndexInfo indexInfo = ComputeIndexInfo(t);
				return segments[indexInfo.segmentIndex].EvaluateTangent(indexInfo.tValue);
			}

			public float Length()
			{
				float num = 0f;
				BezierSpline[] array = segments;
				foreach (BezierSpline bezierSpline in array)
				{
					num += bezierSpline.Length();
				}
				return num;
			}

			private IndexInfo ComputeIndexInfo(float t)
			{
				if ((double)t == 1.0)
				{
					return new IndexInfo(segments.Length - 1, 1f);
				}
				float num = t * (float)segments.Length;
				int num2 = (int)Math.Floor(num);
				float tValue = num - (float)num2;
				if (Diagnostics.Verify(num2 >= 0 && num2 <= segments.Length))
				{
					return new IndexInfo(num2, tValue);
				}
				return new IndexInfo(-1, 0f);
			}

			public RasterizedSpline Offset(float distance, int resolution)
			{
				int num = resolution / segments.Length;
				int num2 = num * segments.Length;
				int num3 = resolution - num2;
				RasterizedSpline rasterizedSpline = new RasterizedSpline(num2 + num3);
				for (int i = 0; i < segments.Length; i++)
				{
					BezierSpline bezierSpline = segments[i];
					int resolution2 = ((i == 0) ? (num + num3) : num);
					rasterizedSpline.Append(bezierSpline.RasterizeWithOffset(distance, resolution2));
				}
				return rasterizedSpline;
			}

			public RasterizedSpline Rasterize(int resolution)
			{
				int num = resolution / segments.Length;
				int num2 = num * segments.Length;
				int num3 = resolution - num2;
				RasterizedSpline rasterizedSpline = new RasterizedSpline(num2 + num3);
				for (int i = 0; i < segments.Length; i++)
				{
					BezierSpline bezierSpline = segments[i];
					int resolution2 = ((i == 0) ? (num + num3) : num);
					rasterizedSpline.Append(bezierSpline.Rasterize(resolution2));
				}
				return rasterizedSpline;
			}

			public RasterizedSpline RasterizeWithTangents(int resolution)
			{
				int num = resolution / segments.Length;
				int num2 = num * segments.Length;
				int num3 = resolution - num2;
				RasterizedSpline rasterizedSpline = new RasterizedSpline(num2 + num3);
				for (int i = 0; i < segments.Length; i++)
				{
					BezierSpline bezierSpline = segments[i];
					int resolution2 = ((i == 0) ? (num + num3) : num);
					rasterizedSpline.Append(bezierSpline.RasterizeWithTangents(resolution2));
				}
				return rasterizedSpline;
			}

			public override bool Equals(object obj)
			{
				if (obj is PiecewiseBezierSpline piecewiseBezierSpline)
				{
					if (piecewiseBezierSpline.segments.Length != segments.Length)
					{
						return false;
					}
					for (int i = 0; i < piecewiseBezierSpline.segments.Length; i++)
					{
						BezierSpline obj2 = piecewiseBezierSpline.segments[i];
						BezierSpline obj3 = segments[i];
						if (!obj2.Equals(obj3))
						{
							return false;
						}
					}
					return true;
				}
				return false;
			}

			public override int GetHashCode()
			{
				return base.GetHashCode();
			}
		}

		public class RasterizedSpline
		{
			private List<Vector2> _positionSamples;

			private List<Vector2> _tangentSamples;

			public List<Vector2> Positions => _positionSamples;

			public List<Vector2> Tangents => _tangentSamples;

			public int Resolution => _positionSamples.Count;

			public float Length
			{
				get
				{
					if (_positionSamples.Count <= 0)
					{
						return 0f;
					}
					Vector2 b = _positionSamples[0];
					float num = 0f;
					for (int i = 1; i < _positionSamples.Count; i++)
					{
						Vector2 vector = _positionSamples[i];
						num += Vector2.Distance(vector, b);
						b = vector;
					}
					return num;
				}
			}

			public RasterizedSpline(int sampleCapacity)
			{
				_positionSamples = new List<Vector2>(sampleCapacity);
				_tangentSamples = null;
			}

			public RasterizedSpline(List<Vector2> positionSamples)
			{
				_positionSamples = positionSamples;
				_tangentSamples = null;
			}

			public RasterizedSpline(List<Vector2> positionSamples, List<Vector2> tangentSamples)
			{
				_positionSamples = positionSamples;
				_tangentSamples = tangentSamples;
			}

			public void Append(RasterizedSpline rasterizedSpline)
			{
				if (_positionSamples.Count > 0 && rasterizedSpline._positionSamples.Count > 0 && _positionSamples[(_positionSamples.Count != 1) ? (_positionSamples.Count - 1) : 0] == rasterizedSpline._positionSamples[0])
				{
					_positionSamples.RemoveAt(_positionSamples.Count - 1);
					_tangentSamples?.RemoveAt(_tangentSamples.Count - 1);
				}
				_positionSamples.AddRange(rasterizedSpline._positionSamples);
				if (rasterizedSpline._tangentSamples != null)
				{
					if (_tangentSamples == null)
					{
						_tangentSamples = new List<Vector2>(rasterizedSpline._tangentSamples.Count);
					}
					_tangentSamples.AddRange(rasterizedSpline._tangentSamples);
				}
			}

			public void Truncate(float maxLength)
			{
				for (int i = 0; i < _positionSamples.Count - 1; i++)
				{
					Vector2 vector = _positionSamples[i + 1] - _positionSamples[i];
					float magnitude = vector.magnitude;
					if (magnitude >= maxLength)
					{
						_positionSamples[i + 1] = _positionSamples[i] + vector * (maxLength / magnitude);
						_positionSamples.RemoveRange(i + 2, _positionSamples.Count - (i + 2));
						if (_tangentSamples != null)
						{
							_tangentSamples[i + 1] = _tangentSamples[i] + vector * (maxLength / magnitude);
							_tangentSamples.RemoveRange(i + 2, _tangentSamples.Count - (i + 2));
						}
						break;
					}
					maxLength -= magnitude;
				}
			}

			public int ComputeIntersectionCountWithLineSegment(Vector2 origin, Vector2 direction)
			{
				if (_positionSamples.Count <= 0)
				{
					return 0;
				}
				int num = 0;
				Vector2 vector = _positionSamples[0];
				for (int i = 1; i < Resolution; i++)
				{
					Vector2 vector2 = _positionSamples[i];
					Vector2 vector3 = vector2 - vector;
					if (LineIntersection.LineLineIntersection(vector.x, vector.y, vector3.x, vector3.y, origin.x, origin.y, direction.x, direction.y, out var _, out var _) == LineIntersection.Point)
					{
						num++;
					}
					vector = vector2;
				}
				return num;
			}

			public List<Vector2> ComputeIntersectionsWithLineSegment(Vector2 origin, Vector2 direction)
			{
				List<Vector2> list = new List<Vector2>();
				if (_positionSamples.Count <= 0)
				{
					return list;
				}
				Vector2 vector = _positionSamples[0];
				for (int i = 1; i < Resolution; i++)
				{
					Vector2 vector2 = _positionSamples[i];
					Vector2 endA = vector2 - vector;
					LineIntersection.IntersectionInfo intersectionInfo = LineIntersection.LineLineIntersection(vector, endA, origin, direction);
					if (intersectionInfo.type == LineIntersection.IntersectionInfo.IntersectionType.Point)
					{
						list.Add(intersectionInfo.intersection);
					}
					vector = vector2;
				}
				return list;
			}

			public void ExtendOutAtEnds(float distance)
			{
				if (_positionSamples.Count >= 2)
				{
					Vector2 normalized = (_positionSamples[0] - _positionSamples[1]).normalized;
					Vector2 vector = ((_positionSamples.Count != 2) ? (_positionSamples[_positionSamples.Count - 1] - _positionSamples[_positionSamples.Count - 2]).normalized : (-normalized));
					_positionSamples.Insert(0, _positionSamples[0] + distance * normalized);
					_tangentSamples?.Insert(0, _tangentSamples[0]);
					_positionSamples.Add(_positionSamples[_positionSamples.Count - 1] + distance * vector);
					_tangentSamples?.Add(_tangentSamples[_tangentSamples.Count - 1]);
				}
			}

			public RasterizedSpline Offset(float distance)
			{
				if (Tangents == null)
				{
					Diagnostics.FailAssert("Cannot offset RasterizedSpline as it has no tangents.");
					return null;
				}
				List<Vector2> list = new List<Vector2>(Resolution);
				for (int i = 0; i < Resolution; i++)
				{
					Vector2 vector = Positions[i];
					Vector2 normal = Tangents[i].GetNormal();
					list.Add(vector + normal * distance);
				}
				return new RasterizedSpline(list, Tangents);
			}
		}

		public static Vector2 EvaluateBezier(float time, Vector2 inPoint, Vector2 inHandle, Vector2 outHandle, Vector2 outPoint)
		{
			float num = 1f - time;
			float num2 = num * num;
			float num3 = num2 * num;
			float num4 = time * time;
			float num5 = num4 * time;
			float num6 = num3 * inPoint.x;
			float num7 = num3 * inPoint.y;
			num6 += 3f * num2 * time * inHandle.x;
			num7 += 3f * num2 * time * inHandle.y;
			num6 += 3f * num * num4 * outHandle.x;
			num7 += 3f * num * num4 * outHandle.y;
			num6 += num5 * outPoint.x;
			num7 += num5 * outPoint.y;
			return new Vector2(num6, num7);
		}

		public static Vector2Fixed EvaluateBezier(Fix64 time, Vector2Fixed inPoint, Vector2Fixed inHandle, Vector2Fixed outHandle, Vector2Fixed outPoint)
		{
			Fix64 fix = Fix64.One - time;
			Fix64 fix2 = fix * fix;
			Fix64 fix3 = fix2 * fix;
			Fix64 fix4 = time * time;
			Fix64 fix5 = fix4 * time;
			return fix3 * inPoint + (Fix64)3L * fix2 * time * inHandle + (Fix64)3L * fix * fix4 * outHandle + fix5 * outPoint;
		}
	}
}
