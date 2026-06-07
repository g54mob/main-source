using NodeCanvas.DialogueTrees;
using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;

namespace NodeCanvas.BehaviourTrees
{
	public class NestedDT : BTNodeNested<DialogueTree>
	{
		[SerializeField]
		[ExposeField]
		private BBParameter<DialogueTree> _nestedDialogueTree;

		public override DialogueTree subGraph
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

		private void OnDLGFinished(bool success)
		{
		}

		protected override void OnReset()
		{
		}
	}
}
