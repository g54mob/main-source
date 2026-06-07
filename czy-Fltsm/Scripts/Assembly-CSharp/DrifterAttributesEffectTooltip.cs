using UnityEngine;
using UnityEngine.EventSystems;

public class DrifterAttributesEffectTooltip : MonoBehaviour
{
	[SerializeField]
	private EventTrigger _eventTrigger;

	private DrifterAttributesEffect _effect;

	private void Awake()
	{
		EventTrigger.Entry entry = new EventTrigger.Entry();
		entry.eventID = EventTriggerType.PointerEnter;
		entry.callback.AddListener(ShowTooltip);
		_eventTrigger.triggers.Add(entry);
		entry = new EventTrigger.Entry();
		entry.eventID = EventTriggerType.PointerExit;
		entry.callback.AddListener(HideTooltip);
		_eventTrigger.triggers.Add(entry);
	}

	public void Initialize(DrifterAttributesEffect effect)
	{
		_effect = effect;
	}

	private void OnDisable()
	{
		HideTooltip(null);
	}

	public void ShowTooltip(BaseEventData data)
	{
		if (!(_effect == null) && base.enabled)
		{
			TooltipPanel.Instance.AttributeEffectTooltip.Show(_effect);
		}
	}

	public void HideTooltip(BaseEventData data)
	{
		if (TooltipPanel.Instance != null)
		{
			TooltipPanel.Instance.AttributeEffectTooltip.Hide();
		}
	}
}
