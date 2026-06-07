using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace Shapes
{
	public class PolylinePath : PointPath<PolylinePoint>
	{
		private const MethodImplOptions INLINE = MethodImplOptions.AggressiveInlining;

		private bool lastUsedClosed;

		private PolylineJoins lastUsedJoins = PolylineJoins.Miter;

		public void SetPoint(int index, Vector3 point)
		{
			PolylinePoint point2 = path[index];
			point2.point = point;
			SetPoint(index, point2);
		}

		public void SetPoint(int index, Vector2 point)
		{
			PolylinePoint point2 = path[index];
			point2.point = point;
			SetPoint(index, point2);
		}

		public void SetColor(int index, Color color)
		{
			PolylinePoint point = path[index];
			point.color = color;
			SetPoint(index, point);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void AddPoint(float x, float y)
		{
			AddPoint(new PolylinePoint(new Vector3(x, y, 0f), Color.white));
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void AddPoint(float x, float y, float z)
		{
			AddPoint(new PolylinePoint(new Vector3(x, y, z), Color.white));
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void AddPoint(float x, float y, Color color)
		{
			AddPoint(new PolylinePoint(new Vector3(x, y, 0f), color));
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void AddPoint(float x, float y, float z, Color color)
		{
			AddPoint(new PolylinePoint(new Vector3(x, y, z), color));
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void AddPoint(Vector3 pos)
		{
			AddPoint(new PolylinePoint(pos, Color.white));
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void AddPoint(Vector3 pos, Color color)
		{
			AddPoint(new PolylinePoint(pos, color));
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void AddPoint(Vector3 pos, float thickness)
		{
			AddPoint(new PolylinePoint(pos, Color.white, thickness));
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void AddPoint(Vector3 pos, float thickness, Color color)
		{
			AddPoint(new PolylinePoint(pos, color, thickness));
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void AddPoint(Vector2 pos)
		{
			AddPoint(new PolylinePoint(pos, Color.white));
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void AddPoint(Vector2 pos, Color color)
		{
			AddPoint(new PolylinePoint(pos, color));
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void AddPoint(Vector2 pos, float thickness)
		{
			AddPoint(new PolylinePoint(pos, Color.white, thickness));
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void AddPoint(Vector2 pos, float thickness, Color color)
		{
			AddPoint(new PolylinePoint(pos, color, thickness));
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void AddPoints(IEnumerable<Vector3> pts)
		{
			AddPoints(pts.Select((Vector3 point) => new PolylinePoint(point, Color.white)));
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void AddPoints(params Vector3[] pts)
		{
			AddPoints(pts.Select((Vector3 point) => new PolylinePoint(point, Color.white)));
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void AddPoints(IEnumerable<Vector2> pts)
		{
			AddPoints(pts.Select((Vector2 point) => new PolylinePoint(point, Color.white)));
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void AddPoints(params Vector2[] pts)
		{
			AddPoints(pts.Select((Vector2 point) => new PolylinePoint(point, Color.white)));
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void AddPoints(IEnumerable<Vector3> pts, Color color)
		{
			AddPoints(pts.Select((Vector3 point) => new PolylinePoint(point, color)));
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void AddPoints(IEnumerable<Vector2> pts, Color color)
		{
			AddPoints(pts.Select((Vector2 point) => new PolylinePoint(point, color)));
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void AddPoints(IEnumerable<Vector3> pts, IEnumerable<Color> colors)
		{
			AddPoints(pts.Zip(colors, (Vector3 p, Color c) => new PolylinePoint(p, c)));
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void AddPoints(IEnumerable<Vector2> pts, IEnumerable<Color> colors)
		{
			AddPoints(pts.Zip(colors, (Vector2 p, Color c) => new PolylinePoint(p, c)));
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void AddPoints(IEnumerable<Vector3> pts, IEnumerable<float> thicknesses)
		{
			AddPoints(pts.Zip(thicknesses, (Vector3 p, float t) => new PolylinePoint(p, Color.white, t)));
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void AddPoints(IEnumerable<Vector2> pts, IEnumerable<float> thicknesses)
		{
			AddPoints(pts.Zip(thicknesses, (Vector2 p, float t) => new PolylinePoint(p, Color.white, t)));
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void AddPoints(IEnumerable<Vector3> pts, IEnumerable<float> thicknesses, IEnumerable<Color> colors)
		{
			AddPoints(pts.Zip(colors, thicknesses, (Vector3 p, Color c, float t) => new PolylinePoint(p, c, t)));
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void AddPoints(IEnumerable<Vector2> pts, IEnumerable<float> thicknesses, IEnumerable<Color> colors)
		{
			AddPoints(pts.Zip(colors, thicknesses, (Vector2 p, Color c, float t) => new PolylinePoint(p, c, t)));
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void BezierTo(Vector3 startTangent, Vector3 endTangent, Vector3 end)
		{
			BezierTo(startTangent, endTangent, end, ShapesConfig.Instance.polylineDefaultPointsPerTurn);
		}

		public void BezierTo(Vector3 startTangent, Vector3 endTangent, Vector3 end, float pointsPerTurn)
		{
			if (!CheckCanAddContinuePoint("BezierTo"))
			{
				int pointCount = CalcBezierPointCount(base.LastPoint.point, startTangent, endTangent, end, pointsPerTurn);
				BezierTo(startTangent, endTangent, end, pointCount);
			}
		}

		public void BezierTo(Vector3 startTangent, Vector3 endTangent, Vector3 end, int pointCount)
		{
			if (!CheckCanAddContinuePoint("BezierTo"))
			{
				AddPoints(ShapesMath.CubicBezierPointsSkipFirstMatchStyle(base.LastPoint, base.LastPoint.point, startTangent, endTangent, end, pointCount));
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void BezierTo(Vector3 startTangent, Vector3 endTangent, PolylinePoint end)
		{
			BezierTo(startTangent, endTangent, end, ShapesConfig.Instance.polylineDefaultPointsPerTurn);
		}

		public void BezierTo(Vector3 startTangent, Vector3 endTangent, PolylinePoint end, float pointsPerTurn)
		{
			if (!CheckCanAddContinuePoint("BezierTo"))
			{
				int pointCount = CalcBezierPointCount(base.LastPoint.point, startTangent, endTangent, end.point, pointsPerTurn);
				BezierTo(startTangent, endTangent, end, pointCount);
			}
		}

		public void BezierTo(Vector3 startTangent, Vector3 endTangent, PolylinePoint end, int pointCount)
		{
			if (!CheckCanAddContinuePoint("BezierTo"))
			{
				PolylinePoint startTangent2 = PolylinePoint.Lerp(base.LastPoint, end, 1f / 3f);
				startTangent2.point = startTangent;
				PolylinePoint endTangent2 = PolylinePoint.Lerp(base.LastPoint, end, 2f / 3f);
				endTangent2.point = endTangent;
				BezierTo(startTangent2, endTangent2, end, pointCount);
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void BezierTo(PolylinePoint startTangent, PolylinePoint endTangent, PolylinePoint end)
		{
			BezierTo(startTangent, endTangent, end, ShapesConfig.Instance.polylineDefaultPointsPerTurn);
		}

		public void BezierTo(PolylinePoint startTangent, PolylinePoint endTangent, PolylinePoint end, float pointsPerTurn)
		{
			if (!CheckCanAddContinuePoint("BezierTo"))
			{
				int pointCount = CalcBezierPointCount(base.LastPoint.point, startTangent.point, endTangent.point, end.point, pointsPerTurn);
				BezierTo(startTangent, endTangent, end, pointCount);
			}
		}

		public void BezierTo(PolylinePoint startTangent, PolylinePoint endTangent, PolylinePoint end, int pointCount)
		{
			if (!CheckCanAddContinuePoint("BezierTo"))
			{
				AddPoints(ShapesMath.CubicBezierPointsSkipFirst(base.LastPoint, startTangent, endTangent, end, pointCount));
			}
		}

		private static int CalcBezierPointCount(Vector3 a, Vector3 b, Vector3 c, Vector3 d, float pointsPerTurn)
		{
			int vertCount = ShapesConfig.Instance.polylineBezierAngularSumAccuracy * 2 + 1;
			float num = ShapesMath.GetApproximateCurveSum(a, b, c, d, vertCount) / 360f;
			return Mathf.Max(2, Mathf.RoundToInt(num * pointsPerTurn));
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void ArcTo(Vector3 corner, Vector3 next, float radius, int pointCount)
		{
			AddArcPoints(corner, next, radius, useDensity: false, pointCount, 0f);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void ArcTo(Vector3 corner, PolylinePoint next, float radius, int pointCount)
		{
			AddArcPoints(corner, next, radius, useDensity: false, pointCount, 0f);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void ArcTo(Vector3 corner, Vector3 next, float radius)
		{
			AddArcPoints(corner, next, radius, useDensity: true, 0, ShapesConfig.Instance.polylineDefaultPointsPerTurn);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void ArcTo(Vector3 corner, PolylinePoint next, float radius)
		{
			AddArcPoints(corner, next, radius, useDensity: true, 0, ShapesConfig.Instance.polylineDefaultPointsPerTurn);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void ArcTo(Vector3 corner, Vector3 next, float radius, float pointsPerTurn)
		{
			AddArcPoints(corner, next, radius, useDensity: true, 0, pointsPerTurn);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void ArcTo(Vector3 corner, PolylinePoint next, float radius, float pointsPerTurn)
		{
			AddArcPoints(corner, next, radius, useDensity: true, 0, pointsPerTurn);
		}

		private void AddArcPoints(Vector3 corner, Vector3 next, float radius, bool useDensity, int targetPointCount, float pointsPerTurn)
		{
			if (!CheckCanAddContinuePoint("AddArcPoints"))
			{
				PolylinePoint lastPoint = base.LastPoint;
				lastPoint.point = next;
				AddArcPoints(corner, lastPoint, radius, useDensity, targetPointCount, pointsPerTurn);
			}
		}

		private void AddArcPoints(Vector3 corner, PolylinePoint next, float radius, bool useDensity, int targetPointCount, float pointsPerTurn)
		{
			if (CheckCanAddContinuePoint("AddArcPoints"))
			{
				return;
			}
			PolylinePoint lastPoint = base.LastPoint;
			Vector3 normalized = (corner - lastPoint.point).normalized;
			Vector3 normalized2 = (next.point - corner).normalized;
			Vector3 v = Vector3.Cross(normalized, normalized2);
			if (v.TaxicabMagnitude() <= 0.001f)
			{
				float lineSegmentProjectionT = ShapesMath.GetLineSegmentProjectionT(lastPoint.point, next.point, corner);
				float t = Mathf.Clamp01(lineSegmentProjectionT - 0.0001f);
				float t2 = Mathf.Clamp01(lineSegmentProjectionT + 0.0001f);
				PolylinePoint p = lastPoint;
				PolylinePoint p2 = next;
				p.point = Vector3.Lerp(lastPoint.point, next.point, t);
				p2.point = Vector3.Lerp(lastPoint.point, next.point, t2);
				AddPoint(p);
				AddPoint(p2);
				return;
			}
			Vector3 normalized3 = v.normalized;
			Vector3 vector = Vector3.Cross(normalized3, normalized);
			Vector3 vector2 = Vector3.Cross(normalized3, normalized2);
			Vector3 normalized4 = (vector + vector2).normalized;
			float num = Vector3.Dot(normalized4, vector2);
			radius = Mathf.Max(radius, 0.0001f);
			Vector3 center = corner + normalized4 * (radius / num);
			if (useDensity)
			{
				targetPointCount = Mathf.RoundToInt(Vector3.Angle(vector, vector2) / 360f * pointsPerTurn);
			}
			AddPoints(ShapesMath.GetArcPoints(lastPoint, next, -vector, -vector2, center, radius, targetPointCount));
		}

		public bool EnsureMeshIsReadyToRender(bool closed, PolylineJoins renderJoins, out Mesh outMesh)
		{
			if (!meshDirty && (renderJoins != lastUsedJoins || closed != lastUsedClosed))
			{
				meshDirty = true;
			}
			return EnsureMeshIsReadyToRender(out outMesh, delegate
			{
				TryUpdateMesh(closed, renderJoins);
			});
		}

		private void TryUpdateMesh(bool closed, PolylineJoins joins)
		{
			lastUsedClosed = closed;
			lastUsedJoins = joins;
			ShapesMeshGen.GenPolylineMesh(mesh, path, closed, joins, flattenZ: false, useColors: true);
		}

		[Obsolete("This function no longer exists - either use the overload without a color, where the color will match the previous point, or the one with a PolylinePoint endpoint, where the color will blend between previous point and the target point", true)]
		public void ArcTo(Vector3 corner, Vector3 next, float radius, int pointCount, Color color)
		{
			AddArcPoints(corner, next, radius, useDensity: false, pointCount, 0f);
		}

		[Obsolete("This function no longer exists - either use the overload without a color, where the color will match the previous point, or the one with a PolylinePoint endpoint, where the color will blend between previous point and the target point", true)]
		public void ArcTo(Vector3 corner, Vector3 next, float radius, Color color)
		{
			AddArcPoints(corner, next, radius, useDensity: true, 0, ShapesConfig.Instance.polylineDefaultPointsPerTurn);
		}

		[Obsolete("This function no longer exists - either use the overload without a color, where the color will match the previous point, or the one with a PolylinePoint endpoint, where the color will blend between previous point and the target point", true)]
		public void ArcTo(Vector3 corner, Vector3 next, float radius, float pointsPerTurn, Color color)
		{
			AddArcPoints(corner, next, radius, useDensity: true, 0, pointsPerTurn);
		}

		[Obsolete("This function no longer exists - either use the overload without a color, where the color will match the previous point, or the one with a PolylinePoint endpoint, where the color will blend between previous point and the target point", true)]
		public void BezierTo(Vector3 startTangent, Vector3 endTangent, Vector3 end, float pointsPerTurn, Color color)
		{
		}

		[Obsolete("This function no longer exists - either use the overload without a color, where the color will match the previous point, or the one with a PolylinePoint endpoint, where the color will blend between previous point and the target point", true)]
		public void BezierTo(Vector3 startTangent, Vector3 endTangent, Vector3 end, int pointCount, Color color)
		{
		}

		[Obsolete("This function no longer exists - either use the overload without a color, where the color will match the previous point, or the one with a PolylinePoint endpoint, where the color will blend between previous point and the target point", true)]
		public void BezierTo(Vector3 startTangent, Vector3 endTangent, Vector3 end, Color color)
		{
		}
	}
}
