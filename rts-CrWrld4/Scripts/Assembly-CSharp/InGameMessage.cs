using System.Collections.Generic;
using NBT.Tags;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InGameMessage : MonoBehaviour
{
	public class MessageItem
	{
		public string messageID;

		public string buttonText;

		public string buttonText2;

		public string messageChannel;

		public bool pause;

		public bool autoClose;

		public bool autoUnpause;

		public MessageItem()
		{
		}

		public MessageItem(string messageID, string buttonText, string buttonText2, string messageChannel, bool pause, bool autoClose, bool autoUnpause)
		{
		}

		public void ReadData(Tag tag)
		{
		}

		public TagCompound WriteData()
		{
			return null;
		}
	}

	public GameObject textBlockPrefab;

	public GameObject imageBlockPrefab;

	public GameObject blocksContainer;

	public GameObject controlRow;

	public TextMeshProUGUI buttonText;

	public TextMeshProUGUI button2Text;

	public GameObject button;

	public GameObject button2;

	private string messageChannel;

	private string messageID;

	public Outline buttonOutline;

	public Outline button2Outline;

	private bool pause;

	private bool autoClose;

	private bool autoUnpause;

	private Queue<MessageItem> queuedMessages;

	private float timeCounter;

	private List<ADABlockRow> blocks;

	public static void Show(string messageID, string buttonText, string buttonText2, string messageChannel, bool pause, bool autoClose = false, bool autoUnpause = false)
	{
	}

	public static void Close(bool unpause)
	{
	}

	public void QueueMessage(MessageItem mi)
	{
	}

	public void DequeueMessage()
	{
	}

	public void Init(string messageID, string text, string text2, string messageChannel, bool pause, bool autoClose, bool autoUnpause)
	{
	}

	public void Update()
	{
	}

	public void OnButtonClick()
	{
	}

	public void OnButton2Click()
	{
	}

	public void RefreshBlocks()
	{
	}

	public void SetBlockText(int index, string text)
	{
	}

	public static void DestroyChildren(Transform transform)
	{
	}

	public void ReadData(Tag tag)
	{
	}

	public void WriteData(TagCompound baseTag)
	{
	}
}
