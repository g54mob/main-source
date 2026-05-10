using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;

namespace NodeCanvas.StateMachines
{
	[Description("Execute a number of Actions repeatedly and in parallel to any other FSM state while the FSM is running. Conditions are optional. This is not a state.")]
	[Color("ff64cb")]
	[Icon("Repeat", false, null)]
	[Name("On FSM Update", 0)]
	public class OnFSMUpdate : FSMNode, IUpdatable, IGraphElement
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
