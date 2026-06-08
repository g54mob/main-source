using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Shapes
{
	public class PolylinePath : PointPath<PolylinePoint>
	{
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

		public void AddPoint(float x, float y)
		{
			AddPoint(new PolylinePoint(new Vector3(x, y, 0f), Color.white));
		}

		public void AddPoint(float x, float y, float z)
		{
			AddPoint(new PolylinePoint(new Vector3(x, y, z), Color.white));
		}

		public void AddPoint(float x, float y, Color color)
		{
			AddPoint(new PolylinePoint(new Vector3(x, y, 0f), color));
		}

		public void AddPoint(float x, float y, float z, Color color)
		{
			AddPoint(new PolylinePoint(new Vector3(x, y, z), color));
		}

		public void AddPoint(Vector3 pos)
		{
			AddPoint(new PolylinePoint(pos, Color.white));
		}

		public void AddPoint(Vector3 pos, Color color)
		{
			AddPoint(new PolylinePoint(pos, color));
		}

		public void AddPoint(Vector3 pos, float thickness)
		{
			AddPoint(new PolylinePoint(pos, Color.white, thickness));
		}

		public void AddPoint(Vector3 pos, float thickness, Color color)
		{
			AddPoint(new PolylinePoint(pos, color, thickness));
		}

		public void AddPoint(Vector2 pos)
		{
			AddPoint(new PolylinePoint(pos, Color.white));
		}

		public void AddPoint(Vector2 pos, Color color)
		{
			AddPoint(new PolylinePoint(pos, color));
		}

		public void AddPoint(Vector2 pos, float thickness)
		{
			AddPoint(new PolylinePoint(pos, Color.white, thickness));
		}

		public void AddPoint(Vector2 pos, float thickness, Color color)
		{
			AddPoint(new PolylinePoint(pos, color, thickness));
		}

		public void AddPoints(IEnumerable<Vector3> pts)
		{
			AddPoints(pts.Select((Vector3 point) => new PolylinePoint(point, Color.white)));
		}

		public void AddPoints(params Vector3[] pts)
		{
			AddPoints(pts.Select((Vector3 point) => new PolylinePoint(point, Color.white)));
		}

		public void AddPoints(IEnumerable<Vector2> pts)
		{
			AddPoints(pts.Select((Vector2 point) => new PolylinePoint(point, Color.white)));
		}

		public void AddPoints(params Vector2[] pts)
		{
			AddPoints(pts.Select((Vector2 point) => new PolylinePoint(point, Color.white)));
		}

		public void AddPoints(IEnumerable<Vector3> pts, Color color)
		{
			AddPoints(pts.Select((Vector3 point) => new PolylinePoint(point, color)));
		}

		public void AddPoints(IEnumerable<Vector2> pts, Color color)
		{
			AddPoints(pts.Select((Vector2 point) => new PolylinePoint(point, color)));
		}

		public void AddPoints(IEnumerable<Vector3> pts, IEnumerable<Color> colors)
		{
			AddPoints(pts.Zip(colors, (Vector3 p, Color c) => new PolylinePoint(p, c)));
		}

		public void AddPoints(IEnumerable<Vector2> pts, IEnumerable<Color> colors)
		{
			AddPoints(pts.Zip(colors, (Vector2 p, Color c) => new PolylinePoint(p, c)));
		}

		public void AddPoints(IEnumerable<Vector3> pts, IEnumerable<float> thicknesses)
		{
			AddPoints(pts.Zip(thicknesses, (Vector3 p, float t) => new PolylinePoint(p, Color.white, t)));
		}

		public void AddPoints(IEnumerable<Vector2> pts, IEnumerable<float> thicknesses)
		{
			AddPoints(pts.Zip(thicknesses, (Vector2 p, float t) => new PolylinePoint(p, Color.white, t)));
		}

		public void AddPoints(IEnumerable<Vector3> pts, IEnumerable<float> thicknesses, IEnumerable<Color> colors)
		{
			AddPoints(pts.Zip(colors, thicknesses, (Vector3 p, Color c, float t) => new PolylinePoint(p, c, t)));
		}

		public void AddPoints(IEnumerable<Vector2> pts, IEnumerable<float> thicknesses, IEnumerable<Color> colors)
		{
			AddPoints(pts.Zip(colors, thicknesses, (Vector2 p, Color c, float t) => new PolylinePoint(p, c, t)));
		}

		public void BezierTo(Vector3 startTangent, Vector3 endTangent, Vector3 end, int pointCount)
		{
			BezierTo(startTangent, endTangent, end, pointCount, Color.white);
		}

		public void BezierTo(Vector3 startTangent, Vector3 endTangent, Vector3 end, int pointCount, Color color)
		{
			if (!CheckCanAddContinuePoint("BezierTo"))
			{
				AddPoints(ShapesMath.CubicBezierPointsSkipFirst(base.LastPoint.point, startTangent, endTangent, end, pointCount), color);
			}
		}

		public void BezierTo(Vector3 startTangent, Vector3 endTangent, Vector3 end)
		{
			BezierTo(startTangent, endTangent, end, ShapesConfig.Instance.polylineDefaultPointsPerTurn, Color.white);
		}

		public void BezierTo(Vector3 startTangent, Vector3 endTangent, Vector3 end, Color color)
		{
			BezierTo(startTangent, endTangent, end, ShapesConfig.Instance.polylineDefaultPointsPerTurn, color);
		}

		public void BezierTo(Vector3 startTangent, Vector3 endTangent, Vector3 end, float pointsPerTurn)
		{
			BezierTo(startTangent, endTangent, end, pointsPerTurn, Color.white);
		}

		public void BezierTo(Vector3 startTangent, Vector3 endTangent, Vector3 end, float pointsPerTurn, Color color)
		{
			int vertCount = ShapesConfig.Instance.polylineBezierAngularSumAccuracy * 2 + 1;
			float num = ShapesMath.GetApproximateCurveSum(base.LastPoint.point, startTangent, endTangent, end, vertCount) / 360f;
			int pointCount = Mathf.Max(2, Mathf.RoundToInt(num * pointsPerTurn));
			BezierTo(startTangent, endTangent, end, pointCount, color);
		}

		public void ArcTo(Vector3 corner, Vector3 next, float radius, int pointCount)
		{
			if (!CheckCanAddContinuePoint("ArcTo"))
			{
				AddArcPoints(corner, next, radius, useDensity: false, pointCount, 0f, Color.white);
			}
		}

		public void ArcTo(Vector3 corner, Vector3 next, float radius)
		{
			if (!CheckCanAddContinuePoint("ArcTo"))
			{
				AddArcPoints(corner, next, radius, useDensity: true, 0, ShapesConfig.Instance.polylineDefaultPointsPerTurn, Color.white);
			}
		}

		public void ArcTo(Vector3 corner, Vector3 next, float radius, float pointsPerTurn)
		{
			if (!CheckCanAddContinuePoint("ArcTo"))
			{
				AddArcPoints(corner, next, radius, useDensity: true, 0, pointsPerTurn, Color.white);
			}
		}

		public void ArcTo(Vector3 corner, Vector3 next, float radius, int pointCount, Color color)
		{
			if (!CheckCanAddContinuePoint("ArcTo"))
			{
				AddArcPoints(corner, next, radius, useDensity: false, pointCount, 0f, color);
			}
		}

		public void ArcTo(Vector3 corner, Vector3 next, float radius, Color color)
		{
			if (!CheckCanAddContinuePoint("ArcTo"))
			{
				AddArcPoints(corner, next, radius, useDensity: true, 0, ShapesConfig.Instance.polylineDefaultPointsPerTurn, color);
			}
		}

		public void ArcTo(Vector3 corner, Vector3 next, float radius, float pointsPerTurn, Color color)
		{
			if (!CheckCanAddContinuePoint("ArcTo"))
			{
				AddArcPoints(corner, next, radius, useDensity: true, 0, pointsPerTurn, color);
			}
		}

		private void AddArcPoints(Vector3 corner, Vector3 next, float radius, bool useDensity, int targetPointCount, float pointsPerTurn, Color color)
		{
			if (radius <= 0.0001f)
			{
				AddPoint(corner, color);
				return;
			}
			Vector3 normalized = (corner - base.LastPoint.point).normalized;
			Vector3 normalized2 = (next - corner).normalized;
			Vector3 v = Vector3.Cross(normalized, normalized2);
			if (v.TaxicabMagnitude() <= 0.001f)
			{
				AddPoint(corner, color);
				return;
			}
			Vector3 normalized3 = v.normalized;
			Vector3 vector = Vector3.Cross(normalized3, normalized);
			Vector3 vector2 = Vector3.Cross(normalized3, normalized2);
			Vector3 normalized4 = (vector + vector2).normalized;
			float num = Vector3.Dot(normalized4, vector2);
			Vector3 center = corner + normalized4 * (radius / num);
			if (useDensity)
			{
				targetPointCount = Mathf.RoundToInt(Vector3.Angle(vector, vector2) / 360f * pointsPerTurn);
			}
			AddPoints(ShapesMath.GetArcPoints(-vector, -vector2, center, radius, targetPointCount), color);
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
	}
}
