using UnityEngine;

public class AllRunesGoalUI : AsciiObject
{
	private int[] symbols = new int[5];

	public int mask { get; set; }

	public override void Draw(AsciiRenderProcedural r, int offsetX, int offsetY)
	{
		offsetX += PositionX;
		offsetY += PositionY;
		int num = offsetX;
		for (int i = 0; i < 5; i++)
		{
			Color foreground = ColorConstants.white;
			int num2 = 1 << i;
			if ((mask & num2) != 0)
			{
				foreground = ColorConstants.rewardGreen;
			}
			r.SetCell(num, offsetY, symbols[i], foreground);
			num += 2;
		}
	}

	public override void UpdateTic()
	{
	}

	private void Awake()
	{
		symbols[0] = SpecialSymbols.Map('∞');
		symbols[1] = SpecialSymbols.Map('♥');
		symbols[2] = SpecialSymbols.Map('*');
		symbols[3] = SpecialSymbols.Map('φ');
		symbols[4] = SpecialSymbols.Map('❄');
	}
}
