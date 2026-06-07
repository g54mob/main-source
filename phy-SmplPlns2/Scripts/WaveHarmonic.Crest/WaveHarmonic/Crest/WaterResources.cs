using System;
using UnityEngine;
using UnityEngine.Experimental.Rendering;
using UnityEngine.Rendering;
using WaveHarmonic.Crest.Utility;

namespace WaveHarmonic.Crest
{
	[ExecuteAlways]
	[FilePath("Packages/com.waveharmonic.crest/Runtime/Settings/Resources.asset")]
	internal sealed class WaterResources : ScriptableSingleton<WaterResources>
	{
		[Serializable]
		public sealed class ShaderResources
		{
			public Shader _CopyDepthIntoCache;

			public Shader _ColorSpline;

			public Shader _FlowSpline;

			public Shader _FoamSpline;

			public Shader _WaveSpline;

			public Shader _DepthGeometry;

			public Shader _LevelGeometry;

			public Shader _UpdateShadow;

			public Shader _UnderwaterEffect;

			public Shader _UnderwaterMask;

			public Shader _HorizonMask;

			public Shader _Portals;

			public Shader _PortalsMask;

			public Shader _ClipConvexHull;

			public Shader _ShallowWaterSimulationVisualizer;

			public Shader _DebugTextureArray;

			public Shader _Blit;

			public Shader _ForceShadows;

			public Shader _CaptureShadowMatrices;
		}

		[Serializable]
		public sealed class ComputeResources
		{
			public ComputeShader _Mask;

			public ComputeShader _UnderwaterArtifacts;

			public ComputeShader _ShapeWavesTransfer;

			public ComputeShader _Query;

			public ComputeShader _Gerstner;

			public ComputeShader _FFT;

			public ComputeShader _FFTBake;

			public ComputeShader _FFTSpectrum;

			public ComputeShader _ShapeCombine;

			public ComputeShader _ShorelineColor;

			public ComputeShader _UpdateDynamicWaves;

			public ComputeShader _UpdateFoam;

			public ComputeShader _UpdateShadow;

			public ComputeShader _PackLevel;

			public ComputeShader _AbsorptionTexture;

			public ComputeShader _ClipTexture;

			public ComputeShader _FlowTexture;

			public ComputeShader _FoamTexture;

			public ComputeShader _LevelTexture;

			public ComputeShader _DepthTexture;

			public ComputeShader _ScatteringTexture;

			public ComputeShader _ClipPrimitive;

			public ComputeShader _SphereWaterInteraction;

			public ComputeShader _RenderDepthProbe;

			public ComputeShader _JumpFloodSDF;

			public ComputeShader _UpdateSWS;

			public ComputeShader _Whirlpool;

			public ComputeShader _Clear;

			public ComputeShader _Blit;

			public ComputeShader _Blur;
		}

		public sealed class KeywordResources
		{
			public LocalKeyword AnimatedWavesTransferWavesTexture { get; private set; }

			public LocalKeyword AnimatedWavesTransferWavesTextureBlend { get; private set; }

			public LocalKeyword ClipPrimitiveInverted { get; private set; }

			public LocalKeyword ClipPrimitiveSphere { get; private set; }

			public LocalKeyword ClipPrimitiveCube { get; private set; }

			public LocalKeyword ClipPrimitiveRectangle { get; private set; }

			public LocalKeyword DepthTextureSDF { get; private set; }

			public LocalKeyword ShorelineColorSourceDistance { get; private set; }

			public LocalKeyword ShorelineColorScattering { get; private set; }

			public LocalKeyword LevelTextureCatmullRom { get; private set; }

			public LocalKeyword DepthProbeBackFaceInclusion { get; private set; }

			public LocalKeyword JumpFloodInverted { get; private set; }

			public LocalKeyword JumpFloodStandalone { get; private set; }

			internal void Initialize(WaterResources resources)
			{
				ComputeResources compute = resources.Compute;
				LocalKeywordSpace keywordSpace = compute._ShapeWavesTransfer.keywordSpace;
				AnimatedWavesTransferWavesTexture = keywordSpace.FindKeyword("d_Texture");
				AnimatedWavesTransferWavesTextureBlend = keywordSpace.FindKeyword("d_TextureBlend");
				LocalKeywordSpace keywordSpace2 = compute._ClipPrimitive.keywordSpace;
				ClipPrimitiveInverted = keywordSpace2.FindKeyword("d_Inverted");
				ClipPrimitiveSphere = keywordSpace2.FindKeyword("d_Sphere");
				ClipPrimitiveCube = keywordSpace2.FindKeyword("d_Cube");
				ClipPrimitiveRectangle = keywordSpace2.FindKeyword("d_Rectangle");
				DepthTextureSDF = compute._DepthTexture.keywordSpace.FindKeyword("d_CrestSDF");
				LevelTextureCatmullRom = compute._LevelTexture.keywordSpace.FindKeyword("d_CatmullRom");
				DepthProbeBackFaceInclusion = compute._RenderDepthProbe.keywordSpace.FindKeyword("d_Crest_BackFaceInclusion");
				LocalKeywordSpace keywordSpace3 = compute._JumpFloodSDF.keywordSpace;
				JumpFloodInverted = keywordSpace3.FindKeyword("d_Crest_Inverted");
				JumpFloodStandalone = keywordSpace3.FindKeyword("d_Crest_Standalone");
				LocalKeywordSpace keywordSpace4 = compute._ShorelineColor.keywordSpace;
				ShorelineColorSourceDistance = keywordSpace4.FindKeyword("d_Crest_ShorelineColorSource_ShorelineDistance");
				ShorelineColorScattering = keywordSpace4.FindKeyword("d_Crest_ShorelineScattering");
			}
		}

		public sealed class ComputeLibrary
		{
			public BlitCompute _BlitCompute;

			public BlurCompute _BlurCompute;

			public ClearCompute _ClearCompute;

			public ShapeCombineCompute _ShapeCombineCompute;

			public GerstnerCompute _GerstnerCompute;

			public ComputeLibrary(WaterResources resources)
			{
				_BlitCompute = new BlitCompute(resources.Compute._Blit);
				_BlurCompute = new BlurCompute(resources.Compute._Blur);
				_ClearCompute = new ClearCompute(resources.Compute._Clear);
				_ShapeCombineCompute = new ShapeCombineCompute(resources.Compute._ShapeCombine);
				_GerstnerCompute = new GerstnerCompute(resources.Compute._Gerstner);
			}
		}

		public abstract class UtilityCompute
		{
			public readonly ComputeShader _Shader;

			public readonly LocalKeyword _Float1Keyword;

			public readonly LocalKeyword _Float2Keyword;

			public readonly LocalKeyword _Float3Keyword;

			public readonly LocalKeyword _Float4Keyword;

			public UtilityCompute(ComputeShader shader)
			{
				_Shader = shader;
				LocalKeywordSpace keywordSpace = shader.keywordSpace;
				_Float1Keyword = keywordSpace.FindKeyword("d_Float1");
				_Float2Keyword = keywordSpace.FindKeyword("d_Float2");
				_Float3Keyword = keywordSpace.FindKeyword("d_Float3");
				_Float4Keyword = keywordSpace.FindKeyword("d_Float4");
			}

			public void SetVariantForFormat<T>(T wrapper, GraphicsFormat format) where T : IPropertyWrapperVariants
			{
				uint componentCount = GraphicsFormatUtility.GetComponentCount(format);
				ref readonly LocalKeyword float1Keyword = ref _Float1Keyword;
				wrapper.SetKeyword(in float1Keyword, componentCount == 1);
				ref readonly LocalKeyword float2Keyword = ref _Float2Keyword;
				wrapper.SetKeyword(in float2Keyword, componentCount == 2);
				ref readonly LocalKeyword float3Keyword = ref _Float3Keyword;
				wrapper.SetKeyword(in float3Keyword, componentCount == 3);
				ref readonly LocalKeyword float4Keyword = ref _Float4Keyword;
				wrapper.SetKeyword(in float4Keyword, componentCount == 4);
			}
		}

		public sealed class ClearCompute : UtilityCompute
		{
			public readonly int _KernelClearTarget;

			public readonly int _KernelClearTargetBoundaryX;

			public readonly int _KernelClearTargetBoundaryY;

			public ClearCompute(ComputeShader shader)
				: base(shader)
			{
				_KernelClearTarget = 0;
				_KernelClearTargetBoundaryX = 1;
				_KernelClearTargetBoundaryY = 2;
			}
		}

		public sealed class BlitCompute : UtilityCompute
		{
			public readonly int _KernelAdd;

			public BlitCompute(ComputeShader shader)
				: base(shader)
			{
				_KernelAdd = 0;
			}
		}

		public sealed class BlurCompute : UtilityCompute
		{
			public readonly int _KernelHorizontal;

			public readonly int _KernelVertical;

			public BlurCompute(ComputeShader shader)
				: base(shader)
			{
				_KernelHorizontal = 0;
				_KernelVertical = 1;
			}
		}

		public sealed class ShapeCombineCompute
		{
			public readonly ComputeShader _Shader;

			public readonly LocalKeyword _CombineKeyword;

			public readonly LocalKeyword _DynamicWavesKeyword;

			public readonly int _CopyAnimatedWavesKernel;

			public readonly int _CombineAnimatedWavesKernel;

			public readonly int _CombineDynamicWavesKernel;

			public ShapeCombineCompute(ComputeShader shader)
			{
				_Shader = shader;
				LocalKeywordSpace keywordSpace = shader.keywordSpace;
				_CombineKeyword = keywordSpace.FindKeyword("d_Combine");
				_DynamicWavesKeyword = keywordSpace.FindKeyword("d_DynamicWaves");
				_CombineAnimatedWavesKernel = 0;
				_CopyAnimatedWavesKernel = 1;
				_CombineDynamicWavesKernel = 2;
			}
		}

		public sealed class GerstnerCompute
		{
			public readonly ComputeShader _Shader;

			public readonly LocalKeyword _WavePairsKeyword;

			public readonly int _ExecuteKernel;

			public GerstnerCompute(ComputeShader shader)
			{
				_Shader = shader;
				_WavePairsKeyword = shader.keywordSpace.FindKeyword("d_WavePairs");
				_ExecuteKernel = 0;
			}
		}

		[SerializeField]
		private ShaderResources _Shaders = new ShaderResources();

		[SerializeField]
		private ComputeResources _Compute = new ComputeResources();

		internal ComputeLibrary _ComputeLibrary;

		public ShaderResources Shaders => _Shaders;

		public ComputeResources Compute => _Compute;

		public KeywordResources Keywords { get; } = new KeywordResources();

		public event Action AfterEnabled;

		private void OnEnable()
		{
			base.hideFlags = HideFlags.NotEditable;
			Initialize();
		}

		private void Initialize()
		{
			Keywords.Initialize(this);
			_ComputeLibrary = new ComputeLibrary(this);
			this.AfterEnabled?.Invoke();
		}
	}
}
