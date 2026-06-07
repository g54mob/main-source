using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering;
using UnityEngine.Rendering;
using WaveHarmonic.Crest.Internal;
using WaveHarmonic.Crest.Utility;

namespace WaveHarmonic.Crest
{
	[Serializable]
	public abstract class Lod : Versioned
	{
		internal static class ShaderIDs
		{
			public static readonly int s_LodIndex = Shader.PropertyToID("_Crest_LodIndex");

			public static readonly int s_LodChange = Shader.PropertyToID("_Crest_LodChange");

			public static readonly int s_TemporaryBlurLodTexture = Shader.PropertyToID("_Crest_TemporaryBlurLodTexture");
		}

		[Tooltip("Whether the simulation is enabled.")]
		[SerializeField]
		internal bool _Enabled;

		[Tooltip("Whether to override the resolution.\n\nIf not enabled, then the simulation will use the resolution defined on the Water Renderer.")]
		[SerializeField]
		internal bool _OverrideResolution = true;

		[Tooltip("The resolution of the simulation data.\n\nSet higher for sharper results at the cost of higher memory usage.")]
		[SerializeField]
		internal int _Resolution = 256;

		[Tooltip("Chooses a texture format based on a preset value.")]
		[SerializeField]
		private protected LodTextureFormatMode _TextureFormatMode = LodTextureFormatMode.Performance;

		[Tooltip("The render texture format used for this simulation data.\n\nIt will be overriden if the format is incompatible with the platform.")]
		[SerializeField]
		internal GraphicsFormat _TextureFormat;

		[Tooltip("Blurs the output.\n\nEnable if blurring is desired or intolerable artifacts are present.\nThe blur is optimized to only run on inner LODs and at lower scales.")]
		[SerializeField]
		private protected bool _Blur;

		[Tooltip("Number of blur iterations.\n\nBlur iterations are optimized to only run maximum iterations on the inner LODs.")]
		[SerializeField]
		private protected int _BlurIterations = 1;

		internal const int k_MaximumSlices = 15;

		internal const int k_ThreadGroupSize = 8;

		internal const int k_ThreadGroupSizeX = 8;

		internal const int k_ThreadGroupSizeY = 8;

		internal const string k_BlurField = "_Blur";

		internal const string k_TextureFormatModeField = "_TextureFormatMode";

		private static Texture2DArray s_BlackTextureArray;

		private protected Matrix4x4[] _ViewMatrices = new Matrix4x4[15];

		private protected Cascade[] _Cascades = new Cascade[15];

		private protected BufferedData<Vector4[]> _SamplingParameters;

		private protected bool _Valid;

		internal WaterRenderer _Water;

		private protected bool _TargetsToClear;

		private protected readonly int _TextureShaderID;

		private protected readonly int _TextureSourceShaderID;

		private protected readonly int _SamplingParametersShaderID;

		private protected readonly int _SamplingParametersCascadeShaderID;

		private protected readonly int _SamplingParametersCascadeSourceShaderID;

		private readonly string _TextureName;

		private readonly Dictionary<Camera, BufferedData<Vector4[]>> _AdditionalCameraData = new Dictionary<Camera, BufferedData<Vector4[]>>();

		private bool _ReAllocateTexture;

		internal abstract string ID { get; }

		internal virtual string Name => ID;

		private protected abstract GraphicsFormat RequestedTextureFormat { get; }

		public GraphicsFormat CompatibleTextureFormat { get; private set; }

		private protected abstract Color ClearColor { get; }

		private protected abstract bool NeedToReadWriteTextureData { get; }

		private protected abstract WaveHarmonic.Crest.Utility.SortedList<int, ILodInput> Inputs { get; }

		internal abstract Color GizmoColor { get; }

		internal virtual int BufferCount => 1;

		private protected virtual Texture2DArray NullTexture => BlackTextureArray;

		private protected virtual bool RequiresClearBorder => false;

		private protected IQueryable Queryable { get; set; }

		private static Texture2DArray BlackTextureArray
		{
			get
			{
				if (s_BlackTextureArray == null)
				{
					s_BlackTextureArray = TextureArrayHelpers.CreateTexture2DArray(Texture2D.blackTexture, 15);
					s_BlackTextureArray.name = "_Crest_LodBlackTexture";
				}
				return s_BlackTextureArray;
			}
		}

		private protected bool Persistent => BufferCount > 1;

		internal virtual bool SkipEndOfFrame => false;

		internal RenderTexture DataTexture { get; private protected set; }

		internal Cascade[] Cascades => _Cascades;

		internal int Slices => _Water.LodLevels;

		internal WaterRenderer Water => _Water;

		private protected virtual bool AlwaysClear => false;

		public bool Blur
		{
			get
			{
				return _Blur;
			}
			set
			{
				SetDirty(_Blur, _Blur = value);
			}
		}

		public int BlurIterations
		{
			get
			{
				return _BlurIterations;
			}
			set
			{
				_BlurIterations = value;
			}
		}

		public bool Enabled
		{
			get
			{
				return GetEnabled();
			}
			set
			{
				SetEnabled(_Enabled, _Enabled = value);
			}
		}

		public bool OverrideResolution
		{
			get
			{
				return _OverrideResolution;
			}
			set
			{
				SetDirty(_OverrideResolution, _OverrideResolution = value);
			}
		}

		public int Resolution
		{
			get
			{
				return GetResolution();
			}
			set
			{
				SetDirty(_Resolution, _Resolution = value);
			}
		}

		public GraphicsFormat TextureFormat
		{
			get
			{
				return _TextureFormat;
			}
			set
			{
				SetDirty((Enum)_TextureFormat, (Enum)(_TextureFormat = value));
			}
		}

		public LodTextureFormatMode TextureFormatMode
		{
			get
			{
				return _TextureFormatMode;
			}
			set
			{
				SetDirty((Enum)_TextureFormatMode, (Enum)(_TextureFormatMode = value));
			}
		}

		internal Lod()
		{
			string text = "g_Crest_Cascade" + ID;
			_TextureShaderID = Shader.PropertyToID(text);
			_TextureSourceShaderID = Shader.PropertyToID(text + "Source");
			_SamplingParametersShaderID = Shader.PropertyToID("g_Crest_SamplingParameters" + ID);
			_SamplingParametersCascadeShaderID = Shader.PropertyToID("g_Crest_SamplingParametersCascade" + ID);
			_SamplingParametersCascadeSourceShaderID = Shader.PropertyToID("g_Crest_SamplingParametersCascade" + ID + "Source");
			_TextureName = "_Crest_" + ID + "Lod";
		}

		private protected RenderTexture CreateLodDataTextures(string postfix = null)
		{
			if (postfix == null)
			{
				postfix = string.Empty;
			}
			RenderTexture renderTexture = new RenderTexture(Resolution, Resolution, 0, CompatibleTextureFormat);
			renderTexture.wrapMode = TextureWrapMode.Clamp;
			renderTexture.antiAliasing = 1;
			renderTexture.filterMode = FilterMode.Bilinear;
			renderTexture.anisoLevel = 0;
			renderTexture.useMipMap = false;
			renderTexture.name = _TextureName + postfix;
			renderTexture.dimension = TextureDimension.Tex2DArray;
			renderTexture.volumeDepth = Slices;
			renderTexture.enableRandomWrite = NeedToReadWriteTextureData;
			renderTexture.Create();
			return renderTexture;
		}

		private protected void FlipBuffers(CommandBuffer commands)
		{
			if (_ReAllocateTexture)
			{
				ReAllocate();
			}
			_SamplingParameters.Flip();
			UpdateSamplingParameters(commands);
		}

		private protected void Clear(RenderTexture target)
		{
			Helpers.ClearRenderTexture(target, ClearColor, depth: false);
		}

		internal virtual void BuildCommandBuffer(WaterRenderer water, CommandBuffer buffer)
		{
			FlipBuffers(buffer);
			buffer.BeginSample(ID);
			if (_TargetsToClear || AlwaysClear)
			{
				CoreUtils.SetRenderTarget(buffer, DataTexture, ClearFlag.Color, ClearColor);
				if (Helpers.RequiresCustomClear && ScriptableSingleton<WaterResources>.Instance.Compute._Clear != null)
				{
					WaterResources.ClearCompute clearCompute = ScriptableSingleton<WaterResources>.Instance._ComputeLibrary._ClearCompute;
					PropertyWrapperCompute wrapper = new PropertyWrapperCompute(buffer, clearCompute._Shader, clearCompute._KernelClearTarget);
					clearCompute.SetVariantForFormat(wrapper, CompatibleTextureFormat);
					wrapper.SetTexture(WaveHarmonic.Crest.ShaderIDs.s_Target, DataTexture);
					wrapper.SetVector(WaveHarmonic.Crest.ShaderIDs.s_ClearMask, Color.white);
					wrapper.SetVector(WaveHarmonic.Crest.ShaderIDs.s_ClearColor, ClearColor);
					wrapper.Dispatch(Resolution / 8, Resolution / 8, Slices);
				}
				_TargetsToClear = false;
			}
			if (Inputs.Count > 0)
			{
				SubmitDraws(buffer, Inputs, DataTexture);
				_TargetsToClear = true;
			}
			TryBlur(buffer);
			if (RequiresClearBorder)
			{
				ClearBorder(buffer);
			}
			Queryable?.UpdateQueries(_Water);
			buffer.EndSample(ID);
		}

		private protected bool SubmitDraws(CommandBuffer buffer, WaveHarmonic.Crest.Utility.SortedList<int, ILodInput> draws, RenderTargetIdentifier target, int pass = -1, bool filter = false)
		{
			bool result = false;
			foreach (KeyValuePair<int, ILodInput> draw in draws)
			{
				ILodInput value = draw.Value;
				if (!value.Enabled)
				{
					continue;
				}
				if (pass != -1)
				{
					int pass2 = value.Pass;
					if (pass2 != -1 && pass2 != pass)
					{
						continue;
					}
				}
				Rect rect = value.Rect;
				if (value.IsCompute)
				{
					int num = 0;
					if (rect != Rect.zero)
					{
						num = -1;
						int num2 = Slices - 1;
						while (num2 >= 0 && (!(rect != Rect.zero) || rect.Overlaps(Cascades[num2].TexelRect)))
						{
							num = num2;
							num2--;
						}
						if (num < 0)
						{
							continue;
						}
					}
					value.Draw(this, buffer, target, pass, 1f, Slices - num);
					result = true;
					continue;
				}
				int num3 = Slices - 1;
				while (num3 >= 0 && (!(rect != Rect.zero) || rect.Overlaps(Cascades[num3].TexelRect)))
				{
					float num4 = (filter ? value.Filter(_Water, num3) : 1f);
					if (!(num4 <= 0f))
					{
						CoreUtils.SetRenderTarget(buffer, target, ClearFlag.None, 0, CubemapFace.Unknown, num3);
						buffer.SetGlobalInteger(ShaderIDs.s_LodIndex, num3);
						buffer.SetViewProjectionMatrices(_ViewMatrices[num3], _Water.GetProjectionMatrix(num3));
						value.Draw(this, buffer, target, pass, num4, num3);
						result = true;
					}
					num3--;
				}
			}
			return result;
		}

		internal void SetOrigin(Vector3 newOrigin)
		{
			_SamplingParameters.RunLambda(delegate(Vector4[] data)
			{
				for (int i = 0; i < _Water.LodLevels; i++)
				{
					data[i].x -= newOrigin.x;
					data[i].y -= newOrigin.z;
				}
			});
		}

		private void ClearBorder(CommandBuffer buffer)
		{
			int num = Resolution / 8;
			WaterResources.ClearCompute clearCompute = ScriptableSingleton<WaterResources>.Instance._ComputeLibrary._ClearCompute;
			PropertyWrapperCompute wrapper = new PropertyWrapperCompute(buffer, clearCompute._Shader, clearCompute._KernelClearTargetBoundaryX);
			clearCompute.SetVariantForFormat(wrapper, DataTexture.graphicsFormat);
			wrapper.SetTexture(WaveHarmonic.Crest.ShaderIDs.s_Target, DataTexture);
			wrapper.SetVector(WaveHarmonic.Crest.ShaderIDs.s_ClearColor, ClearColor);
			wrapper.SetInteger(WaveHarmonic.Crest.ShaderIDs.s_Resolution, Resolution);
			wrapper.SetInteger(WaveHarmonic.Crest.ShaderIDs.s_TargetSlice, Slices - 1);
			wrapper.Dispatch(num, 1, 1);
			wrapper = new PropertyWrapperCompute(buffer, clearCompute._Shader, clearCompute._KernelClearTargetBoundaryY);
			wrapper.SetTexture(WaveHarmonic.Crest.ShaderIDs.s_Target, DataTexture);
			wrapper.SetVector(WaveHarmonic.Crest.ShaderIDs.s_ClearColor, ClearColor);
			wrapper.SetInteger(WaveHarmonic.Crest.ShaderIDs.s_Resolution, Resolution);
			wrapper.SetInteger(WaveHarmonic.Crest.ShaderIDs.s_TargetSlice, Slices - 1);
			wrapper.Dispatch(1, num, 1);
		}

		private void UpdateSamplingParameters(CommandBuffer commands, bool initialize = false)
		{
			Vector3 position = _Water.Position;
			int num = (_Enabled ? Resolution : 4);
			Vector4[] current = _SamplingParameters.Current;
			int slices = Slices;
			for (int i = 0; i < slices; i++)
			{
				float num2 = 4f * _Water.CascadeData.Current[i].x / (float)num;
				Vector3 vector = position - new Vector3(Mathf.Repeat(position.x, num2), 0f, Mathf.Repeat(position.z, num2));
				Cascade cascade = new Cascade(vector.XZ(), num2, num);
				_Cascades[i] = cascade;
				current[i] = cascade.Packed;
				if (initialize && BufferCount > 1)
				{
					_SamplingParameters.Previous(1)[i] = cascade.Packed;
				}
				_ViewMatrices[i] = WaterRenderer.CalculateViewMatrixFromSnappedPositionRHS(vector);
			}
			if (!initialize)
			{
				commands.SetGlobalVector(_SamplingParametersShaderID, new Vector4(slices, num, 1f / (float)num, 0f));
				commands.SetGlobalVectorArray(_SamplingParametersCascadeShaderID, current);
				if (BufferCount > 1)
				{
					commands.SetGlobalVectorArray(_SamplingParametersCascadeSourceShaderID, _SamplingParameters.Previous(1));
				}
			}
			else
			{
				Shader.SetGlobalVector(_SamplingParametersShaderID, new Vector4(slices, num, 1f / (float)num, 0f));
				Shader.SetGlobalVectorArray(_SamplingParametersCascadeShaderID, current);
				if (BufferCount > 1)
				{
					Shader.SetGlobalVectorArray(_SamplingParametersCascadeSourceShaderID, _SamplingParameters.Previous(1));
				}
			}
		}

		internal int SuggestIndex(Rect sampleArea)
		{
			for (int i = 0; i < Slices; i++)
			{
				Cascade cascade = _Cascades[i];
				Rect texelRect = cascade.TexelRect;
				float texel = cascade._Texel;
				texelRect.x += texel;
				texelRect.y += texel;
				texelRect.width -= 2f * texel;
				texelRect.height -= 2f * texel;
				if (texelRect.Contains(sampleArea.min) && texelRect.Contains(sampleArea.max))
				{
					return i;
				}
			}
			return -1;
		}

		internal int SuggestIndexForWaves(Rect sampleArea)
		{
			return SuggestIndexForWaves(sampleArea, Mathf.Min(sampleArea.width, sampleArea.height));
		}

		internal int SuggestIndexForWaves(Rect sampleArea, float minimumSpatialLength)
		{
			int slices = Slices;
			for (int i = 0; i < slices; i++)
			{
				Cascade cascade = _Cascades[i];
				Rect texelRect = cascade.TexelRect;
				float texel = cascade._Texel;
				texelRect.x += texel;
				texelRect.y += texel;
				texelRect.width -= 2f * texel;
				texelRect.height -= 2f * texel;
				if (texelRect.Contains(sampleArea.min) && texelRect.Contains(sampleArea.max) && (!(_Water.MaximumWavelength(i, Resolution) / 2f < minimumSpatialLength / 2f) || i >= slices - 1))
				{
					return i;
				}
			}
			return -1;
		}

		private protected void TryBlur(CommandBuffer commands)
		{
			if (_Blur && !(_Water.Scale >= 32f))
			{
				RenderTexture dataTexture = DataTexture;
				WaterResources.BlurCompute blurCompute = ScriptableSingleton<WaterResources>.Instance._ComputeLibrary._BlurCompute;
				PropertyWrapperCompute wrapper = new PropertyWrapperCompute(commands, blurCompute._Shader, blurCompute._KernelHorizontal);
				PropertyWrapperCompute propertyWrapperCompute = new PropertyWrapperCompute(commands, blurCompute._Shader, blurCompute._KernelVertical);
				int s_TemporaryBlurLodTexture = ShaderIDs.s_TemporaryBlurLodTexture;
				commands.GetTemporaryRT(s_TemporaryBlurLodTexture, dataTexture.descriptor);
				blurCompute.SetVariantForFormat(wrapper, dataTexture.graphicsFormat);
				wrapper.SetInteger(WaveHarmonic.Crest.ShaderIDs.s_Resolution, dataTexture.width);
				wrapper.SetTexture(WaveHarmonic.Crest.ShaderIDs.s_Source, dataTexture);
				wrapper.SetTexture(WaveHarmonic.Crest.ShaderIDs.s_Target, s_TemporaryBlurLodTexture);
				propertyWrapperCompute.SetTexture(WaveHarmonic.Crest.ShaderIDs.s_Source, s_TemporaryBlurLodTexture);
				propertyWrapperCompute.SetTexture(WaveHarmonic.Crest.ShaderIDs.s_Target, dataTexture);
				int x = dataTexture.width / 8;
				int y = dataTexture.height / 8;
				int num = Mathf.Min(dataTexture.volumeDepth, 4);
				for (int i = 0; i < _BlurIterations; i++)
				{
					wrapper.Dispatch(x, y, Mathf.Max(num - i, 1));
					propertyWrapperCompute.Dispatch(x, y, Mathf.Max(num - i, 1));
				}
				commands.ReleaseTemporaryRT(s_TemporaryBlurLodTexture);
			}
		}

		internal virtual void Bind<T>(T target) where T : IPropertyWrapper
		{
		}

		internal virtual void Initialize()
		{
			if (_Water.IsRunningWithoutGraphics)
			{
				_Valid = false;
				return;
			}
			CompatibleTextureFormat = Helpers.GetCompatibleTextureFormat(RequestedTextureFormat, Helpers.s_DataGraphicsFormatUsage, Name, NeedToReadWriteTextureData);
			if (CompatibleTextureFormat == GraphicsFormat.None)
			{
				Debug.Log("Crest: Disabling " + Name + " simulation due to no valid available texture format.");
				_Valid = false;
			}
			else
			{
				_Valid = true;
				Allocate();
			}
		}

		internal virtual void SetGlobals(bool enable)
		{
			if (_Water.IsRunningWithoutGraphics)
			{
				return;
			}
			Shader.SetGlobalTexture(_TextureShaderID, (enable && Enabled) ? ((Texture)DataTexture) : ((Texture)NullTexture));
			if (_SamplingParameters == null || _SamplingParameters.Size != BufferCount)
			{
				_SamplingParameters = new BufferedData<Vector4[]>(BufferCount, () => new Vector4[15]);
			}
			_SamplingParameters.RunLambda(delegate(Vector4[] x)
			{
				Array.Fill(x, new Vector4(0f, 0f, 1f, 0f));
			});
			UpdateSamplingParameters(null, initialize: true);
		}

		internal virtual void Enable()
		{
		}

		internal virtual void Disable()
		{
			Queryable?.CleanUp();
		}

		internal virtual void Destroy()
		{
			if (DataTexture != null)
			{
				DataTexture.Release();
			}
			Helpers.Destroy(DataTexture);
			_AdditionalCameraData.Clear();
		}

		internal virtual void AfterExecute()
		{
		}

		private protected virtual void Allocate()
		{
			DataTexture = CreateLodDataTextures();
			Clear(DataTexture);
			Shader.SetGlobalTexture(_TextureShaderID, DataTexture);
			_ReAllocateTexture = false;
		}

		private bool GetEnabled()
		{
			if (_Enabled)
			{
				return _Valid;
			}
			return false;
		}

		private void SetEnabled(bool previous, bool current)
		{
			if (previous != current && !(_Water == null) && _Water.isActiveAndEnabled)
			{
				if (current)
				{
					Initialize();
					Enable();
				}
				else
				{
					Disable();
					Destroy();
				}
				SetGlobals(current);
			}
		}

		private int GetResolution()
		{
			if (!_OverrideResolution && !(Water == null))
			{
				return Water.LodResolution;
			}
			return _Resolution;
		}

		private protected virtual void ReAllocate()
		{
			if (Enabled)
			{
				CompatibleTextureFormat = Helpers.GetCompatibleTextureFormat(RequestedTextureFormat, Helpers.s_DataGraphicsFormatUsage, Name, NeedToReadWriteTextureData);
				RenderTextureDescriptor descriptor = DataTexture.descriptor;
				int height = (descriptor.width = Resolution);
				descriptor.height = height;
				descriptor.graphicsFormat = CompatibleTextureFormat;
				descriptor.enableRandomWrite = NeedToReadWriteTextureData;
				DataTexture.Release();
				DataTexture.descriptor = descriptor;
				DataTexture.Create();
				_ReAllocateTexture = false;
				UpdateSamplingParameters(null, initialize: true);
			}
		}

		internal virtual void LoadCameraData(Camera camera)
		{
			Queryable?.Initialize(_Water);
			if (!Persistent)
			{
				return;
			}
			if (!_AdditionalCameraData.ContainsKey(camera))
			{
				_SamplingParameters = new BufferedData<Vector4[]>(BufferCount, () => new Vector4[15]);
				_AdditionalCameraData.Add(camera, _SamplingParameters);
			}
			else
			{
				_SamplingParameters = _AdditionalCameraData[camera];
			}
		}

		internal virtual void StoreCameraData(Camera camera)
		{
		}

		internal virtual void RemoveCameraData(Camera camera)
		{
			if (_AdditionalCameraData.ContainsKey(camera))
			{
				_AdditionalCameraData.Remove(camera);
			}
		}

		private void SetDirty<I>(I previous, I current) where I : IEquatable<I>
		{
			if (!object.Equals(previous, current))
			{
				_ReAllocateTexture = true;
			}
		}

		private void SetDirty(Enum previous, Enum current)
		{
			if (previous != current)
			{
				_ReAllocateTexture = true;
			}
		}
	}
	[Serializable]
	public abstract class Lod<T> : Lod, IQueryableLod<T> where T : IQueryProvider
	{
		[Tooltip("Where to obtain water data on CPU for physics / gameplay.")]
		[SerializeField]
		private protected LodQuerySource _QuerySource = LodQuerySource.GPU;

		[Tooltip("Maximum number of queries that can be performed when using GPU queries.")]
		[SerializeField]
		private protected int _MaximumQueryCount = 4096;

		public T Provider { get; set; }

		WaterRenderer IQueryableLod<T>.Water => base.Water;

		string IQueryableLod<T>.Name => Name;

		float IQueryableLod<T>.Texel => _Cascades[0]._Texel;

		public int MaximumQueryCount => _MaximumQueryCount;

		public LodQuerySource QuerySource
		{
			get
			{
				return _QuerySource;
			}
			internal set
			{
				_QuerySource = value;
			}
		}

		private protected abstract T CreateProvider(bool onEnable);

		internal override void SetGlobals(bool onEnable)
		{
			base.SetGlobals(onEnable);
			InitializeProvider(onEnable);
		}

		private protected void InitializeProvider(bool onEnable)
		{
			Provider = CreateProvider(onEnable);
			base.Queryable = Provider as IQueryable;
		}

		internal override void AfterExecute()
		{
			base.Queryable?.SendReadBack(_Water);
		}
	}
}
