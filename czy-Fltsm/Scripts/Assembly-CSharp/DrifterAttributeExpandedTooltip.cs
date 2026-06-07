using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(EventTrigger))]
public class DrifterAttributeExpandedTooltip : MonoBehaviour
{
	private Agent _agent;

	private DrifterAttributes.AttributeType _attribute;

	private void Awake()
	{
		EventTrigger component = GetComponent<EventTrigger>();
		EventTrigger.Entry entry = new EventTrigger.Entry();
		entry.eventID = EventTriggerType.PointerEnter;
		entry.callback.AddListener(delegate
		{
			Enter();
		});
		component.triggers.Add(entry);
		EventTrigger.Entry entry2 = new EventTrigger.Entry();
		entry2.eventID = EventTriggerType.PointerExit;
		entry2.callback.AddListener(delegate
		{
			Exit();
		});
		component.triggers.Add(entry2);
	}

	public void Initialize(Agent agent, DrifterAttributes.AttributeType attribute)
	{
		_agent = agent;
		_attribute = attribute;
	}

	public void Enter()
	{
		if (!(_agent == null))
		{
			TooltipPanel.Instance.AttributeEffectTooltip.Show(_agent, _attribute);
		}
	}

	public void Exit()
	{
		if (!(_agent == null))
		{
			TooltipPanel.Instance.AttributeEffectTooltip.Hide();
		}
	}
}
