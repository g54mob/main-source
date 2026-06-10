using System.Globalization;

public class LogEntry
{
	public float Timestamp;

	public long TotalMoney;

	public long ChangeAmount;

	public string EventType;

	public string FishName;

	public string FishRarity;

	public string SkillID;

	public long SkillCost;

	public string AreaID;

	public int ExpeditionCount;

	public string FishCaughtSummary;

	public long MoneyGained;

	public int PondLevel;

	public LogEntry(string[] row)
	{
		float.TryParse(row[0], NumberStyles.Float, CultureInfo.InvariantCulture, out Timestamp);
		long.TryParse(row[1], out TotalMoney);
		long.TryParse(row[2], out ChangeAmount);
		EventType = row[3];
		FishName = row[4];
		FishRarity = row[5];
		SkillID = row[6];
		long.TryParse(row[7], out SkillCost);
		AreaID = row[8];
		int.TryParse(row[9], out ExpeditionCount);
		FishCaughtSummary = row[10];
		long.TryParse(row[11], out MoneyGained);
		int.TryParse(row[12], out PondLevel);
	}
}
