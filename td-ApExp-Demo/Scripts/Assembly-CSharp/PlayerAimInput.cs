using UnityEngine;

public struct PlayerAimInput
{
	public int PlayerIndex;

	public Vector2 Aim;

	public PlayerAimInput(int playerIndex, Vector2 aim)
	{
		PlayerIndex = playerIndex;
		Aim = aim;
	}
}
