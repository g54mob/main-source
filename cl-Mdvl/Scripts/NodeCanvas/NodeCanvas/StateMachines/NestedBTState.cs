using NodeCanvas.BehaviourTrees;
using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;

namespace NodeCanvas.StateMachines
{
	[Name("Sub BehaviourTree", 0)]
	[Description("Execute a Behaviour Tree OnEnter. OnExit that Behavior Tree will be stoped or paused based on the relevant specified setting. You can optionaly specify a Success Event and a Failure Event which will be sent when the BT's root node status returns either of the two. If so, use alongside with a CheckEvent on a transition.")]
	[DropReferenceType(typeof(BehaviourTree))]
	[ParadoxNotion.Design.Icon("BT", false, "")]
	public class NestedBTState : FSMStateNested<BehaviourTree>
	{
		public enum BTExecutionMode
		{
			Once = 0,
			Repeat = 1
		}

		public enum BTExitMode
		{
			StopAndRestart = 0,
			PauseAndResume = 1
		}

		[SerializeField]
		[ExposeField]
		[Name("Sub Tree", 0)]
		private BBParameter<BehaviourTree> _nestedBT;

		[Tooltip("What will happen to the BT when this state exits.")]
		public BTExitMode exitMode;

		[Tooltip("Sould the BT repeat?")]
		public BTExecutionMode executionMode = BTExecutionMode.Repeat;

		[DimIfDefault]
		[Tooltip("The event to send when the BT finish in Success.")]
		public string successEvent;

		[DimIfDefault]
		[Tooltip("The event to send when the BT finish in Failure.")]
		public string failureEvent;

		public override BehaviourTree subGraph
		{
			get
			{
				return _nestedBT.value;
			}
			set
			{
				_nestedBT.value = value;
			}
		}

		public override BBParameter subGraphParameter => _nestedBT;

		protected override void OnEnter()
		{
			if (subGraph == null)
			{
				Finish(inSuccess: false);
				return;
			}
			base.currentInstance = (BehaviourTree)this.CheckInstance();
			base.currentInstance.repeat = executionMode == BTExecutionMode.Repeat;
			base.currentInstance.updateInterval = 0f;
			this.TryWriteAndBindMappedVariables();
			base.currentInstance.StartGraph(base.graph.agent, base.graph.blackboard.parent, Graph.UpdateMode.Manual, OnFinish);
			OnUpdate();
		}

		protected override void OnUpdate()
		{
			base.currentInstance.UpdateGraph(base.graph.deltaTime);
			if (!string.IsNullOrEmpty(successEvent) && base.currentInstance.rootStatus == Status.Success)
			{
				base.currentInstance.Stop();
			}
			if (!string.IsNullOrEmpty(failureEvent) && base.currentInstance.rootStatus == Status.Failure)
			{
				base.currentInstance.Stop(success: false);
			}
		}

		private void OnFinish(bool success)
		{
			if (base.status == Status.Running)
			{
				this.TryReadAndUnbindMappedVariables();
				if (!string.IsNullOrEmpty(successEvent) && success)
				{
					SendEvent(successEvent);
				}
				if (!string.IsNullOrEmpty(failureEvent) && !success)
				{
					SendEvent(failureEvent);
				}
				Finish(success);
			}
		}

		protected override void OnExit()
		{
			if (base.currentInstance != null)
			{
				if (base.status == Status.Running)
				{
					this.TryReadAndUnbindMappedVariables();
				}
				if (exitMode == BTExitMode.StopAndRestart)
				{
					base.currentInstance.Stop();
				}
				else
				{
					base.currentInstance.Pause();
				}
			}
		}
	}
}
