using System;
using MalbersAnimations.Reactions;
using MalbersAnimations.Scriptables;
using UnityEngine;

namespace MalbersAnimations.Utilities
{
	[Serializable]
	public class MInteractorReaction
	{
		public ComparerInt Is;

		[Tooltip("Interactable Index. Set it to Zero or 1 to use this reaction with all Interactables")]
		public IntReference Index = new IntReference();

		public Component target;

		[SerializeReference]
		[SubclassSelector]
		public Reaction reaction;

		public void React(int newInteractable)
		{
			if (reaction != null)
			{
				if (Index.Value <= 0 || Index.Value.CompareInt(newInteractable, Is))
				{
					target = reaction.VerifyComponent(target);
					reaction.TryReact(target);
				}
			}
			else
			{
				Debug.LogError("Reaction is Empty. Please use any reaction");
			}
		}
	}
}
