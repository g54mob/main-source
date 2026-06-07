using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DelegateScrollRect : ScrollRect
{
	[SerializeField]
	private ScrollRectEvent _onBeginDrag = new ScrollRectEvent();

	[SerializeField]
	private ScrollRectEvent _onDrag = new ScrollRectEvent();

	[SerializeField]
	private ScrollRectEvent _onEndDrag = new ScrollRectEvent();

	[SerializeField]
	private ScrollRectEvent _onScroll = new ScrollRectEvent();

	public override void OnBeginDrag(PointerEventData eventData)
	{
		base.OnBeginDrag(eventData);
		if (_onBeginDrag != null)
		{
			_onBeginDrag.Invoke(base.normalizedPosition);
		}
	}

	public override void OnDrag(PointerEventData eventData)
	{
		base.OnDrag(eventData);
		if (_onDrag != null)
		{
			_onDrag.Invoke(base.normalizedPosition);
		}
	}

	public override void OnEndDrag(PointerEventData eventData)
	{
		base.OnEndDrag(eventData);
		if (_onEndDrag != null)
		{
			_onEndDrag.Invoke(base.normalizedPosition);
		}
	}

	public override void OnScroll(PointerEventData data)
	{
		base.OnScroll(data);
		if (_onScroll != null)
		{
			_onScroll.Invoke(data.scrollDelta);
		}
	}
}
