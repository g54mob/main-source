using UnityEngine;

namespace RLD
{
	public class GizmoBoxLineSlider3DController : GizmoLineSlider3DController
	{
		public GizmoBoxLineSlider3DController(GizmoLineSlider3DControllerData controllerData)
			: base(controllerData)
		{
		}

		public override void UpdateHandles()
		{
			_data.SliderHandle.Set3DShapeVisible(_data.CylinderIndex, isVisible: false);
			_data.SliderHandle.Set3DShapeVisible(_data.SegmentIndex, isVisible: false);
			_data.SliderHandle.Set3DShapeVisible(_data.BoxIndex, _data.Slider.IsVisible);
		}

		public override void UpdateTransforms(float zoomFactor)
		{
			GizmoLineSlider3D slider = _data.Slider;
			_data.Box.AlignWidth(slider.GetRealDirection());
			_data.Box.Size = new Vector3(slider.GetRealLength(zoomFactor), slider.GetRealBoxHeight(zoomFactor), slider.GetRealBoxDepth(zoomFactor));
			_data.Box.SetFaceCenter(BoxFace.Left, slider.StartPosition);
		}

		public override void UpdateEpsilons(float zoomFactor)
		{
			float num = _data.Slider.Settings.BoxHoverEps * zoomFactor;
			_data.Box.SizeEps = new Vector3(0f, num, num);
		}

		public override float GetRealSizeAlongDirection(Vector3 direction, float zoomFactor)
		{
			direction.Normalize();
			GizmoLineSlider3D slider = _data.Slider;
			float realLength = slider.GetRealLength(zoomFactor);
			float realBoxHeight = slider.GetRealBoxHeight(zoomFactor);
			float realBoxDepth = slider.GetRealBoxDepth(zoomFactor);
			Vector3 v = _data.Box.Rotation * new Vector3(realLength, realBoxHeight, realBoxDepth);
			return direction.AbsDot(v);
		}
	}
}
