using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class HouseSlot : TMP_DropdownItemFormatter
{
	[SerializeField]
	private Image _stateImage;

	[SerializeField]
	private Sprite _unoccupiedIcon;

	[SerializeField]
	private Sprite _occupiedIcon;

	private List<string> _options;

	private List<TMP_DropdownFormatableItem> _optionItems = new List<TMP_DropdownFormatableItem>();

	private int _selectedIndex;

	public Agent Agent { get; private set; }

	public House House { get; private set; }

	public UnityEvent<Agent, Agent> OnAgentUpdated { get; private set; } = new UnityEvent<Agent, Agent>();

	protected override void OnEnable()
	{
		base.OnEnable();
		GameEventDispatcher.AddListener(GameEventType.AgentAddedToPlayerCommunity, OnAgentsUpdated);
		GameEventDispatcher.AddListener(GameEventType.AgentRemovedFromPlayerCommunity, OnAgentsUpdated);
	}

	protected override void OnDisable()
	{
		base.OnDisable();
		GameEventDispatcher.RemoveListener(GameEventType.AgentAddedToPlayerCommunity, OnAgentsUpdated);
		GameEventDispatcher.RemoveListener(GameEventType.AgentRemovedFromPlayerCommunity, OnAgentsUpdated);
	}

	public void Initialize(House house, Agent agent)
	{
		Agent = agent;
		House = house;
		UpdateDropdown(agent, house.Buildable.Community);
		UpdateState();
		base.gameObject.SetActive(value: true);
	}

	protected override void AddItem(TMP_DropdownFormatableItem item)
	{
		int count = _optionItems.Count;
		_optionItems.Add(item);
		if (House.Buildable.Community.Agents.Count <= count)
		{
			item.Hide();
		}
		else
		{
			item.Interactable = !House.ReturnIsInhabitant(House.Buildable.Community.Agents[count]);
		}
	}

	protected override void RemoveItem(TMP_DropdownFormatableItem item)
	{
		_optionItems.Remove(item);
	}

	protected override void OnSelectedIndexChanged(int selectedIndex)
	{
		List<Agent> agents = House.Buildable.Community.Agents;
		Agent agent = Agent;
		if (selectedIndex < 0 || agents.Count <= selectedIndex)
		{
			Agent = null;
		}
		else
		{
			Agent = agents[selectedIndex];
		}
		if (0 <= _selectedIndex && _selectedIndex < _optionItems.Count)
		{
			_optionItems[_selectedIndex].Interactable = true;
		}
		_selectedIndex = selectedIndex;
		if (0 <= _selectedIndex && _selectedIndex < _optionItems.Count)
		{
			_optionItems[_selectedIndex].Interactable = false;
		}
		UpdateState();
		OnAgentUpdated.Invoke(agent, Agent);
	}

	private void UpdateDropdown(Agent selectedAgent, Community community)
	{
		int count = community.Agents.Count;
		_selectedIndex = -1;
		if (_options == null)
		{
			_options = new List<string>(community.Agents.Count);
		}
		else
		{
			_options.Clear();
		}
		for (int i = 0; i < count; i++)
		{
			Agent agent = community.Agents[i];
			if (agent == selectedAgent)
			{
				_selectedIndex = _options.Count;
			}
			_options.Add(agent.Name);
		}
		Initialize(_options);
		SetSelectedIndexWithoutNotify(_selectedIndex);
	}

	private void UpdateState()
	{
		if (_selectedIndex < 0)
		{
			_stateImage.sprite = _unoccupiedIcon;
		}
		else
		{
			_stateImage.sprite = _occupiedIcon;
		}
	}

	private void OnAgentsUpdated(GameEvent gameEvent)
	{
		UpdateDropdown(Agent, House.Buildable.Community);
	}
}
