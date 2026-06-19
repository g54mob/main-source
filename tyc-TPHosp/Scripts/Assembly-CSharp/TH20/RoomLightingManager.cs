using System;
using System.Collections.Generic;
using UnityConsole;
using UnityEngine;
using UnityEngine.Profiling;
using UnityEngine.Rendering;

namespace TH20
{
	[DontSave]
	public class RoomLightingManager : MustCallDestroy
	{
		public enum RoomLightType
		{
			Default = 0,
			Overhead = 1,
			Underneath = 2
		}

		private enum Effect
		{
			None = 0,
			AttributeMap = 1,
			Desaturate = 2
		}

		private struct RoomLight
		{
			public Matrix4x4 LocalToWorldMatrix;

			public Bounds Bounds;

			public Material Material;

			public Cubemap ReflectionCubemap;

			public bool AllowDataView;

			public RoomLight(Matrix4x4 localToWorldMatrix, Bounds bounds, Material material, Cubemap reflectionCubemap, bool allowDataView)
			{
				LocalToWorldMatrix = localToWorldMatrix;
				Bounds = bounds;
				Material = material;
				ReflectionCubemap = reflectionCubemap;
				AllowDataView = allowDataView;
			}
		}

		private static class WallDirection
		{
			public static class Mask
			{
				public const int EastWest = 10;

				public const int NorthSouth = 5;

				public const int NorthEast = 3;

				public const int NorthWest = 9;

				public const int SouthEast = 6;

				public const int SouthWest = 12;
			}

			public const int North = 1;

			public const int East = 2;

			public const int South = 4;

			public const int West = 8;

			public const int NorthEastReflexCorner = 16;

			public const int SouthEastReflexCorner = 32;

			public const int SouthWestReflexCorner = 64;

			public const int NorthWestReflexCorner = 128;
		}

		private struct CombinedClippableLight
		{
			public int MinX;

			public int MinY;

			public int MaxX;

			public int MaxY;
		}

		private struct CombinedRoomLight
		{
			public int MinX;

			public int MinY;

			public int MaxX;

			public int MaxY;

			public int Walls;

			public CombinedRoomLight(int minX, int minY, int maxX, int maxY, int walls)
			{
				MinX = minX;
				MinY = minY;
				MaxX = maxX;
				MaxY = maxY;
				Walls = walls;
			}
		}

		private struct GenerateCombinedLightsConstParams
		{
			public Vector3 GlobalLightOffset;

			public float RoomLightHeight;

			public float RoomLightBaseBias;

			public bool UseFalloff;

			public RoomLightType LightType;

			public float UnderneathLightHeight;

			public float OverheadLightHeight;

			public List<CombinedRoomLight> Pass1;

			public List<CombinedRoomLight> Pass2;

			public List<RoomLight> CachedVolumeLights;

			public List<RoomLightInstancingData> CachedMaterialInstancingData;

			public List<MaterialPropertyBlock> CachedMaterialPropertyBlocks;

			public Effect Effect;

			public HospitalMapParams HospitalMapParams;

			public bool DataViewEffects;

			public int FalloffDistanceID;

			public bool UseGPUInstancing;
		}

		private class HospitalMapParams
		{
			public Texture2D Texture;

			public Texture2D Gradient;

			public Vector4 Dimension;

			public Vector3 DataRange;

			public float DataOpacity;
		}

		private struct ClippableLightCachedData
		{
			public Vector3 WorldPosition;

			public Quaternion Rotation;

			public List<Matrix4x4> Cells;
		}

		private struct RoomLightInstancingData
		{
			public Vector4 FalloffDistance;

			public Vector4 CornerToggle;

			public Vector4 DirectionalLightColorIntensity;

			public Vector4 AmbientLightColorIntensity;

			public Vector4 CeilingLightParams;

			public Vector4 CeilingLightParams1;

			public Vector4 LightParams0;
		}

		private struct CachedInstancingParams
		{
			public Matrix4x4[] Matrices;

			public Vector4[] FalloffDistances;

			public Vector4[] CornerToggle;

			public Vector4[] DirectionalLightColorIntensity;

			public Vector4[] AmbientColorIntensity;

			public Vector4[] CeilingLightParams;

			public Vector4[] CeilingLightParams1;

			public Vector4[] LightParams0;
		}

		private struct CachedClippableInstancingParams
		{
			public Matrix4x4[] Matrices;

			public Matrix4x4[] WorldToLight;

			public Vector4[] Color;

			public Vector4[] PostionAtten;
		}

		private class FloorplanCubeMapComparer : IComparer<FloorPlan>
		{
			private RoomLightingManager _roomLightingManager;

			public FloorplanCubeMapComparer(RoomLightingManager roomLightingManager)
			{
				_roomLightingManager = roomLightingManager;
			}

			public int Compare(FloorPlan a, FloorPlan b)
			{
				int instanceID = _roomLightingManager.GetRoomLightCubeMap(a).GetInstanceID();
				int instanceID2 = _roomLightingManager.GetRoomLightCubeMap(b).GetInstanceID();
				return instanceID.CompareTo(instanceID2);
			}
		}

		public static bool DEBUG_DisableShadowCulling;

		private const int Pass1InitialCapacity = 64;

		private const int Pass2InitialCapacity = 32;

		private const int CachedRoomLightsnitialCapacity = 256;

		private const string DeferredLightingCommandBufferName = "Deferred Room Lighting";

		private const string CopyShadowMaskCommandBufferName = "Copy Shadow Mask (Room Lighting)";

		private const string DebugRelfectionSpheresName = "Debug Reflection Spheres";

		private const string DefaultLayerName = "Default";

		private const string OutdoorLayerName = "Outdoor";

		private const string MetagameLayerName = "Metagame";

		private const string DataMapShaderKeywordString = "DATAMAP";

		private const string DataDesaturateShaderKeywordString = "DATA_DESATURATE";

		private const RenderTextureFormat ShadowMaskCopyFormat = RenderTextureFormat.R8;

		private float _roomLightBaseBias = -0.01f;

		private int _outOfBoundsLightDistance;

		[DontSave]
		private RoomLightingManagerConfig _config;

		[DontSave]
		private Material _defaultRoomLightMaterial;

		[DontSave]
		private Cubemap _defaultRoomLightCubemap;

		[DontSave]
		private Material _defaultRoomClosedLightMaterial;

		[DontSave]
		private Cubemap _defaultRoomClosedLightCubemap;

		[DontSave]
		private Material _outdoorRoomLightMaterial;

		[DontSave]
		private Cubemap _outdoorRoomLightCubemap;

		[DontSave]
		private Material _reflectionTestMaterial;

		[DontSave]
		private GameObject _debugReflectionSpheresGameObject;

		[DontSave]
		private GameObject _debugExteriorReflectionSpheresGameObject;

		[DontSave]
		private Material _clippablePointLightMaterial;

		[DontSave]
		private Material _clippableSpotLightMaterial;

		[DontSave]
		private Dictionary<Camera, CommandBuffer> _cameraLightCommandBuffers;

		[DontSave]
		private Dictionary<Camera, CommandBuffer> _clearShadowMaskCommandBuffers;

		[DontSave]
		private Dictionary<Camera, RenderTexture> _interiorShadowMaskTextures;

		[DontSave]
		private Dictionary<Camera, RenderTexture> _exteriorShadowMaskTextures;

		[DontSave]
		private Dictionary<Light, CommandBuffer> _shadowMaskCommandBuffers;

		[DontSave]
		private List<CombinedClippableLight> _combinedClippableLightsCached = new List<CombinedClippableLight>();

		[DontSave]
		private Mesh _unitCubeMesh;

		private bool _useGPUInstancing;

		private BuildEvents _buildEvents;

		private Level _level;

		private float _roomLightHeight;

		private bool _updateCharaterLayers;

		private bool _useLightFalloff;

		private bool _useUnderneathLight;

		[DontSave]
		private List<FloorPlan> _builtRooms = new List<FloorPlan>();

		[DontSave]
		private Light _interiorLight;

		[DontSave]
		private Light _exteriorLight;

		[DontSave]
		private Vector3 _roomLightDirection;

		[DontSave]
		private Vector3 _exteriorLightDirection;

		[DontSave]
		private Transform _shadowCastingVolumeParent;

		[DontSave]
		private List<CombinedRoomLight> _pass1 = new List<CombinedRoomLight>(64);

		[DontSave]
		private List<CombinedRoomLight> _pass2 = new List<CombinedRoomLight>(32);

		[DontSave]
		private List<RoomLight> _cachedInteriorVolumeLights = new List<RoomLight>(256);

		[DontSave]
		private List<Transform> _cachedShadowCastingVolumes = new List<Transform>(256);

		[DontSave]
		private List<MaterialPropertyBlock> _cachedInteriorPropertyBlocks = new List<MaterialPropertyBlock>(256);

		[DontSave]
		private List<RoomLightInstancingData> _cachedInteriorInstancingData = new List<RoomLightInstancingData>(256);

		[DontSave]
		private List<RoomLight> _cachedExteriorVolumeLights = new List<RoomLight>(256);

		[DontSave]
		private List<MaterialPropertyBlock> _cachedExteriorPropertyBlock = new List<MaterialPropertyBlock>(256);

		[DontSave]
		private List<RoomLightInstancingData> _cachedExteriorInstancingData = new List<RoomLightInstancingData>(256);

		private List<Character> _characters = new List<Character>();

		[DontSave]
		private List<ClippableLight> _clippableSpotLights = new List<ClippableLight>(128);

		[DontSave]
		private List<ClippableLight> _clippablePointLights = new List<ClippableLight>(128);

		[DontSave]
		private List<ClippableLightCachedData> _clippableSpotLightsCachedData = new List<ClippableLightCachedData>(128);

		[DontSave]
		private List<ClippableLightCachedData> _clippablePointLightsCachedData = new List<ClippableLightCachedData>(128);

		[DontSave]
		private List<ClippableLight> _cachedClippableList = new List<ClippableLight>(8);

		[DontSave]
		private Camera[] _cachedAllCameras = new Camera[32];

		[DontSave]
		private Plane[] _cameraFrustumPlanesCached;

		[DontSave]
		private MaterialPropertyBlock _instancePropsCached;

		[DontSave]
		private Texture2D _defaultSpotLightCookie;

		[DontSave]
		private int _colorShaderID;

		[DontSave]
		private int _lightPosShaderID;

		[DontSave]
		private int _volumeShadowMaskShaderID;

		[DontSave]
		private int _roomLightCubemapTextureShaderID;

		[DontSave]
		private int _directionalLightDirectionID;

		[DontSave]
		private int _falloffDistanceID;

		[DontSave]
		private int _lightTexture0ShaderID;

		[DontSave]
		private int _unityWorldToLightShaderID;

		[DontSave]
		private int _exteriorVolumeShadowMaskID;

		[DontSave]
		private int _cornerToggleID;

		[DontSave]
		private int _directionalLightColorIntensityID;

		[DontSave]
		private int _ambientLightColorIntensityID;

		[DontSave]
		private int _ceilingLightParamsID;

		[DontSave]
		private int _ceilingLightParams1ID;

		[DontSave]
		private int _lightParams0ID;

		[DontSave]
		private int _metagameLayerMask;

		[DontSave]
		private CustomSampler _drawLightInstancedSampler;

		[DontSave]
		private CustomSampler _drawLightInstancedDrawSampler;

		[DontSave]
		private CustomSampler _drawLightInstancedCopySampler;

		[DontSave]
		private CustomSampler _clippableLightSampler;

		[DontSave]
		private CustomSampler _clippableLightRebuildCacheSampler;

		[DontSave]
		private CustomSampler _clippableLightDrawMeshSampler;

		[DontSave]
		private CustomSampler _clippableLightDrawMeshInstancedSampler;

		[DontSave]
		private CustomSampler _clippableAppendClippableDataSampler;

		[DontSave]
		private CachedInstancingParams _cachedInstancingParams;

		[DontSave]
		private CachedClippableInstancingParams _cachedClippableInstancingParams;

		[DontSave]
		private RoomLightingDebug _debug;

		private Effect _effect;

		[DontSave]
		private HospitalMapParams _hospitalMapParams;

		public RoomLightingManager(RoomLightingManagerConfig config, BuildEvents buildEvents, Level level)
		{
			_level = level;
			_buildEvents = buildEvents;
			_config = config;
			_colorShaderID = Shader.PropertyToID("_Color");
			_lightPosShaderID = Shader.PropertyToID("_ClippableLightPos");
			_volumeShadowMaskShaderID = Shader.PropertyToID("_VolumeShadowMask");
			_roomLightCubemapTextureShaderID = Shader.PropertyToID("_RoomLightCubemapTexture");
			_directionalLightDirectionID = Shader.PropertyToID("_DirectionalLightDirection");
			_lightTexture0ShaderID = Shader.PropertyToID("_LightTexture0");
			_falloffDistanceID = Shader.PropertyToID("_FalloffDistance");
			_exteriorVolumeShadowMaskID = Shader.PropertyToID("_ExteriorVolumeShadowMask");
			_cornerToggleID = Shader.PropertyToID("_CornerToggle");
			_unityWorldToLightShaderID = Shader.PropertyToID("_ClippableWorldToLight");
			_directionalLightColorIntensityID = Shader.PropertyToID("_DirectionalLightColorIntensity");
			_ambientLightColorIntensityID = Shader.PropertyToID("_AmbientLightColorIntensity");
			_ceilingLightParamsID = Shader.PropertyToID("_CeilingLightParams");
			_ceilingLightParams1ID = Shader.PropertyToID("_CeilingLightParams1");
			_lightParams0ID = Shader.PropertyToID("_LightParams0");
			_metagameLayerMask = LayerMask.GetMask("Metagame");
			_defaultSpotLightCookie = config.DefaultSpotLightCookie;
			_drawLightInstancedSampler = CustomSampler.Create("RoomLightingManager.DrawLightsInstanced");
			_drawLightInstancedDrawSampler = CustomSampler.Create("RoomLightingManager.DrawLightsInstanced.Draw");
			_drawLightInstancedCopySampler = CustomSampler.Create("RoomLightingManager.DrawLightsInstanced.Copy");
			_clippableLightSampler = CustomSampler.Create("RoomLightingManager.ClippableLights");
			_clippableLightRebuildCacheSampler = CustomSampler.Create("RoomLightingManager.ClippableLights.Rebuild");
			_clippableLightDrawMeshSampler = CustomSampler.Create("RoomLightingManager.DrawClippableLight");
			_clippableLightDrawMeshInstancedSampler = CustomSampler.Create("RoomLightingManager.DrawClippableLightInstanced");
			_clippableAppendClippableDataSampler = CustomSampler.Create("RoomLightingManager.AppendClippableData");
			_useGPUInstancing = SystemInfo.supportsInstancing;
			if (level.App.IsOSXYosemti())
			{
				_useGPUInstancing = false;
			}
			_instancePropsCached = new MaterialPropertyBlock();
			_cameraFrustumPlanesCached = new Plane[6];
			_cachedInstancingParams = new CachedInstancingParams
			{
				Matrices = new Matrix4x4[512],
				FalloffDistances = new Vector4[512],
				CornerToggle = new Vector4[512],
				DirectionalLightColorIntensity = new Vector4[512],
				AmbientColorIntensity = new Vector4[512],
				CeilingLightParams = new Vector4[512],
				CeilingLightParams1 = new Vector4[512],
				LightParams0 = new Vector4[512]
			};
			_cachedClippableInstancingParams = new CachedClippableInstancingParams
			{
				Matrices = new Matrix4x4[512],
				WorldToLight = new Matrix4x4[512],
				Color = new Vector4[512],
				PostionAtten = new Vector4[512]
			};
			if (config.UseDeferredRoomLighting)
			{
				Camera.onPreRender = (Camera.CameraCallback)Delegate.Combine(Camera.onPreRender, new Camera.CameraCallback(OnPreRender));
				BuildEvents buildEvents2 = _buildEvents;
				buildEvents2.OnRoomItemAdded = (Action<RoomItem, FloorPlan>)Delegate.Combine(buildEvents2.OnRoomItemAdded, new Action<RoomItem, FloorPlan>(OnRoomItemAdded));
				BuildEvents buildEvents3 = _buildEvents;
				buildEvents3.OnRoomItemVisualCreated = (Action<RoomItemVisual>)Delegate.Combine(buildEvents3.OnRoomItemVisualCreated, new Action<RoomItemVisual>(OnRoomItemVisualCreated));
				BuildEvents buildEvents4 = _buildEvents;
				buildEvents4.OnRoomItemVisualDestroyed = (Action<RoomItemVisual>)Delegate.Combine(buildEvents4.OnRoomItemVisualDestroyed, new Action<RoomItemVisual>(OnRoomItemVisualDestroyed));
				BuildEvents buildEvents5 = _buildEvents;
				buildEvents5.OnRoomDeleted = (Action<Room>)Delegate.Combine(buildEvents5.OnRoomDeleted, new Action<Room>(OnRoomDeleted));
				BuildEvents buildEvents6 = _buildEvents;
				buildEvents6.OnRoomVisibilityChanged = (Action<Room, bool>)Delegate.Combine(buildEvents6.OnRoomVisibilityChanged, new Action<Room, bool>(OnRoomVisibilityChanged));
				BuildEvents buildEvents7 = _buildEvents;
				buildEvents7.OnRoomOpened = (Action<Room>)Delegate.Combine(buildEvents7.OnRoomOpened, new Action<Room>(OnRoomOpened));
				BuildEvents buildEvents8 = _buildEvents;
				buildEvents8.OnRoomClosed = (Action<Room>)Delegate.Combine(buildEvents8.OnRoomClosed, new Action<Room>(OnRoomClosed));
				BuildEvents buildEvents9 = _buildEvents;
				buildEvents9.OnRoomLightingChanged = (Action<Room>)Delegate.Combine(buildEvents9.OnRoomLightingChanged, new Action<Room>(OnRoomLightingChanged));
				_cameraLightCommandBuffers = new Dictionary<Camera, CommandBuffer>();
				_clearShadowMaskCommandBuffers = new Dictionary<Camera, CommandBuffer>();
				_shadowMaskCommandBuffers = new Dictionary<Light, CommandBuffer>();
				_interiorShadowMaskTextures = new Dictionary<Camera, RenderTexture>();
				_exteriorShadowMaskTextures = new Dictionary<Camera, RenderTexture>();
				_unitCubeMesh = MeshUtils.CreateCubeMesh(Vector3.one);
				_interiorLight = CreateInteriorLight();
				_exteriorLight = CreateExteriorLight();
				ReloadConfig();
				if (config.ShowDebugReflectionSpheres)
				{
					_debugReflectionSpheresGameObject = new GameObject("Debug Reflection Spheres");
					_debugExteriorReflectionSpheresGameObject = new GameObject("Debug Reflection Spheres");
				}
			}
			else if (config.IndoorLightingPrefab != null)
			{
				UnityEngine.Object.Instantiate(config.IndoorLightingPrefab);
			}
			ConsoleCommandsDatabase.RegisterCommand("SetVolumeLightInstancing", "Enables or Disables Volume Instancing", "SetHUDEnabled [true|false]", Debug_SetVolumeLightInstancing);
			ConsoleCommandsDatabase.RegisterCommand("EnableRoomLightingDebug", "Enables or Disables Room Lighting Debug Features", "EnableRoomLightingDebug [true|false]", Debug_EnableRoomLightingDebug);
			ConsoleCommandsDatabase.RegisterCommand("ToggleExteriorLightVolumes", "Toggle Exterior Light Volumes in RoomLightingDebug", "ToggleExteriorLightVolumes", Debug_ToggleExteriorLightVolumes);
			ConsoleCommandsDatabase.RegisterCommand("ToggleInteriorLightVolumes", "Toggle Exterior Light Volumes in RoomLightingDebug", "ToggleExteriorLightVolumes", Debug_ToggleInteriorLightVolumes);
		}

		private ConsoleCommandResult Debug_ToggleExteriorLightVolumes(string[] args)
		{
			if (_debug == null)
			{
				return ConsoleCommandResult.Failed("Not in RoomLightingDebug mode, call EnableRoomLightingDebug in the console to enable!");
			}
			_debug.BoundsToRender.Clear();
			foreach (RoomLight cachedExteriorVolumeLight in _cachedExteriorVolumeLights)
			{
				_debug.BoundsToRender.Add(cachedExteriorVolumeLight.Bounds);
			}
			return ConsoleCommandResult.Succeeded();
		}

		private ConsoleCommandResult Debug_ToggleInteriorLightVolumes(string[] args)
		{
			if (_debug == null)
			{
				return ConsoleCommandResult.Failed("Not in RoomLightingDebug mode, call EnableRoomLightingDebug in the console to enable!");
			}
			_debug.BoundsToRender.Clear();
			foreach (RoomLight cachedInteriorVolumeLight in _cachedInteriorVolumeLights)
			{
				_debug.BoundsToRender.Add(cachedInteriorVolumeLight.Bounds);
			}
			return ConsoleCommandResult.Succeeded();
		}

		private ConsoleCommandResult Debug_SetVolumeLightInstancing(params string[] args)
		{
			return ConsoleCommandHelpers.ExtractBool(delegate(bool enabled)
			{
				_useGPUInstancing = enabled;
				RegenerateInteriorVolumeLights();
				RegenerateExteriorVolumeLights(_level.WorldState.ExteriorState.Values, _level.WorldState.Anchor.ToWorldPosition());
			}, args);
		}

		private ConsoleCommandResult Debug_EnableRoomLightingDebug(params string[] args)
		{
			return ConsoleCommandHelpers.ExtractBool(delegate(bool enabled)
			{
				if (enabled)
				{
					if (_debug == null)
					{
						GameObject gameObject = new GameObject("RoomLightingDebug");
						_debug = gameObject.AddComponent<RoomLightingDebug>();
					}
				}
				else if (_debug != null)
				{
					UnityEngine.Object.Destroy(_debug.gameObject);
				}
			}, args);
		}

		public void ReloadConfig()
		{
			if (_config == null)
			{
				return;
			}
			if (_defaultRoomLightMaterial != null)
			{
				UnityEngine.Object.Destroy(_defaultRoomLightMaterial);
			}
			if (_defaultRoomClosedLightMaterial != null)
			{
				UnityEngine.Object.Destroy(_defaultRoomClosedLightMaterial);
			}
			if (_outdoorRoomLightMaterial != null)
			{
				UnityEngine.Object.Destroy(_outdoorRoomLightMaterial);
			}
			Material source = _config.OutdoorRoomLightMaterial;
			Cubemap outdoorRoomLightCubemap = _config.OutdoorRoomLightCubemap;
			LevelLightingConfig levelLightingConfig = _level.Config.GetLevelLightingConfig();
			if (levelLightingConfig != null)
			{
				if (levelLightingConfig.OutdoorLightMaterialOverride != null)
				{
					source = levelLightingConfig.OutdoorLightMaterialOverride;
				}
				if (levelLightingConfig.OutdoorCubemapOverride != null)
				{
					outdoorRoomLightCubemap = levelLightingConfig.OutdoorCubemapOverride;
				}
				_useUnderneathLight = levelLightingConfig.UseUnderneathLight;
			}
			_defaultRoomLightMaterial = new Material(_config.DefaultRoomLightMaterial);
			_defaultRoomClosedLightMaterial = new Material(_config.DefaultRoomClosedLightMaterial);
			_outdoorRoomLightMaterial = new Material(source);
			_clippablePointLightMaterial = _config.ClippablePointLightMaterial;
			_clippableSpotLightMaterial = _config.ClippableSpotLightMaterial;
			_defaultRoomLightCubemap = _config.DefaultRoomLightCubemap;
			_defaultRoomClosedLightCubemap = _config.DefaultRoomClosedLightCubemap;
			_outdoorRoomLightCubemap = outdoorRoomLightCubemap;
			_roomLightHeight = _config.RoomLightHeight;
			_reflectionTestMaterial = _config.ReflectionTestMaterial;
			_updateCharaterLayers = _config.UpdateCharaterLayers;
			_useLightFalloff = _config.UseLightFalloff;
			ReloadLightConfig();
		}

		private void ReloadLightConfig()
		{
			_roomLightBaseBias = _config.RoomLightBaseBias;
			_outOfBoundsLightDistance = _config.OutOfBoundsLightDistance;
			_roomLightDirection = Quaternion.Euler(_config.InteriorLightRotation) * Vector3.forward;
			_exteriorLightDirection = Quaternion.Euler(_config.ExteriorLightRotation) * Vector3.forward;
			if (_interiorLight != null)
			{
				_interiorLight.transform.rotation = Quaternion.Euler(_config.InteriorShadowRotation);
				_interiorLight.shadowStrength = _config.InteriorShadowStrength;
			}
			if (_exteriorLight != null)
			{
				_exteriorLight.transform.rotation = Quaternion.Euler(_config.ExteriorLightRotation);
				_exteriorLight.shadowStrength = _config.ExteriorShadowStrength;
				_exteriorLight.shadowNormalBias = _config.ExteriorShadowNormalBias;
				_exteriorLight.shadowBias = _config.ExteriorShadowBias;
			}
			LevelLightingConfig levelLightingConfig = _level.Config.GetLevelLightingConfig();
			if (levelLightingConfig != null)
			{
				if (levelLightingConfig.RoomLightBaseBias.UseOverride)
				{
					_roomLightBaseBias = levelLightingConfig.RoomLightBaseBias.Value;
				}
				if (levelLightingConfig.OutOfBoundsLightDistance.UseOverride)
				{
					_outOfBoundsLightDistance = levelLightingConfig.OutOfBoundsLightDistance.Value;
				}
				if (levelLightingConfig.RoomLightHeight.UseOverride)
				{
					_roomLightHeight = levelLightingConfig.RoomLightHeight.Value;
				}
			}
		}

		public void Update()
		{
			int num = LayerMask.NameToLayer("Default");
			int num2 = LayerMask.NameToLayer("Outdoor");
			foreach (Character character in _characters)
			{
				if (!character.Visual.RetroModeEnabled)
				{
					int layer = num2;
					if (!_level.WorldState.IsExterior(character.Position))
					{
						layer = num;
					}
					character.Visual.SetLayer(layer);
				}
			}
			if (_interiorLight == null)
			{
				_interiorLight = CreateInteriorLight();
				ReloadLightConfig();
			}
			if (_exteriorLight == null)
			{
				_exteriorLight = CreateExteriorLight();
				ReloadLightConfig();
			}
			float y = _level.CameraLogic.CameraComponent.transform.position.y;
			float a;
			float b;
			switch (_level.LocalPreferences.Video.ShadowFadeDistance)
			{
			case LocalPreferences.VideoPreferences.ShadowFadeDistanceMode.Near:
				a = _config.NearShadowFade.FadeInDistance;
				b = _config.NearShadowFade.FadeOutDistance;
				break;
			case LocalPreferences.VideoPreferences.ShadowFadeDistanceMode.Medium:
				a = _config.MediumShadowFade.FadeInDistance;
				b = _config.MediumShadowFade.FadeOutDistance;
				break;
			case LocalPreferences.VideoPreferences.ShadowFadeDistanceMode.Far:
				a = _config.FarShadowFade.FadeInDistance;
				b = _config.FarShadowFade.FadeOutDistance;
				break;
			default:
				a = 200f;
				b = 200f;
				break;
			}
			if (y > _config.FarShadowFade.FadeOutDistance)
			{
				if (_interiorLight.enabled)
				{
					_interiorLight.enabled = false;
				}
			}
			else
			{
				_interiorLight.shadowStrength = 1f - Mathf.InverseLerp(a, b, y);
				if (DEBUG_DisableShadowCulling)
				{
					_interiorLight.shadowStrength = 1f;
				}
				if (!_interiorLight.enabled)
				{
					_interiorLight.enabled = true;
				}
			}
			if (_cachedAllCameras.Length < Camera.allCamerasCount)
			{
				_cachedAllCameras = new Camera[Camera.allCamerasCount];
			}
			int allCameras = Camera.GetAllCameras(_cachedAllCameras);
			for (int i = 0; i < allCameras; i++)
			{
				if (CanCameraReceiveLighting(_cachedAllCameras[i], _level.MetagameMap.CameraLogic, _metagameLayerMask))
				{
					ClearThenCopyShadowMask(_cachedAllCameras[i], _interiorLight, _interiorShadowMaskTextures);
					ClearThenCopyShadowMask(_cachedAllCameras[i], _exteriorLight, _exteriorShadowMaskTextures);
					break;
				}
			}
		}

		public void RengerateAfterLoad(List<Room> rooms, bool[,] exteriorState, Vector3 lightOffset)
		{
			_colorShaderID = Shader.PropertyToID("_Color");
			_lightPosShaderID = Shader.PropertyToID("_ClippableLightPos");
			foreach (Room room in rooms)
			{
				FloorPlan floorPlan = room.FloorPlan;
				if (!floorPlan.HospitalMap.Plot.Built)
				{
					continue;
				}
				_builtRooms.Add(floorPlan);
				foreach (RoomItem item in floorPlan.Items)
				{
					if (item.Visual.RequiresRoomLightUpdates)
					{
						ApplyLightingToRoomItem(floorPlan, item);
					}
				}
			}
			RegenerateInteriorVolumeLights();
			RegenerateExteriorVolumeLights(exteriorState, lightOffset);
			foreach (Room room2 in rooms)
			{
				if (!room2.IsOpen)
				{
					OnRoomClosed(room2);
				}
			}
		}

		public void RegisterClippableLight(ClippableLight clippableLight)
		{
			if (!(clippableLight == null))
			{
				switch (clippableLight.Type)
				{
				case ClippableLight.LightType.Point:
					_clippablePointLights.Add(clippableLight);
					_clippablePointLightsCachedData.Add(new ClippableLightCachedData
					{
						WorldPosition = new Vector3(float.NaN, float.NaN, float.NaN),
						Cells = new List<Matrix4x4>()
					});
					break;
				case ClippableLight.LightType.Spot:
					_clippableSpotLights.Add(clippableLight);
					_clippableSpotLightsCachedData.Add(new ClippableLightCachedData
					{
						WorldPosition = new Vector3(float.NaN, float.NaN, float.NaN),
						Cells = new List<Matrix4x4>()
					});
					break;
				}
			}
		}

		public void UnregisterClippableLight(ClippableLight clippableLight)
		{
			if (!(clippableLight == null))
			{
				switch (clippableLight.Type)
				{
				case ClippableLight.LightType.Point:
				{
					int index2 = _clippablePointLights.IndexOf(clippableLight);
					_clippablePointLights.RemoveAt(index2);
					_clippablePointLightsCachedData.RemoveAt(index2);
					break;
				}
				case ClippableLight.LightType.Spot:
				{
					int index = _clippableSpotLights.IndexOf(clippableLight);
					_clippableSpotLights.RemoveAt(index);
					_clippableSpotLightsCachedData.RemoveAt(index);
					break;
				}
				}
			}
		}

		public void RegisterCharacter(Character character)
		{
			if (_updateCharaterLayers)
			{
				_characters.Add(character);
			}
			_cachedClippableList.Clear();
			character.GameObject.GetComponentsInChildren(_cachedClippableList);
			foreach (ClippableLight cachedClippable in _cachedClippableList)
			{
				RegisterClippableLight(cachedClippable);
			}
			_cachedClippableList.Clear();
		}

		public void UnregisterCharacter(Character character)
		{
			if (_updateCharaterLayers)
			{
				_characters.Remove(character);
			}
			_cachedClippableList.Clear();
			if (character.GameObject != null)
			{
				character.GameObject.GetComponentsInChildren(_cachedClippableList);
			}
			foreach (ClippableLight cachedClippable in _cachedClippableList)
			{
				UnregisterClippableLight(cachedClippable);
			}
			_cachedClippableList.Clear();
		}

		private Light CreateInteriorLight()
		{
			Light light = new GameObject("Interior Light (For Shadow Casting)").AddComponent<Light>();
			light.color = new Color(0f, 0f, 0f, 1f);
			light.type = LightType.Directional;
			light.shadows = LightShadows.Soft;
			light.cullingMask = ~LayerMask.GetMask("Outdoor") & ~LayerMask.GetMask("Metagame");
			light.shadowNormalBias = 0f;
			return light;
		}

		private Light CreateExteriorLight()
		{
			Light light = new GameObject("Exterior Light (For Shadow Casting)").AddComponent<Light>();
			light.color = new Color(0f, 0f, 0f, 1f);
			light.type = LightType.Directional;
			light.shadows = LightShadows.Soft;
			light.cullingMask = ~LayerMask.GetMask("Default") & ~LayerMask.GetMask("Metagame");
			return light;
		}

		private void OnRoomVisibilityChanged(Room room, bool visible)
		{
			if (visible)
			{
				BuildRoom(room);
			}
			else
			{
				OnRoomDeleted(room);
			}
		}

		private void OnRoomDeleted(Room room)
		{
			if (room != null)
			{
				_builtRooms.Remove(room.FloorPlan);
			}
			RegenerateInteriorVolumeLights();
		}

		public void BuildRoom(Room newRoom)
		{
			if (newRoom == null)
			{
				return;
			}
			_builtRooms.Remove(newRoom.FloorPlan);
			FloorPlan floorPlan = newRoom.FloorPlan;
			if (floorPlan.HospitalMap.Plot.Built && !_builtRooms.Contains(newRoom.FloorPlan))
			{
				_builtRooms.Add(floorPlan);
				foreach (RoomItem item in floorPlan.Items)
				{
					if (item.Visual.RequiresRoomLightUpdates)
					{
						ApplyLightingToRoomItem(floorPlan, item);
					}
				}
				RegenerateInteriorVolumeLights();
			}
			if (!newRoom.IsOpen)
			{
				OnRoomClosed(newRoom);
			}
		}

		private void OnRoomItemAdded(RoomItem roomItem, FloorPlan floorPlan)
		{
			if (floorPlan.Definition.IsHospitalOrBay && roomItem.Visual.RequiresRoomLightUpdates)
			{
				ApplyLightingToRoomItem(floorPlan, roomItem);
			}
		}

		private void OnRoomItemVisualCreated(RoomItemVisual roomItemVisual)
		{
			_cachedClippableList.Clear();
			roomItemVisual.GameObject.GetComponentsInChildren(includeInactive: true, _cachedClippableList);
			foreach (ClippableLight cachedClippable in _cachedClippableList)
			{
				RegisterClippableLight(cachedClippable);
			}
			_cachedClippableList.Clear();
		}

		private void OnRoomItemVisualDestroyed(RoomItemVisual roomItemVisual)
		{
			_cachedClippableList.Clear();
			if (roomItemVisual.GameObject != null)
			{
				roomItemVisual.GameObject.GetComponentsInChildren(_cachedClippableList);
				foreach (ClippableLight cachedClippable in _cachedClippableList)
				{
					UnregisterClippableLight(cachedClippable);
				}
			}
			_cachedClippableList.Clear();
		}

		private void OnRoomOpened(Room room)
		{
			RegenerateInteriorVolumeLights();
		}

		private void OnRoomClosed(Room room)
		{
			RegenerateInteriorVolumeLights();
		}

		private void OnRoomLightingChanged(Room room)
		{
			RegenerateInteriorVolumeLights();
		}

		private void ApplyLightingToRoomItem(FloorPlan floorPlan, RoomItem item)
		{
			Material roomLightMaterial = GetRoomLightMaterial(floorPlan);
			item.Visual.UpdateRoomLighting(roomLightMaterial.GetColor("_AmbientLightColor"), roomLightMaterial.GetFloat("_AmbientLightIntensity"), roomLightMaterial.GetColor("_DirectionalLightColor"), roomLightMaterial.GetFloat("_DirectionalLightIntensity"), _roomLightDirection, _defaultRoomLightCubemap);
		}

		public override void Destroy()
		{
			Camera.onPreRender = (Camera.CameraCallback)Delegate.Remove(Camera.onPreRender, new Camera.CameraCallback(OnPreRender));
			ConsoleCommandsDatabase.UnRegisterCommand("ToggleExteriorLightVolumes");
			ConsoleCommandsDatabase.UnRegisterCommand("ToggleInteriorLightVolumes");
			ConsoleCommandsDatabase.UnRegisterCommand("SetVolumeLightInstancing");
			ConsoleCommandsDatabase.UnRegisterCommand("EnableRoomLightingDebug");
			BuildEvents buildEvents = _buildEvents;
			buildEvents.OnRoomItemAdded = (Action<RoomItem, FloorPlan>)Delegate.Remove(buildEvents.OnRoomItemAdded, new Action<RoomItem, FloorPlan>(OnRoomItemAdded));
			BuildEvents buildEvents2 = _buildEvents;
			buildEvents2.OnRoomItemVisualCreated = (Action<RoomItemVisual>)Delegate.Remove(buildEvents2.OnRoomItemVisualCreated, new Action<RoomItemVisual>(OnRoomItemVisualCreated));
			BuildEvents buildEvents3 = _buildEvents;
			buildEvents3.OnRoomItemVisualDestroyed = (Action<RoomItemVisual>)Delegate.Remove(buildEvents3.OnRoomItemVisualDestroyed, new Action<RoomItemVisual>(OnRoomItemVisualDestroyed));
			BuildEvents buildEvents4 = _buildEvents;
			buildEvents4.OnRoomDeleted = (Action<Room>)Delegate.Remove(buildEvents4.OnRoomDeleted, new Action<Room>(OnRoomDeleted));
			BuildEvents buildEvents5 = _buildEvents;
			buildEvents5.OnRoomVisibilityChanged = (Action<Room, bool>)Delegate.Remove(buildEvents5.OnRoomVisibilityChanged, new Action<Room, bool>(OnRoomVisibilityChanged));
			BuildEvents buildEvents6 = _buildEvents;
			buildEvents6.OnRoomOpened = (Action<Room>)Delegate.Remove(buildEvents6.OnRoomOpened, new Action<Room>(OnRoomOpened));
			BuildEvents buildEvents7 = _buildEvents;
			buildEvents7.OnRoomClosed = (Action<Room>)Delegate.Remove(buildEvents7.OnRoomClosed, new Action<Room>(OnRoomClosed));
			BuildEvents buildEvents8 = _buildEvents;
			buildEvents8.OnRoomLightingChanged = (Action<Room>)Delegate.Remove(buildEvents8.OnRoomLightingChanged, new Action<Room>(OnRoomLightingChanged));
			if (_defaultRoomLightMaterial != null)
			{
				UnityEngine.Object.Destroy(_defaultRoomLightMaterial);
			}
			if (_defaultRoomClosedLightMaterial != null)
			{
				UnityEngine.Object.Destroy(_defaultRoomClosedLightMaterial);
			}
			if (_outdoorRoomLightMaterial != null)
			{
				UnityEngine.Object.Destroy(_outdoorRoomLightMaterial);
			}
			if (_cameraLightCommandBuffers != null)
			{
				foreach (KeyValuePair<Camera, CommandBuffer> cameraLightCommandBuffer in _cameraLightCommandBuffers)
				{
					if ((bool)cameraLightCommandBuffer.Key)
					{
						cameraLightCommandBuffer.Key.RemoveCommandBuffer(CameraEvent.AfterLighting, cameraLightCommandBuffer.Value);
					}
				}
			}
			if (_cameraLightCommandBuffers != null)
			{
				foreach (KeyValuePair<Camera, CommandBuffer> cameraLightCommandBuffer2 in _cameraLightCommandBuffers)
				{
					if ((bool)cameraLightCommandBuffer2.Key)
					{
						cameraLightCommandBuffer2.Key.RemoveCommandBuffer(CameraEvent.AfterLighting, cameraLightCommandBuffer2.Value);
					}
				}
			}
			if (_cameraLightCommandBuffers != null)
			{
				foreach (KeyValuePair<Camera, CommandBuffer> cameraLightCommandBuffer3 in _cameraLightCommandBuffers)
				{
					if ((bool)cameraLightCommandBuffer3.Key)
					{
						cameraLightCommandBuffer3.Key.RemoveCommandBuffer(CameraEvent.AfterLighting, cameraLightCommandBuffer3.Value);
					}
				}
			}
			if (_clearShadowMaskCommandBuffers != null)
			{
				foreach (KeyValuePair<Camera, CommandBuffer> clearShadowMaskCommandBuffer in _clearShadowMaskCommandBuffers)
				{
					if ((bool)clearShadowMaskCommandBuffer.Key)
					{
						clearShadowMaskCommandBuffer.Key.RemoveCommandBuffer(CameraEvent.BeforeLighting, clearShadowMaskCommandBuffer.Value);
					}
				}
			}
			_clearShadowMaskCommandBuffers = new Dictionary<Camera, CommandBuffer>();
			if (_interiorLight != null)
			{
				UnityEngine.Object.Destroy(_interiorLight.gameObject);
			}
			if (_exteriorLight != null)
			{
				UnityEngine.Object.Destroy(_exteriorLight.gameObject);
			}
			if (_interiorShadowMaskTextures != null)
			{
				foreach (RenderTexture value in _interiorShadowMaskTextures.Values)
				{
					if (value != null)
					{
						value.Release();
					}
				}
			}
			if (_exteriorShadowMaskTextures != null)
			{
				foreach (RenderTexture value2 in _exteriorShadowMaskTextures.Values)
				{
					if (value2 != null)
					{
						value2.Release();
					}
				}
			}
			if (_debug != null)
			{
				UnityEngine.Object.Destroy(_debug.gameObject);
			}
			base.Destroy();
		}

		public void RegenerateExteriorVolumeLights(bool[,] exteriorState, Vector3 lightOffset)
		{
			_cachedExteriorVolumeLights.Clear();
			_cachedExteriorPropertyBlock.Clear();
			_cachedExteriorInstancingData.Clear();
			GenerateCombinedLightsConstParams parameters = new GenerateCombinedLightsConstParams
			{
				GlobalLightOffset = _config.RoomLightOffset,
				LightType = RoomLightType.Default,
				UnderneathLightHeight = _config.UnderneathLightHeight,
				OverheadLightHeight = _config.OverheadLightHeight,
				RoomLightHeight = _roomLightHeight,
				RoomLightBaseBias = _roomLightBaseBias,
				UseFalloff = _useLightFalloff,
				Pass1 = _pass1,
				Pass2 = _pass2,
				CachedVolumeLights = _cachedExteriorVolumeLights,
				CachedMaterialPropertyBlocks = _cachedExteriorPropertyBlock,
				CachedMaterialInstancingData = _cachedExteriorInstancingData,
				Effect = _effect,
				HospitalMapParams = _hospitalMapParams,
				DataViewEffects = false,
				FalloffDistanceID = _falloffDistanceID,
				UseGPUInstancing = _useGPUInstancing
			};
			GenerateCombinedLights(ref parameters, exteriorState, lightOffset, _outdoorRoomLightMaterial, _outdoorRoomLightCubemap, allowDataView: false);
			if (_debugExteriorReflectionSpheresGameObject != null)
			{
				UnityEngine.Object.Destroy(_debugExteriorReflectionSpheresGameObject);
				_debugExteriorReflectionSpheresGameObject = new GameObject("Debug Reflection Spheres");
				foreach (RoomLight cachedExteriorVolumeLight in _cachedExteriorVolumeLights)
				{
					GameObject gameObject = GameObject.CreatePrimitive(PrimitiveType.Sphere);
					gameObject.transform.parent = _debugExteriorReflectionSpheresGameObject.transform;
					Bounds bounds = cachedExteriorVolumeLight.Bounds;
					Vector3 center = bounds.center;
					center.y = 1f;
					gameObject.transform.position = center;
					gameObject.GetComponent<MeshRenderer>().sharedMaterial = _reflectionTestMaterial;
				}
			}
			int length = exteriorState.GetLength(0);
			int length2 = exteriorState.GetLength(1);
			int outOfBoundsLightDistance = _outOfBoundsLightDistance;
			parameters.LightType = RoomLightType.Default;
			AddRoomLight(new CombinedRoomLight(-outOfBoundsLightDistance, length2, length - 1 + outOfBoundsLightDistance, length2 + outOfBoundsLightDistance, 0), lightOffset, 0f, _outdoorRoomLightMaterial, _outdoorRoomLightCubemap, allowDataView: false, ref parameters);
			AddRoomLight(new CombinedRoomLight(length, 0, length2 + outOfBoundsLightDistance, length2 - 1, 0), lightOffset, 0f, _outdoorRoomLightMaterial, _outdoorRoomLightCubemap, allowDataView: false, ref parameters);
			AddRoomLight(new CombinedRoomLight(-outOfBoundsLightDistance, -outOfBoundsLightDistance, length - 1 + outOfBoundsLightDistance, -1, 0), lightOffset, 0f, _outdoorRoomLightMaterial, _outdoorRoomLightCubemap, allowDataView: false, ref parameters);
			AddRoomLight(new CombinedRoomLight(-outOfBoundsLightDistance, 0, -1, length2 - 1, 0), lightOffset, 0f, _outdoorRoomLightMaterial, _outdoorRoomLightCubemap, allowDataView: false, ref parameters);
			parameters.LightType = RoomLightType.Overhead;
			AddRoomLight(new CombinedRoomLight(-outOfBoundsLightDistance, -outOfBoundsLightDistance, length2 + outOfBoundsLightDistance, length2 + outOfBoundsLightDistance, 0), lightOffset, 0f, _outdoorRoomLightMaterial, _outdoorRoomLightCubemap, allowDataView: false, ref parameters);
			parameters.LightType = RoomLightType.Underneath;
			AddRoomLight(new CombinedRoomLight(-outOfBoundsLightDistance, -outOfBoundsLightDistance, length2 + outOfBoundsLightDistance, length2 + outOfBoundsLightDistance, 0), lightOffset, 0f, _outdoorRoomLightMaterial, _outdoorRoomLightCubemap, allowDataView: false, ref parameters);
		}

		public void RegenerateInteriorVolumeLights()
		{
			_cachedInteriorVolumeLights.Clear();
			_cachedInteriorPropertyBlocks.Clear();
			_cachedInteriorInstancingData.Clear();
			GenerateCombinedLightsConstParams parameters = new GenerateCombinedLightsConstParams
			{
				GlobalLightOffset = _config.RoomLightOffset,
				LightType = RoomLightType.Default,
				RoomLightHeight = _roomLightHeight,
				RoomLightBaseBias = _roomLightBaseBias,
				UseFalloff = _useLightFalloff,
				Pass1 = _pass1,
				Pass2 = _pass2,
				CachedVolumeLights = _cachedInteriorVolumeLights,
				CachedMaterialPropertyBlocks = _cachedInteriorPropertyBlocks,
				CachedMaterialInstancingData = _cachedInteriorInstancingData,
				Effect = _effect,
				HospitalMapParams = _hospitalMapParams,
				DataViewEffects = true,
				FalloffDistanceID = _falloffDistanceID,
				UseGPUInstancing = _useGPUInstancing
			};
			FloorplanCubeMapComparer comparer = new FloorplanCubeMapComparer(this);
			bool flag = _level.DataViewManager != null && _level.DataViewManager.CurrentMode != DataViewManager.Mode.None;
			_builtRooms.Sort(comparer);
			bool flag2 = false;
			for (int i = 0; i < _builtRooms.Count; i++)
			{
				FloorPlan floorPlan = _builtRooms[i];
				bool allowDataView = floorPlan.HospitalMap.Plot.Built && !floorPlan.HospitalMap.Room.Definition.IsNoDataRoom;
				bool flag3 = floorPlan.HasNoVisibleExteriorWalls();
				bool flag4 = floorPlan.Definition.IsLowWallRoom() && floorPlan.HospitalMap.FloorPlan.HasNoVisibleExteriorWalls();
				if (flag || (!flag3 && !flag4))
				{
					if (floorPlan.HospitalMap.FloorPlan.HasNoVisibleExteriorWalls())
					{
						flag2 = true;
					}
					Vector3 roomLightOffset = floorPlan.Anchor.ToWorldPosition();
					if (floorPlan?.HospitalMap?.Room?.Definition == null || !floorPlan.HospitalMap.Room.Definition.NoArributeData)
					{
						GenerateCombinedLights(ref parameters, floorPlan.Tiles, roomLightOffset, GetRoomLightMaterial(floorPlan), GetRoomLightCubeMap(floorPlan), allowDataView);
					}
				}
			}
			if (_effect != Effect.None)
			{
				for (int j = 0; j < _cachedShadowCastingVolumes.Count; j++)
				{
					_cachedShadowCastingVolumes[j].gameObject.SetActive(value: false);
				}
			}
			else if (flag2 || _shadowCastingVolumeParent != null)
			{
				if (_shadowCastingVolumeParent == null)
				{
					GameObject gameObject = new GameObject("Shadow Casting Parent");
					_shadowCastingVolumeParent = gameObject.transform;
				}
				for (int k = 0; k < _cachedInteriorVolumeLights.Count; k++)
				{
					if (k >= _cachedShadowCastingVolumes.Count)
					{
						GameObject gameObject2 = new GameObject("Shadow Caster");
						gameObject2.transform.SetParent(_shadowCastingVolumeParent);
						MeshRenderer meshRenderer = gameObject2.AddComponent<MeshRenderer>();
						meshRenderer.sharedMaterial = _config.VolumeShadowCastingMaterial;
						meshRenderer.shadowCastingMode = ShadowCastingMode.ShadowsOnly;
						gameObject2.AddComponent<MeshFilter>().sharedMesh = _unitCubeMesh;
						int layer = LayerMask.NameToLayer("Outdoor");
						gameObject2.layer = layer;
						_cachedShadowCastingVolumes.Add(gameObject2.transform);
					}
					else
					{
						_cachedShadowCastingVolumes[k].gameObject.SetActive(value: true);
					}
					Vector3 center = _cachedInteriorVolumeLights[k].Bounds.center;
					center.y = 0f;
					_cachedShadowCastingVolumes[k].localPosition = center;
					Vector3 size = _cachedInteriorVolumeLights[k].Bounds.size;
					size.y = 4f;
					_cachedShadowCastingVolumes[k].localScale = size;
				}
				for (int l = _cachedInteriorVolumeLights.Count; l < _cachedShadowCastingVolumes.Count; l++)
				{
					_cachedShadowCastingVolumes[l].gameObject.SetActive(value: false);
				}
			}
			if (!(_debugReflectionSpheresGameObject != null))
			{
				return;
			}
			UnityEngine.Object.Destroy(_debugReflectionSpheresGameObject);
			_debugReflectionSpheresGameObject = new GameObject("Debug Reflection Spheres");
			foreach (RoomLight cachedInteriorVolumeLight in _cachedInteriorVolumeLights)
			{
				GameObject gameObject3 = GameObject.CreatePrimitive(PrimitiveType.Sphere);
				gameObject3.transform.parent = _debugReflectionSpheresGameObject.transform;
				Bounds bounds = cachedInteriorVolumeLight.Bounds;
				Vector3 center2 = bounds.center;
				center2.y = 1f;
				gameObject3.transform.position = center2;
				gameObject3.GetComponent<MeshRenderer>().sharedMaterial = _reflectionTestMaterial;
			}
		}

		private Material GetRoomLightMaterial(FloorPlan floorPlan)
		{
			if (floorPlan.OwningRoom == null)
			{
				return _defaultRoomLightMaterial;
			}
			return floorPlan.OwningRoom.GetRoomLightMaterial(_defaultRoomLightMaterial, _defaultRoomClosedLightMaterial);
		}

		private Cubemap GetRoomLightCubeMap(FloorPlan floorPlan)
		{
			if (floorPlan.OwningRoom == null)
			{
				return _defaultRoomLightCubemap;
			}
			return floorPlan.OwningRoom.GetRoomReflectionCubeMap(_defaultRoomLightCubemap, _defaultRoomClosedLightCubemap);
		}

		private static bool CanMergeWithNextCell(bool[,] cells, int x, int y, int walls)
		{
			if (y + 1 >= cells.GetLength(1))
			{
				return false;
			}
			walls &= 0xA;
			int num = CellWalls(cells, x, y + 1);
			if (cells[x, y + 1])
			{
				return walls == (num & 0xA);
			}
			return false;
		}

		private static bool IsFreeCell(bool[,] cells, int x, int y)
		{
			if (x >= 0 && x < cells.GetLength(0) && y >= 0 && y < cells.GetLength(1))
			{
				return cells[x, y];
			}
			return false;
		}

		private static int CellWalls(bool[,] cells, int x, int y)
		{
			return (int)((uint)(0 | ((!IsFreeCell(cells, x + 1, y)) ? 2 : 0) | ((!IsFreeCell(cells, x - 1, y)) ? 8 : 0)) | ((!IsFreeCell(cells, x, y + 1)) ? 1u : 0u)) | ((!IsFreeCell(cells, x, y - 1)) ? 4 : 0);
		}

		private static void GenerateCombinedLights(ref GenerateCombinedLightsConstParams parameters, bool[,] cells, Vector3 roomLightOffset, Material material, Cubemap reflectionCubemap, bool allowDataView)
		{
			int length = cells.GetLength(0);
			int length2 = cells.GetLength(1);
			parameters.Pass1.Clear();
			parameters.Pass2.Clear();
			if (parameters.DataViewEffects && allowDataView)
			{
				switch (parameters.Effect)
				{
				case Effect.None:
					material.DisableKeyword("DATAMAP");
					material.DisableKeyword("DATA_DESATURATE");
					break;
				case Effect.Desaturate:
					material.EnableKeyword("DATA_DESATURATE");
					break;
				case Effect.AttributeMap:
					material.EnableKeyword("DATAMAP");
					break;
				}
			}
			else
			{
				material.DisableKeyword("DATAMAP");
				material.DisableKeyword("DATA_DESATURATE");
			}
			for (int i = 0; i < length; i++)
			{
				int num = 0;
				while (true)
				{
					if (num < length2 && !cells[i, num])
					{
						num++;
						continue;
					}
					if (num >= length2)
					{
						break;
					}
					int num2 = CellWalls(cells, i, num);
					int j;
					for (j = num; CanMergeWithNextCell(cells, i, j, num2); j++)
					{
					}
					int num3 = CellWalls(cells, i, j);
					parameters.Pass1.Add(new CombinedRoomLight(i, num, i, j, (num2 & 0xE) | (num3 & 1)));
					num = j + 1;
				}
			}
			for (int k = 0; k < parameters.Pass1.Count; k++)
			{
				if (parameters.Pass1[k].MinX == -1)
				{
					continue;
				}
				CombinedRoomLight item = parameters.Pass1[k];
				parameters.Pass1[k] = new CombinedRoomLight(-1, -1, -1, -1, 0);
				for (int l = k + 1; l < parameters.Pass1.Count && parameters.Pass1[l].MaxX <= item.MaxX + 1; l++)
				{
					if (item.MinY == parameters.Pass1[l].MinY && item.MaxY == parameters.Pass1[l].MaxY && item.MaxX + 1 == parameters.Pass1[l].MinX && (item.Walls & 5) == (parameters.Pass1[l].Walls & 5))
					{
						item.MaxX = parameters.Pass1[l].MaxX;
						item.Walls |= parameters.Pass1[l].Walls;
						parameters.Pass1[l] = new CombinedRoomLight(-1, -1, -1, -1, 0);
					}
				}
				if ((item.Walls & 3) == 0 && !IsFreeCell(cells, item.MaxX + 1, item.MaxY + 1))
				{
					item.Walls |= 16;
				}
				if ((item.Walls & 6) == 0 && !IsFreeCell(cells, item.MaxX + 1, item.MinY - 1))
				{
					item.Walls |= 32;
				}
				if ((item.Walls & 0xC) == 0 && !IsFreeCell(cells, item.MinX - 1, item.MinY - 1))
				{
					item.Walls |= 64;
				}
				if ((item.Walls & 9) == 0 && !IsFreeCell(cells, item.MinX - 1, item.MaxY + 1))
				{
					item.Walls |= 128;
				}
				parameters.Pass2.Add(item);
			}
			if (parameters.CachedVolumeLights.Capacity < parameters.Pass2.Count)
			{
				parameters.CachedVolumeLights.Capacity = parameters.Pass2.Count;
			}
			float falloffThickness = (parameters.UseFalloff ? material.GetFloat("_FalloffThickness") : 0f);
			for (int m = 0; m < parameters.Pass2.Count; m++)
			{
				AddRoomLight(parameters.Pass2[m], roomLightOffset, falloffThickness, material, reflectionCubemap, allowDataView, ref parameters);
			}
		}

		private static void AddRoomLight(CombinedRoomLight combined, Vector3 roomLightOffset, float falloffThickness, Material material, Cubemap reflectionCubemap, bool allowDataView, ref GenerateCombinedLightsConstParams parameters)
		{
			float num;
			float y;
			switch (parameters.LightType)
			{
			case RoomLightType.Overhead:
				num = Mathf.Max(0f, parameters.OverheadLightHeight - parameters.RoomLightHeight);
				y = parameters.RoomLightHeight + 0.5f * num;
				break;
			case RoomLightType.Underneath:
				num = Mathf.Max(0f, parameters.RoomLightBaseBias - parameters.UnderneathLightHeight);
				y = parameters.UnderneathLightHeight + 0.5f * num;
				break;
			default:
				num = Mathf.Max(0f, parameters.RoomLightHeight - parameters.RoomLightBaseBias);
				y = parameters.RoomLightBaseBias + 0.5f * num;
				break;
			}
			Vector3 vector = new Vector3((float)(combined.MinX + combined.MaxX) * 0.5f * 2f, y, (float)(combined.MinY + combined.MaxY) * 0.5f * 2f) + roomLightOffset;
			Vector3 vector2 = new Vector3(2f + 2f * (float)(combined.MaxX - combined.MinX), num, 2f + 2f * (float)(combined.MaxY - combined.MinY));
			vector += parameters.GlobalLightOffset;
			Bounds bounds = new Bounds(vector, vector2);
			Vector4 vector3 = default(Vector4);
			if ((combined.Walls & 0x91) != 0)
			{
				vector3.x = 2f * falloffThickness / vector2.z;
			}
			if ((combined.Walls & 0x64) != 0)
			{
				vector3.y = 2f * falloffThickness / vector2.z;
			}
			if ((combined.Walls & 0x32) != 0)
			{
				vector3.z = 2f * falloffThickness / vector2.x;
			}
			if ((combined.Walls & 0xC8) != 0)
			{
				vector3.w = 2f * falloffThickness / vector2.x;
			}
			Vector4 vector4 = new Vector4(((combined.Walls & 0x10) == 0) ? 1 : 0, ((combined.Walls & 0x20) == 0) ? 1 : 0, ((combined.Walls & 0x40) == 0) ? 1 : 0, ((combined.Walls & 0x80) == 0) ? 1 : 0);
			if (!parameters.UseGPUInstancing)
			{
				MaterialPropertyBlock materialPropertyBlock = new MaterialPropertyBlock();
				materialPropertyBlock.SetVector(parameters.FalloffDistanceID, vector3);
				materialPropertyBlock.SetVector("_CornerToggle", vector4);
				parameters.CachedMaterialPropertyBlocks.Add(materialPropertyBlock);
				if (parameters.HospitalMapParams != null)
				{
					ApplyHospitalMapChanges(materialPropertyBlock, parameters.HospitalMapParams);
				}
			}
			else
			{
				parameters.CachedMaterialInstancingData.Add(new RoomLightInstancingData
				{
					FalloffDistance = vector3,
					CornerToggle = vector4,
					DirectionalLightColorIntensity = material.GetVector("_DirectionalLightColorIntensity"),
					AmbientLightColorIntensity = material.GetVector("_AmbientLightColorIntensity"),
					CeilingLightParams = material.GetVector("_CeilingLightParams"),
					CeilingLightParams1 = material.GetVector("_CeilingLightParams1"),
					LightParams0 = material.GetVector("_LightParams0")
				});
			}
			parameters.CachedVolumeLights.Add(new RoomLight(Matrix4x4.TRS(vector, Quaternion.identity, vector2), bounds, material, reflectionCubemap, allowDataView));
		}

		private static void ApplyHospitalMapChanges(MaterialPropertyBlock materialPropertyBlock, HospitalMapParams hospitalMapParams)
		{
			if (hospitalMapParams.Texture != null)
			{
				materialPropertyBlock.SetTexture("_HospitalTex", hospitalMapParams.Texture);
			}
			if (hospitalMapParams.Gradient != null)
			{
				materialPropertyBlock.SetTexture("_GradientTex", hospitalMapParams.Gradient);
			}
			materialPropertyBlock.SetVector("_MapDim", hospitalMapParams.Dimension);
			materialPropertyBlock.SetVector("_DataRange", hospitalMapParams.DataRange);
			materialPropertyBlock.SetFloat("_DataOpacity", hospitalMapParams.DataOpacity);
		}

		private static bool CanCameraReceiveLighting(Camera camera, TopDownCameraLogic metamapCameraLogic, int metagameLayerMask)
		{
			if ((camera.cameraType != CameraType.Game && camera.cameraType != CameraType.SceneView) || camera.name == "PreRenderCamera")
			{
				return false;
			}
			if (camera.cameraType == CameraType.Game && !camera.enabled)
			{
				return false;
			}
			if ((camera.cullingMask & metagameLayerMask) != 0)
			{
				return false;
			}
			if (metamapCameraLogic != null && camera == metamapCameraLogic.CameraComponent)
			{
				return false;
			}
			return true;
		}

		private void OnPreRender(Camera camera)
		{
			if (!CanCameraReceiveLighting(camera, _level.MetagameMap.CameraLogic, _metagameLayerMask))
			{
				return;
			}
			CommandBuffer orCreate = CommandBufferUtils.GetOrCreate(_cameraLightCommandBuffers, camera, CameraEvent.AfterLighting, "Deferred Room Lighting");
			orCreate.SetRenderTarget(new RenderTargetIdentifier(BuiltinRenderTextureType.CameraTarget));
			GeometryUtility.CalculateFrustumPlanes(camera, _cameraFrustumPlanesCached);
			if (QualitySettings.shadows != ShadowQuality.Disable && _exteriorLight != null && _exteriorLight.isActiveAndEnabled)
			{
				Shader.EnableKeyword("VOLUME_SHADOW_MASK_EXTERIOR");
				orCreate.EnableShaderKeyword("VOLUME_SHADOW_MASK");
				_exteriorShadowMaskTextures.TryGetValue(camera, out var value);
				orCreate.SetGlobalTexture(_exteriorVolumeShadowMaskID, value);
				orCreate.SetGlobalTexture(_volumeShadowMaskShaderID, value);
			}
			else
			{
				Shader.DisableKeyword("VOLUME_SHADOW_MASK_EXTERIOR");
				orCreate.DisableShaderKeyword("VOLUME_SHADOW_MASK");
			}
			orCreate.SetGlobalVector(_directionalLightDirectionID, -_exteriorLightDirection);
			if (_useGPUInstancing)
			{
				DrawLightsInstanced(_cameraFrustumPlanesCached, orCreate, _config.InteriorInstanceLightMaterial, _cachedExteriorVolumeLights, _cachedExteriorInstancingData);
			}
			else
			{
				Cubemap cubemap = null;
				for (int i = 0; i < _cachedExteriorVolumeLights.Count; i++)
				{
					RoomLight roomLight = _cachedExteriorVolumeLights[i];
					if (GeometryUtility.TestPlanesAABB(_cameraFrustumPlanesCached, roomLight.Bounds))
					{
						if (cubemap != roomLight.ReflectionCubemap)
						{
							cubemap = roomLight.ReflectionCubemap;
							orCreate.SetGlobalTexture(_roomLightCubemapTextureShaderID, roomLight.ReflectionCubemap);
						}
						orCreate.DrawMesh(_unitCubeMesh, roomLight.LocalToWorldMatrix, roomLight.Material, 0, -1, _cachedExteriorPropertyBlock[i]);
					}
				}
			}
			orCreate.SetGlobalVector(_directionalLightDirectionID, -_roomLightDirection);
			if (QualitySettings.shadows != ShadowQuality.Disable && _interiorLight != null && _interiorLight.isActiveAndEnabled)
			{
				orCreate.EnableShaderKeyword("VOLUME_SHADOW_MASK");
				_interiorShadowMaskTextures.TryGetValue(camera, out var value2);
				orCreate.SetGlobalTexture(_volumeShadowMaskShaderID, value2);
			}
			else
			{
				orCreate.DisableShaderKeyword("VOLUME_SHADOW_MASK");
			}
			if (_useGPUInstancing)
			{
				if (_effect != Effect.None)
				{
					if (_effect == Effect.Desaturate)
					{
						orCreate.EnableShaderKeyword("DATA_DESATURATE");
					}
					else if (_effect == Effect.AttributeMap)
					{
						orCreate.EnableShaderKeyword("DATAMAP");
					}
					if (_hospitalMapParams.Texture != null)
					{
						orCreate.SetGlobalTexture("_HospitalTex", _hospitalMapParams.Texture);
					}
					if (_hospitalMapParams.Gradient != null)
					{
						orCreate.SetGlobalTexture("_GradientTex", _hospitalMapParams.Gradient);
					}
					orCreate.SetGlobalVector("_MapDim", _hospitalMapParams.Dimension);
					orCreate.SetGlobalVector("_DataRange", _hospitalMapParams.DataRange);
					orCreate.SetGlobalFloat("_DataOpacity", _hospitalMapParams.DataOpacity);
				}
				DrawLightsInstanced(_cameraFrustumPlanesCached, orCreate, _config.InteriorInstanceLightMaterial, _cachedInteriorVolumeLights, _cachedInteriorInstancingData);
			}
			else
			{
				Cubemap cubemap2 = null;
				for (int j = 0; j < _cachedInteriorVolumeLights.Count; j++)
				{
					RoomLight roomLight2 = _cachedInteriorVolumeLights[j];
					if (GeometryUtility.TestPlanesAABB(_cameraFrustumPlanesCached, roomLight2.Bounds))
					{
						if (cubemap2 != roomLight2.ReflectionCubemap)
						{
							cubemap2 = roomLight2.ReflectionCubemap;
							orCreate.SetGlobalTexture(_roomLightCubemapTextureShaderID, roomLight2.ReflectionCubemap);
						}
						orCreate.DrawMesh(_unitCubeMesh, roomLight2.LocalToWorldMatrix, roomLight2.Material, 0, -1, _cachedInteriorPropertyBlocks[j]);
					}
				}
			}
			float num = ((_level.CameraLogic == null || !(_level.CameraLogic.CameraComponent != null)) ? camera.transform.position.y : _level.CameraLogic.CameraComponent.transform.position.y);
			float a;
			float num2;
			switch (_level.LocalPreferences.Video.LightFadeDistance)
			{
			case LocalPreferences.VideoPreferences.LightFadeDistanceMode.Near:
				a = _config.NearClippableFade.FadeInDistance;
				num2 = _config.NearClippableFade.FadeOutDistance;
				break;
			case LocalPreferences.VideoPreferences.LightFadeDistanceMode.Medium:
				a = _config.MediumClippableFade.FadeInDistance;
				num2 = _config.MediumClippableFade.FadeOutDistance;
				break;
			case LocalPreferences.VideoPreferences.LightFadeDistanceMode.Far:
				a = _config.FarClippableFade.FadeInDistance;
				num2 = _config.FarClippableFade.FadeOutDistance;
				break;
			default:
				a = 200f;
				num2 = 200f;
				break;
			}
			if (num < num2)
			{
				float fadeIntensity = Mathf.Clamp01(1f - Mathf.InverseLerp(a, num2, num));
				DrawClippableLights(orCreate, _clippablePointLightMaterial, _cameraFrustumPlanesCached, _clippablePointLights, _clippablePointLightsCachedData, isSpot: false, fadeIntensity);
				DrawClippableLights(orCreate, _clippableSpotLightMaterial, _cameraFrustumPlanesCached, _clippableSpotLights, _clippableSpotLightsCachedData, isSpot: true, fadeIntensity);
			}
		}

		private void AppendClippableLightInstanceData(ref int clippableLightCount, ClippableLight clippableLight, Vector4 worldPositionAtten, List<Matrix4x4> lightCells, float fadeIntensity)
		{
			Color color = clippableLight.Color * clippableLight.Intensity * clippableLight.Intensity * fadeIntensity;
			if (clippableLight.Type == ClippableLight.LightType.Spot)
			{
				Matrix4x4 worldToLocalMatrix = clippableLight.transform.worldToLocalMatrix;
				Matrix4x4 matrix4x = Matrix4x4.Perspective(clippableLight.SpotAngle, 1f, 0.1f, clippableLight.Range) * worldToLocalMatrix;
				for (int i = 0; i < lightCells.Count; i++)
				{
					_cachedClippableInstancingParams.WorldToLight[clippableLightCount + i] = matrix4x;
				}
			}
			for (int j = 0; j < lightCells.Count; j++)
			{
				_cachedClippableInstancingParams.Matrices[clippableLightCount] = lightCells[j];
				_cachedClippableInstancingParams.Color[clippableLightCount] = color;
				_cachedClippableInstancingParams.PostionAtten[clippableLightCount] = worldPositionAtten;
				clippableLightCount++;
			}
		}

		private void DrawClippableLightsInstanced(Material material, CommandBuffer commandBuffer, int clippableLightCount, bool isSpot)
		{
			_instancePropsCached.Clear();
			if (isSpot)
			{
				_instancePropsCached.SetMatrixArray("_ClippableWorldToLight", _cachedClippableInstancingParams.WorldToLight);
				commandBuffer.SetGlobalTexture(_lightTexture0ShaderID, _defaultSpotLightCookie);
			}
			_instancePropsCached.SetVectorArray("_ClippableLightPos", _cachedClippableInstancingParams.PostionAtten);
			_instancePropsCached.SetVectorArray("_Color", _cachedClippableInstancingParams.Color);
			commandBuffer.DrawMeshInstanced(_unitCubeMesh, 0, material, 0, _cachedClippableInstancingParams.Matrices, clippableLightCount, _instancePropsCached);
		}

		private void DrawClippableLights(CommandBuffer commandBuffer, Material lightMaterial, Plane[] cameraFrustumPlanes, List<ClippableLight> clippableLights, List<ClippableLightCachedData> clippableLightsCachedData, bool isSpot, float fadeIntensity)
		{
			bool flag = false;
			int clippableLightCount = 0;
			for (int i = 0; i < clippableLights.Count; i++)
			{
				ClippableLight clippableLight = clippableLights[i];
				if (clippableLight == null)
				{
					flag = true;
				}
				else
				{
					if (!clippableLight.isActiveAndEnabled)
					{
						continue;
					}
					Vector3 position = clippableLight.transform.position;
					float range = clippableLight.Range;
					if (!GeometryUtility.TestPlanesAABB(cameraFrustumPlanes, new Bounds(position, new Vector3(range, range, range))))
					{
						continue;
					}
					GridCoord gridCoord = position.ToGridCoord();
					Room roomAtWorldCoord = _level.WorldState.GetRoomAtWorldCoord(gridCoord, includeHospital: true, includeClosedPlots: true);
					if (roomAtWorldCoord == null)
					{
						continue;
					}
					int boundsSize = Mathf.CeilToInt(range) + 2;
					float num = 25f / (1f + 25f * clippableLight.Range * clippableLight.Range);
					Quaternion rotation = clippableLight.transform.rotation;
					ClippableLightCachedData value = clippableLightsCachedData[i];
					if (!Mathf.Approximately(value.WorldPosition.x, position.x) || !Mathf.Approximately(value.WorldPosition.y, position.y) || !Mathf.Approximately(value.WorldPosition.z, position.z) || !Mathf.Approximately(value.Rotation.x, rotation.x) || !Mathf.Approximately(value.Rotation.y, rotation.y) || !Mathf.Approximately(value.Rotation.z, rotation.z) || !Mathf.Approximately(value.Rotation.w, rotation.w))
					{
						clippableLightsCachedData[i].Cells.Clear();
						value.WorldPosition = position;
						value.Rotation = rotation;
						clippableLightsCachedData[i] = value;
						CombineClippableLight(_combinedClippableLightsCached, boundsSize, gridCoord, roomAtWorldCoord.FloorPlan);
						foreach (CombinedClippableLight item2 in _combinedClippableLightsCached)
						{
							Vector3 vector = new GridCoord(item2.MinX, item2.MinY).ToWorldPosition() - new Vector3(1f, 0f, 1f);
							Vector3 vector2 = new GridCoord(item2.MaxX, item2.MaxY).ToWorldPosition() + new Vector3(1f, 0f, 1f);
							Matrix4x4 item = Matrix4x4.TRS(new Vector3((vector.x + vector2.x) * 0.5f, position.y, (vector.z + vector2.z) * 0.5f), Quaternion.identity, new Vector3(vector2.x - vector.x, 10f, vector2.z - vector.z));
							clippableLightsCachedData[i].Cells.Add(item);
						}
					}
					if (!_useGPUInstancing || clippableLight.Cookie != null)
					{
						DrawClippableLight(lightMaterial, commandBuffer, clippableLightsCachedData[i].Cells, clippableLight, position, num, fadeIntensity, _instancePropsCached);
						continue;
					}
					AppendClippableLightInstanceData(ref clippableLightCount, clippableLight, new Vector4(position.x, position.y, position.z, num), clippableLightsCachedData[i].Cells, fadeIntensity);
					if (clippableLightCount > 256)
					{
						DrawClippableLightsInstanced(lightMaterial, commandBuffer, clippableLightCount, isSpot);
						clippableLightCount = 0;
					}
				}
			}
			if (_useGPUInstancing && clippableLightCount > 0)
			{
				DrawClippableLightsInstanced(lightMaterial, commandBuffer, clippableLightCount, isSpot);
			}
			if (flag)
			{
				clippableLights.RemoveAll((ClippableLight x) => x == null);
			}
		}

		private void DrawClippableLight(Material lightMaterial, CommandBuffer roomLightCommandBuffer, List<Matrix4x4> lightCells, ClippableLight clippableLight, Vector3 worldPosition, float attenCoefficient, float fadeIntensity, MaterialPropertyBlock propBlock)
		{
			propBlock.Clear();
			if (clippableLight.Type == ClippableLight.LightType.Spot)
			{
				lightMaterial = _clippableSpotLightMaterial;
				Matrix4x4 worldToLocalMatrix = clippableLight.transform.worldToLocalMatrix;
				Matrix4x4 matrix4x = Matrix4x4.Perspective(clippableLight.SpotAngle, 1f, 0.1f, clippableLight.Range);
				propBlock.SetMatrix(_unityWorldToLightShaderID, matrix4x * worldToLocalMatrix);
				propBlock.SetTexture(_lightTexture0ShaderID, clippableLight.Cookie ?? _defaultSpotLightCookie);
			}
			propBlock.SetVector(_colorShaderID, clippableLight.Color * clippableLight.Intensity * clippableLight.Intensity * fadeIntensity);
			propBlock.SetVector(_lightPosShaderID, new Vector4(worldPosition.x, worldPosition.y, worldPosition.z, attenCoefficient));
			foreach (Matrix4x4 lightCell in lightCells)
			{
				roomLightCommandBuffer.DrawMesh(_unitCubeMesh, lightCell, lightMaterial, 0, 0, propBlock);
			}
		}

		private static void CombineClippableLight(List<CombinedClippableLight> lights, int boundsSize, GridCoord lightGridCoord, FloorPlan floorPlan)
		{
			lights.Clear();
			for (int i = 0; i < boundsSize; i++)
			{
				int num = lightGridCoord.X + i - boundsSize / 2;
				int num2 = int.MinValue;
				int num3 = int.MinValue;
				for (int j = 0; j < boundsSize; j++)
				{
					int num4 = lightGridCoord.Y + j - boundsSize / 2;
					GridCoord worldCoord = new GridCoord(num, num4);
					bool flag = num3 != int.MinValue && num3 + 1 == num4;
					bool flag2 = RoomAlgorithms.RoomContainsWorldCoord(floorPlan, worldCoord);
					if (flag && !flag2)
					{
						lights.Add(new CombinedClippableLight
						{
							MinX = num,
							MaxX = num,
							MinY = num2,
							MaxY = num3
						});
						num2 = int.MinValue;
						num3 = int.MinValue;
					}
					else if (!flag && flag2)
					{
						num2 = num4;
						num3 = num4;
					}
					else if (flag)
					{
						num3 = num4;
					}
				}
				bool num5 = num2 != int.MinValue;
				bool flag3 = num3 != int.MinValue;
				if (num5 && flag3)
				{
					lights.Add(new CombinedClippableLight
					{
						MinX = num,
						MaxX = num,
						MinY = num2,
						MaxY = num3
					});
				}
			}
		}

		private void DrawLightsInstanced(Plane[] cameraFrustumPlanes, CommandBuffer commandBuffer, Material instanceMaterial, List<RoomLight> lights, List<RoomLightInstancingData> instancingDatas)
		{
			int num = 0;
			Cubemap cubemap = null;
			_instancePropsCached.Clear();
			bool? flag = null;
			for (int i = 0; i < lights.Count; i++)
			{
				RoomLight roomLight = lights[i];
				if (cubemap != roomLight.ReflectionCubemap || num > 256 || (flag.HasValue && flag.Value != lights[i].AllowDataView))
				{
					if (num > 0)
					{
						_instancePropsCached.SetVectorArray(_falloffDistanceID, _cachedInstancingParams.FalloffDistances);
						_instancePropsCached.SetVectorArray(_cornerToggleID, _cachedInstancingParams.CornerToggle);
						_instancePropsCached.SetVectorArray(_directionalLightColorIntensityID, _cachedInstancingParams.DirectionalLightColorIntensity);
						_instancePropsCached.SetVectorArray(_ambientLightColorIntensityID, _cachedInstancingParams.AmbientColorIntensity);
						_instancePropsCached.SetVectorArray(_ceilingLightParamsID, _cachedInstancingParams.CeilingLightParams);
						_instancePropsCached.SetVectorArray(_ceilingLightParams1ID, _cachedInstancingParams.CeilingLightParams1);
						_instancePropsCached.SetVectorArray(_lightParams0ID, _cachedInstancingParams.LightParams0);
						commandBuffer.DrawMeshInstanced(_unitCubeMesh, 0, instanceMaterial, 0, _cachedInstancingParams.Matrices, num, _instancePropsCached);
						if (!lights[i].AllowDataView && _effect == Effect.AttributeMap)
						{
							commandBuffer.DisableShaderKeyword("DATAMAP");
							flag = lights[i].AllowDataView;
						}
						else if (lights[i].AllowDataView && _effect == Effect.AttributeMap)
						{
							commandBuffer.EnableShaderKeyword("DATAMAP");
							flag = lights[i].AllowDataView;
						}
						num = 0;
					}
					cubemap = roomLight.ReflectionCubemap;
					commandBuffer.SetGlobalTexture(_roomLightCubemapTextureShaderID, roomLight.ReflectionCubemap);
				}
				RoomLightInstancingData roomLightInstancingData = instancingDatas[i];
				_cachedInstancingParams.Matrices[num] = roomLight.LocalToWorldMatrix;
				_cachedInstancingParams.FalloffDistances[num] = roomLightInstancingData.FalloffDistance;
				_cachedInstancingParams.CornerToggle[num] = roomLightInstancingData.CornerToggle;
				_cachedInstancingParams.DirectionalLightColorIntensity[num] = roomLightInstancingData.DirectionalLightColorIntensity;
				_cachedInstancingParams.AmbientColorIntensity[num] = roomLightInstancingData.AmbientLightColorIntensity;
				_cachedInstancingParams.CeilingLightParams[num] = roomLightInstancingData.CeilingLightParams;
				_cachedInstancingParams.CeilingLightParams1[num] = roomLightInstancingData.CeilingLightParams1;
				_cachedInstancingParams.LightParams0[num] = roomLightInstancingData.LightParams0;
				if (!lights[i].AllowDataView && _effect == Effect.AttributeMap)
				{
					commandBuffer.DisableShaderKeyword("DATAMAP");
					flag = lights[i].AllowDataView;
				}
				else if (lights[i].AllowDataView && _effect == Effect.AttributeMap)
				{
					commandBuffer.EnableShaderKeyword("DATAMAP");
					flag = lights[i].AllowDataView;
				}
				num++;
			}
			if (num > 0)
			{
				_instancePropsCached.SetVectorArray(_falloffDistanceID, _cachedInstancingParams.FalloffDistances);
				_instancePropsCached.SetVectorArray(_cornerToggleID, _cachedInstancingParams.CornerToggle);
				_instancePropsCached.SetVectorArray(_directionalLightColorIntensityID, _cachedInstancingParams.DirectionalLightColorIntensity);
				_instancePropsCached.SetVectorArray(_ambientLightColorIntensityID, _cachedInstancingParams.AmbientColorIntensity);
				_instancePropsCached.SetVectorArray(_ceilingLightParamsID, _cachedInstancingParams.CeilingLightParams);
				_instancePropsCached.SetVectorArray(_ceilingLightParams1ID, _cachedInstancingParams.CeilingLightParams1);
				_instancePropsCached.SetVectorArray(_lightParams0ID, _cachedInstancingParams.LightParams0);
				if (!lights[lights.Count - 1].AllowDataView && _effect == Effect.AttributeMap)
				{
					commandBuffer.DisableShaderKeyword("DATAMAP");
					flag = lights[lights.Count - 1].AllowDataView;
				}
				else if (lights[lights.Count - 1].AllowDataView && _effect == Effect.AttributeMap)
				{
					commandBuffer.EnableShaderKeyword("DATAMAP");
					flag = lights[lights.Count - 1].AllowDataView;
				}
				commandBuffer.DrawMeshInstanced(_unitCubeMesh, 0, instanceMaterial, 0, _cachedInstancingParams.Matrices, num, _instancePropsCached);
			}
		}

		private RenderTexture ClearThenCopyShadowMask(Camera camera, Light light, Dictionary<Camera, RenderTexture> cachedRenderTextures)
		{
			CommandBuffer orCreate = CommandBufferUtils.GetOrCreate(_clearShadowMaskCommandBuffers, camera, CameraEvent.BeforeLighting, "Deferred Room Lighting");
			RenderTexture renderTexture;
			if (!cachedRenderTextures.ContainsKey(camera))
			{
				renderTexture = (cachedRenderTextures[camera] = new RenderTexture(camera.pixelWidth, camera.pixelHeight, 0, RenderTextureFormat.R8));
			}
			else
			{
				renderTexture = cachedRenderTextures[camera];
				if (renderTexture.width != camera.pixelWidth || renderTexture.height != camera.pixelHeight)
				{
					renderTexture.Release();
					renderTexture = (cachedRenderTextures[camera] = new RenderTexture(camera.pixelWidth, camera.pixelHeight, 0, RenderTextureFormat.R8));
				}
			}
			orCreate.SetRenderTarget(renderTexture);
			orCreate.ClearRenderTarget(clearDepth: false, clearColor: true, Color.white);
			CommandBufferUtils.GetOrCreate(_shadowMaskCommandBuffers, light, LightEvent.AfterScreenspaceMask, "Copy Shadow Mask (Room Lighting)").Blit(new RenderTargetIdentifier(BuiltinRenderTextureType.CurrentActive), renderTexture);
			return renderTexture;
		}

		public void EnableDesaturatedHospital()
		{
			_effect = Effect.Desaturate;
			if (_hospitalMapParams == null)
			{
				_hospitalMapParams = new HospitalMapParams
				{
					DataOpacity = 0f
				};
			}
			for (int i = 0; i < _cachedInteriorVolumeLights.Count; i++)
			{
				if (_cachedInteriorVolumeLights[i].AllowDataView)
				{
					_cachedInteriorVolumeLights[i].Material.EnableKeyword("DATA_DESATURATE");
				}
			}
		}

		public void EnableHospitalMap(Texture2D texture, HospitalMapAttributesVisualisation.Config.AttributeConfig config)
		{
			_effect = Effect.AttributeMap;
			_hospitalMapParams = new HospitalMapParams
			{
				Texture = texture,
				Gradient = config.Gradient,
				DataRange = new Vector3(config.MinValue, config.MiddleValue, config.MaxValue),
				Dimension = new Vector2(texture.width, texture.height),
				DataOpacity = 0f
			};
			if (_useGPUInstancing)
			{
				return;
			}
			for (int i = 0; i < _cachedInteriorVolumeLights.Count; i++)
			{
				if (_cachedInteriorVolumeLights[i].AllowDataView)
				{
					_cachedInteriorVolumeLights[i].Material.EnableKeyword("DATAMAP");
					ApplyHospitalMapChanges(_cachedInteriorPropertyBlocks[i], _hospitalMapParams);
				}
			}
		}

		public void DisableHospitalEffects()
		{
			_effect = Effect.None;
			_hospitalMapParams = null;
			for (int i = 0; i < _cachedInteriorVolumeLights.Count; i++)
			{
				if (_cachedInteriorVolumeLights[i].AllowDataView)
				{
					_cachedInteriorVolumeLights[i].Material.DisableKeyword("DATAMAP");
					_cachedInteriorVolumeLights[i].Material.DisableKeyword("DATA_DESATURATE");
				}
			}
		}

		public void SetDataMapOpacity(float dataOpacity)
		{
			if (_hospitalMapParams == null || dataOpacity.Equals(_hospitalMapParams.DataOpacity))
			{
				return;
			}
			_hospitalMapParams.DataOpacity = dataOpacity;
			if (!_useGPUInstancing)
			{
				for (int i = 0; i < _cachedInteriorPropertyBlocks.Count; i++)
				{
					ApplyHospitalMapChanges(_cachedInteriorPropertyBlocks[i], _hospitalMapParams);
				}
			}
		}
	}
}
