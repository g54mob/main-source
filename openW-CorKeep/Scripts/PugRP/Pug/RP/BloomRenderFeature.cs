using UnityEngine;
using UnityEngine.Rendering;

namespace Pug.RP
{
	public class BloomRenderFeature : RenderFeature
	{
		private static GlobalKeyword s_featureKeyword = GlobalKeyword.Create("BLOOM_ENABLED");

		private RenderTextureDescriptor m_desc;

		private RenderTextureDescriptor m_halfSizeDesc;

		private RenderTexture m_halfSize;

		public override bool usesCulling => false;

		public override string sampleName => "Bloom";

		public override RenderPipelineStage executionStage => RenderPipelineStage.BeforePostProcessing;

		public override void ValidateFrame(PugRPContext context)
		{
			base.isValid = context.camera != null && context.pugCamera != null && context.pugCamera.bloom && context.pugCamera.bloomIntensity > Mathf.Epsilon;
		}

		public override void OnBeginValidFrame(PugRPContext context)
		{
			m_desc = new RenderTextureDescriptor(context.pixelWidth, context.pixelHeight, PugRPUtils.floatNoAlphaFormat)
			{
				enableRandomWrite = true
			};
			m_halfSizeDesc = new RenderTextureDescriptor(context.pixelWidth / 2, context.pixelHeight / 2, PugRPUtils.floatNoAlphaFormat)
			{
				enableRandomWrite = true
			};
			PugRPUtils.Setup(ref m_halfSize, "Bloom (half size)", m_halfSizeDesc);
		}

		public override void Execute(PugRPContext context, CommandBuffer cmd)
		{
			cmd.SetKeyword(in s_featureKeyword, value: true);
			PugRPUtils.WideBlur(cmd, context.internalTarget, m_halfSize, m_desc, context.pugCamera.bloomWidth, 1f, context.pugCamera.bloomThreshold, context.pugCamera.bloomBlend);
			cmd.SetGlobalTexture(ShaderIDs.BloomTexture, m_halfSize);
			cmd.SetGlobalFloat(ShaderIDs.BloomIntensity, context.pugCamera.bloomIntensity);
		}

		public override void ExecuteDisabled(PugRPContext context, CommandBuffer cmd)
		{
			cmd.SetKeyword(in s_featureKeyword, value: false);
			cmd.SetGlobalTexture(ShaderIDs.BloomTexture, Texture2D.blackTexture);
		}

		protected override void DisposeInternal()
		{
			PugRPUtils.Release(ref m_halfSize);
		}
	}
}
