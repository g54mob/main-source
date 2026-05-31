using System;
using UnityEngine;
using UnityEngine.Rendering.Universal;

namespace CTS
{
	[Serializable]
	public class OutlineRenderFeature : ScriptableRendererFeature
	{
		private OutlineJFAInitPass _jfaInitPass;

		[SerializeField]
		private RenderPassEvent _renderPassEvent = RenderPassEvent.BeforeRenderingPostProcessing;

		public override void Create()
		{
			_jfaInitPass = new OutlineJFAInitPass
			{
				renderPassEvent = _renderPassEvent
			};
		}

		public override void AddRenderPasses(ScriptableRenderer renderer, ref RenderingData renderingData)
		{
			renderer.EnqueuePass(_jfaInitPass);
		}
	}
}
