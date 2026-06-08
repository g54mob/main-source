using System;
using UnityEngine;

public class CallHandler : MonoBehaviour
{
	private GameObject messagePlayer;

	private AudioManager messageController;

	private ClosePanelAudio audioPlayer;

	private Icon messagesIcon;

	private TaskbarManager taskbar;

	private AudioSource phoneCallSounds;

	public void Start()
	{
		audioPlayer = SoundEffectUtils.GetOpenClosePanelPlayer();
		phoneCallSounds = GetComponent<AudioSource>();
	}

	public void InstantiateNewCall(GameObject messagePlayer, AudioTranscriptManager messageManager, Icon messagesIcon, TaskbarManager taskbar, Action additionalCloseAction)
	{
		this.messagePlayer = messagePlayer;
		messageController = messageManager;
		this.messagesIcon = messagesIcon;
		this.taskbar = taskbar;
		Confirmation confirmation = GetComponent<Confirmation>();
		confirmation.SetYesButton(OpenMessages);
		confirmation.GetToolbar().AddCloseFunction(delegate
		{
			additionalCloseAction();
			phoneCallSounds.Pause();
		});
		confirmation.SetNoButton(delegate
		{
			confirmation.GetToolbar().Close();
			additionalCloseAction();
			phoneCallSounds.Pause();
		});
	}

	public void InstantiateUnskippableCall(GameObject messagePlayerPrefab, Message message, Canvas canvas, Action afterCallAction)
	{
		Confirmation confirmation = GetComponent<Confirmation>();
		confirmation.DisableClose();
		confirmation.SetNoButtonText("Open");
		confirmation.SetNoButton(delegate
		{
			confirmation.GetToolbar().Close();
			messagePlayer = UnityEngine.Object.Instantiate(messagePlayerPrefab, base.transform.position, Quaternion.identity, canvas.transform);
			UnskippableMessageManager componentInChildren = messagePlayer.GetComponentInChildren<UnskippableMessageManager>();
			componentInChildren.SetDisplayMessage(message);
			componentInChildren.PlayAudio(afterCallAction);
			OpenMessagePanel();
			phoneCallSounds.Pause();
		});
	}

	private void OpenMessages()
	{
		if (messagePlayer == null)
		{
			throw new Exception("Instantiate not called beforehand.");
		}
		phoneCallSounds.Pause();
		messagesIcon.StopAnimation();
		OpenMessagePanel();
		messageController.PlayAudio();
		Save.SetIntroPlayed();
		taskbar.AddTaskbar(messagePlayer, messagesIcon.GetTaskbarIcon(), UIUtils.ToTitleCase(Icon.GetName(messagesIcon)));
	}

	private void OpenMessagePanel()
	{
		audioPlayer.PlayOpen();
		PanelManager.OpenWindow(messagePlayer);
		GetComponentInChildren<Panel>().ClosePanel();
	}
}
