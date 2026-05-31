using System;
using CTS.Core;
using UnityEngine;
using UnityEngine.UI;

public class ButtonStaticEvents : StaticEvent
{
	[SerializeField]
	[Inject(false)]
	private Button _button;

	public static event Action ButtonPressed;

	protected override void OnEnabled()
	{
		_button.onClick.AddListener(OnButtonClick);
	}

	protected override void OnDisabled()
	{
		_button.onClick.RemoveListener(OnButtonClick);
	}

	private void OnButtonClick()
	{
		if (RuntimeFrameTrigger<StaticEvent>.TryUse())
		{
			ButtonStaticEvents.ButtonPressed?.Invoke();
		}
	}
}
