using System.Collections.Generic;
using Steamworks;
using UnityEngine;

public class LeaderboardEntry
{
	public int index;

	public string playerName;

	public int playerID;

	public int score;

	public int serverRank;

	public int actualRank;

	public Texture2D playerAvatar;

	public List<int> extraParams;

	public bool isValid;

	public bool isHaveUGC;

	public UGCHandle_t ugcHandle;

	public Texture2D screenshot;

	public LeaderboardEntry()
	{
	}

	public LeaderboardEntry(int index, string playerName, int playerID, int score, int rank, Texture2D playerAvatar, bool isValid, List<int> extraParams = null)
	{
	}
}
