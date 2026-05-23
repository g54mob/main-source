using UnityEngine;

public class TransitionToSelectedLevelHelper : MonoBehaviour
{
	public bool justRestartCurrentLevel;

	public void TransitionToSelectedLevel()
	{
		LocalGamestate.SelectedGameMode = LocalGamestate.GameMode.Classic;
		if (justRestartCurrentLevel)
		{
			SceneTransitionManager.instance.RestartCurrentLevel();
		}
		else
		{
			SceneTransitionManager.instance.TransitionFromLevelSelectToLevel(LevelInteractor.lastActiveLevelInfo.sceneName);
		}
	}
}
