using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewDialogueSequence", menuName = "Dialogue Sequence")]
public class DialogueSequenceSO : ScriptableObject
{
	public bool pauseGame = true;

	public List<DialogueLine> lines;
}
