using Unity.Entities;
using Unity.Mathematics;

public struct TileUpdateBuffer : IBufferElementData
{
	public enum Command
	{
		Add = 0,
		Remove = 1,
		Clear = 2
	}

	public Command command;

	public int2 position;

	public TileCD tile;
}
