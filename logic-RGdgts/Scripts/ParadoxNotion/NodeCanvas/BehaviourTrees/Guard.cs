using System.Collections.Generic;
using NodeCanvas.Framework;
using UnityEngine;

namespace NodeCanvas.BehaviourTrees
{
	public class Guard : BTDecorator
	{
		public enum GuardMode
		{
			ReturnFailure = 0,
			WaitUntilReleased = 1
		}

		public BBParameter<string> token;

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
