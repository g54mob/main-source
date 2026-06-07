using UnityEngine;

namespace RLD
{
	public class GizmoCylindricalTorusCircle3DBorderController : GizmoCircle3DBorderController
	{
		public GizmoCylindricalTorusCircle3DBorderController(GizmoCircle3DBorderControllerData controllerData)
			: base(controllerData)
		{
		}

		public override void UpdateHandles()
		{
			_data.TargetHandle.Set3DShapeVisible(_data.BorderCircleIndex, isVisible: false);
			_data.TargetHandle.Set3DShapeVisible(_data.BorderTorusIndex, isVisible: false);
			_data.TargetHandle.Set3DShapeVisible(_data.BorderCylTorusIndex, _data.Border.IsVisible);
		}

		public override void UpdateEpsilons(float zoomFactor)
		{
			_data.BorderCylTorus.CylHrzRadiusEps = zoomFactor * _data.PlaneSlider.Settings.BorderTorusHoverEps;
			_data.BorderCylTorus.CylVertRadiusEps = _data.BorderCylTorus.CylHrzRadiusEps;
		}

		public override void UpdateTransforms(float zoomFactor)
		{
			CylTorusShape3D borderCylTorus = _data.BorderCylTorus;
			CircleShape3D targetCircle = _data.TargetCircle;
			borderCylTorus.Rotation = targetCircle.Rotation * Quaternion.Euler(-90f, 0f, 0f);
			borderCylTorus.Center = targetCircle.Center;
			borderCylTorus.CoreRadius = GetTorusCoreRadius(zoomFactor);
			borderCylTorus.HrzRadius = _data.Border.GetRealCylTorusWidth(zoomFactor) * 0.5f;
			borderCylTorus.VertRadius = _data.Border.GetRealCylTorusHeight(zoomFactor) * 0.5f;
		}

		public float GetTorusCoreRadius(float zoomFactor)
		{
			float realCylTorusWidth = _data.Border.GetRealCylTorusWidth(zoomFactor);
			return _data.TargetCircle.Radius - realCylTorusWidth * 0.5f;
		}
	}
}
