using UnityEngine;

public class HauntedGateQuestRow : QuestRow
{
	public AsciiString treasureAvailableLabel;

	public AsciiString waitTimeLabel;

	private long _lastSecondsRemaining = -1L;

	public override void Draw(AsciiRenderProcedural r, int offsetX, int offsetY)
	{
		bool flag = !UndeadCryptIntro.IsItemKey();
		base.mode = ((!flag) ? Mode.Normal : Mode.NormalWithCost);
		base.Draw(r, offsetX, offsetY);
		if (flag)
		{
			if (UndeadCryptIntro.IsTreasureAvailable())
			{
				treasureAvailableLabel.Draw(r, offsetX, offsetY);
			}
			else
			{
				DrawTreasureWaitTime(r, offsetX, offsetY);
			}
		}
	}

	private void DrawTreasureWaitTime(AsciiRenderProcedural r, int offsetX, int offsetY)
	{
		long num = (long)UndeadCryptIntro.GetTreasureSecondsRemaining();
		if (_lastSecondsRemaining != num)
		{
			_lastSecondsRemaining = num;
			waitTimeLabel.SetValue(Utils.FormatTimeCasual(num));
		}
		waitTimeLabel.Draw(r, offsetX, offsetY);
	}

	public override bool IsNewIndicating()
	{
		return base.IsNewIndicating();
	}

	public override Color GetNewIndicatorColor()
	{
		return base.GetNewIndicatorColor();
	}

	public override string GetNewIndicatorString()
	{
		if (UndeadCryptIntro.IsTreasureAvailable())
		{
			return "";
		}
		return base.GetNewIndicatorString();
	}
}
