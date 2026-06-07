using UnityEngine;

namespace RLD
{
	public class GizmoBoxLineSlider2DController : GizmoLineSlider2DController
	{
		public GizmoBoxLineSlider2DController(GizmoLineSlider2DControllerData controllerData)
			: base(controllerData)
		{
		}

		public override void UpdateHandles()
		{
			_data.SliderHandle.Set2DShapeVisible(_data.SegmentIndex, isVisible: false);
			_data.SliderHandle.Set2DShapeVisible(_data.QuadIndex, _data.Slider.IsVisible);
		}

		public override void UpdateEpsilons()
		{
			_data.Quad.SizeEps = Vector2Ex.FromValue(_data.Slider.Settings.BoxHoverEps);
		}

		public override void UpdateTransforms()
		{
			QuadShape2D quad = _data.Quad;
			GizmoLineSlider2D slider = _data.Slider;
			float realLength = slider.GetRealLength();
			Vector2 realDirection = slider.GetRealDirection();
			quad.Width = realLength;
			quad.Height = slider.GetRealBoxThickness();
			quad.AlignWidth(realDirection);
			quad.Center = slider.StartPosition + realDirection * 0.5f * realLength;
		}
	}
}
