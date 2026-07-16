using System;
using UnityEngine;

public class NPCDialogue : MonoBehaviour
{
	private Interactable interactable;

	[SerializeField]
	private LevelDialogueSO[] dialogues;

	[NonSerialized]
	public bool blockInteract;

	private void Awake()
	{
		interactable = GetComponent<Interactable>();
		Interactable obj = interactable;
		obj.CanInteract = (Func<bool>)Delegate.Combine(obj.CanInteract, new Func<bool>(CanInteract));
		interactable.OnInteractStart += Talk;
	}

	private bool CanInteract()
	{
		return !blockInteract;
	}

	private void Talk(Interactor interactor)
	{
		DialogueManager.Instance.StartDialogue(dialogues[0]);
	}
}
