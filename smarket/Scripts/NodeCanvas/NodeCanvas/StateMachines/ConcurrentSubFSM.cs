using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;

namespace NodeCanvas.StateMachines
{
	[Name("Parallel Sub FSM", -1)]
	[Description("Execute a Sub FSM in parallel and for as long as this FSM is running.")]
	[Category("SubGraphs")]
	[Color("ff64cb")]
	public class ConcurrentSubFSM : FSMNodeNested<FSM>, IUpdatable, IGraphElement
	{
		[SerializeField]
		[ExposeField]
		[Name("Parallel FSM", 0)]
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
