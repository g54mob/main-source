using System;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public class NetworkPatchPanelPort
{
	[Serializable]
	private class NetworkPatchPanelPortWrapper
	{
		public NetworkPatchPanelPortData[] ports;
	}

	[Serializable]
	private class NetworkPatchPanelPortData
	{
		public bool cableBackCorrect;

		public string backDeviceID;

		public int connectToPortBackDevice;

		public string frontDeviceID;

		public int connectToPortFrontDevice;
	}

	[Header("Back")]
	public bool cableBackCorrect;

	public UnityEngine.Object backDevice;

	public int connectToPortBackDevice;

	[Header("Front")]
	public UnityEngine.Object frontDevice;

	public int connectToPortFrontDevice;

	[Header("Objects")]
	public Button button;

	public Transform pathcord;

	public void ChangeFrontDevice(UnityEngine.Object device)
	{
	}

	public UnityEngine.Object GetBackDevice()
	{
		return null;
	}

	public static string NetworkPatchPanelPortSaveToString(NetworkPatchPanelPort[] ports)
	{
		return null;
	}

	public static NetworkPatchPanelPort[] NetworkPatchPanelLoadFromString(NetworkPatchPanelPort[] oryginal, string data)
	{
		return null;
	}
}
