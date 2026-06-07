using UnityEngine;

public class BaseWallPiece : MonoBehaviour
{
	public SpriteRenderer Rend;

	public BoxCollider2D Col;

	public CardinalDir TgtSide;

	public CardinalDir TopLeftAccess;

	public CardinalDir BotRightAccess;

	private const float kWallThickness = 1.125f;

	private void InitInternal()
	{
	}

	public void InitVert(float size, CardinalDir side, CardinalDir topAccess, CardinalDir botAccess)
	{
	}

	public void InitHorz(float size, CardinalDir side, CardinalDir leftAccess, CardinalDir rightAccess)
	{
	}
}
