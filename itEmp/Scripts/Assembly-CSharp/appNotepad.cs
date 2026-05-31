using TMPro;
using UnityEngine;

public class appNotepad : MonoBehaviour
{
	[Header("Component Default")]
	[AppNameDropdown]
	public string nameInAppBase;

	public AppMovementFucus movementFucus;

	public WindowAppMinimalizeAnimation minimalizeAnimation;

	public AppBase appBase;

	[Header("App Object")]
	public Transform applicationLayout;

	[Header("UI")]
	public TMP_InputField notpadContent;

	public static string[] supportedExtensions;

	private FileSystemObject currentFile;

	private bool isOpen;

	private void OnValidate()
	{
	}

	public void OpenApp()
	{
	}

	public void OpenAppWithFile(FileSystemObject file)
	{
	}

	public void CloseApp()
	{
	}

	public void Save()
	{
	}
}
