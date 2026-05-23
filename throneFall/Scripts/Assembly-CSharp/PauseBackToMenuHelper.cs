using UnityEngine;

public class PauseBackToMenuHelper : MonoBehaviour
{
	public void BackToMenu()
	{
		SceneTransitionManager.instance.TransitionFromLevelToLevelSelect();
	}
}
