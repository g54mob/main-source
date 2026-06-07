using System;
using UnityEngine;

[Serializable]
public class TaskManagerRCPBase
{
	public string name;

	[Header("Object")]
	public Transform RCPGameObject;

	[Header("Components")]
	public MiniMapDeviceInfo miniMapDeviceInfo;

	public SimpleRCP simpleRCP;

	public NetworkCard networkCard;

	public RCPNetworkSettings rcpNetworkSettings;

	[Header("Computer Connected Data")]
	public ComputerVariables computerVariables;
}
