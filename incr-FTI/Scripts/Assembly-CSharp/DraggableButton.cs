using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DraggableButton : Selectable, IDragHandler, IEventSystemHandler
{
	public delegate void DraggableActionDelegate(DraggableButton button, bool isDrgging);

	public DraggableActionDelegate actionDelegate;

	public override void OnPointerDown(PointerEventData eventData)
	{
		base.OnPointerDown(eventData);
		if (eventData.button == PointerEventData.InputButton.Left && IsActive() && IsInteractable() && EventSystem.current != null)
		{
			UserInput.Instance.didBeginDragOnDragButton = true;
			actionDelegate?.Invoke(this, isDrgging: false);
		}
	}

	public override void OnPointerEnter(PointerEventData eventData)
	{
		base.OnPointerEnter(eventData);
		if (eventData.button == PointerEventData.InputButton.Left && UserInput.isPrimaryPointerDown && UserInput.Instance.didBeginDragOnDragButton && IsActive() && IsInteractable() && EventSystem.current != null)
		{
			actionDelegate?.Invoke(this, isDrgging: true);
		}
	}

	public void OnDrag(PointerEventData eventData)
	{
	}
}
