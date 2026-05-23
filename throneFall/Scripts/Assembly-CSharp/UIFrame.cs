using System.Collections.Generic;
using Rewired;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine.UI;

public class UIFrame : MonoBehaviour
{
	public ThronefallUIElement firstSelected;

	public bool storeLastSelectedElementInFrameStack = true;

	public bool freezeTime;

	public bool freezePlayer = true;

	public bool canNotBeEscaped;

	public UnityEvent onActivate = new UnityEvent();

	public UnityEvent onNewFocus = new UnityEvent();

	public UnityEvent onNewSelection = new UnityEvent();

	public UnityEvent onApply = new UnityEvent();

	public UnityEvent onDeactivate = new UnityEvent();

	private List<ThronefallUIElement> managedElements = new List<ThronefallUIElement>();

	private UIFrameManager frameManager;

	private ThronefallUIElement currentSelected;

	private ThronefallUIElement currentFocus;

	private ThronefallUIElement lastSelected;

	private ThronefallUIElement currentDragTarget;

	private Player input;

	private GraphicRaycaster graphicRaycaster;

	private PointerEventData pointerData = new PointerEventData(null);

	private Vector2 lastFramePointerPosition;

	private List<RaycastResult> pointerRayResults = new List<RaycastResult>();

	private List<ThronefallUIElement> filteredPointerResults = new List<ThronefallUIElement>();

	private ThronefallUIElement lastApplied;

	private bool interactable = true;

	private bool mouseSleeping;

	private bool appliedThisFrame;

	public ThronefallUIElement CurrentSelection => currentSelected;

	public ThronefallUIElement CurrentFocus => currentFocus;

	public ThronefallUIElement LastApplied => lastApplied;

	public bool Interactable => interactable;

	private bool mouseApplyPossible
	{
		get
		{
			if (!(currentFocus != null) || currentFocus.ignoreMouse)
			{
				if (currentSelected != null && currentSelected.autoSelectOnFocus)
				{
					return !currentSelected.ignoreMouse;
				}
				return false;
			}
			return true;
		}
	}

	public bool MouseSleeping => mouseSleeping;

	private void Awake()
	{
		frameManager = GetComponentInParent<UIFrameManager>();
		if (frameManager != null)
		{
			frameManager.RegisterFrame(this);
		}
	}

	private void Start()
	{
		input = ReInput.players.GetPlayer(0);
		graphicRaycaster = GetComponentInParent<GraphicRaycaster>();
	}

	private void Update()
	{
		if ((!(frameManager != null) || !(frameManager.ActiveFrame != this)) && interactable && !SceneTransitionManager.instance.SceneTransitionIsRunning)
		{
			appliedThisFrame = false;
			HandleMouseNavigation();
			if (!appliedThisFrame)
			{
				HandleButtonNavigation();
			}
		}
	}

	private void HandleButtonNavigation()
	{
		if (input.GetButtonDown("Menu Apply"))
		{
			Apply();
		}
		else if (input.GetButtonRepeating("Menu Right"))
		{
			ControllerOrKeyboardNavigate(ThronefallUIElement.NavigationDirection.Right);
		}
		else if (input.GetButtonRepeating("Menu Left"))
		{
			ControllerOrKeyboardNavigate(ThronefallUIElement.NavigationDirection.Left);
		}
		else if (input.GetButtonRepeating("Menu Up"))
		{
			ControllerOrKeyboardNavigate(ThronefallUIElement.NavigationDirection.Up);
		}
		else if (input.GetButtonRepeating("Menu Down"))
		{
			ControllerOrKeyboardNavigate(ThronefallUIElement.NavigationDirection.Down);
		}
		else if (input.GetButtonDown("Interact"))
		{
			Apply();
		}
		else if (input.GetButtonRepeating("Move Horizontal"))
		{
			ControllerOrKeyboardNavigate(ThronefallUIElement.NavigationDirection.Right);
		}
		else if (input.GetNegativeButtonRepeating("Move Horizontal"))
		{
			ControllerOrKeyboardNavigate(ThronefallUIElement.NavigationDirection.Left);
		}
		else if (input.GetButtonRepeating("Move Vertical"))
		{
			ControllerOrKeyboardNavigate(ThronefallUIElement.NavigationDirection.Up);
		}
		else if (input.GetNegativeButtonRepeating("Move Vertical"))
		{
			ControllerOrKeyboardNavigate(ThronefallUIElement.NavigationDirection.Down);
		}
	}

	private void HandleMouseNavigation()
	{
		if (!input.controllers.hasMouse || !Cursor.visible)
		{
			return;
		}
		lastFramePointerPosition = pointerData.position;
		pointerData.position = input.controllers.Mouse.screenPosition;
		if (mouseSleeping && object.Equals(lastFramePointerPosition, pointerData.position))
		{
			return;
		}
		mouseSleeping = false;
		pointerRayResults.Clear();
		graphicRaycaster.Raycast(pointerData, pointerRayResults);
		filteredPointerResults.Clear();
		foreach (RaycastResult pointerRayResult in pointerRayResults)
		{
			ThronefallUIElement componentInParent = pointerRayResult.gameObject.GetComponentInParent<ThronefallUIElement>();
			if (componentInParent != null && managedElements.Contains(componentInParent))
			{
				filteredPointerResults.Add(componentInParent);
			}
		}
		if (filteredPointerResults.Count > 0 && !filteredPointerResults[0].ignoreMouse)
		{
			if (filteredPointerResults[0].autoSelectOnFocus)
			{
				if (filteredPointerResults[0] != currentSelected)
				{
					Select(filteredPointerResults[0]);
				}
				Focus(null);
			}
			else
			{
				Focus(filteredPointerResults[0]);
			}
		}
		else
		{
			Focus(null);
		}
		if (input.controllers.Mouse.GetButtonDown(0) && filteredPointerResults.Count > 0 && mouseApplyPossible)
		{
			if (CurrentFocus != null)
			{
				Select(currentFocus);
			}
			Apply();
		}
		if (input.controllers.Mouse.GetButton(0) && currentDragTarget != null)
		{
			currentDragTarget.OnDrag(input.controllers.Mouse.screenPosition);
		}
		if (input.controllers.Mouse.GetButtonUp(0) && currentDragTarget != null)
		{
			currentDragTarget.OnDragEnd();
			currentDragTarget = null;
		}
	}

	private void ControllerOrKeyboardNavigate(ThronefallUIElement.NavigationDirection direction)
	{
		if (!(currentSelected == null))
		{
			mouseSleeping = true;
			ThronefallUIElement thronefallUIElement = currentSelected.TryNavigate(direction);
			if (thronefallUIElement != null)
			{
				Select(thronefallUIElement);
			}
		}
	}

	public void Select(ThronefallUIElement newSelection)
	{
		if (newSelection == currentSelected || newSelection.cannotBeSelected)
		{
			return;
		}
		lastSelected = currentSelected;
		currentSelected = newSelection;
		onNewSelection.Invoke();
		if (lastSelected != null)
		{
			if (lastSelected == currentFocus)
			{
				lastSelected.Focus();
			}
			else
			{
				lastSelected.Clear();
			}
		}
		if (newSelection != null)
		{
			if (newSelection == currentFocus)
			{
				newSelection.FocusAndSelect();
			}
			else
			{
				newSelection.Select();
			}
		}
	}

	private void Focus(ThronefallUIElement newFocus)
	{
		if (newFocus == currentFocus)
		{
			return;
		}
		if (currentFocus != null)
		{
			if (currentFocus == currentSelected)
			{
				currentFocus.Select();
			}
			else
			{
				currentFocus.Clear();
			}
		}
		if (newFocus != null)
		{
			if (newFocus == currentSelected)
			{
				newFocus.FocusAndSelect();
			}
			else
			{
				newFocus.Focus();
			}
		}
		currentFocus = newFocus;
		onNewFocus.Invoke();
	}

	public void Activate(ThronefallUIElement _selected = null)
	{
		base.gameObject.SetActive(value: true);
		interactable = true;
		lastApplied = null;
		currentFocus = null;
		currentSelected = null;
		onActivate.Invoke();
		RefetchManagedElements();
		foreach (ThronefallUIElement managedElement in managedElements)
		{
			managedElement.HardStateSet(ThronefallUIElement.SelectionState.Default);
		}
		ThronefallUIElement thronefallUIElement = _selected;
		if (thronefallUIElement == null)
		{
			thronefallUIElement = firstSelected;
		}
		if (thronefallUIElement != null)
		{
			Select(thronefallUIElement);
		}
	}

	public void Apply()
	{
		if (appliedThisFrame)
		{
			return;
		}
		appliedThisFrame = true;
		if (currentFocus != null && currentFocus.cannotBeSelected)
		{
			currentFocus.Apply();
			lastApplied = currentFocus;
			if (currentFocus.dragable)
			{
				currentDragTarget = CurrentFocus;
				currentDragTarget.OnDragStart();
			}
		}
		else
		{
			if (!(currentSelected != null))
			{
				return;
			}
			currentSelected.Apply();
			lastApplied = currentSelected;
			if (currentSelected.dragable)
			{
				currentDragTarget = currentSelected;
				currentDragTarget.OnDragStart();
			}
		}
		onApply.Invoke();
	}

	public void Deactivate(bool keepGameObjectActive = false)
	{
		interactable = false;
		base.gameObject.SetActive(keepGameObjectActive);
		foreach (ThronefallUIElement managedElement in managedElements)
		{
			if (managedElement != null)
			{
				managedElement.Clear();
			}
		}
		onDeactivate.Invoke();
	}

	public void RefetchManagedElements()
	{
		managedElements.Clear();
		managedElements.AddRange(GetComponentsInChildren<ThronefallUIElement>(includeInactive: true));
	}
}
