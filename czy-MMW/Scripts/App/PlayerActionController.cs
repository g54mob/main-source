using System;
using System.Collections.Generic;
using Factory;
using Motorways;
using UnityEngine;

public class PlayerActionController : IScopeObserver, IReleasedFromScopeHandler
{
	[Dependency]
	private IScope _appScope;

	private IScope _gameScope;

	[Dependency]
	private IInputState _inputState;

	private Dictionary<InputEventFilter, List<Func<PlayerActionGroup, IScope, float, PlayerAction>>> _inputEventFilterToPlayerActionConstructors = new Dictionary<InputEventFilter, List<Func<PlayerActionGroup, IScope, float, PlayerAction>>>();

	private Dictionary<IScope, List<Func<PlayerActionGroup, IScope, float, PlayerAction>>> _owningScopeToConstructors = new Dictionary<IScope, List<Func<PlayerActionGroup, IScope, float, PlayerAction>>>();

	private List<PlayerActionGroup> _activePlayerActionGroups = new List<PlayerActionGroup>();

	private List<IScope> activeScopes = new List<IScope>();

	private bool _gameActionsBlocked;

	private bool _tutorialActionsBlocked;

	public IEnumerable<PlayerActionGroup> ActiveGroups => _activePlayerActionGroups;

	public int ActivePlayerActionCount => _activePlayerActionGroups.Count;

	public int BlockingPlayerActionCount
	{
		get
		{
			int num = 0;
			foreach (PlayerActionGroup activePlayerActionGroup in _activePlayerActionGroups)
			{
				if (!activePlayerActionGroup.IsInterruptible)
				{
					num++;
				}
			}
			return num;
		}
	}

	public bool TutorialBlockInputFlag
	{
		get
		{
			return _tutorialActionsBlocked;
		}
		set
		{
			_tutorialActionsBlocked = value;
			SetScopeActive(_gameScope, !_gameActionsBlocked && !_tutorialActionsBlocked);
		}
	}

	public void SetGameScope(IScope gameScope)
	{
		if (Diagnostics.Verify(_gameScope == null))
		{
			_gameScope = gameScope;
		}
	}

	public void GameEnded()
	{
		if (Diagnostics.Verify(_gameScope != null))
		{
			_gameScope = null;
		}
	}

	public void UpdateBlockFlags(InputState.BlockInput blockInputFlags)
	{
		bool isActive = true;
		_gameActionsBlocked = (blockInputFlags & InputState.BlockInput.BlockGame) != 0;
		SetScopeActive(_appScope, isActive);
		SetScopeActive(_gameScope, !_gameActionsBlocked && !_tutorialActionsBlocked);
	}

	public void SetScopeActive(IScope scope, bool isActive)
	{
		if (isActive)
		{
			if (!activeScopes.Contains(scope))
			{
				activeScopes.Add(scope);
			}
		}
		else if (activeScopes.Contains(scope))
		{
			activeScopes.Remove(scope);
		}
	}

	public bool RegisterAction(InputEventFilter inputEventFilter, Func<PlayerActionGroup, IScope, float, PlayerAction> playerActionConstructor, IScope toScope, bool ignorePollingAxis = false)
	{
		if (!_inputEventFilterToPlayerActionConstructors.ContainsKey(inputEventFilter))
		{
			_inputEventFilterToPlayerActionConstructors.Add(inputEventFilter, new List<Func<PlayerActionGroup, IScope, float, PlayerAction>>());
		}
		if (!_owningScopeToConstructors.ContainsKey(toScope))
		{
			_owningScopeToConstructors.Add(toScope, new List<Func<PlayerActionGroup, IScope, float, PlayerAction>>());
			toScope.Subscribe(this);
		}
		if (Diagnostics.Verify(!_inputEventFilterToPlayerActionConstructors[inputEventFilter].Contains(playerActionConstructor)))
		{
			_inputEventFilterToPlayerActionConstructors[inputEventFilter].Add(playerActionConstructor);
			if (!_owningScopeToConstructors[toScope].Contains(playerActionConstructor))
			{
				_owningScopeToConstructors[toScope].Add(playerActionConstructor);
			}
			if (!ignorePollingAxis)
			{
				if (inputEventFilter.ExpectedButtonState == InputEventButtonState.Axis)
				{
					_inputState.EnsurePollingAxis(inputEventFilter.RewiredAction);
				}
				else
				{
					_inputState.EnsurePollingRewiredAction(inputEventFilter.RewiredAction);
				}
			}
			return true;
		}
		return false;
	}

	protected void CleanupEmptyDictionaryEntries()
	{
		List<InputEventFilter> list = new List<InputEventFilter>();
		foreach (KeyValuePair<InputEventFilter, List<Func<PlayerActionGroup, IScope, float, PlayerAction>>> inputEventFilterToPlayerActionConstructor in _inputEventFilterToPlayerActionConstructors)
		{
			if (inputEventFilterToPlayerActionConstructor.Value.Count == 0)
			{
				list.Add(inputEventFilterToPlayerActionConstructor.Key);
			}
		}
		for (int i = 0; i < list.Count; i++)
		{
			_inputEventFilterToPlayerActionConstructors.Remove(list[i]);
		}
		List<IScope> list2 = new List<IScope>();
		foreach (KeyValuePair<IScope, List<Func<PlayerActionGroup, IScope, float, PlayerAction>>> owningScopeToConstructor in _owningScopeToConstructors)
		{
			if (owningScopeToConstructor.Value.Count == 0)
			{
				owningScopeToConstructor.Key.Unsubscribe(this);
				list2.Add(owningScopeToConstructor.Key);
			}
		}
		for (int j = 0; j < list2.Count; j++)
		{
			_owningScopeToConstructors.Remove(list2[j]);
		}
	}

	public void UnregisterAction<PlayerActionType>(IScope optionalScopeFilter = null) where PlayerActionType : PlayerAction
	{
		foreach (KeyValuePair<InputEventFilter, List<Func<PlayerActionGroup, IScope, float, PlayerAction>>> inputEventFilterToPlayerActionConstructor in _inputEventFilterToPlayerActionConstructors)
		{
			int num = 0;
			while (num < inputEventFilterToPlayerActionConstructor.Value.Count)
			{
				if (inputEventFilterToPlayerActionConstructor.Value[num].Method.ReturnType == typeof(PlayerActionType))
				{
					bool flag = optionalScopeFilter == null;
					foreach (KeyValuePair<IScope, List<Func<PlayerActionGroup, IScope, float, PlayerAction>>> owningScopeToConstructor in _owningScopeToConstructors)
					{
						if (owningScopeToConstructor.Value.Contains(inputEventFilterToPlayerActionConstructor.Value[num]))
						{
							if (owningScopeToConstructor.Key == optionalScopeFilter)
							{
								flag = true;
							}
							owningScopeToConstructor.Value.Remove(inputEventFilterToPlayerActionConstructor.Value[num]);
						}
					}
					if (flag)
					{
						inputEventFilterToPlayerActionConstructor.Value.RemoveAt(num);
					}
				}
				else
				{
					num++;
				}
			}
		}
		CleanupEmptyDictionaryEntries();
	}

	public void OnInputEvent(float timestamp, InputEvent inputEvent)
	{
		bool flag = _inputState.IsInputEventOverUI(inputEvent);
		bool flag2 = false;
		foreach (PlayerActionGroup activePlayerActionGroup in _activePlayerActionGroups)
		{
			if (activePlayerActionGroup.ObservesInputEvent(inputEvent))
			{
				flag2 |= activePlayerActionGroup.BlocksNewActionsForInputEvent(inputEvent);
				activePlayerActionGroup.ObserveInput(timestamp, inputEvent, flag);
			}
		}
		if (flag2 || (flag && !(inputEvent is MotorwaysUIInputEvent)))
		{
			return;
		}
		List<Func<PlayerActionGroup, IScope, float, PlayerAction>> list = null;
		foreach (KeyValuePair<InputEventFilter, List<Func<PlayerActionGroup, IScope, float, PlayerAction>>> inputEventFilterToPlayerActionConstructor in _inputEventFilterToPlayerActionConstructors)
		{
			if (!inputEventFilterToPlayerActionConstructor.Key.MatchesEvent(inputEvent))
			{
				continue;
			}
			foreach (Func<PlayerActionGroup, IScope, float, PlayerAction> item in inputEventFilterToPlayerActionConstructor.Value)
			{
				foreach (KeyValuePair<IScope, List<Func<PlayerActionGroup, IScope, float, PlayerAction>>> owningScopeToConstructor in _owningScopeToConstructors)
				{
					if (owningScopeToConstructor.Value.Contains(item) && activeScopes.Contains(owningScopeToConstructor.Key))
					{
						if (list == null)
						{
							list = new List<Func<PlayerActionGroup, IScope, float, PlayerAction>>();
						}
						list.Add(item);
						break;
					}
				}
			}
		}
		if (list == null)
		{
			return;
		}
		IScope arg = _gameScope ?? _appScope;
		PlayerActionGroup playerActionGroup = _appScope.Get<PlayerActionGroup>();
		playerActionGroup.Initialize(timestamp, inputEvent);
		bool flag3 = false;
		foreach (Func<PlayerActionGroup, IScope, float, PlayerAction> item2 in list)
		{
			if (playerActionGroup.CanAddNewActions)
			{
				PlayerAction playerAction = item2(playerActionGroup, arg, timestamp);
				flag3 |= !playerAction.IsInterruptible;
			}
		}
		if (flag3)
		{
			foreach (PlayerActionGroup activePlayerActionGroup2 in _activePlayerActionGroups)
			{
				foreach (PlayerAction action in activePlayerActionGroup2.Actions)
				{
					if (action.InputSourceType != inputEvent.Source)
					{
						activePlayerActionGroup2.CancelAllActions();
						break;
					}
				}
			}
		}
		_activePlayerActionGroups.Add(playerActionGroup);
	}

	public void Tick(float frameTime)
	{
		for (int num = _activePlayerActionGroups.Count - 1; num >= 0; num--)
		{
			if (_activePlayerActionGroups[num].IsSafeToRemove)
			{
				_appScope.Release(_activePlayerActionGroups[num]);
				_activePlayerActionGroups.RemoveAt(num);
				PlayerAction.Log.Info("Removing empty PlayerActionGroup.");
			}
			else
			{
				_activePlayerActionGroups[num].Tick(frameTime);
			}
		}
	}

	public void DebugGUI()
	{
		if (FeatureToggle.IsFeatureDisabled(Feature.PlayerActionView))
		{
			return;
		}
		Rect position = new Rect(10f, 50f, 1000f, 40f);
		GUI.Label(position, "PLAYER ACTIONS:");
		position.y += 50f;
		foreach (PlayerActionGroup activePlayerActionGroup in _activePlayerActionGroups)
		{
			foreach (PlayerAction action in activePlayerActionGroup.Actions)
			{
				GUI.Label(position, $"{action.GetType()}| Instigating Type: {action.OwningGroup.InstigatingInputEvent.Source} | Is Interruptible: {action.IsInterruptible}");
				position.y += 50f;
			}
		}
	}

	public void InterruptActions<PlayerActionType>() where PlayerActionType : PlayerAction
	{
		for (int num = _activePlayerActionGroups.Count - 1; num >= 0; num--)
		{
			if (_activePlayerActionGroups[num].HasActionType<PlayerActionType>())
			{
				_activePlayerActionGroups[num].RemoveActionType<PlayerActionType>();
			}
		}
	}

	public void CancelAllActions()
	{
		PlayerAction.Log.Info("Cancelling all actions!");
		foreach (PlayerActionGroup activePlayerActionGroup in _activePlayerActionGroups)
		{
			activePlayerActionGroup.CancelAllActions();
		}
	}

	public void OnScopeReleased(IScope scopeBeingReleased)
	{
		if (!Diagnostics.Verify(_owningScopeToConstructors.ContainsKey(scopeBeingReleased), "A scope is reporting being released, but we don't have any actions registered for it!"))
		{
			return;
		}
		for (int i = 0; i < _owningScopeToConstructors[scopeBeingReleased].Count; i++)
		{
			Func<PlayerActionGroup, IScope, float, PlayerAction> item = _owningScopeToConstructors[scopeBeingReleased][i];
			foreach (KeyValuePair<InputEventFilter, List<Func<PlayerActionGroup, IScope, float, PlayerAction>>> inputEventFilterToPlayerActionConstructor in _inputEventFilterToPlayerActionConstructors)
			{
				inputEventFilterToPlayerActionConstructor.Value.Remove(item);
			}
		}
		_owningScopeToConstructors.Remove(scopeBeingReleased);
	}

	public void OnReleasedFromScope(IScope scope)
	{
		foreach (KeyValuePair<IScope, List<Func<PlayerActionGroup, IScope, float, PlayerAction>>> owningScopeToConstructor in _owningScopeToConstructors)
		{
			owningScopeToConstructor.Key.Unsubscribe(this);
		}
		_inputEventFilterToPlayerActionConstructors.Clear();
		_owningScopeToConstructors.Clear();
		foreach (PlayerActionGroup activePlayerActionGroup in _activePlayerActionGroups)
		{
			_appScope.Release(activePlayerActionGroup);
		}
		_activePlayerActionGroups.Clear();
		_gameScope = null;
	}
}
