using System.Collections.Generic;

public class MaterialSchematicCollection
{
	private readonly Dictionary<string, MaterialSchematic> collection;

	public MaterialSchematicCollection()
	{
		collection = new Dictionary<string, MaterialSchematic>();
	}

	public void AddMaterialSchematic(MaterialSchematic materialSchematic)
	{
		collection.Add(materialSchematic.Id, materialSchematic);
	}

	public MaterialSchematic GetMaterialSchematics(string id)
	{
		if (!collection.ContainsKey(id))
		{
			return null;
		}
		return collection[id];
	}
}
