using UnityEngine;

public class TitleScreenUIHelper : MonoBehaviour
{
	[SerializeField]
	private Equippable tutorialWeapon;

	private float framesTillYouCanPlay = 4f;

	private void Update()
	{
		framesTillYouCanPlay -= 1f;
	}

	public void ClickPlay()
	{
		if (!(framesTillYouCanPlay > 0f))
		{
			if (LevelProgressManager.instance.GetLevelDataForScene("Neuland(Tutorial)").highscoreBest > 0 || LevelProgressManager.instance.GetLevelDataForScene("Neuland(Tutorial)").beatenBest)
			{
				Debug.Log("Start game in level select as tutorial has already been played.");
				SceneTransitionManager.instance.TransitionFromNullToLevelSelect();
				return;
			}
			Debug.Log("Start it tutorial!");
			PerkManager.instance.CurrentlyEquipped.Clear();
			PerkManager.instance.CurrentlyEquipped.Add(tutorialWeapon);
			LocalGamestate.SelectedGameMode = LocalGamestate.GameMode.Classic;
			SceneTransitionManager.instance.TransitionFromNullToLevel("Neuland(Tutorial)");
		}
	}
}
