using UnityEngine;

namespace Shapes
{
	public class PolygonPath : PointPath<Vector2>
	{
		private PolygonTriangulation lastUsedTriangulationMode = PolygonTriangulation.EarClipping;

		public void AddPoint(float x, float y)
		{
			AddPoint(new Vector2(x, y));
		}

		public void BezierTo(Vector2 startTangent, Vector2 endTangent, Vector2 end, int pointCount)
		{
			if (!CheckCanAddContinuePoint("BezierTo"))
			{
				AddPoints(ShapesMath.CubicBezierPointsSkipFirst(base.LastPoint, startTangent, endTangent, end, pointCount));
			}
		}

		public void BezierTo(Vector2 startTangent, Vector2 endTangent, Vector2 end, float pointsPerTurn)
		{
			int vertCount = ShapesConfig.Instance.polylineBezierAngularSumAccuracy * 2 + 1;
			float num = ShapesMath.GetApproximateCurveSum(base.LastPoint, startTangent, endTangent, end, vertCount) / 360f;
			int pointCount = Mathf.Max(2, Mathf.RoundToInt(num * ShapesConfig.Instance.polylineDefaultPointsPerTurn));
			BezierTo(startTangent, endTangent, end, pointCount);
		}

		public void ArcTo(Vector2 corner, Vector2 next, float radius, float pointsPerTurn)
		{
			if (!CheckCanAddContinuePoint("ArcTo"))
			{
				AddArcPoints(corner, next, radius, useDensity: true, 0, pointsPerTurn);
			}
		}

		public void ArcTo(Vector2 corner, Vector2 next, float radius, int pointCount)
		{
			if (!CheckCanAddContinuePoint("ArcTo"))
			{
				AddArcPoints(corner, next, radius, useDensity: false, pointCount, 0f);
			}
		}

		public void ArcTo(Vector2 corner, Vector2 next, float radius)
		{
			if (!CheckCanAddContinuePoint("ArcTo"))
			{
				AddArcPoints(corner, next, radius, useDensity: true, 0, ShapesConfig.Instance.polylineDefaultPointsPerTurn);
			}
		}

		public void ArcTo(Vector2 corner, Vector2 next, float radius, float pointsPerTurn, Color color)
		{
			if (!CheckCanAddContinuePoint("ArcTo"))
			{
				AddArcPoints(corner, next, radius, useDensity: true, 0, pointsPerTurn);
			}
		}

		private void AddArcPoints(Vector2 corner, Vector2 next, float radius, bool useDensity, int targetPointCount, float pointsPerTurn)
		{
			if (radius <= 0.0001f)
			{
				AddPoint(corner);
				return;
			}
			Vector2 normalized = (corner - base.LastPoint).normalized;
			Vector2 normalized2 = (next - corner).normalized;
			if (Vector2.Dot(normalized, normalized2) > 0.999f)
			{
				AddPoint(corner);
				return;
			}
			Vector2 vector = ShapesMath.Rotate90CW(normalized);
			Vector2 vector2 = ShapesMath.Rotate90CW(normalized2);
			Vector2 normalized3 = (vector + vector2).normalized;
			float num = Vector2.Dot(normalized3, vector2);
			Vector2 center = corner + normalized3 * (radius / num);
			if (useDensity)
			{
				targetPointCount = Mathf.RoundToInt(Vector2.Angle(vector, vector2) / 360f * pointsPerTurn);
			}
			AddPoints(ShapesMath.GetArcPoints(-vector, -vector2, center, radius, targetPointCount));
		}

		public bool EnsureMeshIsReadyToRender(PolygonTriangulation triangulation, out Mesh outMesh)
		{
			if (!meshDirty && triangulation != lastUsedTriangulationMode)
			{
				meshDirty = true;
			}
			return EnsureMeshIsReadyToRender(out outMesh, delegate
			{
				TryUpdateMesh(triangulation);
			});
		}

		private void TryUpdateMesh(PolygonTriangulation triangulation)
		{
			lastUsedTriangulationMode = triangulation;
			ShapesMeshGen.GenPolygonMesh(mesh, path, triangulation);
		}
	}
}
