using System;
using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;

namespace NodeCanvas.StateMachines
{
	[Name("Parallel", 0)]
	[Description("Execute a number of Actions with optional conditional requirement and in parallel to any other state, as soon as the FSM is started. All actions will prematurely be stoped as soon as the FSM stops as well. This is not a state.")]
	[Color("ff64cb")]
	[Icon("Repeat", false, null)]
	[Obsolete("Use On FSM Update node")]
	public class ConcurrentState : FSMNode, IUpdatable, IGraphElement
	{
		[SerializeField]
		private ConditionList _conditionList;

		[SerializeField]
		private ActionList _actionList;

		[SerializeField]
		private bool _repeatStateActions;

		private bool done;

		public ConditionList conditionList
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

		public override string name => null;

		public override int maxInConnections => 0;

		public override int maxOutConnections => 0;

		public override bool allowAsPrime => false;

		public override void OnValidate(Graph assignedGraph)
		{
		}

		public override void OnGraphStarted()
		{
		}

		public override void OnGraphStoped()
		{
		}

		public override void OnGraphPaused()
		{
		}

		void IUpdatable.Update()
		{
		}
	}
}
