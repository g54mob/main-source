using M4.Session;
using UnityEngine;

public class RewiredContinue : MonoBehaviour
{
	private void Update()
	{
		if (FlotsamInputManager.GetAnyButtonUp())
		{
			Continue();
		}
	}

	public void Continue()
	{
		if (!Session.Profile.EndRun())
		{
			LoadingScreen.LoadScene("_01_MainMenu");
		}
	}
}
