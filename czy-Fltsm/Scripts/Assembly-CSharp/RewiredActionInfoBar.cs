using System.Collections.Generic;
using UnityEngine;

public class RewiredActionInfoBar : MonoBehaviour
{
	private class Entry
	{
		private bool _enabled;

		private bool _visible;

		private GameObject _contextGO;

		public Object Context { get; private set; }

		public List<IRewiredAction> Actions { get; private set; }

		public uint Priority { get; private set; }

		public bool Visible
		{
			get
			{
				if (_enabled)
				{
					if (!(_contextGO == null))
					{
						return _contextGO.activeInHierarchy;
					}
					return true;
				}
				return false;
			}
		}

		public Entry(Object context, uint priority = 0u)
		{
			Context = context;
			Actions = new List<IRewiredAction>();
			Priority = priority;
			_enabled = true;
			if (context is GameObject contextGO)
			{
				_contextGO = contextGO;
			}
			else if (context is Component component)
			{
				_contextGO = component.gameObject;
			}
			_visible = false;
		}

		public bool HasUpdatedVisibility()
		{
			if (_visible != Visible)
			{
				_visible = Visible;
				return true;
			}
			return false;
		}

		public void Enable()
		{
			_enabled = true;
			foreach (IRewiredAction action in Actions)
			{
				action.Enable();
			}
		}

		public void Disable()
		{
			_enabled = false;
			foreach (IRewiredAction action in Actions)
			{
				action.Disable();
			}
		}

		public void Sort()
		{
			Sorting.SlowSort(Actions, SortActions);
		}

		private int SortActions(IRewiredAction left, IRewiredAction right)
		{
			return left.SortingOrder - right.SortingOrder;
		}
	}

	[SerializeField]
	private uint _maximumPriority = 10u;

	[SerializeField]
	private ChildBehaviourCache<RewiredActionInfoBarAction> _actions;

	[SerializeField]
	private RewiredGlyphProvider _rewiredJoysticks;

	private Entry _defaultEntry;

	private List<Entry>[] _prioritizedEntries;

	private bool _updateActions;

	private Entry DefaultEntry
	{
		get
		{
			if (_defaultEntry == null)
			{
				_defaultEntry = new Entry(this);
			}
			return _defaultEntry;
		}
	}

	private void Awake()
	{
		GameEventDispatcher.AddListener(GameEventType.ActiveInputUpdated, OnActiveInputUpdated);
	}

	private void LateUpdate()
	{
		if (_updateActions || EntryHasUpdatedVisibility())
		{
			UpdateActions();
		}
	}

	private void OnDestroy()
	{
		GameEventDispatcher.RemoveListener(GameEventType.ActiveInputUpdated, OnActiveInputUpdated);
	}

	public void AddActionToContext(Object context, params IRewiredAction[] actions)
	{
		AddContextActionsEnumerable(context, 0u, actions);
	}

	private void AddContextActions(Object context, uint priority, params IRewiredAction[] actions)
	{
		AddContextActionsEnumerable(context, priority, actions);
	}

	private void AddContextActionsEnumerable(Object context, uint priority, IEnumerable<IRewiredAction> actions)
	{
		if (_prioritizedEntries == null)
		{
			_prioritizedEntries = new List<Entry>[_maximumPriority + 1];
		}
		if (_maximumPriority < priority)
		{
			priority = _maximumPriority;
		}
		if (TryGetEntry(context, out var entry))
		{
			entry.Actions.AddUniqueRange(actions);
			List<Entry> list = _prioritizedEntries[entry.Priority];
			list.Remove(entry);
			list.Add(entry);
		}
		else
		{
			List<Entry> list = _prioritizedEntries[priority];
			if (list == null)
			{
				list = new List<Entry>();
				_prioritizedEntries[priority] = list;
			}
			entry = new Entry(context, priority);
			entry.Actions.AddUniqueRange(actions);
			list.Add(entry);
		}
		entry.Enable();
		_updateActions = true;
	}

	public void RemoveActionsFromContext(Object context, params IRewiredAction[] actions)
	{
		if (!actions.IsNullOrEmpty() && TryGetEntry(context, out var entry) && !entry.Actions.IsNullOrEmpty())
		{
			foreach (IRewiredAction item in actions)
			{
				entry.Actions.Remove(item);
			}
			if (actions.IsNullOrEmpty())
			{
				entry.Disable();
			}
			_updateActions = true;
		}
	}

	public void DisableContext(Object context)
	{
		if (TryGetEntry(context, out var entry))
		{
			entry.Disable();
			_updateActions = true;
		}
	}

	public void AddActions(params IRewiredAction[] actions)
	{
		if (DefaultEntry.Actions.AddUniqueRange(actions))
		{
			_updateActions = true;
		}
	}

	public void RemoveActions(params IRewiredAction[] actions)
	{
		foreach (IRewiredAction item in actions)
		{
			if (DefaultEntry.Actions.Remove(item))
			{
				_updateActions = true;
			}
		}
	}

	private void UpdateActions(GameEvent gameEvent = null)
	{
		Entry prioritizedEnabledEntry = GetPrioritizedEnabledEntry();
		prioritizedEnabledEntry.Sort();
		_actions.Reset();
		if (!prioritizedEnabledEntry.Actions.IsNullOrEmpty())
		{
			foreach (IRewiredAction action in prioritizedEnabledEntry.Actions)
			{
				AddAction(action);
			}
		}
		_actions.Trim();
		_updateActions = false;
	}

	private void AddAction(IRewiredAction action)
	{
		if (action.VisibleInRewiredActionInfoBar())
		{
			KeyCode keyCode;
			if (_rewiredJoysticks.TryGetActiveControllerActionNameAndIcon(out var _, out var icon, action.ActionId))
			{
				_actions.Get(active: true).Initialize(icon, action.Description, action.Prefix);
			}
			else if (FlotsamInputManager.TryActiveControllerActionKeyCode(action.ActionId, out keyCode))
			{
				_actions.Get(active: true).Initialize(keyCode, action.Description, action.Prefix);
			}
		}
	}

	private bool TryGetEntry(Object owner, out Entry entry)
	{
		entry = null;
		if (_prioritizedEntries.IsNullOrEmpty())
		{
			return false;
		}
		int num = _prioritizedEntries.Length;
		while (0 < num--)
		{
			List<Entry> list = _prioritizedEntries[num];
			if (list.IsNullOrEmpty())
			{
				continue;
			}
			int count = list.Count;
			while (0 < count--)
			{
				entry = list[count];
				if (entry.Context == owner)
				{
					return true;
				}
			}
		}
		return false;
	}

	private Entry GetPrioritizedEnabledEntry()
	{
		if (_prioritizedEntries.IsNullOrEmpty())
		{
			return DefaultEntry;
		}
		int num = _prioritizedEntries.Length;
		while (0 < num--)
		{
			List<Entry> list = _prioritizedEntries[num];
			if (list.IsNullOrEmpty())
			{
				continue;
			}
			int count = list.Count;
			while (0 < count--)
			{
				Entry entry = list[count];
				if (entry.Visible)
				{
					return entry;
				}
			}
		}
		return DefaultEntry;
	}

	private void OnActiveInputUpdated(GameEvent gameEvent)
	{
		_updateActions = true;
	}

	private bool EntryHasUpdatedVisibility()
	{
		if (_prioritizedEntries.IsNullOrEmpty())
		{
			return false;
		}
		List<Entry>[] prioritizedEntries = _prioritizedEntries;
		foreach (List<Entry> list in prioritizedEntries)
		{
			if (list.IsNullOrEmpty())
			{
				continue;
			}
			foreach (Entry item in list)
			{
				if (item.HasUpdatedVisibility())
				{
					return true;
				}
			}
		}
		return false;
	}
}
