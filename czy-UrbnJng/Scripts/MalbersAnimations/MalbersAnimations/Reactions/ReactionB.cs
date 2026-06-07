using System;
using System.Collections.Generic;
using UnityEngine;

namespace MalbersAnimations.Reactions
{
	[Serializable]
	public class ReactionB
	{
		[HideInInspector]
		public string display;

		[HideInInspector]
		public bool showExecute;

		[HideInInspector]
		public bool showExitInTransition;

		[Range(0f, 1f)]
		public float Time;

		[SubclassSelector]
		[SerializeReference]
		public Reaction reaction;

		[Tooltip("If the animation is interrupted by a transition and the time has not played yet, execute the Effect anyways")]
		[Hide("showExecute")]
		public bool ExecuteOnExit = true;

		[Tooltip("If the animation is interrupted, Execute the Effect as soon as it start transition to another Animation State")]
		[Hide("showExitInTransition")]
		public bool ExitInTransition = true;

		[Tooltip("Ignore the effect if  execute is called in Transition and the next transition is that one")]
		public List<string> IgnoreInTransition = new List<string>();

		public bool sent { get; set; }

		public Component target { get; set; }

		public List<int> IgnoreInTransitionHash { get; set; }

		public void React()
		{
			reaction.React(target);
			sent = true;
		}
	}
}
