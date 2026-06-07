using Rewired;
using RewiredConsts;
using UnityEngine;
using UnityEngine.UI;

public class RewiredButtonDeprecated : CustomButton, IRewiredComponent
{
	public enum Wait
	{
		None = 0,
		ForUp = 1,
		ForNextFrame = 2
	}

	[Header("Controller Button")]
	[SerializeField]
	private bool _rewired;

	[SerializeField]
	[ConditionalHide(false, ConditionalSourceField = "_rewired")]
	[ActionIdProperty(typeof(Action))]
	private int _action;

	[SerializeField]
	private int _priority;

	[SerializeField]
	[ConditionalHide(false, ConditionalSourceField = "_rewired")]
	private Image _actionImage;

	[SerializeField]
	[ConditionalHide(false, ConditionalSourceField = "_rewired")]
	private InputFlags _interactableInputs = InputFlags.All;

	[SerializeField]
	[ConditionalHide(false, ConditionalSourceField = "_rewired")]
	private bool _setInteractableParameter;

	[SerializeField]
	[ConditionalHide(false, ConditionalSourceField = "_rewired", ConditionalSourceField2 = "_setInteractableParameter")]
	private string _interactableParameter = "IsInteractable";

	[SerializeField]
	[ConditionalHide(false, ConditionalSourceField = "_rewired")]
	private RewiredGlyphProvider _joysticks;

	[SerializeField]
	[ConditionalHide(false, ConditionalSourceField = "_rewired")]
	private bool _overrideColors;

	[SerializeField]
	[ConditionalHide(false, ConditionalSourceField = "_rewired", ConditionalSourceField2 = "_overrideColors")]
	private ColorBlock _colors = ColorBlock.defaultColorBlock;

	private Wait _wait;

	private bool _actionImageActiveSelf;

	private ColorBlock _defaultColors;

	public int ActionId => _action;

	public int Priority => _priority;

	protected override void Awake()
	{
		base.Awake();
		InitializeRewired();
	}

	protected override void OnEnable()
	{
		base.OnEnable();
		if (!_rewired)
		{
			return;
		}
		GameEventDispatcher.AddListener(GameEventType.ActiveInputUpdated, EnableRewired);
		EnableRewired();
		if (base.interactable)
		{
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

	protected virtual void LateUpdate()
	{
		UpdateRewired();
	}

	protected override void OnDisable()
	{
		base.OnDisable();
		GameEventDispatcher.RemoveListener(GameEventType.ActiveInputUpdated, EnableRewired);
		RewiredComponent.UnregisterRewiredComponent(this);
	}

	private void InitializeRewired()
	{
		_actionImageActiveSelf = (bool)_actionImage && _actionImage.gameObject.activeSelf;
		_defaultColors = base.colors;
	}

	private void EnableRewired(GameEvent gameEvent = null)
	{
		RewiredComponent.UnregisterRewiredComponent(this);
		base.interactable = FlotsamInputManager.HasActiveInput(_interactableInputs);
		if (base.interactable && (bool)_joysticks && _joysticks.TryGetActiveControllerActionNameAndIcon(out var _, out var icon, _action))
		{
			if ((bool)_actionImage)
			{
				_actionImage.gameObject.SetActive(value: true);
				_actionImage.overrideSprite = icon;
			}
			if (_overrideColors)
			{
				base.colors = _colors;
			}
		}
		else
		{
			base.colors = _defaultColors;
			if ((bool)_actionImage)
			{
				_actionImage.overrideSprite = null;
				_actionImage.gameObject.SetActive(_actionImageActiveSelf);
			}
		}
		if (_setInteractableParameter)
		{
			base.animator?.SetBool(_interactableParameter, base.interactable);
		}
		if (base.interactable)
		{
			RewiredComponent.RegisterRewiredComponent(this);
		}
	}

	private void UpdateRewired()
	{
		if (!_rewired)
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
			if (RewiredComponent.AreInteractable && FlotsamInputManager.GetButtonDown(_action) && RewiredComponent.HasPriority(this))
			{
				base.onClick.Invoke();
			}
			break;
		default:
			Debug.LogErrorFormat("No behaviour implemented for {0}!", _wait);
			break;
		}
	}
}
