using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;

namespace NodeCanvas.StateMachines
{
	[Name("Action State", 100)]
	[Description("Execute a number of Action Tasks OnEnter. All actions will be stoped OnExit. This state is Finished when all Actions are finished as well")]
	public class ActionState : FSMState, ITaskAssignable, IGraphElement
	{
		[SerializeField]
		private ActionList _actionList;

		[SerializeField]
		private bool _repeatStateActions;

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

		public ActionList actionList
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public bool repeatStateActions
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

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
