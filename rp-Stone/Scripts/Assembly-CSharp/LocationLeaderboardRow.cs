using System;

public class LocationLeaderboardRow : LeaderboardRow
{
	private bool scoreTransformed;

	public new void Setup(int rank, LeaderboardEntry entry)
	{
		base.Setup(rank, entry);
		if (!scoreTransformed && scoreLabel.Value != "-")
		{
			try
			{
				int num = int.Parse(scoreLabel.Value);
				int num2 = num / 30;
				int num3 = num % 30;
				string text = Utils.FormatTimeCasual(num2);
				text = text + " " + num3 + "f";
				scoreLabel.SetValue(text);
				scoreTransformed = true;
			}
			catch (Exception)
			{
			}
		}
	}

	public void Reset()
	{
		scoreTransformed = false;
	}
}
