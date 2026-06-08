using System;
using SafeTypes;

public class ReferralDataModel
{
	public static readonly int[] REDEMPTION_THRESHOLDS = new int[6] { 1, 2, 3, 5, 7, 10 };

	private static readonly int[] EXPIRATION_DAYS = new int[4] { 7, 10, 14, 21 };

	public string referralKey;

	public DateTime expiration;

	public DateTime lastHeartbeat;

	public SafeInt redemptionCount;

	public SafeInt totalTreasureCount;

	public SafeInt collectedTreasureCount;

	public bool isNewQuestRow;

	public int progressValue { get; private set; }

	public int progressGoal { get; private set; }

	public static ReferralDataModel FromString(string sjson)
	{
		return new ReferralDataModel
		{
			expiration = SlimJson.ParseDateTime(sjson, "e"),
			lastHeartbeat = SlimJson.ParseDateTime(sjson, "h"),
			collectedTreasureCount = new SafeInt(SlimJson.ParseInt(sjson, "t")),
			isNewQuestRow = SlimJson.ParseBool(sjson, "n")
		};
	}

	public override string ToString()
	{
		SlimJson.BeginSerialization();
		SlimJson.AddProperty("e", expiration);
		SlimJson.AddProperty("h", lastHeartbeat);
		SlimJson.AddProperty("t", collectedTreasureCount.GetValue());
		SlimJson.AddProperty("n", isNewQuestRow);
		return SlimJson.EndSerialization();
	}

	public void Refresh()
	{
		UpdateProgressValues();
		UpdateExpirationDate();
		isNewQuestRow = true;
	}

	public void UpdateProgressValues()
	{
		int num = REDEMPTION_THRESHOLDS[0];
		int num2 = 0;
		int value = collectedTreasureCount.GetValue();
		progressValue = redemptionCount.GetValue();
		progressGoal = num;
		int num3 = 0;
		while (progressValue >= num && num3 < value)
		{
			num2++;
			progressValue -= num;
			num3++;
			if (num3 < REDEMPTION_THRESHOLDS.Length)
			{
				num = REDEMPTION_THRESHOLDS[num3];
			}
			progressGoal = num;
		}
		if (progressValue > progressGoal)
		{
			progressValue = progressGoal;
		}
		if (progressValue == progressGoal)
		{
			num2++;
		}
		totalTreasureCount = new SafeInt(num2);
	}

	public void UpdateExpirationDate()
	{
		int num = Math.Min(collectedTreasureCount.GetValue(), EXPIRATION_DAYS.Length - 1);
		int days = EXPIRATION_DAYS[num];
		expiration = DateTime.Now + new TimeSpan(days, 0, 0, 0);
	}

	public bool HasExpired()
	{
		return expiration < DateTime.Now;
	}

	public bool HasTreasureToCollect()
	{
		return collectedTreasureCount.GetValue() < totalTreasureCount.GetValue();
	}
}
