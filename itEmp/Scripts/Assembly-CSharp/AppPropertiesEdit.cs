using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AppPropertiesEdit : MonoBehaviour
{
	[Header("Component Default")]
	public AppMovementFucus movementFucus;

	public WindowAppMinimalizeAnimation minimalizeAnimation;

	[Header("Components")]
	public AppProperties appProperties;

	public DirectoryManager directoryManager;

	public ComputerVariables computerVariables;

	public WarningDatabase warningDatabase;

	[Header("UI")]
	public TMP_Text NameObjectFront;

	public TMP_Text NameApp;

	public TMP_Text NameObject;

	public TMP_Text NameUser;

	public Image IconApp;

	public RectTransform BlockedClickProperties;

	[Header("UI Security")]
	public RectTransform Security_PermissionList;

	public Button ApplyButton;

	private bool isOpen;

	private FileSystemObject fileSystemObject;

	private List<FileSystemObject.Permission> modifiedPermission;

	public void OpenApp()
	{
	}

	public void OpenAppFromAppProperties(FileSystemObject fso, string appName, Sprite icon)
	{
	}

	public void CloseApp()
	{
	}

	public void RefreshUI()
	{
	}

	public void ToggleAllow(string name)
	{
	}

	public void ToggleDeny(string name)
	{
	}

	private FileSystemObject.Permission GetPermission(string name)
	{
		return null;
	}

	private void UpdatePermissions(List<FileSystemObject.PermissionChange> permsToUpdate)
	{
	}

	private void UpdatePrivateAllow(List<FileSystemObject.Permission> permissions)
	{
	}

	public void ButtonOk()
	{
	}

	public void ButtonApply()
	{
	}

	public void ButtonCancel()
	{
	}

	public void SetActiveApply(bool active)
	{
	}

	public void EventLogInterpreter(List<FileSystemObject.Permission> perActual, List<FileSystemObject.Permission> perNew)
	{
	}
}
