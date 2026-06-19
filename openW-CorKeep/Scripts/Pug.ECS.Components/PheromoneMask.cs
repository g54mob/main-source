using System.Runtime.CompilerServices;

public struct PheromoneMask
{
	public uint Value;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public readonly bool HasType(PheromoneType type)
	{
		return (Value & (1 << (int)(type - 1))) != 0;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public void SetType(PheromoneType type)
	{
		Value |= (uint)(1 << (int)(type - 1));
	}
}
