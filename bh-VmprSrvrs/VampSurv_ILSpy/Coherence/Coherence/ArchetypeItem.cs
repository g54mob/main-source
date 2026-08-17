using System;
using System.Collections.Generic;

namespace Coherence;

[Serializable]
public class ArchetypeItem(string componentName, List<ArchetypeItemField> fields, string bakeConditional = "")
{
	public int id;

	public int baseComponentId;

	public string componentName = componentName;

	public string bakeConditional = bakeConditional;

	public List<ArchetypeItemField> fields = fields;
}
