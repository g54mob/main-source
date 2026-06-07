using UnityEngine;

public class AppPMail : MonoBehaviour
{
	[Header("Component Default")]
	[AppNameDropdown]
	public string nameInAppBase;

	public AppMovementFucus movementFucus;

	public WindowAppMinimalizeAnimation minimalizeAnimation;

	private bool isOpen;

	private AppBase appBase;

	private DirectoryManager directoryManager;

	private string AppNameFromApplicationBase;

	public void OpenApp()
	{
	}

	public void CloseApp()
	{
	}

	public bool ValidateFiles()
	{
		return false;
	}
}
