using System;
using System.Collections.Generic;

public class ComponentModel
{
	public BlockBodyModel ParentBlockBodyModel { get; set; }

	public ComponentSchematic ComponentSchematic { get; private set; }

	public string Name => ComponentSchematic.Name;

	public ComponentType Type => ComponentSchematic.Type;

	public Properties Properties => ComponentSchematic.Properties;

	public Dictionary<string, object> InternalProperties { get; private set; }

	public virtual void Initialize()
	{
	}

	protected ComponentModel(ComponentSchematic componentSchematic)
	{
		ComponentSchematic = componentSchematic;
		InternalProperties = new Dictionary<string, object>();
	}

	public static ComponentModel Instantiate(ComponentSchematic componentSchematic)
	{
		Type type = System.Type.GetType(componentSchematic.Name + "Model");
		if (type == null)
		{
			return new ComponentModel(componentSchematic);
		}
		return Activator.CreateInstance(type, componentSchematic) as ComponentModel;
	}
}
