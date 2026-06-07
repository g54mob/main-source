using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DrifterOverview : SceneBehaviour, IComparer<DrifterOverviewPortrait>
{
	public enum Filters
	{
		Morale = 0,
		MortalDanger = 1,
		Disease = 2,
		Thirst = 3,
		Hunger = 4,
		Message = 5,
		Leveled = 6,
		Homeless = 7,
		Pollution = 8,
		RadioMessage = 9,
		None = 256
	}

	[Serializable]
	public struct FilterToggle
	{
		public Filters Filter;

		public Toggle Toggle;
	}

	[SerializeField]
	private ChildBehaviourCache<DrifterOverviewPortrait> _drifterPortraits;

	[SerializeField]
	private ChildBehaviourCache<RadioMessageSenderPortrait> _radioMessagePortraits;

	[SerializeField]
	private SelectableGroup _portraitSelectableGroup;

	[SerializeField]
	private FilterToggle[] _toggles;

	[SerializeField]
	private SelectableGroup _toggleSelectalbeGroup;

	private readonly List<DrifterOverviewPortrait> _sortedPortraits = new List<DrifterOverviewPortrait>();

	private bool _updateFilter;

	private bool _sortPortraits;

	public bool Minimized { get; private set; } = true;

	public Filters Filter { get; private set; }

	protected override void Awake()
	{
		base.Awake();
		GameEventDispatcher.AddListener(GameEventType.AgentAddedToPlayerCommunity, OnAgentPortraitAdded);
		GameEventDispatcher.AddListener(GameEventType.AgentRemovedFromPlayerCommunity, OnAgentRemoved);
		GameEventDispatcher.AddListener(GameEventType.RadioMessageReceived, OnRadioMessageReceived);
		GameEventDispatcher.AddListener(GameEventType.RadioMessageRead, OnRadioMessageRead);
		FilterToggle[] toggles = _toggles;
		for (int i = 0; i < toggles.Length; i++)
		{
			toggles[i].Toggle.onValueChanged.AddListener(ToggleFilter);
		}
	}

	private void Start()
	{
		if (Community.PlayerCommunity == null)
		{
			return;
		}
		foreach (Agent agent in Community.PlayerCommunity.Agents)
		{
			if (agent != null)
			{
				OnAgentAddedToCommunity(agent);
			}
		}
	}

	private void LateUpdate()
	{
		if (_updateFilter)
		{
			Filter = Filters.None;
			FilterToggle[] toggles = _toggles;
			for (int i = 0; i < toggles.Length; i++)
			{
				FilterToggle filterToggle = toggles[i];
				if (filterToggle.Toggle.isOn)
				{
					Filter = filterToggle.Filter;
				}
			}
			_sortPortraits = true;
			_updateFilter = false;
		}
		if (_sortPortraits)
		{
			SortPortraits();
		}
	}

	private void OnDestroy()
	{
		GameEventDispatcher.RemoveListener(GameEventType.AgentAddedToPlayerCommunity, OnAgentPortraitAdded);
		GameEventDispatcher.RemoveListener(GameEventType.AgentRemovedFromPlayerCommunity, OnAgentRemoved);
		GameEventDispatcher.RemoveListener(GameEventType.RadioMessageReceived, OnRadioMessageReceived);
		GameEventDispatcher.RemoveListener(GameEventType.RadioMessageRead, OnRadioMessageRead);
		FilterToggle[] toggles = _toggles;
		for (int i = 0; i < toggles.Length; i++)
		{
			toggles[i].Toggle.onValueChanged.RemoveAllListeners();
		}
	}

	public void ToggleFilter(bool value)
	{
		_updateFilter = true;
	}

	public void ShowOverview()
	{
		_portraitSelectableGroup.gameObject.SetActive(value: true);
		_portraitSelectableGroup.Initialize(clearSelected: true);
	}

	public void HideOverview()
	{
		_portraitSelectableGroup.gameObject.SetActive(value: false);
	}

	private void OnAgentAddedToCommunity(Agent agent)
	{
		if (AddAgentPortrait(agent))
		{
			_sortPortraits = true;
			agent.Morale.UpdatedEvent.AddListener(OnAgentMoraleUpdated);
		}
	}

	private void OnAgentPortraitAdded(GameEvent gameEvent)
	{
		if (gameEvent is AgentEvent agentEvent)
		{
			OnAgentAddedToCommunity(agentEvent.Agent);
		}
	}

	private void OnRadioMessageReceived(GameEvent gameEvent)
	{
		if (gameEvent is RadioMessageEvent radioMessageEvent)
		{
			AddRadioMessagePortrait(radioMessageEvent.Message);
		}
	}

	private void OnRadioMessageRead(GameEvent gameEvent)
	{
		RadioMessageEvent radioEvent = gameEvent as RadioMessageEvent;
		if (radioEvent != null && _radioMessagePortraits.TryFind((RadioMessageSenderPortrait message) => message.Message == radioEvent.Message, out var instance))
		{
			_radioMessagePortraits.Remove(instance);
		}
	}

	private void OnAgentRemoved(GameEvent gameEvent)
	{
		AgentEvent agentEvent = gameEvent as AgentEvent;
		if (agentEvent != null && _drifterPortraits.TryFind((DrifterOverviewPortrait portrait) => portrait.Drifter == agentEvent.Agent, out var instance))
		{
			agentEvent.Agent.Morale.UpdatedEvent.RemoveListener(OnAgentMoraleUpdated);
			instance.Clear();
			_drifterPortraits.Remove(instance);
		}
	}

	private bool AddAgentPortrait(Agent agent)
	{
		if (agent.Community.CommunityType != Community.Type.Player || _drifterPortraits.TryFind((DrifterOverviewPortrait portrait) => portrait.gameObject.activeSelf && portrait.Drifter == agent, out var _))
		{
			return false;
		}
		_drifterPortraits.Get().Initialize(agent, this);
		return true;
	}

	private void AddRadioMessagePortrait(RadioMessage message)
	{
		_radioMessagePortraits.Get(Filter == Filters.RadioMessage).Initialize(message);
	}

	private void SortPortraits()
	{
		_sortedPortraits.Clear();
		_sortedPortraits.AddRange(_drifterPortraits.Instances);
		Sorting.SlowSort(_sortedPortraits, this);
		for (int i = 0; i < _sortedPortraits.Count; i++)
		{
			DrifterOverviewPortrait drifterOverviewPortrait = _sortedPortraits[i];
			drifterOverviewPortrait.transform.SetSiblingIndex(i);
			drifterOverviewPortrait.EvaluateEnabled(Filter);
		}
		bool active = Filter == Filters.RadioMessage;
		foreach (RadioMessageSenderPortrait instance in _radioMessagePortraits.Instances)
		{
			instance.gameObject.SetActive(active);
		}
		_portraitSelectableGroup.Initialize(clearSelected: true);
		_sortPortraits = false;
	}

	private void OnAgentMoraleUpdated()
	{
		_sortPortraits = true;
	}

	public int Compare(DrifterOverviewPortrait x, DrifterOverviewPortrait y)
	{
		bool flag = x.Drifter;
		bool flag2 = y.Drifter;
		if (flag && flag2)
		{
			switch (Filter)
			{
			case Filters.Morale:
				return x.Drifter.Morale.CurrentMorale - y.Drifter.Morale.CurrentMorale;
			case Filters.Thirst:
				return y.Drifter.Vitals.Thirst.Amount - x.Drifter.Vitals.Thirst.Amount;
			case Filters.Hunger:
				return y.Drifter.Vitals.Hunger.Amount - x.Drifter.Vitals.Hunger.Amount;
			case Filters.Leveled:
				return y.Drifter.Attributes.SpendablePoints - x.Drifter.Attributes.SpendablePoints;
			case Filters.Pollution:
			{
				float num = y.Drifter.Vitals.Pollution.Level - x.Drifter.Vitals.Pollution.Level;
				if (num < 0f)
				{
					return -1;
				}
				if (0f < num)
				{
					return 1;
				}
				return 0;
			}
			default:
				return 0;
			}
		}
		if (flag == flag2)
		{
			return 0;
		}
		if (flag)
		{
			return -1;
		}
		return 1;
	}
}
