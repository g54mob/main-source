using NodeCanvas.Framework;
using UnityEngine;

namespace NodeCanvas.StateMachines
{
	public class SuperActionState : FSMState
	{
		[SerializeField]
		private ActionList _onEnterList;

		[SerializeField]
		private ActionList _onUpdateList;

		[SerializeField]
		private ActionList _onExitList;

		private bool enterListFinished;

		public override void OnValidate(Graph assignedGraph)
		{
		}

		protected override void OnEnter()
		{
		}

		protected override void OnUpdate()
		{
		}

		protected override void OnExit()
		{
		}

		protected override void OnPause()
		{
		}
	}
}
