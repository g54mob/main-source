using UnityEngine;

namespace RLD
{
	public class GizmoRotationArc3D
	{
		private ArcShape3D _arc = new ArcShape3D();

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

		public float Radius
		{
			get
			{
				return _arc.Radius;
			}
			set
			{
				_arc.Radius = value;
			}
		}

		public void SetArcData(Vector3 rotationAxis, Vector3 arcOrigin, Vector3 arcStart, float radius)
		{
			Plane plane = new Plane(rotationAxis, arcOrigin);
			_arc.SetArcData(plane, arcOrigin, arcStart, radius);
		}

		public void Render(GizmoRotationArc3DLookAndFeel lookAndFeel)
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
				_arc.RenderSolid();
			}
			ArcShape3D.WireRenderFlags wireRenderFlags = ArcShape3D.WireRenderFlags.None;
			if ((lookAndFeel.FillFlags & GizmoRotationArcFillFlags.ArcBorder) != GizmoRotationArcFillFlags.None)
			{
				wireRenderFlags |= ArcShape3D.WireRenderFlags.ArcBorder;
			}
			if ((lookAndFeel.FillFlags & GizmoRotationArcFillFlags.ExtremitiesBorder) != GizmoRotationArcFillFlags.None)
			{
				wireRenderFlags |= ArcShape3D.WireRenderFlags.ExtremitiesBorder;
			}
			GizmoLineMaterial get2 = Singleton<GizmoLineMaterial>.Get;
			get2.ResetValuesToSensibleDefaults();
			get2.SetColor(lookAndFeel.BorderColor);
			get2.SetPass(0);
			_arc.RenderWire();
		}
	}
}
