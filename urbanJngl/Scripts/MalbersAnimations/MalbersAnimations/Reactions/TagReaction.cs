using System;
using UnityEngine;

namespace MalbersAnimations.Reactions
{
	[Serializable]
	[AddTypeMenu("Malbers/Tags", 0)]
	public class TagReaction : Reaction
	{
		public enum TagReactionType
		{
			Add = 0,
			Remove = 1
		}

		public TagReactionType action;

		public Tag Tag;

		public override Type ReactionType => typeof(Tags);

		protected override bool _TryReact(Component reactor)
		{
			Tags tags = reactor as Tags;
			switch (action)
			{
			case TagReactionType.Add:
				tags.AddTag(Tag);
				break;
			case TagReactionType.Remove:
				tags.RemoveTag(Tag);
				break;
			}
			return true;
		}
	}
}
