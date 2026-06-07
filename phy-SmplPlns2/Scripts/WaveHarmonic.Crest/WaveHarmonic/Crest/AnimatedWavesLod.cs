using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering;
using UnityEngine.Rendering;
using WaveHarmonic.Crest.Utility;

namespace WaveHarmonic.Crest
{
	[Serializable]
	public sealed class AnimatedWavesLod : Lod<ICollisionProvider>
	{
		internal new static class ShaderIDs
		{
			public static readonly int s_WaveBuffer = Shader.PropertyToID("_Crest_WaveBuffer");

			public static readonly int s_DynamicWavesTarget = Shader.PropertyToID("_Crest_DynamicWavesTarget");

			public static readonly int s_AttenuationInShallows = Shader.PropertyToID("_Crest_AttenuationInShallows");
		}

		internal readonly struct WavelengthFilter
		{
			public readonly float _Minimum;

			public readonly float _Maximum;

			public readonly float _TransitionThreshold;

			public readonly float _ViewerAltitudeLevelAlpha;

			public readonly int _Slice;

			public readonly int _Slices;

			public readonly bool _HighQualityCombine;

			public WavelengthFilter(WaterRenderer water, int slice, int resolution)
			{
				_Slice = slice;
				_Slices = water.LodLevels;
				_Maximum = water.MaximumWavelength(slice, resolution);
				_Minimum = _Maximum * 0.5f;
				_TransitionThreshold = water.MaximumWavelength(_Slices - 1, resolution) * 0.5f;
				_ViewerAltitudeLevelAlpha = water.ViewerAltitudeLevelAlpha;
				_HighQualityCombine = water.AnimatedWavesLod.PreserveWaveQuality;
			}
		}

		[Tooltip("Collision layers to enable.\n\nSome layers will have overhead with CPU, GPU and memory.")]
		[SerializeField]
		internal CollisionLayers _CollisionLayers = CollisionLayers.Everything;

		[SerializeField]
		internal BakedWaveData _BakedWaveData;

		[Tooltip("The wave sampling method to determine quality and performance.")]
		[SerializeField]
		internal WaveSampling _WaveSampling;

		[Tooltip("Shifts wavelengths to maintain quality for higher resolutions.\n\nSet this to 2 to improve wave quality. In some cases like flowing rivers, this can make a substantial difference to visual stability. We recommend doubling the Resolution on the WaterRenderer component to preserve detail after making this change.")]
		[SerializeField]
		private float _WaveResolutionMultiplier = 1f;

		[Tooltip("How much waves are dampened in shallow water.")]
		[SerializeField]
		private float _AttenuationInShallows = 0.95f;

		[Tooltip("Any water deeper than this will receive full wave strength.\n\nThe lower the value, the less effective the depth cache will be at attenuating very large waves. Set to the maximum value (1,000) to disable.")]
		[SerializeField]
		private float _ShallowsMaximumDepth = 1000f;

		private const string k_DrawCombine = "Combine";

		internal static readonly Color s_GizmoColor = new Color(0f, 1f, 0f, 0.5f);

		internal static bool s_Combine = true;

		private WaterResources.ShapeCombineCompute _CombineShader;

		private RenderTexture _PersistentDataTexture;

		internal static readonly WaveHarmonic.Crest.Utility.SortedList<int, ILodInput> s_Inputs = new WaveHarmonic.Crest.Utility.SortedList<int, ILodInput>(Helpers.DuplicateComparison);

		private readonly Dictionary<Camera, RenderTexture> _AdditionalCameraData = new Dictionary<Camera, RenderTexture>();

		[HideInInspector]
		[Obsolete("Please use QuerySource instead.")]
		[Tooltip("Where to obtain water shape on CPU for physics / gameplay.")]
		[SerializeField]
		internal CollisionSource _CollisionSource = CollisionSource.GPU;

		internal override string ID => "AnimatedWaves";

		internal override string Name => "Animated Waves";

		internal override Color GizmoColor => s_GizmoColor;

		private protected override bool NeedToReadWriteTextureData => true;

		private protected override Color ClearColor => Color.black;

		internal override int BufferCount
		{
			get
			{
				if (!_Water.WriteMotionVectors)
				{
					return 1;
				}
				return 2;
			}
		}

		private protected override GraphicsFormat RequestedTextureFormat => _TextureFormatMode switch
		{
			LodTextureFormatMode.Performance => GraphicsFormat.R16G16B16A16_SFloat, 
			LodTextureFormatMode.Precision => GraphicsFormat.R32G32B32A32_SFloat, 
			LodTextureFormatMode.Manual => _TextureFormat, 
			_ => throw new NotImplementedException(), 
		};

		internal bool PreserveWaveQuality => WaveSampling switch
		{
			WaveSampling.Automatic => base.Resolution >= 512, 
			WaveSampling.Performance => false, 
			WaveSampling.Precision => true, 
			_ => throw new NotImplementedException(), 
		};

		private protected override WaveHarmonic.Crest.Utility.SortedList<int, ILodInput> Inputs => s_Inputs;

		public float AttenuationInShallows
		{
			get
			{
				return _AttenuationInShallows;
			}
			set
			{
				_AttenuationInShallows = value;
			}
		}

		public CollisionLayers CollisionLayers
		{
			get
			{
				return _CollisionLayers;
			}
			set
			{
				_CollisionLayers = value;
			}
		}

		[Obsolete("Please use QuerySource instead.")]
		public CollisionSource CollisionSource
		{
			get
			{
				return _CollisionSource;
			}
			internal set
			{
				_CollisionSource = value;
			}
		}

		public float ShallowsMaximumDepth
		{
			get
			{
				return _ShallowsMaximumDepth;
			}
			set
			{
				_ShallowsMaximumDepth = value;
			}
		}

		public float WaveResolutionMultiplier
		{
			get
			{
				return GetWaveResolutionMultiplier();
			}
			set
			{
				_WaveResolutionMultiplier = value;
			}
		}

		public WaveSampling WaveSampling
		{
			get
			{
				return _WaveSampling;
			}
			set
			{
				_WaveSampling = value;
			}
		}

		internal AnimatedWavesLod()
		{
			_Enabled = true;
			_OverrideResolution = false;
			_TextureFormat = GraphicsFormat.R16G16B16A16_SFloat;
		}

		internal override void Initialize()
		{
			_CombineShader = ScriptableSingleton<WaterResources>.Instance._ComputeLibrary._ShapeCombineCompute;
			if (_CombineShader._Shader == null)
			{
				_Valid = false;
				return;
			}
			base.Initialize();
			if (base.Persistent && !_Water.IsMultipleViewpointMode)
			{
				_PersistentDataTexture = CreateLodDataTextures();
			}
		}

		internal override void Destroy()
		{
			base.Destroy();
			if (_PersistentDataTexture != null)
			{
				_PersistentDataTexture.Release();
			}
			Helpers.Destroy(_PersistentDataTexture);
			foreach (RenderTexture value in _AdditionalCameraData.Values)
			{
				if (value != null)
				{
					value.Release();
				}
				Helpers.Destroy(value);
			}
			_AdditionalCameraData.Clear();
		}

		internal override void SetGlobals(bool enable)
		{
			base.SetGlobals(enable);
			if (!_Water.IsRunningWithoutGraphics && base.Persistent)
			{
				Shader.SetGlobalTexture(_TextureSourceShaderID, (enable && base.Enabled) ? ((Texture)_PersistentDataTexture) : ((Texture)NullTexture));
			}
		}

		internal override void BuildCommandBuffer(WaterRenderer water, CommandBuffer buffer)
		{
			buffer.BeginSample(ID);
			FlipBuffers(buffer);
			if (base.Persistent)
			{
				RenderTexture dataTexture = base.DataTexture;
				RenderTexture persistentDataTexture = _PersistentDataTexture;
				_PersistentDataTexture = dataTexture;
				RenderTexture renderTexture = (base.DataTexture = persistentDataTexture);
				buffer.SetGlobalTexture(_TextureSourceShaderID, _PersistentDataTexture);
				buffer.SetGlobalTexture(_TextureShaderID, base.DataTexture);
			}
			Shader.SetGlobalFloat(ShaderIDs.s_AttenuationInShallows, _AttenuationInShallows);
			buffer.GetTemporaryRT(ShaderIDs.s_WaveBuffer, base.DataTexture.descriptor);
			CoreUtils.SetRenderTarget(buffer, ShaderIDs.s_WaveBuffer, ClearFlag.Color, ClearColor);
			if (Helpers.RequiresCustomClear && ScriptableSingleton<WaterResources>.Instance.Compute._Clear != null)
			{
				WaterResources.ClearCompute clearCompute = ScriptableSingleton<WaterResources>.Instance._ComputeLibrary._ClearCompute;
				PropertyWrapperCompute wrapper = new PropertyWrapperCompute(buffer, clearCompute._Shader, clearCompute._KernelClearTarget);
				clearCompute.SetVariantForFormat(wrapper, base.DataTexture.graphicsFormat);
				wrapper.SetTexture(WaveHarmonic.Crest.ShaderIDs.s_Target, ShaderIDs.s_WaveBuffer);
				wrapper.SetVector(WaveHarmonic.Crest.ShaderIDs.s_ClearMask, Color.white);
				wrapper.SetVector(WaveHarmonic.Crest.ShaderIDs.s_ClearColor, ClearColor);
				wrapper.Dispatch(base.Resolution / 8, base.Resolution / 8, base.Slices);
			}
			SubmitDraws(buffer, s_Inputs, ShaderIDs.s_WaveBuffer, 0, filter: true);
			int num = base.Slices - 1;
			int num2 = base.Resolution / 8;
			PropertyWrapperCompute target = new PropertyWrapperCompute(buffer, _CombineShader._Shader, PreserveWaveQuality ? _CombineShader._CopyAnimatedWavesKernel : _CombineShader._CombineAnimatedWavesKernel);
			if (_Water._DynamicWavesLod.Enabled)
			{
				_Water._DynamicWavesLod.Bind(target);
			}
			target.SetKeyword(in _CombineShader._CombineKeyword, value: false);
			target.SetKeyword(in _CombineShader._DynamicWavesKeyword, _Water._DynamicWavesLod.Enabled && !PreserveWaveQuality && !_CollisionLayers.HasFlag(CollisionLayers.DynamicWaves));
			target.SetTexture(ShaderIDs.s_WaveBuffer, ShaderIDs.s_WaveBuffer);
			target.SetTexture(WaveHarmonic.Crest.ShaderIDs.s_Target, base.DataTexture);
			if (PreserveWaveQuality)
			{
				target.Dispatch(num2, num2, base.Slices);
			}
			else
			{
				buffer.BeginSample("Combine");
				for (int num3 = num; num3 >= 0; num3--)
				{
					target.SetInteger(Lod.ShaderIDs.s_LodIndex, num3);
					target.Dispatch(num2, num2, 1);
					if (num3 == num)
					{
						target.SetKeyword(in _CombineShader._CombineKeyword, s_Combine);
					}
				}
				buffer.EndSample("Combine");
			}
			buffer.ReleaseTemporaryRT(ShaderIDs.s_WaveBuffer);
			if (SubmitDraws(buffer, s_Inputs, base.DataTexture, 1) && ScriptableSingleton<WaterResources>.Instance.Compute._Clear != null)
			{
				WaterResources.ClearCompute clearCompute2 = ScriptableSingleton<WaterResources>.Instance._ComputeLibrary._ClearCompute;
				PropertyWrapperCompute wrapper2 = new PropertyWrapperCompute(buffer, clearCompute2._Shader, clearCompute2._KernelClearTarget);
				clearCompute2.SetVariantForFormat(wrapper2, base.DataTexture.graphicsFormat);
				wrapper2.SetTexture(WaveHarmonic.Crest.ShaderIDs.s_Target, base.DataTexture);
				wrapper2.SetVector(WaveHarmonic.Crest.ShaderIDs.s_ClearMask, Color.black);
				wrapper2.SetVector(WaveHarmonic.Crest.ShaderIDs.s_ClearColor, Color.clear);
				wrapper2.Dispatch(base.Resolution / 8, base.Resolution / 8, base.Slices);
			}
			ComputeShader packLevel = ScriptableSingleton<WaterResources>.Instance.Compute._PackLevel;
			if (_Water._LevelLod.Enabled && packLevel != null)
			{
				buffer.SetComputeTextureParam(packLevel, 0, WaveHarmonic.Crest.ShaderIDs.s_Target, base.DataTexture);
				buffer.DispatchCompute(packLevel, 0, base.Resolution / 8, base.Resolution / 8, base.Slices);
			}
			if (_CollisionLayers != CollisionLayers.Nothing)
			{
				base.Provider.UpdateQueries(_Water, CollisionLayer.AfterAnimatedWaves);
			}
			if ((_CollisionLayers.HasFlag(CollisionLayers.DynamicWaves) || PreserveWaveQuality) && _Water._DynamicWavesLod.Enabled)
			{
				buffer.BeginSample("Combine");
				buffer.GetTemporaryRT(ShaderIDs.s_DynamicWavesTarget, base.DataTexture.descriptor);
				PropertyWrapperCompute target2 = new PropertyWrapperCompute(buffer, _CombineShader._Shader, _CombineShader._CombineDynamicWavesKernel);
				target2.SetKeyword(in _CombineShader._CombineKeyword, value: false);
				target2.SetTexture(WaveHarmonic.Crest.ShaderIDs.s_Target, ShaderIDs.s_DynamicWavesTarget);
				_Water._DynamicWavesLod.Bind(target2);
				for (int num4 = num; num4 >= 0; num4--)
				{
					target2.SetInteger(Lod.ShaderIDs.s_LodIndex, num4);
					target2.Dispatch(num2, num2, 1);
					if (num4 == num)
					{
						target2.SetKeyword(in _CombineShader._CombineKeyword, s_Combine);
					}
				}
				if (ScriptableSingleton<WaterResources>.Instance.Compute._Blit != null)
				{
					WaterResources.BlitCompute blitCompute = ScriptableSingleton<WaterResources>.Instance._ComputeLibrary._BlitCompute;
					target2 = new PropertyWrapperCompute(buffer, blitCompute._Shader, 0);
					blitCompute.SetVariantForFormat(target2, base.DataTexture.graphicsFormat);
					target2.SetTexture(WaveHarmonic.Crest.ShaderIDs.s_Source, ShaderIDs.s_DynamicWavesTarget);
					target2.SetTexture(WaveHarmonic.Crest.ShaderIDs.s_Target, base.DataTexture);
					target2.Dispatch(num2, num2, base.Slices);
				}
				buffer.ReleaseTemporaryRT(ShaderIDs.s_DynamicWavesTarget);
				buffer.EndSample("Combine");
				if (_CollisionLayers.HasFlag(CollisionLayers.DynamicWaves))
				{
					base.Provider.UpdateQueries(_Water, CollisionLayer.AfterDynamicWaves);
				}
			}
			if (_CollisionLayers.HasFlag(CollisionLayers.Displacement))
			{
				SubmitDraws(buffer, s_Inputs, base.DataTexture, 2);
			}
			if (_CollisionLayers == CollisionLayers.Nothing || _CollisionLayers.HasFlag(CollisionLayers.Displacement))
			{
				base.Queryable?.UpdateQueries(_Water);
			}
			buffer.EndSample(ID);
		}

		internal override void AfterExecute()
		{
			base.Provider.SendReadBack(_Water, _CollisionLayers);
		}

		private protected override ICollisionProvider CreateProvider(bool onEnable)
		{
			ICollisionProvider collisionProvider = ICollisionProvider.None;
			base.Queryable?.CleanUp();
			if (!_Enabled || !onEnable)
			{
				return collisionProvider;
			}
			LodQuerySource lodQuerySource = base.QuerySource;
			if (_Water.Surface.IsQuadMesh)
			{
				lodQuerySource = LodQuerySource.None;
			}
			switch (lodQuerySource)
			{
			case LodQuerySource.GPU:
				if (_Valid)
				{
					ICollisionProvider collisionProvider2;
					if (!_Enabled)
					{
						ICollisionProvider none = ICollisionProvider.None;
						collisionProvider2 = none;
					}
					else
					{
						ICollisionProvider none = new CollisionQueryJundroo(_Water);
						collisionProvider2 = none;
					}
					collisionProvider = collisionProvider2;
				}
				if (_Water.IsRunningWithoutGraphics)
				{
					Debug.LogError("Crest: GPU queries requires a GPU. Please consider CPU queries if running from a server without a GPU.");
				}
				break;
			case LodQuerySource.CPU:
				if (_BakedWaveData != null)
				{
					collisionProvider = _BakedWaveData.CreateCollisionProvider();
				}
				break;
			}
			if (collisionProvider == null)
			{
				collisionProvider = ICollisionProvider.None;
			}
			return collisionProvider;
		}

		internal static float FilterByWavelength(WavelengthFilter filter, float wavelength)
		{
			if (wavelength == 0f)
			{
				return 0f;
			}
			if (wavelength < filter._Minimum)
			{
				return 0f;
			}
			if (wavelength >= filter._TransitionThreshold)
			{
				if (filter._Slice == filter._Slices - 2 && !filter._HighQualityCombine)
				{
					return 1f - filter._ViewerAltitudeLevelAlpha;
				}
				if (filter._Slice == filter._Slices - 1)
				{
					return filter._ViewerAltitudeLevelAlpha;
				}
			}
			else if (wavelength < filter._Maximum)
			{
				return 1f;
			}
			if (!filter._HighQualityCombine)
			{
				return 0f;
			}
			return 1f;
		}

		internal static float FilterByWavelength(WaterRenderer water, int slice, float wavelength, int resolution)
		{
			return FilterByWavelength(new WavelengthFilter(water, slice, resolution), wavelength);
		}

		[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
		private static void OnLoad()
		{
			s_Inputs.Clear();
		}

		internal override void LoadCameraData(Camera camera)
		{
			base.LoadCameraData(camera);
			if (base.Persistent)
			{
				if (!_AdditionalCameraData.ContainsKey(camera))
				{
					_PersistentDataTexture = CreateLodDataTextures();
					Clear(_PersistentDataTexture);
					_AdditionalCameraData.Add(camera, _PersistentDataTexture);
				}
				else
				{
					_PersistentDataTexture = _AdditionalCameraData[camera];
				}
			}
		}

		internal override void StoreCameraData(Camera camera)
		{
			base.StoreCameraData(camera);
			if (base.Persistent)
			{
				_AdditionalCameraData[camera] = _PersistentDataTexture;
			}
		}

		internal override void RemoveCameraData(Camera camera)
		{
			base.RemoveCameraData(camera);
			if (_AdditionalCameraData.ContainsKey(camera))
			{
				RenderTexture renderTexture = _AdditionalCameraData[camera];
				if (renderTexture != null)
				{
					renderTexture.Release();
				}
				Helpers.Destroy(renderTexture);
				_AdditionalCameraData.Remove(camera);
			}
		}

		private float GetWaveResolutionMultiplier()
		{
			if (!PreserveWaveQuality)
			{
				return _WaveResolutionMultiplier;
			}
			return 1f;
		}
	}
}
