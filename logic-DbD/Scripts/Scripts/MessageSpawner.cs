using System;
using System.Collections.Generic;
using UnityEngine;

public class MessageSpawner : MonoBehaviour
{
	public enum MessageTypes
	{
		Intro = 0,
		Correct = 1,
		Incorrect = 2,
		Late = 3
	}

	public enum MessageCodes
	{
		FrogMan = 400,
		LateLevel4 = 444,
		IllegalKeyword = 777,
		FirstShutdown = 909,
		ArrestZoran = 1000,
		TemporaryLeave = 1111,
		TemporaryLeave2 = 1112,
		DemoEndCorrect = 9998,
		DemoEndWrong = 9999
	}

	public static readonly Dictionary<int, string> MESSAGE_NAMES = new Dictionary<int, string>
	{
		{ 0, "Welcome recruit!" },
		{ 1, "Catching a litterbug" },
		{ 2, "TOP SECRET MESSAGE" },
		{ 3, "a landlord needs us!" },
		{ 4, "WAR CRIMINAL ON THE LOOSE" },
		{ 5, "Our country needs you" },
		{ 6, "A MURDER!!!" },
		{ 7, "trouble in LZU" },
		{ 8, "a last case if you want" },
		{ 9, "Here's the plan" }
	};

	[SerializeField]
	private MessageContainerController messageContainerController;

	[SerializeField]
	private EmergencyMessagePopup emergencyMessageSpawner;

	private void Awake()
	{
		int currLevel = LevelManager.GetCurrLevel();
		ICollection<int> messages = Save.GetMessages();
		if (HasCurrentLevelMessage(currLevel, messages))
		{
			CreateMessages(messages);
		}
		else
		{
			CreateMessages(currLevel);
		}
		messageContainerController.SetMostRecentMessage();
	}

	private bool HasCurrentLevelMessage(int currentLevel, ICollection<int> messageNumbers)
	{
		if (messageNumbers.Count <= 0)
		{
			return false;
		}
		if (currentLevel == 4 && messageNumbers.Contains(444))
		{
			return true;
		}
		if (currentLevel <= 3 && !messageNumbers.Contains(currentLevel))
		{
			return messageNumbers.Contains(GetWrongMessageCode(currentLevel));
		}
		return true;
	}

	private int GetWrongMessageCode(int level)
	{
		if (level == 0)
		{
			return 0;
		}
		return level * 10;
	}

	private void CreateMessages(ICollection<int> messages)
	{
		foreach (int message in messages)
		{
			if (message == 0)
			{
				AddLevelStartMessage(message, MessageTypes.Intro);
			}
			else if (message < MESSAGE_NAMES.Count)
			{
				AddLevelStartMessage(message, MessageTypes.Correct);
			}
			else if (message / 10 < MESSAGE_NAMES.Count)
			{
				AddLevelStartMessage(message / 10, MessageTypes.Incorrect);
			}
			else if (message == 444)
			{
				AddLevelStartMessage(4, MessageTypes.Late);
			}
			else
			{
				emergencyMessageSpawner.AddEmergencyMessage((MessageCodes)message);
			}
		}
	}

	private void CreateMessages(int level)
	{
		for (int i = 0; i <= Math.Min(level, 3); i++)
		{
			if (i == 0)
			{
				AddLevelStartMessage(i, MessageTypes.Intro);
				Save.AddMessage(i);
			}
			else
			{
				AddLevelStartMessage(i, MessageTypes.Correct);
				Save.AddMessage(i);
			}
		}
	}

	public void AddLevelStartMessage(int level, bool isCorrectArrest)
	{
		AddLevelStartMessage(level, isCorrectArrest ? MessageTypes.Correct : MessageTypes.Incorrect);
		Save.AddMessage(isCorrectArrest ? level : GetWrongMessageCode(level));
	}

	public void AddLevelStartMessage(int level, MessageCodes messageCode)
	{
		AddLevelStartMessage(level, messageCode);
		Save.AddMessage((int)messageCode);
	}

	public void AddLevelStartMessage(int level, MessageTypes messageType)
	{
		string fileName = GetFileName(messageType);
		Message audioMessage = ResourcesManager.GetAudioMessage($"Messages/{level}/", fileName);
		audioMessage.title = MESSAGE_NAMES[level];
		messageContainerController.AddMessage(audioMessage);
	}

	public static string GetFileName(MessageTypes messageType)
	{
		return messageType switch
		{
			MessageTypes.Correct => "correct", 
			MessageTypes.Incorrect => "wrong", 
			MessageTypes.Intro => "intro", 
			MessageTypes.Late => "late", 
			_ => throw new ArgumentException($"Unexpected messageType: {messageType}"), 
		};
	}

	public static string GetMessageNameFromCode(MessageCodes messageCode)
	{
		return messageCode switch
		{
			MessageCodes.FrogMan => "This is not a joke", 
			MessageCodes.IllegalKeyword => "WHAT ARE YOU DOING", 
			MessageCodes.FirstShutdown => "Leaving early", 
			MessageCodes.ArrestZoran => "Very funny", 
			MessageCodes.TemporaryLeave => "Goodbye", 
			MessageCodes.TemporaryLeave2 => "Goodbye Again", 
			MessageCodes.DemoEndCorrect => "APPLY NOW correct", 
			MessageCodes.DemoEndWrong => "APPLY NOW wrong", 
			_ => throw new ArgumentException($"Unexpected messageCode: {messageCode}"), 
		};
	}

	public static Message GetMessageAudio(MessageCodes messageCode)
	{
		string messageNameFromCode = GetMessageNameFromCode(messageCode);
		return ResourcesManager.GetAudioMessage("Messages/Misc/", messageNameFromCode);
	}
}
