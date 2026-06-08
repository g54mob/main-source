using UnityEngine;

public class SpriteRunesMasked : AsciiSprite
{
	private int[] symbols = new int[5];

	private void DrawRunes(AsciiRenderProcedural r, int offsetX, int offsetY)
	{
		offsetX -= pivotX;
		offsetY -= pivotY;
		int num = 0;
		if (EventController.singleton.GetActiveAndStartedEvent() != null)
		{
			num = EventController.singleton.GetProgress("custom_progress_mask", 0);
		}
		int num2 = offsetX;
		for (int i = 0; i < 5; i++)
		{
			Color foreground = ColorConstants.white;
			int num3 = 1 << i;
			if ((num & num3) != 0)
			{
				foreground = ColorConstants.rewardGreen;
			}
			r.SetCell(num2, offsetY, symbols[i], foreground);
			num2 += 2;
		}
	}

	private void Awake()
	{
		symbols[0] = SpecialSymbols.Map('∞');
		symbols[1] = SpecialSymbols.Map('♥');
		symbols[2] = SpecialSymbols.Map('*');
		symbols[3] = SpecialSymbols.Map('φ');
		symbols[4] = SpecialSymbols.Map('❄');
	}

	public override void Load()
	{
		height = 1;
		width = 9;
	}

	public override void Draw(AsciiRenderProcedural r, int offsetX, int offsetY)
	{
		DrawRunes(r, offsetX, offsetY);
	}

	public override void Draw(AsciiRenderProcedural r, int offsetX, int offsetY, Color overrideForeground)
	{
		DrawRunes(r, offsetX, offsetY);
	}

	public override void Draw(AsciiRenderProcedural r, int offsetX, int offsetY, Color overrideForeground, Color overrideBackground)
	{
		DrawRunes(r, offsetX, offsetY);
	}

	public override void Draw(AsciiRenderProcedural r, int offsetX, int offsetY, float colorMultiply)
	{
		DrawRunes(r, offsetX, offsetY);
	}

	public override void Draw(AsciiRenderProcedural r, int offsetX, int offsetY, float colorMultiply, Color tint)
	{
		DrawRunes(r, offsetX, offsetY);
	}
}
