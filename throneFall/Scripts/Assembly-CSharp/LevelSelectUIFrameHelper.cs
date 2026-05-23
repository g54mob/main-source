using TMPro;
using UnityEngine;

public class LevelSelectUIFrameHelper : MonoBehaviour
{
	public UIFrame target;

	public TextMeshProUGUI levelTitle;

	public ThronefallUIElement highscoreButton;

	public ThronefallUIElement noSavePlayButton;

	public ThronefallUIElement saveUpperButton;

	public ThronefallUIElement saveLowerButton;

	public GameObject hasSaveParent;

	public GameObject hasNoSaveParent;

	public void OnShow()
	{
		MatchSaveLoadHandler.TryLoadRun(LevelInteractor.lastActiveLevelInfo.sceneName);
		if (MatchSaveLoadHandler.CurrentSave != null && !LevelInteractor.lastActiveLevelInfo.ignoreSaves && !MatchSaveLoadHandler.CurrentSave.runComplete)
		{
			hasSaveParent.SetActive(value: true);
			hasNoSaveParent.SetActive(value: false);
			target.firstSelected = saveLowerButton;
			highscoreButton.topNav = saveLowerButton;
			highscoreButton.botNav = saveUpperButton;
		}
		else
		{
			hasSaveParent.SetActive(value: false);
			hasNoSaveParent.SetActive(value: true);
			target.firstSelected = noSavePlayButton;
			highscoreButton.topNav = noSavePlayButton;
			highscoreButton.botNav = noSavePlayButton;
		}
	}

	public void TransitionToSelectedLevel()
	{
		LocalGamestate.SelectedGameMode = LocalGamestate.GameMode.Classic;
		SceneTransitionManager.instance.TransitionFromLevelSelectToLevel(LevelInteractor.lastActiveLevelInfo.sceneName);
	}

	public void SetOverrideSave(bool value)
	{
		MatchSaveLoadHandler.OverwriteCurrentSave = value;
	}
}
