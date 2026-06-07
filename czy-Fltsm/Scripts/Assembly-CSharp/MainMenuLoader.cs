using M4.Session;
using UnityEngine;

public class MainMenuLoader : MonoBehaviour
{
	private bool _waitingForSession = true;

	private void Update()
	{
		if (_waitingForSession && Session.IsReady)
		{
			_waitingForSession = false;
			LoadingScreen.LoadScene("_01_MainMenu");
		}
	}
}
