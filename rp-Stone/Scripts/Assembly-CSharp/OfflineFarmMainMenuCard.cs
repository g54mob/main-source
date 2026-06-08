using UnityEngine;

public class OfflineFarmMainMenuCard : DialogNineSlice
{
	public AsciiSprite ouroborosIcon;

	public AsciiString locationName;

	public AsciiString treasureHeader;

	public AsciiString treasureCounter;

	public AsciiString timeRemaining;

	private OfflineFarmController.OfflineRunSummary runSummary;

	private double lastElapsedSeconds;

	public void Show(OfflineFarmController.OfflineRunSummary runInfo)
	{
		base.SetState(State.Idle);
		runSummary = runInfo;
		if (runInfo != null)
		{
			locationName.SetValue(Te.xt(runInfo.locationName));
			UpdateTimeRemaining();
		}
	}

	public void Hide()
	{
		base.SetState(State.Disabled);
	}

	private void UpdateTimeRemaining()
	{
		if (runSummary == null)
		{
			return;
		}
		double totalSeconds = (OfflineFarmController.singleton.GetDateTimeNow() - runSummary.startTime).TotalSeconds;
		if (Mathf.Abs((float)(totalSeconds - lastElapsedSeconds)) < 0.2f)
		{
			return;
		}
		lastElapsedSeconds = totalSeconds;
		double num = 0.0;
		if ((double)runSummary.totalSeconds > totalSeconds && runSummary.secondsPerTreasure > 0f)
		{
			num = (double)runSummary.totalSeconds - totalSeconds;
			timeRemaining.SetValue(Utils.FormatTimeCasual((long)num, morePrecision: true));
			int num2 = Mathf.FloorToInt((float)(totalSeconds / (double)runSummary.secondsPerTreasure));
			num2 *= runSummary.treasuresPerLoop;
			if (num2 > runSummary.treasureCount)
			{
				num2 = runSummary.treasureCount;
			}
			treasureCounter.SetValue(num2 + "/" + runSummary.treasureCount);
		}
		else
		{
			timeRemaining.SetValue(Te.xt("tid_location_complete_m"));
			treasureCounter.SetValue(runSummary.treasureCount + "/" + runSummary.treasureCount);
		}
	}

	public override void UpdateTic()
	{
		if (base.CurrentState != State.Disabled)
		{
			base.UpdateTic();
			UpdateTimeRemaining();
		}
	}

	public override void Draw(AsciiRenderProcedural r, int offsetX, int offsetY)
	{
		if (base.CurrentState != State.Disabled)
		{
			offsetY = 0;
			base.Draw(r, offsetX, offsetY);
			offsetX += PositionX;
			offsetY += PositionY;
			ouroborosIcon.Draw(r, offsetX + locationName.PositionX, offsetY + 2);
			DrawString(locationName, r, offsetX, offsetY);
			DrawString(treasureHeader, r, offsetX, offsetY);
			DrawString(treasureCounter, r, offsetX, offsetY);
			DrawString(timeRemaining, r, offsetX, offsetY);
		}
	}

	private void DrawString(AsciiString asciiString, AsciiRenderProcedural r, int offsetX, int offsetY)
	{
		if (asciiString.Length % 2 == 0)
		{
			asciiString.Draw(r, offsetX + 1, offsetY);
		}
		else
		{
			asciiString.Draw(r, offsetX, offsetY);
		}
	}
}
