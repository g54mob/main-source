using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine.UI;

[RequireComponent(typeof(Selectable))]
public class SelectionStateManager : MonoBehaviour, ISelectHandler, IEventSystemHandler, IDeselectHandler, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler, IPointerUpHandler
{
	public enum SelectionState
	{
		Normal = 0,
		Highlighted = 1,
		Pressed = 2,
		Selected = 3,
		Disabled = 4
	}

	private Selectable _selectable;

	private SelectionState _selectionState;

	private bool _interactable;

	private bool _selected;

	private bool _highlighted;

	private bool _pressed;

	public UnityEvent<SelectionState> SelectionStateChangedEvent { get; private set; } = new UnityEvent<SelectionState>();

	private void Awake()
	{
		_selectable = GetComponent<Selectable>();
		_interactable = IsInteractable();
		UpdateSelectionState();
	}

	private void LateUpdate()
	{
		bool flag = IsInteractable();
		if (flag != _interactable)
		{
			_interactable = flag;
			UpdateSelectionState();
		}
	}

	public void OnSelect(BaseEventData eventData)
	{
		_selected = true;
		UpdateSelectionState();
	}

	public void OnDeselect(BaseEventData eventData)
	{
		_selected = false;
		UpdateSelectionState();
	}

	public void OnPointerEnter(PointerEventData eventData)
	{
		_highlighted = true;
		UpdateSelectionState();
	}

	public void OnPointerExit(PointerEventData eventData)
	{
		_highlighted = false;
		UpdateSelectionState();
	}

	public void OnPointerDown(PointerEventData eventData)
	{
		_pressed = true;
		UpdateSelectionState();
	}

	public void OnPointerUp(PointerEventData eventData)
	{
		_pressed = false;
		UpdateSelectionState();
	}

	private void UpdateSelectionState()
	{
		if (_interactable)
		{
			if (_highlighted)
			{
				if (_pressed)
				{
					SetSelectionState(SelectionState.Pressed);
				}
				else
				{
					SetSelectionState(SelectionState.Highlighted);
				}
			}
			else if (_selected)
			{
				SetSelectionState(SelectionState.Selected);
			}
			else
			{
				SetSelectionState(SelectionState.Normal);
			}
		}
		else
		{
			SetSelectionState(SelectionState.Disabled);
		}
	}

	private void SetSelectionState(SelectionState selectionStateToSet)
	{
		if (selectionStateToSet != _selectionState)
		{
			_selectionState = selectionStateToSet;
			SelectionStateChangedEvent.Invoke(_selectionState);
			Debug.LogFormat("Selection State change to: {0}", _selectionState);
		}
	}

	private bool IsInteractable()
	{
		if (_selectable.enabled)
		{
			return _selectable.interactable;
		}
		return false;
	}
}
