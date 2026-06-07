using System.Collections.Generic;

public class ISAdQualitySegment
{
	public string name;

	public int age;

	public string gender;

	public int level;

	public int isPaying;

	public double inAppPurchasesTotal;

	public long userCreationDate;

	public Dictionary<string, string> customs;

	public void setCustom(string key, string value)
	{
	}

	public Dictionary<string, string> getSegmentAsDict()
	{
		return null;
	}
}
