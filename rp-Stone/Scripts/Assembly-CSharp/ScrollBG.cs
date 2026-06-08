using UnityEngine;

public class ScrollBG : DialogNineSlice
{
	public AsciiSprite scrollSideLeft;

	public AsciiSprite scrollSideRight;

	private bool bounceAtEndPending;

	private int bouncingAtEnd;

	protected override void SetState(State newState)
	{
		base.SetState(newState);
		scaleY = 1f;
		targetScaleY = 1f;
		if (newState == State.Idle)
		{
			bounceAtEndPending = true;
		}
	}

	public override void Draw(AsciiRenderProcedural r, int offsetX, int offsetY)
	{
		base.Draw(r, offsetX, offsetY);
		int num = (int)((float)Width * scaleX);
		int num2 = (int)((float)Height * scaleY);
		offsetX += PositionX + (Width - num) / 2;
		offsetY += PositionY + (Height - num2) / 2;
		if (bouncingAtEnd > 0)
		{
			offsetX--;
			num += 2;
		}
		scrollSideLeft.Draw(r, offsetX, offsetY);
		scrollSideRight.Draw(r, offsetX + num - 1, offsetY);
	}

	public override void UpdateTic()
	{
		base.UpdateTic();
		if (bounceAtEndPending)
		{
			bounceAtEndPending = false;
			bouncingAtEnd = 3;
		}
		bouncingAtEnd--;
	}

	protected override void Start()
	{
		base.Start();
		scrollSideLeft = Object.Instantiate(scrollSideLeft);
		scrollSideRight = Object.Instantiate(scrollSideRight);
		scrollSideLeft.Load();
		scrollSideRight.Load();
	}
}
