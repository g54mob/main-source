using System;
using UnityEngine;
using UnityEngine.Rendering;

namespace HauntedPSX.RenderPipelines.PSX.Runtime
{
	public class PSXRenderPipelineResources : ScriptableObject
	{
		[Serializable]
		[ReloadGroup]
		public sealed class ShaderResources
		{
			[Reload("Runtime/PostProcessing/Shaders/Sky.shader", ReloadAttribute.Package.Root)]
			public Shader skyPS;

			[Reload("Runtime/PostProcessing/Shaders/AccumulationMotionBlur.shader", ReloadAttribute.Package.Root)]
			public Shader accumulationMotionBlurPS;

			[Reload("Runtime/PostProcessing/Shaders/CopyColorRespectFlipY.shader", ReloadAttribute.Package.Root)]
			public Shader copyColorRespectFlipYPS;

			[Reload("Runtime/PostProcessing/Shaders/CRT.shader", ReloadAttribute.Package.Root)]
			public Shader crtPS;

			[Reload("Runtime/PostProcessing/Shaders/Compression.compute", ReloadAttribute.Package.Root)]
			public ComputeShader compressionCS;

			[Reload("Runtime/Material/PSXTerrain/PSXTerrainDetail.shader", ReloadAttribute.Package.Root)]
			public Shader terrainDetailLitPS;

			[Reload("Runtime/Material/PSXTerrain/PSXWavingGrass.shader", ReloadAttribute.Package.Root)]
			public Shader terrainDetailGrassPS;

			[Reload("Runtime/Material/PSXTerrain/PSXWavingGrassBillboard.shader", ReloadAttribute.Package.Root)]
			public Shader terrainDetailGrassBillboardPS;
		}

		[Serializable]
		[ReloadGroup]
		public sealed class TextureResources
		{
			[Reload("Runtime/RenderPipelineResources/Texture/WhiteNoise1024RGB.png", 0, 2, ReloadAttribute.Package.Root)]
			public Texture2D[] whiteNoise1024RGBTex;

			[Reload("Runtime/RenderPipelineResources/Texture/Bayer/BayerL4x4.png", 0, 2, ReloadAttribute.Package.Root)]
			public Texture2D[] framebufferDitherTex;

			[Reload("Runtime/RenderPipelineResources/Texture/Bayer/BayerL4x4.png", 0, 2, ReloadAttribute.Package.Root)]
			public Texture2D[] alphaClippingDitherTex;

			[Reload("Runtime/RenderPipelineResources/Texture/BlueNoise16/L/LDR_LLL1_{0}.png", 0, 32, ReloadAttribute.Package.Root)]
			public Texture2D[] blueNoise16LTex;

			[Reload("Runtime/RenderPipelineResources/Texture/BlueNoise16/RGB/LDR_RGB1_{0}.png", 0, 32, ReloadAttribute.Package.Root)]
			public Texture2D[] blueNoise16RGBTex;

			[Reload("Runtime/RenderPipelineResources/Texture/SkyboxTextureCubeDefault.exr", ReloadAttribute.Package.Root)]
			public Texture skyboxTextureCubeDefault;
		}

		[Serializable]
		[ReloadGroup]
		public sealed class MaterialResources
		{
			[Reload("Runtime/RenderPipelineResources/Material/DefaultOpaqueMat.mat", ReloadAttribute.Package.Root)]
			public Material defaultOpaqueMat;
		}

		public ShaderResources shaders;

		public TextureResources textures;

		public MaterialResources materials;
	}
}
