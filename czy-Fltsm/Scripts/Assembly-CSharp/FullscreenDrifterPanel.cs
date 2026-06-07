using System.Collections.Generic;
using I2.Loc;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine.UI.PajamaLlama;

public class FullscreenDrifterPanel : Panel, IAgentReference, IMoveHandler, IEventSystemHandler, ScrollRectSelectionScroller.IProvider
{
	[SerializeField]
	private DrifterPanelBase[] _drifterPanels;

	[SerializeField]
	private ChildBehaviourCache<DrifterListItem> _drifterListItemCache;

	[SerializeField]
	private TextMeshProUGUI _name;

	[SerializeField]
	private PortraitDynamic _portrait;

	private DrifterPanelBase _activePanel;

	private Agent _selectedDrifter;

	private int _selectedDrifterIndex;

	private DrifterListItem _selectedDrifterListItem;

	private List<Agent> _drifters;

	public override PanelID ID
	{
		get
		{
			if (!(_activePanel != null))
			{
				return PanelID.None;
			}
			return _activePanel.ID;
		}
	}

	public Agent AgentReference => _selectedDrifter;

	public UnityEvent OnAgentUpdated { get; private set; } = new UnityEvent();

	public override LocalizedString Title
	{
		get
		{
			if (!_activePanel)
			{
				return base.Title;
			}
			return _activePanel.Title;
		}
	}

	public GameObject SelectedGameObject
	{
		get
		{
			if (!_selectedDrifterListItem)
			{
				return null;
			}
			return _selectedDrifterListItem.gameObject;
		}
	}

	private void OnEnable()
	{
		GameEventDispatcher.AddListener(GameEventType.AgentAddedToPlayerCommunity, OnDrifterEvent);
		GameEventDispatcher.AddListener(GameEventType.AgentRemovedFromPlayerCommunity, OnDrifterEvent);
		GameEventDispatcher.AddListener(GameEventType.AgentDeath, OnDrifterEvent);
		GameEventDispatcher.AddListener(GameEventType.ActiveInputUpdated, OnActiveInputUpdated);
		GameEventDispatcher.AddListener(GameEventType.AgentFullscreenPanelRefresh, OnAgentPanelRefresh);
		OnActiveInputUpdated();
		UpdateDrifterList();
		_portrait.Enable(_selectedDrifter);
	}

	private void OnDisable()
	{
		GameEventDispatcher.RemoveListener(GameEventType.AgentAddedToPlayerCommunity, OnDrifterEvent);
		GameEventDispatcher.RemoveListener(GameEventType.AgentRemovedFromPlayerCommunity, OnDrifterEvent);
		GameEventDispatcher.RemoveListener(GameEventType.AgentDeath, OnDrifterEvent);
		GameEventDispatcher.RemoveListener(GameEventType.ActiveInputUpdated, OnActiveInputUpdated);
		GameEventDispatcher.RemoveListener(GameEventType.AgentFullscreenPanelRefresh, OnAgentPanelRefresh);
		_portrait.Disable(_selectedDrifter);
		if (_activePanel != null)
		{
			_activePanel.Close();
		}
	}

	public override bool Open(PanelID id, IPanelContext context = null)
	{
		if (_drifterPanels.IsNullOrEmpty())
		{
			return base.Open(id, context);
		}
		if (context is Agent { IsAlive: not false } agent)
		{
			_selectedDrifter = agent;
		}
		DrifterPanelBase[] drifterPanels = _drifterPanels;
		foreach (DrifterPanelBase drifterPanelBase in drifterPanels)
		{
			if (drifterPanelBase.Open(id, context))
			{
				if ((bool)_activePanel && drifterPanelBase != _activePanel)
				{
					_activePanel.Close();
				}
				_activePanel = drifterPanelBase;
				base.gameObject.SetActive(value: true);
				UpdateDrifterList();
				return true;
			}
		}
		return false;
	}

	private void UpdateDrifterList()
	{
		Agent agent = _selectedDrifter;
		_drifters = Community.PlayerCommunity.Agents;
		_drifterListItemCache.Reset();
		if (!_drifters.IsNullOrEmpty())
		{
			if (agent == null || !agent.IsAlive)
			{
				agent = _drifters[0];
			}
			for (int i = 0; i < _drifters.Count; i++)
			{
				DrifterListItem drifterListItem = _drifterListItemCache.Get(active: true);
				drifterListItem.Initialize(_drifters[i]);
				drifterListItem.OnClick.AddListener(OnDrifterListItemClick);
				if (drifterListItem.Drifter == agent)
				{
					_selectedDrifterIndex = i;
					_selectedDrifterListItem = drifterListItem;
				}
			}
			_drifterListItemCache.Trim();
		}
		if ((bool)_activePanel)
		{
			_activePanel.UpdateDrifters(_drifters);
		}
		SelectDrifterListItem(_selectedDrifterListItem, _selectedDrifterIndex);
	}

	private void TrySelectDrifter(int index)
	{
		if (_drifterListItemCache.TryGetAtIndex(index, out var instance) && instance.gameObject.activeInHierarchy)
		{
			SelectDrifterListItem(instance, index);
		}
	}

	private void OnDrifterEvent(GameEvent gameEvent)
	{
		UpdateDrifterList();
	}

	private void OnDrifterListItemClick(DrifterListItem sender)
	{
		if (_drifterListItemCache.TryGetIndex(sender, out var index))
		{
			SelectDrifterListItem(sender, index);
		}
	}

	private void SelectDrifterListItem(DrifterListItem item, int index)
	{
		if ((bool)_selectedDrifterListItem)
		{
			_selectedDrifterListItem.OnDeselect();
		}
		_selectedDrifterIndex = index;
		_selectedDrifterListItem = item;
		_selectedDrifterListItem.OnSelect();
		SelectDrifter(item.Drifter);
	}

	private void SelectDrifter(Agent drifter)
	{
		_selectedDrifter = drifter;
		_name.text = _selectedDrifter.Name;
		_portrait.Enable(_selectedDrifter);
		if ((bool)_activePanel)
		{
			_activePanel.SetSelectedDrifter(_selectedDrifter);
		}
		OnAgentUpdated.Invoke();
	}

	private void OnActiveInputUpdated(GameEvent gameEvent = null)
	{
		if (FlotsamInputManager.ActiveInput == InputFlags.Joystick)
		{
			EventSystem.current.SetSelectedGameObject(base.gameObject);
		}
	}

	private void OnAgentPanelRefresh(GameEvent gameEvent)
	{
		if (!(gameEvent is AgentEvent agentEvent))
		{
			return;
		}
		for (int i = 0; i < _drifterListItemCache.Count; i++)
		{
			DrifterListItem drifterListItem = _drifterListItemCache[i];
			if (drifterListItem.Drifter == agentEvent.Agent)
			{
				SelectDrifterListItem(drifterListItem, i);
			}
		}
	}

	public override bool CanBeOpened(PanelID id, IPanelContext context = null)
	{
		DrifterPanelBase[] drifterPanels = _drifterPanels;
		for (int i = 0; i < drifterPanels.Length; i++)
		{
			if (drifterPanels[i].CanBeOpened(id, context))
			{
				return true;
			}
		}
		return false;
	}

	public void OnMove(AxisEventData axisEventData)
	{
		switch (axisEventData.moveDir)
		{
		case MoveDirection.Up:
			TrySelectDrifter(_selectedDrifterIndex - 1);
			break;
		case MoveDirection.Down:
			TrySelectDrifter(_selectedDrifterIndex + 1);
			break;
		default:
			_activePanel.OnMove(axisEventData);
			break;
		}
	}
}
