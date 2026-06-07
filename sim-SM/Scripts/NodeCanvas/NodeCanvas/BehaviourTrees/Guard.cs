using System.Collections.Generic;
using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;

namespace NodeCanvas.BehaviourTrees
{
	[Name("Guard", 0)]
	[Category("Decorators")]
	[Icon("Shield", false, null)]
	[Description("Protects the decorated child from running if another Guard with the same token is already guarding (Running) that token.\nGuarding is global for all of the agent Behaviour Trees.")]
	public class Guard : BTDecorator
	{
		public enum GuardMode
		{
			ReturnFailure = 0,
			WaitUntilReleased = 1
		}

		[Tooltip("A unique Token to use for guarding.")]
		public BBParameter<string> token;

		[Tooltip("What to return in case the token is already guarded by another Guard.")]
		public GuardMode ifGuarded;

		private bool isGuarding;

		private static readonly Dictionary<GameObject, List<Guard>> guards;

		private static List<Guard> AgentGuards(Component agent)
		{
			return null;
		}

		public override void OnGraphStarted()
		{
		}

		public override void OnGraphStoped()
		{
		}

		protected override Status OnExecute(Component agent, IBlackboard blackboard)
		{
			return default(Status);
		}

		protected override void OnReset()
		{
		}

		private void SetGuards(Component guardAgent)
		{
		}
	}
}
