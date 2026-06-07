using UnityEngine;

namespace RLD
{
	public class GizmoCylinderLineSlider3DController : GizmoLineSlider3DController
	{
		public GizmoCylinderLineSlider3DController(GizmoLineSlider3DControllerData controllerData)
			: base(controllerData)
		{
		}

		public override void UpdateHandles()
		{
			_data.SliderHandle.Set3DShapeVisible(_data.SegmentIndex, isVisible: false);
			_data.SliderHandle.Set3DShapeVisible(_data.BoxIndex, isVisible: false);
			_data.SliderHandle.Set3DShapeVisible(_data.CylinderIndex, _data.Slider.IsVisible);
		}

		public override void UpdateTransforms(float zoomFactor)
		{
			GizmoLineSlider3D slider = _data.Slider;
			_data.Cylinder.AlignCentralAxis(slider.GetRealDirection());
			_data.Cylinder.Radius = slider.GetRealCylinderRadius(zoomFactor);
			_data.Cylinder.Height = slider.GetRealLength(zoomFactor);
			_data.Cylinder.BaseCenter = slider.StartPosition;
		}

		public override void UpdateEpsilons(float zoomFactor)
		{
			_data.Cylinder.RadiusEps = _data.Slider.Settings.CylinderHoverEps * zoomFactor;
		}

		public override float GetRealSizeAlongDirection(Vector3 direction, float zoomFactor)
		{
			GizmoLineSlider3D slider = _data.Slider;
			float realLength = slider.GetRealLength(zoomFactor);
			float realCylinderRadius = slider.GetRealCylinderRadius(zoomFactor);
			Vector3 v = _data.Cylinder.Rotation * new Vector3(realCylinderRadius * 2f, realLength, realCylinderRadius * 2f);
			return direction.AbsDot(v);
		}
	}
}
