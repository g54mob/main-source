namespace RLD
{
	public class GizmoThinRATriangle3DBorderController : GizmoRATriangle3DBorderController
	{
		public GizmoThinRATriangle3DBorderController(GizmoRATriangle3DBorderControllerData controllerData)
			: base(controllerData)
		{
		}

		public override void UpdateHandles()
		{
			_data.TargetHandle.Set3DShapeVisible(_data.BorderTriangleIndex, _data.Border.IsVisible);
		}

		public override void UpdateEpsilons(float zoomFactor)
		{
			_data.BorderTriangle.WireEps = zoomFactor * _data.PlaneSlider.Settings.BorderLineHoverEps;
			_data.BorderTriangle.ExtrudeEps = _data.BorderTriangle.WireEps;
		}

		public override void UpdateTransforms(float zoomFactor)
		{
			RightAngTriangle3D targetTriangle = _data.TargetTriangle;
			RightAngTriangle3D borderTriangle = _data.BorderTriangle;
			borderTriangle.Rotation = targetTriangle.Rotation;
			borderTriangle.RightAngleCorner = targetTriangle.RightAngleCorner;
			borderTriangle.XLength = targetTriangle.XLength;
			borderTriangle.XLengthSign = targetTriangle.XLengthSign;
			borderTriangle.YLength = targetTriangle.YLength;
			borderTriangle.YLengthSign = targetTriangle.YLengthSign;
		}
	}
}
