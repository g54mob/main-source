using System;
using Rewired;
using RewiredConsts;
using UnityEngine;
using UnityEngine.EventSystems;

public class UIComponent : UIBehaviour, IMoveHandler, IEventSystemHandler, IPointerDownHandler, IPointerUpHandler, IPointerEnterHandler, IPointerExitHandler, ISelectHandler, IDeselectHandler
{
	[SerializeField]
	private bool _interactable = true;

	[SerializeField]
	private Transition _transition;

	[SerializeField]
	private PointerEventData.InputButton _mouseButton;

	[SerializeField]
	[ActionIdProperty(typeof(RewiredConsts.Action))]
	private int _inputActionId = -1;

	[Tooltip("The input modes in which the component can be selected")]
	[SerializeField]
	private InputFlags _selectableInputs = InputFlags.All;

	private int _inputActionIdOverride = -1;

	private bool _hasPointer;

	private bool _hasPointerDown;

	private bool _hasButton;

	private bool _hasSelection;

	public bool Interactable
	{
		get
		{
			if (base.isActiveAndEnabled)
			{
				return _interactable;
			}
			return false;
		}
		set
		{
			if (_interactable != value)
			{
				_interactable = value;
				UpdateTransition();
			}
		}
	}

	public int InputActionId
	{
		get
		{
			if (_inputActionIdOverride != -1)
			{
				return _inputActionIdOverride;
			}
			return _inputActionId;
		}
	}

	public bool Selectable => (FlotsamInputManager.ActiveInput & _selectableInputs) != 0;

	protected override void OnEnable()
	{
		base.OnEnable();
		UpdateTransition();
		if (_selectableInputs != InputFlags.All)
		{
			GameEventDispatcher.AddListener(GameEventType.ActiveInputUpdated, OnActiveInputUpdated);
		}
	}

	protected override void OnDisable()
	{
		base.OnDisable();
		_hasPointer = false;
		_hasPointerDown = false;
		_hasButton = false;
		_hasSelection = false;
		if (_selectableInputs != InputFlags.All)
		{
			GameEventDispatcher.RemoveListener(GameEventType.ActiveInputUpdated, OnActiveInputUpdated);
		}
	}

	private void LateUpdate()
	{
		bool button = FlotsamInputManager.GetButton(InputActionId);
		if (button != _hasButton)
		{
			_hasButton = button;
			UpdateTransition();
		}
	}

	public void UpdateTransition()
	{
		if (!Interactable)
		{
			_transition.SetDisabled();
		}
		else if ((_hasSelection && _hasButton) || (_hasPointer && _hasPointerDown))
		{
			_transition.SetPressed();
		}
		else if (Selectable && _hasSelection)
		{
			_transition.SetSelected();
		}
		else if (_hasPointer)
		{
			_transition.SetHighlighted();
		}
		else
		{
			_transition.SetNormal();
		}
	}

	public void SetAnimatorTrigger(string trigger)
	{
		_transition.SetAnimatorTrigger(trigger);
	}

	public void SetAnimatorBool(string name, bool value)
	{
		_transition.SetAnimatorBool(name, value);
	}

	public void SetAnimatorInteger(string name, int value)
	{
		_transition.SetAnimatorInteger(name, value);
	}

	private void OnActiveInputUpdated(GameEvent gameEvent)
	{
		UpdateTransition();
	}

	public void OnMove(AxisEventData eventData)
	{
		throw new NotImplementedException();
	}

	public virtual void OnPointerEnter(PointerEventData eventData)
	{
		_hasPointer = true;
		UpdateTransition();
	}

	public virtual void OnPointerExit(PointerEventData eventData)
	{
		_hasPointer = false;
		UpdateTransition();
	}

	public void OnPointerDown(PointerEventData eventData)
	{
		if (eventData.button == _mouseButton)
		{
			_hasPointerDown = true;
			UpdateTransition();
		}
	}

	public void OnPointerUp(PointerEventData eventData)
	{
		if (eventData.button == _mouseButton)
		{
			_hasPointerDown = false;
			UpdateTransition();
		}
	}

	public virtual void OnSelect(BaseEventData eventData = null)
	{
		_hasSelection = true;
		UpdateTransition();
	}

	public virtual void OnDeselect(BaseEventData eventData = null)
	{
		_hasSelection = false;
		UpdateTransition();
	}
}
