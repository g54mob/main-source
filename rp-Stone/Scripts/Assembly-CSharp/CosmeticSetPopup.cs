using UnityEngine;

public class CosmeticSetPopup : PopUpModalScreen
{
	public CosmeticSetUI cosmeticSet;

	private int bgStyle;

	private float f_width;

	private float f_height;

	public override void Show()
	{
		if (!CosmeticController.singleton.HasActiveSetUnlocks())
		{
			base.SetState(State.Disabled);
			return;
		}
		base.Show();
		CosmeticController.SetUnlock setUnlockData = CosmeticController.singleton.PopActiveSetUnlocks();
		cosmeticSet.Setup(setUnlockData);
		f_width = Width;
		f_height = Height;
	}

	protected override void SetState(State newState)
	{
		base.SetState(newState);
		if (newState == State.Disabled)
		{
			cosmeticSet.Hide();
		}
	}

	public override void UpdateTic()
	{
		base.UpdateTic();
		if (base.currentState != State.Disabled)
		{
			cosmeticSet.UpdateTic();
		}
		if (base.currentState == State.Idle && cosmeticSet.currentState == CosmeticSetUI.State.Done && AsciiMouse.singleton.down0)
		{
			Hide();
		}
	}

	public override void Draw(AsciiRenderProcedural r, int offsetX, int offsetY)
	{
		base.Draw(r, offsetX, offsetY);
		offsetX += PositionX;
		offsetY += PositionY + (int)transitionOffsetY;
		if (cosmeticSet.currentState >= CosmeticSetUI.State.PrepareReward && cosmeticSet.currentState < CosmeticSetUI.State.Done)
		{
			float num = Time.deltaTime * 6f;
			f_height = Mathf.Lerp(f_height, r.height + 4, num);
			num *= 2f;
			f_width = Mathf.Lerp(f_width, r.width + 4, num);
		}
		int num2 = Mathf.RoundToInt(f_width);
		int num3 = Mathf.RoundToInt(f_height);
		BoxDrawing.Command command = new BoxDrawing.Command(offsetX - (num2 >> 1), offsetY - (num3 >> 1), num2, num3, ColorConstants.darkGrey, bgStyle);
		BoxDrawing.Draw(r, command);
		for (int i = command.x; i < command.x + command.w; i++)
		{
			for (int j = command.y; j < command.y + command.h; j++)
			{
				AsciiCellProcedural cell = r.GetCell(i, j);
				if (cell != null)
				{
					cell.backgroundColor = ColorConstants.black;
				}
			}
		}
		offsetY++;
		cosmeticSet.Draw(r, offsetX, offsetY);
	}

	protected override void Awake()
	{
		base.Awake();
		bgStyle = BoxDrawing.AddStyle(new char[14]
		{
			'.', '─', '.', '│', ' ', '│', '\'', '─', '\'', '┼',
			'├', '┤', '┬', '┴'
		});
	}
}
