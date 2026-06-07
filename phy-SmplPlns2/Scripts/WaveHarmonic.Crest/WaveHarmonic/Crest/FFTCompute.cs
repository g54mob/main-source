using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering;
using UnityEngine.Rendering;
using WaveHarmonic.Crest.Utility;

namespace WaveHarmonic.Crest
{
	internal sealed class FFTCompute
	{
		public static class ShaderIDs
		{
			public static readonly int s_Size = Shader.PropertyToID("_Crest_Size");

			public static readonly int s_WindSpeed = Shader.PropertyToID("_Crest_WindSpeed");

			public static readonly int s_Turbulence = Shader.PropertyToID("_Crest_Turbulence");

			public static readonly int s_Alignment = Shader.PropertyToID("_Crest_Alignment");

			public static readonly int s_Gravity = Shader.PropertyToID("_Crest_Gravity");

			public static readonly int s_Period = Shader.PropertyToID("_Crest_Period");

			public static readonly int s_WindDir = Shader.PropertyToID("_Crest_WindDir");

			public static readonly int s_SpectrumControls = Shader.PropertyToID("_Crest_SpectrumControls");

			public static readonly int s_ResultInit = Shader.PropertyToID("_Crest_ResultInit");

			public static readonly int s_Time = Shader.PropertyToID("_Crest_Time");

			public static readonly int s_Chop = Shader.PropertyToID("_Crest_Chop");

			public static readonly int s_ChopScales = Shader.PropertyToID("_Crest_ChopScales");

			public static readonly int s_GravityScales = Shader.PropertyToID("_Crest_GravityScales");

			public static readonly int s_Init0 = Shader.PropertyToID("_Crest_Init0");

			public static readonly int s_ResultHeight = Shader.PropertyToID("_Crest_ResultHeight");

			public static readonly int s_ResultDisplaceX = Shader.PropertyToID("_Crest_ResultDisplaceX");

			public static readonly int s_ResultDisplaceZ = Shader.PropertyToID("_Crest_ResultDisplaceZ");

			public static readonly int s_InputH = Shader.PropertyToID("_Crest_InputH");

			public static readonly int s_InputX = Shader.PropertyToID("_Crest_InputX");

			public static readonly int s_InputZ = Shader.PropertyToID("_Crest_InputZ");

			public static readonly int s_InputButterfly = Shader.PropertyToID("_Crest_InputButterfly");

			public static readonly int s_Output1 = Shader.PropertyToID("_Crest_Output1");

			public static readonly int s_Output2 = Shader.PropertyToID("_Crest_Output2");

			public static readonly int s_Output3 = Shader.PropertyToID("_Crest_Output3");

			public static readonly int s_Output = Shader.PropertyToID("_Crest_Output");

			public static readonly int s_TemporaryFFT1 = Shader.PropertyToID("_Crest_TemporaryFFT1");

			public static readonly int s_TemporaryFFT2 = Shader.PropertyToID("_Crest_TemporaryFFT2");

			public static readonly int s_TemporaryFFT3 = Shader.PropertyToID("_Crest_TemporaryFFT3");
		}

		internal readonly struct Parameters
		{
			public readonly WaveSpectrum _Spectrum;

			public readonly int _Resolution;

			public readonly float _LoopPeriod;

			public readonly float _WindSpeed;

			public readonly float _WindDirectionRadians;

			public readonly float _WindTurbulence;

			public readonly float _WindAlignment;

			public readonly float _Gravity;

			public readonly bool _Advanced;

			public Parameters(WaveSpectrum spectrum, int resolution, float period, float speed, float direction, float turbulence, float alignment, float gravity, bool advanced)
			{
				_Spectrum = spectrum;
				_Resolution = resolution;
				_LoopPeriod = period;
				_WindSpeed = speed;
				_WindDirectionRadians = direction;
				_WindTurbulence = turbulence;
				_WindAlignment = alignment;
				_Gravity = gravity;
				_Advanced = advanced;
			}

			public override int GetHashCode()
			{
				return GetHashCode(_Resolution);
			}

			public int GetHashCode(int resolution)
			{
				HashCode hashCode = default(HashCode);
				hashCode.Add(_Spectrum);
				hashCode.Add(_LoopPeriod);
				hashCode.Add(_WindSpeed);
				hashCode.Add(_WindDirectionRadians);
				hashCode.Add(_WindTurbulence);
				hashCode.Add(_WindAlignment);
				hashCode.Add(_Gravity);
				hashCode.Add(resolution);
				hashCode.Add(_Advanced);
				return hashCode.ToHashCode();
			}
		}

		private const int k_Kernel0Resolution = 8;

		private const int k_CascadeCount = 16;

		private bool _Initialized;

		private RenderTexture _SpectrumInitial;

		private bool _SpectrumInitialized;

		private ComputeShader _ShaderSpectrum;

		private ComputeShader _ShaderFFT;

		private int _KernelSpectrumInitial;

		private int _KernelSpectrumUpdate;

		private LocalKeyword _AdvancedKeyword;

		private Parameters _Parameters;

		private float _GenerationTime = -1f;

		private static readonly bool s_SupportsRandomWriteRGFloat = !Helpers.IsWebGPU && SystemInfo.SupportsRandomWriteOnRenderTextureFormat(RenderTextureFormat.RGFloat);

		private static readonly Dictionary<int, FFTCompute> s_Generators = new Dictionary<int, FFTCompute>();

		private static readonly Dictionary<int, Texture2D> s_ButterflyTextures = new Dictionary<int, Texture2D>();

		public RenderTexture WaveBuffers { get; private set; }

		public static int GeneratorCount
		{
			get
			{
				if (s_Generators == null)
				{
					return 0;
				}
				return s_Generators.Count;
			}
		}

		public FFTCompute(Parameters parameters)
		{
			_Parameters = parameters;
		}

		public void Release()
		{
			if (_SpectrumInitial != null)
			{
				_SpectrumInitial.Release();
			}
			if (WaveBuffers != null)
			{
				WaveBuffers.Release();
			}
			Helpers.Destroy(_SpectrumInitial);
			Helpers.Destroy(WaveBuffers);
			_SpectrumInitialized = false;
			_Initialized = false;
		}

		internal static void CleanUpAll()
		{
			foreach (KeyValuePair<int, FFTCompute> s_Generator in s_Generators)
			{
				s_Generator.Value.Release();
			}
			s_Generators?.Clear();
			foreach (Texture2D item in s_ButterflyTextures?.Values)
			{
				Helpers.Destroy(item);
			}
			s_ButterflyTextures?.Clear();
		}

		[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
		private static void InitStatics()
		{
			CleanUpAll();
		}

		public static RenderTexture GenerateDisplacements(CommandBuffer buf, float time, Parameters parameters, bool updateSpectrum)
		{
			int hashCode = parameters.GetHashCode();
			if (!s_Generators.TryGetValue(hashCode, out var value))
			{
				value = new FFTCompute(parameters);
				s_Generators.Add(hashCode, value);
			}
			return value.GenerateDisplacementsInternal(buf, time, updateSpectrum);
		}

		private RenderTexture GenerateDisplacementsInternal(CommandBuffer buffer, float time, bool updateSpectrum)
		{
			if (_GenerationTime == time && !updateSpectrum)
			{
				return WaveBuffers;
			}
			int resolution = _Parameters._Resolution;
			float loopPeriod = _Parameters._LoopPeriod;
			if (!_Initialized || _SpectrumInitial == null)
			{
				Release();
				_ShaderSpectrum = ScriptableSingleton<WaterResources>.Instance.Compute._FFTSpectrum;
				_KernelSpectrumInitial = _ShaderSpectrum.FindKernel("SpectrumInitalize");
				_KernelSpectrumUpdate = _ShaderSpectrum.FindKernel("SpectrumUpdate");
				_ShaderFFT = ScriptableSingleton<WaterResources>.Instance.Compute._FFT;
				_AdvancedKeyword = _ShaderSpectrum.keywordSpace.FindKeyword("d_AdvancedControls");
				RenderTextureDescriptor descriptor = new RenderTextureDescriptor(0, 0);
				int width = (descriptor.height = resolution);
				descriptor.width = width;
				descriptor.dimension = TextureDimension.Tex2DArray;
				descriptor.enableRandomWrite = true;
				descriptor.depthBufferBits = 0;
				descriptor.volumeDepth = 16;
				descriptor.graphicsFormat = GraphicsFormat.R32G32B32A32_SFloat;
				descriptor.msaaSamples = 1;
				Helpers.SafeCreateRenderTexture(ref _SpectrumInitial, descriptor);
				_SpectrumInitial.name = "_Crest_FFTSpectrumInit";
				_SpectrumInitial.Create();
				WaveBuffers = new RenderTexture(resolution, resolution, 0, Helpers.GetCompatibleTextureFormat(GraphicsFormat.R16G16B16A16_SFloat, randomWrite: true))
				{
					wrapMode = TextureWrapMode.Repeat,
					antiAliasing = 1,
					filterMode = FilterMode.Bilinear,
					anisoLevel = 0,
					useMipMap = false,
					name = "_Crest_FFTCascades",
					dimension = TextureDimension.Tex2DArray,
					volumeDepth = 16,
					enableRandomWrite = true
				};
				WaveBuffers.Create();
				if (!s_ButterflyTextures.ContainsKey(resolution))
				{
					int num2 = Mathf.RoundToInt(Mathf.Log(resolution, 2f));
					Color[] array = new Color[resolution * num2];
					int num3 = 1;
					int num4 = resolution >> 1;
					for (int i = 0; i < num2; i++)
					{
						int num5 = i * resolution;
						int num6 = 0;
						int num7 = 2 * num3;
						for (int j = 0; j < num4; j++)
						{
							float num8 = 0f;
							for (int k = num6; k < num7; k += 2)
							{
								float f = MathF.PI * 2f * num8 * (float)num4 / (float)resolution;
								float num9 = Mathf.Cos(f);
								float num10 = Mathf.Sin(f);
								array[num5 + k / 2] = new Color(num9, 0f - num10, 0f, 1f);
								array[num5 + k / 2 + num3] = new Color(0f - num9, num10, 0f, 1f);
								num8 += 1f;
							}
							num6 += 4 * num3;
							num7 = num6 + 2 * num3;
						}
						num4 >>= 1;
						num3 <<= 1;
					}
					Texture2D texture2D = new Texture2D(resolution, Mathf.RoundToInt(Mathf.Log(resolution, 2f)), TextureFormat.RGFloat, mipChain: false, linear: true);
					texture2D.SetPixels(array);
					texture2D.Apply();
					s_ButterflyTextures.Add(resolution, texture2D);
				}
				_Initialized = true;
			}
			if (!_SpectrumInitialized || updateSpectrum)
			{
				PropertyWrapperCompute propertyWrapperCompute = new PropertyWrapperCompute(buffer, _ShaderSpectrum, _KernelSpectrumInitial);
				propertyWrapperCompute.SetInteger(ShaderIDs.s_Size, resolution);
				propertyWrapperCompute.SetFloat(ShaderIDs.s_WindSpeed, _Parameters._WindSpeed);
				propertyWrapperCompute.SetFloat(ShaderIDs.s_Turbulence, _Parameters._WindTurbulence);
				propertyWrapperCompute.SetFloat(ShaderIDs.s_Alignment, _Parameters._WindAlignment);
				propertyWrapperCompute.SetFloat(ShaderIDs.s_Gravity, _Parameters._Gravity);
				propertyWrapperCompute.SetFloat(ShaderIDs.s_Period, (loopPeriod < float.PositiveInfinity) ? loopPeriod : (-1f));
				propertyWrapperCompute.SetVector(ShaderIDs.s_WindDir, new Vector4(Mathf.Cos(_Parameters._WindDirectionRadians), Mathf.Sin(_Parameters._WindDirectionRadians)));
				propertyWrapperCompute.SetTexture(ShaderIDs.s_SpectrumControls, _Parameters._Spectrum.ControlsTexture);
				propertyWrapperCompute.SetTexture(ShaderIDs.s_ResultInit, _SpectrumInitial);
				propertyWrapperCompute.Dispatch(resolution / 8, resolution / 8, 16);
				_SpectrumInitialized = true;
			}
			PropertyWrapperCompute propertyWrapperCompute2 = new PropertyWrapperCompute(buffer, _ShaderSpectrum, _KernelSpectrumUpdate);
			RenderTextureDescriptor descriptor2 = _SpectrumInitial.descriptor;
			descriptor2.graphicsFormat = Helpers.GetCompatibleTextureFormat(GraphicsFormat.R32G32_SFloat, Helpers.s_DataGraphicsFormatUsage, "FFT", randomWrite: true);
			buffer.GetTemporaryRT(ShaderIDs.s_TemporaryFFT1, descriptor2);
			buffer.GetTemporaryRT(ShaderIDs.s_TemporaryFFT2, descriptor2);
			buffer.GetTemporaryRT(ShaderIDs.s_TemporaryFFT3, descriptor2);
			propertyWrapperCompute2.SetKeyword(in _AdvancedKeyword, _Parameters._Advanced);
			propertyWrapperCompute2.SetInteger(ShaderIDs.s_Size, resolution);
			propertyWrapperCompute2.SetFloat(ShaderIDs.s_Time, time * _Parameters._Spectrum._GravityScale);
			propertyWrapperCompute2.SetFloatArray(ShaderIDs.s_ChopScales, _Parameters._Spectrum._ChopScales);
			propertyWrapperCompute2.SetFloatArray(ShaderIDs.s_GravityScales, _Parameters._Spectrum._GravityScales);
			propertyWrapperCompute2.SetFloat(ShaderIDs.s_Chop, _Parameters._Spectrum._Chop);
			propertyWrapperCompute2.SetFloat(ShaderIDs.s_Period, (loopPeriod < float.PositiveInfinity) ? loopPeriod : (-1f));
			propertyWrapperCompute2.SetTexture(ShaderIDs.s_Init0, _SpectrumInitial);
			propertyWrapperCompute2.SetTexture(ShaderIDs.s_ResultHeight, ShaderIDs.s_TemporaryFFT1);
			propertyWrapperCompute2.SetTexture(ShaderIDs.s_ResultDisplaceX, ShaderIDs.s_TemporaryFFT2);
			propertyWrapperCompute2.SetTexture(ShaderIDs.s_ResultDisplaceZ, ShaderIDs.s_TemporaryFFT3);
			propertyWrapperCompute2.Dispatch(resolution / 8, resolution / 8, 16);
			int num11 = 2 * Mathf.RoundToInt(Mathf.Log(resolution / 8, 2f));
			PropertyWrapperCompute propertyWrapperCompute3 = new PropertyWrapperCompute(buffer, _ShaderFFT, num11);
			Texture2D value = s_ButterflyTextures[resolution];
			propertyWrapperCompute3.SetTexture(ShaderIDs.s_InputButterfly, value);
			propertyWrapperCompute3.SetTexture(ShaderIDs.s_Output1, ShaderIDs.s_TemporaryFFT1);
			propertyWrapperCompute3.SetTexture(ShaderIDs.s_Output2, ShaderIDs.s_TemporaryFFT2);
			propertyWrapperCompute3.SetTexture(ShaderIDs.s_Output3, ShaderIDs.s_TemporaryFFT3);
			propertyWrapperCompute3.Dispatch(1, resolution, 16);
			propertyWrapperCompute3 = new PropertyWrapperCompute(buffer, _ShaderFFT, num11 + 1);
			propertyWrapperCompute3.SetTexture(ShaderIDs.s_InputH, ShaderIDs.s_TemporaryFFT1);
			propertyWrapperCompute3.SetTexture(ShaderIDs.s_InputX, ShaderIDs.s_TemporaryFFT2);
			propertyWrapperCompute3.SetTexture(ShaderIDs.s_InputZ, ShaderIDs.s_TemporaryFFT3);
			propertyWrapperCompute3.SetTexture(ShaderIDs.s_InputButterfly, value);
			propertyWrapperCompute3.SetTexture(ShaderIDs.s_Output, WaveBuffers);
			propertyWrapperCompute3.Dispatch(resolution, 1, 16);
			buffer.ReleaseTemporaryRT(ShaderIDs.s_TemporaryFFT1);
			buffer.ReleaseTemporaryRT(ShaderIDs.s_TemporaryFFT2);
			buffer.ReleaseTemporaryRT(ShaderIDs.s_TemporaryFFT3);
			_GenerationTime = time;
			return WaveBuffers;
		}

		public static void OnGenerationDataUpdated(Parameters oldParameters, Parameters newParameters)
		{
			int hashCode = newParameters.GetHashCode();
			if (!s_Generators.TryGetValue(hashCode, out var value))
			{
				int hashCode2 = oldParameters.GetHashCode(newParameters._Resolution);
				if (s_Generators.TryGetValue(hashCode2, out var value2))
				{
					s_Generators.Remove(hashCode2);
					value2._Parameters = newParameters;
					value2._SpectrumInitialized = false;
					s_Generators.Add(hashCode, value2);
				}
			}
			else
			{
				value.Release();
				s_Generators.Remove(oldParameters.GetHashCode());
			}
		}

		public static FFTCompute GetInstance(Parameters parameters)
		{
			return s_Generators.GetValueOrDefault(parameters.GetHashCode(), null);
		}

		public bool HasData()
		{
			if (WaveBuffers != null)
			{
				return WaveBuffers.IsCreated();
			}
			return false;
		}

		internal void OnGUI()
		{
			if (WaveBuffers != null && WaveBuffers.IsCreated())
			{
				DebugGUI.DrawTextureArray(WaveBuffers, 8, 0.5f, 20f);
			}
			if (_Parameters._Spectrum != null)
			{
				_Parameters._Spectrum.OnGUI();
			}
		}
	}
}
