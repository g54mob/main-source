using System;
using UnityEngine;

public class EmergencyMessagePopup : MonoBehaviour
{
	public static int MINUTES_PLAYED_SHUTDOWN_CALL = 5;

	[SerializeField]
	private CallPopupCreator callNotifier;

	[SerializeField]
	private Canvas canvas;

	[SerializeField]
	private MessageContainerController messages;

	public bool InstantiatePopupMessage(MessageSpawner.MessageCodes messageType, float waitDuration = 0f)
	{
		if (ShouldShowMessage(messageType) && !Save.GetMessages().Contains((int)messageType))
		{
			AddEmergencyMessage(messageType);
			Save.AddMessage((int)messageType);
			callNotifier.CreateDelayedNewMessage(waitDuration);
			return true;
		}
		return false;
	}

	public void AddEmergencyMessage(MessageSpawner.MessageCodes messageType)
	{
		messages.AddMessage(MessageSpawner.GetMessageAudio(messageType));
	}

	private bool ShouldShowMessage(MessageSpawner.MessageCodes messageType)
	{
		switch (messageType)
		{
		case MessageSpawner.MessageCodes.FrogMan:
		case MessageSpawner.MessageCodes.IllegalKeyword:
			return true;
		case MessageSpawner.MessageCodes.ArrestZoran:
			return LevelManager.GetCurrLevel() != 8;
		case MessageSpawner.MessageCodes.FirstShutdown:
			return TimeKeeper.GetMinutesPlayed() <= (double)MINUTES_PLAYED_SHUTDOWN_CALL;
		default:
			throw new ArgumentException($"Unexpected messageType: {messageType}");
		}
	}
}
