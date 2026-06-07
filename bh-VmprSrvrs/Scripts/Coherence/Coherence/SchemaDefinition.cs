using System;
using System.Collections.Generic;

namespace Coherence
{
	[Serializable]
	public class SchemaDefinition
	{
		public string SchemaId;

		public List<ComponentDefinition> ComponentDefinitions;

		public List<CommandDefinition> CommandDefinitions;

		public List<ArchetypeDefinition> ArchetypeDefinitions;

		public List<InputDefinition> InputDefinitions;
	}
}
