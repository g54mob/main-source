using System;

[AttributeUsage(AttributeTargets.Property, Inherited = true)]
public class ToggleGroupProperty : Attribute
{
	public int NbOfProperties { get; protected set; }

	public ToggleGroupProperty(int nbOfProperties)
	{
		NbOfProperties = nbOfProperties;
	}
}
