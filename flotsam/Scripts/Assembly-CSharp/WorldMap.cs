using System;
using System.Collections;
using System.Collections.Generic;
using PajamaLlama.Math;
using PajamaLlama.Utilities;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class WorldMap : SceneBehaviour
{
	public enum Collisions
	{
		BuildRadius = 0,
		Constructions = 1,
		Physics2D = 2
	}

	[Header("Transition")]
	[SerializeField]
	private Color _fadeColor = Color.blue;

	[SerializeField]
	private float _fadeTime = 0.5f;

	[SerializeField]
	private float _landmarkZoomRadius = 250f;

	[SerializeField]
	private float _landmarkZoomSmoothness = 0.65f;

	[Header("Movement")]
	[SerializeField]
	private CursorProperties _movementCursorProperties;

	[SerializeField]
	private WorldMapTownheart _townheart;

	[SerializeField]
	private int _physicsUpdateInterval = 500;

	[SerializeField]
	private Transform _physicsParent;

	[SerializeField]
	private WorldMapTownheartPhycis2D _townheartPhysics;

	[SerializeField]
	private PolygonCollider2D _landmarkPhysicsPrefab;

	[SerializeField]
	private float _movementSpeed = 50f;

	[SerializeField]
	private float _rotationSpeed = 50f;

	[SerializeField]
	private DialogProperties _nextBiomeDialog;

	[Header("Visualization")]
	[SerializeField]
	private WorldMapTile _worldMapTilePrefab;

	[SerializeField]
	private WorldMapPath _movementPath;

	[SerializeField]
	private WorldMapPath _planningPath;

	[SerializeField]
	private GameObject _boatRadiusRenderer;

	[SerializeField]
	private WorldMapEnergyCostMarker _energyCostMarkerPrefab;

	[Header("Audio")]
	[SerializeField]
	private AudioClipProperties _openAudioClip;

	[SerializeField]
	private AudioClipProperties _closeAudioClip;

	[Header("Scouting")]
	[SerializeField]
	private WorldMapCompass _compass;

	[SerializeField]
	private float _defaultFOWRange = 375f;

	[SerializeField]
	private float _defaultScoutRange = 250f;

	[SerializeField]
	private float _watchFOWRange = 750f;

	[SerializeField]
	private float _watchTowerScoutRange = 250f;

	[Header("Misc")]
	[SerializeField]
	private WorldMapCameraController _worldCameraController;

	[SerializeField]
	private TransformPositionTweener _worldCameraPositionTweener;

	[SerializeField]
	private WorldMapFogOfWar _fogOfWar;

	[SerializeField]
	private bool _zoomCloseToLandmarks = true;

	[Header("Debugging")]
	[SerializeField]
	private bool _debugNextBiome;

	private World _world;

	private Vector3 _startPosition;

	private Quaternion _startRotation;

	private float _distanceMoved;

	private List<UnityEngine.Object> _movementBlockers = new List<UnityEngine.Object>();

	private Coroutine _movementCoroutine;

	private bool _movementWithKeys;

	private readonly List<WorldMapTile> _tiles = new List<WorldMapTile>();

	private float _swimRadius;

	private Community _playerCommunity;

	private Engine _engine;

	private bool _isChangingState;

	private RevealSpawnerEvent _revealLandmarkEvent;

	private readonly List<WorldMapEnergyCostMarker> _distanceMarkers = new List<WorldMapEnergyCostMarker>();

	private readonly List<WorldMapScoutableLandmark> _allLandmarks = new List<WorldMapScoutableLandmark>();

	private readonly List<WorldMapFlotsam> _allFlotsam = new List<WorldMapFlotsam>();

	private bool _mouseMovementTargetActive;

	private bool _townheartInitialized;

	public WorldMapTownheart Townheart => _townheart;

	public WorldMapCompass Compass => _compass;

	public WorldMapCameraController WorldCameraController => _worldCameraController;

	public WorldMapFogOfWar FogOfWar => _fogOfWar;

	public bool IsMoving { get; private set; }

	public bool IsTownMovementBlocked => 0 < _movementBlockers.Count;

	public float FuelAmount { get; set; }

	public List<MapObstacle> Obstacles { get; } = new List<MapObstacle>();

	public UnityEvent OnMovementPress { get; } = new UnityEvent();

	public float MovementSpeed => EnergyDevTools.ApplyMovementSpeed(_movementSpeed) * _engine.ReturnMovementSpeed();

	public float RotationSpeed => EnergyDevTools.ApplyMovementSpeed(_rotationSpeed) * _engine.ReturnMovementSpeed();

	public void Initialize()
	{
		_world = GameManager.WorldManager.World;
		_playerCommunity = Community.PlayerCommunity;
		InitializeTownheart();
		Compass.Initialize();
		InitializeVisuals(_world);
		_swimRadius = GameManager.Settings.GameplaySettings.SwimmingRadius;
		UpdateGlobalShaderVariables();
		for (int i = 0; i < _playerCommunity.Agents.Count; i++)
		{
			SpawnAgentVisual(_playerCommunity.Agents[i]);
		}
		GameEventDispatcher.AddListener(GameEventType.WorldTileAdded, OnWorldTileAdded);
		GameEventDispatcher.AddListener(GameEventType.WorldTileRemoved, OnWorldTileRemoved);
		GameEventDispatcher.AddListener(GameEventType.AgentAddedToPlayerCommunity, OnAgentAdded);
		GameEventDispatcher.AddListener(GameEventType.RevealSpawner, OnRevealLandmark);
		_playerCommunity.BoatsUpdatedEvent += OnBoatBuilt;
		_boatRadiusRenderer.SetActive(_playerCommunity.HasBoat());
		GameManager.UIManager.WorldMapCanvas.Initialize(this);
	}

	public void InitializeTownheart()
	{
		if (!_townheartInitialized && !(_playerCommunity.Engine == null))
		{
			_engine = _playerCommunity.Engine;
			_townheartPhysics.Initialize(this, _engine);
			_townheart.Initialize(_engine, _townheartPhysics);
			_worldCameraController.transform.position = _townheart.transform.position;
			_worldCameraController.Initialize(this, _townheart.transform);
			_townheartInitialized = true;
		}
	}

	private void Activate()
	{
		UIManager.SetState(UIState.Map);
		CameraController.Instance.Camera.enabled = false;
		CameraController.Instance.UICamera.enabled = false;
		InitializeCameraPositionAndRotation();
		AudioManager.EnableMapAudio(_openAudioClip);
		InitializeTownheart();
		UpdateScouting();
		base.gameObject.SetActive(value: true);
		GameManager.CursorManager.Activate(_movementCursorProperties);
		GameEventDispatcher.Dispatch(GameEventType.MapActivated);
		_compass.UpdateBearings();
		_isChangingState = false;
		_startPosition = _townheart.transform.position;
		_startRotation = _townheart.transform.rotation;
		_distanceMoved = 0f;
		RemoveMovementBlocker(this);
		RevealLandmark();
	}

	private void Deactivate()
	{
		if (!Mathf.Approximately(_distanceMoved, 0f))
		{
			Transform transform = _townheart.transform;
			_playerCommunity.StopNonInteractableProjects(transform.position, GameManager.Settings.GameplaySettings.InteractionRadius);
			Vector2 vector = transform.transform.position.Vector2TopDown();
			LandmarkMapObstacle landmarkMapObstacle = ReturnClosestObstacle();
			if (landmarkMapObstacle != null && vector.IsInRange(landmarkMapObstacle.Position, GameSettings.Instance.GameplaySettings.SwimmingRadius))
			{
				Vector2 a = landmarkMapObstacle.MapLandmark.ReturnClosestMapPosition(_townheart.transform.position).Vector2TopDown();
				Vector2 vector2 = landmarkMapObstacle.MapLandmark.ReturnClosestWorldPosition(_townheart.transform.position).Vector2TopDown();
				float num = Vector2.Distance(a, vector);
				Vector2 normalized = (vector - vector2).normalized;
				vector = vector2 + normalized * num;
			}
			try
			{
				MovementEvent.DispatchTownheartMove(_startPosition, vector.Vector3TopDown(), _startRotation, transform.rotation, _distanceMoved);
			}
			catch (Exception exception)
			{
				Debug.LogException(exception);
			}
		}
		UIManager.SetState(UIState.Normal);
		AddMovementBlocker(this);
		CameraController.Instance.Camera.enabled = true;
		CameraController.Instance.UICamera.enabled = true;
		CameraController.Instance.transform.SetPositionAndRotation(Quaternion.Inverse(_townheart.transform.rotation) * _worldCameraController.RelativePosition, Quaternion.Inverse(_townheart.transform.rotation) * _worldCameraController.transform.rotation);
		AudioManager.DisableMapAudio(_closeAudioClip);
		base.gameObject.SetActive(value: false);
		GameManager.CursorManager.Deactivate();
		GameEventDispatcher.Dispatch(GameEventType.MapDeactivated);
		_isChangingState = false;
		_revealLandmarkEvent?.Dispose();
		_revealLandmarkEvent = null;
		FlotsamInputManager.ResetCameraTownheartMovementInputToggle();
		PruneWorldtiles();
	}

	private void OnEnable()
	{
		if (GameManager.UIManager.WorldMapCanvas.RewiredActionInfoBar != null)
		{
			GameManager.UIManager.WorldMapCanvas.RewiredActionInfoBar.AddActions(_townheartPhysics.Forward, _townheartPhysics.Backward, _townheartPhysics.RotateLeft, _townheartPhysics.RotateRight);
		}
	}

	private void Update()
	{
		UpdateGlobalShaderVariables();
		UpdateScouting();
		if (_engine.ConsumeEnergy(_townheartPhysics.DistanceMoved))
		{
			_distanceMoved += _townheartPhysics.DistanceMoved;
		}
		if (!IsTownMovementBlocked && _townheartPhysics.ProcessedInput && _townheartPhysics.Moved && !_mouseMovementTargetActive)
		{
			StartKeyMovement();
		}
		else
		{
			EndKeyMovement();
		}
	}

	private void LateUpdate()
	{
		Vector2 vector = _townheart.Position.Vector2TopDown();
		_world?.UpdateTiles(vector);
		foreach (WorldMapTile tile in _tiles)
		{
			tile.UpdatePhyscis(vector, 62500f);
		}
	}

	private void UpdateGlobalShaderVariables()
	{
		Shader.SetGlobalVector("TOWNHEART_POSITION", _townheart.transform.position);
		Shader.SetGlobalFloat("TOWNHEART_RADIUS", _swimRadius);
		Shader.SetGlobalFloat("TOWNHEART_RADIUS_NOISE_STRENGTH", GameManager.WorldManager.World.TileProperties.MapOverlayWeight);
	}

	private void OnDestroy()
	{
		GameEventDispatcher.RemoveListener(GameEventType.WorldTileAdded, OnWorldTileAdded);
		GameEventDispatcher.RemoveListener(GameEventType.WorldTileRemoved, OnWorldTileRemoved);
		GameEventDispatcher.RemoveListener(GameEventType.AgentAddedToPlayerCommunity, OnAgentAdded);
		GameEventDispatcher.RemoveListener(GameEventType.RevealSpawner, OnRevealLandmark);
		if (_playerCommunity != null)
		{
			_playerCommunity.BoatsUpdatedEvent -= OnBoatBuilt;
		}
	}

	private void InitializeVisuals(World world)
	{
		foreach (WorldTile tile in world.Tiles)
		{
			AddWorldTile(tile, async: false);
		}
	}

	private void OnWorldTileAdded(GameEvent gameEvent)
	{
		if (gameEvent is MapEvent mapEvent)
		{
			AddWorldTile(mapEvent.WorldTile, async: true);
		}
	}

	private void AddWorldTile(WorldTile worldTile, bool async)
	{
		WorldMapTile worldMapTile = UnityEngine.Object.Instantiate(_worldMapTilePrefab, (_worldMapTilePrefab.transform.parent == null) ? base.transform : _worldMapTilePrefab.transform.parent);
		worldMapTile.Initialize(worldTile, _physicsUpdateInterval, async);
		_tiles.Add(worldMapTile);
	}

	private void OnWorldTileRemoved(GameEvent gameEvent)
	{
		if (!(gameEvent is MapEvent mapEvent) || _tiles.IsNullOrEmpty())
		{
			return;
		}
		foreach (WorldMapTile tile in _tiles)
		{
			if (tile.WorldTile == mapEvent.WorldTile)
			{
				tile.gameObject.SetActive(value: false);
			}
			else if (tile.WorldTile == _world.Tiles[0])
			{
				tile.RestoreLastTileFOW();
			}
		}
	}

	private void PruneWorldtiles()
	{
		if (_tiles.IsNullOrEmpty())
		{
			return;
		}
		int count = _tiles.Count;
		while (0 < count--)
		{
			WorldMapTile worldMapTile = _tiles[count];
			if (!_world.Tiles.Contains(worldMapTile.WorldTile))
			{
				UnityEngine.Object.Destroy(worldMapTile.gameObject);
				_tiles.RemoveAt(count);
			}
		}
	}

	public void ActivateForwardInputWait()
	{
		_townheartPhysics.Forward.ActivateWait(RewiredComponent.Wait.ForUpAndAxisZero);
		if (GameManager.CursorManager.Properties is MouseMovementCursorProperties mouseMovementCursorProperties)
		{
			mouseMovementCursorProperties.Interact.ActivateWait(RewiredComponent.Wait.ForUpAndAxisZero);
		}
	}

	public void CenterOnTownheart()
	{
		_worldCameraController.SetRelativePosition(Vector3.zero);
	}

	private void OnRevealLandmark(GameEvent gameEvent)
	{
		_revealLandmarkEvent?.Dispose();
		_revealLandmarkEvent = gameEvent as RevealSpawnerEvent;
		RevealLandmark();
	}

	private void RevealLandmark()
	{
		if (_revealLandmarkEvent != null && !_isChangingState)
		{
			if (base.isActiveAndEnabled)
			{
				PLCoroutine.Start(RevealSpawnerRoutine(_revealLandmarkEvent.Spawner, _revealLandmarkEvent.PrePanDialogue, _revealLandmarkEvent.PostPanDialogue, _revealLandmarkEvent.CenterOnTownheartWaitTime), this).Completed.AddListener(OnRevealSpawnerRoutineCompleted);
			}
			else if (_revealLandmarkEvent.OpenMapIfInactive)
			{
				Open();
				return;
			}
			_revealLandmarkEvent.Dispose();
			_revealLandmarkEvent = null;
		}
	}

	private IEnumerator RevealSpawnerRoutine(ISpawner spawner, DialogueTrigger prePanDialogue, DialogueTrigger postPanDialogue, float centerOnTownheartWaitTime)
	{
		WorldMapPointOfInterest poiToReveal = null;
		AddMovementBlocker(this);
		while (_isChangingState)
		{
			yield return null;
		}
		if (prePanDialogue != null)
		{
			yield return prePanDialogue.TriggerRoutine();
		}
		if (TryReturnPointOfInterest(out var poi, spawner) && poi.InitializeReveal())
		{
			poiToReveal = poi;
		}
		else
		{
			spawner.ClearFogOfWar();
		}
		_worldCameraController.enabled = false;
		_worldCameraPositionTweener.Initialize(spawner.WorldPosition2D.Vector3TopDown());
		yield return Tweener.TweenRoutine(_worldCameraPositionTweener.Duration, _worldCameraPositionTweener.Easing, true, _worldCameraPositionTweener);
		if (poiToReveal != null)
		{
			yield return poiToReveal.RevealRoutine();
		}
		else if (postPanDialogue != null)
		{
			yield return postPanDialogue.TriggerRoutine();
		}
		else if (0f < centerOnTownheartWaitTime)
		{
			yield return new WaitForSecondsRealtime(centerOnTownheartWaitTime);
		}
		CenterOnTownheart();
		_worldCameraPositionTweener.Initialize(_townheart.Position);
		yield return Tweener.TweenRoutine(_worldCameraPositionTweener.Duration, _worldCameraPositionTweener.Easing, true, _worldCameraPositionTweener);
	}

	private void OnRevealSpawnerRoutineCompleted(PLCoroutine coroutine, bool stopped)
	{
		_worldCameraController.enabled = true;
		RemoveMovementBlocker(this);
	}

	public void AddMovementBlocker(UnityEngine.Object movementBlocker)
	{
		if (_movementBlockers.AddUnique(movementBlocker))
		{
			ClearMouseMovementTarget();
			EndKeyMovement();
		}
	}

	public void RemoveMovementBlocker(UnityEngine.Object movementBlocker)
	{
		_movementBlockers.Remove(movementBlocker);
	}

	public void SetMouseMovementTarget(Vector3 target, MouseMovementCursorProperties.Gear gear)
	{
		if (!IsTownMovementBlocked)
		{
			StopAllMovement();
			_mouseMovementTargetActive = true;
			_townheartPhysics.SetMouseMovementTargetAndDirection(target, gear);
			if (!_townheart.IsMoving)
			{
				_townheart.OnStartMove();
				MovementEvent.DispatchStartedMoving();
			}
		}
	}

	public void ClearMouseMovementTarget()
	{
		if (_mouseMovementTargetActive)
		{
			_mouseMovementTargetActive = false;
			_townheart.OnEndMove();
			_townheartPhysics.StopMouseMovement();
			MovementEvent.DispatchStoppedMoving();
		}
	}

	public void EnablePlanningPath()
	{
		_planningPath.Enable();
		_planningPath.DisableEndPositionMarker();
		GameManager.UIManager.WorldMapCanvas.SetCostTooltipActive(active: true);
	}

	public void UpdatePlanningPath(MapPath path)
	{
		_planningPath.UpdatePath(path);
		UpdatePlannedDistanceMarkers(path);
	}

	private void UpdatePlannedDistanceMarkers(MapPath path)
	{
		float energyCost = _playerCommunity.Engine.ReturnEnergyCost(path.Length);
		float unitsPerNode = GameManager.Settings.GameplaySettings.UnitsPerNode;
		int num = (int)(path.Length / unitsPerNode);
		int i;
		for (i = 0; i <= num; i++)
		{
			WorldMapEnergyCostMarker worldMapEnergyCostMarker;
			if (i < _distanceMarkers.Count)
			{
				worldMapEnergyCostMarker = _distanceMarkers[i];
			}
			else
			{
				worldMapEnergyCostMarker = UnityEngine.Object.Instantiate(_energyCostMarkerPrefab, base.transform);
				_distanceMarkers.Add(worldMapEnergyCostMarker);
			}
			if (!worldMapEnergyCostMarker.gameObject.activeSelf)
			{
				worldMapEnergyCostMarker.gameObject.SetActive(value: true);
			}
			float num2 = (float)i * unitsPerNode;
			Vector2 position = path.ReturnPosition(num2);
			bool inRange = num2 < _engine.ReturnEnergyRange();
			worldMapEnergyCostMarker.Initialize(_playerCommunity.Engine.ReturnEnergyCost(num2), position, _worldCameraController, inRange);
		}
		for (; i < _distanceMarkers.Count; i++)
		{
			WorldMapEnergyCostMarker worldMapEnergyCostMarker = _distanceMarkers[i];
			if (worldMapEnergyCostMarker.gameObject.activeSelf)
			{
				worldMapEnergyCostMarker.gameObject.SetActive(value: false);
			}
		}
		Vector2 vector = path.ReturnLerpedPosition(1f);
		GameManager.UIManager.WorldMapCanvas.UpdateCostTooltip(energyCost, _worldCameraController.Camera.WorldToScreenPoint(new Vector3(vector.x, 0f, vector.y)));
	}

	public bool TrySetPlanningPath(MapPath path)
	{
		EnablePlanningPath();
		UpdatePlanningPath(path);
		GameManager.UIManager.WorldMapCanvas.MovementButton.gameObject.SetActive(value: true);
		if (path.EvaluatedState == MapPath.State.Ok)
		{
			_planningPath.EnableEndPositionMarker(path.Destination);
		}
		else
		{
			_planningPath.DisableEndPositionMarker();
		}
		return true;
	}

	public void DisablePlanningPath()
	{
		_planningPath.Disable();
		GameManager.UIManager.WorldMapCanvas.MovementButton.gameObject.SetActive(value: false);
		GameManager.UIManager.WorldMapCanvas.SetCostTooltipActive(active: false);
		foreach (WorldMapEnergyCostMarker distanceMarker in _distanceMarkers)
		{
			distanceMarker.gameObject.SetActive(value: false);
		}
	}

	public void SetMovementPath(MapPath path)
	{
		if (path.EvaluatedState == MapPath.State.Ok)
		{
			_movementPath.Enable();
			UpdateWorldMapPath(_movementPath, path);
			_movementPath.EnableEndPositionMarker(path.Destination);
			DisablePlanningPath();
		}
	}

	public void DisableMovementPath()
	{
		_movementPath.Disable();
	}

	public void ClearMovementPath()
	{
		_movementPath.Disable();
	}

	private void UpdateWorldMapPath(WorldMapPath worldMapPath, MapPath path)
	{
		if (path.EvaluatedState == MapPath.State.Ok)
		{
			worldMapPath.SetCanReach();
		}
		else
		{
			worldMapPath.SetCannotReach(path);
		}
		worldMapPath.SetPathPositions(path, 0f);
	}

	public void TriggerMovementPress(BaseEventData eventData)
	{
		if ((eventData as PointerEventData).button == PointerEventData.InputButton.Left)
		{
			OnMovementPress.Invoke();
		}
	}

	private void OnBoatBuilt()
	{
		_boatRadiusRenderer.SetActive(_playerCommunity.HasBoat());
	}

	private void OnAgentAdded(GameEvent gameEvent)
	{
		SpawnAgentVisual((gameEvent as AgentEvent).Agent);
	}

	private void SpawnAgentVisual(Agent agent)
	{
	}

	public void MoveTo(MapPath path)
	{
		if (path.EvaluatedState == MapPath.State.Ok && !IsTownMovementBlocked)
		{
			StopAllMovement();
			SetMovementPath(path);
			_movementCoroutine = StartCoroutine(MoveToCoroutine(path));
		}
	}

	private IEnumerator MoveToCoroutine(MapPath path)
	{
		IsMoving = true;
		if (!_townheart.IsMoving)
		{
			_townheart.OnStartMove();
			MovementEvent.DispatchStartedMoving();
		}
		float progress = 0f;
		float movementLerpSpeed = _movementSpeed / path.Length;
		Vector3 vector = path.ReturnLerpedPosition(Mathf.Clamp(movementLerpSpeed * GameSpeedManager.PausableUnscaledDeltaTime, 0f, 1f)).Vector3TopDown();
		Quaternion startRotation = _townheart.transform.rotation;
		Quaternion endRotation = Quaternion.LookRotation(vector - _townheart.transform.position);
		float num = Quaternion.Angle(startRotation, endRotation);
		float rotationLerpSpeed = _rotationSpeed / num;
		while (progress < 1f)
		{
			progress += Mathf.Clamp(rotationLerpSpeed * GameSpeedManager.PausableUnscaledDeltaTime, 0f, 1f);
			_townheart.transform.rotation = Quaternion.Lerp(startRotation, endRotation, progress);
			yield return null;
		}
		progress = 0f;
		movementLerpSpeed = _movementSpeed / path.Length;
		while (progress < 1f)
		{
			progress += Mathf.Clamp(movementLerpSpeed * GameSpeedManager.PausableUnscaledDeltaTime, 0f, 1f);
			vector = path.ReturnLerpedPosition(progress).Vector3TopDown();
			float num2 = Vector3.Distance(_townheart.transform.position, vector);
			if (!_engine.ConsumeEnergy(num2))
			{
				break;
			}
			_distanceMoved += num2;
			_townheart.transform.LookAt(vector);
			SetTownheartPosition(vector);
			if (WorldManager.TryReturnClosestRoadInRange(out var closestRoad, vector, 150f))
			{
				Debug.LogFormat("_townheart is in range of the {0}", closestRoad.Name);
			}
			_movementPath.SetPathPositions(path, progress);
			yield return null;
		}
		StopMovementCoroutine();
		_townheart.OnEndMove();
		MovementEvent.DispatchStoppedMoving();
	}

	private void StopMovementCoroutine()
	{
		if (_movementCoroutine != null)
		{
			StopCoroutine(_movementCoroutine);
			IsMoving = false;
			DisableMovementPath();
			_movementCoroutine = null;
		}
	}

	public void StopAllMovement()
	{
		StopMovementCoroutine();
		_movementWithKeys = false;
	}

	private void StartKeyMovement()
	{
		if (!_movementWithKeys && !IsTownMovementBlocked)
		{
			StopAllMovement();
			_movementWithKeys = true;
			if (!_townheart.IsMoving)
			{
				_townheart.OnStartMove();
				MovementEvent.DispatchStartedMoving();
			}
		}
	}

	private void EndKeyMovement()
	{
		if (_movementWithKeys)
		{
			_movementWithKeys = false;
			_townheart.OnEndMove();
			MovementEvent.DispatchStoppedMoving();
		}
	}

	private void SetTownheartPosition(Vector3 position)
	{
		_townheart.transform.position = position;
		if (_zoomCloseToLandmarks)
		{
			ZoomNearLandmarks(position);
		}
	}

	private void ZoomNearLandmarks(Vector3 position)
	{
		if (_worldCameraController.ZoomController.IsPlayerZooming)
		{
			return;
		}
		Vector3 edgeStart;
		Vector3 edgeEnd;
		float distance;
		Vector3 a = ReturnClosestWorldmapLandmark(position).ReturnClosestPolygonPosition(position, out edgeStart, out edgeEnd, out distance);
		float landmarkZoomRadius = _landmarkZoomRadius;
		float num = GameplaySettings.ReturnConstructionRadius();
		float num2 = Vector3.Distance(a, position);
		if (num2 < landmarkZoomRadius)
		{
			float currentZoomLevel = _worldCameraController.ZoomController.CurrentZoomLevel;
			float t = (num2 - num) / (landmarkZoomRadius - num);
			float num3 = Mathf.Lerp(0.01f, 1f, t);
			if (num3 < currentZoomLevel)
			{
				_worldCameraController.ZoomController.SetDesiredZoom(num3, _landmarkZoomSmoothness);
			}
		}
	}

	public void OpenNextBiomePopup()
	{
		if (PopUpDialog.Instance.TryOpenPopUpDialog(_nextBiomeDialog))
		{
			PopUpDialog.Instance.DialogFeedbackEvent.AddListener(OnBiomeDialogResponse);
		}
	}

	private void OnBiomeDialogResponse(bool feedback)
	{
		PopUpDialog.Instance.DialogFeedbackEvent.RemoveListener(OnBiomeDialogResponse);
		if (feedback)
		{
			MoveToNextBiome();
		}
	}

	private void MoveToNextBiome()
	{
		if (Application.isEditor && _debugNextBiome)
		{
			MoveToNextBiomeTask();
		}
		else
		{
			LoadingScreen.LoadTask(MoveToNextBiomeTask, _fadeColor, _fadeTime, "Load Next Biome");
		}
	}

	private void MoveToNextBiomeTask()
	{
		World world = GameManager.WorldManager.World;
		_playerCommunity.StopNonInteractableProjects(Vector3.zero);
		world.UpdateTileProperties(GameManager.Settings.WorldSettings.DefaultTileProperties);
		foreach (WorldMapTile tile in _tiles)
		{
			UnityEngine.Object.Destroy(tile.gameObject);
		}
		_tiles.Clear();
		_townheart.Teleport(world.TownheartWorldPosition, world.TownheartRotation);
		CameraController.Instance.LoadPreset();
		InitializeCameraPositionAndRotation();
		_worldCameraController.ZoomController.SetZoom(0f, overwriteDesiredZoom: true);
		InitializeVisuals(world);
		GameManager.CursorManager.Activate(_movementCursorProperties);
		_compass.UpdateBearings();
		MovementEvent.DispatchTownheartMove(world.TownheartWorldPosition, world.TownheartWorldPosition, world.TownheartRotation, world.TownheartRotation, 0f);
		Deactivate();
	}

	private void InitializeCameraPositionAndRotation()
	{
		_worldCameraController.enabled = true;
		_worldCameraController.transform.rotation = _townheart.transform.rotation * CameraController.Instance.transform.rotation;
		Vector3 vector = _townheart.transform.rotation * CameraController.Instance.transform.position;
		_worldCameraController.SetRelativePosition(vector);
		_worldCameraController.transform.position = _townheart.transform.position + vector;
	}

	public void Open()
	{
		if (!_isChangingState && !base.gameObject.activeInHierarchy)
		{
			_isChangingState = Fade.InOut(_fadeColor, _fadeTime, Activate, OnActivated);
		}
	}

	public bool Close()
	{
		if (CanBeClosed())
		{
			AddMovementBlocker(this);
			if (base.gameObject.activeInHierarchy)
			{
				_isChangingState = Fade.InOut(_fadeColor, _fadeTime, Deactivate, OnDeactiveted);
			}
			return true;
		}
		return false;
	}

	private void UpdateScouting()
	{
		float num = _defaultFOWRange;
		float scoutRange = _defaultScoutRange;
		if (WatchTower.Enabled)
		{
			num = _watchFOWRange;
			scoutRange = _watchTowerScoutRange;
		}
		WorldMapFogOfWar.ScoutArea(_townheart.Position, num);
		foreach (WorldMapTile tile in _tiles)
		{
			tile.UpdateScouting(_townheart.Position, num, scoutRange);
		}
	}

	private void OnActivated()
	{
		GameEventDispatcher.Dispatch(GameEventType.TransitionedToMapView);
	}

	private void OnDeactiveted()
	{
		GameEventDispatcher.Dispatch(GameEventType.TransitionedFromMapView);
	}

	public bool CanBeClosed()
	{
		if (!_isChangingState && (!(_townheart != null) || !_townheart.IsMoving) && (!WorldManager.TryReturnCurrentRegion(out var region) || !region.WorldTile.IsEndTile))
		{
			return !PLCoroutine.HasActiveCoroutines(this);
		}
		return false;
	}

	private LandmarkMapObstacle ReturnClosestObstacle()
	{
		LandmarkMapObstacle result = null;
		float num = float.MaxValue;
		foreach (LandmarkMapObstacle obstacle in Obstacles)
		{
			if (obstacle != null)
			{
				float num2 = Vector2.Distance(_townheart.transform.position.Vector2TopDown(), obstacle.Position);
				if (num2 < num)
				{
					result = obstacle;
					num = num2;
				}
			}
		}
		return result;
	}

	public bool HasLandmarkInSquareRadius(Vector2 center, float squareRadius)
	{
		foreach (WorldMapTile tile in _tiles)
		{
			if (tile.HasLandmarkInSquareRadius(center, squareRadius))
			{
				return true;
			}
		}
		return false;
	}

	public bool TryReturnPointOfInterest(out WorldMapPointOfInterest poi, ISpawner spawner)
	{
		foreach (WorldMapTile tile in _tiles)
		{
			if (tile.TryReturnPointOfInterest(out poi, spawner))
			{
				return true;
			}
		}
		poi = null;
		return false;
	}

	public bool TryReturnLandmarkInRadius(out WorldMapLandmark landmark, Vector2 center, float radius)
	{
		throw new NotSupportedException();
	}

	public bool TryReturnRaycastLandmark(out WorldMapLandmark landmark, Ray ray, Vector2 center, float radius)
	{
		foreach (WorldMapTile tile in _tiles)
		{
			if (tile.TryReturnRaycastLandmarkInRadius(out landmark, ray, center, radius))
			{
				return true;
			}
		}
		landmark = null;
		return false;
	}

	public float ReturnTileSpawningRange()
	{
		return _watchFOWRange;
	}

	public WorldMapFogOfWar.PersistentData ReturnFogOfWarPersistentData(WorldTile worldTile)
	{
		foreach (WorldMapTile tile in _tiles)
		{
			if (tile.WorldTile == worldTile)
			{
				return tile.ReturnFogOfWarPersistentData();
			}
		}
		return null;
	}

	private WorldMapLandmark ReturnClosestWorldmapLandmark(Vector3 position)
	{
		float num = float.MaxValue;
		WorldMapLandmark result = null;
		foreach (WorldMapTile tile in _tiles)
		{
			WorldMapLandmark worldMapLandmark = tile.ReturnClosestWorldmapLandmark(position);
			float num2 = worldMapLandmark.transform.position.DistanceToSquared(position);
			if (num2 < num)
			{
				num = num2;
				result = worldMapLandmark;
			}
		}
		return result;
	}

	public IReadOnlyList<WorldMapFlotsam> GetAllFlotsam()
	{
		_allFlotsam.Clear();
		foreach (WorldMapTile tile in _tiles)
		{
			_allFlotsam.AddRange(tile.GetAllFlotsam());
		}
		return _allFlotsam;
	}
}
