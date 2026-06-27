using System;
using System.ComponentModel;

public class MetaType
{
	public Type ComponentType { get; private set; }

	private MetaType(Type componentType)
	{
		ComponentType = componentType;
	}

	public static MetaType Create<T>() where T : IComponent
	{
		return new MetaType(typeof(T));
	}
}
