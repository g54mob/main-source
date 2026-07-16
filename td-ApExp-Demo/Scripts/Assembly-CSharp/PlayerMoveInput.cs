using UnityEngine;

public struct PlayerMoveInput
{
	public int PlayerIndex;

	public Vector2 Move;

	public PlayerMoveInput(int playerIndex, Vector2 move)
	{
		PlayerIndex = playerIndex;
		Move = move;
	}
}
