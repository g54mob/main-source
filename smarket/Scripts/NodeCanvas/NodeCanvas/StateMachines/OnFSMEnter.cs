using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;

namespace NodeCanvas.StateMachines
{
	[Description("Execute a number of Actions when the FSM starts/enters, if Conditions are met. This is not a state.")]
	[Color("ff64cb")]
	[Icon("MacroIn", false, null)]
	[Name("On FSM Enter", 0)]
	public class OnFSMEnter : FSMNode, IUpdatable, IGraphElement
	{
		[SerializeField]
		private ConditionList _conditionList;

		[SerializeField]
		private ActionList _actionList;

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

		void IUpdatable.Update()
		{
		}
	}
}
