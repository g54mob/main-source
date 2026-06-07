using System.Collections.Generic;
using UnityEngine;
using XNode;

namespace Gh.Tk.Story.Requirements
{
	public class SatisfyRequirementsOverTimeDurationRequirementNode : RequirementNode, IRequirementProvider
	{
		public int durationInHours;

		[Input(ShowBackingValue.Unconnected, ConnectionType.Multiple, TypeConstraint.None, false)]
		public NodeConnection requirements;

		[Tooltip("use {target} and {current} to refer to the target and current hours")]
		public string labelTemplate;

		public IEnumerable<RequirementNode> GetRequirements()
		{
			return null;
		}

		protected override bool IsMetInternal(ActiveStory story)
		{
			return false;
		}

		public override string GetLabelKey(ActiveStory story)
		{
			return null;
		}
	}
}
