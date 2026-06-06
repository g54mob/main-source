using TMPro;
using UnityEngine;

public class DialoguePlayerChoiceButton : MonoBehaviour
{
	[SerializeField]
	private TMP_Text _text;

	private DialogueNodePlayerChoices _relatedDialogueNode;

	private int _choiceIndex = -1;

	public void ChoiceClicked()
	{
		_relatedDialogueNode.Choose(_choiceIndex);
	}

	public void Initialize(string text, int choiceIndex, DialogueNodePlayerChoices relatedDialogueNode)
	{
		_text.text = text;
		_choiceIndex = choiceIndex;
		_relatedDialogueNode = relatedDialogueNode;
	}
}
