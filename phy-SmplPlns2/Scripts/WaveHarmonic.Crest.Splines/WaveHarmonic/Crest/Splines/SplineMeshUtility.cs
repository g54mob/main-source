using System;
using System.Buffers;
using System.Collections.Generic;
using UnityEngine;
using WaveHarmonic.Crest.Internal;

namespace WaveHarmonic.Crest.Splines
{
	internal static class SplineMeshUtility
	{
		private static readonly List<SplinePoint> s_SplinePoints = new List<SplinePoint>();

		public static bool GenerateMeshFromSpline<T>(Spline spline, Transform transform, int subdivisions, float radius, Vector4 customDataDefault, ref Mesh mesh, ref Vector3[] verts) where T : SplinePointData
		{
			spline.GetComponentsInChildren(includeInactive: false, s_SplinePoints);
			if (s_SplinePoints.Count < 2)
			{
				mesh = null;
				return false;
			}
			int num = s_SplinePoints.Count;
			if (spline._Closed && num > 2)
			{
				num++;
			}
			ArrayPool<Vector3> shared = ArrayPool<Vector3>.Shared;
			ArrayPool<Vector4> shared2 = ArrayPool<Vector4>.Shared;
			int num2 = (num - 1) * 3 + 1;
			Vector3[] array = shared.Rent(num2);
			Span<Vector3> span = array.AsSpan();
			Span<Vector3> splinePointsAndTangents = span.Slice(0, num2);
			if (!SplineInterpolation.GenerateCubicSplineHull(s_SplinePoints, splinePointsAndTangents, spline._Closed))
			{
				return false;
			}
			bool flag = typeof(T) != typeof(SplinePointData);
			float num3 = 0f;
			for (int i = 1; i < num; i++)
			{
				num3 += (s_SplinePoints[i % s_SplinePoints.Count].transform.position - s_SplinePoints[i - 1].transform.position).magnitude;
			}
			num3 = Mathf.Max(num3, 1f);
			float num4 = 16f / Mathf.Pow(2f, subdivisions + 1);
			int a = Mathf.CeilToInt(num3 / num4);
			a = Mathf.Max(a, 1);
			Vector3[] array2 = shared.Rent(a);
			Vector3[] array3 = shared.Rent(a);
			Vector3[] array4 = shared.Rent(a);
			span = array2.AsSpan();
			Span<Vector3> pointsOnSpline = span.Slice(0, a);
			span = array3.AsSpan();
			Span<Vector3> span2 = span.Slice(0, a);
			span = array4.AsSpan();
			Span<Vector3> span3 = span.Slice(0, a);
			pointsOnSpline[0] = splinePointsAndTangents[0];
			Vector4[] array5 = shared2.Rent(a);
			Span<Vector4> span4 = array5.AsSpan().Slice(0, a);
			span4[0] = customDataDefault;
			if (flag && s_SplinePoints[0].TryGetComponent<T>(out var component))
			{
				span4[0] = component.GetData(customDataDefault);
			}
			for (int j = 1; j < a; j++)
			{
				float t = (float)j / (float)(a - 1);
				SplineInterpolation.InterpolateCubicPosition(num, splinePointsAndTangents, t, out pointsOnSpline[j]);
			}
			float num5;
			float num6;
			if (spline._Offset == SplineOffset.Left)
			{
				num5 = radius * 2f;
				num6 = 0f;
			}
			else if (spline._Offset == SplineOffset.Center)
			{
				num5 = (num6 = radius);
			}
			else
			{
				num5 = 0f;
				num6 = radius * 2f;
			}
			for (int k = 0; k < a; k++)
			{
				int num7 = k - 1;
				int num8 = k + 1;
				if (!spline._Closed)
				{
					num7 = Mathf.Max(num7, 0);
					num8 = Mathf.Min(num8, a - 1);
				}
				else
				{
					if (num7 < 0)
					{
						num7 += a;
					}
					num8 %= a;
				}
				float num9 = 0f;
				if (k > 0)
				{
					float num10 = (float)k / (float)(a - 1) * ((float)s_SplinePoints.Count - 1f);
					int num11 = Mathf.FloorToInt(num10);
					float t2 = num10 - (float)num11;
					float radiusMultiplier = s_SplinePoints[num11]._RadiusMultiplier;
					float radiusMultiplier2 = s_SplinePoints[Mathf.Min(num11 + 1, s_SplinePoints.Count - 1)]._RadiusMultiplier;
					num9 = Mathf.Lerp(radiusMultiplier, radiusMultiplier2, Mathf.SmoothStep(0f, 1f, t2));
					Vector4 a2 = customDataDefault;
					if (flag && s_SplinePoints[num11].TryGetComponent<T>(out var component2))
					{
						a2 = component2.GetData(customDataDefault);
					}
					Vector4 b = customDataDefault;
					if (flag && s_SplinePoints[Mathf.Min(num11 + 1, s_SplinePoints.Count - 1)].TryGetComponent<T>(out var component3))
					{
						b = component3.GetData(customDataDefault);
					}
					span4[k] = Vector4.Lerp(a2, b, Mathf.SmoothStep(0f, 1f, t2));
				}
				else
				{
					num9 = s_SplinePoints[0]._RadiusMultiplier;
				}
				Vector3 vector = pointsOnSpline[num8] - pointsOnSpline[num7];
				Vector3 vector2 = vector;
				vector2.x = vector.z;
				vector2.z = 0f - vector.x;
				vector2.y = 0f;
				vector2 = vector2.normalized;
				span2[k] = pointsOnSpline[k] - num5 * num9 * vector2;
				span3[k] = pointsOnSpline[k] + num9 * num6 * vector2;
			}
			if (spline._Closed)
			{
				Vector3 vector3 = Vector3.Lerp(span3[0], span3[span3.Length - 1], 0.5f);
				span3[0] = (span3[span3.Length - 1] = vector3);
			}
			ResolveOverlaps(span2, pointsOnSpline);
			ResolveOverlaps(span3, pointsOnSpline);
			for (int l = 0; l < 5; l++)
			{
				for (int m = 1; m < span2.Length - 1; m++)
				{
					pointsOnSpline[m] = 0.5f * (span2[m - 1] + span2[m + 1]);
				}
				for (int n = 1; n < span2.Length - 1; n++)
				{
					span2[n] = pointsOnSpline[n];
				}
				for (int num12 = 1; num12 < span3.Length - 1; num12++)
				{
					pointsOnSpline[num12] = 0.5f * (span3[num12 - 1] + span3[num12 + 1]);
				}
				for (int num13 = 1; num13 < span3.Length - 1; num13++)
				{
					span3[num13] = pointsOnSpline[num13];
				}
			}
			if (mesh == null)
			{
				mesh = new Mesh();
				mesh.name = transform.gameObject.name + "_SplineMesh";
			}
			else
			{
				mesh.Clear();
			}
			int num14 = (span2.Length - 1) * 2 * 3;
			ArrayPool<int> shared3 = ArrayPool<int>.Shared;
			int[] array6 = shared3.Rent(num14);
			int num15 = 2 * span2.Length;
			if (num15 != verts?.Length)
			{
				verts = new Vector3[num15];
			}
			Vector4[] array7 = shared2.Rent(num15);
			Vector4[] array8 = shared2.Rent(num15);
			transform.InverseTransformPoints(span2, span2);
			transform.InverseTransformPoints(span3, span3);
			for (int num16 = 0; num16 < span2.Length; num16++)
			{
				verts[2 * num16] = span2[num16];
				verts[2 * num16 + 1] = span3[num16];
				Vector2 normalized = new Vector2(verts[2 * num16].x - verts[2 * num16 + 1].x, verts[2 * num16].z - verts[2 * num16 + 1].z).normalized;
				array7[2 * num16] = new Vector4(1f, 0f, normalized.x, normalized.y);
				array7[2 * num16 + 1] = new Vector4(0f, 0f, normalized.x, normalized.y);
				array8[2 * num16] = span4[num16];
				array8[2 * num16 + 1] = span4[num16];
				if (num16 < span2.Length - 1)
				{
					int num17 = num16 + 1;
					array6[num16 * 6] = 2 * num16;
					array6[num16 * 6 + 1] = 2 * num17;
					array6[num16 * 6 + 2] = 2 * num16 + 1;
					array6[num16 * 6 + 3] = 2 * num17;
					array6[num16 * 6 + 4] = 2 * num17 + 1;
					array6[num16 * 6 + 5] = 2 * num16 + 1;
				}
			}
			mesh.SetVertices(verts);
			mesh.SetUVs(0, array7, 0, num15);
			mesh.SetUVs(1, array8, 0, num15);
			mesh.SetIndices(array6, 0, num14, MeshTopology.Triangles, 0);
			mesh.RecalculateNormals();
			shared3.Return(array6);
			shared2.Return(array7);
			shared2.Return(array8);
			shared.Return(array);
			shared.Return(array2);
			shared.Return(array3);
			shared.Return(array4);
			shared2.Return(array5);
			return true;
		}

		private static void ResolveOverlaps(Span<Vector3> points, Span<Vector3> pointsOnSpline)
		{
			if (points.Length < 2)
			{
				return;
			}
			Vector3 vector = points[1];
			for (int i = 1; i < points.Length; i++)
			{
				Vector3 vector2 = points[i];
				Vector3 rhs = pointsOnSpline[i] - pointsOnSpline[i - 1];
				Vector3 lhs = vector2 - vector;
				lhs.y = (rhs.y = 0f);
				if (Vector3.Dot(lhs, rhs) > 0f)
				{
					vector = vector2;
				}
				else
				{
					points[i] = vector.XNZ(vector2.y);
				}
			}
		}
	}
}
