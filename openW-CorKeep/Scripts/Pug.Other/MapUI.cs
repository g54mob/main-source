using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using I2.Loc;
using Pug.Platform;
using Pug.UnityExtensions;
using Rewired;
using Unity.Collections;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;

public class MapUI : MonoBehaviour
{
	private class MapPart
	{
		public SpriteRenderer spriteRenderer;

		public Texture2D timestampTexture;
	}

	private class MapMarker
	{
		public bool Hidden;

		public float2 TargetWorldPosition;

		public float2 DisplayedWorldPosition;

		public GameObject Container;

		public MapMarkerUIElement UiElement;

		public MapMarkerType Type => UiElement.markerType;

		public MapMarker(GameObject container)
		{
			Container = container;
			UiElement = container.GetComponentInChildren<MapMarkerUIElement>();
		}

		public void SetHidden(bool hidden)
		{
			Container.SetActive(!hidden);
			Hidden = hidden;
		}

		public bool ShouldHideOutsideMiniMapBorder()
		{
			MapMarkerType type = Type;
			return type == MapMarkerType.Portal || type == MapMarkerType.Waypoint || type == MapMarkerType.UserPlacedMarker || type == MapMarkerType.PlayerGrave;
		}

		public float2 GetScreenPosition()
		{
			return Container.transform.position.ToFloat3().xy;
		}
	}

	[Serializable]
	public struct UniqueMarkerInfo
	{
		public ObjectID id;

		public LocalizedString hoverString;

		public Sprite largeMapIcon;

		public Sprite miniMapIcon;
	}

	private class MarkerPool
	{
		private GameObject _prefab;

		private Stack<MapMarker> _freeMarkers;

		private Transform _parent;

		public MarkerPool(GameObject prefab, Transform parent)
		{
			_prefab = prefab;
			_parent = parent;
			_freeMarkers = new Stack<MapMarker>();
		}

		public MapMarker GetMarker()
		{
			if (!_freeMarkers.TryPop(out var result))
			{
				result = new MapMarker(UnityEngine.Object.Instantiate(_prefab, _parent));
			}
			result.Container.SetActive(value: true);
			return result;
		}

		public void ReturnMarker(MapMarker marker)
		{
			marker.Container.SetActive(value: false);
			_freeMarkers.Push(marker);
		}
	}

	private const float MARKER_OFFSET_QUANT = -0.001f;

	public const TextureFormat MAP_TEXTURE_FORMAT = TextureFormat.ARGB32;

	public const int TIMESTAMP_TEXTURE_DOWNSCALE = 1;

	public const int MAP_PART_WIDTH = 256;

	public const int MAP_PART_HEIGHT = 256;

	private static readonly int2 MapPartDimensions = new int2(256, 256);

	public const int TIMESTAMP_TEXTURE_WIDTH = 256;

	public const int TIMESTAMP_TEXTURE_HEIGHT = 256;

	public const int SERIALIZED_TEXTURE_WIDTH = 256;

	public const int SERIALIZED_TEXTURE_HEIGHT = 256;

	private const float MIN_ZOOM = 1f / 32f;

	private const float MAX_ZOOM = 4f;

	private static readonly Color[] Transparent = new Color[65536];

	private const float MARKER_UPDATE_INTERVAL_SECONDS = 1f;

	private const float PLAYER_TELEPORT_DISTANCE_THRESHOLD = 10f;

	private const float TILE_UPDATE_DELAY_AFTER_TELEPORT = 5f;

	private const float PING_LENGTH = 6f;

	private const float DELAY_BETWEEN_PINGS = 0.1f;

	private const int USER_MARKER_LIMIT = 512;

	private const float PING_MARKER_LIMIT = 64f;

	private const float GAMEPAD_MAP_CURSOR_OFFSET = -0.375f;

	private const float JOYSTICK_MAP_MOVE_SPEED = 10f;

	private const float MARKER_ATTRACTION_WEIGHT_WHILE_JOYSTICK_INPUT = 0.25f;

	private const float MARKER_ATTRACTION_WEIGHT_WHILE_NO_JOYSTICK_INPUT = 1f;

	private readonly int _maskRectShaderID = Shader.PropertyToID("_MaskRect");

	private readonly int2 _coreMarkerPosition = new int2(0, 4);

	private static int _mapTextureCount = 0;

	private static int _mapTimestampTextureCount = 0;

	public UserMapMarkerToggle pingUserMapMarkerToggle;

	private UserMapMarkerToggle _currentUserMapMarkerToggle;

	private UIelement _currentSelectedMapMarkerOption;

	public RemoveAllUserMapMarkersButton removeAllUserMapMarkersButton;

	public GameObject container;

	public GameObject mapPartsContainer;

	public Transform minimapPositionOffsetTransform;

	public Transform zoomTransform;

	public Transform mapUserPositionOffsetTransform;

	public Transform mapPlayerPositionOffsetTransform;

	public SpriteRenderer largeMapBorder;

	public SpriteRenderer largeMapBackground;

	public SpriteRenderer miniMapBorder;

	public SpriteRenderer miniMapBackground;

	public GameObject coreMarkerPrefab;

	public GameObject playerMarkerPrefab;

	public GameObject graveMarkerPrefab;

	public GameObject pingMarkerPrefab;

	public GameObject portalMarkerPrefab;

	public GameObject waypointMarkerPrefab;

	public GameObject userPlacedMarkerPrefab;

	public GameObject uniqueMarkerPrefab;

	public GameObject titanShrineMarkerPrefab;

	public GameObject coreAttentionMarkerPrefab;

	public Material mapContentMaterial;

	private Material _mapContentMaterial;

	public AnimationCurve markerAttractionCurve;

	private List<MapMarker> _playerMarkers = new List<MapMarker>();

	private List<MapMarker> _pingMarkers = new List<MapMarker>();

	private List<float> _pingMarkerTimers = new List<float>();

	private TimerSimple _pingCooldown = new TimerSimple(0.1f);

	private TimerSimple _markerUpdateTimer = new TimerSimple(1f, false, false);

	private int _lastUpdateMarkerEntityCount;

	private MarkerPool _portalMarkerPool;

	private MarkerPool _waypointMarkerPool;

	private MarkerPool _userPlacedMarkerPool;

	private MarkerPool _playerGraveMarkerPool;

	private MarkerPool _uniqueMarkerPool;

	private MarkerPool _playerMarkerPool;

	private MarkerPool _pingMarkerPool;

	private MarkerPool _titanShrinePool;

	private MarkerPool _coreAttentionPool;

	private Dictionary<Entity, MapMarker> _markerEntities = new Dictionary<Entity, MapMarker>();

	private List<MapMarker> _allNonEntityMarkers = new List<MapMarker>();

	private MapMarker _coreMarker;

	private List<Entity> _cachedEntityList = new List<Entity>();

	private HashSet<Entity> _cachedEntitySet = new HashSet<Entity>();

	private Dictionary<Unity.Entities.Hash128, PlayerController> _playerGuidToController = new Dictionary<Unity.Entities.Hash128, PlayerController>();

	private List<PlayerController> _cachedPlayerControllerList = new List<PlayerController>();

	private Texture2D _tmpMapTexture;

	private Texture2D _tmpTimestampTexture;

	private float2 _playerPositionOnLastUpdate;

	private TimerSimple _tileUpdateDelay;

	private int _currentlyLoadedCharacterId = -1;

	private int _currentlyLoadedServerId = -1;

	[ArrayElementTitle("id")]
	public List<UniqueMarkerInfo> uniqueMarkerInfo = new List<UniqueMarkerInfo>();

	private Dictionary<Vector2Int, MapPart> _mapParts = new Dictionary<Vector2Int, MapPart>();

	private bool _isShowingBigMap;

	private float _currentZoom = 2f;

	private float _bigMapZoom = 2f;

	private const float MINI_MAP_ZOOM = 1f;

	public NativeParallelHashSet<int2> MapsChangedThisUpdate;

	private HashSet<int2> _mapsChangedSinceLastSave = new HashSet<int2>();

	private EntityQuery _mapMarkersQuery;

	private MapUpdateSystem _mapUpdateSystem;

	private MapFile _mapFileData;

	private float2 _cursorHoldDownPosition;

	private float2 _accumulatedJoystickMovement;

	private bool _attractToNearbyMarker;

	private bool? _lastCoreMarkerAttentionState;

	private bool HasASelectedMapMarker
	{
		get
		{
			if (!(Manager.main.player != null) || !Manager.main.player.inputModule.PrefersKeyboardAndMouse())
			{
				return _currentSelectedMapMarkerOption is UserMapMarkerToggle;
			}
			return true;
		}
	}

	private UserMapMarkerType ActiveUserMapMarkerType
	{
		get
		{
			if (!(_currentUserMapMarkerToggle == null))
			{
				return _currentUserMapMarkerToggle.userMapMarkerType;
			}
			return UserMapMarkerType.Ping;
		}
	}

	public Dictionary<Vector2Int, MapPartSerialized> MapParts
	{
		get
		{
			UpdateSerializedData();
			return _mapFileData.mapParts;
		}
	}

	public bool IsShowingBigMap
	{
		get
		{
			return _isShowingBigMap;
		}
		private set
		{
			if (_isShowingBigMap != value)
			{
				_isShowingBigMap = value;
				OnBigMapToggled(_isShowingBigMap);
			}
		}
	}

	public bool PauseMapUpdates
	{
		get
		{
			if (_tileUpdateDelay.isRunning)
			{
				return !_tileUpdateDelay.isTimerElapsed;
			}
			return false;
		}
	}

	public bool OpenedMapThisFrame { get; private set; }

	public static PugColorARGB32 CurrentMapTimestampColor
	{
		get
		{
			uint num = (uint)(DateTimeOffset.Now.ToUnixTimeSeconds() >> 2);
			return new PugColorARGB32((byte)(num >> 24), (byte)(num >> 16), (byte)(num >> 8), (byte)num);
		}
	}

	public void SetUserMapMarkerToggle(UserMapMarkerToggle userMapMarkerToggle)
	{
		_currentUserMapMarkerToggle = userMapMarkerToggle;
	}

	private float GetCurrentZoom()
	{
		return _currentZoom * 0.0625f;
	}

	private float GetMarkerScale()
	{
		return 1f / GetCurrentZoom();
	}

	private float GetPixelPerfectQuantization()
	{
		return 0.0625f / GetCurrentZoom();
	}

	private void Awake()
	{
		largeMapBorder.gameObject.SetActive(value: false);
		container.SetActive(value: false);
		_tmpMapTexture = new Texture2D(256, 256, TextureFormat.ARGB32, mipChain: false, linear: false)
		{
			name = "MapUI_tmpMapTexture"
		};
		_tmpTimestampTexture = new Texture2D(256, 256, TextureFormat.ARGB32, mipChain: false, linear: true)
		{
			name = "MapUI_tmpTimestampTexture"
		};
		MapsChangedThisUpdate = new NativeParallelHashSet<int2>(4, Allocator.Persistent);
		_mapContentMaterial = UnityEngine.Object.Instantiate(mapContentMaterial);
		_portalMarkerPool = new MarkerPool(portalMarkerPrefab, mapPartsContainer.transform);
		_waypointMarkerPool = new MarkerPool(waypointMarkerPrefab, mapPartsContainer.transform);
		_userPlacedMarkerPool = new MarkerPool(userPlacedMarkerPrefab, mapPartsContainer.transform);
		_playerGraveMarkerPool = new MarkerPool(graveMarkerPrefab, mapPartsContainer.transform);
		_uniqueMarkerPool = new MarkerPool(uniqueMarkerPrefab, mapPartsContainer.transform);
		_playerMarkerPool = new MarkerPool(playerMarkerPrefab, mapPartsContainer.transform);
		_pingMarkerPool = new MarkerPool(pingMarkerPrefab, mapPartsContainer.transform);
		_titanShrinePool = new MarkerPool(titanShrineMarkerPrefab, mapPartsContainer.transform);
		_coreAttentionPool = new MarkerPool(coreAttentionMarkerPrefab, mapPartsContainer.transform);
		_mapContentMaterial.DisableKeyword("USE_COLOR_INDEXING");
		_coreMarker = new MapMarker(UnityEngine.Object.Instantiate(coreMarkerPrefab, mapPartsContainer.transform));
		_coreMarker.TargetWorldPosition = _coreMarkerPosition;
		_allNonEntityMarkers.Add(_coreMarker);
		OnBigMapToggled(isShowingBigMap: false);
	}

	private void OnDestroy()
	{
		UnityEngine.Object.Destroy(_tmpMapTexture);
		UnityEngine.Object.Destroy(_tmpTimestampTexture);
		MapsChangedThisUpdate.Dispose();
	}

	private void OnDisable()
	{
		foreach (MapMarker playerMarker in _playerMarkers)
		{
			playerMarker.SetHidden(hidden: true);
		}
		foreach (MapMarker pingMarker in _pingMarkers)
		{
			pingMarker.SetHidden(hidden: true);
		}
		ReturnAllPooledMarkers();
		_mapUpdateSystem = null;
	}

	public void GetOrCreateMapTextures(int2 mapPartKey, out NativeArray<PugColorARGB32> textureData, out NativeArray<PugColorARGB32> timestampData)
	{
		if (!_mapParts.TryGetValue(mapPartKey.ToVec2Int(), out var value))
		{
			value = SetupNewMapPart(mapPartKey);
		}
		textureData = value.spriteRenderer.sprite.texture.GetPixelData<PugColorARGB32>(0);
		timestampData = value.timestampTexture.GetPixelData<PugColorARGB32>(0);
	}

	public void SetColorAtPos(int2 worldPos, Color c)
	{
		if (_mapUpdateSystem == null)
		{
			_mapUpdateSystem = Manager.ecs.ClientWorld.GetExistingSystemManaged<MapUpdateSystem>();
		}
		_mapUpdateSystem.SetColorOverridesThisUpdate(worldPos, c);
	}

	public void PlaceMapMarker(float2 worldPos)
	{
		if (Manager.main.player.guestMode)
		{
			return;
		}
		if (Manager.ui.currentSelectedUIElement is MapMarkerUIElement { markerType: MapMarkerType.UserPlacedMarker } mapMarkerUIElement)
		{
			if (EntityUtility.EntityExists(mapMarkerUIElement.mapMarkerEntity, Manager.ecs.ClientWorld) && !EntityUtility.IsComponentEnabled<EntityDestroyedCD>(mapMarkerUIElement.mapMarkerEntity, Manager.ecs.ClientWorld))
			{
				Manager.main.player.QueueInputAction(new UIInputActionData
				{
					action = UIInputAction.RemoveMarker,
					entity = mapMarkerUIElement.mapMarkerEntity,
					position = EntityUtility.GetComponentData<LocalTransform>(mapMarkerUIElement.mapMarkerEntity, Manager.ecs.ClientWorld).Position.ToFloat2()
				});
			}
		}
		else
		{
			if ((Manager.ui.currentSelectedUIElement != null && !(Manager.ui.currentSelectedUIElement is BlockingUIElement)) || (_pingCooldown.isRunning && !_pingCooldown.isTimerElapsed))
			{
				return;
			}
			if (CountUserPlacedMarkers() >= 512)
			{
				if (Manager.menu.menuStackCount <= 0)
				{
					Manager.menu.centerPopUpText.StartNewDisplaySequence("maximumMapMarkersPlaced", null, menuInputCooldown: true, 0f, 1.5f, useUnscaledTime: true, 0f, 1f, localize: true, TextManager.FontFace.boldMedium, DummyCallBack, new List<string> { "cancelDialogue" }, 10f, 0.95f, 0, 18f, secondOptionPopsAllMenus: false, pauseGame: false);
				}
			}
			else
			{
				PlayerController player = Manager.main.player;
				ObjectDataCD objectData = new ObjectDataCD
				{
					objectID = ObjectID.MapMarker,
					variation = (int)(ActiveUserMapMarkerType - 2)
				};
				float3 position = EntityMonoBehaviour.ToRenderFromWorld(worldPos.ToFloat3());
				player.entityPrespawnSystem.CreatePrespawnEntity(objectData, position);
				player.playerCommandSystem.CreateMapUI(worldPos.ToFloat3(), (int)ActiveUserMapMarkerType);
			}
		}
	}

	private void DummyCallBack(PopupResponse response)
	{
	}

	private int CountUserPlacedMarkers()
	{
		int num = 0;
		foreach (MapMarker value in _markerEntities.Values)
		{
			if (value.Type == MapMarkerType.UserPlacedMarker)
			{
				num++;
			}
		}
		return num;
	}

	public void ClearAllUserPlacedMapMarkers()
	{
		if (!(Manager.main.player == null) && !Manager.main.player.guestMode)
		{
			Manager.main.player.QueueInputAction(new UIInputActionData
			{
				action = UIInputAction.ClearAllMarkers
			});
		}
	}

	public void Ping(PlayerController pc, float2 worldPos)
	{
		if ((_pingCooldown.isRunning && !_pingCooldown.isTimerElapsed) || (Manager.main.player.pvpMode && !pc.IsPlayersOfSamePvPTeam(Manager.main.player)))
		{
			return;
		}
		int i;
		for (i = 0; i < _pingMarkers.Count && !(_pingMarkerTimers[i] <= 0f); i++)
		{
		}
		if (!((float)i > 64f))
		{
			if (i == _pingMarkers.Count)
			{
				MapMarker markerFromPool = GetMarkerFromPool(_pingMarkerPool, Entity.Null);
				_pingMarkers.Add(markerFromPool);
				_pingMarkerTimers.Add(0f);
				_allNonEntityMarkers.Add(markerFromPool);
			}
			_pingMarkers[i].UiElement.player = pc;
			_pingMarkers[i].UiElement.UpdateColor();
			_pingMarkers[i].TargetWorldPosition = worldPos;
			_pingMarkers[i].SetHidden(hidden: false);
			_pingMarkerTimers[i] = 6f;
		}
	}

	private void UpdateSelection()
	{
		if (!IsShowingBigMap || Manager.main.player == null)
		{
			return;
		}
		PlayerInput inputModule = Manager.main.player.inputModule;
		if (inputModule.PrefersKeyboardAndMouse())
		{
			removeAllUserMapMarkersButton.MarkAsActiveOption(value: true);
			return;
		}
		if (_currentUserMapMarkerToggle == null)
		{
			_currentUserMapMarkerToggle = pingUserMapMarkerToggle;
		}
		if ((_currentSelectedMapMarkerOption == null || _currentSelectedMapMarkerOption is UserMapMarkerToggle { isOn: false }) && removeAllUserMapMarkersButton != Manager.ui.currentSelectedUIElement)
		{
			_currentSelectedMapMarkerOption = _currentUserMapMarkerToggle;
			_currentSelectedMapMarkerOption.OnLeftClicked(mod1: false, mod2: false);
		}
		bool flag = false;
		UIelement currentSelectedMapMarkerOption = _currentSelectedMapMarkerOption;
		if (inputModule.WasButtonPressedDownThisFrame(PlayerInput.InputType.SELECT_NEXT_MAP_MARKER))
		{
			_currentSelectedMapMarkerOption = _currentSelectedMapMarkerOption.GetAdjacentUIElement(Direction.Id.right, _currentSelectedMapMarkerOption.transform.position);
			flag = true;
		}
		else if (inputModule.WasButtonPressedDownThisFrame(PlayerInput.InputType.SELECT_PREVIOUS_MAP_MARKER))
		{
			_currentSelectedMapMarkerOption = _currentSelectedMapMarkerOption.GetAdjacentUIElement(Direction.Id.left, _currentSelectedMapMarkerOption.transform.position);
			flag = true;
		}
		if (_currentSelectedMapMarkerOption == removeAllUserMapMarkersButton)
		{
			if (currentSelectedMapMarkerOption is UserMapMarkerToggle userMapMarkerToggle2)
			{
				userMapMarkerToggle2.ToggleOff();
			}
			flag = inputModule.WasButtonPressedDownThisFrame(PlayerInput.InputType.MAP_PING);
		}
		if (flag)
		{
			_currentSelectedMapMarkerOption?.OnLeftClicked(mod1: false, mod2: false);
		}
		removeAllUserMapMarkersButton.MarkAsActiveOption(removeAllUserMapMarkersButton == _currentSelectedMapMarkerOption);
	}

	public void Init()
	{
		_mapMarkersQuery = Manager.ecs.GetClientEntityQuery(new EntityQueryDesc
		{
			All = new ComponentType[3]
			{
				typeof(MapMarkerCD),
				typeof(LocalTransform),
				typeof(ObjectDataCD)
			},
			None = new ComponentType[1] { typeof(EntityDestroyedCD) }
		});
	}

	public static Vector2Int WorldPositionToMapPartIndex(float2 worldPos)
	{
		worldPos += new float2(0.5f);
		return new Vector2Int((int)((worldPos.x < 0f) ? (worldPos.x - 256f) : worldPos.x) / 256, (int)((worldPos.y < 0f) ? (worldPos.y - 256f) : worldPos.y) / 256);
	}

	public static int2 WorldPositionToMapPartPosition(int2 worldPos)
	{
		return (worldPos % MapPartDimensions + MapPartDimensions) % MapPartDimensions;
	}

	private void OnBigMapToggled(bool isShowingBigMap)
	{
		if (isShowingBigMap)
		{
			Manager.ui.HideAllInventoryAndCraftingUI();
		}
		_markerUpdateTimer.Start(0f);
		if (isShowingBigMap)
		{
			SaveAllMaps();
			_pingCooldown.Start();
		}
		if (_mapContentMaterial != null)
		{
			Vector4 maskRect = GetMaskRect(isShowingBigMap ? largeMapBackground.bounds : miniMapBackground.bounds);
			_mapContentMaterial.SetVector(_maskRectShaderID, new Vector4(maskRect.x, maskRect.y, 1f / maskRect.z, 1f / maskRect.w));
		}
		if (isShowingBigMap)
		{
			minimapPositionOffsetTransform.localPosition = largeMapBorder.transform.localPosition;
			largeMapBorder.gameObject.SetActive(value: true);
			miniMapBorder.gameObject.SetActive(value: false);
			SetZoomLevel(_bigMapZoom);
		}
		else
		{
			minimapPositionOffsetTransform.localPosition = miniMapBorder.transform.localPosition;
			miniMapBorder.gameObject.SetActive(value: true);
			largeMapBorder.gameObject.SetActive(value: false);
			SetZoomLevel(1f);
		}
		float2 screenCoordinateOffset = ((Manager.main.player == null || Manager.main.player.inputModule.PrefersKeyboardAndMouse()) ? float2.zero : new float2(0f, -0.375f));
		CenterMapOnLocalPlayer(screenCoordinateOffset);
	}

	public void ToggleMap()
	{
		IsShowingBigMap = !IsShowingBigMap;
		AudioManager.SfxUI(IsShowingBigMap ? SfxID.paper : SfxID.paper2, 1f, reuse: true, 1f, 0.1f);
		OpenedMapThisFrame = IsShowingBigMap;
	}

	public void ShowBigMap()
	{
		if (!IsShowingBigMap)
		{
			ToggleMap();
		}
	}

	public void HideBigMap()
	{
		if (IsShowingBigMap)
		{
			ToggleMap();
		}
	}

	private Texture2D CreateMapTexture()
	{
		Texture2D texture2D = new Texture2D(256, 256, TextureFormat.ARGB32, mipChain: false, linear: false);
		texture2D.filterMode = FilterMode.Point;
		texture2D.name = $"MapTexture_{_mapTextureCount++}";
		texture2D.SetPixels(Transparent);
		return texture2D;
	}

	private Texture2D CreateTimestampTexture()
	{
		Texture2D texture2D = new Texture2D(256, 256, TextureFormat.ARGB32, mipChain: false, linear: true);
		texture2D.filterMode = FilterMode.Point;
		texture2D.name = $"MapTimestampTexture_{_mapTimestampTextureCount++}";
		texture2D.SetPixels(Transparent);
		return texture2D;
	}

	private MapPart SetupNewMapPart(int2 partIndex, Texture2D optionalTexture = null, Texture2D optionalTimestampTexture = null)
	{
		float3 float5 = (partIndex * MapPartDimensions).ToFloat2().XY0();
		int2 int5 = partIndex;
		GameObject obj = new GameObject("mapPart" + int5.ToString());
		obj.transform.SetParent(mapPartsContainer.transform);
		obj.transform.localScale = Vector3.one;
		obj.transform.localPosition = float5;
		obj.layer = ObjectLayerID.UI;
		SpriteRenderer spriteRenderer = obj.AddComponent<SpriteRenderer>();
		spriteRenderer.sortingLayerID = SortingLayerID.GUI;
		spriteRenderer.sortingOrder = 10;
		spriteRenderer.maskInteraction = SpriteMaskInteraction.None;
		spriteRenderer.material = _mapContentMaterial;
		if (optionalTexture != null)
		{
			optionalTexture.filterMode = FilterMode.Point;
		}
		if (optionalTimestampTexture != null)
		{
			optionalTimestampTexture.filterMode = FilterMode.Point;
		}
		Texture2D texture2D = ((optionalTexture != null) ? optionalTexture : CreateMapTexture());
		texture2D.name = $"mapPartTexture{partIndex}";
		texture2D.Apply();
		Texture2D texture2D2 = ((optionalTimestampTexture != null) ? optionalTimestampTexture : CreateTimestampTexture());
		texture2D2.name = $"mapPartTimestamp{partIndex}";
		texture2D2.Apply();
		try
		{
			spriteRenderer.sprite = Sprite.Create(texture2D, new Rect(float2.zero, MapPartDimensions.ToFloat2()), float2.zero, 1f, 0u, SpriteMeshType.FullRect);
		}
		catch (Exception exception)
		{
			Debug.LogException(exception);
			Debug.Log($"Clearing map part at {partIndex} due to error");
			UnityEngine.Object.Destroy(texture2D);
			UnityEngine.Object.Destroy(texture2D2);
			texture2D = CreateMapTexture();
			texture2D2 = CreateTimestampTexture();
			texture2D.Apply();
			texture2D2.Apply();
			spriteRenderer.sprite = Sprite.Create(texture2D, new Rect(float2.zero, MapPartDimensions.ToFloat2()), float2.zero, 1f, 0u, SpriteMeshType.FullRect);
		}
		MapPart mapPart = new MapPart
		{
			spriteRenderer = spriteRenderer,
			timestampTexture = texture2D2
		};
		_mapParts.Add(partIndex.ToVec2Int(), mapPart);
		return mapPart;
	}

	private void UpdateUIScaling()
	{
		Vector3 localScale = Manager.ui.CalcGameplayUITargetScaleMultiplier();
		minimapPositionOffsetTransform.localScale = localScale;
		if (localScale.x < 0.01f)
		{
			miniMapBorder.gameObject.SetActive(value: false);
			largeMapBorder.gameObject.SetActive(value: false);
		}
		else
		{
			miniMapBorder.gameObject.SetActive(!IsShowingBigMap);
			largeMapBorder.gameObject.SetActive(IsShowingBigMap);
		}
	}

	private void UpdatePositionFromPlayerMovement()
	{
		float2 localPlayerWorldPosition = GetLocalPlayerWorldPosition();
		mapPlayerPositionOffsetTransform.localPosition = -MakePixelPerfectMapPosition(localPlayerWorldPosition);
		if (math.distance(localPlayerWorldPosition, _playerPositionOnLastUpdate) > 10f)
		{
			_tileUpdateDelay.Start(5f);
		}
		_playerPositionOnLastUpdate = localPlayerWorldPosition;
	}

	private void UpdateZoom()
	{
		if (!IsShowingBigMap || !(Manager.main.player != null))
		{
			return;
		}
		Player rewiredPlayer = Manager.main.player.inputModule.rewiredPlayer;
		if ((rewiredPlayer.IsCurrentInputSource(93, ControllerType.Mouse) && rewiredPlayer.GetAxis(93) > 0f) || Manager.main.player.inputModule.WasButtonPressedDownThisFrame(PlayerInput.InputType.ZOOM_OUT_MAP))
		{
			if (_bigMapZoom <= 1f)
			{
				_bigMapZoom /= 2f;
			}
			else
			{
				_bigMapZoom -= 1f;
			}
		}
		else if ((rewiredPlayer.IsCurrentInputSource(92, ControllerType.Mouse) && rewiredPlayer.GetAxis(92) > 0f) || Manager.main.player.inputModule.WasButtonPressedDownThisFrame(PlayerInput.InputType.ZOOM_IN_MAP))
		{
			if (_bigMapZoom < 1f)
			{
				_bigMapZoom *= 2f;
			}
			else
			{
				_bigMapZoom += 1f;
			}
		}
		_bigMapZoom = math.clamp(_bigMapZoom, 1f / 32f, 4f);
		SetZoomLevel(_bigMapZoom);
	}

	private void SetZoomLevel(float newZoom)
	{
		if (!(math.abs(newZoom - _currentZoom) < 1.1920929E-07f))
		{
			float2 cursorWorldPosition = GetCursorWorldPosition();
			_currentZoom = newZoom;
			Vector3 localPosition = mapPlayerPositionOffsetTransform.localPosition;
			mapPlayerPositionOffsetTransform.localPosition = localPosition.RoundToMultipleXY(GetPixelPerfectQuantization());
			CenterCursorAtPosition(cursorWorldPosition);
			float currentZoom = GetCurrentZoom();
			zoomTransform.localScale = new float3(currentZoom, currentZoom, 1f);
			OnZoomLevelChanged();
		}
	}

	private void OnZoomLevelChanged()
	{
		float markerScale = GetMarkerScale();
		ScaleMarkers(_allNonEntityMarkers, markerScale);
		ScaleMarkers(_markerEntities.Values, markerScale);
	}

	private static void ScaleMarkers(IEnumerable<MapMarker> markers, float scale)
	{
		foreach (MapMarker marker in markers)
		{
			marker.Container.transform.localScale = new float3(scale, scale, 1f);
		}
	}

	private Vector4 GetMaskRect(Bounds bounds)
	{
		float3 float5 = bounds.min;
		float3 float6 = bounds.max;
		return new Vector4(float5.x, float5.y, float6.x - float5.x, float6.y - float5.y);
	}

	private void LateUpdate()
	{
		bool flag = Manager.main.currentSceneHandler != null && Manager.main.currentSceneHandler.isInGame && (IsShowingBigMap || (Manager.prefs.showMinimap && !Manager.ui.isAnyInventoryShowing));
		container.SetActive(flag);
		UpdateUIScaling();
		UpdatePositionFromPlayerMovement();
		UpdateZoom();
		if (flag)
		{
			UpdateMapFromUserInput();
			ApplyTextureUpdates();
			UpdatePingMarkers();
			UpdateCoreMarker();
			UpdatePlayerMarkers();
			UpdateMarkersFromEntities();
			AdjustMarkerBorderPositions();
			ApplyMarkerPositions();
			UpdateSelection();
		}
		OpenedMapThisFrame = false;
	}

	public void CenterAtPosition(float2 worldPosition)
	{
		float3 obj = MakePixelPerfectMapPosition(worldPosition);
		float3 float5 = -mapPlayerPositionOffsetTransform.localPosition.ToFloat3();
		float3 float6 = -(obj - float5);
		mapUserPositionOffsetTransform.localPosition = float6;
	}

	public void CenterCursorAtPosition(float2 worldPosition)
	{
		float2 cursorWorldPosition = GetCursorWorldPosition();
		float2 worldPosition2 = ScreenToWorldPosition(minimapPositionOffsetTransform.position.ToFloat3().xy) + (worldPosition - cursorWorldPosition);
		CenterAtPosition(worldPosition2);
	}

	public void CenterMapOnLocalPlayer(float2 screenCoordinateOffset = default(float2))
	{
		screenCoordinateOffset = screenCoordinateOffset.RoundToMultiple(0.0625f);
		float2 v = screenCoordinateOffset / GetCurrentZoom();
		mapUserPositionOffsetTransform.localPosition = -v.XY0();
	}

	private void UpdateMapFromUserInput()
	{
		if (!IsShowingBigMap || Manager.main.player == null)
		{
			return;
		}
		PlayerInput inputModule = Manager.main.player.inputModule;
		if (inputModule.PrefersKeyboardAndMouse())
		{
			if (inputModule.WasButtonPressedDownThisFrame(PlayerInput.InputType.INTERACT))
			{
				_cursorHoldDownPosition = GetCursorWorldPosition();
			}
			if (inputModule.IsButtonCurrentlyDown(PlayerInput.InputType.INTERACT))
			{
				CenterCursorAtPosition(_cursorHoldDownPosition);
			}
		}
		else
		{
			MapMarker attractingMarker = null;
			float2 cursorScreenPosition = GetCursorScreenPosition();
			float2 obj = inputModule.GetInputAxisValue(PlayerInput.InputAxisType.MAP_MOVEMENT_HORIZONTAL, PlayerInput.InputAxisType.MAP_MOVEMENT_VERTICAL);
			float2 float5 = (_attractToNearbyMarker ? GetMarkerAttraction(cursorScreenPosition, out attractingMarker) : float2.zero);
			bool flag = math.length(obj) > 1.1920929E-07f;
			float num = (flag ? 0.25f : 1f);
			float2 float6 = (obj + float5 * num) * 10f;
			float2 float7 = float6 * Time.deltaTime;
			if (!flag && attractingMarker != null && ShouldSnapToMarker(cursorScreenPosition, float7, attractingMarker))
			{
				CenterAtPosition(attractingMarker.TargetWorldPosition);
				_attractToNearbyMarker = true;
			}
			else
			{
				_accumulatedJoystickMovement += float7;
				float2 float8 = _accumulatedJoystickMovement.RoundToMultiple(0.0625f);
				mapUserPositionOffsetTransform.position -= new Vector3(float8.x, float8.y, 0f);
				_accumulatedJoystickMovement -= float8;
				_attractToNearbyMarker = math.length(float6) > 1.1920929E-07f;
			}
		}
		if (Manager.main.player != null && !OpenedMapThisFrame && inputModule.WasButtonPressedDownThisFrame(PlayerInput.InputType.MAP_PING) && HasASelectedMapMarker)
		{
			float2 cursorWorldPosition = GetCursorWorldPosition();
			if (ActiveUserMapMarkerType > UserMapMarkerType.Ping)
			{
				PlaceMapMarker(cursorWorldPosition);
				return;
			}
			Ping(Manager.main.player, cursorWorldPosition);
			Manager.main.player.playerCommandSystem.MapPing(Manager.main.player.entity, cursorWorldPosition.ToFloat3());
		}
	}

	private bool ShouldSnapToMarker(float2 cursorScreenPosition, float2 movementThisFrame, MapMarker marker)
	{
		float2 screenPosition = marker.GetScreenPosition();
		float2 float5 = screenPosition - cursorScreenPosition;
		if (math.dot(float5, movementThisFrame) < 0f)
		{
			return false;
		}
		if (math.lengthsq(movementThisFrame) < math.lengthsq(screenPosition))
		{
			return false;
		}
		return math.distance(math.project(float5, movementThisFrame), float5) <= 0.125f;
	}

	private float2 GetMarkerAttraction(float2 cursorScreenPosition, out MapMarker attractingMarker)
	{
		if (!TryFindClosestMarker(cursorScreenPosition, out attractingMarker))
		{
			return float2.zero;
		}
		float2 xy = attractingMarker.Container.transform.position.ToFloat3().xy;
		float num = math.distance(xy, cursorScreenPosition);
		if (num < 0.0625f)
		{
			return float2.zero;
		}
		return markerAttractionCurve.Evaluate(num) * math.normalizesafe(xy - cursorScreenPosition);
	}

	private bool TryFindClosestMarker(float2 screenPosition, out MapMarker closestMarker)
	{
		closestMarker = null;
		float num = float.MaxValue;
		foreach (MapMarker value in _markerEntities.Values)
		{
			if (!value.Hidden)
			{
				float num2 = math.distancesq(value.GetScreenPosition(), screenPosition);
				if (num2 < num)
				{
					num = num2;
					closestMarker = value;
				}
			}
		}
		return closestMarker != null;
	}

	private void ApplyTextureUpdates()
	{
		foreach (int2 item in MapsChangedThisUpdate)
		{
			MapPart mapPart = _mapParts[item.ToVec2Int()];
			mapPart.spriteRenderer.sprite.texture.Apply();
			mapPart.timestampTexture.Apply();
			_mapsChangedSinceLastSave.Add(item);
		}
		MapsChangedThisUpdate.Clear();
	}

	private void UpdateSerializedData()
	{
		foreach (int2 item in _mapsChangedSinceLastSave)
		{
			MapPart mapPart = _mapParts[item.ToVec2Int()];
			Texture2D texture = mapPart.spriteRenderer.sprite.texture;
			Texture2D timestampTexture = mapPart.timestampTexture;
			MapPartSerialized value = new MapPartSerialized
			{
				png = texture.EncodeToPNG(),
				timestampPng = timestampTexture.EncodeToPNG()
			};
			value.RecomputeTimestampHash();
			_mapFileData.mapParts[item.ToVec2Int()] = value;
		}
		_mapsChangedSinceLastSave.Clear();
	}

	private void UpdateCoreMarker()
	{
		if (Manager.saves.IsCreativeModeWorld())
		{
			_coreMarker.SetHidden(hidden: true);
			return;
		}
		_coreMarker.SetHidden(hidden: false);
		_coreMarker.TargetWorldPosition = _coreMarkerPosition;
	}

	private void UpdatePlayerMarkers()
	{
		List<PlayerController> cachedPlayerControllerList = _cachedPlayerControllerList;
		cachedPlayerControllerList.Clear();
		cachedPlayerControllerList.AddRange(Manager.main.nonLocalPlayers);
		if (Manager.main.player != null)
		{
			cachedPlayerControllerList.Add(Manager.main.player);
		}
		for (int i = _playerMarkers.Count; i < cachedPlayerControllerList.Count; i++)
		{
			MapMarker markerFromPool = GetMarkerFromPool(_playerMarkerPool, Entity.Null);
			_playerMarkers.Add(markerFromPool);
			_allNonEntityMarkers.Add(markerFromPool);
		}
		for (int j = 0; j < cachedPlayerControllerList.Count; j++)
		{
			MapMarker mapMarker = _playerMarkers[j];
			if (cachedPlayerControllerList[j].isDyingOrDead || (Manager.main.player != null && Manager.main.player.pvpMode && !cachedPlayerControllerList[j].IsPlayersOfSamePvPTeam(Manager.main.player)))
			{
				mapMarker.SetHidden(hidden: true);
				mapMarker.UiElement.player = null;
			}
			else
			{
				mapMarker.SetHidden(hidden: false);
				mapMarker.TargetWorldPosition = GetPlayerWorldPosition(cachedPlayerControllerList[j]);
				mapMarker.UiElement.player = cachedPlayerControllerList[j];
			}
		}
		for (int k = cachedPlayerControllerList.Count; k < _playerMarkers.Count; k++)
		{
			_playerMarkers[k].SetHidden(hidden: true);
			_playerMarkers[k].UiElement.player = null;
		}
	}

	private void UpdateMarkersFromEntities()
	{
		if (Manager.main.player == null)
		{
			return;
		}
		using NativeArray<Entity> nativeArray = _mapMarkersQuery.ToEntityArray(Allocator.Temp);
		if (nativeArray.Length == _lastUpdateMarkerEntityCount)
		{
			TimerSimple markerUpdateTimer = _markerUpdateTimer;
			if (markerUpdateTimer.isRunning && !markerUpdateTimer.isTimerElapsed)
			{
				return;
			}
		}
		_lastUpdateMarkerEntityCount = nativeArray.Length;
		_markerUpdateTimer.Start(1f);
		using NativeArray<MapMarkerCD> markerData = _mapMarkersQuery.ToComponentDataArray<MapMarkerCD>(Allocator.Temp);
		using NativeArray<LocalTransform> transforms = _mapMarkersQuery.ToComponentDataArray<LocalTransform>(Allocator.Temp);
		RemoveMarkersWithoutEntity(nativeArray);
		CreateNewMarkers(nativeArray, markerData);
		UpdateMarkerOwnership();
		UpdateMarkerVisibility();
		UpdateMarkerEntityPositions(nativeArray, transforms);
	}

	private bool TryGetUniqueMarkerInfo(ObjectID id, out UniqueMarkerInfo info)
	{
		foreach (UniqueMarkerInfo item in uniqueMarkerInfo)
		{
			if (item.id == id)
			{
				info = item;
				return true;
			}
		}
		info = default(UniqueMarkerInfo);
		return false;
	}

	private void CreateNewMarkers(NativeArray<Entity> markerEntities, NativeArray<MapMarkerCD> markerData)
	{
		for (int i = 0; i < markerEntities.Length; i++)
		{
			if (!_markerEntities.ContainsKey(markerEntities[i]))
			{
				TryCreateNewMarker(markerEntities[i], markerData[i]);
			}
		}
	}

	private bool TryCreateNewMarker(Entity entity, MapMarkerCD mapMarkerData)
	{
		if (!TryGetMarkerPool(mapMarkerData.mapMarkerType, out var pool))
		{
			return false;
		}
		MapMarker markerFromPool = GetMarkerFromPool(pool, entity);
		switch (mapMarkerData.mapMarkerType)
		{
		case MapMarkerType.UniqueBoss:
		case MapMarkerType.UniqueScene:
		{
			if (!TryGetUniqueMarkerInfo(mapMarkerData.uniqueMarkerId, out var info))
			{
				Debug.LogError($"Unique marker with id {mapMarkerData.uniqueMarkerId} not found in unique markers list.");
				break;
			}
			markerFromPool.UiElement.hoverString = info.hoverString;
			markerFromPool.UiElement.largeMapIcon = info.largeMapIcon;
			markerFromPool.UiElement.miniMapIcon = info.miniMapIcon;
			markerFromPool.UiElement.Init();
			break;
		}
		case MapMarkerType.Portal:
		case MapMarkerType.UserPlacedMarker:
		case MapMarkerType.Waypoint:
		case MapMarkerType.TitanShrine:
		case MapMarkerType.CoreAttention:
			markerFromPool.UiElement.userMarkerType = mapMarkerData.userMapMarkerType;
			break;
		case MapMarkerType.PlayerGrave:
			UpdatePlayerGraveOwner(entity, markerFromPool);
			break;
		}
		return true;
	}

	private MapMarker GetMarkerFromPool(MarkerPool pool, Entity entity)
	{
		float markerScale = GetMarkerScale();
		MapMarker marker = pool.GetMarker();
		marker.Container.transform.localScale = new Vector3(markerScale, markerScale, 1f);
		marker.UiElement.mapMarkerEntity = entity;
		marker.UiElement.Init();
		if (entity != Entity.Null)
		{
			_markerEntities.Add(entity, marker);
		}
		return marker;
	}

	private void RemoveMarkersWithoutEntity(NativeArray<Entity> existingEntities)
	{
		_cachedEntitySet.Clear();
		foreach (Entity item in existingEntities)
		{
			_cachedEntitySet.Add(item);
		}
		_cachedEntityList.Clear();
		_cachedEntityList.AddRange(_markerEntities.Keys);
		foreach (Entity cachedEntity in _cachedEntityList)
		{
			if (!_cachedEntitySet.Contains(cachedEntity))
			{
				ReturnToPool(_markerEntities[cachedEntity]);
				_markerEntities.Remove(cachedEntity);
			}
		}
	}

	private void UpdateMarkerOwnership()
	{
		if (!ConnectedPlayersChanged(_playerGuidToController, Manager.main.allPlayers))
		{
			return;
		}
		_playerGuidToController.Clear();
		foreach (PlayerController allPlayer in Manager.main.allPlayers)
		{
			PlayerGhost componentData = EntityUtility.GetComponentData<PlayerGhost>(allPlayer.entity, Manager.ecs.ClientWorld);
			_playerGuidToController.Add(componentData.playerGuid, allPlayer);
		}
		foreach (var (markerEntity, mapMarker2) in _markerEntities)
		{
			if (mapMarker2.Type == MapMarkerType.PlayerGrave)
			{
				UpdatePlayerGraveOwner(markerEntity, mapMarker2);
			}
		}
	}

	private static bool ConnectedPlayersChanged(Dictionary<Unity.Entities.Hash128, PlayerController> oldPlayers, List<PlayerController> currentPlayers)
	{
		if (oldPlayers.Count != currentPlayers.Count)
		{
			return true;
		}
		foreach (PlayerController currentPlayer in currentPlayers)
		{
			if (!oldPlayers.ContainsKey(EntityUtility.GetComponentData<PlayerGhost>(currentPlayer.entity, Manager.ecs.ClientWorld).playerGuid))
			{
				return true;
			}
		}
		return false;
	}

	private void UpdatePlayerGraveOwner(Entity markerEntity, MapMarker marker)
	{
		if (EntityUtility.TryGetComponentData<ClaimedByPlayerGuidCD>(markerEntity, Manager.ecs.ClientWorld, out var value))
		{
			marker.UiElement.player = (_playerGuidToController.TryGetValue(value.playerGuid, out var value2) ? value2 : null);
		}
	}

	private void UpdateMarkerVisibility()
	{
		bool pvpMode = Manager.main.player.pvpMode;
		foreach (var (entity2, mapMarker2) in _markerEntities)
		{
			switch (mapMarker2.Type)
			{
			case MapMarkerType.Player:
			case MapMarkerType.PlayerGrave:
			{
				PlayerController player = mapMarker2.UiElement.player;
				bool hidden2 = player == null || (pvpMode && !Manager.main.player.IsPlayersOfSamePvPTeam(player));
				mapMarker2.SetHidden(hidden2);
				break;
			}
			case MapMarkerType.Portal:
			case MapMarkerType.Waypoint:
			case MapMarkerType.TitanShrine:
			{
				MapMarkerActivatedCD value;
				bool hidden = EntityUtility.TryGetComponentData<MapMarkerActivatedCD>(entity2, Manager.ecs.ClientWorld, out value) && value.Hidden;
				mapMarker2.SetHidden(hidden);
				break;
			}
			}
		}
	}

	private void UpdateMarkerEntityPositions(NativeArray<Entity> entities, NativeArray<LocalTransform> transforms)
	{
		for (int i = 0; i < entities.Length; i++)
		{
			Entity key = entities[i];
			if (_markerEntities.TryGetValue(key, out var value) && !value.Hidden)
			{
				float2 targetWorldPosition = transforms[i].Position.ToFloat2();
				if (value.Type == MapMarkerType.Waypoint)
				{
					targetWorldPosition += new float2(1f, 1f);
				}
				value.TargetWorldPosition = targetWorldPosition;
			}
		}
	}

	private void ReturnAllPooledMarkers()
	{
		foreach (MapMarker value in _markerEntities.Values)
		{
			ReturnToPool(value);
		}
		_markerEntities.Clear();
		foreach (MapMarker allNonEntityMarker in _allNonEntityMarkers)
		{
			if (allNonEntityMarker != _coreMarker)
			{
				ReturnToPool(allNonEntityMarker);
			}
		}
		_allNonEntityMarkers.Clear();
		_allNonEntityMarkers.Add(_coreMarker);
		_playerMarkers.Clear();
		_pingMarkers.Clear();
		_pingMarkerTimers.Clear();
	}

	private void ReturnToPool(MapMarker marker)
	{
		marker.UiElement.mapMarkerEntity = Entity.Null;
		marker.UiElement.player = null;
		if (!TryGetMarkerPool(marker.Type, out var pool))
		{
			Debug.LogError($"Non-pooled marker type {marker.Type} found when returning to pool");
		}
		else
		{
			pool.ReturnMarker(marker);
		}
	}

	private bool TryGetMarkerPool(MapMarkerType type, out MarkerPool pool)
	{
		pool = type switch
		{
			MapMarkerType.Portal => _portalMarkerPool, 
			MapMarkerType.Waypoint => _waypointMarkerPool, 
			MapMarkerType.UserPlacedMarker => _userPlacedMarkerPool, 
			MapMarkerType.PlayerGrave => _playerGraveMarkerPool, 
			MapMarkerType.UniqueScene => _uniqueMarkerPool, 
			MapMarkerType.UniqueBoss => _uniqueMarkerPool, 
			MapMarkerType.Player => _playerMarkerPool, 
			MapMarkerType.Ping => _pingMarkerPool, 
			MapMarkerType.TitanShrine => _titanShrinePool, 
			MapMarkerType.CoreAttention => _coreAttentionPool, 
			_ => null, 
		};
		return pool != null;
	}

	private void UpdatePingMarkers()
	{
		for (int i = 0; i < _pingMarkers.Count; i++)
		{
			if (_pingMarkerTimers[i] <= 0f)
			{
				_pingMarkers[i].SetHidden(hidden: true);
			}
			_pingMarkerTimers[i] -= Time.deltaTime;
		}
	}

	private float3 MakePixelPerfectMapPosition(float2 worldPos)
	{
		worldPos += 0.5f;
		return worldPos.RoundToMultiple(GetPixelPerfectQuantization()).XY0();
	}

	private float2 ScreenToWorldPosition(float2 screenPosition)
	{
		float2 obj = screenPosition - mapPlayerPositionOffsetTransform.position.ToFloat3().xy;
		Vector3 vector = Manager.ui.CalcGameplayUITargetScaleMultiplier();
		float2 float5 = math.max(new float2(vector.x, vector.y), 0.01f);
		return obj / GetCurrentZoom() / float5 - 0.5f;
	}

	public float2 GetCursorScreenPosition()
	{
		if (Manager.main.player == null)
		{
			return float2.zero;
		}
		if (!Manager.main.player.inputModule.PrefersKeyboardAndMouse())
		{
			return minimapPositionOffsetTransform.position.ToFloat3().xy;
		}
		return Manager.ui.mouse.pointer.transform.localPosition.ToFloat3().xy;
	}

	public float2 GetCursorWorldPosition()
	{
		return ScreenToWorldPosition(GetCursorScreenPosition());
	}

	private float2 GetLocalPlayerWorldPosition()
	{
		PlayerController player = Manager.main.player;
		if (player == null)
		{
			return float2.zero;
		}
		return GetPlayerWorldPosition(player);
	}

	private float2 GetPlayerWorldPosition(PlayerController player)
	{
		return player.WorldPosition.XZ().RoundToMultiple(0.0625f);
	}

	private void AdjustMarkerBorderPositions()
	{
		float2 xy = minimapPositionOffsetTransform.position.ToFloat3().xy;
		Vector2 vector = (IsShowingBigMap ? largeMapBorder.size : miniMapBorder.size);
		float3 float5 = math.max(Manager.ui.CalcGameplayUITargetScaleMultiplier().ToFloat3(), 0.01f);
		float3 float6 = new float3(vector.x - 0.125f, vector.y - 0.125f, 1f) / GetCurrentZoom() / float5;
		Bounds bounds = new Bounds(ScreenToWorldPosition(xy).XY0(), float6);
		MoveMarkersWithinBounds(_allNonEntityMarkers, bounds);
		MoveMarkersWithinBounds(_markerEntities.Values, bounds);
	}

	private void MoveMarkersWithinBounds(IEnumerable<MapMarker> markers, Bounds bounds)
	{
		foreach (MapMarker marker in markers)
		{
			if (marker.Hidden)
			{
				continue;
			}
			float3 float5 = marker.TargetWorldPosition.XY0();
			if (bounds.Contains(float5))
			{
				marker.Container.SetActive(value: true);
				marker.DisplayedWorldPosition = float5.xy;
				continue;
			}
			if (!IsShowingBigMap && marker.ShouldHideOutsideMiniMapBorder())
			{
				marker.Container.SetActive(value: false);
				continue;
			}
			Vector3 normalized = (bounds.center - (Vector3)float5).normalized;
			if (!(math.lengthsq(normalized) < 0.1f))
			{
				Ray ray = new Ray(float5, normalized);
				if (bounds.IntersectRay(ray, out var distance))
				{
					_ = distance >= 0f;
				}
				else
					_ = 0;
				marker.DisplayedWorldPosition = float5.xy + new float2(normalized.x, normalized.y) * distance;
			}
		}
	}

	private void ApplyMarkerPositions()
	{
		int zOrder = 0;
		ApplyMarkerPositions(_markerEntities.Values, ref zOrder);
		ApplyMarkerPositions(_allNonEntityMarkers, ref zOrder);
	}

	private void ApplyMarkerPositions(IEnumerable<MapMarker> markers, ref int zOrder)
	{
		foreach (MapMarker marker in markers)
		{
			float3 float5 = MakePixelPerfectMapPosition(marker.DisplayedWorldPosition);
			float5.z = (float)(++zOrder) * -0.001f;
			marker.Container.transform.localPosition = float5;
		}
	}

	public void LoadMaps()
	{
		Clear();
		if (_currentlyLoadedCharacterId != -1)
		{
			Debug.LogError("hasn't unloaded old maps");
		}
		_currentlyLoadedCharacterId = Manager.saves.GetCharacterId();
		_currentlyLoadedServerId = Manager.saves.GetServerId();
		FilesystemManager.File file = Manager.filesystemManager.GetFile(FilesystemManager.FileID.MapParts, _currentlyLoadedCharacterId, _currentlyLoadedServerId);
		try
		{
			if (!file.Exists())
			{
				return;
			}
			FilesystemManager.LoadBinaryFile(file, ref _mapFileData);
			List<Vector2Int> list = new List<Vector2Int>(_mapFileData.mapParts.Count);
			foreach (KeyValuePair<Vector2Int, MapPartSerialized> mapPart in _mapFileData.mapParts)
			{
				_tmpMapTexture.LoadImage(mapPart.Value.png);
				_tmpTimestampTexture.LoadImage(mapPart.Value.timestampPng);
				if (_tmpMapTexture.width != 256 || _tmpMapTexture.height != 256 || _tmpTimestampTexture.width != 256 || _tmpTimestampTexture.height != 256)
				{
					Debug.LogError($"Invalid map part dimensions for {mapPart.Key} on client, removing from map");
					list.Add(mapPart.Key);
				}
			}
			foreach (Vector2Int item in list)
			{
				_mapFileData.mapParts.Remove(item);
			}
		}
		catch (Exception exception)
		{
			Debug.LogException(exception);
			return;
		}
		if (_mapFileData.mapParts == null)
		{
			return;
		}
		foreach (KeyValuePair<Vector2Int, MapPartSerialized> mapPart2 in _mapFileData.mapParts)
		{
			CreateMapPartFromSerializedData(mapPart2.Key, mapPart2.Value);
		}
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool TimestampIsNewer(PugColorARGB32 a, PugColorARGB32 b)
	{
		int num = (a.r << 24) | (a.g << 16) | (a.b << 8) | a.a;
		uint num2 = (uint)((b.r << 24) | (b.g << 16) | (b.b << 8) | b.a);
		return (uint)num > num2;
	}

	public void UpdateMapPart(int2 mapPosition, MapPartSerialized mapPart)
	{
		Vector2Int vector2Int = mapPosition.ToVec2Int();
		if (!_mapParts.ContainsKey(vector2Int))
		{
			CreateMapPartFromSerializedData(mapPosition.ToVec2Int(), mapPart);
			_mapFileData.mapParts.Add(vector2Int, mapPart);
			return;
		}
		_tmpMapTexture.LoadImage(mapPart.png);
		_tmpTimestampTexture.LoadImage(mapPart.timestampPng);
		MapPart mapPart2 = _mapParts[vector2Int];
		NativeArray<PugColorARGB32> currentTimestamps = mapPart2.timestampTexture.GetPixelData<PugColorARGB32>(0);
		NativeArray<PugColorARGB32> incomingTimestamps = _tmpTimestampTexture.GetPixelData<PugColorARGB32>(0);
		NativeArray<PugColorARGB32> currentColor = mapPart2.spriteRenderer.sprite.texture.GetPixelData<PugColorARGB32>(0);
		MapUIBurstedUtility.UpdateMapPart(_tmpMapTexture.GetPixelData<PugColorARGB32>(0), in incomingTimestamps, ref currentColor, ref currentTimestamps);
		mapPart2.spriteRenderer.sprite.texture.Apply();
		mapPart2.timestampTexture.Apply();
		_mapsChangedSinceLastSave.Add(vector2Int.ToInt2());
	}

	private void CreateMapPartFromSerializedData(Vector2Int mapPosition, MapPartSerialized mapPartSerialized)
	{
		Texture2D texture2D = CreateMapTexture();
		texture2D.LoadImage(mapPartSerialized.png);
		Texture2D texture2D2 = CreateTimestampTexture();
		texture2D2.LoadImage(mapPartSerialized.timestampPng);
		SetupNewMapPart(mapPosition.ToInt2(), texture2D, texture2D2);
	}

	private byte[] GetSerializedMapData(out int byteCount)
	{
		ApplyTextureUpdates();
		UpdateSerializedData();
		return FilesystemManager.SerializeToBinary(_mapFileData, FilesystemManager.FileID.MapParts, out byteCount);
	}

	public void SaveAllMaps()
	{
		if (_mapsChangedSinceLastSave.Count != 0 && _currentlyLoadedCharacterId != -1 && _currentlyLoadedServerId != -1)
		{
			int byteCount;
			byte[] serializedMapData = GetSerializedMapData(out byteCount);
			if (serializedMapData != null)
			{
				Debug.Log("Writing map data");
				Manager.filesystemManager.GetFile(FilesystemManager.FileID.MapParts, _currentlyLoadedCharacterId, _currentlyLoadedServerId).Write(serializedMapData, byteCount, addToPool: true);
			}
		}
	}

	public void Clear(bool clearSavedData = false)
	{
		foreach (MapPart value in _mapParts.Values)
		{
			if (value.spriteRenderer.sprite.texture != null)
			{
				UnityEngine.Object.Destroy(value.spriteRenderer.sprite.texture);
			}
			UnityEngine.Object.Destroy(value.spriteRenderer.gameObject);
			UnityEngine.Object.Destroy(value.timestampTexture);
		}
		_mapParts.Clear();
		MapsChangedThisUpdate.Clear();
		_mapsChangedSinceLastSave.Clear();
		_mapFileData = new MapFile
		{
			mapParts = new SerializableDictionary<Vector2Int, MapPartSerialized>()
		};
		if (!clearSavedData)
		{
			_currentlyLoadedCharacterId = -1;
			_currentlyLoadedServerId = -1;
		}
	}

	public bool IsShowingUniqueMarker(ObjectID objectID)
	{
		if (Manager.ecs.ClientWorld == null)
		{
			return false;
		}
		foreach (var (entity2, mapMarker2) in _markerEntities)
		{
			if (mapMarker2.Type == MapMarkerType.UniqueBoss && EntityUtility.EntityExists(entity2, Manager.ecs.ClientWorld) && EntityUtility.GetComponentData<MapMarkerCD>(entity2, Manager.ecs.ClientWorld).uniqueMarkerId == objectID)
			{
				return true;
			}
		}
		return false;
	}

	public bool IsShowingShrineMarker(ObjectID objectID)
	{
		if (Manager.ecs.ClientWorld == null)
		{
			return false;
		}
		foreach (var (entity2, mapMarker2) in _markerEntities)
		{
			if (mapMarker2.Type == MapMarkerType.TitanShrine && EntityUtility.EntityExists(entity2, Manager.ecs.ClientWorld) && EntityUtility.GetComponentData<MapMarkerCD>(entity2, Manager.ecs.ClientWorld).uniqueMarkerId == objectID)
			{
				return true;
			}
		}
		return false;
	}

	public bool IsShowingAnyShrineMarker()
	{
		if (Manager.ecs.ClientWorld == null)
		{
			return false;
		}
		foreach (var (entity2, mapMarker2) in _markerEntities)
		{
			if (mapMarker2.Type == MapMarkerType.TitanShrine && EntityUtility.EntityExists(entity2, Manager.ecs.ClientWorld))
			{
				return true;
			}
		}
		return false;
	}
}
