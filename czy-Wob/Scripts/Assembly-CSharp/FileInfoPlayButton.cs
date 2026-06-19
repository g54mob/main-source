using UnityEngine;

public class FileInfoPlayButton : MonoBehaviour
{
	public FileInfoLoader fileInfoRef;

	private string playFileSound = "mainMenu_playButton";

	private bool hasBeenClicked;

	public void PlayFile()
	{
		if (!hasBeenClicked)
		{
			hasBeenClicked = true;
			AudioController.Play(playFileSound);
			GetComponent<CoreButtonUnityGUI>().interactable = false;
			fileInfoRef.LoadSelectedFile();
		}
	}
}
