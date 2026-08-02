using System.Collections.Generic;
using System.Linq;

public class UserMessagePanelCenter : Singleton<UserMessagePanelCenter>
{
	public List<MessageItem> messageItems = new List<MessageItem>();

	public float fadeInDuration = 0.5f;

	public float displayDelay = 1f;

	public float slideUpAmount = 100f;

	public float fadeOutDuration = 0.5f;

	private void Start()
	{
		messageItems = GetComponentsInChildren<MessageItem>().ToList();
	}

	public void SendMessageToPanel(string message)
	{
		MessageItem messageItem = messageItems.Find((MessageItem x) => x.transform.GetSiblingIndex() == messageItems.Count - 1);
		messageItem.transform.SetAsFirstSibling();
		if (!(messageItem == null))
		{
			messageItem.ShowMessage(message, fadeInDuration, displayDelay, slideUpAmount, fadeOutDuration);
		}
	}

	public void SendMessageToPanel(string message, float displayDuration)
	{
		MessageItem messageItem = messageItems.Find((MessageItem x) => x.transform.GetSiblingIndex() == messageItems.Count - 1);
		messageItem.transform.SetAsFirstSibling();
		if (!(messageItem == null))
		{
			messageItem.ShowMessage(message, fadeInDuration, displayDuration, slideUpAmount, fadeOutDuration);
		}
	}
}
