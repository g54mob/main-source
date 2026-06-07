using System;
using UnityEngine;
using UnityEngine.Rendering;

namespace Mystery.Graphing
{
	public abstract class SRPGraphRenderer : IGraphConsoleRenderer
	{
		protected void OnEnable()
		{
			if (GraphicsSettings.defaultRenderPipeline != null)
			{
				RenderPipelineManager.endCameraRendering += endCameraRendering;
			}
			else
			{
				Camera.onPostRender = (Camera.CameraCallback)Delegate.Combine(Camera.onPostRender, new Camera.CameraCallback(OnCameraRender));
			}
			if (Material == null)
			{
				Material = BuiltInGraphShader.GetLineMaterial();
			}
		}

		protected void OnDisable()
		{
			if (GraphicsSettings.defaultRenderPipeline != null)
			{
				RenderPipelineManager.endCameraRendering -= endCameraRendering;
			}
			else
			{
				Camera.onPostRender = (Camera.CameraCallback)Delegate.Remove(Camera.onPostRender, new Camera.CameraCallback(OnCameraRender));
			}
		}

		private void endCameraRendering(ScriptableRenderContext src, Camera camera)
		{
			if (CheckFilter(camera))
			{
				Render(camera);
			}
		}

		protected void OnCameraRender(Camera camera)
		{
			if (CheckFilter(camera))
			{
				Render(camera);
			}
		}

		private bool CheckFilter(Camera camera)
		{
			return (camera.cullingMask & (1 << base.gameObject.layer)) != 0;
		}
	}
}
