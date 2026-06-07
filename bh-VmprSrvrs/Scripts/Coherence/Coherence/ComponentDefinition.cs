using System;
using System.Collections.Generic;

namespace Coherence
{
	[Serializable]
	public class ComponentDefinition : BaseDefinition
	{
		public string bitMasks;

		public List<ComponentMemberDescription> members;

		public DictionaryOfStringString overrides;

		public int totalSize;

		public string baseComponentName;

		public bool generatedByArchetype;

		public string bakeConditional;

		public ComponentDefinition(string name, string bakeConditional = "")
			: base(null)
		{
		}
	}
}
