using PajamaLlama.Debugs;
using UnityEngine;
using UnityEngine.UI;

public class UIInteractableToggle : UIInteractable
{
	public delegate void ToggleEventHandler();

	[Header("Toggle")]
	[Tooltip("Image component to toggle. When left empty it will take attached of first child.")]
	[SerializeField]
	private Image _targetImage;

	[Header("Sprites")]
	[SerializeField]
	[Tooltip("Sprite for the normal state.")]
	private Sprite _normal;

	[SerializeField]
	[Tooltip("Sprite for the toggled state.")]
	private Sprite _toggled;

	protected Toggle _toggleComponent;

	public bool IsOn => _toggleComponent.isOn;

	public event ToggleEventHandler ToggleUpdatedEvent;

	protected override void Awake()
	{
		InitializeReferences();
		if (_normal != null && _toggled != null)
		{
			_targetImage.sprite = (IsOn ? _toggled : _normal);
		}
		base.Awake();
	}

	protected override void Subscribe()
	{
		_toggleComponent.onValueChanged.AddListener(OnToggleValueChanged);
	}

	protected override void Unsubscribe()
	{
		_toggleComponent.onValueChanged.RemoveListener(OnToggleValueChanged);
	}

	private void InitializeReferences()
	{
		if (_targetImage == null)
		{
			_targetImage = GetComponentInChildren<Image>();
		}
		_toggleComponent = GetComponent<Toggle>();
		if (_toggleComponent == null)
		{
			Debugger.Warning($"No toggle component found on {base.gameObject.name}.", this);
		}
	}

	public override void Interact()
	{
		Toggle();
		if (IsOn)
		{
			base.Interact();
		}
	}

	public virtual void Toggle()
	{
		Toggle(!IsOn);
	}

	private void OnToggleValueChanged(bool toggled)
	{
		Toggle(toggled, sendEvent: true);
	}

	public virtual void Toggle(bool toggled, bool sendEvent = false)
	{
		if (_toggleComponent == null)
		{
			InitializeReferences();
		}
		_toggleComponent.SetIsOnWithoutNotify(toggled);
		if (_normal != null && _toggled != null)
		{
			_targetImage.sprite = (IsOn ? _toggled : _normal);
		}
		if (sendEvent && this.ToggleUpdatedEvent != null)
		{
			this.ToggleUpdatedEvent();
		}
	}
}
