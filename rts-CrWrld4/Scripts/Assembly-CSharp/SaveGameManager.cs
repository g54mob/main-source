using System.Collections.Generic;
using NBT.Tags;
using UnityEngine;

public class SaveGameManager
{
	private static string DIVIDER_GUID;

	public static bool HasSavedMission(string missionGUID, GameSpace.CATEGORY category, int colonyID)
	{
		return false;
	}

	public static string CalculateMissionGUID(byte[] data)
	{
		return null;
	}

	public static string GetMissionGUIDFromFile(string fileName)
	{
		return null;
	}

	public static void SaveAchievementsAndStats()
	{
	}

	public static void LoadAchievementsAndStats()
	{
	}

	public static void SaveFavorites(HashSet<string> favorites)
	{
	}

	public static HashSet<string> LoadFavorites()
	{
		return null;
	}

	public static void SaveHidden(HashSet<string> hidden)
	{
	}

	public static HashSet<string> LoadHidden()
	{
		return null;
	}

	public static void SaveReports(HashSet<string> reports)
	{
	}

	public static HashSet<string> LoadReports()
	{
		return null;
	}

	public static void ExportTerrainTheme(TerrainTheme theme, string fileName)
	{
	}

	public static TerrainTheme ImportTerrainTheme(string fileName)
	{
		return null;
	}

	public static TerrainTheme LoadEmbeddedTerrainTheme(string dataName)
	{
		return null;
	}

	public static void ExportADAMessage(ADAMessage mess, string fileName)
	{
	}

	public static ADAMessage ImportADAMessage(string fileName)
	{
		return null;
	}

	public static ADAMessage LoadEmbeddedADAMessage(string dataName)
	{
		return null;
	}

	public static void SaveMissionCompletionStats()
	{
	}

	public static void LoadMissionCompletionStats()
	{
	}

	public static TagCompound GetDemoMissionCompletionStatsTag()
	{
		return null;
	}

	public static void ExportCPack(CPack cpack, string fileName, bool branch)
	{
	}

	public static string GetCPackGUID(string fileName, out string cpackName)
	{
		cpackName = null;
		return null;
	}

	public static CPack ImportCPack(string fileName, bool overwriteOldScripts)
	{
		return null;
	}

	public static CPack ImportCPackEmbedded(string dataName)
	{
		return null;
	}

	public static byte[] GetRecorderData(GameRecorder gameRecorder)
	{
		return null;
	}

	public static void SaveRecorder(string fileName, GameRecorder gameRecorder)
	{
	}

	public static void LoadRecorder(string fileName, GameRecorder gameRecorder)
	{
	}

	public static void PreLoadMissionEmbedded(out int gsw, out int gsh, out string version, out string title, out string desc, out byte objectives, out string calculatedGUID, string fileName)
	{
		gsw = default(int);
		gsh = default(int);
		version = null;
		title = null;
		desc = null;
		objectives = default(byte);
		calculatedGUID = null;
	}

	public static void PreLoadMission(out int gsw, out int gsh, out string version, out string title, out string desc, out byte objectives, out string calculatedGUID, string fileName)
	{
		gsw = default(int);
		gsh = default(int);
		version = null;
		title = null;
		desc = null;
		objectives = default(byte);
		calculatedGUID = null;
	}

	public static void MakeTerrainThumbnail(string file)
	{
	}

	private static void CreateThumbnailFromTerrain(Texture2D tex, int gsw, int gsh, byte[] terrain, int[] creeper)
	{
	}

	public static void PreLoadMission(out int gsw, out int gsh, out string version, out string title, out string desc, out byte objectives, byte[] data)
	{
		gsw = default(int);
		gsh = default(int);
		version = null;
		title = null;
		desc = null;
		objectives = default(byte);
	}

	public static void LoadMissionEmbedded(string fileName)
	{
	}

	public static void LoadMission(string fileName, bool loadGUID = true)
	{
	}

	private static void LoadMission(byte[] data, bool loadGUID = true)
	{
	}

	private static string GetFixedLengthString(string s, int len)
	{
		return null;
	}

	public static void SaveMission(string fileName, bool includeGUID = true)
	{
	}

	public static void LoadGlobalData(TagCompound baseTag)
	{
	}

	private static void SaveGlobalData(TagCompound baseTag)
	{
	}

	private static void LoadCPacks(TagCompound baseTag)
	{
	}

	private static void SaveCPacks(TagCompound baseTag)
	{
	}

	private static void LoadGameEventLog(TagCompound baseTag)
	{
	}

	private static void SaveGameEventLog(TagCompound baseTag)
	{
	}

	private static void LoadBeams(TagCompound baseTag)
	{
	}

	private static void SaveBeams(TagCompound baseTag)
	{
	}

	private static void LoadWorld(TagCompound baseTag)
	{
	}

	private static void LoadGameMessage(TagCompound baseTag)
	{
	}

	private static void SaveGameMessage(TagCompound baseTag)
	{
	}

	private static void LoadBuildUnitManager(TagCompound baseTag)
	{
	}

	private static void SaveBuildUnitManager(TagCompound baseTag)
	{
	}

	private static void SaveWorld(TagCompound baseTag)
	{
	}

	private static void LoadScape(TagCompound baseTag)
	{
	}

	private static void SaveScape(TagCompound baseTag)
	{
	}

	private static void LoadGreenar(TagCompound baseTag)
	{
	}

	private static void SaveGreenar(TagCompound baseTag)
	{
	}

	private static void LoadOrbitals(TagCompound baseTag)
	{
	}

	private static void SaveOrbitals(TagCompound baseTag)
	{
	}

	private static void LoadMaterialsManager(TagCompound baseTag)
	{
	}

	private static void SaveMaterialsManager(TagCompound baseTag)
	{
	}

	private static void LoadDecalMaterialsManager(TagCompound baseTag)
	{
	}

	private static void SaveDecalMaterialsManager(TagCompound baseTag)
	{
	}

	private static void LoadUnits(TagCompound baseTag)
	{
	}

	private static void LoadUnitsLate()
	{
	}

	private static void SaveUnits(TagCompound baseTag)
	{
	}

	private static void LoadDecals(TagCompound baseTag)
	{
	}

	private static void SaveDecals(TagCompound baseTag)
	{
	}

	private static void LoadPackets(TagCompound baseTag)
	{
	}

	private static void SavePackets(TagCompound baseTag)
	{
	}

	public static byte[] ReadDataEmbedded(string dataName)
	{
		return null;
	}

	public static byte[] ReadData(string dataName)
	{
		return null;
	}

	public static void WriteDualData(byte[] data1, byte[] data2, string data1Name, string data2Name)
	{
	}

	public static void WriteDualData1(byte[] data1, byte[] data2, string data1Name, string data2Name)
	{
	}

	public static void WriteData(byte[] data, string dataName)
	{
	}

	public static void WriteData1(byte[] data, string dataName)
	{
	}

	public static Texture2D GetImageFromMap(string map, bool embedded)
	{
		return null;
	}
}
