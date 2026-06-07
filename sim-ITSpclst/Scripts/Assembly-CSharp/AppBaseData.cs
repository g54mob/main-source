using System;
using UnityEngine;
using UnityEngine.Events;

[Serializable]
public class AppBaseData
{
	public string Name;

	public string extension;

	public Sprite icon;

	public string[] supportedExtension;

	[Header("Open App")]
	public bool closeNetworkInfoApp;

	public UnityEvent<string> actionOpenParam;

	public UnityEvent actionOpen;

	[Header("Update")]
	public UnityEvent Update;

	[Header("Close App")]
	public UnityEvent actionCloseApp;

	[Header("Setup Data")]
	public bool isInstalled;

	public string path;
}
