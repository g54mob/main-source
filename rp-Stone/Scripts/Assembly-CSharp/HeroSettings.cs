using System;

public class HeroSettings
{
	public const string DEFAULT_NAME = "simple one";

	public static DateTime lastSaveTime;

	public static string name = "simple one";

	public static bool bigHeadEnabled = false;

	public static bool isNameSet => name != "simple one";

	public static void ResetClock()
	{
		lastSaveTime = DateTime.Now;
	}

	public static void HourglassBonus()
	{
		DateTime now = DateTime.Now;
		if (lastSaveTime > now)
		{
			if ((lastSaveTime - now).TotalHours <= 24.0)
			{
				lastSaveTime = now;
			}
			else
			{
				lastSaveTime -= new TimeSpan(24, 0, 0);
			}
		}
	}

	public static string Serialize()
	{
		SlimJson.BeginSerialization();
		if (lastSaveTime < DateTime.Now)
		{
			lastSaveTime = DateTime.Now;
		}
		SlimJson.AddProperty("lastSaveTime", lastSaveTime);
		SlimJson.AddProperty("playerName", name);
		SlimJson.AddProperty("bigHead", bigHeadEnabled);
		return SlimJson.EndSerialization();
	}

	public static void Parse(string sjson)
	{
		if (sjson != null)
		{
			lastSaveTime = SlimJson.ParseDateTime(sjson, "lastSaveTime", DateTime.Now);
			name = SlimJson.Parse(sjson, "playerName", "simple one");
			bigHeadEnabled = SlimJson.ParseBool(sjson, "bigHead");
		}
		else
		{
			ClearProgress();
		}
	}

	public static void ClearProgress()
	{
		lastSaveTime = default(DateTime);
		name = "simple one";
		bigHeadEnabled = false;
	}
}
