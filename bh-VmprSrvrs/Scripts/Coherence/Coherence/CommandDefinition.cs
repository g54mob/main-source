using System;
using System.Collections.Generic;

namespace Coherence
{
	[Serializable]
	public class CommandDefinition : BaseDefinition
	{
		public List<ComponentMemberDescription> members;

		public MessageTarget routing;

		public int totalSize;

		public string bakeConditional;

		public CommandDefinition(string name, string bakeConditional = "")
			: base(null)
		{
		}

		public CommandDefinition(string name, List<ComponentMemberDescription> members, MessageTarget routing, int totalSize, string bakeConditional)
			: base(null)
		{
		}
	}
}
