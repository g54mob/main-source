using UnityEngine;

public class BaseBoardObj : GridBoardObj
{
	public static BaseBoardObj II;

	public SpriteRenderer RendWallFront;

	public BoxCollider2D ColBorderFrontLeft;

	public BoxCollider2D ColBorderFrontRight;

	public Sprite SprWallLeft_RightRight;

	public Sprite SprWallLeft_RightLeft;

	public Sprite SprWallLeft_RightFront;

	public Sprite SprWallLeft_LeftRight;

	public Sprite SprWallLeft_LeftLeft;

	public Sprite SprWallLeft_LeftFront;

	public Sprite SprWallRight_RightRight;

	public Sprite SprWallRight_RightLeft;

	public Sprite SprWallRight_RightFront;

	public Sprite SprWallRight_LeftRight;

	public Sprite SprWallRight_LeftLeft;

	public Sprite SprWallRight_LeftFront;

	public Sprite SprWallTop_BotBot;

	public Sprite SprWallTop_BotTop;

	public Sprite SprWallTop_TopBot;

	public Sprite SprWallTop_TopTop;

	public Sprite SprWallBot_BotBot;

	public Sprite SprWallBot_BotTop;

	public Sprite SprWallBot_TopBot;

	public Sprite SprWallBot_TopTop;

	private const float kWallMargin = 0.5f;

	protected override void Awake()
	{
	}

	public override void InitBoard(float numCols, float numRows)
	{
	}
}
