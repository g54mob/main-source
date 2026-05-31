using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AppErrorOpenUnsupportedApplication : MonoBehaviour
{
	[Header("Component Default")]
	public AppMovementFucus movementFucus;

	public WindowAppMinimalizeAnimation minimalizeAnimation;

	public AppStore appStore;

	public appNotepad appNotepad;

	[Header("UI")]
	public TMP_Text TitleWindow;

	public Button AppSelectNotepadButton;

	public RectTransform AppSelectNotepadBox;

	public Image OnlyOnceButtonOutline;

	public TMP_Text OnlyOnceButtonText;

	public Button OnlyOnceButton;

	public RectTransform ButtonOtherClickExit;

	private bool isOpen;

	private string extension;

	public FileSystemObject fileOpen;

	public Action actBlueButton;

	public void OpenApp(FileSystemObject fso, string extension = "")
	{
	}

	public void CloseApp()
	{
	}

	public void ButtonSelectNotepad()
	{
	}

	public void ButtonOnlyOnce()
	{
	}

	public void ButtonBrowseAppsInAP()
	{
	}

	private string GenerateFakeBinaryData(int length)
	{
		return null;
	}
}
