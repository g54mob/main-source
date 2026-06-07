using System.Collections.Generic;
using I2.Loc;
using PajamaLlama.Debugs;
using PajamaLlama.Flotsam.Morale;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class AgentPanel : Panel, IAgentReference, ILocalizationGenderProvider, ILocalizationParamsManager
{
	[SerializeField]
	private LocalizedString _inCommunityText = "";

	[SerializeField]
	private IconProperties _needsRescuingIconProperties;

	[Header("Buttons")]
	[SerializeField]
	private Button _focusButton;

	[SerializeField]
	private Button _houseButton;

	[SerializeField]
	private Button _houseButtonActionTab;

	[Header("Other")]
	public InventoryView InventoryView;

	[Header("Text Labels")]
	[SerializeField]
	private TextMeshProUGUI _textName;

	[Header("Vitals")]
	[SerializeField]
	private Slider _pollutionBar;

	[Header("Morale")]
	[SerializeField]
	private AgentMoralePanel _moralePanel;

	[SerializeField]
	private Toggle _moraleTabToggle;

	[Header("Attributes")]
	[SerializeField]
	private DrifterAttributesPanel _attributePanel;

	[Header("Background")]
	[SerializeField]
	private GameObject _storyPanel;

	[SerializeField]
	private DrifterStoryBlock _pastStory;

	[SerializeField]
	private DrifterStoryBlock _presentStory;

	[Header("Actions")]
	[SerializeField]
	private GameObject _actionsPanel;

	[Header("Status")]
	[SerializeField]
	private TextMeshProUGUI _statusText;

	[SerializeField]
	private Image _statusImage;

	[Header("Disease")]
	[SerializeField]
	private DiseasePanel _diseasePanel;

	[Header("Tutorial")]
	[SerializeField]
	private GameObject _tutorialButton;

	private static readonly IReadOnlyDictionary<AgentPanelTab, TutorialID> _tabTutorials = new Dictionary<AgentPanelTab, TutorialID>
	{
		[AgentPanelTab.Morale] = TutorialID.DrifterMorale,
		[AgentPanelTab.Expertise] = TutorialID.DrifterExpertise,
		[AgentPanelTab.Story] = TutorialID.DrifterExpertise
	};

	private AgentPanelTab _currentTab;

	private readonly List<DietIcon> _dietIcons = new List<DietIcon>();

	public Agent AgentReference { get; private set; }

	public UnityEvent OnAgentUpdated { get; } = new UnityEvent();

	Agent.EGender ILocalizationGenderProvider.LocalizationGender
	{
		get
		{
			if (!(AgentReference != null))
			{
				return Agent.EGender.Male;
			}
			return AgentReference.Descriptor.Gender;
		}
	}

	private void OnEnable()
	{
		GameEventDispatcher.AddListener(GameEventType.UIClick, OnUIClick);
		GameEventDispatcher.AddListener(GameEventType.MapActivated, OnMapActivated);
	}

	private void Update()
	{
		UpdatePanel();
	}

	private void OnDisable()
	{
		GameEventDispatcher.RemoveListener(GameEventType.UIClick, OnUIClick);
		GameEventDispatcher.RemoveListener(GameEventType.MapActivated, OnMapActivated);
	}

	private void OnDestroy()
	{
		GameEventDispatcher.RemoveListener(GameEventType.MapDeactivated, OnMapDeactivated);
	}

	public override bool Open(PanelID id, IPanelContext context = null)
	{
		if (context is Agent agent && CanBeOpened() && base.Open(id, context))
		{
			LocalizationManager.ParamManagers.AddUnique(this);
			Initialize(agent);
			OnDrifterPortraitUpdate();
			if (agent.ReturnNavigator().enabled)
			{
				agent.ReturnNavigator().LineRenderer.EnablePathVisuals();
			}
			return true;
		}
		return false;
	}

	public override void OnContainerStateChanged(PanelContainerState state)
	{
		switch (state)
		{
		case PanelContainerState.Open:
			GameEventDispatcher.AddListener(GameEventType.DrifterPortraitDisabled, OnDrifterPortraitUpdate);
			break;
		case PanelContainerState.Closed:
		case PanelContainerState.Closing:
			GameEventDispatcher.RemoveListener(GameEventType.DrifterPortraitDisabled, OnDrifterPortraitUpdate);
			break;
		case PanelContainerState.Opening:
			break;
		}
	}

	public void Initialize(Agent agent)
	{
		AgentReference = agent;
		OnAgentUpdated.Invoke();
		UpdatePanel();
		InventoryView.Initialize(agent.Inventory);
		_attributePanel.Initialize(agent);
		_moralePanel.Initialize(agent);
		_pastStory.Initialize(agent, agent.Descriptor.PastBackground);
		_presentStory.Initialize(agent, agent.Descriptor.PresentBackground);
		AgentReference.Vitals.Pollution.Updated.AddListener(UpdatePollution);
		AgentReference.Vitals.Pollution.OnCurrentDiseaseUpdatedEvent.AddListener(UpdateDisease);
		UpdatePollution();
		UpdateDisease(AgentReference.Vitals.Pollution.CurrentDisease);
	}

	private void UpdateName(string name, bool dialogFeedback)
	{
		PopUpDialog.Instance.InputEvent -= UpdateName;
		if (dialogFeedback)
		{
			AgentReference.SetName(name);
			if (AgentReference.AssignmentPanelEntry != null)
			{
				AgentReference.AssignmentPanelEntry.UpdateEntry();
			}
		}
	}

	private void UpdatePanel()
	{
		if (!base.gameObject.activeInHierarchy)
		{
			return;
		}
		_textName.text = AgentReference.Name;
		if (AgentReference == null)
		{
			return;
		}
		_focusButton.interactable = AgentReference.IsAlive;
		_houseButton.interactable = AgentReference.ReservedHouse != null;
		_houseButtonActionTab.interactable = AgentReference.ReservedHouse != null;
		if (AgentReference.Community == null)
		{
			return;
		}
		string text;
		Sprite sprite;
		if (AgentReference.Community.IsPlayerCommunity())
		{
			ProjectProperties projectProperties = AgentReference.Assignment?.Project.Properties;
			if (projectProperties == null)
			{
				IconProperties idlingIconProperties = GameManager.Settings.AgentSettings.IdlingIconProperties;
				text = idlingIconProperties.TooltipText;
				sprite = idlingIconProperties.Sprite;
			}
			else
			{
				text = projectProperties.DescriptiveText;
				sprite = projectProperties.Icon;
				if (string.IsNullOrEmpty(text))
				{
					text = TextManager.ReplaceVariables(_inCommunityText, AgentReference.Vitals);
					Debugger.Error($"No description set for {projectProperties.ToString()}.");
				}
			}
		}
		else
		{
			sprite = _needsRescuingIconProperties.Sprite;
			text = _needsRescuingIconProperties.TooltipText;
		}
		_statusText.text = text;
		_statusImage.sprite = sprite;
	}

	public void UpdatePollution()
	{
		_pollutionBar.value = AgentReference.Vitals.Pollution.LevelNormalized;
	}

	public void OpenDrifterDutiesPanel()
	{
		GameManager.UIManager.DisplayPanel(PanelID.AssignmentPanel, AgentReference);
	}

	public void OpenDrifterExpertisePanel()
	{
		GameManager.UIManager.DisplayPanel(PanelID.ExpertisePanel, AgentReference);
	}

	private void UpdateDisease(Disease disease)
	{
		if ((bool)disease)
		{
			_diseasePanel.Initialize(disease);
			_diseasePanel.gameObject.SetActive(value: true);
		}
		else
		{
			_diseasePanel.gameObject.SetActive(value: false);
		}
	}

	public override void Close()
	{
		if (base.gameObject.activeSelf)
		{
			LocalizationManager.ParamManagers.Remove(this);
			Selector.Deselect(AgentReference.gameObject);
			AgentReference.Vitals.Pollution.Updated.RemoveListener(UpdatePollution);
			AgentReference.Vitals.Pollution.OnCurrentDiseaseUpdatedEvent.RemoveListener(UpdateDisease);
			base.Close();
		}
	}

	public void LockOnDrifter()
	{
		if (AgentReference.IsAlive)
		{
			CameraController.Instance.Lock(AgentReference.gameObject);
		}
	}

	public void PopUpNameChange()
	{
		if (AgentReference.Community.IsPlayerCommunity() && PopUpDialog.Instance.TryPopUpInput(GameManager.Settings.UISettings.InputNameChangeAgent))
		{
			PopUpDialog.Instance.InputEvent += UpdateName;
		}
	}

	public void UpdateDiet()
	{
	}

	private void ClearDiet()
	{
		for (int i = 0; i < _dietIcons.Count; i++)
		{
			Object.Destroy(_dietIcons[i].gameObject);
		}
		_dietIcons.Clear();
	}

	public void LockOnHouse()
	{
		if ((bool)AgentReference.ReservedHouse)
		{
			CameraController.Instance.Lock(AgentReference.ReservedHouse.gameObject);
			Selector.Select(AgentReference.ReservedHouse.gameObject, ObjectType.Buildable);
		}
	}

	public void SetMoraleTabActive(bool active)
	{
		SetTabActive(AgentPanelTab.Morale, active);
	}

	public void SetExpertiseTabActive(bool active)
	{
		SetTabActive(AgentPanelTab.Expertise, active);
	}

	public void SetStoryTabActive(bool active)
	{
		SetTabActive(AgentPanelTab.Story, active);
	}

	public void SetActionsTabActive(bool active)
	{
		SetTabActive(AgentPanelTab.Actions, active);
	}

	private void SetTabActive(AgentPanelTab tab, bool active)
	{
		_moralePanel.gameObject.SetActive(tab == AgentPanelTab.Morale);
		_attributePanel.gameObject.SetActive(tab == AgentPanelTab.Expertise);
		_storyPanel.SetActive(tab == AgentPanelTab.Story);
		_actionsPanel.SetActive(tab == AgentPanelTab.Actions);
		if (active)
		{
			_currentTab = tab;
			if (_tutorialButton != null)
			{
				_tutorialButton.SetActive(_tabTutorials.ContainsKey(tab));
			}
		}
	}

	public void OpenCurrentPageTutorial()
	{
		if (_tutorialButton != null && _tabTutorials.TryGetValue(_currentTab, out var value))
		{
			GameManager.UIManager.ClosePanel(ID);
			TutorialEvent.Dispatch(GameEventType.TutorialPanelPopup, value);
		}
	}

	private bool CanBeOpened()
	{
		UIState state = UIManager.State;
		if ((uint)(state - 8) <= 1u)
		{
			return false;
		}
		return true;
	}

	private void OnUIClick(GameEvent gameEvent)
	{
		if (gameEvent is UIEvent { CallType: UIEvent.Type.ToggleAgentPanelMoraleTab })
		{
			_moraleTabToggle.isOn = true;
		}
	}

	private void OnMapActivated(GameEvent gameEvent)
	{
		if (GameManager.UIManager != null && !GameManager.UIManager.IsPanelOpen(PanelID.DialoguePanel))
		{
			GameManager.UIManager.DisableDynamicPortrait(AgentReference);
			GameEventDispatcher.AddListener(GameEventType.MapDeactivated, OnMapDeactivated);
		}
	}

	private void OnMapDeactivated(GameEvent gameEvent)
	{
		GameEventDispatcher.RemoveListener(GameEventType.MapDeactivated, OnMapDeactivated);
		OnDrifterPortraitUpdate();
	}

	private void OnDrifterPortraitUpdate(GameEvent gameEvent = null)
	{
		if (GameManager.UIManager != null && !GameManager.UIManager.IsDynamicPortraitEnabled())
		{
			GameManager.UIManager.EnableDynamicPortrait(AgentReference);
		}
	}
}
