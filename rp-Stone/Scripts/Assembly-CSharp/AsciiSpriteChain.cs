using UnityEngine;

public class AsciiSpriteChain : AsciiSprite
{
	public AsciiSprite currentSprite { get; set; }

	public override void Load()
	{
		base.loaded = true;
	}

	public override void Draw(AsciiRenderProcedural r, int offsetX, int offsetY)
	{
		if (currentSprite != null)
		{
			currentSprite.Draw(r, offsetX - pivotX, offsetY - pivotY);
		}
	}

	public override void Draw(AsciiRenderProcedural r, int offsetX, int offsetY, float colorMultiply)
	{
		if (currentSprite != null)
		{
			currentSprite.Draw(r, offsetX - pivotX, offsetY - pivotY, colorMultiply);
		}
	}

	public override void Draw(AsciiRenderProcedural r, int offsetX, int offsetY, float colorMultiply, Color tint)
	{
		if (currentSprite != null)
		{
			currentSprite.Draw(r, offsetX - pivotX, offsetY - pivotY, colorMultiply, tint);
		}
	}

	public override void Draw(AsciiRenderProcedural r, int offsetX, int offsetY, Color overrideForeground)
	{
		if (currentSprite != null)
		{
			currentSprite.Draw(r, offsetX - pivotX, offsetY - pivotY, overrideForeground);
		}
	}

	public override void Draw(AsciiRenderProcedural r, int offsetX, int offsetY, Color overrideForeground, Color overrideBackground)
	{
		if (currentSprite != null)
		{
			currentSprite.Draw(r, offsetX - pivotX, offsetY - pivotY, overrideForeground, overrideBackground);
		}
	}
}
