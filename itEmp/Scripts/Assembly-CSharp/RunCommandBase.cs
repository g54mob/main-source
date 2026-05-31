using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[Serializable]
public class RunCommandBase
{
	public string name;

	public List<string> comands;

	[Header("App Base")]
	public string AppBaseComand;

	[Header("Action()")]
	public UnityEvent action;
}
