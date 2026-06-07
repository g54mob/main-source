using System;

namespace Coherence
{
	[Serializable]
	public class BakedCommand
	{
		public CommandDefinition commandDefinition;

		public bool hasRefFields;
	}
}
