using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine.UI;

public class CustomSelectable : Selectable
{
	public UnityEvent OnSelectionEnter;

	public UnityEvent OnSelectionExit;

	public override void OnSelect(BaseEventData eventData)
	{
	}

	public override void OnDeselect(BaseEventData eventData)
	{
	}
}
