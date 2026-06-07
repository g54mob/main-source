using UnityEngine;

namespace RLD
{
	public class GizmoQuadPlaneSlider2DController : GizmoPlaneSlider2DController
	{
		public GizmoQuadPlaneSlider2DController(GizmoPlaneSlider2DControllerData controllerData)
			: base(controllerData)
		{
		}

		public override void UpdateHandles()
		{
			_data.CircleBorder.SetVisible(isVisible: false);
			_data.SliderHandle.Set2DShapeVisible(_data.CircleIndex, isVisible: false);
			_data.PolygonBorder.SetVisible(isVisible: false);
			_data.SliderHandle.Set2DShapeVisible(_data.PolygonIndex, isVisible: false);
			_data.QuadBorder.SetVisible(_data.Slider.IsBorderVisible);
			_data.SliderHandle.Set2DShapeVisible(_data.QuadIndex, _data.Slider.IsVisible);
		}

		public override void UpdateEpsilons()
		{
			_data.Quad.SizeEps = Vector2Ex.FromValue(_data.Slider.Settings.AreaHoverEps);
		}

		public override void UpdateTransforms()
		{
			QuadShape2D quad = _data.Quad;
			GizmoPlaneSlider2D slider = _data.Slider;
			quad.Center = slider.Position;
			quad.RotationDegrees = slider.RotationDegrees;
			quad.Size = slider.GetRealQuadSize();
			_data.QuadBorder.OnQuadShapeChanged();
		}

		public override Vector2 GetRealExtentPoint(Shape2DExtentPoint extentPt)
		{
			return _data.Quad.GetExtentPoint(extentPt);
		}
	}
}
