using DevCmdLine;
using UnityEngine;

public class DevCmdHideUI : MonoBehaviour
{
	[DevCmd("toggleui", "Toggles visibility of the UI.\r\nUsage:\r\n    toggleui\r\n        Toggles visibility of the UI", new string[] { })]
	private static void HideUI(DevCmdArg[] args)
	{
		DebugHideUI[] array = Object.FindObjectsOfType<DebugHideUI>(includeInactive: true);
		foreach (DebugHideUI debugHideUI in array)
		{
			debugHideUI.gameObject.SetActive(!debugHideUI.gameObject.activeSelf);
		}
	}
}
