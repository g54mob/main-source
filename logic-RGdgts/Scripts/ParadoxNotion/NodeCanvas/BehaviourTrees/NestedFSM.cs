using NodeCanvas.Framework;
using NodeCanvas.StateMachines;
using ParadoxNotion.Design;
using UnityEngine;

namespace NodeCanvas.BehaviourTrees
{
	public class NestedFSM : BTNodeNested<FSM>
	{
		[SerializeField]
		[ExposeField]
		private BBParameter<FSM> _nestedFSM;

		[HideInInspector]
		public string successState;

		[HideInInspector]
		public string failureState;

		public override FSM subGraph
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public override BBParameter subGraphParameter => null;

		protected override Status OnExecute(Component agent, IBlackboard blackboard)
		{
			return default(Status);
		}

		private void OnFSMFinish(bool success)
		{
		}

		protected override void OnReset()
		{
		}
	}
}
