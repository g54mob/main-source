using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MyInputField : UUInputField
{
	public override void OnUpdateSelected(BaseEventData eventData)
	{
		base.OnUpdateSelected(eventData);
	}

	public override void OnSelect(BaseEventData eventData)
	{
		base.OnSelect(eventData);
	}

	public override void OnDeselect(BaseEventData eventData)
	{
		base.OnDeselect(eventData);
	}

	public override void OnPointerClick(PointerEventData eventData)
	{
		base.OnPointerClick(eventData);
	}
}
