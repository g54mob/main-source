using UnityEngine;
using UnityEngine.Rendering;

namespace Shapes
{
	public class ImmediateModeShapeDrawer : MonoBehaviour
	{
		[Tooltip("When enabled, shapes will only draw in cameras that can see the layer of this GameObject")]
		public bool useCullingMasks;

		public virtual void DrawShapes(Camera cam)
		{
		}

		private void OnCameraPreRender(Camera cam)
		{
			CameraType cameraType = cam.cameraType;
			if (cameraType != CameraType.Preview && cameraType != CameraType.Reflection && (!useCullingMasks || (cam.cullingMask & (1 << base.gameObject.layer)) != 0))
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
