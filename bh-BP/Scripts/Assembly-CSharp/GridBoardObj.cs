using UnityEngine;

public class GridBoardObj : MonoBehaviour
{
	public static GridBoardObj I;

	public Sprite SprNoArt;

	public SpriteRenderer RendBorder;

	public BoxCollider2D ColBorderLeft;

	public BoxCollider2D ColBorderRight;

	public BoxCollider2D ColBorderTop;

	public SpriteRenderer RendPlayerPathHorz;

	public float ExtraMarginX;

	public float ExtraMarginY;

	public float ExtraColliderMarginX;

	public float ExtraColliderMarginY;

	protected const float kBorderWidth = 0.1f;

	protected virtual void Awake()
	{
	}

	public virtual void InitBoard(float numCols, float numRows)
	{
	}

	public virtual void InitBoard(float minX, float minY, float maxX, float maxY)
	{
	}

	public void SetExpansionPct(float minX, float minY, float maxX, float maxY, CardinalDir dir, float pct)
	{
	}
}
