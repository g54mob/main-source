using UnityEngine;

public class BackToTitlescreenUIHelper : MonoBehaviour
{
	public void TransitionToMainMenu()
	{
		SceneTransitionManager.instance.TransitionToMainMenu();
	}
}
