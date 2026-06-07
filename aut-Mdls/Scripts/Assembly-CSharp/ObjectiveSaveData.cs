using System;
using System.Collections.Generic;
using AYellowpaper.SerializedCollections;
using Data.SaveData;
using Data.Shapes;
using Newtonsoft.Json;

[Serializable]
public class ObjectiveSaveData : AbstractSaveData
{
	public const int CurrentVersion = 1;

	public SerializedDictionary<int, int> ClaimedDeliveryTargets;

	public SerializedDictionary<string, int> ClaimedModuleChallenges;

	public List<int> ClaimedModuleChallengeAwards;

	public ObjectiveSaveData(Dictionary<int, int> claimedDeliveryTargets, Dictionary<RotationIndependentHash, int> claimedModuleChallenges, List<int> claimedModuleChallengeAwards)
		: base(1)
	{
		ClaimedDeliveryTargets = new SerializedDictionary<int, int>(claimedDeliveryTargets);
		ClaimedModuleChallenges = new SerializedDictionary<string, int>(claimedModuleChallenges.Count);
		foreach (KeyValuePair<RotationIndependentHash, int> claimedModuleChallenge in claimedModuleChallenges)
		{
			ClaimedModuleChallenges.Add(claimedModuleChallenge.Key.ToString(), claimedModuleChallenge.Value);
		}
		ClaimedModuleChallengeAwards = ((claimedModuleChallengeAwards != null) ? new List<int>(claimedModuleChallengeAwards) : new List<int>());
	}

	[JsonConstructor]
	public ObjectiveSaveData(Dictionary<int, int> claimedDeliveryTargets, Dictionary<string, int> claimedModuleChallenges, List<int> claimedModuleChallengeAwards)
		: base(1)
	{
		ClaimedDeliveryTargets = new SerializedDictionary<int, int>(claimedDeliveryTargets);
		ClaimedModuleChallenges = new SerializedDictionary<string, int>(claimedModuleChallenges);
		ClaimedModuleChallengeAwards = ((claimedModuleChallengeAwards != null) ? new List<int>(claimedModuleChallengeAwards) : new List<int>());
	}
}
