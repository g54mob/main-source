using System;
using UnityEngine;

[Serializable]
public class InteractionData
{
	public KeyCode keyCode;

	public string message;

	public bool hasHoldAction;

	public float holdDuration;

	public Action onHoldComplete;

	public Action onKeyDown;

	public Action onKeyUp;

	public Color? messageColor;

	public bool isDisabled;

	public InteractionData(KeyCode keyCode, string message, bool hasHoldAction = false, float holdDuration = 1f, Action onHoldComplete = null, Action onKeyDown = null, Action onKeyUp = null, Color? messageColor = null, bool isDisabled = false)
	{
		this.keyCode = keyCode;
		this.message = message;
		this.hasHoldAction = hasHoldAction;
		this.holdDuration = holdDuration;
		this.onHoldComplete = onHoldComplete;
		this.onKeyDown = onKeyDown;
		this.onKeyUp = onKeyUp;
		this.messageColor = messageColor;
		this.isDisabled = isDisabled;
	}
}
