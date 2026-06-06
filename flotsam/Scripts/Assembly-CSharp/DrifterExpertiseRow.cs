using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine.UI;

public class DrifterExpertiseRow : MonoBehaviour, IAgentReference, IPointerEnterHandler, IEventSystemHandler
{
	[SerializeField]
	private TextMeshProUGUI _levelField;

	[SerializeField]
	private Slider _levelProgressField;

	[SerializeField]
	private ChildBehaviourCache<DrifterExpertiseField> _expertiseFieldCache;

	[SerializeField]
	private Transition _transition;

	private DrifterExpertiseField _selectedExpertise;

	private int _selectedExpertiseIndex = -1;

	private int _spendPoints;

	public Agent AgentReference { get; private set; }

	public UnityEvent OnAgentUpdated { get; private set; } = new UnityEvent();

	private void OnDisable()
	{
		GameEventDispatcher.RemoveListener(GameEventType.AgentExperienceGained, OnDrifterEvent);
	}

	public void Initialize(Agent drifter, List<DrifterAttributes.AttributeType> attributes)
	{
		AgentReference = drifter;
		OnAgentUpdated.Invoke();
		_spendPoints = 0;
		_expertiseFieldCache.Reset();
		foreach (DrifterAttributes.AttributeType attribute in attributes)
		{
			_expertiseFieldCache.Get(active: true).Initialize(drifter, attribute);
		}
		_expertiseFieldCache.Trim();
		GameEventDispatcher.RemoveListener(GameEventType.AgentExperienceGained, OnDrifterEvent);
		GameEventDispatcher.AddListener(GameEventType.AgentExperienceGained, OnDrifterEvent);
		UpdateFields();
	}

	public int Select(int index)
	{
		SelectBox(index);
		_transition.SetSelected();
		return _selectedExpertiseIndex;
	}

	public int SelectLeft(int index)
	{
		return SelectBox(index - 1);
	}

	public int SelectRight(int index)
	{
		return SelectBox(index + 1);
	}

	public void Deselect()
	{
		if ((bool)_selectedExpertise)
		{
			_selectedExpertise.OnDeselect();
			_selectedExpertise = null;
		}
		_selectedExpertiseIndex = -1;
		_transition.SetNormal();
	}

	public void IncreaseSelected()
	{
		if (0 < AgentReference.Attributes.SpendablePoints && (bool)_selectedExpertise && _selectedExpertise.Increase())
		{
			_spendPoints++;
			UpdateFields();
		}
	}

	public void DecreaseSelected()
	{
		if (0 < _spendPoints && (bool)_selectedExpertise && _selectedExpertise.Decrease())
		{
			_spendPoints--;
			UpdateFields();
		}
	}

	public void Apply()
	{
		foreach (DrifterExpertiseField instance in _expertiseFieldCache.Instances)
		{
			instance.Apply();
		}
		_spendPoints = 0;
	}

	private int SelectBox(int index)
	{
		index = Mathf.Clamp(index, 0, _expertiseFieldCache.Instances.Count - 1);
		if (index == _selectedExpertiseIndex)
		{
			return index;
		}
		DrifterExpertiseField drifterExpertiseField = _expertiseFieldCache.Instances[index];
		if (drifterExpertiseField == null)
		{
			return _selectedExpertiseIndex;
		}
		if ((bool)_selectedExpertise)
		{
			_selectedExpertise.OnDeselect();
		}
		_selectedExpertiseIndex = index;
		_selectedExpertise = drifterExpertiseField;
		_selectedExpertise.OnSelect();
		return index;
	}

	private void OnDrifterEvent(GameEvent gameEvent)
	{
		if (gameEvent is AgentFloatEvent agentFloatEvent && agentFloatEvent.Agent == AgentReference)
		{
			UpdateFields();
		}
	}

	private void UpdateFields()
	{
		_levelField.text = AgentReference.Attributes.Level.ToString();
		_levelProgressField.value = AgentReference.Attributes.ReturnNormalizedExperience();
	}

	public void OnPointerEnter(PointerEventData pointerEventData)
	{
		AgentEvent.Dispatch(GameEventType.AgentFullscreenPanelRefresh, AgentReference);
	}
}
