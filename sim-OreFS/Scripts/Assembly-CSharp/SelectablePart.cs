using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class SelectablePart : MonoBehaviour, ISelectHandler, IEventSystemHandler, IDeselectHandler
{
	public Selectable targetSelectable;

	public InputActionReference enterAction;

	public InputActionReference exitAction;

	private bool isFocused;

	private bool isSelected;

	private bool exitListening;

	private bool resetBackBusyNextFrame;

	private Selectable ownSelectable;

	private void Awake()
	{
		ownSelectable = GetComponent<Selectable>();
		if (enterAction != null)
		{
			enterAction.action.performed += OnEnterPressed;
		}
	}

	private void OnDestroy()
	{
		if (enterAction != null)
		{
			enterAction.action.performed -= OnEnterPressed;
		}
		if (exitAction != null)
		{
			exitAction.action.performed -= OnExitPressed;
		}
	}

	public void OnSelect(BaseEventData eventData)
	{
		if (!Input.mousePresent || !Input.GetMouseButton(0))
		{
			isSelected = true;
		}
	}

	public void OnDeselect(BaseEventData eventData)
	{
		isSelected = false;
	}

	private void Update()
	{
		if (isFocused && EventSystem.current.currentSelectedGameObject != targetSelectable?.gameObject)
		{
			isFocused = false;
			InputDetection.Instance.isBackBusy = false;
			StopExitListening();
		}
		if (resetBackBusyNextFrame)
		{
			InputDetection.Instance.isBackBusy = false;
			resetBackBusyNextFrame = false;
		}
	}

	private void OnEnterPressed(InputAction.CallbackContext context)
	{
		if (isSelected && !isFocused && targetSelectable != null && targetSelectable.interactable)
		{
			EventSystem.current.SetSelectedGameObject(targetSelectable.gameObject);
			isFocused = true;
			InputDetection.Instance.isBackBusy = true;
			StartExitListening();
		}
	}

	private void OnExitPressed(InputAction.CallbackContext context)
	{
		if (isFocused && ownSelectable != null)
		{
			EventSystem.current.SetSelectedGameObject(ownSelectable.gameObject);
			isFocused = false;
			StopExitListening();
			resetBackBusyNextFrame = true;
		}
	}

	private void StartExitListening()
	{
		if (!exitListening)
		{
			if (exitAction != null)
			{
				exitAction.action.performed += OnExitPressed;
			}
			exitListening = true;
		}
	}

	private void StopExitListening()
	{
		if (exitListening)
		{
			if (exitAction != null)
			{
				exitAction.action.performed -= OnExitPressed;
			}
			exitListening = false;
		}
	}
}
