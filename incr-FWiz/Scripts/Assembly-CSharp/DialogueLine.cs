using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Localization;

[Serializable]
public class DialogueLine
{
	[Header("Effects")]
	public List<string> StartLineStoryIDEvents;

	public List<string> EndLineStoryIDEvents;

	[Header("Character")]
	public DialogueCharacter Character;

	public string GraphicID;

	[Header("Text")]
	public LocalizedString Text;

	public List<string> SmartVariables;

	[Header("Features")]
	public float SkipTimer;

	public bool AllowsClickNext;

	public bool TopContainer;
}
