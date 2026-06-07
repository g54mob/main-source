using System.Collections.Generic;
using UnityEngine;

namespace RLD
{
	public class GizmoRotationArc2D
	{
		public enum ArcType
		{
			Standard = 0,
			PolyProjected = 1
		}

		private ArcShape2D _arc = new ArcShape2D();

		private ArcType _type;

		private PolygonShape2D _projectionPoly;

		private int _numProjectedPoints = 100;

		public float RotationAngle
		{
			get
			{
				return _arc.DegreeAngleFromStart;
			}
			set
			{
				_arc.DegreeAngleFromStart = value;
			}
		}

		public ArcType Type
		{
			get
			{
				return _type;
			}
			set
			{
				_type = value;
			}
		}

		public PolygonShape2D ProjectionPoly
		{
			get
			{
				return _projectionPoly;
			}
			set
			{
				_projectionPoly = value;
			}
		}

		public int NumProjectedPoints
		{
			get
			{
				return _numProjectedPoints;
			}
			set
			{
				_numProjectedPoints = Mathf.Max(3, value);
			}
		}

		public void SetArcData(Vector2 arcOrigin, Vector2 arcStart, float radius)
		{
			_arc.Origin = arcOrigin;
			_arc.SetArcData(arcStart, radius);
		}

		public void Render(GizmoRotationArc2DLookAndFeel lookAndFeel, Camera camera)
		{
			if (_type == ArcType.Standard || _projectionPoly == null)
			{
				_arc.ForceShortestArc = lookAndFeel.UseShortestRotation;
				if ((lookAndFeel.FillFlags & GizmoRotationArcFillFlags.Area) != GizmoRotationArcFillFlags.None)
				{
					GizmoSolidMaterial get = Singleton<GizmoSolidMaterial>.Get;
					get.ResetValuesToSensibleDefaults();
					get.SetCullModeOff();
					get.SetLit(isLit: false);
					get.SetColor(lookAndFeel.Color);
					get.SetPass(0);
					_arc.RenderArea(camera);
				}
				ArcShape2D.BorderRenderFlags borderRenderFlags = ArcShape2D.BorderRenderFlags.None;
				if ((lookAndFeel.FillFlags & GizmoRotationArcFillFlags.ArcBorder) != GizmoRotationArcFillFlags.None)
				{
					borderRenderFlags |= ArcShape2D.BorderRenderFlags.ArcBorder;
				}
				if ((lookAndFeel.FillFlags & GizmoRotationArcFillFlags.ExtremitiesBorder) != GizmoRotationArcFillFlags.None)
				{
					borderRenderFlags |= ArcShape2D.BorderRenderFlags.ExtremitiesBorder;
				}
				GizmoLineMaterial get2 = Singleton<GizmoLineMaterial>.Get;
				get2.ResetValuesToSensibleDefaults();
				get2.SetColor(lookAndFeel.BorderColor);
				get2.SetPass(0);
				_arc.RenderBorder(camera);
			}
			else
			{
				if (_type != ArcType.PolyProjected || _projectionPoly == null)
				{
					return;
				}
				List<Vector2> arcPoints = PrimitiveFactory.Generate2DArcBorderPoints(_arc.Origin, _arc.StartPoint, _arc.DegreeAngleFromStart, lookAndFeel.UseShortestRotation, NumProjectedPoints);
				arcPoints = PrimitiveFactory.ProjectArcPointsOnPoly2DBorder(_arc.Origin, arcPoints, _projectionPoly.GetPoints());
				if ((lookAndFeel.FillFlags & GizmoRotationArcFillFlags.Area) != GizmoRotationArcFillFlags.None)
				{
					GizmoSolidMaterial get3 = Singleton<GizmoSolidMaterial>.Get;
					get3.ResetValuesToSensibleDefaults();
					get3.SetCullModeOff();
					get3.SetLit(isLit: false);
					get3.SetColor(lookAndFeel.Color);
					get3.SetPass(0);
					GLRenderer.DrawTriangleFan2D(_arc.Origin, arcPoints, camera);
				}
				if (lookAndFeel.FillFlags != GizmoRotationArcFillFlags.None)
				{
					GizmoLineMaterial get4 = Singleton<GizmoLineMaterial>.Get;
					get4.ResetValuesToSensibleDefaults();
					get4.SetColor(lookAndFeel.BorderColor);
					get4.SetPass(0);
					if ((lookAndFeel.FillFlags & GizmoRotationArcFillFlags.ArcBorder) != GizmoRotationArcFillFlags.None)
					{
						GLRenderer.DrawLines2D(arcPoints, camera);
					}
					if ((lookAndFeel.FillFlags & GizmoRotationArcFillFlags.ExtremitiesBorder) != GizmoRotationArcFillFlags.None)
					{
						GLRenderer.DrawLines2D(new List<Vector2>
						{
							_arc.Origin,
							arcPoints[0],
							_arc.Origin,
							arcPoints[arcPoints.Count - 1]
						}, camera);
					}
				}
			}
		}
	}
}
