using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

namespace SCPE
{
	public sealed class DangerRenderer : PostProcessEffectRenderer<Danger>
	{
		private Shader shader;

		public override void Init()
		{
			shader = Shader.Find("Hidden/SC Post Effects/Danger");
		}

		public override void Release()
		{
			base.Release();
		}

		public override void Render(PostProcessRenderContext context)
		{
			PropertySheet propertySheet = context.propertySheets.Get(shader);
			propertySheet.properties.SetVector("_Params", new Vector4(base.settings.intensity, base.settings.size, 0f, 0f));
			propertySheet.properties.SetColor("_Color", base.settings.color);
			Texture value = ((base.settings.overlayTex.value == null) ? RuntimeUtilities.blackTexture : base.settings.overlayTex.value);
			propertySheet.properties.SetTexture("_Overlay", value);
			context.command.BlitFullscreenTriangle(context.source, context.destination, propertySheet, 0);
		}
	}
}
