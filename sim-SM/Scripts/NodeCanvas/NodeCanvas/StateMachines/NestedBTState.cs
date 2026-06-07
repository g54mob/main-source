using NodeCanvas.BehaviourTrees;
using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;

namespace NodeCanvas.StateMachines
{
	[Name("Sub BehaviourTree", 0)]
	[Description("Execute a Behaviour Tree OnEnter. OnExit that Behavior Tree will be stoped or paused based on the relevant specified setting. You can optionaly specify a Success Event and a Failure Event which will be sent when the BT's root node status returns either of the two. If so, use alongside with a CheckEvent on a transition.")]
	[DropReferenceType(typeof(BehaviourTree))]
	[Icon("BT", false, null)]
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
		public BTExecutionMode executionMode;

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
				return null;
			}
			set
			{
			}
		}

		public override BBParameter subGraphParameter => null;

		protected override void OnEnter()
		{
		}

		protected override void OnUpdate()
		{
		}

		private void OnFinish(bool success)
		{
		}

		protected override void OnExit()
		{
		}
	}
}
