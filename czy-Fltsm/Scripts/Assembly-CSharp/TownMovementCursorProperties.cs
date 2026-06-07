using PajamaLlama.Math;
using UnityEngine;
using UnityEngine.EventSystems;

[CreateAssetMenu(menuName = "Flotsam/Cursor Properties/Town Movement")]
public class TownMovementCursorProperties : CursorProperties
{
	private enum Stage
	{
		PathCalculation = 0,
		ConfirmPanel = 1,
		Moving = 2
	}

	[Header("Alternate cursors")]
	[SerializeField]
	private CursorState _outOfRangeCursor = CursorState.Unselectable;

	[SerializeField]
	private CursorState _blockedLandmarkCursor = CursorState.Unselectable;

	[SerializeField]
	private CursorState _overLandmarkCursor = CursorState.OverLandmark;

	[SerializeField]
	private MapPathCalculator _mapPathCalculator;

	[Header("Audio")]
	[SerializeField]
	private AudioClipProperties _arrowLongerAudio;

	[SerializeField]
	private AudioClipProperties _arrowShorterAudio;

	private LayerMask _mapMask;

	private WorldMap _worldMap;

	private Camera _camera;

	private Engine _engine;

	private MapPath _planningPath;

	private MapPath _movementPath;

	private bool _planningPathSet;

	private FMODEvent _arrowShorterEvent;

	private FMODEvent _arrowLongerEvent;

	private void OnDestroy()
	{
		if (_arrowLongerEvent != null)
		{
			_arrowLongerEvent.Dispose();
		}
		if (_arrowShorterEvent != null)
		{
			_arrowShorterEvent.Dispose();
		}
	}

	public override void UpdateCursor(CursorManager cursor)
	{
		if (!Physics.Raycast(_camera.ScreenPointToRay(FlotsamInputManager.MousePosition), out var hitInfo, float.PositiveInfinity, _mapMask))
		{
			return;
		}
		Vector3 point = hitInfo.point;
		if (base.Interact.GetButtonDoublePressUp())
		{
			MoveTown();
			return;
		}
		if (base.Cancel.GetButtonDown())
		{
			_worldMap.EnablePlanningPath();
			UpdatePlannedPath(point);
			_planningPathSet = false;
			return;
		}
		if (base.Cancel.GetButton())
		{
			UpdatePlannedPath(point);
			UpdateCursor(_planningPath);
			PlayArrowAudio(Mathf.RoundToInt(_planningPath.LengthDifference));
			return;
		}
		if (base.Cancel.GetButtonUp())
		{
			_worldMap.DisablePlanningPath();
			return;
		}
		if (_worldMap.TryReturnLandmarkInRadius(out var landmark, point.Vector2TopDown(), GameplaySettings.ReturnConstructionRadius()))
		{
			base.Cursor = _overLandmarkCursor;
			if (base.Interact.GetButtonDown())
			{
				if (!EventSystem.current.IsPointerOverGameObject())
				{
					SetPlannedPath(landmark.SelectAndCalulateEntrancePosition());
				}
			}
			else if (_planningPathSet)
			{
				UpdatePlannedPath(_planningPath.Destination);
			}
			return;
		}
		base.Cursor = _defaultCursor;
		if (base.Interact.GetButtonDown())
		{
			if (!EventSystem.current.IsPointerOverGameObject())
			{
				SetPlannedPath(point);
			}
		}
		else if (_planningPathSet)
		{
			UpdatePlannedPath(_planningPath.Destination);
		}
	}

	public override bool TryToDeactivate(CursorManager cursor)
	{
		return false;
	}

	public void UpdatePlannedPath(Vector3 destination)
	{
		_planningPath.CalculatePath(destination);
		_worldMap.UpdatePlanningPath(_planningPath);
	}

	public void SetPlannedPath(Vector3 destination)
	{
		_planningPath.CalculatePath(destination);
		if (_worldMap.TrySetPlanningPath(_planningPath))
		{
			_planningPathSet = true;
		}
		else
		{
			UpdateCursor(_planningPath);
		}
	}

	public override void Activate()
	{
		_mapMask = GameManager.Settings.WorldSettings.MapPlaneCollisionLayer;
		_worldMap = GameManager.WorldMapManager.WorldMap;
		_engine = Community.PlayerCommunity.Engine;
		_camera = Camera.main;
		_worldMap.OnMovementPress.AddListener(MoveTown);
		GameManager.UIManager.WorldMapCanvas.MovementButton.gameObject.SetActive(value: false);
		_planningPath = new MapPath(_mapPathCalculator, _worldMap.Obstacles, _worldMap.Townheart.transform);
		_planningPath.AddStateEvaluator(new MapPathOutOfRangeEvaluator(_engine));
		_planningPath.AddStateEvaluator(new MapPathBlockedEvaluator(_worldMap, GameManager.Settings.GameplaySettings.ConstructionRadius));
		_planningPathSet = false;
		_movementPath = new MapPath(_mapPathCalculator, _worldMap.Obstacles, _worldMap.Townheart.transform);
		if (_arrowShorterEvent == null)
		{
			_arrowShorterEvent = new FMODEvent(_arrowShorterAudio);
		}
		if (_arrowLongerEvent == null)
		{
			_arrowLongerEvent = new FMODEvent(_arrowLongerAudio);
		}
	}

	public override void DeactivateImmediately()
	{
		_worldMap.DisablePlanningPath();
		_worldMap.DisableMovementPath();
		_worldMap.OnMovementPress.RemoveListener(MoveTown);
	}

	private void UpdateCursor(MapPath mapPath)
	{
		switch (mapPath.EvaluatedState)
		{
		case MapPath.State.DestinationOutOfRange:
			base.Cursor = _outOfRangeCursor;
			break;
		case MapPath.State.DestinationBlocked:
			base.Cursor = _blockedLandmarkCursor;
			break;
		case MapPath.State.Ok:
			base.Cursor = _defaultCursor;
			break;
		}
	}

	private void MoveTown()
	{
		if (_planningPath.EvaluatedState == MapPath.State.Ok)
		{
			_movementPath.CalculatePath(_planningPath.Destination);
			_worldMap.MoveTo(_movementPath);
			_planningPathSet = false;
		}
	}

	private void PlayArrowAudio(float distanceChanged)
	{
		if (Mathf.Abs(distanceChanged) > 1f)
		{
			if (distanceChanged > 0f)
			{
				_arrowLongerEvent.Unpause(start: true);
				_arrowShorterEvent.Pause();
			}
			else
			{
				_arrowLongerEvent.Pause();
				_arrowShorterEvent.Unpause(start: true);
			}
		}
		else
		{
			_arrowLongerEvent.Pause();
			_arrowShorterEvent.Pause();
		}
	}
}
