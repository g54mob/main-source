using System.Collections.Generic;

public class TitanicUniqueFoesRow : AsciiObject
{
	public AsciiTextBox textBox;

	public override void UpdateTic()
	{
		textBox.UpdateTic();
	}

	public override void Draw(AsciiRenderProcedural r, int offsetX, int offsetY)
	{
		textBox.Draw(r, offsetX, offsetY);
	}

	private void Awake()
	{
		List<string> uniqueFoeNames = BladeOfGodGoals.singleton.uniqueFoeNames;
		if (uniqueFoeNames == null)
		{
			textBox.Text = "";
			Height = 0;
			return;
		}
		string text = "";
		for (int i = 0; i < uniqueFoeNames.Count; i++)
		{
			if (i > 0)
			{
				text += "\n";
			}
			text = text + (i + 1) + ") " + Te.xt(uniqueFoeNames[i]);
		}
		textBox.Text = text;
		if (uniqueFoeNames.Count > 0)
		{
			Height = uniqueFoeNames.Count + 1;
		}
		else
		{
			Height = 0;
		}
		textBox.height = uniqueFoeNames.Count;
	}
}
