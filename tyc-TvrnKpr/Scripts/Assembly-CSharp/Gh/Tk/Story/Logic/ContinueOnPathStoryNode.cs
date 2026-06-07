using System.Collections.Generic;
using Gh.Tk.Story.Requirements;
using XNode;

namespace Gh.Tk.Story.Logic
{
	public class ContinueOnPathStoryNode : StoryNode, IRequirementProvider
	{
		[Input(ShowBackingValue.Unconnected, ConnectionType.Multiple, TypeConstraint.None, false)]
		public NodeConnection input;

		[Input(ShowBackingValue.Unconnected, ConnectionType.Multiple, TypeConstraint.None, false)]
		public NodeConnection whenTrueContinueOnA;

		[Input(ShowBackingValue.Unconnected, ConnectionType.Multiple, TypeConstraint.None, false)]
		public NodeConnection whenTrueContinueOnB;

		[Output(ShowBackingValue.Never, ConnectionType.Multiple, TypeConstraint.None, false)]
		public NodeConnection a;

		[Output(ShowBackingValue.Never, ConnectionType.Multiple, TypeConstraint.None, false)]
		public NodeConnection b;

		public override void OnUpdate(ActiveStory story)
		{
		}

		public IEnumerable<RequirementNode> GetRequirements()
		{
			return null;
		}
	}
}
