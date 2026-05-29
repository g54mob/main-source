using UnityEngine;

public class appExplorerOpenApps : MonoBehaviour
{
	public appNotepad notepad;

	public AppBase appBase;

	public AppPDFReader appPDFReader;

	public AppErrorOpenUnsupportedApplication appErrorOpenUnsupportedApplication;

	public void OpenApp(FileSystemObject item)
	{
	}

	public bool IsExecuteFile(FileSystemObject item)
	{
		return false;
	}
}
