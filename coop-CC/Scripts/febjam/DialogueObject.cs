using System;
using UnityEngine;

[CreateAssetMenu(fileName = "dialogue-", menuName = "Dialogue", order = 1)]
public class DialogueObject : ScriptableObject
{
	[Serializable]
	public enum PortraitType
	{
		Talk = 0,
		Laugh = 1,
		Nod = 2
	}

	[TextArea]
	public string[] dialogues;

	public PortraitType[] portraitTypes;
}
