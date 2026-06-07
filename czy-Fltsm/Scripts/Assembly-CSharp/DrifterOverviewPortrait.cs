using System;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class DrifterOverviewPortrait : SceneBehaviour, IAgentReference
{
	[SerializeField]
	private OutlinedImage _drifterImage;

	[SerializeField]
	private Image _statusImage;

	[SerializeField]
	private GameObject _mortalDangerWarning;

	[SerializeField]
	private TextMeshProUGUI _nameText;

	[SerializeField]
	private GameObject _pollutionBar;

	[SerializeField]
	private Slider _pollutionSlider;

	[SerializeField]
	private Image _moraleImage;

	[SerializeField]
	private Color _selectedColor = Color.white;

	private DrifterOverview _overview;

	public Agent Drifter { get; private set; }

	public Agent AgentReference => Drifter;

	public UnityEvent OnAgentUpdated { get; private set; } = new UnityEvent();

	public void Initialize(Agent drifter, DrifterOverview overview)
	{
		RemoveListeners();
		Drifter = drifter;
		UpdatePortrait(Drifter.Descriptor);
		OnAgentUpdated.Invoke();
		_overview = overview;
		AddListeners();
		base.gameObject.SetActive(value: true);
	}

	private void OnDestroy()
	{
		RemoveListeners();
		OnAgentUpdated.RemoveAllListeners();
	}

	public void EvaluateEnabled(DrifterOverview.Filters filter)
	{
		base.gameObject.SetActive((bool)Drifter && ReturnIsEnabledWithFilter(filter));
		_moraleImage.gameObject.SetActive(filter == DrifterOverview.Filters.Morale);
		_pollutionBar.gameObject.SetActive(filter == DrifterOverview.Filters.Pollution);
	}

	public void Clear()
	{
		RemoveListeners();
		Drifter = null;
		base.gameObject.SetActive(value: false);
	}

	private void UpdateMortalDanger()
	{
		_mortalDangerWarning.SetActive((bool)Drifter && Drifter.Vitals.IsInMortalDanger());
	}

	private void AddListeners()
	{
		GameEventDispatcher.AddListener(GameEventType.AgentPortraitGenerated, UpdatePortrait);
		if ((bool)Drifter)
		{
			Drifter.OnAssignmentUpdatedEvent.AddListener(UpdateProject);
			UpdateProject();
			Drifter.Descriptor.UpdatedEvent.AddListener(UpdateName);
			UpdateName(Drifter.Descriptor);
			Drifter.Vitals.Pollution.Updated.AddListener(UpdatePollution);
			UpdatePollution();
			Drifter.Morale.UpdatedEvent.AddListener(UpdateMorale);
			UpdateMorale();
			Drifter.Vitals.Hunger.Updated.AddListener(UpdateMortalDanger);
			Drifter.Vitals.Thirst.Updated.AddListener(UpdateMortalDanger);
			UpdateMortalDanger();
		}
	}

	private void RemoveListeners()
	{
		GameEventDispatcher.RemoveListener(GameEventType.AgentPortraitGenerated, UpdatePortrait);
		if (!(Drifter == null))
		{
			Drifter.OnAssignmentUpdatedEvent.RemoveListener(UpdateProject);
			Drifter.Descriptor.UpdatedEvent.RemoveListener(UpdateName);
			Drifter.Vitals.Pollution.Updated.RemoveListener(UpdatePollution);
			Drifter.Vitals.Hunger.Updated.RemoveListener(UpdateMortalDanger);
			Drifter.Vitals.Thirst.Updated.RemoveListener(UpdateMortalDanger);
			Drifter.Morale.UpdatedEvent.RemoveListener(UpdateMorale);
		}
	}

	private void UpdateProject(Agent agent = null)
	{
		if (Drifter.Assignment == null || Drifter.Assignment.Project == null)
		{
			_statusImage.gameObject.SetActive(value: false);
			return;
		}
		_statusImage.gameObject.SetActive(value: true);
		_statusImage.sprite = Drifter.Assignment.Project.Properties.Icon;
	}

	private void UpdatePollution()
	{
		_pollutionSlider.value = Drifter.Vitals.Pollution.LevelNormalized;
	}

	private void UpdatePortrait(GameEvent gameEvent)
	{
		if (gameEvent is AgentEvent agentEvent)
		{
			UpdatePortrait(agentEvent.AgentDescriptor);
		}
	}

	private void UpdatePortrait(AgentDescriptor descriptor)
	{
		if (descriptor == Drifter.Descriptor && PortraitGenerator.HasStaticPortrait(descriptor))
		{
			_drifterImage.Initialize(PortraitGenerator.ReturnStaticPortrait(descriptor));
		}
	}

	private void UpdateMorale()
	{
		if (Drifter.Morale.TryReturnCurrentCategory(out var category))
		{
			_moraleImage.sprite = category.Icon;
		}
	}

	public void LockDrifter()
	{
		if (!(Drifter == null) && UIManager.State == UIState.Normal)
		{
			switch (_overview.Filter)
			{
			case DrifterOverview.Filters.Leveled:
				GameManager.UIManager.DisplayPanel(PanelID.ExpertisePanel, Drifter);
				break;
			case DrifterOverview.Filters.Morale:
				Selector.Select(Drifter.gameObject, ObjectType.CommunityMember);
				UIEvent.Dispatch(UIEvent.Type.ToggleAgentPanelMoraleTab);
				break;
			default:
				Selector.Select(Drifter.gameObject, ObjectType.CommunityMember);
				break;
			}
		}
	}

	public void Select()
	{
		_drifterImage.OverrideOutlineColor(_selectedColor);
	}

	public void Deselect()
	{
		_drifterImage.RestoreOutlineColor();
	}

	private void UpdateName(ActorDescriptor actorDescriptor)
	{
		_nameText.text = Drifter.Name;
	}

	private bool ReturnIsEnabledWithFilter(DrifterOverview.Filters filter)
	{
		switch (filter)
		{
		case DrifterOverview.Filters.Morale:
			return true;
		case DrifterOverview.Filters.MortalDanger:
			return Drifter.Vitals.IsInMortalDanger();
		case DrifterOverview.Filters.Disease:
			return Drifter.Vitals.Pollution.CurrentDisease != null;
		case DrifterOverview.Filters.Thirst:
			return 0 < Drifter.Vitals.Thirst.Amount;
		case DrifterOverview.Filters.Hunger:
			return 0 < Drifter.Vitals.Hunger.Amount;
		case DrifterOverview.Filters.Message:
			return Drifter.ReturnHasMessageQueued();
		case DrifterOverview.Filters.Leveled:
			return 0 < Drifter.Attributes.SpendablePoints;
		case DrifterOverview.Filters.Homeless:
			return Drifter.ReservedHouse == null;
		case DrifterOverview.Filters.Pollution:
			return 0f < Drifter.Vitals.Pollution.Level;
		case DrifterOverview.Filters.RadioMessage:
		case DrifterOverview.Filters.None:
			return false;
		default:
			throw new NotImplementedException();
		}
	}
}
