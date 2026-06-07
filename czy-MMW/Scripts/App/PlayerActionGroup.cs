using System.Collections.Generic;
using Factory.Pools;

public class PlayerActionGroup : IReusable
{
	private float _creationTimestamp;

	private List<PlayerAction> _activePlayerActions = new List<PlayerAction>();

	private List<PlayerAction> _pendingRemovalPlayerActions = new List<PlayerAction>();

	private bool _actionResolvedAsExclusive;

	public static Diagnostics.Log.Channel Log = Diagnostics.Log.OpenChannel("PlayerActionGroup");

	public IEnumerable<PlayerAction> Actions => _activePlayerActions;

	public bool HasExclusiveAction
	{
		get
		{
			if (_activePlayerActions.Count != 1)
			{
				return _actionResolvedAsExclusive;
			}
			return true;
		}
	}

	public bool IsSafeToRemove => _activePlayerActions.Count == 0;

	public bool IsInterruptible
	{
		get
		{
			foreach (PlayerAction activePlayerAction in _activePlayerActions)
			{
				if (!activePlayerAction.IsInterruptible)
				{
					return false;
				}
			}
			return true;
		}
	}

	public bool CanAddNewActions => !_actionResolvedAsExclusive;

	public InputEvent InstigatingInputEvent { get; private set; }

	public void MakeActionExclusive(PlayerAction action)
	{
		if (_actionResolvedAsExclusive)
		{
			return;
		}
		_actionResolvedAsExclusive = true;
		foreach (PlayerAction activePlayerAction in _activePlayerActions)
		{
			if (activePlayerAction != action)
			{
				activePlayerAction.OnActionCancel();
				Log.Info("Cancelling action due to exclusivity change: {0}", activePlayerAction.GetType().ToString());
			}
		}
	}

	public bool IsActionExclusive(PlayerAction action)
	{
		if (HasExclusiveAction)
		{
			return _activePlayerActions[0] == action;
		}
		return false;
	}

	public void Initialize(float timestamp, InputEvent instigatingEvent)
	{
		_creationTimestamp = timestamp;
		InstigatingInputEvent = instigatingEvent;
		_actionResolvedAsExclusive = false;
	}

	public bool AddAction(PlayerAction newAction)
	{
		if (CanAddNewActions)
		{
			_activePlayerActions.Add(newAction);
			newAction.OwningGroup = this;
			return true;
		}
		return false;
	}

	public void RemoveAction(PlayerAction action)
	{
		_pendingRemovalPlayerActions.Add(action);
	}

	public void CancelAllActions()
	{
		foreach (PlayerAction activePlayerAction in _activePlayerActions)
		{
			activePlayerAction.OnActionCancel();
		}
	}

	public void RemoveActionType<PlayerActionType>() where PlayerActionType : PlayerAction
	{
		foreach (PlayerAction activePlayerAction in _activePlayerActions)
		{
			if (activePlayerAction.GetType() == typeof(PlayerActionType))
			{
				activePlayerAction.OnActionComplete();
				RemoveAction(activePlayerAction);
			}
		}
	}

	public bool HasAction(PlayerAction action)
	{
		return _activePlayerActions.Contains(action);
	}

	public bool HasActionType<PlayerActionType>() where PlayerActionType : PlayerAction
	{
		foreach (PlayerAction activePlayerAction in _activePlayerActions)
		{
			if (activePlayerAction.GetType() == typeof(PlayerActionType))
			{
				return true;
			}
		}
		return false;
	}

	public bool ObservesInputEvent(InputEvent inputEvent)
	{
		bool flag = false;
		foreach (PlayerAction activePlayerAction in _activePlayerActions)
		{
			flag |= activePlayerAction.ObservesInputEvent(inputEvent);
		}
		return flag;
	}

	public bool BlocksNewActionsForInputEvent(InputEvent inputEvent)
	{
		bool flag = false;
		foreach (PlayerAction activePlayerAction in _activePlayerActions)
		{
			flag |= activePlayerAction.BlocksNewActionsForInputEvent(inputEvent);
		}
		return flag;
	}

	public void ObserveInput(float timestamp, InputEvent inputEvent, bool overUI)
	{
		foreach (PlayerAction activePlayerAction in _activePlayerActions)
		{
			if (activePlayerAction.ObservesInputEvent(inputEvent))
			{
				activePlayerAction.ObserveInput(timestamp, inputEvent, overUI);
			}
		}
	}

	public void Tick(float frameTime)
	{
		foreach (PlayerAction pendingRemovalPlayerAction in _pendingRemovalPlayerActions)
		{
			pendingRemovalPlayerAction.Scope.Release(pendingRemovalPlayerAction);
			_activePlayerActions.Remove(pendingRemovalPlayerAction);
		}
		_pendingRemovalPlayerActions.Clear();
		foreach (PlayerAction activePlayerAction in _activePlayerActions)
		{
			if (!_pendingRemovalPlayerActions.Contains(activePlayerAction))
			{
				activePlayerAction.Tick(frameTime);
			}
		}
	}

	public void Reset()
	{
		_creationTimestamp = 0f;
		_activePlayerActions.Clear();
		_pendingRemovalPlayerActions.Clear();
		_actionResolvedAsExclusive = false;
	}
}
