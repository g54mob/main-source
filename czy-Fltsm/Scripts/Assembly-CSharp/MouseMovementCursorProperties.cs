using PajamaLlama.Math;
using UnityEngine;
using UnityEngine.EventSystems;

[CreateAssetMenu(menuName = "Flotsam/Cursor Properties/Mouse Movement")]
public class MouseMovementCursorProperties : CursorProperties
{
	public enum Gear
	{
		Neutral = 0,
		Forward = 1,
		Reverse = 2,
		ForwardReverse = 3
	}

	[SerializeField]
	private MapPathCalculator _mapPathCalculator;

	[SerializeField]
	[Tooltip("The angle between the cursor position and the town forward at which the town will move forward, otherwise the town will move in reverse")]
	private float _forwardAngle = 120f;

	private WorldMap _worldMap;

	private LayerMask _mapMask;

	private Engine _engine;

	private Camera _camera;

	private MapPath _path;

	private Gear _gear;

	public override void Activate()
	{
		_mapMask = GameManager.Settings.WorldSettings.MapPlaneCollisionLayer;
		_worldMap = GameManager.WorldMapManager.WorldMap;
		_engine = Community.PlayerCommunity.Engine;
		_camera = Camera.main;
		_gear = Gear.Neutral;
		if (_path == null || _path.Origin == null)
		{
			_path = new MapPath(_mapPathCalculator, _worldMap.Obstacles, _worldMap.Townheart.transform);
			_path.AddStateEvaluator(new MapPathOutOfRangeEvaluator(_engine));
			_path.AddStateEvaluator(new MapPathBlockedEvaluator(_worldMap, GameManager.Settings.GameplaySettings.ConstructionRadius));
		}
		base.Cursor = CursorState.Move;
	}

	public override bool TryToDeactivate(CursorManager cursor)
	{
		return false;
	}

	public override void DeactivateImmediately()
	{
	}

	public override void UpdateCursor(CursorManager cursor)
	{
		Ray ray = _camera.ScreenPointToRay(FlotsamInputManager.MousePosition);
		bool flag = false;
		if (Physics.Raycast(ray, out var hitInfo, float.PositiveInfinity, _mapMask))
		{
			flag = _worldMap.TryReturnRaycastLandmark(out var _, ray, hitInfo.point.Vector2TopDown(), GameplaySettings.ReturnConstructionRadius());
			if (base.Interact.GetButtonDown() && !EventSystem.current.IsPointerOverGameObject())
			{
				Transform transform = _worldMap.Townheart.transform;
				if (Vector3.Angle(hitInfo.point.Vector3TopDown() - transform.position.Vector3TopDown(), _worldMap.Townheart.transform.forward) <= _forwardAngle)
				{
					_gear = Gear.Forward;
				}
				else
				{
					_gear = Gear.Reverse;
				}
			}
			if (_gear != Gear.Neutral && base.Interact.GetButtonTimedPress(0.15f))
			{
				_worldMap.SetMouseMovementTarget(hitInfo.point.Vector3TopDown(), (Gear.Forward == _gear && base.Cancel.GetButton()) ? Gear.ForwardReverse : _gear);
			}
			if (base.Interact.GetButton())
			{
				return;
			}
			_worldMap.ClearMouseMovementTarget();
			_gear = Gear.Neutral;
		}
		base.Cursor = (flag ? CursorState.OverLandmark : CursorState.Move);
	}
}
