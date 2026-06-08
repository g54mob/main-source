using UnityEngine;

public struct BoardPosition
{
	public int x;

	public int y;

	public Vector2 position;

	public BoardPosition(int x, int y)
	{
		this.x = x;
		this.y = y;
		position.x = x;
		position.y = y;
	}
}
