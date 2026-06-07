using System;
using UnityEngine;

[Serializable]
public class TaskManagerComputersBase
{
	public string name;

	[Header("Object")]
	public Transform ComputerGameObject;

	[Header("Components")]
	public MiniMapDeviceInfo miniMapDeviceInfo;

	public DirectoryManager directoryManager;

	public appExplorer appExplorer;

	public BiosMovement biosMovement;

	public CurrentTimeBIOS currentTimeBIOS;

	public PersonalizationSettings personalizationSettings;

	public systemOptionSettings systemOptionSettings;

	public ComputerVariables computerVariables;

	public ComputerVariablesSystemExpert computerVariablesSystemExpert;

	public WarningDatabase warningDatabase;

	public yourComputerInSmallCorp yourComputerInSmallCorp;

	public ComputerNetwork ComputerNetwork;

	public AppBase appBase;

	public AppVirusPlus appVirusPlus;

	public AppStore appStore;

	public AppEventLog appEventLog;

	public AppFirewall appFirewall;

	public TerminalComand_Ping terminalComand_Ping;

	public AppBrowser appBrowser;

	public SettingsMove appBrowserSettingsMove;

	public ComputerInterferenceNetwork computerInterferenceNetwork;
}
