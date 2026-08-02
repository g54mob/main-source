using System;
using System.Collections;
using Michsky.UI.Heat;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ConfirmPanel : UIPanelBase
{
	public Button confirmButton;

	public Button cancelButton;

	public TextMeshProUGUI confirmDescriptionText;

	public string defaultText = "Are you sure?";

	private Action currentAction;

	private Action currentCancelAction;

	private void Start()
	{
		confirmButton.onClick.AddListener(delegate
		{
			PlayClickSound();
			Confirm();
		});
		cancelButton.onClick.AddListener(delegate
		{
			PlayClickSound();
			Cancel();
		});
		AddHoverSound(confirmButton);
		AddHoverSound(cancelButton);
	}

	private void PlayClickSound()
	{
		if (UIManagerAudio.instance != null && UIManagerAudio.instance.UIManagerAsset != null)
		{
			UIManagerAudio.instance.audioSource.PlayOneShot(UIManagerAudio.instance.UIManagerAsset.clickSound);
		}
	}

	private void PlayHoverSound()
	{
		if (UIManagerAudio.instance != null && UIManagerAudio.instance.UIManagerAsset != null)
		{
			UIManagerAudio.instance.audioSource.PlayOneShot(UIManagerAudio.instance.UIManagerAsset.hoverSound);
		}
	}

	private void AddHoverSound(Button button)
	{
		EventTrigger eventTrigger = button.gameObject.GetComponent<EventTrigger>();
		if (eventTrigger == null)
		{
			eventTrigger = button.gameObject.AddComponent<EventTrigger>();
		}
		EventTrigger.Entry entry = new EventTrigger.Entry();
		entry.eventID = EventTriggerType.PointerEnter;
		entry.callback.AddListener(delegate
		{
			PlayHoverSound();
		});
		eventTrigger.triggers.Add(entry);
	}

	public void ShowPanel(Action action)
	{
		confirmDescriptionText.SetText(defaultText);
		base.ShowPanel();
		currentAction = action;
		currentCancelAction = null;
	}

	public void ShowPanel(string message, Action action)
	{
		confirmDescriptionText.SetText(message);
		base.ShowPanel();
		currentAction = action;
		currentCancelAction = null;
	}

	public void ShowPanel(string message, Action confirmAction, Action cancelAction)
	{
		confirmDescriptionText.SetText(message);
		base.ShowPanel();
		currentAction = confirmAction;
		currentCancelAction = cancelAction;
	}

	public void ShowPanelWithFade(string message, Action confirmAction, Action cancelAction, float duration = 0.5f)
	{
		confirmDescriptionText.SetText(message);
		base.ShowPanelWithFade(duration);
		currentAction = confirmAction;
		currentCancelAction = cancelAction;
	}

	public new void HidePanel()
	{
		base.HidePanel();
		currentAction = null;
		currentCancelAction = null;
	}

	private void Confirm()
	{
		if (currentAction != null)
		{
			Action actionToExecute = currentAction;
			HidePanelWithFade(0.2f, delegate
			{
				StartCoroutine(DelayedAction(0.2f, actionToExecute));
			});
		}
	}

	private void Cancel()
	{
		if (currentCancelAction != null)
		{
			Action actionToExecute = currentCancelAction;
			HidePanelWithFade(0.2f, delegate
			{
				StartCoroutine(DelayedAction(0.2f, actionToExecute));
			});
		}
		else
		{
			HidePanel();
		}
	}

	private IEnumerator DelayedAction(float delay, Action action)
	{
		yield return new WaitForSecondsRealtime(delay);
		action?.Invoke();
	}
}
