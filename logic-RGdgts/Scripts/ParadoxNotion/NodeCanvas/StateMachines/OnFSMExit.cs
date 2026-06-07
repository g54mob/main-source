using NodeCanvas.Framework;
using UnityEngine;

namespace NodeCanvas.StateMachines
{
	public class OnFSMExit : FSMNode
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
	}
}
