using M4.Session;
using UnityEngine;

public class AlphaMenu : MonoBehaviour
{
	private void Start()
	{
		base.gameObject.SetActive(Session.Platform.ItIsInitialized);
	}

	public void LoadMainMenu()
	{
		LoadingScreen.LoadScene("_01_MainMenu");
	}

	public void QuitGame()
	{
		GameManager.QuitToDesktop();
	}
}
