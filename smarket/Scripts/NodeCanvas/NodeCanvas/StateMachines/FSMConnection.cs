using NodeCanvas.Framework;
using UnityEngine;

namespace NodeCanvas.StateMachines
{
	public class FSMConnection : Connection, ITaskAssignable<ConditionTask>, ITaskAssignable, IGraphElement
	{
		[SerializeField]
		private FSM.TransitionCallMode _transitionCallMode;

		[SerializeField]
		private ConditionTask _condition;

		public ConditionTask condition
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public Task task
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public FSM.TransitionCallMode transitionCallMode
		{
			get
			{
				return default(FSM.TransitionCallMode);
			}
			private set
			{
			}
		}

		public void EnableCondition(Component agent, IBlackboard blackboard)
		{
		}

		public void DisableCondition()
		{
		}

		public void PerformTransition()
		{
		}
	}
}
