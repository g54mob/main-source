public class ComponentSchematic
{
	public const string Model = "Model";

	public string Name { get; set; }

	public ComponentType Type { get; set; }

	public Properties Properties { get; private set; }

	public ComponentSchematic()
	{
		Properties = new Properties();
		Type = ComponentType.Other;
	}

	public Properties CloneProperties()
	{
		return Properties.Clone();
	}
}
