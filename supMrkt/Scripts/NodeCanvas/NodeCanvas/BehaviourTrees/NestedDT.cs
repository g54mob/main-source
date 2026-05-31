using NodeCanvas.DialogueTrees;
using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;

namespace NodeCanvas.BehaviourTrees
{
	[Name("Sub Dialogue", 0)]
	[Description("Executes a sub Dialogue Tree. Returns Running while the sub Dialogue Tree is active. You can Finish the Dialogue Tree with the 'Finish' node and return Success or Failure.")]
	[Icon("Dialogue", false, null)]
	[DropReferenceType(typeof(DialogueTree))]
	public class NestedDT : BTNodeNested<DialogueTree>
	{
		[SerializeField]
		[ExposeField]
		[Name("Sub Tree", 0)]
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
