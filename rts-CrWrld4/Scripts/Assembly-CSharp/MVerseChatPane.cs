using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MVerseChatPane : MonoBehaviour
{
	private int MAX_MESSAGES;

	private int MAX_MESSAGE_LENGTH;

	public GameObject chatMessagePrefab;

	public Transform chatMessageContainer;

	public ScrollRect scrollRect;

	public TMP_InputField inputField;

	public GameObject closeButton;

	public Transform gameChatContainer;

	private bool _inLobby;

	public bool inLobby
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	public void MoveToGame()
	{
	}

	public void Show()
	{
	}

	public void OnEnable()
	{
	}

	public void Update()
	{
	}

	public void OnSendMessageButton()
	{
	}

	private void HandleCommand(string message)
	{
	}

	private void HandleSendCommand(string[] s)
	{
	}

	public void OnSendMessage(string val)
	{
	}

	public void ReceiveMessage(uint senderNetId, string message)
	{
	}

	public void CreateMessage(string senderName, string message)
	{
	}

	private void RemoveMessage()
	{
	}

	private IEnumerator ForceScroll()
	{
		return null;
	}

	private IEnumerator ForceSelect()
	{
		return null;
	}
}
