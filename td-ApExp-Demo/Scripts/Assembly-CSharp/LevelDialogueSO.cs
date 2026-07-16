using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Dialogue", menuName = "Level Dialogue SO")]
public class LevelDialogueSO : ScriptableObject
{
	public List<DialogueLine> DialogueLines = new List<DialogueLine>();
}
