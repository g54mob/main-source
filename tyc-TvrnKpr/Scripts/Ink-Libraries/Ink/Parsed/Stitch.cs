using System.Collections.Generic;

namespace Ink.Parsed
{
	public class Stitch : FlowBase
	{
		public override FlowLevel flowLevel => default(FlowLevel);

		public Stitch(string name, List<Object> topLevelObjects, List<Argument> arguments, bool isFunction)
		{
		}
	}
}
