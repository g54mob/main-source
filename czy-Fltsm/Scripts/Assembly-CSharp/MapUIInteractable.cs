using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class MapUIInteractable : UIInteractable
{
	[SerializeField]
	private bool _enableMap = true;

	[SerializeField]
	private Button _button;

	private WorldMap _worldMap;

	private bool _worldMapIsMoving;

	protected override void Awake()
	{
		base.Awake();
		GameEventDispatcher.AddListener(GameEventType.WorldMapStartedMoving, OnMapMovementStart);
		GameEventDispatcher.AddListener(GameEventType.WorldMapStoppedMoving, OnMapMovementStop);
	}

	private void OnEnable()
	{
		_worldMap = GameManager.WorldMapManager.WorldMap;
	}

	private void LateUpdate()
	{
		SetInteractable((bool)_worldMap && !_worldMapIsMoving && (_enableMap || _worldMap.CanBeClosed()));
	}

	protected override void OnDestroy()
	{
		base.OnDestroy();
		GameEventDispatcher.RemoveListener(GameEventType.WorldMapStartedMoving, OnMapMovementStart);
		GameEventDispatcher.RemoveListener(GameEventType.WorldMapStoppedMoving, OnMapMovementStop);
	}

	public override void Interact()
	{
		if (base.IsInteractable)
		{
			base.Interact();
			if (_enableMap)
			{
				GameManager.WorldMapManager.WorldMap.Open();
			}
			else
			{
				GameManager.WorldMapManager.WorldMap.Close();
			}
		}
	}

	private void SetInteractable(bool interactable)
	{
		if (base.IsInteractable != interactable)
		{
			base.IsInteractable = interactable;
			if ((bool)_button)
			{
				_button.interactable = interactable;
			}
		}
	}

	private void OnMapMovementStart(GameEvent gameEvent)
	{
		_worldMapIsMoving = true;
	}

	private void OnMapMovementStop(GameEvent gameEvent)
	{
		_worldMapIsMoving = false;
	}
}
