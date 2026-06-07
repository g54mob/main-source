using UnityEngine;
using UnityEngine.Localization.Tables;

public class MiniTool : MonoBehaviour
{
	public enum MessageType
	{
		Info = 0,
		Warning = 1,
		Error = 2
	}

	public float messageStartDelay;

	public float messageEndDelay;

	public float messageSecondsPerLine;

	public Color[] messageColors;

	[SerializeField]
	private MiniToolMessagePanel systemMessagePanel;

	[SerializeField]
	private MiniToolMessagePanel userMessagePanel;

	public void ShowSystemMessage(string message, MessageType messageType, bool persistent)
	{
	}

	public void ShowSystemMessage(TableReference tableRef, TableEntryReference entryRef, MessageType messageType, bool persistent)
	{
	}

	public void ShowUserMessage(string message, MessageType messageType, bool persistent)
	{
	}

	public void HideUserMessage()
	{
	}

	public void HideSystemMessage()
	{
	}

	public bool IsShowingSystemMessage()
	{
		return false;
	}

	public bool IsShowingUserMessage()
	{
		return false;
	}

	public string GetSystemMessage()
	{
		return null;
	}

	public string GetUserMessage()
	{
		return null;
	}

	public void OnGadgetTurnOn()
	{
	}

	public void OnGadgetTurnOff()
	{
	}

	public bool IsShowingPersistentSystemMessage()
	{
		return false;
	}
}
