using UnityEngine;
using UnityEngine.UI;

public class VersionNumbering : MonoBehaviour
{
	public Character character;

	public Text versionNumber;

	public OfflineProgressSplashScreen screen;

	public string curBeta;

	private void Start()
	{
		versionNumber.text = "<b>Build " + character.getVersionAsString() + "</b>";
	}

	public void showScreen()
	{
		screen.openScreen();
	}
}
