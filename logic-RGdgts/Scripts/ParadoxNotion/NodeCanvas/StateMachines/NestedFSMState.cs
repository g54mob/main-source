using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;

namespace NodeCanvas.StateMachines
{
	public class NestedFSMState : FSMStateNested<FSM>
	{
		public enum FSMExitMode
		{
			StopAndRestart = 0,
			PauseAndResume = 1
		}

		[SerializeField]
		[ExposeField]
		private BBParameter<FSM> _nestedFSM;

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
