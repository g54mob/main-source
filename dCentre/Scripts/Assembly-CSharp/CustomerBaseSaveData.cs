using System;
using System.Collections.Generic;

[Serializable]
public class CustomerBaseSaveData
{
	public int customerBaseID;

	public int customerID;

	public Dictionary<int, string> subnetsPerApp;

	public float[] appsSpeedRequirements;

	public int[] appTypes;

	public int difficulty;

	public Dictionary<int, int> appObjectiveIDs;

	public int[] appsTimeBelowRequirements;

	public bool[] appReputationAwarded;
}
