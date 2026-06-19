using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DialogueStory_", menuName = "Project/Dialogue/Story")]
public class DialogueStory : ScriptableObject
{
	public List<DialogueLine> Lines;
}
