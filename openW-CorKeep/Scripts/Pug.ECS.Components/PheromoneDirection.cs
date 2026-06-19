using System.Runtime.CompilerServices;
using Pug.UnityExtensions;

public struct PheromoneDirection
{
	public unsafe fixed byte dirs[2];

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public unsafe readonly Direction GetDirection(PheromoneType type)
	{
		return (Direction.Id)dirs[(int)type];
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public unsafe void SetDirection(PheromoneType type, Direction direction)
	{
		dirs[(int)type] = (byte)direction.id;
	}
}
