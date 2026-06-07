using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Flotsam/Settings/Data Settings")]
public class DataSettings : ScriptableObject
{
	[Header("Communities")]
	public NameGenerator[] CommunityNameGenerators;

	[Tooltip("Limit of the amount of characters a community can have.")]
	public int CommunityCharacterLimit = 24;

	[Header("Analytics")]
	[Tooltip("Amount of time (in seconds) it takes for the analytics to send through pooled information.")]
	public int PooledAnalyticsCallIntervalTime = 600;

	public void GenerateCommunityNames(List<string> communityNames)
	{
		NameGenerator[] communityNameGenerators = CommunityNameGenerators;
		for (int i = 0; i < communityNameGenerators.Length; i++)
		{
			communityNameGenerators[i].AddAllNames(communityNames);
		}
	}

	public string ReturnRandomCommunityName()
	{
		string text = FlotsamGame.Random(CommunityNameGenerators).ReturnName();
		if (text.Length > CommunityCharacterLimit)
		{
			return ReturnRandomCommunityName();
		}
		return text;
	}
}
