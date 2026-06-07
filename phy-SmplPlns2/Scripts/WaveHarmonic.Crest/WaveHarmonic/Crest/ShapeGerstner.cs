using System;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;
using UnityEngine.Experimental.Rendering;
using UnityEngine.Rendering;
using WaveHarmonic.Crest.Utility;

namespace WaveHarmonic.Crest
{
	[AddComponentMenu("Crest/Inputs/Crest Shape Gerstner")]
	public sealed class ShapeGerstner : ShapeWaves
	{
		private struct GerstnerWaveComponent4
		{
			public Vector4 _TwoPiOverWavelength;

			public Vector4 _Amplitude;

			public Vector4 _WaveDirectionX;

			public Vector4 _WaveDirectionZ;

			public Vector4 _Omega;

			public Vector4 _Phase;

			public Vector4 _ChopAmplitude;

			public Vector4 _Amplitude2;

			public Vector4 _ChopAmplitude2;

			public Vector4 _Phase2;
		}

		private new static class ShaderIDs
		{
			public static readonly int s_FirstCascadeIndex = Shader.PropertyToID("_Crest_FirstCascadeIndex");

			public static readonly int s_TextureRes = Shader.PropertyToID("_Crest_TextureRes");

			public static readonly int s_StartIndices = Shader.PropertyToID("_Crest_StartIndices");

			public static readonly int s_GerstnerWaveData = Shader.PropertyToID("_Crest_GerstnerWaveData");
		}

		[Tooltip("Use a swell spectrum as the default.\n\nUses a swell spectrum as default (when none is assigned), and disabled reverse waves.")]
		[SerializeField]
		private bool _Swell = true;

		[Tooltip("The weight of the opposing, second pair of Gerstner waves.\n\nEach Gerstner wave is actually a pair of waves travelling in opposite directions (similar to FFT). This weight is applied to the wave travelling in against-wind direction. Set to zero to obtain simple single waves which are useful for shorelines waves.")]
		[SerializeField]
		private float _ReverseWaveWeight = 0.5f;

		[Tooltip("How many wave components to generate in each octave.")]
		[SerializeField]
		private int _ComponentsPerOctave = 8;

		[Tooltip("Change to get a different set of waves.")]
		[SerializeField]
		private int _RandomSeed;

		[Tooltip("Prevent data arrays from being written to so one can provide their own.")]
		[SerializeField]
		private bool _ManualGeneration;

		private float _WindSpeedWhenGenerated = -1f;

		private const int k_MaximumWaveComponents = 1024;

		[NonSerialized]
		public float[] _Wavelengths;

		[NonSerialized]
		public float[] _Amplitudes;

		[NonSerialized]
		public float[] _Powers;

		[NonSerialized]
		public float[] _AngleDegrees;

		[NonSerialized]
		public float[] _Phases;

		private float[] _Amplitudes2;

		private float[] _Phases2;

		private readonly int[] _StartIndices = new int[16];

		private ComputeBuffer _BufferWaveData;

		private readonly GerstnerWaveComponent4[] _WaveData = new GerstnerWaveComponent4[256];

		private WaterResources.GerstnerCompute _Shader;

		private static WaveSpectrum s_SwellSpectrum;

		private readonly float _TwoPi = MathF.PI * 2f;

		private readonly float _ReciprocalTwoPi = 1f / (2f * MathF.PI);

		internal static readonly SortedList<int, ShapeGerstner> s_Instances = new SortedList<int, ShapeGerstner>(Helpers.SiblingIndexComparison);

		private static int s_InstanceCount;

		private protected override int MinimumResolution => 8;

		private protected override int MaximumResolution => int.MaxValue;

		private protected override WaveSpectrum DefaultSpectrum
		{
			get
			{
				if (!_Swell)
				{
					return ShapeWaves.WindSpectrum;
				}
				return SwellSpectrum;
			}
		}

		private static WaveSpectrum SwellSpectrum
		{
			get
			{
				if (s_SwellSpectrum == null)
				{
					s_SwellSpectrum = ScriptableObject.CreateInstance<WaveSpectrum>();
					s_SwellSpectrum.name = "Swell Waves (auto)";
					s_SwellSpectrum.hideFlags = HideFlags.DontSave | HideFlags.NotEditable;
					s_SwellSpectrum._PowerDisabled[0] = true;
					s_SwellSpectrum._PowerDisabled[1] = true;
					s_SwellSpectrum._PowerDisabled[2] = true;
					s_SwellSpectrum._PowerDisabled[3] = true;
					s_SwellSpectrum._PowerDisabled[4] = true;
					s_SwellSpectrum._PowerDisabled[5] = true;
					s_SwellSpectrum._PowerDisabled[6] = true;
					s_SwellSpectrum._PowerDisabled[7] = true;
					s_SwellSpectrum._WaveDirectionVariance = 15f;
					s_SwellSpectrum._Chop = 1.3f;
				}
				return s_SwellSpectrum;
			}
		}

		private protected override int Version => Mathf.Max(base.Version, 2);

		public int ComponentsPerOctave
		{
			get
			{
				return _ComponentsPerOctave;
			}
			set
			{
				_ComponentsPerOctave = value;
			}
		}

		public bool ManualGeneration
		{
			get
			{
				return _ManualGeneration;
			}
			set
			{
				_ManualGeneration = value;
			}
		}

		public int RandomSeed
		{
			get
			{
				return _RandomSeed;
			}
			set
			{
				_RandomSeed = value;
			}
		}

		public float ReverseWaveWeight
		{
			get
			{
				return GetReverseWaveWeight();
			}
			set
			{
				_ReverseWaveWeight = value;
			}
		}

		public bool Swell
		{
			get
			{
				return _Swell;
			}
			set
			{
				_Swell = value;
			}
		}

		[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
		private static void InitStatics()
		{
			s_Instances.Clear();
		}

		private float GetReverseWaveWeight()
		{
			if (!_Swell)
			{
				return _ReverseWaveWeight;
			}
			return 0f;
		}

		private void InitData()
		{
			if (_WaveBuffers == null)
			{
				_WaveBuffers = new RenderTexture(base.Resolution, base.Resolution, 0, Helpers.GetCompatibleTextureFormat(GraphicsFormat.R16G16B16A16_SFloat, randomWrite: true));
			}
			else
			{
				_WaveBuffers.Release();
			}
			RenderTexture waveBuffers = _WaveBuffers;
			int width = (_WaveBuffers.height = base.Resolution);
			waveBuffers.width = width;
			_WaveBuffers.wrapMode = TextureWrapMode.Clamp;
			_WaveBuffers.antiAliasing = 1;
			_WaveBuffers.filterMode = FilterMode.Bilinear;
			_WaveBuffers.anisoLevel = 0;
			_WaveBuffers.useMipMap = false;
			_WaveBuffers.name = "_Crest_GerstnerCascades";
			_WaveBuffers.dimension = TextureDimension.Tex2DArray;
			_WaveBuffers.volumeDepth = 16;
			_WaveBuffers.enableRandomWrite = true;
			_WaveBuffers.Create();
			_BufferWaveData?.Release();
			_BufferWaveData = new ComputeBuffer(256, UnsafeUtility.SizeOf<GerstnerWaveComponent4>());
			_Shader = ScriptableSingleton<WaterResources>.Instance._ComputeLibrary._GerstnerCompute;
		}

		private protected override void OnUpdate(WaterRenderer water)
		{
			bool firstUpdate = _FirstUpdate;
			base.OnUpdate(water);
			if (_WaveBuffers == null || base.Resolution != _WaveBuffers.width || _BufferWaveData == null)
			{
				InitData();
			}
			float windSpeedMPS = base.WindSpeedMPS;
			if (firstUpdate || base.UpdateDataEachFrame || windSpeedMPS != _WindSpeedWhenGenerated)
			{
				UpdateWaveData(water, windSpeedMPS);
				_WindSpeedWhenGenerated = windSpeedMPS;
			}
			ReportMaxDisplacement(water);
		}

		internal override void Draw(Lod lod, CommandBuffer buffer, RenderTargetIdentifier target, int pass = -1, float weight = 1f, int slice = -1)
		{
			if (_LastGenerateFrameCount != Time.frameCount)
			{
				if (_FirstCascade >= 0 && _LastCascade >= 0)
				{
					UpdateGenerateWaves(buffer);
					if (!base.IsCompute)
					{
						CoreUtils.SetRenderTarget(buffer, target, ClearFlag.None, 0, CubemapFace.Unknown, slice);
					}
				}
				_LastGenerateFrameCount = Time.frameCount;
			}
			base.Draw(lod, buffer, target, pass, weight, slice);
		}

		private protected override void SetRenderParameters<T>(WaterRenderer water, T wrapper)
		{
			base.SetRenderParameters(water, wrapper);
			wrapper.SetVector(ShapeWaves.ShaderIDs.s_AxisX, base.PrimaryWaveDirection);
		}

		private void SliceUpWaves(WaterRenderer water, float windSpeed)
		{
			bool flag = base.Blend != LodInputBlend.Alpha && _Mode != LodInputMode.Renderer;
			_FirstCascade = (flag ? (-1) : 0);
			_LastCascade = -2;
			int num = 0;
			int i = 0;
			int num2 = 0;
			_StartIndices[0] = 0;
			if (_ManualGeneration)
			{
				for (int j = 0; j < _WaveData.Length; j++)
				{
					_WaveData[j]._Phase2 = Vector4.zero;
					_WaveData[j]._Amplitude2 = Vector4.zero;
					_WaveData[j]._ChopAmplitude2 = Vector4.zero;
				}
			}
			float num3;
			for (num3 = MinWavelength(num); i < _Wavelengths.Length && _Wavelengths[i] < num3; i++)
			{
			}
			for (; i < _Wavelengths.Length; i++)
			{
				for (; i < _Wavelengths.Length && _Amplitudes[i] < 0.001f; i++)
				{
				}
				if (i >= _Wavelengths.Length)
				{
					break;
				}
				while (num < 16 && _Wavelengths[i] >= 2f * num3)
				{
					int num4 = num2 / 4;
					int num5 = num2 - num4 * 4;
					while (num5 != 0)
					{
						_WaveData[num4]._TwoPiOverWavelength[num5] = 1f;
						_WaveData[num4]._Amplitude[num5] = 0f;
						_WaveData[num4]._WaveDirectionX[num5] = 0f;
						_WaveData[num4]._WaveDirectionZ[num5] = 0f;
						_WaveData[num4]._Omega[num5] = 0f;
						_WaveData[num4]._Phase[num5] = 0f;
						_WaveData[num4]._ChopAmplitude[num5] = 0f;
						if (!_ManualGeneration && !_Swell)
						{
							_WaveData[num4]._Phase2[num5] = 0f;
							_WaveData[num4]._Amplitude2[num5] = 0f;
							_WaveData[num4]._ChopAmplitude2[num5] = 0f;
						}
						num5 = (num5 + 1) % 4;
						num2++;
					}
					if (num2 > 0 && _FirstCascade < 0)
					{
						_FirstCascade = num;
					}
					num++;
					_StartIndices[num] = num2 / 4;
					num3 *= 2f;
				}
				if (num == 16)
				{
					break;
				}
				int num6 = num2 / 4;
				int index = num2 - num6 * 4;
				_WaveData[num6]._Amplitude[index] = _Amplitudes[i];
				float num7 = _ActiveSpectrum._ChopScales[i / _ComponentsPerOctave];
				_WaveData[num6]._ChopAmplitude[index] = (0f - num7) * _ActiveSpectrum._Chop * _Amplitudes[i];
				if (!_ManualGeneration && !_Swell)
				{
					_WaveData[num6]._Amplitude2[index] = _Amplitudes2[i];
					_WaveData[num6]._ChopAmplitude2[index] = (0f - num7) * _ActiveSpectrum._Chop * _Amplitudes2[i];
				}
				float f = MathF.PI / 180f * _AngleDegrees[i];
				float num8 = Mathf.Cos(f);
				float num9 = Mathf.Sin(f);
				float num10 = _ActiveSpectrum._GravityScales[i / _ComponentsPerOctave];
				float num11 = water.Gravity * _ActiveSpectrum._GravityScale;
				float num12 = Mathf.Sqrt(_Wavelengths[i] * num11 * num10 * _ReciprocalTwoPi);
				float num13 = _TwoPi / _Wavelengths[i];
				float num14 = num13 * num8;
				float num15 = num13 * num9;
				float num16 = 0.5f * (float)(1 << num);
				float f2 = num14 / (_TwoPi / num16);
				float f3 = num15 / (_TwoPi / num16);
				float num17 = _TwoPi * Mathf.Round(f2) / num16;
				num15 = _TwoPi * Mathf.Round(f3) / num16;
				num13 = Mathf.Sqrt(num17 * num17 + num15 * num15);
				num8 = num17 / num13;
				num9 = num15 / num13;
				_WaveData[num6]._TwoPiOverWavelength[index] = num13;
				_WaveData[num6]._WaveDirectionX[index] = num8;
				_WaveData[num6]._WaveDirectionZ[index] = num9;
				_WaveData[num6]._Omega[index] = num13 * num12;
				_WaveData[num6]._Phase[index] = Mathf.Repeat(_Phases[i], MathF.PI * 2f);
				if (!_ManualGeneration && !_Swell)
				{
					_WaveData[num6]._Phase2[index] = Mathf.Repeat(_Phases2[i], MathF.PI * 2f);
				}
				num2++;
			}
			_LastCascade = (flag ? num : 15);
			int num18 = num2 / 4;
			int num19 = num2 - num18 * 4;
			while (num19 != 0)
			{
				_WaveData[num18]._TwoPiOverWavelength[num19] = 1f;
				_WaveData[num18]._Amplitude[num19] = 0f;
				_WaveData[num18]._WaveDirectionX[num19] = 0f;
				_WaveData[num18]._WaveDirectionZ[num19] = 0f;
				_WaveData[num18]._Omega[num19] = 0f;
				_WaveData[num18]._Phase[num19] = 0f;
				_WaveData[num18]._ChopAmplitude[num19] = 0f;
				if (!_ManualGeneration && !_Swell)
				{
					_WaveData[num18]._Phase2[num19] = 0f;
					_WaveData[num18]._Amplitude2[num19] = 0f;
					_WaveData[num18]._ChopAmplitude2[num19] = 0f;
				}
				num19 = (num19 + 1) % 4;
				num2++;
			}
			while (num < 15)
			{
				num++;
				num3 *= 2f;
				_StartIndices[num] = num2 / 4;
			}
			_BufferWaveData.SetData(_WaveData);
		}

		private void UpdateGenerateWaves(CommandBuffer buffer)
		{
			CoreUtils.SetRenderTarget(buffer, _WaveBuffers, ClearFlag.Color);
			PropertyWrapperCompute propertyWrapperCompute = new PropertyWrapperCompute(buffer, _Shader._Shader, _Shader._ExecuteKernel);
			propertyWrapperCompute.SetFloat(ShaderIDs.s_TextureRes, _WaveBuffers.width);
			propertyWrapperCompute.SetInteger(ShaderIDs.s_FirstCascadeIndex, _FirstCascade);
			propertyWrapperCompute.SetIntegers(ShaderIDs.s_StartIndices, _StartIndices);
			propertyWrapperCompute.SetBuffer(ShaderIDs.s_GerstnerWaveData, _BufferWaveData);
			propertyWrapperCompute.SetTexture(ShapeWaves.ShaderIDs.s_WaveBuffer, _WaveBuffers);
			propertyWrapperCompute.SetKeyword(in _Shader._WavePairsKeyword, !_Swell && _ReverseWaveWeight > 0f);
			propertyWrapperCompute.Dispatch(_WaveBuffers.width / 8, _WaveBuffers.height / 8, _LastCascade - _FirstCascade + 1);
		}

		private void UpdateWaveData(WaterRenderer water, float windSpeed)
		{
			if (_ManualGeneration)
			{
				if (_Wavelengths != null)
				{
					SliceUpWaves(water, windSpeed);
				}
				return;
			}
			UnityEngine.Random.State state = UnityEngine.Random.state;
			UnityEngine.Random.InitState(_RandomSeed);
			_ActiveSpectrum.GenerateWaveData(_ComponentsPerOctave, ref _Wavelengths, ref _AngleDegrees);
			UpdateAmplitudes(water);
			if (_Phases == null || _Phases.Length != _Wavelengths.Length || _Phases2 == null || _Phases2.Length != _Wavelengths.Length)
			{
				InitPhases();
			}
			UnityEngine.Random.state = state;
			SliceUpWaves(water, windSpeed);
		}

		private void UpdateAmplitudes(WaterRenderer water)
		{
			if (_Amplitudes == null || _Amplitudes.Length != _Wavelengths.Length)
			{
				_Amplitudes = new float[_Wavelengths.Length];
			}
			if (_Amplitudes2 == null || _Amplitudes2.Length != _Wavelengths.Length)
			{
				_Amplitudes2 = new float[_Wavelengths.Length];
			}
			if (_Powers == null || _Powers.Length != _Wavelengths.Length)
			{
				_Powers = new float[_Wavelengths.Length];
			}
			float windSpeedMPS = base.WindSpeedMPS;
			for (int i = 0; i < _Wavelengths.Length; i++)
			{
				float amplitude = _ActiveSpectrum.GetAmplitude(_Wavelengths[i], _ComponentsPerOctave, windSpeedMPS, water.Gravity, out _Powers[i]);
				_Amplitudes[i] = UnityEngine.Random.value * amplitude;
				if (!_Swell)
				{
					_Amplitudes2[i] = UnityEngine.Random.value * amplitude * ReverseWaveWeight;
				}
			}
		}

		private void InitPhases()
		{
			int num = _ComponentsPerOctave * 14;
			_Phases = new float[num];
			_Phases2 = new float[num];
			for (int i = 0; i < 14; i++)
			{
				for (int j = 0; j < _ComponentsPerOctave; j++)
				{
					int num2 = i * _ComponentsPerOctave + j;
					float num3 = ((float)j + UnityEngine.Random.value) / (float)_ComponentsPerOctave;
					_Phases[num2] = MathF.PI * 2f * num3;
					if (!_Swell)
					{
						float num4 = ((float)j + UnityEngine.Random.value) / (float)_ComponentsPerOctave;
						_Phases2[num2] = MathF.PI * 2f * num4;
					}
				}
			}
		}

		private protected override void ReportMaxDisplacement(WaterRenderer water)
		{
			if (!Enabled)
			{
				return;
			}
			if (_ActiveSpectrum._ChopScales.Length != 14)
			{
				Debug.LogError("Crest: WaveSpectrum " + _ActiveSpectrum.name + " is out of date, please open this asset and resave in editor.", _ActiveSpectrum);
			}
			if (_Wavelengths != null)
			{
				base.MaximumReportedVerticalDisplacement = 0f;
				base.MaximumReportedHorizontalDisplacement = 0f;
				for (int i = 0; i < _Wavelengths.Length; i++)
				{
					float num = _Amplitudes[i];
					base.MaximumReportedVerticalDisplacement += num;
					base.MaximumReportedHorizontalDisplacement += num * _ActiveSpectrum._ChopScales[i / _ComponentsPerOctave];
				}
				base.MaximumReportedHorizontalDisplacement *= _ActiveSpectrum._Chop;
				base.MaximumReportedVerticalDisplacement *= base.Weight;
				base.MaximumReportedHorizontalDisplacement *= base.Weight;
				base.MaximumReportedWavesDisplacement = base.MaximumReportedVerticalDisplacement;
			}
		}

		private protected override void Initialize()
		{
			base.Initialize();
			s_Instances.Add(base.transform.GetSiblingIndex(), this);
		}

		private protected override void OnDisable()
		{
			base.OnDisable();
			s_Instances.Remove(this);
			if (_BufferWaveData != null && _BufferWaveData.IsValid())
			{
				_BufferWaveData.Dispose();
				_BufferWaveData = null;
			}
			if (_WaveBuffers != null)
			{
				Helpers.Destroy(_WaveBuffers);
				_WaveBuffers = null;
			}
		}

		private protected override void Awake()
		{
			base.Awake();
			s_InstanceCount++;
		}

		private protected override void OnDestroy()
		{
			base.OnDestroy();
			if (s_SwellSpectrum != null)
			{
				Helpers.Destroy(s_SwellSpectrum);
				s_SwellSpectrum = null;
			}
		}

		private protected override void OnMigrate()
		{
			base.OnMigrate();
			if (_Version < 2)
			{
				_Swell = false;
			}
		}
	}
}
