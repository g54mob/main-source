using UnityEngine;

namespace RLD
{
	public class GizmoTorusCircle3DBorderController : GizmoCircle3DBorderController
	{
		public GizmoTorusCircle3DBorderController(GizmoCircle3DBorderControllerData controllerData)
			: base(controllerData)
		{
		}

		public override void UpdateHandles()
		{
			_data.TargetHandle.Set3DShapeVisible(_data.BorderCircleIndex, isVisible: false);
			_data.TargetHandle.Set3DShapeVisible(_data.BorderCylTorusIndex, isVisible: false);
			_data.TargetHandle.Set3DShapeVisible(_data.BorderTorusIndex, _data.Border.IsVisible);
		}

		public override void UpdateEpsilons(float zoomFactor)
		{
			_data.BorderTorus.TubeRadiusEps = zoomFactor * _data.PlaneSlider.Settings.BorderTorusHoverEps;
		}

		public override void UpdateTransforms(float zoomFactor)
		{
			TorusShape3D borderTorus = _data.BorderTorus;
			CircleShape3D targetCircle = _data.TargetCircle;
			float realTorusThickness = _data.Border.GetRealTorusThickness(zoomFactor);
			borderTorus.Rotation = targetCircle.Rotation * Quaternion.Euler(-90f, 0f, 0f);
			borderTorus.Center = targetCircle.Center;
			borderTorus.CoreRadius = GetTorusCoreRadius(zoomFactor);
			borderTorus.TubeRadius = realTorusThickness * 0.5f;
		}

		public float GetTorusCoreRadius(float zoomFactor)
		{
			float realTorusThickness = _data.Border.GetRealTorusThickness(zoomFactor);
			return _data.TargetCircle.Radius - realTorusThickness * 0.5f;
		}
	}
}
