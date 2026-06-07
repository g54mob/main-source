using UnityEngine;

namespace RLD
{
	public class GizmoPolygonPlaneSlider2DController : GizmoPlaneSlider2DController
	{
		public GizmoPolygonPlaneSlider2DController(GizmoPlaneSlider2DControllerData controllerData)
			: base(controllerData)
		{
		}

		public override void UpdateHandles()
		{
			_data.CircleBorder.SetVisible(isVisible: false);
			_data.SliderHandle.Set2DShapeVisible(_data.CircleIndex, isVisible: false);
			_data.QuadBorder.SetVisible(isVisible: false);
			_data.SliderHandle.Set2DShapeVisible(_data.QuadIndex, isVisible: false);
			_data.PolygonBorder.SetVisible(_data.Slider.IsBorderVisible);
			_data.SliderHandle.Set2DShapeVisible(_data.PolygonIndex, _data.Slider.IsVisible);
		}

		public override void UpdateEpsilons()
		{
			_data.Polygon.AreaEps = _data.Slider.Settings.AreaHoverEps;
		}

		public override void UpdateTransforms()
		{
			_data.PolygonBorder.OnPolygonShapeChanged();
		}

		public override Vector2 GetRealExtentPoint(Shape2DExtentPoint extentPt)
		{
			return _data.Polygon.GetExtentPoint(extentPt);
		}
	}
}
