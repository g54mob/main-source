using System;
using System.Collections.Generic;
using NodeCanvas.Framework;
using UnityEngine;

namespace NodeCanvas.DialogueTrees
{
	[AddComponentMenu("NodeCanvas/Dialogue Tree Controller")]
	public class DialogueTreeController : GraphOwner<DialogueTree>, IDialogueActor
	{
		string IDialogueActor.name => null;

		Texture2D IDialogueActor.portrait => null;

		Sprite IDialogueActor.portraitSprite => null;

		Color IDialogueActor.dialogueColor => default(Color);

		Vector3 IDialogueActor.dialoguePosition => default(Vector3);

		Transform IDialogueActor.transform => null;

		public void StartDialogue()
		{
		}

		public void StartDialogue(Action<bool> callback)
		{
		}

		public void StartDialogue(IDialogueActor instigator)
		{
		}

		public void StartDialogue(DialogueTree newTree, IDialogueActor instigator, Action<bool> callback)
		{
		}

		public void StartDialogue(IDialogueActor instigator, Action<bool> callback)
		{
		}

		public void PauseDialogue()
		{
		}

		public void StopDialogue()
		{
		}

		public void SetActorReference(string paramName, IDialogueActor actor)
		{
		}

		public void SetActorReferences(Dictionary<string, IDialogueActor> actors)
		{
		}

		public IDialogueActor GetActorReferenceByName(string paramName)
		{
			return null;
		}
	}
}
