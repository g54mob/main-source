namespace RLD
{
	public class GizmoThinQuad3DBorderController : GizmoQuad3DBorderController
	{
		public GizmoThinQuad3DBorderController(GizmoQuad3DBorderControllerData data)
			: base(data)
		{
		}

		public override void UpdateHandles()
		{
			GizmoHandle targetHandle = _data.TargetHandle;
			targetHandle.Set3DShapeVisible(_data.BorderQuadIndex, _data.Border.IsVisible);
			targetHandle.Set3DShapeVisible(_data.TopBoxIndex, isVisible: false);
			targetHandle.Set3DShapeVisible(_data.RightBoxIndex, isVisible: false);
			targetHandle.Set3DShapeVisible(_data.BottomBoxIndex, isVisible: false);
			targetHandle.Set3DShapeVisible(_data.LeftBoxIndex, isVisible: false);
			targetHandle.Set3DShapeVisible(_data.TopLeftBoxIndex, isVisible: false);
			targetHandle.Set3DShapeVisible(_data.TopRightBoxIndex, isVisible: false);
			targetHandle.Set3DShapeVisible(_data.BottomRightBoxIndex, isVisible: false);
			targetHandle.Set3DShapeVisible(_data.BottomLeftBoxIndex, isVisible: false);
		}

		public override void UpdateEpsilons(float zoomFactor)
		{
			QuadShape3D borderQuad = _data.BorderQuad;
			borderQuad.WireEps = _data.PlaneSlider.Settings.BorderLineHoverEps * zoomFactor;
			borderQuad.ExtrudeEps = borderQuad.WireEps;
		}

		public override void UpdateTransforms(float zoomFactor)
		{
			QuadShape3D targetQuad = _data.TargetQuad;
			QuadShape3D borderQuad = _data.BorderQuad;
			borderQuad.Center = targetQuad.Center;
			borderQuad.Rotation = targetQuad.Rotation;
			borderQuad.Size = targetQuad.Size;
		}
	}
}
