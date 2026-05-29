using System;

[Serializable]
public class PlayerTime
{
	public double totalseconds;

	public double seconds;

	public int minutes;

	public int hours;

	public int days;

	public PlayerTime()
	{
		totalseconds = 0.0;
		seconds = 0.0;
		minutes = 0;
		hours = 0;
		days = 0;
	}

	public void setTime(float t)
	{
		totalseconds = t;
		recalculateTime();
	}

	public void setTime(double t)
	{
		totalseconds = t;
		recalculateTime();
	}

	public void advanceTime(float t)
	{
		totalseconds += t;
		recalculateTime();
	}

	public void advanceTime(int time)
	{
		totalseconds += time;
		recalculateTime();
	}

	public void removeTime(float amount)
	{
		totalseconds -= amount;
		recalculateTime();
	}

	public string timeDisplay()
	{
		if (days != 0)
		{
			return days + " days " + hours + " hours " + minutes + " minutes " + seconds.ToString("#0") + " seconds ";
		}
		if (hours != 0)
		{
			return hours + " hours " + minutes.ToString("00") + " minutes " + seconds.ToString("#0") + " seconds ";
		}
		if (minutes != 0)
		{
			return minutes + " minutes " + seconds.ToString("#0") + " seconds ";
		}
		return seconds.ToString("#0") + " seconds";
	}

	public string timeDisplayColon()
	{
		return NumberOutput.timeOutput(totalseconds);
	}

	public string timeDisplayColon(int time)
	{
		string text = "";
		int num = 0;
		int num2 = 0;
		int num3 = 0;
		int num4 = 0;
		num = time / 86400;
		time %= 86400;
		num2 = time / 3600;
		time %= 3600;
		num3 = time / 60;
		time %= 60;
		num4 = time;
		if (num != 0)
		{
			if (num > 1)
			{
				return num + " days " + num2.ToString("00") + ":" + num3.ToString("00") + ":" + num4.ToString("00");
			}
			return num + " day " + num2.ToString("00") + ":" + num3.ToString("00") + ":" + num4.ToString("00");
		}
		if (num2 != 0)
		{
			return num2 + ":" + num3.ToString("00") + ":" + num4.ToString("00");
		}
		if (num3 != 0)
		{
			return num3 + ":" + num4.ToString("00");
		}
		return num4.ToString("#0") + "s";
	}

	public string inverseDisplay(double target)
	{
		return NumberOutput.timeOutput(target - totalseconds);
	}

	public string inverseDisplayColon(double target)
	{
		return NumberOutput.timeOutput(target - totalseconds);
	}

	public bool atTargetTime(double t)
	{
		if (totalseconds >= t)
		{
			return true;
		}
		return false;
	}

	public void reset()
	{
		totalseconds = 0.0;
		seconds = 0.0;
		minutes = 0;
		hours = 0;
		days = 0;
	}

	public void recalculateTime()
	{
		double num = totalseconds;
		if (totalseconds < 0.0)
		{
			totalseconds = 0.0;
		}
		days = (int)(num / 86400.0);
		num %= 86400.0;
		hours = (int)(num / 3600.0);
		num %= 3600.0;
		days = (int)(num / 86400.0);
		num %= 60.0;
		seconds = num;
	}

	public int getTimeAsHighscore()
	{
		if (totalseconds > 2147483647.0)
		{
			return int.MaxValue;
		}
		return (int)totalseconds;
	}
}
