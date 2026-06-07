using I2.Loc;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[RequireComponent(typeof(Selectable))]
public abstract class NonInteractableTooltipBase : UIBehaviour, IPointerClickHandler, IEventSystemHandler, IPointerEnterHandler, IPointerExitHandler
{
	[SerializeField]
	private TooltipButtonTooltip _tooltip;

	[SerializeField]
	private LocalizedString _message;

	private bool _pointerIsOver;

	protected abstract bool Interactable { get; }

	public void OnPointerClick(PointerEventData eventData)
	{
		if (!Interactable && _pointerIsOver)
		{
			_tooltip.Display(TryGetMessage(out var message) ? message : _message, this, eventData.position);
		}
	}

	public void OnPointerEnter(PointerEventData eventData)
	{
		_pointerIsOver = true;
	}

	public void OnPointerExit(PointerEventData eventData)
	{
		_pointerIsOver = false;
		_tooltip.Close(this);
	}

	protected virtual bool TryGetMessage(out LocalizedString message)
	{
		message = null;
		return false;
	}
}
