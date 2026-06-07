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
		private static ImCanvasContext canvasContext = new ImCanvasContext();

		private Canvas canvas;

		private RectTransform canvasRectTf;

		private Camera camUI;

		private List<ImmediateModePanel> panels = new List<ImmediateModePanel>();

		private Canvas Canvas => canvas = ((canvas != null) ? canvas : GetComponent<Canvas>());

		private RectTransform CanvasRectTf => canvasRectTf = ((canvasRectTf != null) ? canvasRectTf : GetComponent<RectTransform>());

		private Camera CamUI => camUI = ((camUI != null) ? camUI : Canvas.worldCamera);

		private bool IsCameraBasedUI
		{
			get
			{
				if (Canvas.worldCamera != null)
				{
					return Canvas.renderMode == RenderMode.WorldSpace;
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
			using (Draw.Scope)
			{
				if (Canvas.renderMode == RenderMode.ScreenSpaceOverlay)
				{
					Draw.Matrix *= canvasContext.worldToCanvas;
				}
				foreach (ImmediateModePanel panel in panels)
				{
					using (Draw.Scope)
					{
						if (Canvas.renderMode == RenderMode.ScreenSpaceOverlay)
						{
							Draw.Matrix = ShapesMath.AffineMtxMul(Draw.Matrix, panel.transform.localToWorldMatrix);
						}
						else
						{
							Draw.Matrix = panel.transform.localToWorldMatrix;
						}
						panel.DrawPanel(canvasContext);
					}
				}
			}
		}

		private bool CameraShouldRenderUI(Camera cam)
		{
			if (cam.cameraType == CameraType.Game)
			{
				if (canvas.renderMode == RenderMode.ScreenSpaceOverlay)
				{
					return cam.targetDisplay == canvas.targetDisplay;
				}
				return cam == CamUI;
			}
			return false;
		}

		public override void DrawShapes(Camera cam)
		{
			if (!Canvas.enabled || !CameraShouldRenderUI(cam))
			{
				return;
			}
			using (Draw.Command(cam))
			{
				Draw.ZTest = CompareFunction.Always;
				RectTransform rectTransform = CanvasRectTf;
				canvasContext.UpdateParams(Canvas, cam, rectTransform, DisplayAsWorldSpacePanel(cam) ? rectTransform.localToWorldMatrix : GetOverlayToWorldMatrix(cam));
				Draw.Matrix = canvasContext.canvasToWorldNet;
				DrawCanvasShapes(canvasContext);
			}
		}

		private bool DisplayAsWorldSpacePanel(Camera cam)
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

		private Matrix4x4 GetOverlayToWorldMatrix(Camera cam)
		{
			float num = (cam.nearClipPlane + cam.farClipPlane) / 2f;
			Transform obj = cam.transform;
			Vector3 forward = obj.forward;
			Vector3 vector = obj.TransformPoint(0f, 0f, num);
			float num2 = 1f;
			RectTransform rectTransform = (RectTransform)Canvas.transform;
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

		public virtual void DrawCanvasShapes(ImCanvasContext ctx)
		{
		}
	}
}
