using System.Collections.Generic;

public class SchematicCollection
{
	private const string MissingBlockId = "missing_block";

	private const string SmallCubeId = "small_cube";

	private readonly Dictionary<string, Schematic> collection;

	public SchematicCollection()
	{
		collection = new Dictionary<string, Schematic>();
	}

	public void AddSchematic(Schematic bodySchematic)
	{
		if (!collection.ContainsKey(bodySchematic.Id))
		{
			collection.Add(bodySchematic.Id, bodySchematic);
		}
	}

	public Schematic GetSchematic(string id)
	{
		if (collection.ContainsKey(id))
		{
			return collection[id];
		}
		if (collection.ContainsKey("missing_block"))
		{
			return collection["missing_block"];
		}
		if (collection.ContainsKey("small_cube"))
		{
			return collection["small_cube"];
		}
		return null;
	}

	public ICollection<Schematic> GetAllSchematics()
	{
		return collection.Values;
	}
}
