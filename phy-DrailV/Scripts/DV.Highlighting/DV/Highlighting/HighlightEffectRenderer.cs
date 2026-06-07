using System;
using UnityEngine.Rendering.PostProcessing;

namespace DV.Highlighting
{
	public sealed class HighlightEffectRenderer : PostProcessEffectRenderer<HighlightEffect>
	{
		public static event Action<PostProcessRenderContext> RenderEffects;

		public override bool HasRendering()
		{
			return false;
		}

		public override void Render(PostProcessRenderContext context)
		{
			HighlightEffectRenderer.RenderEffects?.Invoke(context);
		}
	}
}
