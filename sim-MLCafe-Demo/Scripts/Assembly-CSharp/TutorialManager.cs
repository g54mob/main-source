using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

public class TutorialManager : MonoBehaviour
{
	public enum TutorialState
	{
		Stopped = -1,
		Enter = 0,
		MakeCoffee = 1,
		BringCoffee = 2,
		RunCafe = 3
	}

	[SerializeField]
	private TutorialState state;

	[SerializeField]
	private bool lockByTutorial;

	[SerializeField]
	private bool isRunning;

	[SerializeField]
	private string soundOnChecklistOptionCheck;

	[SerializeField]
	private List<TutorialSection> sections = new List<TutorialSection>();

	private int currentDialogIndex;

	public static UnityEvent OnNextTutorialState = new UnityEvent();

	private bool isAvailable;

	private static TutorialManager instance;

	public void Awake()
	{
		if (instance == null)
		{
			instance = this;
		}
		else
		{
			UnityEngine.Object.Destroy(this);
		}
		UnityEngine.Object.DontDestroyOnLoad(instance);
		if (GameSettings.IsValid() && GameSettings.GetActiveConfig() != null)
		{
			isAvailable = GameSettings.GetActiveConfig().generalSettings.tutorialAvailable;
		}
		else
		{
			isAvailable = true;
		}
	}

	private void Start()
	{
		state = TutorialState.Stopped;
	}

	public static bool IsValidated()
	{
		return instance != null;
	}

	public static bool IsRunning()
	{
		return instance.isRunning;
	}

	public static bool IsAvailable()
	{
		return instance.isAvailable;
	}

	public static void EnableTutorial()
	{
		instance.enabled = true;
	}

	public static void DisableTutorial()
	{
		instance.isAvailable = false;
	}

	public static bool GetLockByTutorial()
	{
		return instance.lockByTutorial;
	}

	public static TutorialState GetCurrentState()
	{
		return instance.state;
	}

	public static void TryShowCheckList(TutorialSection section)
	{
		PopupMessageManager.GetCheckListPopUp().InitCheckList(section.checkListTitleKey, section.options);
	}

	public static void HideCheckList()
	{
		PopupMessageManager.GetCheckListPopUp().Hide();
	}

	public static void TryCheckSectionChecklistOption(string checklistKey, TutorialState state)
	{
		TutorialSection tutorialSection = instance.sections.Find((TutorialSection x) => x.associatedState == state);
		if (tutorialSection == null)
		{
			return;
		}
		tutorialSection.GetCheckListOption(checklistKey).check = true;
		PopupMessageManager.GetCheckListPopUp().UpdateSlot(checklistKey);
		if (PopupMessageManager.GetCheckListPopUp().IsVisible())
		{
			SoundManager.PlaySoundOnce(instance.soundOnChecklistOptionCheck);
			if (tutorialSection.autoHideCheckList && !tutorialSection.options.Any((TutorialChecklistOption x) => !x.check))
			{
				TweenerManager.TweenTimeAction("DelayAutoHideCheckList", 1f, HideCheckList);
			}
		}
	}

	public static TutorialSection GetCurrentSection()
	{
		return instance.sections.Find((TutorialSection x) => x.associatedState == instance.state);
	}

	public static TutorialSection GetSectionOfState(TutorialState state)
	{
		return instance.sections.Find((TutorialSection x) => x.associatedState == state);
	}

	public static Dialog GetCurrentDialog(EntityNameTag nameTag, Action onNextTutorialState = null)
	{
		TutorialSection tutorialSection = instance.sections.Find((TutorialSection x) => x.associatedState == instance.state);
		if (tutorialSection == null)
		{
			return null;
		}
		if (instance.currentDialogIndex >= tutorialSection.dialogSequences.Count)
		{
			instance.currentDialogIndex = 0;
			NextTutorialState();
			if (onNextTutorialState == null)
			{
				return null;
			}
			onNextTutorialState();
			return null;
		}
		return tutorialSection.dialogSequences[instance.currentDialogIndex].AsDialog(nameTag);
	}

	public static void PlayTutorialDialog(Dialog dialog, Action onFinishedSequence = null)
	{
		if (!DialogSequenceManager.PlayDialogSequence(dialog))
		{
			return;
		}
		DialogBoxComponent globalDialogBox = DialogSequenceManager.GetGlobalDialogBox();
		globalDialogBox.OnFinished = (UnityAction)Delegate.Combine(globalDialogBox.OnFinished, (UnityAction)delegate
		{
			instance.currentDialogIndex++;
			if (instance.currentDialogIndex >= dialog.sentences.Length && onFinishedSequence != null)
			{
				onFinishedSequence();
			}
		});
	}

	public static void ResetDialogIndex()
	{
		instance.currentDialogIndex = 0;
		DialogSequenceManager.GetGlobalDialogBox().OnFinished = delegate
		{
		};
	}

	public static void StartTutorial()
	{
		instance.lockByTutorial = true;
		instance.isRunning = true;
		instance.state = TutorialState.Enter;
		WorldTime.PauseSimulation();
	}

	public static void StopTutorial()
	{
		instance.lockByTutorial = false;
		instance.isRunning = false;
		instance.state = TutorialState.Stopped;
		WorldTime.ResumeSimulation();
	}

	public static void NextTutorialState()
	{
		instance.state++;
		OnNextTutorialState.Invoke();
	}

	public static void PreviousTutorialState()
	{
		instance.state--;
	}

	public static void ChangeTutorialStateTo(TutorialState state)
	{
		if (instance.state < state)
		{
			OnNextTutorialState.Invoke();
		}
		instance.state = state;
	}
}
