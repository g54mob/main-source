using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FileInfoNewGamePlayButton : MonoBehaviour
{
	public NameInput fileName;

	public FileInfoLoader fileInfoRef;

	public TextMeshProUGUI textRef;

	public Image backingSprite;

	public Color textColorValid;

	public Color textColorInvalid;

	public Color backingSpriteColorValid;

	public Color backingSpriteColorInvalid;

	private bool isValid;

	private bool hasBeenPressed;

	private string playFileSound = "mainMenu_playButton";

	private CoreButtonUnityGUI buttonRef;

	private void Awake()
	{
		buttonRef = GetComponent<CoreButtonUnityGUI>();
		UpdateValidity();
	}

	private void Update()
	{
		UpdateValidity();
	}

	private void UpdateValidity()
	{
		isValid = fileName.IsStringValid();
		if (isValid)
		{
			buttonRef.interactable = true;
			textRef.color = textColorValid;
			backingSprite.color = backingSpriteColorValid;
		}
		else
		{
			buttonRef.interactable = false;
			textRef.color = textColorInvalid;
			backingSprite.color = backingSpriteColorInvalid;
		}
	}

	public void OnClick()
	{
		if (fileName.IsStringValid() && !hasBeenPressed)
		{
			hasBeenPressed = true;
			AudioController.Play(playFileSound);
			string newFile = SaveLoadManager.CreateNewFile(fileName.GetInputString());
			fileInfoRef.SetAssociatedFile(newFile, null);
			fileInfoRef.LoadSelectedFile();
		}
	}
}
