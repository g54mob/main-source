using NodeCanvas.BehaviourTrees;
using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;

namespace NodeCanvas.StateMachines
{
	[Name("Parallel Sub Behaviour Tree", -1)]
	[Description("Execute a Sub Behaviour Tree in parallel and for as long as this FSM is running.")]
	[Category("SubGraphs")]
	[Color("ff64cb")]
	public class ConcurrentSubTree : FSMNodeNested<BehaviourTree>, IUpdatable, IGraphElement
	{
		[SerializeField]
		[ExposeField]
		[Name("Parallel Tree", 0)]
		protected BBParameter<BehaviourTree> _subTree;

		public override string name => null;

		public override int maxInConnections => 0;

		public override int maxOutConnections => 0;

		public override bool allowAsPrime => false;

		public override BehaviourTree subGraph
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
