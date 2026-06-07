using System;

public class Graph
{
	[Flags]
	public enum Type
	{
		WaterSurface = 1,
		Constructions = 2,
		UnityNavMesh = 0x10
	}

	public static bool TypesMatch(Type firstGraphType, Type secondGraphType)
	{
		return (firstGraphType & secondGraphType) != 0;
	}
}
