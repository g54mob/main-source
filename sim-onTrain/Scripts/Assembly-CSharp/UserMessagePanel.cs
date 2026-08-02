using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Localization;

public class UserMessagePanel : Singleton<UserMessagePanel>
{
	public List<MessageItem> messageItems = new List<MessageItem>();

	public float fadeInDuration = 0.5f;

	public float displayDelay = 1f;

	public float slideUpAmount = 100f;

	public float fadeOutDuration = 0.5f;

	[SerializeField]
	private LocalizedString inventoryIsFullLocalized;

	[SerializeField]
	private LocalizedString wrenchWarningLocalized;

	private void Start()
	{
		messageItems = GetComponentsInChildren<MessageItem>().ToList();
	}

	public void SendMessageToPanel(string message, CollectableItemData data)
	{
		MessageItem messageItem = messageItems.Find((MessageItem x) => x.transform.GetSiblingIndex() == messageItems.Count - 1);
		messageItem.transform.SetAsFirstSibling();
		if (!(messageItem == null))
		{
			messageItem.ShowMessage(message, data, fadeInDuration, displayDelay, slideUpAmount, fadeOutDuration);
		}
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

	public void ShowInventoryFullMessage()
	{
		string message = "Inventory is full!";
		if (inventoryIsFullLocalized != null && !inventoryIsFullLocalized.IsEmpty)
		{
			string localizedString = inventoryIsFullLocalized.GetLocalizedString();
			if (!string.IsNullOrEmpty(localizedString))
			{
				message = localizedString;
			}
		}
		SendMessageToPanel(message);
	}

	public void ShowWrenchWarningMessage()
	{
		string message = "Requires a Wrench to build";
		string localizedString = ((wrenchWarningLocalized != null && !wrenchWarningLocalized.IsEmpty) ? wrenchWarningLocalized : new LocalizedString("Localization Table", "Key_WrenchWarning")).GetLocalizedString();
		if (!string.IsNullOrEmpty(localizedString))
		{
			message = localizedString;
		}
		SendMessageToPanel(message);
	}
}
