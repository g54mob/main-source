using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

namespace TH20
{
	public sealed class BlurDitheredRenderer : PostProcessEffectRenderer<BlurDitheredSettings>
	{
		private Material _material;

		private string _sampleName = "BlurDithered";

		public override void Init()
		{
			base.Init();
			_material = new Material(Shader.Find("Hidden/BlurDithered"));
		}

		public override void Release()
		{
			base.Release();
			Object.DestroyImmediate(_material);
		}

		public override void Render(PostProcessRenderContext context)
		{
			context.command.BeginSample(_sampleName);
			context.command.BlitFullscreenTriangle(context.source, context.destination);
			context.command.SetGlobalTexture("_BlurDitheredSourceTex", context.source);
			foreach (Renderer renderer in DitheredRendererManager.Instance.Renderers)
			{
				if (renderer != null && renderer.gameObject.activeInHierarchy && renderer.enabled)
				{
					for (int i = 0; i < renderer.sharedMaterials.Length; i++)
					{
						context.command.DrawRenderer(renderer, _material, i);
					}
				}
			}
			context.command.EndSample(_sampleName);
		}
	}
}
