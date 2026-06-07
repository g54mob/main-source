using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class DrifterExpertiseField : UIComponent, IPointerClickHandler, IEventSystemHandler
{
	[SerializeField]
	private TextMeshProUGUI _counter;

	[SerializeField]
	private GroupPrefabDisplay _affinityDisplay;

	private int _expertise;

	private int _expertiseIncrease;

	public Agent Drifter { get; private set; }

	public DrifterAttributes.AttributeType Type { get; private set; }

	public void Initialize(Agent drifter, DrifterAttributes.AttributeType type)
	{
		Drifter = drifter;
		Type = type;
		_affinityDisplay.Display(Drifter.Attributes.ReturnAffinityAmount(type));
		_expertise = Drifter.Attributes.ReturnExpertise(type);
		_expertiseIncrease = 0;
		UpdateCounter();
	}

	public bool Increase()
	{
		if (_expertise + _expertiseIncrease < Drifter.Attributes.MaximumAttributeLevel)
		{
			_expertiseIncrease++;
			Apply();
			UpdateCounter();
			AgentEvent.Dispatch(Drifter, Type);
			return true;
		}
		return false;
	}

	public bool Decrease()
	{
		if (0 < _expertiseIncrease)
		{
			_expertiseIncrease--;
			Apply();
			UpdateCounter();
			AgentEvent.Dispatch(Drifter, Type);
			return true;
		}
		return false;
	}

	public void Apply()
	{
		for (int i = 0; i < _expertiseIncrease; i++)
		{
			Drifter.Attributes.TryLevelAttribute(Type);
		}
		_expertiseIncrease = 0;
		_expertise = Drifter.Attributes.ReturnExpertise(Type);
	}

	private void UpdateCounter()
	{
		_counter.text = _expertise.ToString();
	}

	public void OnPointerClick(PointerEventData eventData)
	{
		switch (eventData.button)
		{
		case PointerEventData.InputButton.Left:
			Increase();
			break;
		case PointerEventData.InputButton.Right:
			Decrease();
			break;
		}
	}

	public override void OnPointerEnter(PointerEventData eventData)
	{
		base.OnPointerEnter(eventData);
		AgentEvent.Dispatch(Drifter, Type);
	}

	public override void OnSelect(BaseEventData eventData = null)
	{
		base.OnSelect(eventData);
		AgentEvent.Dispatch(Drifter, Type);
	}
}
