using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AgentDevTools : MonoBehaviour
{
	[Header("Drifter Vitals")]
	[SerializeField]
	private GameObject _drifterVitalParent;

	[SerializeField]
	private TextMeshProUGUI _nameText;

	[SerializeField]
	private RawImage _drifterPortraitImage;

	[SerializeField]
	private Slider _pollutionSlider;

	[SerializeField]
	private TMP_InputField _athleticsModifierField;

	[SerializeField]
	private Slider _athleticsModifierSlider;

	[Header("Attributes")]
	[SerializeField]
	private Transform _attributeParent;

	[SerializeField]
	private AgentDevToolAttributeEntry _entryPrefab;

	[SerializeField]
	private float _experienceGains = 100f;

	[Header("Backgrounds")]
	[SerializeField]
	private ActorProfile[] _actorProfiles;

	[SerializeField]
	private AgentDevToolsButton _specialistButton;

	private Agent _selectedAgent;

	private List<AgentDevToolAttributeEntry> _entries;

	private bool _initializedButtons;

	public static bool OverrideAthleticsModifier { get; private set; } = false;

	public static float AthleticsModifier { get; private set; } = 1f;

	private void OnEnable()
	{
		Selector.SelectedObjectsUpdatedEvent += OnSelectionUpdate;
		InitializeDrifterButtons();
		OnSelectionUpdate();
		OnAthleticsModifierValueChanged(_athleticsModifierSlider.value);
	}

	private void Update()
	{
		if (!(_selectedAgent == null) && Input.GetKey(KeyCode.LeftControl) && Input.GetMouseButtonUp(1))
		{
			PathfindingNode node = GameManager.GraphManager.ConstructionGraph.ReturnClosestNode(CursorManager.BuildingPosition);
			_selectedAgent.ReturnNavigator().StartNavigation(new PathfindingNodeTarget(node));
		}
	}

	private void OnDisable()
	{
		Selector.SelectedObjectsUpdatedEvent -= OnSelectionUpdate;
	}

	private void OnDestroy()
	{
		GameEventDispatcher.RemoveListener(GameEventType.AgentExperienceGained, SpawnPopup);
	}

	private void InitializeDrifterButtons()
	{
		if (_initializedButtons)
		{
			return;
		}
		ActorProfile[] actorProfiles = _actorProfiles;
		for (int i = 0; i < actorProfiles.Length; i++)
		{
			if (actorProfiles[i] is AgentProfile agentProfile)
			{
				AgentDevToolsButton agentDevToolsButton = Object.Instantiate(_specialistButton, _specialistButton.transform.parent);
				agentDevToolsButton.Initialize(agentProfile);
				agentDevToolsButton.gameObject.SetActive(value: true);
			}
		}
		_initializedButtons = true;
	}

	private void InitializeAttributeEntries(Agent agent)
	{
		if (_entries == null)
		{
			_entries = new List<AgentDevToolAttributeEntry>();
		}
		foreach (AgentDevToolAttributeEntry entry in _entries)
		{
			entry.gameObject.SetActive(value: false);
		}
		DrifterAttributes.AttributeType[] array = DrifterAttributes.ReturnAttributeTypes();
		int num = 0;
		DrifterAttributes.AttributeType[] array2 = array;
		foreach (DrifterAttributes.AttributeType attributeType in array2)
		{
			if (attributeType != DrifterAttributes.AttributeType.None)
			{
				AgentDevToolAttributeEntry agentDevToolAttributeEntry;
				if (_entries.Count < num)
				{
					agentDevToolAttributeEntry = _entries[num];
				}
				else
				{
					agentDevToolAttributeEntry = Object.Instantiate(_entryPrefab, _attributeParent);
					_entries.Add(agentDevToolAttributeEntry);
				}
				agentDevToolAttributeEntry.gameObject.SetActive(value: true);
				agentDevToolAttributeEntry.Initialize(_selectedAgent, attributeType);
				num++;
			}
		}
	}

	public void FinishDisease()
	{
		if ((bool)_selectedAgent && (bool)_selectedAgent.Vitals.Pollution.CurrentDisease)
		{
			_selectedAgent.Vitals.Pollution.CurrentDisease.FinishDisease(_selectedAgent);
		}
	}

	public void AddExperience()
	{
		if (_selectedAgent != null)
		{
			ExpertiseManager.Instance.IncreaseExperience(_selectedAgent, _experienceGains);
		}
	}

	public void Kill()
	{
		if (_selectedAgent != null)
		{
			_selectedAgent.KillAgent();
		}
	}

	private void OnSelectionUpdate()
	{
		if (Selector.Selection == null)
		{
			_selectedAgent = null;
		}
		else if (Selector.SelectedType == ObjectType.CommunityMember || Selector.SelectedType == ObjectType.Agent)
		{
			_selectedAgent = Selector.Selection.GetComponent<Agent>();
		}
		else
		{
			_selectedAgent = null;
		}
		_drifterVitalParent.SetActive(_selectedAgent != null);
		if (_selectedAgent != null)
		{
			_nameText.text = _selectedAgent.Name;
			_drifterPortraitImage.texture = PortraitGenerator.ReturnStaticPortrait(_selectedAgent.Descriptor);
			InitializeAttributeEntries(_selectedAgent);
			_pollutionSlider.maxValue = _selectedAgent.Vitals.Properties.PollutionMaximum;
			_pollutionSlider.value = _selectedAgent.Vitals.Pollution.Level;
		}
	}

	public void SpawnDrifter()
	{
		AgentDescriptor.CreateInstance().Spawn<Agent>(Community.PlayerCommunity, CameraController.Instance.ReturnFocusPoint());
	}

	public void SpawnSeagull()
	{
		BirdDescriptor.CreateInstance().Spawn(Community.PlayerCommunity, CameraController.Instance.ReturnFocusPoint() + Vector3.up * 20f);
	}

	public void SendAgentEvent(GameEventTypeDecisionComponent eventComponent)
	{
		if (!(_selectedAgent == null))
		{
			new AgentEvent(eventComponent.GameEventType, _selectedAgent).Dispatch();
		}
	}

	public void ToggleOverrideAthleticsModifier(bool value)
	{
		OverrideAthleticsModifier = value;
		OnAttributeUpdated();
	}

	public void OnAthleticsModifierValueChanged(float value)
	{
		AthleticsModifier = Mathf.Clamp(value, _athleticsModifierSlider.minValue, _athleticsModifierSlider.maxValue);
		_athleticsModifierField.SetTextWithoutNotify(value.ToString());
		_athleticsModifierSlider.SetValueWithoutNotify(value);
		OnAttributeUpdated();
	}

	public void OnAthleticsModifierValueChanged(string value)
	{
		if (float.TryParse(value, out var result))
		{
			OnAthleticsModifierValueChanged(result);
		}
	}

	private void OnAttributeUpdated()
	{
		if (Community.PlayerCommunity == null)
		{
			return;
		}
		foreach (Agent agent in Community.PlayerCommunity.Agents)
		{
			if ((bool)agent && (bool)agent.Attributes && agent.Attributes.AttributesUpdatedEvent != null)
			{
				agent.Attributes.AttributesUpdatedEvent.Invoke();
			}
		}
	}

	public void IncreaseThirst()
	{
		_ = _selectedAgent == null;
	}

	public void DecreaseThirst()
	{
		if (!(_selectedAgent == null))
		{
			_selectedAgent.Vitals.DecreaseVital(VitalType.Thirst);
		}
	}

	public void IncreaseHunger()
	{
		if (!(_selectedAgent == null))
		{
			_selectedAgent.Vitals.IncreaseVital(VitalType.Hunger);
		}
	}

	public void DecreaseHunger()
	{
		if (!(_selectedAgent == null))
		{
			_selectedAgent.Vitals.DecreaseVital(VitalType.Hunger);
		}
	}

	public void SetPollution(float amount)
	{
		_selectedAgent.Vitals.Pollution.Set((int)amount);
	}

	public void RestoreAllDrifters()
	{
		foreach (Agent agent in Community.PlayerCommunity.Agents)
		{
			agent.Vitals.ResetAllVitals();
		}
	}

	public void RestoreDrifter()
	{
		if (!(_selectedAgent == null))
		{
			_selectedAgent.Vitals.ResetAllVitals();
		}
	}

	public void SetSpawnTextPopups(bool active)
	{
		if (active)
		{
			GameEventDispatcher.AddListener(GameEventType.AgentExperienceGained, SpawnPopup);
		}
		else
		{
			GameEventDispatcher.RemoveListener(GameEventType.AgentExperienceGained, SpawnPopup);
		}
	}

	private void SpawnPopup(GameEvent gameEvent)
	{
		if (gameEvent is AgentFloatEvent agentFloatEvent)
		{
			TextPopup.Spawn(agentFloatEvent.Agent.transform.position, $"+{agentFloatEvent.Value}");
		}
	}
}
