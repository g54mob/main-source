using System;
using UnityEngine;
using UnityEngine.Events;

[Serializable]
public class PauseGameSubMenuData
{
	public string name;

	public RectTransform canvas;

	public UnityEvent actionsOpen;

	public UnityEvent actionClose;

	public UnityEvent actionsMinimalize;
}
