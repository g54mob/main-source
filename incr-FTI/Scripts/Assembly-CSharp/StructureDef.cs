using System.Collections.Generic;

public class StructureDef
{
	public StructureType type;

	public bool enabled;

	public readonly ItemList cost;

	public readonly List<Requirement> requirements;

	public StructureDef()
	{
		requirements = new List<Requirement>();
		cost = new ItemList();
		enabled = false;
	}

	public StructureDef(StructureType t)
	{
		type = t;
		cost = new ItemList();
		requirements = Research.RequirementsForStructure(t);
	}
}
