using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

namespace StylizedWater2
{
	public class SetupConstants : ScriptableRenderPass
	{
		private static readonly int _EnableDirectionalCaustics;

		private static readonly int CausticsProjection;

		private static readonly int _WaterSSREnabled;

		private static readonly int _WaterDisplacementPrePassAvailable;

		private bool m_directionalCaustics;

		private static VisibleLight mainLight;

		private Matrix4x4 causticsProjection;

		private StylizedWaterRenderFeature settings;

		private ScriptableRenderPassInput requirements;

		public void Setup(StylizedWaterRenderFeature renderFeature)
		{
		}

		public override void Configure(CommandBuffer cmd, RenderTextureDescriptor cameraTextureDescriptor)
		{
		}

		public override void Execute(ScriptableRenderContext context, ref RenderingData renderingData)
		{
		}

		public override void OnCameraCleanup(CommandBuffer cmd)
		{
		}

		public void Dispose()
		{
		}
	}
}
