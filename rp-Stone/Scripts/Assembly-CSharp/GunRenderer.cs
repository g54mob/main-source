using UnityEngine;

public class GunRenderer : AsciiSprite
{
	public AsciiSprite verticalSprite;

	public AsciiSprite back180Sprite;

	public AsciiSprite meleeSwingVfx;

	public AsciiSprite storeSprite;

	private void Start()
	{
		Load();
		verticalSprite.Load();
		back180Sprite.Load();
		meleeSwingVfx.Load();
		storeSprite.Load();
	}

	public void Draw(AsciiRenderProcedural r, int offsetX, int offsetY, int level, Hero.State animationState)
	{
		if (level > 0)
		{
			SetFrameIndex(Mathf.Min(level, base.FrameCount) - 1);
			if (animationState == Hero.State.Store)
			{
				storeSprite.SetFrameIndex(GetFrameIndex());
				storeSprite.Draw(r, offsetX, offsetY);
			}
		}
	}
}
