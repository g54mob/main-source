using System.Collections.Generic;

public static class DogFeatController
{
	private static List<ulong> eggFeatKeys = new List<ulong>();

	private static Dictionary<ulong, DogFeatEggsLaid> eggFeatDict = new Dictionary<ulong, DogFeatEggsLaid>();

	private static List<ulong> sleepFeatKeys = new List<ulong>();

	private static Dictionary<ulong, DogFeatHoursSlept> sleepFeatDict = new Dictionary<ulong, DogFeatHoursSlept>();

	private static List<ulong> poopFeatKeys = new List<ulong>();

	private static Dictionary<ulong, DogFeatAtePoop> poopFeatDict = new Dictionary<ulong, DogFeatAtePoop>();

	private static List<ulong> anxiousFeatKeys = new List<ulong>();

	private static Dictionary<ulong, DogFeatGotAnxious> anxiousFeatDict = new Dictionary<ulong, DogFeatGotAnxious>();

	public static void OnWorkStart()
	{
		eggFeatKeys.Clear();
		eggFeatDict.Clear();
		sleepFeatKeys.Clear();
		sleepFeatDict.Clear();
		poopFeatKeys.Clear();
		poopFeatDict.Clear();
		anxiousFeatKeys.Clear();
		anxiousFeatDict.Clear();
	}

	public static List<FeatStruct> GetRandomGoodFeats()
	{
		List<FeatStruct> objects = new List<FeatStruct>();
		if (eggFeatDict.Count > 0)
		{
			objects.Add(GetBestEggFeat());
		}
		if (sleepFeatDict.Count > 0)
		{
			objects.Add(GetBestSleepFeat());
		}
		if (poopFeatDict.Count > 0)
		{
			objects.Add(GetBestPoopFeat());
		}
		if (anxiousFeatDict.Count > 0)
		{
			objects.Add(GetBestAnxiousFeat());
		}
		for (int num = objects.Count - 1; num >= 0; num--)
		{
			if (!objects[num].featOwnerUID.HasValue)
			{
				objects.RemoveAt(num);
			}
		}
		ListUtil.ShuffleList(ref objects);
		List<ulong> list = new List<ulong>();
		for (int num2 = objects.Count - 1; num2 >= 0; num2--)
		{
			if (list.Contains(objects[num2].featOwnerUID.Value))
			{
				objects.RemoveAt(num2);
			}
			else
			{
				list.Add(objects[num2].featOwnerUID.Value);
			}
		}
		ListUtil.ShuffleList(ref objects, 4);
		return objects;
	}

	public static FeatStruct GetBestEggFeat()
	{
		ulong value = eggFeatKeys[0];
		DogFeatEggsLaid dogFeatEggsLaid = eggFeatDict[eggFeatKeys[0]];
		for (int i = 1; i < eggFeatKeys.Count; i++)
		{
			if (eggFeatDict[eggFeatKeys[i]] > dogFeatEggsLaid)
			{
				value = eggFeatKeys[i];
				dogFeatEggsLaid = eggFeatDict[eggFeatKeys[i]];
			}
		}
		return new FeatStruct(dogFeatEggsLaid.GetFeatString(), value);
	}

	public static FeatStruct GetBestSleepFeat()
	{
		ulong value = sleepFeatKeys[0];
		DogFeatHoursSlept dogFeatHoursSlept = sleepFeatDict[sleepFeatKeys[0]];
		for (int i = 1; i < sleepFeatKeys.Count; i++)
		{
			if (sleepFeatDict[sleepFeatKeys[i]] > dogFeatHoursSlept)
			{
				value = sleepFeatKeys[i];
				dogFeatHoursSlept = sleepFeatDict[sleepFeatKeys[i]];
			}
		}
		if (dogFeatHoursSlept.minutesSlept < 60)
		{
			return new FeatStruct("", null);
		}
		return new FeatStruct(dogFeatHoursSlept.GetFeatString(), value);
	}

	public static FeatStruct GetBestPoopFeat()
	{
		ulong value = poopFeatKeys[0];
		DogFeatAtePoop dogFeatAtePoop = poopFeatDict[poopFeatKeys[0]];
		for (int i = 1; i < poopFeatKeys.Count; i++)
		{
			if (poopFeatDict[poopFeatKeys[i]] > dogFeatAtePoop)
			{
				value = poopFeatKeys[i];
				dogFeatAtePoop = poopFeatDict[poopFeatKeys[i]];
			}
		}
		return new FeatStruct(dogFeatAtePoop.GetFeatString(), value);
	}

	public static FeatStruct GetBestAnxiousFeat()
	{
		ulong value = anxiousFeatKeys[0];
		DogFeatGotAnxious dogFeatGotAnxious = anxiousFeatDict[anxiousFeatKeys[0]];
		for (int i = 1; i < anxiousFeatKeys.Count; i++)
		{
			if (anxiousFeatDict[anxiousFeatKeys[i]] > dogFeatGotAnxious)
			{
				value = anxiousFeatKeys[i];
				dogFeatGotAnxious = anxiousFeatDict[anxiousFeatKeys[i]];
			}
		}
		return new FeatStruct(dogFeatGotAnxious.GetFeatString(), value);
	}

	public static void ReportEggsLaidFeatProgress(ulong dogID, int eggCountUpdate)
	{
		if (!eggFeatDict.ContainsKey(dogID))
		{
			eggFeatKeys.Add(dogID);
			eggFeatDict[dogID] = new DogFeatEggsLaid();
		}
		eggFeatDict[dogID].ReportFeatProgress(eggCountUpdate);
	}

	public static void ReportSleepFeatProgress(ulong dogID, int minutesUpdate)
	{
		if (!sleepFeatDict.ContainsKey(dogID))
		{
			sleepFeatKeys.Add(dogID);
			sleepFeatDict[dogID] = new DogFeatHoursSlept();
		}
		sleepFeatDict[dogID].ReportFeatProgress(minutesUpdate);
	}

	public static void ReportPoopFeatProgress(ulong dogID, int poopUpdate)
	{
		if (!poopFeatDict.ContainsKey(dogID))
		{
			poopFeatKeys.Add(dogID);
			poopFeatDict[dogID] = new DogFeatAtePoop();
		}
		poopFeatDict[dogID].ReportFeatProgress(poopUpdate);
	}

	public static void ReportAnxiousFeatProgress(ulong dogID, int timesAnxiousUpdate)
	{
		if (!anxiousFeatDict.ContainsKey(dogID))
		{
			anxiousFeatKeys.Add(dogID);
			anxiousFeatDict[dogID] = new DogFeatGotAnxious();
		}
		anxiousFeatDict[dogID].ReportFeatProgress(timesAnxiousUpdate);
	}
}
