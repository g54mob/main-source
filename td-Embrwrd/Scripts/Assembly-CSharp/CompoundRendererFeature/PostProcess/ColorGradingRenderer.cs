using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using UnityEngine.Rendering.Universal.PostProcessing;

namespace CompoundRendererFeature.PostProcess
{
	[CompoundRendererFeature("Stylized Color Grading", InjectionPoint.BeforePostProcess, false)]
	public class ColorGradingRenderer : CompoundRenderer
	{
		private static class PropertyIDs
		{
			internal static readonly int Input;

			internal static readonly int Intensity;

			internal static readonly int ShadowBezierPoints;

			internal static readonly int HighlightBezierPoints;

			internal static readonly int Contrast;

			internal static readonly int Vibrance;

			internal static readonly int Saturation;
		}

		private ColorGrading _volumeComponent;

		private Material _effectMaterial;

		public override bool visibleInSceneView => false;

		public override ScriptableRenderPassInput input => default(ScriptableRenderPassInput);

		public override void Initialize()
		{
		}

		public override bool Setup(in RenderingData renderingData, InjectionPoint injectionPoint)
		{
			return false;
		}

		public override void Render(CommandBuffer cmd, RenderTargetIdentifier source, RenderTargetIdentifier destination, ref RenderingData renderingData, InjectionPoint injectionPoint)
		{
		}

		public override void Dispose(bool disposing)
		{
		}
	}
}
