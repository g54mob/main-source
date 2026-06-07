using System.Collections.Generic;
using UnityEngine;

public class AppBase : PTSMonoBehaviour
{
	public NetworkInfo networkInfo;

	public appExplorer appExplorer;

	public DirectoryManager directoryManager;

	public ComputerDesktop computerDesktop;

	public AppStore appStore;

	public AppErrorOpenUnsupportedApplication appErrorOpenUnsupportedApplication;

	public List<Sprite> icons;

	public List<AppBaseData> Applications;

	public static bool displayUnsupportedAppsIcons;

	public static string[] supportedExtensions;

	public Transform AppsParent;

	public RectTransform AppErrorFilesAppPrefab;

	public RectTransform AppErrorFilesAppParent;

	private void Start()
	{
	}

	private void Update()
	{
	}

	public void OpenAppFromFile(FileSystemObject file)
	{
	}

	public void OpenApp(string data)
	{
	}

	public bool CanOpenApplicationByExtension(string appName, FileSystemObject file, params string[] allowedExtensions)
	{
		return false;
	}

	public void CloseAllApp()
	{
	}

	public static AppBase FindAppBase(Transform currentTransform)
	{
		return null;
	}

	public static AppBaseData FindAppBase(AppBase AppBase, string appName)
	{
		return null;
	}

	public static bool ValidateFiles(AppBase AppBase, DirectoryManager directoryManager, string nameInAppBase, out string AppNameFromApplicationBase)
	{
		AppNameFromApplicationBase = null;
		return false;
	}

	public void OpenAppErrorFilesApp(string nameApp)
	{
	}

	public void OpenAppErrorCmd(string nameApp)
	{
	}

	public void SetupApp(string AppBaseName, string setupPath = "", bool fastmode = false)
	{
	}

	public void UninstallApp(string AppBaseName)
	{
	}

	public void CreateShortcutApp(string AppBaseName, ComputerDesktop computerDesktop, bool isNotInApplicationStoreBase = false)
	{
	}

	public void DeleteShortcutApp(string AppBaseName, ComputerDesktop computerDesktop)
	{
	}

	public bool IsShortcutApp(string NameIdentifierInAppBase, ComputerDesktop computerDesktop, bool isNotInApplicationStoreBase = false)
	{
		return false;
	}

	public bool isInstallAppToOpenFileWithExtension(string extension)
	{
		return false;
	}
}
