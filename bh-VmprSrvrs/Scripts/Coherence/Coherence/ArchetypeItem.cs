using System;
using System.Collections.Generic;

namespace Coherence
{
	[Serializable]
	public class ArchetypeItem
	{
		public int id;

		public int baseComponentId;

		public string componentName;

		public string bakeConditional;

		public List<ArchetypeItemField> fields;

		public ArchetypeItem(string componentName, List<ArchetypeItemField> fields, string bakeConditional = "")
		{
		}
	}
}
