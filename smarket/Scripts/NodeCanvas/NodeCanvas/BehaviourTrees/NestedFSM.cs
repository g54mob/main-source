using NodeCanvas.Framework;
using NodeCanvas.StateMachines;
using ParadoxNotion.Design;
using UnityEngine;

namespace NodeCanvas.BehaviourTrees
{
	[Name("Sub FSM", 0)]
	[Description("Executes a sub FSM. Returns Running while the sub FSM is active. If a Success or Failure State is selected, then it will return Success or Failure as soon as the Nested FSM enters that state at which point the sub FSM will also be stoped. If the sub FSM ends otherwise, this node will return Success.")]
	[Icon("FSM", false, null)]
	[DropReferenceType(typeof(FSM))]
	public class NestedFSM : BTNodeNested<FSM>
	{
		[SerializeField]
		[ExposeField]
		[Name("Sub FSM", 0)]
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
