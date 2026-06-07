using System.Collections.Generic;
using XNode;

namespace Gh.Tk.Story.Requirements.Logic
{
	public class OrRequirement : RequirementNode, IRequirementProvider
	{
		[Input(ShowBackingValue.Unconnected, ConnectionType.Multiple, TypeConstraint.None, false)]
		public NodeConnection requirements;

		protected override bool IsMetInternal(ActiveStory story)
		{
			return false;
		}

		public IEnumerable<RequirementNode> GetRequirements()
		{
			return null;
		}
	}
}
