using System;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.UI;

public class ConfirmationPopup : Popup
{
	[SerializeField]
	private LocalizeStringHandler titleHandler;

	[SerializeField]
	private LocalizeStringHandler messageHandler;

	[SerializeField]
	private Button confirm;

	[SerializeField]
	private Button cancel;

	private Action _onConfirmCallback;

	private Action _onCancelCallback;

	protected override void Initialize(StatelessInitializerContext initializer)
	{
		initializer.Context(confirm).AddListener(OnSubmit).Context(cancel)
			.AddListener(OnCancel);
	}

	public void ShowConfirmation(LocalizedString title, LocalizedString message, Action onConfirmCallback = null)
	{
		cancel.gameObject.SetActive(value: false);
		ShowInternal(title, message, onConfirmCallback);
	}

	public void ShowCancellable(LocalizedString title, LocalizedString message, Action onConfirmCallback = null, Action onCancelCallback = null)
	{
		cancel.gameObject.SetActive(value: true);
		ShowInternal(title, message, onConfirmCallback, onCancelCallback);
	}

	private void ShowInternal(LocalizedString title, LocalizedString message, Action onConfirmCallback = null, Action onCancelCallback = null)
	{
		titleHandler.SetLocalizedString(title);
		messageHandler.SetLocalizedString(message);
		_onConfirmCallback = onConfirmCallback;
		_onCancelCallback = onCancelCallback;
		ShowContent();
	}

	protected override void OnSubmit()
	{
		base.OnSubmit();
		_onConfirmCallback?.Invoke();
	}

	protected override void OnCancel()
	{
		base.OnCancel();
		_onCancelCallback?.Invoke();
	}
}
