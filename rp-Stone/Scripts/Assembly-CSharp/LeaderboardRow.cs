using UnityEngine;

public class LeaderboardRow : DialogButton
{
	public AsciiString rankLabel;

	public AsciiString nameLabel;

	public AsciiString scoreLabel;

	public int rank { get; set; }

	public void Setup(int rank, LeaderboardEntry entry)
	{
		this.rank = rank;
		string value = rank + ".";
		string value2 = entry?.name ?? "-";
		string value3 = entry?.score.ToString() ?? "-";
		rankLabel.SetValue(value);
		nameLabel.SetValue(value2);
		scoreLabel.SetValue(value3);
		if (entry != null && entry.isLocalPlayer)
		{
			SetForegroundColor(ColorConstants.green);
		}
		else
		{
			SetForegroundColor(ColorConstants.white);
		}
	}

	public void SetBackgroundColor(Color c)
	{
		edgeSymbols.bgColor = c;
		rankLabel.backgroundColor = c;
		nameLabel.backgroundColor = c;
		scoreLabel.backgroundColor = c;
	}

	private void SetForegroundColor(Color c)
	{
		rankLabel.color = c;
		nameLabel.color = c;
		scoreLabel.color = c;
	}

	public override void UpdateTic()
	{
		base.UpdateTic();
	}

	public override void Draw(AsciiRenderProcedural r, int offsetX, int offsetY)
	{
		base.Draw(r, offsetX, offsetY);
		rankLabel.Draw(r, offsetX, offsetY);
		nameLabel.Draw(r, offsetX, offsetY);
		scoreLabel.Draw(r, offsetX, offsetY);
	}
}
