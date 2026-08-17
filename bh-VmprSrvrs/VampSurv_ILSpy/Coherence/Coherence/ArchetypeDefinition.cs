using System;
using System.Collections.Generic;

namespace Coherence;

[Serializable]
public class ArchetypeDefinition : BaseDefinition
{
	public List<ArchetypeLOD> lods;

	public ArchetypeDefinition(string name, List<ArchetypeLOD> lods)
	{
		base.name = name;
		this.lods = lods;
	}
}
