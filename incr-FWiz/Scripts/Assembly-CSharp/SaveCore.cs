using UnityEngine;

public static class SaveCore
{
	public enum SaveVersionLocation
	{
		Playtest = 0,
		NextFestDemo = 1,
		FullGame = 2
	}

	public const int SlotsCount = 5;

	public const string SlotExtension = ".sav";

	public static int SelectedSlot;

	public const string LastPlayedSlotKey = "LastPlayedSlot";

	public static string slotDirectory => null;

	public static bool Initialized { get; private set; }

	[RuntimeInitializeOnLoadMethod]
	public static void Initiate()
	{
	}

	public static void HandleIncompatibleSaves()
	{
	}

	private static void MigrateFromVersion(SaveVersionLocation sourceVersion)
	{
	}

	public static string GetSlotPath(int slotNum)
	{
		return null;
	}

	public static string GetSelectedSlotPath()
	{
		return null;
	}

	public static void SetPath(int slotIndex)
	{
	}

	public static void SetDefaulSlot(int slotIndex)
	{
	}

	public static void SetPathToDefaulSlot()
	{
	}

	public static SaveVersionLocation GetSaveVersion()
	{
		return default(SaveVersionLocation);
	}
}
