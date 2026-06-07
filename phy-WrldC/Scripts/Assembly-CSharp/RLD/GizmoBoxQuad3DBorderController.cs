using System.Collections.Generic;
using UnityEngine;

namespace RLD
{
	public class GizmoBoxQuad3DBorderController : GizmoQuad3DBorderController
	{
		public GizmoBoxQuad3DBorderController(GizmoQuad3DBorderControllerData data)
			: base(data)
		{
		}

		public override void UpdateHandles()
		{
			GizmoHandle targetHandle = _data.TargetHandle;
			if (_data.Border.IsVisible)
			{
				targetHandle.Set3DShapeVisible(_data.TopBoxIndex, isVisible: true);
				targetHandle.Set3DShapeVisible(_data.RightBoxIndex, isVisible: true);
				targetHandle.Set3DShapeVisible(_data.BottomBoxIndex, isVisible: true);
				targetHandle.Set3DShapeVisible(_data.LeftBoxIndex, isVisible: true);
				targetHandle.Set3DShapeVisible(_data.TopLeftBoxIndex, isVisible: true);
				targetHandle.Set3DShapeVisible(_data.TopRightBoxIndex, isVisible: true);
				targetHandle.Set3DShapeVisible(_data.BottomRightBoxIndex, isVisible: true);
				targetHandle.Set3DShapeVisible(_data.BottomLeftBoxIndex, isVisible: true);
			}
			else
			{
				targetHandle.Set3DShapeVisible(_data.TopBoxIndex, isVisible: false);
				targetHandle.Set3DShapeVisible(_data.RightBoxIndex, isVisible: false);
				targetHandle.Set3DShapeVisible(_data.BottomBoxIndex, isVisible: false);
				targetHandle.Set3DShapeVisible(_data.LeftBoxIndex, isVisible: false);
				targetHandle.Set3DShapeVisible(_data.TopLeftBoxIndex, isVisible: false);
				targetHandle.Set3DShapeVisible(_data.TopRightBoxIndex, isVisible: false);
				targetHandle.Set3DShapeVisible(_data.BottomRightBoxIndex, isVisible: false);
				targetHandle.Set3DShapeVisible(_data.BottomLeftBoxIndex, isVisible: false);
			}
			targetHandle.Set3DShapeVisible(_data.BorderQuadIndex, isVisible: false);
		}

		public override void UpdateEpsilons(float zoomFactor)
		{
			Vector3 sizeEps = Vector3Ex.FromValue(_data.PlaneSlider.Settings.BorderBoxHoverEps * zoomFactor);
			_data.TopLeftBox.SizeEps = sizeEps;
			_data.TopRightBox.SizeEps = sizeEps;
			_data.BottomRightBox.SizeEps = sizeEps;
			_data.BottomLeftBox.SizeEps = sizeEps;
			_data.TopBox.SizeEps = sizeEps;
			_data.BottomBox.SizeEps = sizeEps;
			_data.LeftBox.SizeEps = sizeEps;
			_data.RightBox.SizeEps = sizeEps;
		}

		public override void UpdateTransforms(float zoomFactor)
		{
			_ = _data.PlaneSlider.LookAndFeel;
			Vector3 right = _data.TargetQuad.Right;
			Vector3 up = _data.TargetQuad.Up;
			Vector3 normal = _data.TargetQuad.Normal;
			float width = _data.TargetQuad.Width;
			float height = _data.TargetQuad.Height;
			List<Vector3> cornerPoints = _data.TargetQuad.GetCornerPoints();
			Vector3 vector = cornerPoints[0];
			Vector3 vector2 = cornerPoints[1];
			Vector3 vector3 = cornerPoints[2];
			Vector3 vector4 = cornerPoints[3];
			float realBoxHeight = _data.Border.GetRealBoxHeight(zoomFactor);
			float realBoxDepth = _data.Border.GetRealBoxDepth(zoomFactor);
			BoxShape3D topLeftBox = _data.TopLeftBox;
			topLeftBox.AlignHeight(normal);
			topLeftBox.AlignWidth(right);
			topLeftBox.Width = realBoxDepth;
			topLeftBox.Height = realBoxHeight;
			topLeftBox.Depth = realBoxDepth;
			topLeftBox.SetFaceCenter(BoxFace.Left, vector - up * topLeftBox.GetSizeAlongDirection(up) * 0.5f);
			BoxShape3D topRightBox = _data.TopRightBox;
			topRightBox.AlignHeight(normal);
			topRightBox.AlignWidth(right);
			topRightBox.Width = realBoxDepth;
			topRightBox.Height = realBoxHeight;
			topRightBox.Depth = realBoxDepth;
			topRightBox.SetFaceCenter(BoxFace.Right, vector2 - up * topRightBox.GetSizeAlongDirection(up) * 0.5f);
			BoxShape3D bottomRightBox = _data.BottomRightBox;
			bottomRightBox.AlignHeight(normal);
			bottomRightBox.AlignWidth(right);
			bottomRightBox.Width = realBoxDepth;
			bottomRightBox.Height = realBoxHeight;
			bottomRightBox.Depth = realBoxDepth;
			bottomRightBox.SetFaceCenter(BoxFace.Right, vector3 + up * bottomRightBox.GetSizeAlongDirection(up) * 0.5f);
			BoxShape3D bottomLeftBox = _data.BottomLeftBox;
			bottomLeftBox.AlignHeight(normal);
			bottomLeftBox.AlignWidth(right);
			bottomLeftBox.Width = realBoxDepth;
			bottomLeftBox.Height = realBoxHeight;
			bottomLeftBox.Depth = realBoxDepth;
			bottomLeftBox.SetFaceCenter(BoxFace.Left, vector4 + up * bottomLeftBox.GetSizeAlongDirection(up) * 0.5f);
			BoxShape3D topBox = _data.TopBox;
			topBox.AlignHeight(normal);
			topBox.AlignWidth(right);
			topBox.Width = width - 2f * topLeftBox.GetSizeAlongDirection(right);
			topBox.Height = realBoxHeight;
			topBox.Depth = realBoxDepth;
			topBox.SetFaceCenter(BoxFace.Left, topLeftBox.GetFaceCenter(BoxFace.Right));
			BoxShape3D rightBox = _data.RightBox;
			rightBox.AlignHeight(normal);
			rightBox.AlignWidth(up);
			rightBox.Width = height - 2f * topRightBox.GetSizeAlongDirection(up);
			rightBox.Height = realBoxHeight;
			rightBox.Depth = realBoxDepth;
			rightBox.SetFaceCenter(BoxFace.Right, topRightBox.GetFaceCenter(BoxFace.Back));
			BoxShape3D bottomBox = _data.BottomBox;
			bottomBox.AlignHeight(normal);
			bottomBox.AlignWidth(right);
			bottomBox.Width = width - 2f * bottomRightBox.GetSizeAlongDirection(right);
			bottomBox.Height = realBoxHeight;
			bottomBox.Depth = realBoxDepth;
			bottomBox.SetFaceCenter(BoxFace.Left, bottomLeftBox.GetFaceCenter(BoxFace.Right));
			BoxShape3D leftBox = _data.LeftBox;
			leftBox.AlignHeight(normal);
			leftBox.AlignWidth(up);
			leftBox.Width = height - 2f * topLeftBox.GetSizeAlongDirection(up);
			leftBox.Height = realBoxHeight;
			leftBox.Depth = realBoxDepth;
			leftBox.SetFaceCenter(BoxFace.Right, topLeftBox.GetFaceCenter(BoxFace.Back));
		}
	}
}
