using UnityEngine;
using UnityEngine.Rendering;

namespace Shapes
{
	public class ImmediateModeShapeDrawer : MonoBehaviour
	{
		public virtual void DrawShapes(Camera cam)
		{
		}

		private void OnCameraPreRender(Camera cam)
		{
			CameraType cameraType = cam.cameraType;
			if (cameraType != CameraType.Preview && cameraType != CameraType.Reflection)
			{
				DrawShapes(cam);
			}
		}

		public virtual void OnEnable()
		{
			RenderPipelineManager.beginCameraRendering += DrawShapesSRP;
		}

		public virtual void OnDisable()
		{
			RenderPipelineManager.beginCameraRendering -= DrawShapesSRP;
		}

		private void DrawShapesSRP(ScriptableRenderContext ctx, Camera cam)
		{
			OnCameraPreRender(cam);
		}
	}
}
