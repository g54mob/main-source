using UnityEngine;

public class BulletSpriteRenderer : AsciiSprite
{
	public bool syncFrameAndMovementX;

	private bool firstTime = true;

	private int lastOffsetX;

	public override void Draw(AsciiRenderProcedural r, int offsetX, int offsetY)
	{
		Draw(r, offsetX, offsetY, 1f, ColorConstants.white);
	}

	public override void Draw(AsciiRenderProcedural r, int offsetX, int offsetY, float colorMultiply, Color tint)
	{
		if (syncFrameAndMovementX)
		{
			int i = 0;
			if (firstTime)
			{
				firstTime = false;
			}
			else
			{
				i = GetFrameIndex();
				if (offsetX > lastOffsetX)
				{
					i = (i + offsetX - lastOffsetX) % base.FrameCount;
				}
				else if (offsetX < lastOffsetX)
				{
					i -= lastOffsetX - offsetX;
					for (int frameCount = base.FrameCount; i < 0; i += frameCount)
					{
					}
				}
			}
			lastOffsetX = offsetX;
			SetFrameIndex(i);
		}
		base.Draw(r, offsetX, offsetY, colorMultiply, tint);
	}

	private void Awake()
	{
		Load();
	}
}
