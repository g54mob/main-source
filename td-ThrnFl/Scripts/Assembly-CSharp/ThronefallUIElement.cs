using UnityEngine;
using UnityEngine.Events;

public abstract class ThronefallUIElement : MonoBehaviour
{
	public enum NavigationDirection
	{
		Right = 0,
		Left = 1,
		Up = 2,
		Down = 3
	}

	public enum SelectionState
	{
		Default = 0,
		Focussed = 1,
		Selected = 2,
		FocussedAndSelected = 3
	}

	protected SelectionState currentState;

	protected SelectionState previousState;

	public bool ignoreMouse;

	public bool autoSelectOnFocus;

	public bool cannotBeSelected;

	public bool forceNavigateToDisabledElements;

	public ThronefallUIElement leftNav;

	public ThronefallUIElement rightNav;

	public ThronefallUIElement topNav;

	public ThronefallUIElement botNav;

	public UnityEvent onSelectionStateChange = new UnityEvent();

	public UnityEvent onApply = new UnityEvent();

	public UnityEvent<NavigationDirection> onEmptyNavigate = new UnityEvent<NavigationDirection>();

	public SelectionState CurrentState => currentState;

	public SelectionState PreviousState => previousState;

	public virtual bool dragable => false;

	public void Apply()
	{
		if (!SceneTransitionManager.instance.SceneTransitionIsRunning)
		{
			onApply.Invoke();
			OnApply();
		}
	}

	public void Select()
	{
		SetState(SelectionState.Selected);
	}

	public void Focus()
	{
		SetState(SelectionState.Focussed);
	}

	public void FocusAndSelect()
	{
		SetState(SelectionState.FocussedAndSelected);
	}

	public void Clear()
	{
		SetState(SelectionState.Default);
	}

	public void HardStateSet(SelectionState selectionState)
	{
		currentState = selectionState;
		previousState = selectionState;
		OnHardStateSet(selectionState);
	}

	protected abstract void OnApply();

	protected abstract void OnClear();

	protected abstract void OnSelect();

	protected abstract void OnFocus();

	protected abstract void OnFocusAndSelect();

	protected abstract void OnHardStateSet(SelectionState selectionState);

	private void SetState(SelectionState state)
	{
		if (state != currentState)
		{
			previousState = currentState;
			currentState = state;
			switch (currentState)
			{
			case SelectionState.Default:
				OnClear();
				break;
			case SelectionState.Focussed:
				OnFocus();
				break;
			case SelectionState.Selected:
				OnSelect();
				break;
			case SelectionState.FocussedAndSelected:
				OnFocusAndSelect();
				break;
			}
			onSelectionStateChange.Invoke();
		}
	}

	public ThronefallUIElement TryNavigate(NavigationDirection direction)
	{
		if (SceneTransitionManager.instance.SceneTransitionIsRunning)
		{
			return this;
		}
		ThronefallUIElement thronefallUIElement = null;
		switch (direction)
		{
		case NavigationDirection.Down:
			thronefallUIElement = botNav;
			break;
		case NavigationDirection.Up:
			thronefallUIElement = topNav;
			break;
		case NavigationDirection.Left:
			thronefallUIElement = leftNav;
			break;
		case NavigationDirection.Right:
			thronefallUIElement = rightNav;
			break;
		}
		if ((bool)thronefallUIElement && !thronefallUIElement.gameObject.activeInHierarchy && !forceNavigateToDisabledElements)
		{
			return thronefallUIElement.TryNavigate(direction);
		}
		onEmptyNavigate.Invoke(direction);
		return thronefallUIElement;
	}

	public virtual void OnDrag(Vector2 mousePosition)
	{
	}

	public virtual void OnDragEnd()
	{
	}

	public virtual void OnDragStart()
	{
	}
}
