using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.UI.PajamaLlama;

public class BuildableToggle : MonoBehaviour
{
	[SerializeField]
	private Image _iconImage;

	[SerializeField]
	[Tooltip("The animator parameter used for the interactable state. Toggle component interactable is set when the parameter is empty")]
	private string _interactableParameter = "Interactable";

	[Header("Tooltip")]
	[SerializeField]
	private bool _tooltipTriggerOnToggle;

	[SerializeField]
	private Vector3 _tooltipOffset = Vector3.zero;

	[SerializeField]
	private float _tooltipDelayMouseAndKeyboard = 0.1f;

	[SerializeField]
	private float _tooltipDelayJoystick = 0.33f;

	public PlaceableProperties.Event LockUpdatedEvent;

	private bool _interactable = true;

	protected bool _isOn;

	private Toggle _toggleComponent;

	protected EventTrigger _eventTrigger;

	protected bool _checkRequirements;

	protected static BuildableToggle _activeToggle;

	private bool _isPointerOver;

	private bool _isSelected;

	private bool _isTooltipped;

	private PanelContainer _panelContainer;

	private Coroutine _tooltipCoroutine;

	public bool Interactable
	{
		get
		{
			return _interactable;
		}
		set
		{
			_interactable = value;
			if ((bool)_toggleComponent && _toggleComponent.isActiveAndEnabled)
			{
				if (string.IsNullOrEmpty(_interactableParameter) || _toggleComponent.transition != Selectable.Transition.Animation)
				{
					_toggleComponent.interactable = value;
				}
				else
				{
					_toggleComponent.animator.SetBool(_interactableParameter, value);
				}
			}
		}
	}

	public IPlaceable Placeable { get; private set; }

	public BuildableCategory Category => Placeable.Category;

	public virtual void Initialize(IPlaceable placeable)
	{
		Placeable = placeable;
		_iconImage.sprite = placeable.Icon;
		_toggleComponent = GetComponent<Toggle>();
		_panelContainer = GetComponentInParent<PanelContainer>(includeInactive: true);
		if (_tooltipTriggerOnToggle)
		{
			_toggleComponent.onValueChanged.AddListener(OnToggleComponentValueChanged);
		}
		_eventTrigger = GetComponent<EventTrigger>();
		_eventTrigger.AddTrigger(EventTriggerType.PointerUp, Click);
		_eventTrigger.AddTrigger(EventTriggerType.PointerEnter, Enter);
		_eventTrigger.AddTrigger(EventTriggerType.PointerExit, Exit);
		_eventTrigger.AddTrigger(EventTriggerType.Submit, Submit);
		_eventTrigger.AddTrigger(EventTriggerType.Select, Select);
		_eventTrigger.AddTrigger(EventTriggerType.UpdateSelected, Select);
		_eventTrigger.AddTrigger(EventTriggerType.Deselect, Deselect);
		Community.PlayerCommunity.BuildablesUpdatedEvent += CheckRequirements;
		Community.PlayerCommunity.Inventory.InventoryUpdatedEvent.AddListener(CheckRequirements);
		if (Placeable.RequiresMooringPoint)
		{
			Community.PlayerCommunity.MooringPointsUpdatedEvent += CheckRequirements;
		}
		CheckRequirementsImmediately();
		CheckRequirements();
		LockUpdatedEvent = new PlaceableProperties.Event();
		GameEventDispatcher.AddListener(GameEventType.UnlockableUnlocked, OnUnlockableUnlocked);
		UpdateLockedState(Placeable);
	}

	private void OnEnable()
	{
		CheckRequirementsImmediately();
		UpdateTooltip();
	}

	private void Update()
	{
		if (Interactable && _isOn && _activeToggle != this)
		{
			Toggle();
		}
	}

	private void LateUpdate()
	{
		UpdateRequirements();
		UpdateTooltip();
	}

	public void UpdateRequirements()
	{
		if (_checkRequirements)
		{
			CheckRequirementsImmediately();
			_checkRequirements = false;
		}
	}

	private void OnDisable()
	{
		if (_tooltipCoroutine != null)
		{
			StopCoroutine(_tooltipCoroutine);
		}
		Placeable.HideTooltip();
		_isTooltipped = false;
	}

	private void OnDestroy()
	{
		Community.PlayerCommunity.BuildablesUpdatedEvent -= CheckRequirements;
		Community.PlayerCommunity.Inventory.InventoryUpdatedEvent.RemoveListener(CheckRequirements);
		if (Placeable.RequiresMooringPoint)
		{
			Community.PlayerCommunity.MooringPointsUpdatedEvent -= CheckRequirements;
		}
	}

	protected virtual void Click(BaseEventData eventData)
	{
		if (eventData is PointerEventData { button: PointerEventData.InputButton.Left })
		{
			Submit(eventData);
		}
	}

	protected virtual void Submit(BaseEventData eventData)
	{
		if (Interactable)
		{
			if ((bool)_activeToggle)
			{
				GameManager.CursorManager.Deactivate(cancelled: true);
			}
			_activeToggle = this;
			Trigger();
		}
	}

	protected virtual void Enter(BaseEventData eventData = null)
	{
		_isPointerOver = true;
	}

	protected virtual void Exit(BaseEventData eventData)
	{
		_isPointerOver = false;
		UpdateTooltip();
	}

	protected virtual void Select(BaseEventData eventData)
	{
		_isSelected = true;
	}

	protected virtual void Deselect(BaseEventData eventData)
	{
		_isSelected = false;
		UpdateTooltip();
	}

	public virtual void Trigger()
	{
		if (Interactable)
		{
			Placeable.ActivateCursor(OnCursorDeactivated);
			UIManager.SetState(UIState.Building);
			if (Placeable is BuildableProperties properties)
			{
				BuildableEvent.Dispatch(GameEventType.BuildableSelectedInBuildMenu, properties);
			}
			else if (Placeable is DecorationProperties properties2)
			{
				DecorationEvent.DispatchSelectedInBuildMenu(properties2);
			}
		}
	}

	private void UpdateTooltip()
	{
		if (!_panelContainer)
		{
			return;
		}
		bool flag = _panelContainer.State == PanelContainerState.Open && (_isPointerOver || _isSelected);
		if (flag != _isTooltipped)
		{
			if (_tooltipCoroutine != null)
			{
				StopCoroutine(_tooltipCoroutine);
			}
			if (flag)
			{
				_tooltipCoroutine = StartCoroutine(ShowTooltip(ReturnTooltipDelay()));
			}
			else
			{
				Placeable.HideTooltip();
			}
			_isTooltipped = flag;
		}
	}

	private IEnumerator ShowTooltip(float delay)
	{
		while (0f < delay)
		{
			yield return null;
			delay -= GameSpeedManager.PausableUnscaledDeltaTime;
		}
		if (_isTooltipped)
		{
			Placeable.ShowTooltip(base.transform.position + _tooltipOffset, delayed: false);
		}
		_tooltipCoroutine = null;
	}

	public void Toggle()
	{
		_isOn = !_isOn;
		_toggleComponent.isOn = _isOn;
		CheckRequirementsImmediately();
	}

	public void Toggle(bool toggled)
	{
		if (toggled != _isOn)
		{
			Toggle();
		}
	}

	protected virtual void OnCursorDeactivated(CursorProperties cursorProperties, bool canceled)
	{
		Toggle();
		_activeToggle = null;
		if (UIManager.State == UIState.Building)
		{
			UIManager.SetState(UIState.Normal);
		}
	}

	private void OnToggleComponentValueChanged(bool value)
	{
		if (_toggleComponent.isOn)
		{
			Enter();
		}
	}

	public void CheckRequirements()
	{
		_checkRequirements = true;
	}

	public virtual void CheckRequirementsImmediately()
	{
		Interactable = _isOn || (Placeable != null && Placeable.ReturnCanBePlaced(Community.PlayerCommunity));
	}

	private void OnUnlockableUnlocked(GameEvent gameEvent)
	{
		if (gameEvent is UnlockableEvent unlockableEvent && UpdateLockedState(unlockableEvent.Unlockable as IPlaceable))
		{
			LockUpdatedEvent.Invoke(unlockableEvent.Unlockable as IPlaceable);
		}
	}

	private bool UpdateLockedState(IPlaceable placeable)
	{
		if (placeable != null && placeable == Placeable)
		{
			base.gameObject.SetActive(Placeable.IsToggleEnabled);
			return true;
		}
		return false;
	}

	public void Remove()
	{
		Community.PlayerCommunity.BuildablesUpdatedEvent -= CheckRequirements;
		Community.PlayerCommunity.Inventory.InventoryUpdatedEvent.RemoveListener(CheckRequirements);
		if (Placeable.RequiresMooringPoint)
		{
			Community.PlayerCommunity.MooringPointsUpdatedEvent -= CheckRequirements;
		}
		GameEventDispatcher.RemoveListener(GameEventType.UnlockableUnlocked, OnUnlockableUnlocked);
		Object.Destroy(base.gameObject);
	}

	private float ReturnTooltipDelay()
	{
		if ((FlotsamInputManager.ActiveInput & InputFlags.Joystick) != InputFlags.None)
		{
			return _tooltipDelayJoystick;
		}
		return _tooltipDelayMouseAndKeyboard;
	}
}
