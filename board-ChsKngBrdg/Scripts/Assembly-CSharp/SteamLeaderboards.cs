using System;
using System.Threading.Tasks;
using Steamworks;
using Steamworks.Data;
using UnityEngine;

public class SteamLeaderboards : MonoBehaviour
{
	public static async Task<Leaderboard> TryGetLeaderboard(string id)
	{
		try
		{
			Leaderboard? leaderboard = await SteamUserStats.FindLeaderboardAsync(id);
			if (!leaderboard.HasValue)
			{
				return default(Leaderboard);
			}
			return leaderboard.Value;
		}
		catch (Exception exception)
		{
			Debug.LogException(exception);
		}
		return default(Leaderboard);
	}

	public static void AutoUpdateScoreToLeaderboard()
	{
		Debug.Log("auto update leaderboard score");
		int statInt = SteamUserStats.GetStatInt("SpeedrunTime");
		if (statInt >= 0)
		{
			if ((float)statInt >= CheatPrevention.minimumTimeToComplete && !CheatPrevention.hasCheatedPreviously)
			{
				TrySetScoreInLeaderboard("BestSpeedrunTime", statInt);
			}
			else
			{
				TrySetScoreInLeaderboard("CheaterSpeedrunTime", statInt);
			}
		}
	}

	public static async void TrySetScoreInLeaderboard(string id, int score)
	{
		_ = 1;
		try
		{
			await (await TryGetLeaderboard(id)).SubmitScoreAsync(score);
		}
		catch (Exception exception)
		{
			Debug.LogException(exception);
		}
	}

	public static async Task<LeaderboardEntry[]> TryGetGlobalLeaderboardEntries(string id, int count)
	{
		_ = 1;
		try
		{
			return await (await TryGetLeaderboard(id)).GetScoresAsync(count);
		}
		catch (Exception exception)
		{
			Debug.LogException(exception);
		}
		return null;
	}

	public static async Task<LeaderboardEntry[]> TryGetFriendLeaderboardEntries(string id)
	{
		_ = 1;
		try
		{
			return await (await TryGetLeaderboard(id)).GetScoresFromFriendsAsync();
		}
		catch (Exception exception)
		{
			Debug.LogException(exception);
		}
		return null;
	}

	public static async Task<LeaderboardEntry[]> TryGetGlobalLeaderboardEntriesAroundUser(string id, int start, int end)
	{
		_ = 1;
		try
		{
			return await (await TryGetLeaderboard(id)).GetScoresAroundUserAsync(start, end);
		}
		catch (Exception exception)
		{
			Debug.LogException(exception);
		}
		return null;
	}

	public static Texture2D GetTextureFromImage(Image image)
	{
		Texture2D texture2D = new Texture2D((int)image.Width, (int)image.Height, TextureFormat.RGBA32, mipChain: false);
		for (int i = 0; i < (int)image.Width; i++)
		{
			for (int j = 0; j < (int)image.Height; j++)
			{
				Steamworks.Data.Color pixel = image.GetPixel(i, j);
				texture2D.SetPixel(i, (int)image.Height - j, new UnityEngine.Color((float)(int)pixel.r / 255f, (float)(int)pixel.g / 255f, (float)(int)pixel.b / 255f, (float)(int)pixel.a / 255f));
			}
		}
		texture2D.filterMode = FilterMode.Point;
		texture2D.Apply();
		return texture2D;
	}
}
