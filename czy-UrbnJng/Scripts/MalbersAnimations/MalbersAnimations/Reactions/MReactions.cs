using UnityEngine;

namespace MalbersAnimations.Reactions
{
	[AddComponentMenu("Malbers/Animal Controller/Reactions")]
	public class MReactions : MonoBehaviour
	{
		[Tooltip("Try to find a target on Enable. (Search first in the hierarchy then in the parents)")]
		[ContextMenuItem("Find Target", "GetTarget on Enable")]
		public bool FindTarget;

		[SerializeField]
		private Component Target;

		[Tooltip("React when the Component is Enabled")]
		public bool ReactOnEnable;

		[Tooltip("React when the Component is Disabled")]
		public bool ReactOnDisable;

		[SerializeReference]
		[SubclassSelector]
		public Reaction reaction;

		private void OnEnable()
		{
			if (FindTarget)
			{
				Target = GetComponent(reaction.ReactionType) ?? GetComponentInParent(reaction.ReactionType);
			}
			if (ReactOnEnable)
			{
				React();
			}
		}

		private void OnDisable()
		{
			if (ReactOnDisable)
			{
				React();
			}
		}

		[ContextMenu("Find Target")]
		public void GetTarget()
		{
			Target = GetComponent(reaction.ReactionType) ?? GetComponentInParent(reaction.ReactionType);
			MTools.SetDirty(this);
		}

		public void React()
		{
			if (reaction != null)
			{
				reaction.React(Target);
			}
			else
			{
				Debug.LogError("Reaction is Empty. Please use any reaction", this);
			}
		}

		public void React(int index)
		{
			if (reaction != null && reaction is ListReaction listReaction)
			{
				index = Mathf.Clamp(index, 0, listReaction.reactions.Count - 1);
				listReaction.reactions[index]?.React(Target);
			}
			else
			{
				Debug.LogError("Reaction is Empty. Please use any reaction", this);
			}
		}

		public void React(Component newAnimal)
		{
			if (reaction != null)
			{
				Target = reaction.VerifyComponent(newAnimal);
				reaction.TryReact(Target);
			}
			else
			{
				Debug.LogError("Reaction is Empty. Please use any reaction", this);
			}
		}

		public void React(GameObject newAnimal)
		{
			React(newAnimal.transform);
		}
	}
}
