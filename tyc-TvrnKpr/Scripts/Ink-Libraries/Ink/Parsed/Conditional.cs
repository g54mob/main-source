using System.Collections.Generic;
using Ink.Runtime;

namespace Ink.Parsed
{
	public class Conditional : Object
	{
		private ControlCommand _reJoinTarget;

		public Expression initialCondition { get; private set; }

		public List<ConditionalSingleBranch> branches { get; private set; }

		public Conditional(Expression condition, List<ConditionalSingleBranch> branches)
		{
		}

		public override Ink.Runtime.Object GenerateRuntimeObject()
		{
			return null;
		}

		public override void ResolveReferences(Story context)
		{
		}
	}
}
