using System;
using UnityEngine;

namespace MalbersAnimations.Reactions
{
	[Serializable]
	[AddTypeMenu("Unity/Behaviour", 0)]
	public class BehaviourReaction : Reaction
	{
		public enum Behaviour_Reaction
		{
			SetEnable = 0,
			Destroy = 1
		}

		public Behaviour_Reaction action;

		[Hide("action", new int[] { 0 })]
		public bool value = true;

		[Hide("action", new int[] { 1 })]
		public float time;

		public override Type ReactionType => typeof(Behaviour);

		protected override bool _TryReact(Component component)
		{
			Behaviour behaviour = component as Behaviour;
			switch (action)
			{
			case Behaviour_Reaction.SetEnable:
				behaviour.enabled = value;
				return true;
			case Behaviour_Reaction.Destroy:
				UnityEngine.Object.Destroy(component, time);
				return true;
			default:
				return false;
			}
		}
	}
}
