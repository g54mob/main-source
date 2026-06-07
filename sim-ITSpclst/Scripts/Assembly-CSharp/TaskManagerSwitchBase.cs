using System;
using UnityEngine;

[Serializable]
public class TaskManagerSwitchBase
{
	public string name;

	[Header("Object")]
	public Transform SwitchGameObject;

	[Header("Components")]
	public MiniMapDeviceInfo miniMapDeviceInfo;

	public NetworkSwitch networkSwitch;
}
