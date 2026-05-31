using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SystemInstalationAfterSetup : MonoBehaviour
{
	public AppBase appBase;

	public systeminstalation systemInstalation;

	public ComputerVariables computerVariables;

	public DirectoryManager directoryManager;

	public ComputerDesktop computerDesktop;

	public List<SystemInstalationAfterSetupDesktopContent> appsToInstall;

	public UnityEvent AdditionalActionsBeforeAppInstall;

	public UnityEvent AdditionalActionsAfterAppInstall;

	public void PrepareOS()
	{
	}

	private void SetAllAppsAsNotInstalled()
	{
	}

	private void RenameTheFolderToYourUsername()
	{
	}
}
