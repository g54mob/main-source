using System;
using UnityEngine;

[Serializable]
public class DialogueNode
{
	[TextArea]
	public string mainText;

	[Space]
	public bool isQuestion;

	[Space]
	public string option1Text;

	public string option1FollowUp;

	[Space]
	public string option2Text;

	public string option2FollowUp;

	[Space]
	public bool givesQuest;
}
