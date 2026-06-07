using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;

namespace NodeCanvas.BehaviourTrees
{
	public class SubTree : BTNodeNested<BehaviourTree>
	{
		[SerializeField]
		[ExposeField]
		private BBParameter<BehaviourTree> _subTree;

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

		protected override Status OnExecute(Component agent, IBlackboard blackboard)
		{
			return default(Status);
		}

		protected override void OnReset()
		{
		}
	}
}
