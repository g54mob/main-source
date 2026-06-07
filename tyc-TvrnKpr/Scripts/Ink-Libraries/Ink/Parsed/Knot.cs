using System.Collections.Generic;

namespace Ink.Parsed
{
	public class Knot : FlowBase
	{
		public override FlowLevel flowLevel => default(FlowLevel);

		public Knot(string name, List<Object> topLevelObjects, List<Argument> arguments, bool isFunction)
		{
		}

		public override void ResolveReferences(Story context)
		{
		}
	}
}
