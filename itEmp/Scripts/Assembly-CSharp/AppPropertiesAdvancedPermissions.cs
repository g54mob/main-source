using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AppPropertiesAdvancedPermissions : MonoBehaviour
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
	public TMP_Text NameApp;

	public TMP_Text NameObject;

	public TMP_Text NameOwner;

	public Image IconApp;

	public RectTransform BlockedClickProperties;

	public Button ApplyButton;

	public Button EnableInheritanceButton;

	public Button DisableInheritanceButton;

	[Header("UI List")]
	public RectTransform PermissionEntriesList;

	public RectTransform PermissionEntriesPrefab;

	private bool isOpen;

	private FileSystemObject fileSystemObject;

	private bool modifiedpermissionsInheritance;

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

	private void CreateRow(string subject, string type, string access, string inheriedFrom)
	{
	}

	public void ButtonSetInheritance(bool value)
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

	public void EventLogInterpreter(bool perActual, bool perNew)
	{
	}
}
