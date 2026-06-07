using System;
using UnityEngine.Events;
using UnityEngine.Localization;
using UnityEngine.UI;

public class ButtonInitializerContext : InitializerContext<Button>
{
	public ButtonInitializerContext SetInteractable(bool interactable)
	{
		Target.interactable = interactable;
		return this;
	}

	public ButtonInitializerContext AddListener(UnityAction callback, bool invoke = false)
	{
		Target.onClick.AddListener(callback);
		if (invoke)
		{
			callback();
		}
		return this;
	}

	public ButtonInitializerContext AddConfirmationPopup(LocalizedString title, LocalizedString message, Action onConfirmCallback = null)
	{
		Target.onClick.AddListener(delegate
		{
			UI.Registry.popup.generic.ShowConfirmation(title, message, onConfirmCallback);
		});
		return this;
	}

	public ButtonInitializerContext AddCancellablePopup(LocalizedString title, LocalizedString message, Action onConfirmCallback = null, Action onCancelCallback = null)
	{
		Target.onClick.AddListener(delegate
		{
			UI.Registry.popup.generic.ShowCancellable(title, message, onConfirmCallback, onCancelCallback);
		});
		return this;
	}
}
