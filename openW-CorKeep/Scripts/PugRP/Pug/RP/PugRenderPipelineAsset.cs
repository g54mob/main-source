using System;
using UnityEngine;
using UnityEngine.Rendering;

namespace Pug.RP
{
	[CreateAssetMenu(menuName = "Rendering/PugRP")]
	public class PugRenderPipelineAsset : RenderPipelineAsset<PugRP>
	{
		[Serializable]
		public class TextureShaderProperty
		{
			public string name;

			public Texture texture;

			public void Upload(CommandBuffer cmd)
			{
				cmd.SetGlobalTexture(name, texture);
			}
		}

		[Serializable]
		public class ObjectShadowChannel
		{
			public string name;

			public float depth;

			public float thickness = 0.1f;

			public float startFade = 0.01f;

			public float endFade = 0.01f;

			[Range(0f, 1f)]
			public float strength = 1f;

			public bool affectSprites;

			public void GetShaderUniforms(float depthScale, out Vector4 paramsA, out Vector4 paramsB)
			{
				float num = thickness * 0.5f;
				float num2 = depth + depthScale * 0.5f;
				paramsA = new Vector4(num2 - num - startFade, num2 - num, num2 + num, num2 + num + endFade) / depthScale;
				paramsB = new Vector4(strength, (!affectSprites) ? 1 : 0, 0f, 0f);
			}
		}

		public bool enableSRPBatching = true;

		public bool logRTCreation;

		public bool logUtilityCameraCreation;

		public bool showLightDebugInfo;

		public bool snappingAccountsForOrigin;

		public bool sharedCullPass;

		public bool alignSharedCullCamera;

		[Space(10f)]
		public float pixelsPerMeter = 16f;

		public ShadowResolution shadowResolution = ShadowResolution._128;

		public ShadowFilterQuality shadowFilterQuality = ShadowFilterQuality.Medium;

		[Min(1f)]
		public int maxShadowUpdatesPerFrame = 4;

		[SerializeField]
		private string[] m_RenderingLayerNames = new string[32]
		{
			"Layer1", "Layer2", "Layer3", "Layer4", "Layer5", "Layer6", "Layer7", "Layer8", "Layer9", "Layer10",
			"Layer11", "Layer12", "Layer13", "Layer14", "Layer15", "Layer16", "Layer17", "Layer18", "Layer19", "Layer20",
			"Layer21", "Layer22", "Layer23", "Layer24", "Layer25", "Layer26", "Layer27", "Layer28", "Layer29", "Layer30",
			"Layer31", "Layer32"
		};

		public LayerMask shadowCastingLayers = 1;

		[Layer]
		public int indirectOnlyLayer;

		public AnimationCurve lightFalloffCurve = AnimationCurve.Linear(0f, 1f, 1f, 0f);

		[Range(0f, 1f)]
		public float lightFalloffDither = 0.1f;

		[Space(10f)]
		public bool highPerformanceLightMode;

		[Range(0f, 1f)]
		public float fallbackLightNormalFactor = 0.5f;

		[Space(10f)]
		public ShadowsType punctualShadowsType;

		[Header("Raymarched Shadows")]
		[Range(0f, 1f)]
		public float raymarchedShadowQuality = 1f;

		[Range(8f, 256f)]
		public int raymarchedShadowMaxSampleCount = 1;

		[Min(0f)]
		public float raymarchedShadowBias = 1f;

		[Range(0f, 1f)]
		public float raymarchedShadowDither = 1f;

		[Range(0f, 1f)]
		public float raymarchedShadowSharpness = 0.25f;

		[Header("Point Shadows")]
		public bool singlePassPointShadows = true;

		[Min(0f)]
		public float pointShadowBias = 1f;

		[Range(1f, 16f)]
		public int pointShadowSamples = 8;

		[Range(0f, 1f)]
		public float pointShadowSoftness = 0.7f;

		[Header("Spot Shadows")]
		[Min(0f)]
		public float spotShadowBias = 1f;

		[Header("Directional Shadows")]
		[Min(0f)]
		public float directionalShadowBias = 1f;

		[Header("Object Shadows")]
		public ObjectShadowChannel objectShadowChannel0;

		public ObjectShadowChannel objectShadowChannel1;

		public ObjectShadowChannel objectShadowChannel2;

		public ObjectShadowChannel objectShadowChannel3;

		[Header("Light Settings")]
		[Space(10f)]
		[Min(0f)]
		public float lightPixelPenetration;

		[Min(0f)]
		public float lightOffsetPenetration;

		public float lightOffsetDepth;

		public bool celShade;

		[Range(0f, 1f)]
		public float celShadeThreshold = 0.5f;

		[Range(0f, 1f)]
		public float celShadeTransition = 0.1f;

		[Space(10f)]
		public bool enablePhysicalLightAttenuation;

		public bool enableSpriteLightRims;

		[Space(10f)]
		public Texture2D ditherTexture;

		public Texture2D[] noiseTextures;

		public TextureShaderProperty[] globalTextures;

		private Texture2D m_curveTexture;

		public override string renderPipelineShaderTag => "UniversalPipeline";

		public Texture2D curveTexture => m_curveTexture;

		[Obsolete]
		public override string[] renderingLayerMaskNames => m_RenderingLayerNames;

		[Obsolete]
		public override string[] prefixedRenderingLayerMaskNames => m_RenderingLayerNames;

		public bool usesCachedPunctualShadows
		{
			get
			{
				if (punctualShadowsType != ShadowsType.Shadowmap)
				{
					return punctualShadowsType == ShadowsType.Raymap;
				}
				return true;
			}
		}

		public virtual void SetGlobalShaderParameters(CommandBuffer cmd)
		{
			cmd.SetGlobalFloat(ShaderIDs.FallbackLightNormalFactor, fallbackLightNormalFactor);
			cmd.SetGlobalVector(ShaderIDs.CelShadeParams, new Vector4(celShade ? 1 : 0, celShadeThreshold - celShadeTransition * 0.5f, celShadeThreshold + celShadeTransition * 0.5f, 0f));
			if (globalTextures != null)
			{
				for (int i = 0; i < globalTextures.Length; i++)
				{
					globalTextures[i].Upload(cmd);
				}
			}
		}

		public void SetCameraShaderParameters(CommandBuffer cmd, PugCamera pugCamera)
		{
			if (!(pugCamera == null))
			{
				float indirectLightDepth = pugCamera.indirectLightDepth;
				objectShadowChannel0.GetShaderUniforms(indirectLightDepth, out var paramsA, out var paramsB);
				objectShadowChannel1.GetShaderUniforms(indirectLightDepth, out var paramsA2, out var paramsB2);
				objectShadowChannel2.GetShaderUniforms(indirectLightDepth, out var paramsA3, out var paramsB3);
				objectShadowChannel3.GetShaderUniforms(indirectLightDepth, out var paramsA4, out var paramsB4);
				cmd.SetGlobalVector(ShaderIDs.ObjectShadowParam1, new Vector4(paramsA.x, paramsA2.x, paramsA3.x, paramsA4.x));
				cmd.SetGlobalVector(ShaderIDs.ObjectShadowParam2, new Vector4(paramsA.y, paramsA2.y, paramsA3.y, paramsA4.y));
				cmd.SetGlobalVector(ShaderIDs.ObjectShadowParam3, new Vector4(paramsA.z, paramsA2.z, paramsA3.z, paramsA4.z));
				cmd.SetGlobalVector(ShaderIDs.ObjectShadowParam4, new Vector4(paramsA.w, paramsA2.w, paramsA3.w, paramsA4.w));
				cmd.SetGlobalVector(ShaderIDs.ObjectShadowParam5, new Vector4(paramsB.x, paramsB2.x, paramsB3.x, paramsB4.x));
				cmd.SetGlobalVector(ShaderIDs.ObjectShadowParam6, new Vector4(paramsB.y, paramsB2.y, paramsB3.y, paramsB4.y));
			}
		}

		private void UpdateCurveTexture()
		{
			PugRPUtils.InitializeCurveTexture(ref m_curveTexture, 256, lightFalloffCurve);
		}

		protected override RenderPipeline CreatePipeline()
		{
			UpdateCurveTexture();
			return new PugRP();
		}

		protected override void OnValidate()
		{
			base.OnValidate();
			UpdateCurveTexture();
		}
	}
}
