using System;
using System.Collections.Generic;

public interface IInitializerContext
{
	protected static readonly Dictionary<Type, IInitializerContext> Cache;

	static IInitializerContext()
	{
		Cache = new Dictionary<Type, IInitializerContext>();
	}
}
