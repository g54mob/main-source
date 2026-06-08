using UnityEngine;

internal class MockLeaderboardData
{
	public const string MY_NAME = "fruloo";

	public const int MY_RANK = 41;

	private static ulong CalculateHash(string read)
	{
		ulong num = 3074457345618258791uL;
		for (int i = 0; i < read.Length; i++)
		{
			num += read[i];
			num *= 3074457345618258799L;
		}
		return num;
	}

	public static string GenerateSaveId(int rank)
	{
		return "testpid" + rank;
	}

	public static int GenerateScore(int rank)
	{
		return (int)Mathf.Floor(187f * Mathf.Exp((1f - (float)rank) / 50f));
	}

	public static string GenerateName(int rank)
	{
		if (rank != 41)
		{
			return NameGenerator.GenerateName(CalculateHash(rank.ToString()));
		}
		return "fruloo";
	}
}
