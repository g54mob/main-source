using System.Collections.Generic;

public class UniqueFoesGoalUI : GoalBookEntryUI
{
	protected override void Awake()
	{
		base.Awake();
		base.currentState = State.Special;
	}

	public void Setup(List<string> uniqueFoeNames, int totalFoeCount)
	{
		int num = 0;
		string text = "";
		if (uniqueFoeNames != null)
		{
			num = uniqueFoeNames.Count;
			for (int i = 0; i < uniqueFoeNames.Count; i++)
			{
				string inStr = uniqueFoeNames[i];
				text += Te.xt(inStr);
				if (i < uniqueFoeNames.Count - 1)
				{
					text += ", ";
				}
			}
		}
		string text2 = $"{num}/{totalFoeCount}\n";
		text2 += text;
		textBox.Text = text2;
		Height = textBox.lineCount;
	}

	public override void Draw(AsciiRenderProcedural r, int offsetX, int offsetY)
	{
		offsetX += PositionX;
		offsetY += PositionY;
		textBox.Draw(r, offsetX, offsetY);
	}

	public override void UpdateTic()
	{
	}
}
