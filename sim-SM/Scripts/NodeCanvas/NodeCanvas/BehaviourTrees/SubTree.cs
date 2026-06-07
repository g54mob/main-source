using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;

namespace NodeCanvas.BehaviourTrees
{
	[Name("Sub Tree", 0)]
	[Description("Executes a sub Behaviour Tree. The status of the root node in the SubTree will be returned.")]
	[Icon("BT", false, null)]
	[DropReferenceType(typeof(BehaviourTree))]
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
