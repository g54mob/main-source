using System.Collections.Generic;
using UnityEngine;

public class AppStoreSetupManager : MonoBehaviour
{
	public AppStoreApplicationPage appStoreApplicationPage;

	public DirectoryManager directoryManager;

	public appExplorer appExplorer;

	public AppBase appBase;

	public ComputerDesktop computerDesktop;

	public NotifiSystemManager notifiSystemManager;

	public string path;

	public List<AppStoreNowSetupApp> appStoreNowSetupApp;

	public void TerminatedProcesses()
	{
	}

	public void Setup(AppStoreBaseData application, string ownPath = "", bool fastmode = false)
	{
	}

	public static bool ValidatingFilesAndFolders(AppStoreBaseData application, DirectoryManager directoryManager, AppBase appBase)
	{
		return false;
	}

	private static bool CompareFileSystemObjects(FileSystemObject expected, FileSystemObject actual, DirectoryManager directoryManager)
	{
		return false;
	}

	private static bool CompareFileContents(FileSystemObjectContentFile file1, FileSystemObjectContentFile file2)
	{
		return false;
	}

	public static string RemoveWhitespace(string input)
	{
		return null;
	}

	public void Uninstall(AppStoreBaseData application)
	{
	}
}
