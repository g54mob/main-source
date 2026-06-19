using System;
using I2.Loc;
using UnityEngine;

public class RadicalOptionsMenuOption_TextToggle : RadicalPauseMenuOption
{
	[SerializeField]
	private LocalizedString _enabledLocalizationKey = new LocalizedString
	{
		mTerm = "on"
	};

	[SerializeField]
	private LocalizedString _disabledLocalizationKey = new LocalizedString
	{
		mTerm = "off"
	};

	public new virtual bool IsOn { get; protected set; }

	public event Action<bool> ValueChanged;

	public void Initialize(bool value, bool invokeValueChangeEvent = false)
	{
		IsOn = value;
		Initialize_Internal();
		if (invokeValueChangeEvent)
		{
			this.ValueChanged?.Invoke(IsOn);
		}
	}

	private void Start()
	{
		Initialize_Internal();
	}

	protected virtual void Initialize_Internal()
	{
		UpdateText(IsOn);
	}

	public override void OnActivated()
	{
		base.OnActivated();
		IsOn = !IsOn;
		this.ValueChanged?.Invoke(IsOn);
		UpdateText(IsOn);
	}

	public override bool OnSkimRight()
	{
		return OnSkimLeft();
	}

	public override bool OnSkimLeft()
	{
		OnActivated();
		return true;
	}

	protected virtual void UpdateText(bool value)
	{
		valueText.Render(value ? _enabledLocalizationKey.mTerm : _disabledLocalizationKey.mTerm);
	}
}
