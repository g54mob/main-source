using UnityEngine;

namespace RLD
{
	public class GizmoRATrianglePlaneSlider3DController : GizmoPlaneSlider3DController
	{
		public GizmoRATrianglePlaneSlider3DController(GizmoPlaneSlider3DControllerData controllerData)
			: base(controllerData)
		{
		}

		public override void UpdateHandles()
		{
			_data.QuadBorder.SetVisible(isVisible: false);
			_data.SliderHandle.Set3DShapeVisible(_data.QuadIndex, isVisible: false);
			_data.CircleBorder.SetVisible(isVisible: false);
			_data.SliderHandle.Set3DShapeVisible(_data.CircleIndex, isVisible: false);
			_data.RATriangleBorder.SetVisible(_data.Slider.IsBorderVisible);
			_data.SliderHandle.Set3DShapeVisible(_data.RATriangleIndex, _data.Slider.IsVisible);
		}

		public override void UpdateEpsilons(float zoomFactor)
		{
			_data.RATriangle.AreaEps = _data.Slider.Settings.AreaHoverEps * zoomFactor;
			_data.RATriangle.ExtrudeEps = _data.Slider.Settings.ExtrudeHoverEps * zoomFactor;
		}

		public override void UpdateTransforms(float zoomFactor)
		{
			RightAngTriangle3D rATriangle = _data.RATriangle;
			GizmoPlaneSlider3D slider = _data.Slider;
			Vector2 realRATriSize = slider.GetRealRATriSize(zoomFactor);
			rATriangle.RightAngleCorner = slider.Position;
			rATriangle.Rotation = slider.Rotation;
			rATriangle.XLength = realRATriSize.x;
			rATriangle.YLength = realRATriSize.y;
			rATriangle.XLengthSign = ((!(realRATriSize.x >= 0f)) ? AxisSign.Negative : AxisSign.Positive);
			rATriangle.YLengthSign = ((!(realRATriSize.y >= 0f)) ? AxisSign.Negative : AxisSign.Positive);
			_data.RATriangleBorder.OnTriangleShapeChanged();
		}
	}
}
