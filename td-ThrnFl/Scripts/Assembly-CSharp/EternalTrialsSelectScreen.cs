using UnityEngine;

public class EternalTrialsSelectScreen : MonoBehaviour
{
	public UIFrame targetFrame;

	public UIFrame loadoutSelectionFrame;

	public GameObject runExistantButtons;

	public GameObject noRunSavedButtons;

	public ThronefallUIElement runExistantFirstSelected;

	public ThronefallUIElement noRunSavedFirstSelected;

	public ThronefallUIElement highscoreButton;

	public ThronefallUIElement noSaveButton;

	public ThronefallUIElement saveUpperButton;

	public ThronefallUIElement saveLowerButton;

	public void ContinueRun()
	{
		LocalGamestate.SelectedGameMode = LocalGamestate.GameMode.EternalTrial;
		if (EternalTrialsRunManager.CurrentRun.inGame)
		{
			EternalTrialsRunManager.LoadNextMap();
		}
		else
		{
			UIFrameManager.instance.ChangeActiveFrame(loadoutSelectionFrame);
		}
	}

	public void NewRun()
	{
		LocalGamestate.SelectedGameMode = LocalGamestate.GameMode.EternalTrial;
		EternalTrialsRunManager.DiscardActiveRun();
		EternalTrialsRunManager.CreateFreshRun();
		UIFrameManager.instance.ChangeActiveFrame(loadoutSelectionFrame);
	}

	public void Refresh()
	{
		if (!EternalTrialsRunManager.HasOngoingRun)
		{
			EternalTrialsRunManager.TurnLastDiscardedRunIntoCurrentRun();
		}
		MatchSaveLoadHandler.TryLoadRun("ET_CurrentLevel");
		if (EternalTrialsRunManager.HasOngoingRun)
		{
			runExistantButtons.SetActive(value: true);
			noRunSavedButtons.SetActive(value: false);
			targetFrame.firstSelected = runExistantFirstSelected;
			highscoreButton.topNav = saveLowerButton;
			highscoreButton.botNav = saveUpperButton;
		}
		else
		{
			runExistantButtons.SetActive(value: false);
			noRunSavedButtons.SetActive(value: true);
			targetFrame.firstSelected = noRunSavedFirstSelected;
			highscoreButton.topNav = noSaveButton;
			highscoreButton.botNav = noSaveButton;
		}
	}
}
