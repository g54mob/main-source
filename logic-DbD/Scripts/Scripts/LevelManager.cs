using System;
using System.Linq;
using TMPro;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
	[SerializeField]
	private IconGenerator iconGenerator;

	[SerializeField]
	private PanelManager tables;

	[SerializeField]
	private PanelManager clues;

	[SerializeField]
	private TMP_InputField queryInput;

	[SerializeField]
	private ClueExplorer clueExplorer;

	[SerializeField]
	private WebBrowserController webBrowser;

	[SerializeField]
	private AudioMessageManager messages;

	[SerializeField]
	private AnswerHandler arrestWindow;

	[SerializeField]
	private CallPopupCreator callNotifier;

	[SerializeField]
	private IconNotificationManager iconNotificationManager;

	[SerializeField]
	private AssistantController assistant;

	[SerializeField]
	private AssistantSpawner peeker;

	[SerializeField]
	private GameObject iconContainer;

	[SerializeField]
	private ClickDrag clickDrag;

	[SerializeField]
	private GameObject taskbar;

	public const int MAX_LEVEL = 3;

	private static int currLevel;

	private DateTime currentLevelStartTime = DateTime.Now;

	public static void SetLevel(int level)
	{
		currLevel = level;
	}

	public static int GetCurrLevel()
	{
		return currLevel;
	}

	public bool LevelUp(bool isCorrectArrest)
	{
		if (!isCorrectArrest && !Save.GetHasBeenWrong())
		{
			Save.SetHasBeenWrong();
		}
		else if (!isCorrectArrest)
		{
			arrestWindow.ClearWarrantImage();
			return false;
		}
		if (!isCorrectArrest)
		{
			Save.SetTutorialSeen(val: false);
		}
		currLevel = Math.Min(currLevel + 1, 4);
		tables.ClearNames(DatabaseUtils.GetAllTableNames());
		clues.ClearNames();
		Save.SetIntroPlayed(value: false);
		Save.ClearIconClicks();
		Save.SaveQueryHintGiven(0);
		Save.SaveHintsGiven(0);
		Save.SetHasRecentlyFailed(!isCorrectArrest);
		queryInput.text = "";
		DatabaseUtils.DropAllTables();
		CreateTables.CreateBuiltInTables(hasLoad: false);
		TableNameGenerator.ClearName();
		if (currLevel <= 3)
		{
			arrestWindow.SetWarrantImage();
			arrestWindow.ClearArrestedSuspects();
			clueExplorer.ClearClues();
			iconNotificationManager.SetIconNotifications();
			messages.UpdateMessages(currLevel, isCorrectArrest);
		}
		else
		{
			foreach (Transform item in iconContainer.transform)
			{
				if (Icon.SKIP_ENDING_ICONS.Contains(item.name))
				{
					Vector2 removedIconLocalPosition = item.localPosition;
					ThomasGridLayoutGroup.RemoveIconPos(item.localPosition);
					UnityEngine.Object.Destroy(item.gameObject);
					ThomasGridLayoutGroup.ShiftIconsUp(removedIconLocalPosition, iconContainer.transform);
				}
			}
		}
		currentLevelStartTime = DateTime.Now;
		Debug.Log($"Level {currLevel} loaded.");
		return true;
	}

	public void OnNewLevel()
	{
		iconGenerator.ClearIcons();
		iconGenerator.GenerateIcons();
		assistant.SetLast();
		UIUtils.SetLayer(taskbar.GetComponent<Transform>(), 2);
		if (!IsCredits())
		{
			callNotifier.CreateDelayedNewMessage();
		}
		Save.SaveGame();
	}

	public void OnFail(Action afterFailAction)
	{
		bool hasBeenWrongAgain = Save.GetHasBeenWrongAgain();
		MessageSpawner.MessageCodes messageCode = (hasBeenWrongAgain ? MessageSpawner.MessageCodes.TemporaryLeave2 : MessageSpawner.MessageCodes.TemporaryLeave);
		if (!hasBeenWrongAgain)
		{
			Save.SetHasBeenWrongAgain();
		}
		CreateUnskippableNotificationPopup(messageCode, afterFailAction);
	}

	public void OnDemoEnd(Action afterCallAction, bool isCorrectArrest)
	{
		MessageSpawner.MessageCodes messageCode = (isCorrectArrest ? MessageSpawner.MessageCodes.DemoEndCorrect : MessageSpawner.MessageCodes.DemoEndWrong);
		CreateUnskippableNotificationPopup(messageCode, afterCallAction);
	}

	private void CreateUnskippableNotificationPopup(MessageSpawner.MessageCodes messageCode, Action postMessageAction)
	{
		Message messageAudio = MessageSpawner.GetMessageAudio(messageCode);
		callNotifier.CreateUnskippableNotification(messageAudio, postMessageAction);
		UIUtils.SetLayer(taskbar.GetComponent<Transform>(), 2);
		assistant.SetLast();
	}

	public static bool IsCredits()
	{
		return currLevel == 4;
	}
}
