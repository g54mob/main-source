using System;
using UnityEngine;

[Serializable]
public class TaskManagerPrintersBase
{
	public string name;

	[Header("Object")]
	public Transform PrinterGameObject;

	[Header("Components")]
	public MiniMapDeviceInfo miniMapDeviceInfo;

	public PrinterDevice printerDevice;

	public SimplePrinter simplePrinter;

	public NetworkCard networkCard;

	[Header("Computer Connected Data")]
	public ComputerVariables computerVariables;
}
