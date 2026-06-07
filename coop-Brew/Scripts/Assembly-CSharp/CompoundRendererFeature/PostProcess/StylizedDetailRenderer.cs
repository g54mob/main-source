using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using UnityEngine.Rendering.Universal.PostProcessing;

namespace CompoundRendererFeature.PostProcess
{
	[CompoundRendererFeature("Stylized Detail", InjectionPoint.BeforePostProcess, false)]
	public class StylizedDetailRenderer : CompoundRenderer
	{
		private static class PropertyIDs
		{
			internal static readonly int Input;

			internal static readonly int PingTexture;

			internal static readonly int BlurStrength;

			internal static readonly int Blur1;

			internal static readonly int Blur2;

			internal static readonly int Intensity;

			internal static readonly int DownSampleScaleFactor;

			public static readonly int CoCParams;
		}

		private StylizedDetail _volumeComponent;

		private Material _effectMaterial;

		public override ScriptableRenderPassInput input => default(ScriptableRenderPassInput);

		public override void Initialize()
		{
		}

		public override bool Setup(in RenderingData renderingData, InjectionPoint injectionPoint)
		{
			return false;
		}

		public override void Render(CommandBuffer cmd, RTHandle source, RTHandle destination, ref RenderingData renderingData, InjectionPoint injectionPoint)
		{
		}

		public override void Dispose(bool disposing)
		{
		}
	}
}
