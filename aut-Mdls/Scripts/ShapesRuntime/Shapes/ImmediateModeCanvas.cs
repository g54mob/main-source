using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

namespace Shapes
{
	[ExecuteAlways]
	[RequireComponent(typeof(Canvas))]
	public class ImmediateModeCanvas : ImmediateModeShapeDrawer
	{
		private Canvas canvas;

		private RectTransform canvasRectTf;

		private Camera camUI;

		private List<ImmediateModePanel> panels = new List<ImmediateModePanel>();

		private const double DEG_TO_RAD = Math.PI / 180.0;

		private Canvas Canvas => canvas = ((canvas != null) ? canvas : GetComponent<Canvas>());

		private RectTransform CanvasRectTf => canvasRectTf = ((canvasRectTf != null) ? canvasRectTf : GetComponent<RectTransform>());

		private Camera CamUI => camUI = ((camUI != null) ? camUI : Canvas.worldCamera);

		public bool IsCameraBasedUI
		{
			get
			{
				if (Canvas.worldCamera != null)
				{
					if (Canvas.renderMode != RenderMode.ScreenSpaceCamera)
					{
						return Canvas.renderMode == RenderMode.WorldSpace;
					}
					return true;
				}
				return false;
			}
		}

		public void Add(ImmediateModePanel panel)
		{
			panels.Add(panel);
		}

		public void Remove(ImmediateModePanel panel)
		{
			panels.Remove(panel);
		}

		protected void DrawPanels()
		{
			foreach (ImmediateModePanel panel in panels)
			{
				panel.DrawPanel();
			}
		}

		public override void DrawShapes(Camera cam)
		{
			if (!Canvas.enabled)
			{
				return;
			}
			using (Draw.Command(cam))
			{
				Draw.ZTest = CompareFunction.Always;
				Draw.Matrix = GetCanvasToWorldMatrix(cam);
				DrawCanvasShapes(CanvasRectTf.rect);
			}
		}

		private bool CanUseSimpleCameraMatrix(Camera cam)
		{
			if (cam.cameraType != CameraType.SceneView)
			{
				if (IsCameraBasedUI)
				{
					return cam == Canvas.worldCamera;
				}
				return false;
			}
			return true;
		}

		private Matrix4x4 GetCanvasToWorldMatrix(Camera cam)
		{
			if (CanUseSimpleCameraMatrix(cam))
			{
				return Canvas.transform.localToWorldMatrix;
			}
			float num = (cam.nearClipPlane + cam.farClipPlane) / 2f;
			RectTransform rectTransform = (RectTransform)Canvas.transform;
			Transform obj = cam.transform;
			Vector3 forward = obj.forward;
			Vector3 vector = obj.TransformPoint(0f, 0f, num);
			float num2 = 1f;
			if (cam.orthographic)
			{
				num2 = 2f * cam.orthographicSize / rectTransform.sizeDelta.y;
			}
			else
			{
				double a = (double)cam.fieldOfView * (Math.PI / 180.0) / 2.0;
				double num3 = (float)((double)num * Math.Tan(a));
				num2 = (float)(2.0 * num3 / (double)rectTransform.sizeDelta.y);
			}
			Vector3 vector2 = obj.right * num2;
			Vector3 vector3 = obj.up * num2;
			Vector3 vector4 = forward * num2;
			return new Matrix4x4(vector2, vector3, vector4, new Vector4(vector.x, vector.y, vector.z, 1f));
		}

		public virtual void DrawCanvasShapes(Rect rect)
		{
		}
	}
}
