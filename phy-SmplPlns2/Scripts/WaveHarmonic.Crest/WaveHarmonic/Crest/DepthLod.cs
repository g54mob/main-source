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
	public sealed class DepthLod : Lod<IDepthProvider>
	{
		private sealed class TerrainDepthInput : ILodInput
		{
			private readonly DepthLod _DepthLod;

			private readonly List<Terrain> _Terrains = new List<Terrain>();

			public bool Enabled => _DepthLod._IncludeTerrainHeight;

			public bool IsCompute => true;

			public int Queue => int.MinValue;

			public int Pass => -1;

			public Rect Rect => Rect.zero;

			public MonoBehaviour Component => null;

			public float Filter(WaterRenderer water, int slice)
			{
				return 1f;
			}

			public TerrainDepthInput(DepthLod lod)
			{
				_DepthLod = lod;
			}

			public void Draw(Lod lod, CommandBuffer buffer, RenderTargetIdentifier target, int pass = -1, float weight = 1f, int slices = -1)
			{
				WaterResources instance = ScriptableSingleton<WaterResources>.Instance;
				PropertyWrapperCompute propertyWrapperCompute = new PropertyWrapperCompute(buffer, instance.Compute._DepthTexture, 0);
				int num = lod.Resolution / 8;
				propertyWrapperCompute.SetTexture(WaveHarmonic.Crest.ShaderIDs.s_Target, target);
				propertyWrapperCompute.SetVector(WaveHarmonic.Crest.ShaderIDs.s_TextureRotation, new Vector4(0f, 1f));
				propertyWrapperCompute.SetBoolean(DepthLodInput.ShaderIDs.s_SDF, value: false);
				propertyWrapperCompute.SetKeyword(instance.Keywords.DepthTextureSDF, lod._Water._DepthLod._EnableSignedDistanceFields);
				Terrain.GetActiveTerrains(_Terrains);
				foreach (Terrain terrain in _Terrains)
				{
					TerrainData terrainData = terrain.terrainData;
					if (!(terrainData == null))
					{
						Vector3 size = terrainData.size;
						Vector3 position = terrain.GetPosition();
						propertyWrapperCompute.SetFloat(DepthLodInput.ShaderIDs.s_HeightOffset, position.y);
						propertyWrapperCompute.SetVector(WaveHarmonic.Crest.ShaderIDs.s_Multiplier, new Vector4(size.y * 2f, 1f, 1f, 1f));
						propertyWrapperCompute.SetVector(WaveHarmonic.Crest.ShaderIDs.s_TexturePosition, position.XZ() + size.XZ() * 0.5f);
						propertyWrapperCompute.SetVector(WaveHarmonic.Crest.ShaderIDs.s_TextureSize, size.XZ());
						propertyWrapperCompute.SetTexture(WaveHarmonic.Crest.ShaderIDs.s_Texture, terrainData.heightmapTexture);
						propertyWrapperCompute.Dispatch(num, num, slices);
					}
				}
			}
		}

		[Tooltip("Whether to include the terrain height automatically.\n\nThis will not include terrain details, nor will it produce a signed-distance field. There may also be a slight deviation due to differences in height data and terrain mesh. In these cases, please use the DepthProbe.")]
		[SerializeField]
		internal bool _IncludeTerrainHeight = true;

		[Tooltip("Support signed distance field data generated from the depth probes.\n\nRequires a two component texture format.")]
		[SerializeField]
		internal bool _EnableSignedDistanceFields = true;

		internal const float k_DepthBaseline = float.PositiveInfinity;

		internal static readonly Color s_GizmoColor = new Color(1f, 0f, 0f, 0.5f);

		private static readonly Color s_NullColor = new Color(float.NegativeInfinity, float.PositiveInfinity, 0f, 0f);

		private Texture2DArray _NullTexture;

		internal static readonly WaveHarmonic.Crest.Utility.SortedList<int, ILodInput> s_Inputs = new WaveHarmonic.Crest.Utility.SortedList<int, ILodInput>(Helpers.DuplicateComparison);

		private TerrainDepthInput _TerrainDepthInput;

		private static Color NullColor
		{
			get
			{
				if (!Helpers.IsWebGPU)
				{
					return s_NullColor;
				}
				return new Color(float.MinValue, float.MaxValue, 0f, 0f);
			}
		}

		internal override string ID => "Depth";

		internal override string Name => "Water Depth";

		internal override Color GizmoColor => s_GizmoColor;

		private protected override Color ClearColor => NullColor;

		private protected override bool NeedToReadWriteTextureData => true;

		private protected override GraphicsFormat RequestedTextureFormat
		{
			get
			{
				switch (_TextureFormatMode)
				{
				case LodTextureFormatMode.Performance:
				case LodTextureFormatMode.Automatic:
					return _EnableSignedDistanceFields ? GraphicsFormat.R16G16_SFloat : GraphicsFormat.R16_SFloat;
				case LodTextureFormatMode.Precision:
					return _EnableSignedDistanceFields ? GraphicsFormat.R32G32_SFloat : GraphicsFormat.R32_SFloat;
				case LodTextureFormatMode.Manual:
					return _TextureFormat;
				default:
					throw new NotImplementedException();
				}
			}
		}

		private protected override Texture2DArray NullTexture
		{
			get
			{
				if (_NullTexture == null)
				{
					Texture2D texture2D = TextureArrayHelpers.CreateTexture2D(NullColor, UnityEngine.TextureFormat.RFloat);
					texture2D.name = "_Crest_" + ID + "LodTemporaryDefaultTexture";
					_NullTexture = TextureArrayHelpers.CreateTexture2DArray(texture2D, 15);
					_NullTexture.name = "_Crest_" + ID + "LodDefaultTexture";
					Helpers.Destroy(texture2D);
				}
				return _NullTexture;
			}
		}

		private protected override WaveHarmonic.Crest.Utility.SortedList<int, ILodInput> Inputs => s_Inputs;

		public bool EnableSignedDistanceFields
		{
			get
			{
				return _EnableSignedDistanceFields;
			}
			set
			{
				SetEnableSignedDistanceFields(_EnableSignedDistanceFields, _EnableSignedDistanceFields = value);
			}
		}

		public bool IncludeTerrainHeight
		{
			get
			{
				return _IncludeTerrainHeight;
			}
			set
			{
				_IncludeTerrainHeight = value;
			}
		}

		internal DepthLod()
		{
			_Enabled = true;
			_TextureFormat = GraphicsFormat.R16G16_SFloat;
			_MaximumQueryCount = 512;
		}

		private protected override IDepthProvider CreateProvider(bool onEnable)
		{
			base.Queryable?.CleanUp();
			if (!onEnable || !base.Enabled || base.QuerySource != LodQuerySource.GPU)
			{
				return IDepthProvider.None;
			}
			return IDepthProvider.Create(_Water);
		}

		[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
		private static void OnLoad()
		{
			s_Inputs.Clear();
		}

		private void SetEnableSignedDistanceFields(bool previous, bool current)
		{
			if (previous != current && !(_Water == null) && _Water.isActiveAndEnabled && base.Enabled)
			{
				ReAllocate();
			}
		}

		internal override void Enable()
		{
			base.Enable();
			if (base.Enabled)
			{
				if (_TerrainDepthInput == null)
				{
					_TerrainDepthInput = new TerrainDepthInput(this);
				}
				Inputs.Add(_TerrainDepthInput.Queue, _TerrainDepthInput);
			}
		}

		internal override void Disable()
		{
			base.Disable();
			Inputs.Remove(_TerrainDepthInput);
		}
	}
}
