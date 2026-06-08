using UnityEngine;

public class HeroBodySpriteBladeOfGod : AsciiSprite
{
	private int frameIndexOverride;

	private int _lastOffsetX;

	private float lastMovementTime;

	private float DURATION_NOT_MOVING_TO_RESET = 1f;

	private void CalculateMovingFrameIndex(int offsetX)
	{
		int positionX = GameStates.Singleton.hero.PositionX;
		if (_lastOffsetX != positionX)
		{
			_lastOffsetX = positionX;
			lastMovementTime = Time.realtimeSinceStartup;
			frameIndexOverride++;
			if (frameIndexOverride >= base.FrameCount)
			{
				frameIndexOverride = 0;
			}
		}
		else if (!AsciiAnimation.gameplayPaused && Time.realtimeSinceStartup - lastMovementTime > DURATION_NOT_MOVING_TO_RESET)
		{
			frameIndexOverride = 0;
		}
		SetFrameIndex(frameIndexOverride);
	}

	public override void Draw(AsciiRenderProcedural r, int offsetX, int offsetY)
	{
		CalculateMovingFrameIndex(offsetX);
		base.Draw(r, offsetX, offsetY);
	}

	public override void Draw(AsciiRenderProcedural r, int offsetX, int offsetY, float colorMultiply, Color tint)
	{
		CalculateMovingFrameIndex(offsetX);
		base.Draw(r, offsetX, offsetY, colorMultiply, tint);
	}

	public override void Draw(AsciiRenderProcedural r, int offsetX, int offsetY, Color overrideForeground)
	{
		CalculateMovingFrameIndex(offsetX);
		base.Draw(r, offsetX, offsetY, overrideForeground);
	}

	public override void Draw(AsciiRenderProcedural r, int offsetX, int offsetY, Color overrideForeground, Color overrideBackground)
	{
		CalculateMovingFrameIndex(offsetX);
		base.Draw(r, offsetX, offsetY, overrideForeground, overrideBackground);
	}

	public override void Draw(AsciiRenderProcedural r, int offsetX, int offsetY, float colorMultiply)
	{
		CalculateMovingFrameIndex(offsetX);
		base.Draw(r, offsetX, offsetY, colorMultiply);
	}
}
