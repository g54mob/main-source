using System;
using UnityEngine;

namespace MalbersAnimations.Reactions
{
	[Serializable]
	[AddTypeMenu("[Debug]", 0)]
	public class DebugReaction : Reaction
	{
		public string log = "debug";

		public bool pauseEditor;

		public override Type ReactionType => typeof(Component);

		protected override bool _TryReact(Component component)
		{
			Debug.Log("<color=white> [" + component.name + "]<b> [" + log + "] </b></color>", component);
			return true;
		}
	}
}
