using UnityEngine;
using UnityEngine.EventSystems;

public class AssignmentBox : AssignmentPriorityBoxBase
{
	[Header("AssignmentBox")]
	[SerializeField]
	private Gradient _attributeModifierColor;

	private Agent _agent;

	private bool _isTemplate;

	public Assignment Assignment { get; private set; }

	public void Initialize(Agent agent, Assignment assignment, bool isTemplate = false)
	{
		_agent = agent;
		Assignment = assignment;
		_isTemplate = isTemplate;
		int affinity = ((!(_agent == null)) ? _agent.Attributes.ReturnAssignmentAffinityAmount(assignment) : 0);
		Initialize(assignment.Priority, affinity);
		if (_agent != null)
		{
			UpdateAttributeInfo();
			_agent.Attributes.AttributesUpdatedEvent.AddListener(UpdateAttributeInfo);
		}
		Refresh();
	}

	protected override void OnDestroy()
	{
		base.OnDestroy();
		if (_agent != null)
		{
			_agent.Attributes.AttributesUpdatedEvent.RemoveListener(UpdateAttributeInfo);
		}
	}

	public override void OnPointerEnter(PointerEventData eventData)
	{
		base.OnPointerEnter(eventData);
		AgentEvent.Dispatch(_agent, Assignment.Type);
	}

	public override void OnSelect(BaseEventData eventData = null)
	{
		base.OnSelect(eventData);
		AgentEvent.Dispatch(_agent, Assignment.Type);
	}

	private void UpdateAttributeInfo()
	{
		if (base.gameObject.activeSelf && (bool)_agent)
		{
			DrifterAttributes.AttributeType type = _agent.Attributes.ReturnAssignmentAttribute(Assignment);
			float time = Mathf.Clamp01((float)_agent.Attributes.ReturnTotalAttributePoints(type) / (float)_agent.Attributes.MaximumAttributeLevel);
			base.Background.color = _attributeModifierColor.Evaluate(time);
		}
	}

	public override void Refresh()
	{
		base.Refresh();
		if (_isTemplate)
		{
			GameManager.AgentManager.AssignmentPriorityTemplates[Assignment.Type] = base.Priority;
		}
		else
		{
			_agent.TryUpdateAssignmentPriority(Assignment.Type, base.Priority);
		}
	}

	protected override bool IsEnabled()
	{
		return Assignment?.Enabled ?? false;
	}
}
