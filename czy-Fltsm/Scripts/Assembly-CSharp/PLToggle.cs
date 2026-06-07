using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.PajamaLlama;
using UnityEngine.UI;

public class PLToggle : Toggle
{
	[Serializable]
	private struct SettingsBlock
	{
		public InputFlags Inputs;

		public bool ToggleOnSeleced;

		public bool StopSelectPropagation;

		public bool BlockSubmit;
	}

	[Header("Pajama Llama Toggle")]
	[SerializeField]
	[NamedArrayElement(new string[] { "Inputs" })]
	private SettingsBlock[] _settings;

	[SerializeField]
	private ActionBase _isOnAction;

	[SerializeField]
	[Tooltip("Enable this to invoke onValueChanged when the Toggle is enabled. This is usefull to make sure gameObjects that are set active/inactive on value changed are in the right state. ")]
	private bool _onEnableInvokeValueChanged;

	public IToggleable Toggleable { get; private set; }

	public bool ToggleOnSelected
	{
		get
		{
			if (TryGetSettings(FlotsamInputManager.ActiveInput, out var settings))
			{
				return settings.ToggleOnSeleced;
			}
			return false;
		}
	}

	public bool StopSelectPropagation
	{
		get
		{
			if (TryGetSettings(FlotsamInputManager.ActiveInput, out var settings))
			{
				return settings.StopSelectPropagation;
			}
			return false;
		}
	}

	public bool BlockSubmit
	{
		get
		{
			if (TryGetSettings(FlotsamInputManager.ActiveInput, out var settings))
			{
				return settings.BlockSubmit;
			}
			return false;
		}
	}

	protected override void OnEnable()
	{
		base.OnEnable();
		if (_onEnableInvokeValueChanged)
		{
			onValueChanged.Invoke(base.isOn);
		}
		onValueChanged?.AddListener(OnValueChanged);
	}

	protected virtual void LateUpdate()
	{
		if (_isOnAction != null && _isOnAction.IsSelected && !base.isOn)
		{
			SetIsOnWithoutNotify(value: true);
		}
	}

	protected override void OnDisable()
	{
		base.OnDisable();
		onValueChanged?.RemoveListener(OnValueChanged);
	}

	public override void OnSubmit(BaseEventData eventData)
	{
		if (!BlockSubmit)
		{
			base.OnSubmit(eventData);
		}
	}

	public override void OnSelect(BaseEventData eventData)
	{
		if (!StopSelectPropagation)
		{
			base.OnSelect(eventData);
		}
		if (ToggleOnSelected)
		{
			base.isOn = true;
		}
	}

	public virtual void Initialize(IToggleable toggleable)
	{
		Toggleable = toggleable;
		if (Toggleable != null)
		{
			SetIsOnWithoutNotify(Toggleable.IsToggled);
			if (Toggleable.IsToggled && (bool)_isOnAction)
			{
				_isOnAction.Trigger();
			}
		}
	}

	public void ToggleIfInteractable()
	{
		if (base.interactable)
		{
			base.isOn = !base.isOn;
		}
	}

	public void SetIsOnIfInteractable(bool value)
	{
		if (base.interactable && base.isOn != value)
		{
			base.isOn = value;
		}
	}

	protected virtual void OnValueChanged(bool value)
	{
		Toggleable?.Toggle();
		if (value && (bool)_isOnAction)
		{
			_isOnAction.Trigger();
		}
	}

	private bool TryGetSettings(InputFlags inputFlags, out SettingsBlock settings)
	{
		for (int i = 0; i < _settings.Length; i++)
		{
			settings = _settings[i];
			if ((settings.Inputs & inputFlags) != InputFlags.None)
			{
				return true;
			}
		}
		settings = default(SettingsBlock);
		return false;
	}
}
