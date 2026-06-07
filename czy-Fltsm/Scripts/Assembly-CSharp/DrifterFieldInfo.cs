using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DrifterFieldInfo : MonoBehaviour
{
	[SerializeField]
	private Image _icon;

	[SerializeField]
	private TextMeshProUGUI _title;

	[SerializeField]
	private TextMeshProUGUI _description;

	[SerializeField]
	private TextMeshProUGUI _tooltip;

	private bool _initialized;

	private void Awake()
	{
		Initialize();
	}

	private void OnDestroy()
	{
		GameEventDispatcher.RemoveListener(GameEventType.AgentAttributeInfo, OnInfoEvent);
		GameEventDispatcher.RemoveListener(GameEventType.AgentAssignmentInfo, OnInfoEvent);
	}

	public void Initialize()
	{
		if (!_initialized)
		{
			GameEventDispatcher.AddListener(GameEventType.AgentAttributeInfo, OnInfoEvent);
			GameEventDispatcher.AddListener(GameEventType.AgentAssignmentInfo, OnInfoEvent);
			GameEventDispatcher.AddListener(GameEventType.AgentDietInfo, OnInfoEvent);
			_initialized = true;
		}
	}

	private void OnInfoEvent(GameEvent gameEvent)
	{
		if (gameEvent is AgentEvent { EventType: var eventType } agentEvent)
		{
			switch (eventType)
			{
			case GameEventType.AgentAttributeInfo:
				SetAttributeInfo(agentEvent.Agent, agentEvent.Attribute);
				break;
			case GameEventType.AgentAssignmentInfo:
				SetAssignmentInfo(agentEvent.Agent, agentEvent.AssignmentType);
				break;
			case GameEventType.AgentDietInfo:
				SetDietInfo(agentEvent.ItemProperties);
				break;
			}
		}
	}

	private void SetAttributeInfo(Agent agent, DrifterAttributes.AttributeType attributeType)
	{
		DrifterAttributes.Attribute attribute = agent.Attributes.ReturnAttribute(attributeType);
		if (attribute != null)
		{
			_icon.sprite = attribute.Icon;
			_title.text = $"{attribute.Name} - {agent.Attributes.ReturnTotalAttributePoints(attributeType)}";
			_description.text = attribute.Description;
			_tooltip.text = DrifterAttributes.ReturnDetailedTooltipText(agent.Attributes, attribute, attributeType);
		}
	}

	private void SetAssignmentInfo(Agent agent, AssignmentType assignmentType)
	{
		AssignmentSetting assignmentSetting = GameManager.Settings.ProjectSettings.ReturnAssignmentSetting(assignmentType);
		if (!(assignmentSetting == null))
		{
			_icon.sprite = assignmentSetting.Sprite;
			_title.text = assignmentSetting.Name;
			_description.text = assignmentSetting.Description;
			_tooltip.text = assignmentSetting.GetTooltip((agent != null) ? agent.Attributes : AgentDescriptor.GetProperties().AttributeProperties);
		}
	}

	private void SetDietInfo(ItemProperties itemProperties)
	{
		_icon.sprite = itemProperties.InventorySprite;
		_title.text = itemProperties.LocalizedName;
		_description.text = itemProperties.ReturnCategory();
		_tooltip.text = itemProperties.ReturnStats();
	}
}
