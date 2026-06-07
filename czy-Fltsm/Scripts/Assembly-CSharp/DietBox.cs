using UnityEngine.EventSystems;

public class DietBox : AssignmentPriorityBoxBase
{
	private bool _enabled;

	private Agent _agent;

	private Diet _diet;

	private ItemProperties _itemProperties;

	public override void OnPointerEnter(PointerEventData eventData)
	{
		base.OnPointerEnter(eventData);
		AgentEvent.Dispatch(_agent, _itemProperties);
	}

	public override void OnSelect(BaseEventData eventData = null)
	{
		base.OnSelect(eventData);
		AgentEvent.Dispatch(_agent, _itemProperties);
	}

	public void Initialize(Agent agent, Diet diet, ItemProperties itemProperties)
	{
		_agent = agent;
		_diet = diet;
		_itemProperties = itemProperties;
		if (diet.TryReturnPriority(itemProperties, out var priority))
		{
			Initialize(priority, (diet.Favourite.ItemProperties == itemProperties) ? 1 : 0);
			_enabled = true;
		}
		else
		{
			_enabled = false;
		}
		Refresh();
	}

	public override void Refresh()
	{
		base.Refresh();
		if (_enabled)
		{
			_diet.SetPriority(_itemProperties, base.Priority);
		}
	}

	protected override bool IsEnabled()
	{
		return _enabled;
	}
}
