using UnityEngine;

namespace GPUInstancerPro.TerrainModule
{
	public static class GPUITerrainConstants
	{
		public const string FILE_DEFAULT_DETAIL_TEXTURE_PROFILE = "GPUIDefaultDetailTextureProfile";

		public const string FILE_DEFAULT_DETAIL_PREFAB_PROFILE = "GPUIDefaultDetailPrefabProfile";

		public const string FILE_DEFAULT_TREE_PROFILE = "GPUIDefaultTreeProfile";

		public const string FILE_DEFAULT_DETAIL_MESH = "DefaultDetailMesh";

		public const string FILE_DEFAULT_DETAIL_MATERIAL = "DefaultDetailMaterial";

		public const string FILE_DEFAULT_DETAIL_MATERIAL_DESC = "DefaultDetailMaterialDesc";

		public const string NAME_SUFFIX_DETAILTEXTURE = "_GPUIDetailLayer_";

		private static string _packagesPath;

		public static readonly string SHADER_DEFAULT_DETAIL_Builtin = "GPUInstancerPro/Foliage";

		public static readonly string SHADER_DEFAULT_DETAIL_Lambert_Builtin = "GPUInstancerPro/FoliageLambert";

		public static readonly string SHADER_DEFAULT_DETAIL_URP = "GPUInstancerPro/Foliage_SG";

		public static readonly string SHADER_DEFAULT_DETAIL_HDRP = "GPUInstancerPro/Foliage_SG";

		private static GPUIProfile _defaultDetailTextureProfile;

		private static GPUIProfile _defaultDetailPrefabProfile;

		private static GPUIProfile _defaultTreeProfile;

		private static Mesh _defaultDetailMesh;

		private static Material _defaultDetailMaterial;

		private static GPUIDetailMaterialDescription _defaultDetailMaterialDescription;

		private static Texture2D _defaultHealthyDryNoiseTexture;

		private static Texture2D _defaultNoiseNormal;

		public static readonly string FILE_CS_TerrainDetailCapture = "GPUITerrainDetailCaptureCS";

		private static ComputeShader _CS_TerrainDetailCapture;

		public static readonly string FILE_CS_TerrainDetailCaptureFromInstanceTransforms = "GPUITerrainDetailCaptureFromInstanceTransformsCS";

		private static ComputeShader _CS_TerrainDetailCaptureFromInstanceTransforms;

		public static readonly string FILE_CS_VegetationGenerator = "GPUIVegetationGeneratorCS";

		private static ComputeShader _CS_VegetationGenerator;

		public static readonly string Kw_GPUI_DETAIL_DENSITY_REDUCE = "GPUI_DETAIL_DENSITY_REDUCE";

		public static readonly string Kw_GPUI_TERRAIN_HOLES = "GPUI_TERRAIN_HOLES";

		public static readonly string Kw_GPUI_TWO_CHANNEL_HEIGHTMAP = "GPUI_TWO_CHANNEL_HEIGHTMAP";

		public static readonly string FILE_CS_TerrainTreeGenerator = "GPUITerrainTreeGeneratorCS";

		private static ComputeShader _CS_TerrainTreeGenerator;

		public static readonly string Kw_GPUI_TREE_INSTANCE_COLOR = "GPUI_TREE_INSTANCE_COLOR";

		public static readonly string FILE_CS_TerrainDetailDensityModifier = "GPUITerrainDetailDensityModifierCS";

		private static ComputeShader _CS_TerrainDetailDensityModifier;

		public static readonly int PROP_terrainDetailTexture = Shader.PropertyToID("terrainDetailTexture");

		public static readonly int PROP_detailCounterBuffer = Shader.PropertyToID("detailCounterBuffer");

		public static readonly int PROP_terrainHoleTexture = Shader.PropertyToID("terrainHoleTexture");

		public static readonly int PROP_detailLayerBuffer = Shader.PropertyToID("detailLayerBuffer");

		public static readonly int PROP_detailResolution = Shader.PropertyToID("detailResolution");

		public static readonly int PROP_heightmapTexture = Shader.PropertyToID("heightmapTexture");

		public static readonly int PROP_terrainHeightmapResolution = Shader.PropertyToID("terrainHeightmapResolution");

		public static readonly int PROP_terrainPosition = Shader.PropertyToID("terrainPosition");

		public static readonly int PROP_terrainSize = Shader.PropertyToID("terrainSize");

		public static readonly int PROP_alphaMapTexture = Shader.PropertyToID("alphaMapTexture");

		public static readonly int PROP_alphamapResolution = Shader.PropertyToID("alphamapResolution");

		public static readonly int PROP_detailTextureSize = Shader.PropertyToID("detailTextureSize");

		public static readonly int PROP_heightmapTextureSize = Shader.PropertyToID("heightmapTextureSize");

		public static readonly int PROP_startPosition = Shader.PropertyToID("startPosition");

		public static readonly int PROP_cameraPos = Shader.PropertyToID("cameraPos");

		public static readonly int PROP_density = Shader.PropertyToID("density");

		public static readonly int PROP_detailObjectDistance = Shader.PropertyToID("detailObjectDistance");

		public static readonly int PROP_healthyDryNoiseTexture = Shader.PropertyToID("healthyDryNoiseTexture");

		public static readonly int PROP_gpuiTreeInstanceDataBuffer = Shader.PropertyToID("gpuiTreeInstanceDataBuffer");

		public static readonly int PROP_terrainPrototypeIndex = Shader.PropertyToID("terrainPrototypeIndex");

		public static readonly int PROP_treeData = Shader.PropertyToID("treeData");

		public static readonly int PROP_prefabScale = Shader.PropertyToID("prefabScale");

		public static readonly int PROP_applyPrefabScale = Shader.PropertyToID("applyPrefabScale");

		public static readonly int PROP_applyRotation = Shader.PropertyToID("applyRotation");

		public static readonly int PROP_applyHeight = Shader.PropertyToID("applyHeight");

		public static GPUIProfile DefaultDetailTextureProfile
		{
			get
			{
				if (_defaultDetailTextureProfile == null)
				{
					_defaultDetailTextureProfile = ScriptableObject.CreateInstance<GPUIProfile>();
					_defaultDetailTextureProfile.isShadowCasting = false;
					_defaultDetailTextureProfile.isDistanceCulling = false;
					_defaultDetailTextureProfile.isDefaultProfile = true;
				}
				return _defaultDetailTextureProfile;
			}
		}

		public static GPUIProfile DefaultDetailPrefabProfile
		{
			get
			{
				if (_defaultDetailPrefabProfile == null)
				{
					_defaultDetailPrefabProfile = ScriptableObject.CreateInstance<GPUIProfile>();
					_defaultDetailPrefabProfile.isShadowCasting = true;
					_defaultDetailPrefabProfile.isShadowFrustumCulling = true;
					_defaultDetailPrefabProfile.isShadowOcclusionCulling = true;
					_defaultDetailPrefabProfile.isDistanceCulling = false;
					_defaultDetailPrefabProfile.isDefaultProfile = true;
				}
				return _defaultDetailPrefabProfile;
			}
		}

		public static GPUIProfile DefaultTreeProfile
		{
			get
			{
				if (_defaultTreeProfile == null)
				{
					_defaultTreeProfile = ScriptableObject.CreateInstance<GPUIProfile>();
					_defaultTreeProfile.isShadowCasting = true;
					_defaultTreeProfile.isLODCrossFade = true;
					_defaultTreeProfile.isDistanceCulling = false;
					_defaultTreeProfile.isDefaultProfile = true;
				}
				return _defaultTreeProfile;
			}
		}

		public static Mesh DefaultDetailMesh
		{
			get
			{
				if (_defaultDetailMesh == null)
				{
					_defaultDetailMesh = GPUITerrainUtility.CreateCrossQuadsMesh("DefaultDetailMesh", 1);
				}
				return _defaultDetailMesh;
			}
			set
			{
				if (value != null)
				{
					_defaultDetailMesh = value;
				}
			}
		}

		public static Material DefaultDetailMaterial
		{
			get
			{
				if (_defaultDetailMaterial == null)
				{
					Shader defaultDetailShader = GetDefaultDetailShader();
					if (defaultDetailShader == null)
					{
						return new Material(GetDefaultDetailShaderFallback());
					}
					_defaultDetailMaterial = new Material(defaultDetailShader);
					if (DefaultHealthyDryNoiseTexture != null)
					{
						_defaultDetailMaterial.SetTexture("_HealthyDryNoiseTexture", DefaultHealthyDryNoiseTexture);
					}
					if (DefaultNoiseNormal != null)
					{
						_defaultDetailMaterial.SetTexture("_WindWaveNormalTexture", DefaultNoiseNormal);
					}
					_defaultDetailMaterial.SetFloat("_WindWavesOn", 1f);
					if (QualitySettings.billboardsFaceCameraPosition)
					{
						_defaultDetailMaterial.EnableKeyword("BILLBOARD_FACE_CAMERA_POS");
					}
					else
					{
						_defaultDetailMaterial.DisableKeyword("BILLBOARD_FACE_CAMERA_POS");
					}
				}
				return _defaultDetailMaterial;
			}
		}

		public static GPUIDetailMaterialDescription DefaultDetailMaterialDescription
		{
			get
			{
				if (_defaultDetailMaterialDescription == null)
				{
					_defaultDetailMaterialDescription = ScriptableObject.CreateInstance<GPUIDetailMaterialDescription>();
					_defaultDetailMaterialDescription.SetDefaultValues();
				}
				return _defaultDetailMaterialDescription;
			}
		}

		public static Texture2D DefaultHealthyDryNoiseTexture => _defaultHealthyDryNoiseTexture;

		public static Texture2D DefaultNoiseNormal => _defaultNoiseNormal;

		public static ComputeShader CS_TerrainDetailCapture
		{
			get
			{
				if (_CS_TerrainDetailCapture == null)
				{
					_CS_TerrainDetailCapture = GPUIUtility.LoadResource<ComputeShader>(FILE_CS_TerrainDetailCapture);
				}
				return _CS_TerrainDetailCapture;
			}
		}

		public static ComputeShader CS_TerrainDetailCaptureFromInstanceTransforms
		{
			get
			{
				if (_CS_TerrainDetailCaptureFromInstanceTransforms == null)
				{
					_CS_TerrainDetailCaptureFromInstanceTransforms = GPUIUtility.LoadResource<ComputeShader>(FILE_CS_TerrainDetailCaptureFromInstanceTransforms);
				}
				return _CS_TerrainDetailCaptureFromInstanceTransforms;
			}
		}

		public static ComputeShader CS_VegetationGenerator
		{
			get
			{
				if (_CS_VegetationGenerator == null)
				{
					_CS_VegetationGenerator = GPUIUtility.LoadResource<ComputeShader>(FILE_CS_VegetationGenerator);
				}
				return _CS_VegetationGenerator;
			}
		}

		public static ComputeShader CS_TerrainTreeGenerator
		{
			get
			{
				if (_CS_TerrainTreeGenerator == null)
				{
					_CS_TerrainTreeGenerator = GPUIUtility.LoadResource<ComputeShader>(FILE_CS_TerrainTreeGenerator);
				}
				return _CS_TerrainTreeGenerator;
			}
		}

		public static ComputeShader CS_TerrainDetailDensityModifier
		{
			get
			{
				if (_CS_TerrainDetailDensityModifier == null)
				{
					_CS_TerrainDetailDensityModifier = GPUIUtility.LoadResource<ComputeShader>(FILE_CS_TerrainDetailDensityModifier);
				}
				return _CS_TerrainDetailDensityModifier;
			}
		}

		public static RenderTextureFormat R8_RenderTextureFormat
		{
			get
			{
				if (!GPUIRuntimeSettings.Instance.API_HAS_GUARANTEED_R8_SUPPORT)
				{
					return RenderTextureFormat.RFloat;
				}
				return RenderTextureFormat.R8;
			}
		}

		public static RenderTextureFormat R16_RenderTextureFormat
		{
			get
			{
				if (!GPUIRuntimeSettings.Instance.API_HAS_GUARANTEED_R8_SUPPORT)
				{
					return RenderTextureFormat.RFloat;
				}
				return RenderTextureFormat.R16;
			}
		}

		public static string GetPackagesPath()
		{
			if (string.IsNullOrEmpty(_packagesPath))
			{
				_packagesPath = "Packages/com.gurbu.gpui-pro.terrain/";
			}
			return _packagesPath;
		}

		public static Shader GetDefaultDetailShader()
		{
			return GPUIRuntimeSettings.Instance.RenderPipeline switch
			{
				GPUIRenderPipeline.URP => GPUIUtility.FindShader(SHADER_DEFAULT_DETAIL_URP), 
				GPUIRenderPipeline.HDRP => GPUIUtility.FindShader(SHADER_DEFAULT_DETAIL_HDRP), 
				_ => GPUIUtility.FindShader(SHADER_DEFAULT_DETAIL_Builtin), 
			};
		}

		public static Shader GetDefaultDetailShaderFallback()
		{
			return GPUIRuntimeSettings.Instance.RenderPipeline switch
			{
				GPUIRenderPipeline.URP => GPUIUtility.FindShader("Universal Render Pipeline/Lit"), 
				GPUIRenderPipeline.HDRP => GPUIUtility.FindShader("HDRP/Lit"), 
				_ => GPUIUtility.FindShader("Standard"), 
			};
		}

		public static bool IsDefaultDetailShader(Shader shader)
		{
			if (shader != null)
			{
				return shader.name.StartsWith(SHADER_DEFAULT_DETAIL_Builtin);
			}
			return false;
		}
	}
}
