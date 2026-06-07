using GLTFast.Schema;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

namespace GLTFast.Materials
{
	public class UniversalRPMaterialGenerator : ShaderGraphMaterialGenerator
	{
		private const string k_TransmissionKeyword = "_TRANSMISSION";

		private static bool s_SupportsCameraOpaqueTexture;

		public const string MetallicClearcoatShader = "glTF-pbrMetallicRoughness-Clearcoat";

		private static bool s_MetallicClearcoatShaderQueried;

		private static Shader s_MetallicClearcoatShader;

		public UniversalRPMaterialGenerator(UniversalRenderPipelineAsset renderPipelineAsset)
		{
			s_SupportsCameraOpaqueTexture = renderPipelineAsset.supportsCameraOpaqueTexture;
		}

		protected override void SetDoubleSided(MaterialBase gltfMaterial, UnityEngine.Material material)
		{
			base.SetDoubleSided(gltfMaterial, material);
			material.SetFloat(MaterialProperty.Cull, 0f);
		}

		protected override void SetAlphaModeMask(MaterialBase gltfMaterial, UnityEngine.Material material)
		{
			base.SetAlphaModeMask(gltfMaterial, material);
			material.SetFloat(MaterialProperty.AlphaClip, 1f);
		}

		protected override void SetShaderModeBlend(MaterialBase gltfMaterial, UnityEngine.Material material)
		{
			material.SetOverrideTag("RenderType", "Transparent");
			material.EnableKeyword("_SURFACE_TYPE_TRANSPARENT");
			material.EnableKeyword("_DISABLE_SSR_TRANSPARENT");
			material.EnableKeyword("_ENABLE_FOG_ON_TRANSPARENT");
			material.SetShaderPassEnabled("TransparentDepthPrepass", enabled: false);
			material.SetShaderPassEnabled("TransparentDepthPostpass", enabled: false);
			material.SetShaderPassEnabled("TransparentBackface", enabled: false);
			material.SetShaderPassEnabled("RayTracingPrepass", enabled: false);
			material.SetShaderPassEnabled("DepthOnly", enabled: false);
			material.SetFloat(MaterialProperty.SrcBlend, 5f);
			material.SetFloat(MaterialProperty.DstBlend, 10f);
			material.SetFloat(ShaderGraphMaterialGenerator.ZTestGBufferProperty, 3f);
			material.SetFloat(ShaderGraphMaterialGenerator.AlphaDstBlendProperty, 10f);
			material.SetFloat(MaterialProperty.Surface, 1f);
			material.SetFloat(MaterialProperty.ZWrite, 0f);
		}

		protected override Shader GetMetallicShader(MetallicShaderFeatures features)
		{
			if ((features & MetallicShaderFeatures.ClearCoat) != MetallicShaderFeatures.Default)
			{
				if (!s_MetallicClearcoatShaderQueried)
				{
					s_MetallicClearcoatShader = LoadShaderByName("glTF-pbrMetallicRoughness-Clearcoat");
					if (s_MetallicClearcoatShader == null)
					{
						s_MetallicClearcoatShader = base.GetMetallicShader(features);
					}
					s_MetallicClearcoatShaderQueried = true;
				}
				return s_MetallicClearcoatShader;
			}
			return base.GetMetallicShader(features);
		}

		protected override ShaderMode? ApplyTransmissionShaderFeatures(MaterialBase gltfMaterial)
		{
			if (!s_SupportsCameraOpaqueTexture)
			{
				return base.ApplyTransmissionShaderFeatures(gltfMaterial);
			}
			if (gltfMaterial?.Extensions?.KHR_materials_transmission != null && gltfMaterial.Extensions.KHR_materials_transmission.transmissionFactor > 0f)
			{
				return ShaderMode.Blend;
			}
			return null;
		}

		protected override RenderQueue? ApplyTransmission(ref Color baseColorLinear, IGltfReadable gltf, Transmission transmission, UnityEngine.Material material, RenderQueue? renderQueue)
		{
			if (s_SupportsCameraOpaqueTexture)
			{
				if (transmission.transmissionFactor > 0f)
				{
					material.EnableKeyword("_TRANSMISSION");
					material.SetFloat(ShaderGraphMaterialGenerator.TransmissionFactorProperty, transmission.transmissionFactor);
					renderQueue = RenderQueue.Transparent;
					TrySetTexture(transmission.transmissionTexture, material, gltf, ShaderGraphMaterialGenerator.TransmissionTextureProperty);
				}
				return renderQueue;
			}
			return base.ApplyTransmission(ref baseColorLinear, gltf, transmission, material, renderQueue);
		}
	}
}
