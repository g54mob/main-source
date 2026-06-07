using NodeCanvas.BehaviourTrees;
using NodeCanvas.Framework;
using ParadoxNotion.Design;

namespace NodeCanvas.Tasks.Actions
{
	[Category("✫ Utility")]
	[Description("Switch the entire Behaviour Tree of BehaviourTreeOwner")]
	public class SwitchBehaviourTree : ActionTask<BehaviourTreeOwner>
	{
		[RequiredField]
		public BBParameter<BehaviourTree> behaviourTree;

		protected override string info => null;

		protected override void OnExecute()
		{
		}
	}
}
