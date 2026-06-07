using UnityEngine;

public class GridPieceObjFlipper : GridPieceObj
{
	public PolygonCollider2D PolCol;

	[NamedArray(typeof(LevelType))]
	public GridPieceViz[] VizFlippedY;

	public Vector2[] PolColDefault;

	public Vector2[] PolColFlippedX;

	public Vector2[] PolColFlippedY;

	public Vector2[] PolColFlippedXY;

	public bool[][] InnerGrid;

	public float[] BotY;

	public override void Init(GridPieceInst inst)
	{
	}

	public override void ResetScale()
	{
	}

	public override void InitEditor()
	{
	}

	public override void ResetSprite()
	{
	}

	public override Vector3 GetLocalCenterPos()
	{
		return default(Vector3);
	}

	public override bool HasUnevenFront()
	{
		return false;
	}

	public override float GetFrontYAtXPct(float pct)
	{
		return 0f;
	}
}
