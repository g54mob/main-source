using System;
using System.Collections.Generic;
using I2.Loc;
using PajamaLlama.Extensions;
using Rewired;
using RewiredConsts;
using UnityEngine;
using UnityEngine.UI;

public abstract class RewiredComponent : MonoBehaviour, IRewiredComponent, IRewiredAction
{
	public enum Wait
	{
		None = 0,
		ForUp = 1,
		ForNextFrame = 2,
		ForUpAndAxisZero = 3
	}

	public enum RepeatMode
	{
		None = 0,
		InputModule = 1,
		Custom = 2
	}

	[Header("Rewired")]
	[SerializeField]
	[ActionIdProperty(typeof(RewiredConsts.Action))]
	private int _action = -1;

	[SerializeField]
	private int _priority;

	[SerializeField]
	private LocalizedString _description;

	[SerializeField]
	private LocalizedString _prefix;

	[SerializeField]
	private Image _actionImage;

	[SerializeField]
	private InputFlags _interactableInputs = InputFlags.Joystick;

	[SerializeField]
	[Tooltip("If the Rewired Component is hidden (not visisble), the no error is logged when Action Image is not set.")]
	protected bool _hidden;

	[SerializeField]
	private RewiredGlyphProvider _glyphProvider;

	[SerializeField]
	[Tooltip("The UIStates in which this component is not interactable")]
	private List<UIState> _nonInteractableUIStates;

	[Space]
	[SerializeField]
	private RepeatMode _repeat;

	[Tooltip("The repeat delay in seconds.")]
	[SerializeField]
	[ConditionalEnumHide("_repeat", 2, false, HideInInspector = true)]
	private float _actionRepeatDelay;

	[Tooltip("The number of times the action repeats per second.")]
	[SerializeField]
	[ConditionalEnumHide("_repeat", 2, false, HideInInspector = true)]
	private float _actionsPerSecond = 10f;

	[Header("Action Info Bar")]
	[SerializeField]
	protected bool _addToActionInfoBarOnEnable;

	[SerializeField]
	[Tooltip("[OPTIONAL] The context for the actions. When the context is not set the default context will be used.")]
	[ConditionalHide("_addToActionInfoBarOnEnable", HideInInspector = true)]
	protected RewiredActionInfoBarContext _actionInfoBarContext;

	[SerializeField]
	[ConditionalHide("_addToActionInfoBarOnEnable", HideInInspector = true)]
	private int _actionInfoBarSortingOrder = 1024;

	[Header("Animation")]
	[SerializeField]
	private Animator _animator;

	[SerializeField]
	[ConditionalHide(false, ConditionalSourceField = "_animator", HideInInspector = true)]
	private bool _setInteractableParameter;

	[SerializeField]
	[ConditionalHide(false, ConditionalSourceField = "_animator", ConditionalSourceField2 = "_setInteractableParameter", HideInInspector = true)]
	private string _interactableParameter = "IsInteractable";

	[SerializeField]
	[ConditionalHide(false, ConditionalSourceField = "_animator", HideInInspector = true)]
	private bool _setPressedParameter;

	[SerializeField]
	[ConditionalHide(false, ConditionalSourceField = "_animator", ConditionalSourceField2 = "_setPressedParameter", HideInInspector = true)]
	private string _pressedParameter = "IsPressed";

	private Wait _wait;

	private float _repeatTime;

	private float _repeatInterval;

	private static int _blockCount = 0;

	private static Dictionary<int, List<IRewiredComponent>> _priorityLists = new Dictionary<int, List<IRewiredComponent>>();

	public static bool AreInteractable => _blockCount == 0;

	public int ActionId => _action;

	public int Priority => _priority;

	public int SortingOrder => _actionInfoBarSortingOrder;

	public LocalizedString Description => _description;

	public LocalizedString Prefix => _prefix;

	public Image ActionImage => _actionImage;

	public bool Interactable { get; private set; }

	protected virtual void Awake()
	{
		if (!_hidden && _actionImage == null)
		{
			Debug.LogErrorFormat("Action Image is not set for RewiredComponent '{0}'", base.transform.HierarchyPathToString());
		}
	}

	protected virtual void OnEnable()
	{
		GameEventDispatcher.AddListener(GameEventType.ActiveInputUpdated, OnActiveInputUpdated);
		GameEventDispatcher.AddListener(GameEventType.UIStateChanged, OnActiveInputUpdated);
		GameEventDispatcher.AddListener(GameEventType.UIFlagsUpdated, OnActiveInputUpdated);
		OnActiveInputUpdated();
		if (_addToActionInfoBarOnEnable)
		{
			AddToActionInfoBar();
		}
	}

	protected virtual void Update()
	{
		if (!Interactable)
		{
			return;
		}
		switch (_wait)
		{
		case Wait.ForUp:
			if (FlotsamInputManager.GetButtonUp(_action))
			{
				_wait = Wait.None;
			}
			break;
		case Wait.ForNextFrame:
			_wait = Wait.None;
			break;
		case Wait.None:
			if (AreInteractable)
			{
				if (FlotsamInputManager.GetButtonDown(_action) && HasPriority(this))
				{
					if (_setPressedParameter)
					{
						_animator?.SetBool(_pressedParameter, value: true);
					}
					_repeatTime = 0f;
					_repeatInterval = GetRepeatDelay() + GetRepeatInterval();
					OnButtonDown();
				}
				else if (_repeat != RepeatMode.None && FlotsamInputManager.GetButton(_action) && HasPriority(this))
				{
					_repeatTime += Time.unscaledDeltaTime;
					if (_repeatInterval <= _repeatTime)
					{
						_repeatInterval = GetRepeatInterval();
						_repeatTime -= _repeatInterval;
						OnButtonDown();
					}
				}
				else if (FlotsamInputManager.GetButtonUp(_action) && HasPriority(this))
				{
					if (_setPressedParameter)
					{
						_animator?.SetBool(_pressedParameter, value: false);
					}
					OnButtonUp();
				}
			}
			else if (_setPressedParameter)
			{
				_animator?.SetBool(_pressedParameter, value: false);
			}
			break;
		default:
			Debug.LogErrorFormat("No behaviour implemented for {0}!", _wait);
			break;
		}
	}

	protected virtual void OnDisable()
	{
		GameEventDispatcher.RemoveListener(GameEventType.ActiveInputUpdated, OnActiveInputUpdated);
		GameEventDispatcher.RemoveListener(GameEventType.UIStateChanged, OnActiveInputUpdated);
		GameEventDispatcher.RemoveListener(GameEventType.UIFlagsUpdated, OnActiveInputUpdated);
		_actionImage?.gameObject.SetActive(value: false);
		if (_setPressedParameter)
		{
			_animator?.SetBool(_pressedParameter, value: false);
		}
		UnregisterRewiredComponent(this);
		if (_addToActionInfoBarOnEnable)
		{
			RemoveFromActionInfoBar();
		}
	}

	public static void Block()
	{
		_blockCount++;
	}

	public static void Unblock()
	{
		if (_blockCount <= 0)
		{
			Debug.LogError("RewiredComponent was unblocked, but it was not blocked.");
		}
		else
		{
			_blockCount--;
		}
	}

	protected virtual void OnActiveInputUpdated(GameEvent gameEvent = null)
	{
		UnregisterRewiredComponent(this);
		Interactable = base.isActiveAndEnabled && HasInteractableInput() && IsInInteractableUIState();
		UpdateGlyph();
		if (_setInteractableParameter)
		{
			_animator?.SetBool(_interactableParameter, Interactable);
		}
		if (Interactable)
		{
			RegisterRewiredComponent(this);
			if (FlotsamInputManager.GetButtonDown(_action))
			{
				_wait = Wait.ForUp;
			}
			else if (FlotsamInputManager.GetButtonUp(_action))
			{
				_wait = Wait.ForNextFrame;
			}
			else
			{
				_wait = Wait.None;
			}
		}
	}

	protected abstract void OnButtonDown();

	protected virtual void OnButtonUp()
	{
	}

	protected virtual void UpdateGlyph()
	{
		if (!(_actionImage == null))
		{
			if (Interactable && TryGetGlyph(out var glyph))
			{
				_actionImage.overrideSprite = glyph;
				_actionImage.gameObject.SetActive(value: true);
			}
			else
			{
				_actionImage.gameObject.SetActive(value: false);
			}
		}
	}

	private bool TryGetGlyph(out Sprite glyph)
	{
		glyph = null;
		string text;
		if ((bool)_glyphProvider)
		{
			return _glyphProvider.TryGetActiveControllerActionNameAndIcon(out text, out glyph, _action);
		}
		return false;
	}

	private void AddToActionInfoBar()
	{
		if ((bool)_actionInfoBarContext)
		{
			_actionInfoBarContext.AddActions(this);
		}
		else
		{
			UIManager.AddRewiredActionInfo(this);
		}
	}

	private void RemoveFromActionInfoBar()
	{
		if ((bool)_actionInfoBarContext)
		{
			_actionInfoBarContext.RemoveActions(this);
		}
		else
		{
			UIManager.RemoveRewiredActionInfo(this);
		}
	}

	public static void RegisterRewiredComponent(IRewiredComponent rewiredComponent)
	{
		if (TryGetElementIdentifierId(rewiredComponent, out var elementIdentifierId))
		{
			if (!_priorityLists.TryGetValue(elementIdentifierId, out var value))
			{
				value = new List<IRewiredComponent>();
				_priorityLists.Add(elementIdentifierId, value);
			}
			if (!value.Contains(rewiredComponent))
			{
				value.Add(rewiredComponent);
				Sorting.SlowSort(value, CompareRewiredComponentPriority);
			}
		}
	}

	public static void UnregisterRewiredComponent(IRewiredComponent rewiredComponent)
	{
		Dictionary<int, List<IRewiredComponent>>.Enumerator enumerator = _priorityLists.GetEnumerator();
		while (enumerator.MoveNext())
		{
			if (!enumerator.Current.Value.IsNullOrEmpty() && enumerator.Current.Value.Remove(rewiredComponent))
			{
				Sorting.SlowSort(enumerator.Current.Value, CompareRewiredComponentPriority);
			}
		}
	}

	public static bool HasPriority(IRewiredComponent rewiredComponent)
	{
		if (TryGetElementIdentifierId(rewiredComponent, out var elementIdentifierId) && _priorityLists.TryGetValue(elementIdentifierId, out var value) && !value.IsNullOrEmpty())
		{
			return value[value.Count - 1] == rewiredComponent;
		}
		return true;
	}

	private static int CompareRewiredComponentPriority(IRewiredComponent left, IRewiredComponent right)
	{
		return left.Priority - right.Priority;
	}

	private static bool TryGetElementIdentifierId(IRewiredComponent rewiredComponent, out int elementIdentifierId)
	{
		Controller activeController = FlotsamInputManager.GetActiveController();
		elementIdentifierId = -1;
		if (activeController.type == ControllerType.Joystick)
		{
			ActionElementMap firstButtonMapWithAction = FlotsamInputManager.GetFirstButtonMapWithAction(activeController, rewiredComponent.ActionId);
			if (firstButtonMapWithAction != null)
			{
				elementIdentifierId = firstButtonMapWithAction.elementIdentifierId;
			}
		}
		return 0 <= elementIdentifierId;
	}

	protected bool HasInteractableInput()
	{
		return (_interactableInputs & FlotsamInputManager.ActiveInput) != 0;
	}

	private float GetRepeatDelay()
	{
		return _repeat switch
		{
			RepeatMode.None => -1f, 
			RepeatMode.InputModule => FlotsamInputManager.RepeatDelay, 
			RepeatMode.Custom => _actionRepeatDelay, 
			_ => throw new NotImplementedException(), 
		};
	}

	private float GetRepeatInterval()
	{
		return _repeat switch
		{
			RepeatMode.None => -1f, 
			RepeatMode.InputModule => 1f / FlotsamInputManager.InputActionsPerSecond, 
			RepeatMode.Custom => 1f / _actionsPerSecond, 
			_ => throw new NotImplementedException(), 
		};
	}

	public bool VisibleInRewiredActionInfoBar()
	{
		if (Interactable)
		{
			return AreInteractable;
		}
		return false;
	}

	public bool IsMappedToUICancel()
	{
		return FlotsamInputManager.IsMappedToUICancel(ActionId);
	}

	protected virtual bool IsInInteractableUIState()
	{
		if (!_nonInteractableUIStates.IsNullOrEmpty())
		{
			return !_nonInteractableUIStates.Contains(UIManager.State);
		}
		return true;
	}
}
