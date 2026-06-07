using System;
using System.Collections.Generic;

namespace Coherence
{
	[Serializable]
	public class InputDefinition : BaseDefinition
	{
		public List<ComponentMemberDescription> members;

		public int totalSize;

		public InputDefinition(string name, List<ComponentMemberDescription> members, int totalSize)
			: base(null)
		{
		}
	}
}
