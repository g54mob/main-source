using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;

namespace NodeCanvas.StateMachines
{
	[Name("Sub FSM", 0)]
	[Description("Execute a sub FSM OnEnter, and Stop that FSM OnExit. This state is Finished only when and if the sub FSM is finished as well.")]
	[DropReferenceType(typeof(FSM))]
	[Icon("FSM", false, null)]
	public class NestedFSMState : FSMStateNested<FSM>
	{
		public enum FSMExitMode
		{
			StopAndRestart = 0,
			PauseAndResume = 1
		}

		[SerializeField]
		[ExposeField]
		[Name("Sub FSM", 0)]
		private BBParameter<FSM> _nestedFSM;

		[Tooltip("What will happen to the sub FSM when this state exits.")]
		public FSMExitMode exitMode;

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

		protected override void OnEnter()
		{
		}

		protected override void OnUpdate()
		{
		}

		protected override void OnExit()
		{
		}
	}
}
