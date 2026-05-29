using System;
using UnityEngine;
using UnityEngine.Events;

[Serializable]
public class TabletAppBaseData
{
	public string Name;

	public Sprite icon;

	[Header("Open App")]
	public UnityEvent<string> actionOpenParam;

	public UnityEvent actionOpen;

	[Header("Update")]
	public UnityEvent Update;

	[Header("Close App")]
	public UnityEvent actionCloseApp;
}
