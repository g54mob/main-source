using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;

namespace NodeCanvas.StateMachines
{
	public class ConcurrentSubFSM : FSMNodeNested<FSM>, IUpdatable, IGraphElement
	{
		[SerializeField]
		[ExposeField]
		protected BBParameter<FSM> _subFSM;

		public override string name => null;

		public override int maxInConnections => 0;

		public override int maxOutConnections => 0;

		public override bool allowAsPrime => false;

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

		public override void OnGraphStarted()
		{
		}

		void IUpdatable.Update()
		{
		}
	}
}
