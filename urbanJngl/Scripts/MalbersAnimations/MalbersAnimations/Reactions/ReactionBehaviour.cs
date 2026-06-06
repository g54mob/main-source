using System.Collections.Generic;
using UnityEngine;

namespace MalbersAnimations.Reactions
{
	public class ReactionBehaviour : StateMachineBehaviour
	{
		[Tooltip("List of reactions to send to the animator")]
		public List<ReactionB> reactions = new List<ReactionB>();

		public override void OnStateEnter(Animator anim, AnimatorStateInfo stateInfo, int layerIndex)
		{
			foreach (ReactionB reaction in reactions)
			{
				reaction.sent = false;
				reaction.target = reaction.reaction.VerifyComponent(anim);
				if (reaction.Time == 0f)
				{
					reaction.React();
				}
				GetIgnoreTransitionHashs(reaction);
			}
		}

		public override void OnStateUpdate(Animator anim, AnimatorStateInfo state, int layer)
		{
			int shortNameHash = anim.GetNextAnimatorStateInfo(layer).shortNameHash;
			bool flag = anim.IsInTransition(layer) && state.shortNameHash != shortNameHash;
			float num = state.normalizedTime % 1f;
			foreach (ReactionB reaction in reactions)
			{
				if (reaction.sent)
				{
					continue;
				}
				if (flag)
				{
					if (reaction.IgnoreInTransitionHash.Contains(shortNameHash))
					{
						reaction.sent = true;
					}
					else if (reaction.Time == 1f && reaction.ExitInTransition)
					{
						reaction.React();
						break;
					}
				}
				if (num >= reaction.Time)
				{
					reaction.React();
				}
			}
		}

		public override void OnStateExit(Animator anim, AnimatorStateInfo state, int layer)
		{
			if (anim.GetCurrentAnimatorStateInfo(layer).fullPathHash == state.fullPathHash)
			{
				return;
			}
			foreach (ReactionB reaction in reactions)
			{
				if (reaction.Time == 1f && !reaction.sent)
				{
					reaction.React();
				}
			}
		}

		private void GetIgnoreTransitionHashs(ReactionB item)
		{
			if (item.IgnoreInTransitionHash != null)
			{
				return;
			}
			item.IgnoreInTransitionHash = new List<int>();
			if (item.IgnoreInTransition == null || item.IgnoreInTransition.Count <= 0)
			{
				return;
			}
			foreach (string item2 in item.IgnoreInTransition)
			{
				item.IgnoreInTransitionHash.Add(Animator.StringToHash(item2));
			}
		}

		private void OnValidate()
		{
			for (int i = 0; i < reactions.Count; i++)
			{
				ReactionB reactionB = reactions[i];
				reactionB.display = "[" + ((reactionB.reaction != null) ? reactionB.reaction.ReactionType.Name : "<NONE>") + "]";
				if (reactionB.Time == 0f)
				{
					reactionB.display += "  -  [On Enter]";
				}
				else if (reactionB.Time == 1f)
				{
					reactionB.display += "  -  [On Exit]";
				}
				else
				{
					reactionB.display += $"  -  [OnTime] ({reactionB.Time:F2})";
				}
				if (reactionB.ExitInTransition && reactionB.Time == 1f)
				{
					reactionB.display += "[In Transition]";
				}
				reactionB.showExecute = reactionB.Time != 1f && reactionB.Time != 0f;
				reactionB.showExitInTransition = reactionB.Time == 1f;
			}
		}
	}
}
