using System;
using CTS.Core;
using UnityEngine;
using UnityEngine.UI;

public class ToggleStaticEvents : StaticEvent
{
	[SerializeField]
	[Inject(false)]
	private Toggle _button;

	[SerializeField]
	private bool _sendEventOnOff = true;

	public static Action TogglePressed;

	protected override void OnEnabled()
	{
		_button.onValueChanged.AddListener(OnToggleClick);
	}

	protected override void OnDisabled()
	{
		_button.onValueChanged.RemoveListener(OnToggleClick);
	}

	private void OnToggleClick(bool p_value)
	{
		if ((p_value || _sendEventOnOff) && RuntimeFrameTrigger<StaticEvent>.TryUse())
		{
			TogglePressed?.Invoke();
		}
	}
}
