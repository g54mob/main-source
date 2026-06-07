public struct EnemyPlacement
{
	public GridPieceType Type;

	public int X;

	public bool FlipX;

	public bool FlipY;

	public int StackSize;

	public EnemyPlacement(GridPieceType t, int x, bool flipX = false, bool flipY = false)
	{
		Type = default(GridPieceType);
		X = 0;
		FlipX = false;
		FlipY = false;
		StackSize = 0;
	}
}
