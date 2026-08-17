using System;
using Steamworks;

namespace Assets.Scripts.Steam;

public class LeaderboardEntry
{
	public LeaderboardEntry_t leaderboardEntry;

	public int[] details;

	public LeaderboardEntry(LeaderboardEntry_t leaderboardEntry, int[] details)
	{
		this.details = details;
		this.leaderboardEntry = (LeaderboardEntry_t)leaderboardEntry.m_steamIDUser;
		_ = leaderboardEntry.m_cDetails;
	}

	public ECharacter GetCharacter()
	{
		//IL_0088: Expected I4, but got O
		int[] array = details;
		if (Leaderboards.IsLegitCharacter(details))
		{
			if (details != null)
			{
				return (ECharacter)array[1];
			}
			NullReferenceException ex = new NullReferenceException();
			return (ECharacter)ex;
		}
		return ECharacter.Fox;
	}
}
