using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine.UI;

public class SliderWithExtra : Slider
{
	public UnityEvent OnEnter;

	public UnityEvent OnExit;

	public override void OnPointerEnter(PointerEventData eventData)
	{
		base.OnPointerEnter(eventData);
		OnEnter.Invoke();
	}

	public override void OnPointerExit(PointerEventData eventData)
	{
		base.OnPointerExit(eventData);
		OnExit.Invoke();
	}
}
