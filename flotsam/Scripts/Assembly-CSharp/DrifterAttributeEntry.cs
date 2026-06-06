using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DrifterAttributeEntry : AgentReferenceUIElement
{
	[SerializeField]
	private DrifterAttributes.AttributeType _type;

	[SerializeField]
	private TMP_Text _labelText;

	[SerializeField]
	private TMP_Text _attributeText;

	[SerializeField]
	private DrifterAttributeExpandedTooltip _attributeTooltip;

	[SerializeField]
	private TMP_Text _levelUpText;

	[SerializeField]
	private Button _levelUpButton;

	[SerializeField]
	private GameObject _levelUpParent;

	[SerializeField]
	private GroupPrefabDisplay _affinityDisplay;

	[SerializeField]
	private DrifterAttributeModifierTooltip _buttonTooltip;

	[Header("Colors")]
	[SerializeField]
	private Color _defaultColor = Color.white;

	[SerializeField]
	private Color _negativeColor = Color.white;

	[SerializeField]
	private Color _positiveColor = Color.white;

	protected override void Subscribe(Agent agent)
	{
		agent.Attributes.AttributesUpdatedEvent.AddListener(UpdateAttributes);
		agent.Attributes.AttributesUpdatedEvent.AddListener(UpdateAffinity);
		agent.Attributes.AvailableSpendingPointsUpdatedEvent.AddListener(OnLevelUpdate);
		agent.Attributes.LevelIncreasedEvent.AddListener(OnLevelUpdate);
		UpdateAttributes();
		OnLevelUpdate();
		UpdateAffinity();
	}

	protected override void Unsubscribe(Agent agent)
	{
		agent.Attributes.AttributesUpdatedEvent.RemoveListener(UpdateAttributes);
		agent.Attributes.AttributesUpdatedEvent.RemoveListener(UpdateAffinity);
		agent.Attributes.AvailableSpendingPointsUpdatedEvent.RemoveListener(OnLevelUpdate);
		agent.Attributes.LevelIncreasedEvent.RemoveListener(OnLevelUpdate);
	}

	protected override void UpdateAgent(Agent agent)
	{
		base.UpdateAgent(agent);
		_attributeTooltip.Initialize(_agent, _type);
		_buttonTooltip.SetAttributes(_agent.Attributes, _type, 1, 0);
	}

	public void IncreaseLevel()
	{
		_agent.Attributes.TryLevelAttribute(_type);
	}

	private void UpdateText(TMP_Text text, int amount)
	{
		Color color = _defaultColor;
		if (amount > 0)
		{
			color = _positiveColor;
		}
		else if (amount < 0)
		{
			color = _negativeColor;
		}
		text.text = amount.ToString();
		text.color = color;
	}

	private void UpdateAttributes()
	{
		_labelText.text = _agent.Attributes.ReturnAttributeName(_type);
		UpdateText(_attributeText, _agent.Attributes.ReturnTotalAttributePoints(_type));
		_attributeTooltip.Initialize(_agent, _type);
	}

	private void OnLevelUpdate()
	{
		if (_agent.Attributes.IsMaximumLevel(_type))
		{
			_levelUpParent.SetActive(value: false);
			_levelUpText.gameObject.SetActive(value: false);
			return;
		}
		bool flag = _agent.Attributes.SpendablePoints > 0;
		_levelUpButton.interactable = flag;
		_levelUpParent.gameObject.SetActive(flag);
		_levelUpText.gameObject.SetActive(flag);
		if (flag)
		{
			_levelUpText.text = (_agent.Attributes.ReturnExpertise(_type) + 1).ToString();
		}
	}

	private void UpdateAffinity()
	{
		_affinityDisplay.Display(_agent.Attributes.ReturnAffinityAmount(_type));
	}
}
