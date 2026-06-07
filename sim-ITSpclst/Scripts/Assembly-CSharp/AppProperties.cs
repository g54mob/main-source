using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AppProperties : MonoBehaviour
{
	[Header("Component Default")]
	public AppBase appBase;

	public AppMovementFucus movementFucus;

	public WindowAppMinimalizeAnimation minimalizeAnimation;

	[Header("Components")]
	public DirectoryManager directoryManager;

	public AppPropertiesEdit appPropertiesEdit;

	public AppPropertiesAdvancedPermissions appPropertiesAdvancedPermissions;

	public ComputerVariables computerVariables;

	public appExplorer appExplorer;

	public PersonalizationSettings personalizationSettings;

	public AdminAcceptData adminAcceptData;

	[HideInInspector]
	public bool isOpen;

	[HideInInspector]
	public bool firstOpen;

	[Header("UI")]
	public TMP_Text NameApp;

	public Image IconApp;

	[Header("UI General")]
	public TMP_Text General_NameApp;

	public Image General_IconApp;

	public TMP_Text General_FileTypeValue;

	public TMP_Text General_Path;

	public TMP_Text General_SizeValue;

	public TMP_Text General_SizeOnDiskValue;

	[Header("UI Security")]
	public TMP_Text Security_Path;

	public TMP_Text Security_UserName;

	public TMP_Text Security_PermissionFor;

	public RectTransform Security_PermissionList;

	[Header("Menu")]
	public AppPropertiesMenu[] Menu;

	private FileSystemObject fileSystemObject;

	private string appName;

	[Header("Accept View")]
	public GameObject viewAcceptAdmin;

	public GameObject infoAboutLoginIncorrect;

	public Image bgView;

	public TMP_InputField loginAdminField;

	public TMP_InputField passwordAdminField;

	public int idFunction;

	[Header("Sound Effect")]
	public AudioSource audioSource;

	public AudioClip systemAdminCheck;

	public void OpenApp()
	{
	}

	public void OpenAppFromMenu(ComputerDesktopAppAdapter adapter)
	{
	}

	public void OpenAppFromExplorer(FileSystemObject fso, Sprite _icon)
	{
	}

	public void CloseApp()
	{
	}

	private string InterpretFSOForName(FileSystemObject fso)
	{
		return null;
	}

	public void RenderGeneral()
	{
	}

	public void RenderSecurity()
	{
	}

	public void OpenMenu(int id)
	{
	}

	public void OpenPropEdit()
	{
	}

	public void ButtonOpenAdvancedPermissions()
	{
	}

	public static string ReplaceUnderscoresWithSpaces(string input)
	{
		return null;
	}

	public void AcceptLikeAdminYes()
	{
	}
}
