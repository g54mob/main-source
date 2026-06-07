using NodeCanvas.BehaviourTrees;
using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;

namespace NodeCanvas.StateMachines
{
	public class ConcurrentSubTree : FSMNodeNested<BehaviourTree>, IUpdatable, IGraphElement
	{
		[SerializeField]
		[ExposeField]
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
