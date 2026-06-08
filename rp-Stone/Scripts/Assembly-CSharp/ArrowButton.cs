using System.Collections.Generic;

public class ArrowButton : DialogButton
{
	public enum Direction
	{
		Up = 0,
		Down = 1,
		Left = 2,
		Right = 3
	}

	public Direction direction;

	private Direction lastDirection;

	private bool firstDraw = true;

	private List<int> symbolsParam;

	public override void Draw(AsciiRenderProcedural r, int offsetX, int offsetY)
	{
		base.Draw(r, offsetX, offsetY);
		if (firstDraw || lastDirection != direction)
		{
			firstDraw = false;
			lastDirection = direction;
			UpdateArrow();
		}
	}

	private void UpdateArrow()
	{
		int num = 0;
		num = ((direction == Direction.Up) ? 30 : ((direction == Direction.Down) ? 31 : ((direction != Direction.Left) ? 16 : 17)));
		if (symbolsParam == null)
		{
			symbolsParam = new List<int>();
			symbolsParam.Add(num);
		}
		else
		{
			symbolsParam[0] = num;
		}
		label.SetValue(symbolsParam);
	}
}
