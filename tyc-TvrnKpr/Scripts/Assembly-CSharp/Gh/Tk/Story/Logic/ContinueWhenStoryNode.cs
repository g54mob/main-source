using System.Collections.Generic;
using Gh.Tk.Story.Requirements;
using XNode;

namespace Gh.Tk.Story.Logic
{
	public class ContinueWhenStoryNode : ConnectedStoryNode, IRequirementProvider
	{
		[Input(ShowBackingValue.Unconnected, ConnectionType.Multiple, TypeConstraint.None, false)]
		public NodeConnection whenTrue;

		[Input(ShowBackingValue.Unconnected, ConnectionType.Multiple, TypeConstraint.None, false)]
		public NodeConnection whenFalse;

		[Input(ShowBackingValue.Unconnected, ConnectionType.Multiple, TypeConstraint.None, false)]
		public NodeConnection whenAnyFalse;

		[Input(ShowBackingValue.Unconnected, ConnectionType.Multiple, TypeConstraint.None, false)]
		public NodeConnection whenAnyTrue;

		private RequirementNode[] _requirementNodesCache;

		public override void OnTrigger(ActiveStory story)
		{
		}

		public override void OnUpdate(ActiveStory story)
		{
		}

		protected bool ShouldContinue(ActiveStory story)
		{
			return false;
		}

		protected override void Init()
		{
		}

		public IEnumerable<RequirementNode> GetRequirements()
		{
			return null;
		}
	}
}
