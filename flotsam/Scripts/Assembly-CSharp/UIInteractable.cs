using I2.Loc;
using Rewired;
using RewiredConsts;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine.UI;

public class UIInteractable : SceneBehaviour
{
	[SerializeField]
	[Tooltip("The action that is triggered when this interactable is pressed.")]
	private ActionBase _action;

	[SerializeField]
	[Tooltip("Should the UIInteractable EventTrigger.onClick?")]
	private bool _subscribeToEventTrigger = true;

	[SerializeField]
	[Tooltip("The game event that is sent when this interactable is pressed.\nSelect none if no event should be sent.")]
	private UIEvent.Type _eventType;

	[SerializeField]
	protected Selectable _linkedSelectable;

	[Tooltip("The UI states this interactable's shortcut should not work in.")]
	[SerializeField]
	private UIState[] _UIStateShortcutFilters = new UIState[3]
	{
		UIState.Paused,
		UIState.Typing,
		UIState.Map
	};

	[Header("Rewired")]
	[Tooltip("The input action that triggers the interactable.")]
	[SerializeField]
	[ActionIdProperty(typeof(Action))]
	private int _rewiredAction = -1;

	[Tooltip("Referecnce to a RewiredInteractable that triggers the interactable.")]
	[SerializeField]
	private RewiredInteractable _rewiredInteractable;

	[Header("Events")]
	[SerializeField]
	private UnityEvent _onTrigger = new UnityEvent();

	private EventTrigger _eventTrigger;

	private EventTrigger.Entry _eventTriggerEntry;

	private AudioUIPlayer _audioPlayer;

	private UIInteractableRequirementBase[] _requirements;

	private bool _isInteracable;

	public bool IsInteractable
	{
		get
		{
			return _isInteracable;
		}
		set
		{
			_isInteracable = value;
			if ((bool)_linkedSelectable)
			{
				_linkedSelectable.interactable = value;
			}
			if ((bool)_rewiredInteractable)
			{
				_rewiredInteractable.enabled = value;
			}
		}
	}

	public UnityEvent OnTrigger => _onTrigger;

	public int RewiredAction => _rewiredAction;

	public LocalizedString NonInteractableTooltipMessage { get; private set; }

	protected override void Awake()
	{
		base.Awake();
		_audioPlayer = GetComponent<AudioUIPlayer>();
		_requirements = GetComponents<UIInteractableRequirementBase>();
		if ((bool)_rewiredInteractable)
		{
			_rewiredInteractable.enabled = false;
			_rewiredInteractable.ButtonUpEvent.AddListener(OnRewiredInteract);
		}
		UIInteractableRequirementBase[] requirements = _requirements;
		for (int i = 0; i < requirements.Length; i++)
		{
			requirements[i].ChangedEvent += RequirementChangedEvent;
		}
		if (_subscribeToEventTrigger)
		{
			Subscribe();
		}
	}

	protected virtual void Start()
	{
		RequirementChangedEvent();
	}

	private void Update()
	{
		if (IsInteractable && FlotsamInputManager.GetButtonUp(_rewiredAction) && IsInAvailableUIState())
		{
			Interact();
		}
	}

	protected virtual void OnDestroy()
	{
		if ((bool)_rewiredInteractable)
		{
			_rewiredInteractable.ButtonUpEvent.RemoveListener(OnRewiredInteract);
		}
		UIInteractableRequirementBase[] requirements = _requirements;
		for (int i = 0; i < requirements.Length; i++)
		{
			requirements[i].ChangedEvent -= RequirementChangedEvent;
		}
		Unsubscribe();
	}

	protected virtual void Subscribe()
	{
		_eventTriggerEntry = new EventTrigger.Entry();
		_eventTriggerEntry.eventID = EventTriggerType.PointerClick;
		_eventTriggerEntry.callback.AddListener(OnClick);
		_eventTrigger = GetComponent<EventTrigger>();
		if (_eventTrigger == null)
		{
			_eventTrigger = base.gameObject.AddComponent<EventTrigger>();
		}
		_eventTrigger.triggers.Add(_eventTriggerEntry);
	}

	protected virtual void Unsubscribe()
	{
		if (_eventTriggerEntry != null)
		{
			_eventTriggerEntry.callback.RemoveAllListeners();
			if ((bool)_eventTrigger)
			{
				_eventTrigger.triggers.Remove(_eventTriggerEntry);
			}
		}
	}

	public virtual void Interact()
	{
		if (_audioPlayer != null)
		{
			_audioPlayer.Play();
		}
		UIEvent.Dispatch(_eventType);
		if (_onTrigger != null)
		{
			_onTrigger.Invoke();
		}
		if ((bool)_action)
		{
			_action.Trigger();
		}
	}

	protected bool IsInAvailableUIState()
	{
		UIState state = UIManager.State;
		for (int i = 0; i < _UIStateShortcutFilters.Length; i++)
		{
			if (_UIStateShortcutFilters[i] == state)
			{
				return false;
			}
		}
		return true;
	}

	private void RequirementChangedEvent()
	{
		bool isInteractable = true;
		NonInteractableTooltipMessage = null;
		UIInteractableRequirementBase[] requirements = _requirements;
		foreach (UIInteractableRequirementBase uIInteractableRequirementBase in requirements)
		{
			if (!uIInteractableRequirementBase.IsMet)
			{
				isInteractable = false;
				NonInteractableTooltipMessage = uIInteractableRequirementBase.TooltipMessage;
				break;
			}
		}
		IsInteractable = isInteractable;
	}

	private void OnClick(BaseEventData eventData)
	{
		if (IsInteractable)
		{
			Interact();
		}
	}

	private void OnRewiredInteract()
	{
		if (IsInteractable)
		{
			Interact();
		}
	}
}
