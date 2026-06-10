using NodeCanvas.Framework;
using NodeCanvas.StateMachines;
using ParadoxNotion.Design;
using UnityEngine;

namespace NodeCanvas.BehaviourTrees
{
	[Name("Sub FSM", 0)]
	[Description("Executes a sub FSM. Returns Running while the sub FSM is active. If a Success or Failure State is selected, then it will return Success or Failure as soon as the Nested FSM enters that state at which point the sub FSM will also be stoped. If the sub FSM ends otherwise, this node will return Success.")]
	[ParadoxNotion.Design.Icon("FSM", false, "")]
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
				return _nestedFSM.value;
			}
			set
			{
				_nestedFSM.value = value;
			}
		}

		public override BBParameter subGraphParameter => _nestedFSM;

		protected override Status OnExecute(Component agent, IBlackboard blackboard)
		{
			if (subGraph == null || subGraph.primeNode == null)
			{
				return Status.Optional;
			}
			if (base.status == Status.Resting)
			{
				base.status = Status.Running;
				this.TryStartSubGraph(agent, OnFSMFinish);
			}
			if (base.status == Status.Running)
			{
				base.currentInstance.UpdateGraph(base.graph.deltaTime);
			}
			if (!string.IsNullOrEmpty(successState) && base.currentInstance.currentStateName == successState)
			{
				base.currentInstance.Stop();
				return Status.Success;
			}
			if (!string.IsNullOrEmpty(failureState) && base.currentInstance.currentStateName == failureState)
			{
				base.currentInstance.Stop(success: false);
				return Status.Failure;
			}
			return base.status;
		}

		private void OnFSMFinish(bool success)
		{
			if (base.status == Status.Running)
			{
				base.status = (success ? Status.Success : Status.Failure);
			}
		}

		protected override void OnReset()
		{
			if (base.currentInstance != null)
			{
				base.currentInstance.Stop();
			}
		}
	}
}
