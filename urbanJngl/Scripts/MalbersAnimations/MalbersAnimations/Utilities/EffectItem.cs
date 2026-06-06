using System;
using System.Collections.Generic;
using UnityEngine;

namespace MalbersAnimations.Utilities
{
	[Serializable]
	public class EffectItem
	{
		[HideInInspector]
		public string name;

		[HideInInspector]
		public bool showExecute;

		[HideInInspector]
		public bool showExitInTransition;

		[Tooltip("ID of the Effect")]
		public int ID = 1;

		public EffectOption action;

		[Range(0f, 1f)]
		public float Time;

		[Tooltip("If the animation is interrupted by a transition and the time has not played yet, execute the Effect anyways")]
		[Hide("showExecute")]
		public bool ExecuteOnExit = true;

		[Tooltip("If the animation is interrupted, Execute the Effect as soon as it start transition to another Animation State")]
		[Hide("showExitInTransition")]
		public bool ExitInTransition = true;

		[Tooltip("Ignore the effect if execute is called in Transition and the next transition is this list. Use the name of the Animation State")]
		public List<string> IgnoreInTransition = new List<string>();

		public List<int> IgnoreInTransitionHash { get; set; }

		public bool sent { get; set; }
	}
}
