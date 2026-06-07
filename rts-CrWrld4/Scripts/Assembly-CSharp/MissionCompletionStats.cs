using System.Collections.Generic;
using NBT.Tags;

public class MissionCompletionStats
{
	public class MissionCompletionData
	{
		public string missionGUID;

		public bool isMissionComplete;

		public long[] lastPlayed;

		public int[] playCount;

		public int[] lastCompletionTime;

		public int[] lastEco;

		public int[] lastUnitsBuilt;

		public int[] lastUnitsLost;

		public HashSet<long>[] submitted;

		public bool approved;

		public Dictionary<string, int> tagVotes;

		public MissionCompletionData()
		{
		}

		public MissionCompletionData(string GUID)
		{
		}

		public void ReadData(Tag tag)
		{
		}

		public TagCompound WriteData()
		{
			return null;
		}
	}

	private static Dictionary<string, MissionCompletionData> data;

	private static bool initialized;

	private static int currentStorySystem;

	private static int currentSpanSystem;

	private static int currentPrecursorSystem;

	public static bool IsMissionComplete(string guid)
	{
		return false;
	}

	public static void SetMissionComplete(string guid, bool val)
	{
	}

	public static bool IsMissionObjectiveComplete(string guid, int type)
	{
		return false;
	}

	public static bool IsMissionObjectiveSubmitted(string guid, int type, long timestamp)
	{
		return false;
	}

	public static void SetMissionObjectiveSubmitted(string guid, int type, long timestamp)
	{
	}

	public static List<MissionCompletionData> GetAllData()
	{
		return null;
	}

	public static int GetCurrentStorySystem()
	{
		return 0;
	}

	public static int GetCurrentSpanSystem()
	{
		return 0;
	}

	public static int GetCurrentPrecursorSystem()
	{
		return 0;
	}

	public static void SetCurrentStorySystem(int val)
	{
	}

	public static void SetCurrentSpanSystem(int val)
	{
	}

	public static void SetCurrentPrecursorSystem(int val)
	{
	}

	public static int GetSpanCompleteCount()
	{
		return 0;
	}

	public static int GetDemoCompleteCount()
	{
		return 0;
	}

	public static MissionCompletionData GetData(string guid)
	{
		return null;
	}

	public static bool CreateVirginData(string guid)
	{
		return false;
	}

	public static void RemoveData(string guid)
	{
	}

	public static bool SetData(string guid, bool isMissionComplete, int completionType, int completionTime, int eco, int unitsBuilt, int unitsLost)
	{
		return false;
	}

	private static void SetData(MissionCompletionData md)
	{
	}

	public static void ReadData(Tag tag)
	{
	}

	public static TagCompound WriteData()
	{
		return null;
	}

	public static void SyncDemoMissionData()
	{
	}
}
