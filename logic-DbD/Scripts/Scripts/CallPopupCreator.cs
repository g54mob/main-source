using System;
using System.Collections;
using UnityEngine;

public class CallPopupCreator : MonoBehaviour
{
	[SerializeField]
	private GameObject newMessagePrefab;

	[SerializeField]
	private GameObject unskippableMessagePrefab;

	[SerializeField]
	private GameObject messagesPanel;

	[SerializeField]
	private AudioMessageManager audioManager;

	[SerializeField]
	private Icon messagesIcon;

	[SerializeField]
	private TaskbarManager taskbarManager;

	private Canvas canvas;

	private static GameObject popup;

	public const float DEFAULT_NEW_MESSAGE_POPUP_DELAY = 3f;

	private void Start()
	{
		canvas = UIUtils.FindCanvasFromChild(base.transform);
	}

	public void ClosePopup()
	{
		if (popup != null)
		{
			popup.GetComponent<Panel>().ClosePanel();
		}
	}

	public void CreateDelayedNewMessage()
	{
		CreateDelayedNewMessage(3f);
	}

	public void CreateDelayedNewMessage(float delayTime)
	{
		CreateDelayedNewMessage(delayTime, delegate
		{
		});
	}

	public void CreateDelayedNewMessage(float delayTime, Action additionalCloseAction)
	{
		StartCoroutine(CreateNewMessageNotification(delayTime, additionalCloseAction));
	}

	private IEnumerator CreateNewMessageNotification(float delayTime, Action additionalCloseAction)
	{
		yield return new WaitForSeconds(delayTime);
		if (popup != null)
		{
			UnityEngine.Object.Destroy(popup);
		}
		popup = UnityEngine.Object.Instantiate(newMessagePrefab, base.transform.position, Quaternion.identity, canvas.transform);
		popup.GetComponent<CallHandler>().InstantiateNewCall(messagesPanel, audioManager, messagesIcon, taskbarManager, additionalCloseAction);
		PanelManager.OpenWindow(popup);
	}

	public void CreateUnskippableNotification(Message message, Action afterMessageAction)
	{
		if (popup != null)
		{
			UnityEngine.Object.Destroy(popup);
		}
		popup = UnityEngine.Object.Instantiate(newMessagePrefab, base.transform.position, Quaternion.identity, canvas.transform);
		popup.GetComponent<CallHandler>().InstantiateUnskippableCall(unskippableMessagePrefab, message, canvas, afterMessageAction);
		PanelManager.OpenWindow(popup);
	}
}
