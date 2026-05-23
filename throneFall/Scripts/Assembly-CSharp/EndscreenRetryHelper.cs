using UnityEngine;

public class EndscreenRetryHelper : MonoBehaviour
{
	public void InstantRestartIfInSaveForbiddenMap()
	{
		if (MatchSaveLoadHandler.SaveLoadForbidden)
		{
			UIFrameManager.instance.CloseAllFrames();
			base.gameObject.SetActive(value: false);
			MatchSaveLoadHandler.OverwriteCurrentSave = true;
			SceneTransitionManager.instance.RestartCurrentLevel();
		}
	}

	public void FreshStart()
	{
		MatchSaveLoadHandler.OverwriteCurrentSave = true;
		UIFrameManager.OpenInMapPerkSelect();
	}

	public void RestartLastDay()
	{
		if (EnemySpawner.instance.Wavenumber > 0)
		{
			MatchSaveLoadHandler.OverwriteCurrentSave = false;
			MatchSaveLoadHandler.CurrentSave.ApplyLoadout();
		}
		SceneTransitionManager.instance.RestartCurrentLevel();
	}
}
