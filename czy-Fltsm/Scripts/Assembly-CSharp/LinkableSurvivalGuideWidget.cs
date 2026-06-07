using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(EventTrigger))]
public class LinkableSurvivalGuideWidget : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler
{
	private EventTrigger _eventTrigger;

	private string _link = "";

	private Vector3 _defaultScale = Vector3.one;

	private float _hoverScale = 1f;

	public void Initialize(string link, float scale)
	{
		_link = link;
		if (!TryGetComponent<EventTrigger>(out _eventTrigger))
		{
			_eventTrigger = base.gameObject.AddComponent<EventTrigger>();
		}
		_defaultScale = base.transform.localScale;
		_hoverScale = scale;
		EventTrigger.Entry entry = new EventTrigger.Entry
		{
			eventID = EventTriggerType.PointerClick
		};
		entry.callback.AddListener(OnClick);
		_eventTrigger.triggers.Add(entry);
	}

	public void OnPointerEnter(PointerEventData eventData)
	{
		base.transform.localScale = _defaultScale * _hoverScale;
	}

	public void OnPointerExit(PointerEventData eventData)
	{
		base.transform.localScale = _defaultScale;
	}

	private void OnClick(BaseEventData baseEventData)
	{
		if (baseEventData is PointerEventData)
		{
			new StringEvent(GameEventType.OpenSurvivalGuidePage, _link).Dispatch();
		}
	}
}
