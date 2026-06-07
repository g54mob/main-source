using System;
using System.Collections.Generic;

namespace Coherence
{
	[Serializable]
	public class BakedComponent
	{
		public ComponentDefinition componentDefinition;

		public List<ArchetypeDefinition> archetypes;

		public bool hasRefFields;

		public List<ComponentMemberDescription> fieldsWithSimFrames;
	}
}
