using System;
using UnityEngine;
using UnityEngine.Rendering.Universal;

namespace URPGlitch
{
	[Serializable]
	public sealed class DigitalGlitchFeature : ScriptableRendererFeature
	{
		[SerializeField]
		private Shader shader;

		[SerializeField]
		private Shader compatShader;

		[SerializeField]
		private RenderPassEvent renderPassEvent;

		private DigitalGlitchRenderPass _scriptablePass;

		public override void Create()
		{
			_scriptablePass = new DigitalGlitchRenderPass(shader, compatShader);
			_scriptablePass.renderPassEvent = renderPassEvent;
		}

		public override void AddRenderPasses(ScriptableRenderer renderer, ref RenderingData renderingData)
		{
			if (shader == null || compatShader == null)
			{
				Debug.LogWarning(base.name + " shader is null and will be skipped.");
			}
			else if (renderingData.cameraData.cameraType == CameraType.Game)
			{
				renderer.EnqueuePass(_scriptablePass);
			}
		}

		protected override void Dispose(bool disposing)
		{
			_scriptablePass.Dispose();
		}
	}
}
